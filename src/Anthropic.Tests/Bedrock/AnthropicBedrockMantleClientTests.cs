using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Bedrock;
using Anthropic.Core;
using Anthropic.Exceptions;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Bedrock;

public class AnthropicBedrockMantleClientTests : IDisposable
{
    private readonly string? _origMantleApiKey;
    private readonly string? _origAwsApiKey;
    private readonly string? _origAwsRegion;
    private readonly string? _origAwsDefaultRegion;
    private readonly string? _origAnthropicApiKey;
    private readonly string? _origMantleBaseUrl;

    public AnthropicBedrockMantleClientTests()
    {
        _origMantleApiKey = Environment.GetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK");
        _origAwsApiKey = Environment.GetEnvironmentVariable("ANTHROPIC_AWS_API_KEY");
        _origAwsRegion = Environment.GetEnvironmentVariable("AWS_REGION");
        _origAwsDefaultRegion = Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION");
        _origAnthropicApiKey = Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY");
        _origMantleBaseUrl = Environment.GetEnvironmentVariable(
            "ANTHROPIC_BEDROCK_MANTLE_BASE_URL"
        );

        // Clear env so tests don't pick up ambient state
        Environment.SetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_API_KEY", null);
        Environment.SetEnvironmentVariable("AWS_REGION", null);
        Environment.SetEnvironmentVariable("AWS_DEFAULT_REGION", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_BEDROCK_MANTLE_BASE_URL", null);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Environment.SetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK", _origMantleApiKey);
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_API_KEY", _origAwsApiKey);
        Environment.SetEnvironmentVariable("AWS_REGION", _origAwsRegion);
        Environment.SetEnvironmentVariable("AWS_DEFAULT_REGION", _origAwsDefaultRegion);
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", _origAnthropicApiKey);
        Environment.SetEnvironmentVariable("ANTHROPIC_BEDROCK_MANTLE_BASE_URL", _origMantleBaseUrl);
    }

    record class BlankParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            AddDefaultHeaders(_request, _options);
        }

        public override Uri Url(ClientOptions options)
        {
            return new Uri($"{options.BaseUrl}/v1/messages");
        }
    }

    record class JsonBodyParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            AddDefaultHeaders(_request, _options);
        }

        public override Uri Url(ClientOptions options)
        {
            return new Uri($"{options.BaseUrl}/v1/messages");
        }

        internal override HttpContent? BodyContent()
        {
            return new StringContent("{}", Encoding.UTF8, "text/plain");
        }
    }

    static (HttpClient httpClient, List<HttpRequestMessage> captured) CreateCapturingClient()
    {
        var captured = new List<HttpRequestMessage>();
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Callback<HttpRequestMessage, CancellationToken>(
                (req, _) =>
                {
                    var clone = new HttpRequestMessage(req.Method, req.RequestUri);
                    foreach (var h in req.Headers)
                    {
                        clone.Headers.TryAddWithoutValidation(h.Key, h.Value);
                    }
                    if (req.Content != null)
                    {
                        clone.Content = new StringContent("");
                        clone.Content.Headers.Clear();
                        foreach (var h in req.Content.Headers)
                        {
                            clone.Content.Headers.TryAddWithoutValidation(h.Key, h.Value);
                        }
                    }
                    captured.Add(clone);
                }
            )
            .ReturnsAsync(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}"),
                }
            );
        return (new HttpClient(handlerMock.Object), captured);
    }

    static async Task<HttpRequestMessage> SendOneRequest(AnthropicBedrockMantleClient client)
    {
        var (httpClient, captured) = CreateCapturingClient();
        var rawClient = client
            .WithOptions(opts =>
            {
                opts.HttpClient = httpClient;
                return opts;
            })
            .WithRawResponse;

        await rawClient.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Single(captured);
        return captured[0];
    }

    static async Task<HttpRequestMessage> SendOneRequestWithBody(
        AnthropicBedrockMantleClient client
    )
    {
        var (httpClient, captured) = CreateCapturingClient();
        var rawClient = client
            .WithOptions(opts =>
            {
                opts.HttpClient = httpClient;
                return opts;
            })
            .WithRawResponse;

        await rawClient.Execute(
            new HttpRequest<JsonBodyParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Single(captured);
        return captured[0];
    }

    #region Validation

    [Fact]
    public void Constructor_WithoutBaseUrlOrRegion_Throws()
    {
        var ex = Assert.Throws<AnthropicInvalidDataException>(() =>
            new AnthropicBedrockMantleClient(new() { ApiKey = "test-key" })
        );
        Assert.Contains("base URL", ex.Message);
    }

    #endregion

    #region Region Resolution

    [Fact]
    public void Constructor_WithAwsRegionArg_DerivesBaseUrl()
    {
        var client = new AnthropicBedrockMantleClient(
            new()
            {
                ApiKey = "test-key",

                AwsRegion = "us-west-2",
            }
        );
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_WithAwsRegionEnvVar_DerivesBaseUrl()
    {
        Environment.SetEnvironmentVariable("AWS_REGION", "eu-west-1");
        var client = new AnthropicBedrockMantleClient(new() { ApiKey = "test-key" });
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_WithAwsDefaultRegionEnvVar_DerivesBaseUrl()
    {
        Environment.SetEnvironmentVariable("AWS_DEFAULT_REGION", "ap-southeast-1");
        var client = new AnthropicBedrockMantleClient(new() { ApiKey = "test-key" });
        Assert.NotNull(client);
    }

    [Fact]
    public async Task Constructor_RegionDerivedBaseUrlIsCorrect()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", AwsRegion = "us-east-1" }
        );
        var req = await SendOneRequest(client);
        Assert.StartsWith(
            "https://bedrock-mantle.us-east-1.api.aws/anthropic/v1/messages",
            req.RequestUri!.ToString()
        );
    }

    #endregion

    #region Request Headers — API Key Mode

    [Fact]
    public async Task ApiKeyMode_SendsBearerAuthHeader()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "sk-test-key", BaseUrl = "http://localhost" }
        );
        var req = await SendOneRequest(client);

        Assert.True(req.Headers.Contains("Authorization"));
        Assert.Equal("Bearer sk-test-key", req.Headers.GetValues("Authorization").Single());
        Assert.False(req.Headers.Contains("X-Api-Key"));
    }

    [Fact]
    public async Task ApiKeyMode_SendsContentTypeHeader()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "sk-test-key", BaseUrl = "http://localhost" }
        );
        var req = await SendOneRequestWithBody(client);

        Assert.NotNull(req.Content);
        Assert.Equal("application/json", req.Content!.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task ApiKeyMode_DoesNotSendSigV4Headers()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "sk-test-key", BaseUrl = "http://localhost" }
        );
        var req = await SendOneRequest(client);

        Assert.False(req.Headers.Contains("x-amz-date"));
        Assert.False(req.Headers.Contains("x-amz-content-sha256"));
        // Authorization header should be Bearer, not SigV4
        var authHeader = req.Headers.GetValues("Authorization").Single();
        Assert.StartsWith("Bearer ", authHeader);
    }

    #endregion

    #region Request Headers — SigV4 Mode

    [Fact]
    public async Task SigV4Mode_SendsSigV4Headers()
    {
        var client = new AnthropicBedrockMantleClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsRegion = "us-east-1",

                BaseUrl = "http://localhost",
            }
        );
        var req = await SendOneRequest(client);

        Assert.True(req.Headers.Contains("x-amz-date"));
        Assert.True(req.Headers.Contains("x-amz-content-sha256"));
        Assert.True(req.Headers.Contains("Authorization"));
        Assert.StartsWith(
            "AWS4-HMAC-SHA256 Credential=AKIAIOSFODNN7EXAMPLE/",
            req.Headers.GetValues("Authorization").Single()
        );
    }

    [Fact]
    public async Task SigV4Mode_UsesBedrockMantleServiceName()
    {
        var client = new AnthropicBedrockMantleClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsRegion = "us-east-1",
                BaseUrl = "http://localhost",
            }
        );
        var req = await SendOneRequest(client);

        var authHeader = req.Headers.GetValues("Authorization").Single();
        // Credential scope contains the service name: .../us-east-1/bedrock-mantle/aws4_request
        Assert.Contains("/us-east-1/bedrock-mantle/aws4_request", authHeader);
    }

    [Fact]
    public async Task SigV4Mode_SendsContentTypeHeader()
    {
        var client = new AnthropicBedrockMantleClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsRegion = "us-east-1",
                BaseUrl = "http://localhost",
            }
        );
        var req = await SendOneRequestWithBody(client);

        Assert.NotNull(req.Content);
        Assert.Equal("application/json", req.Content!.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task SigV4Mode_DoesNotSendApiKeyHeader()
    {
        var client = new AnthropicBedrockMantleClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsRegion = "us-east-1",

                BaseUrl = "http://localhost",
            }
        );
        var req = await SendOneRequest(client);

        Assert.False(req.Headers.Contains("X-Api-Key"));
    }

    [Fact]
    public async Task SigV4Mode_WithSessionToken_SendsSecurityTokenHeader()
    {
        var client = new AnthropicBedrockMantleClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsSessionToken = "FwoGZXIvYXdzEA_SESSION_TOKEN",
                AwsRegion = "us-east-1",

                BaseUrl = "http://localhost",
            }
        );
        var req = await SendOneRequest(client);

        Assert.True(req.Headers.Contains("x-amz-security-token"));
        Assert.Equal(
            "FwoGZXIvYXdzEA_SESSION_TOKEN",
            req.Headers.GetValues("x-amz-security-token").Single()
        );
    }

    #endregion

    #region Request Headers — skipAuth Mode

    [Fact]
    public async Task SkipAuth_DoesNotSendAuthHeaders()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { SkipAuth = true, BaseUrl = "http://localhost" }
        );
        var req = await SendOneRequest(client);

        Assert.False(req.Headers.Contains("X-Api-Key"));
        Assert.False(req.Headers.Contains("x-amz-date"));
        Assert.False(req.Headers.Contains("x-amz-content-sha256"));
        Assert.False(req.Headers.Contains("Authorization"));
        Assert.False(req.Headers.Contains("x-amz-security-token"));
    }

    [Fact]
    public async Task SkipAuth_SendsContentTypeHeader()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { SkipAuth = true, BaseUrl = "http://localhost" }
        );
        var req = await SendOneRequestWithBody(client);

        Assert.NotNull(req.Content);
        Assert.Equal("application/json", req.Content!.Headers.ContentType?.MediaType);
    }

    #endregion

    #region Auth Precedence

    [Fact]
    public async Task ApiKeyArg_TakesPrecedenceOverEnvApiKey()
    {
        Environment.SetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK", "env-key");
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "arg-key", BaseUrl = "http://localhost" }
        );
        var req = await SendOneRequest(client);

        Assert.Equal("Bearer arg-key", req.Headers.GetValues("Authorization").Single());
    }

    [Fact]
    public void Constructor_MantleEnvApiKey_Succeeds()
    {
        Environment.SetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK", "mantle-key");
        var client = new AnthropicBedrockMantleClient(new() { BaseUrl = "http://localhost" });
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_AwsEnvApiKeyFallback_Succeeds()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_API_KEY", "aws-key");
        var client = new AnthropicBedrockMantleClient(new() { BaseUrl = "http://localhost" });
        Assert.NotNull(client);
    }

    [Fact]
    public async Task MantleEnvApiKey_TakesPrecedenceOverAwsEnvApiKey()
    {
        Environment.SetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK", "mantle-key");
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_API_KEY", "aws-key");
        var client = new AnthropicBedrockMantleClient(new() { BaseUrl = "http://localhost" });
        var req = await SendOneRequest(client);

        Assert.Equal("Bearer mantle-key", req.Headers.GetValues("Authorization").Single());
    }

    #endregion

    #region Endpoint Restrictions

    [Fact]
    public void Messages_IsAccessible()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.NotNull(client.Messages);
    }

    [Fact]
    public void BetaMessages_IsAccessible()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.NotNull(client.Beta.Messages);
    }

    [Fact]
    public void Models_ThrowsNotSupportedException()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.Throws<NotSupportedException>(() => client.Models);
    }

    [Fact]
    public void BetaModels_ThrowsNotSupportedException()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.Throws<NotSupportedException>(() => client.Beta.Models);
    }

    [Fact]
    public void BetaFiles_ThrowsNotSupportedException()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.Throws<NotSupportedException>(() => client.Beta.Files);
    }

    [Fact]
    public void BetaSkills_ThrowsNotSupportedException()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.Throws<NotSupportedException>(() => client.Beta.Skills);
    }

    #endregion

    #region WithOptions / WithRawResponse

    [Fact]
    public void WithOptions_ReturnsValidClient()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        var modified = client.WithOptions(opts => opts);
        Assert.NotNull(modified);
    }

    [Fact]
    public void WithRawResponse_ReturnsValidClient()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        var raw = client.WithRawResponse;
        Assert.NotNull(raw);
    }

    #endregion
}
