using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Aws;
using Anthropic.Core;
using Anthropic.Exceptions;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Aws;

public class AnthropicAwsClientTests : IDisposable
{
    private readonly string? _origAwsApiKey;
    private readonly string? _origAwsWorkspaceId;
    private readonly string? _origAwsRegion;
    private readonly string? _origAwsDefaultRegion;
    private readonly string? _origAnthropicApiKey;
    private readonly string? _origAwsBaseUrl;

    public AnthropicAwsClientTests()
    {
        _origAwsApiKey = Environment.GetEnvironmentVariable("ANTHROPIC_AWS_API_KEY");
        _origAwsWorkspaceId = Environment.GetEnvironmentVariable("ANTHROPIC_AWS_WORKSPACE_ID");
        _origAwsRegion = Environment.GetEnvironmentVariable("AWS_REGION");
        _origAwsDefaultRegion = Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION");
        _origAnthropicApiKey = Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY");
        _origAwsBaseUrl = Environment.GetEnvironmentVariable("ANTHROPIC_AWS_BASE_URL");

        // Clear env so tests don't pick up ambient state
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_API_KEY", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_WORKSPACE_ID", null);
        Environment.SetEnvironmentVariable("AWS_REGION", null);
        Environment.SetEnvironmentVariable("AWS_DEFAULT_REGION", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_BASE_URL", null);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_API_KEY", _origAwsApiKey);
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_WORKSPACE_ID", _origAwsWorkspaceId);
        Environment.SetEnvironmentVariable("AWS_REGION", _origAwsRegion);
        Environment.SetEnvironmentVariable("AWS_DEFAULT_REGION", _origAwsDefaultRegion);
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", _origAnthropicApiKey);
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_BASE_URL", _origAwsBaseUrl);
    }

    /// <summary>
    /// A minimal <see cref="ParamsBase"/> that targets the gateway URL so we can
    /// exercise <c>BeforeSend</c> via <c>WithRawResponse.Execute</c>.
    /// </summary>
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

    /// <summary>
    /// Creates a mock <see cref="HttpMessageHandler"/> that captures every request and
    /// returns a canned 200 OK.
    /// </summary>
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
                    // Clone the headers we care about — the request object is disposed after SendAsync.
                    var clone = new HttpRequestMessage(req.Method, req.RequestUri);
                    foreach (var h in req.Headers)
                    {
                        clone.Headers.TryAddWithoutValidation(h.Key, h.Value);
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

    static async Task<HttpRequestMessage> SendOneRequest(AnthropicAwsClient client)
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

    #region Validation

    [Fact]
    public void Constructor_WithoutWorkspaceId_Throws()
    {
        var ex = Assert.Throws<AnthropicException>(() =>
            new AnthropicAwsClient(new() { ApiKey = "test-key", BaseUrl = "http://localhost" })
        );
        Assert.Contains("workspace ID", ex.Message);
    }

    [Fact]
    public void Constructor_WithoutBaseUrlOrRegion_Throws()
    {
        var ex = Assert.Throws<AnthropicException>(() =>
            new AnthropicAwsClient(new() { ApiKey = "test-key", WorkspaceId = "default" })
        );
        Assert.Contains("base URL", ex.Message);
    }

    [Fact]
    public void Constructor_WithWorkspaceIdArg_Succeeds()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                ApiKey = "test-key",
                WorkspaceId = "ws-123",
                BaseUrl = "http://localhost",
            }
        );
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_WithWorkspaceIdEnvVar_Succeeds()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_WORKSPACE_ID", "ws-env");
        var client = new AnthropicAwsClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.NotNull(client);
    }

    #endregion

    #region Region Resolution

    [Fact]
    public void Constructor_WithAwsRegionArg_DerivesBaseUrl()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                ApiKey = "test-key",
                WorkspaceId = "default",
                AwsRegion = "us-west-2",
            }
        );
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_WithAwsRegionEnvVar_DerivesBaseUrl()
    {
        Environment.SetEnvironmentVariable("AWS_REGION", "eu-west-1");
        var client = new AnthropicAwsClient(new() { ApiKey = "test-key", WorkspaceId = "default" });
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_WithAwsDefaultRegionEnvVar_DerivesBaseUrl()
    {
        Environment.SetEnvironmentVariable("AWS_DEFAULT_REGION", "ap-southeast-1");
        var client = new AnthropicAwsClient(new() { ApiKey = "test-key", WorkspaceId = "default" });
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_AwsRegionEnvVarTakesPrecedenceOverDefault()
    {
        Environment.SetEnvironmentVariable("AWS_REGION", "us-east-1");
        Environment.SetEnvironmentVariable("AWS_DEFAULT_REGION", "us-west-2");
        var client = new AnthropicAwsClient(new() { ApiKey = "test-key", WorkspaceId = "default" });
        Assert.NotNull(client);
    }

    #endregion

    #region Request Headers — API Key Mode

    [Fact]
    public async Task ApiKeyMode_SendsApiKeyHeader()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                ApiKey = "sk-test-key",
                WorkspaceId = "default",
                BaseUrl = "http://localhost",
            }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.True(req.Headers.Contains("X-Api-Key"));
        Assert.Equal("sk-test-key", req.Headers.GetValues("X-Api-Key").Single());
    }

    [Fact]
    public async Task ApiKeyMode_SendsWorkspaceIdHeader()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                ApiKey = "sk-test-key",
                WorkspaceId = "ws-abc",
                BaseUrl = "http://localhost",
            }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.True(req.Headers.Contains("anthropic-workspace-id"));
        Assert.Equal("ws-abc", req.Headers.GetValues("anthropic-workspace-id").Single());
    }

    [Fact]
    public async Task ApiKeyMode_DoesNotSendSigV4Headers()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                ApiKey = "sk-test-key",
                WorkspaceId = "default",
                BaseUrl = "http://localhost",
            }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.False(req.Headers.Contains("x-amz-date"));
        Assert.False(req.Headers.Contains("x-amz-content-sha256"));
        Assert.False(req.Headers.Contains("Authorization"));
    }

    #endregion

    #region Request Headers — SigV4 Mode

    [Fact]
    public async Task SigV4Mode_SendsSigV4Headers()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsRegion = "us-east-1",
                WorkspaceId = "default",
                BaseUrl = "http://localhost",
            }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.True(req.Headers.Contains("x-amz-date"));
        Assert.True(req.Headers.Contains("x-amz-content-sha256"));
        Assert.True(req.Headers.Contains("Authorization"));
        Assert.StartsWith(
            "AWS4-HMAC-SHA256 Credential=AKIAIOSFODNN7EXAMPLE/",
            req.Headers.GetValues("Authorization").Single()
        );
    }

    [Fact]
    public async Task SigV4Mode_SendsWorkspaceIdHeader()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsRegion = "us-east-1",
                WorkspaceId = "ws-sigv4",
                BaseUrl = "http://localhost",
            }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.True(req.Headers.Contains("anthropic-workspace-id"));
        Assert.Equal("ws-sigv4", req.Headers.GetValues("anthropic-workspace-id").Single());
    }

    [Fact]
    public async Task SigV4Mode_DoesNotSendApiKeyHeader()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsRegion = "us-east-1",
                WorkspaceId = "default",
                BaseUrl = "http://localhost",
            }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.False(req.Headers.Contains("X-Api-Key"));
    }

    [Fact]
    public async Task SigV4Mode_WithSessionToken_SendsSecurityTokenHeader()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsSessionToken = "FwoGZXIvYXdzEA_SESSION_TOKEN",
                AwsRegion = "us-east-1",
                WorkspaceId = "default",
                BaseUrl = "http://localhost",
            }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.True(req.Headers.Contains("x-amz-security-token"));
        Assert.Equal(
            "FwoGZXIvYXdzEA_SESSION_TOKEN",
            req.Headers.GetValues("x-amz-security-token").Single()
        );
    }

    #endregion

    #region Request Headers — skipAuth Mode

    [Fact]
    public void SkipAuth_DoesNotRequireWorkspaceId()
    {
        var client = new AnthropicAwsClient(
            new() { SkipAuth = true, BaseUrl = "http://localhost" }
        );
        Assert.NotNull(client);
    }

    [Fact]
    public void SkipAuth_WithWorkspaceId_Succeeds()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                SkipAuth = true,
                WorkspaceId = "ws-123",
                BaseUrl = "http://localhost",
            }
        );
        Assert.NotNull(client);
    }

    [Fact]
    public async Task SkipAuth_DoesNotSendApiKeyHeader()
    {
        var client = new AnthropicAwsClient(
            new() { SkipAuth = true, BaseUrl = "http://localhost" }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.False(req.Headers.Contains("X-Api-Key"));
    }

    [Fact]
    public async Task SkipAuth_DoesNotSendSigV4Headers()
    {
        var client = new AnthropicAwsClient(
            new() { SkipAuth = true, BaseUrl = "http://localhost" }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.False(req.Headers.Contains("x-amz-date"));
        Assert.False(req.Headers.Contains("x-amz-content-sha256"));
        Assert.False(req.Headers.Contains("Authorization"));
        Assert.False(req.Headers.Contains("x-amz-security-token"));
    }

    [Fact]
    public async Task SkipAuth_DoesNotSendWorkspaceIdHeader_WhenNotProvided()
    {
        var client = new AnthropicAwsClient(
            new() { SkipAuth = true, BaseUrl = "http://localhost" }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.False(req.Headers.Contains("anthropic-workspace-id"));
    }

    [Fact]
    public async Task SkipAuth_SendsWorkspaceIdHeader_WhenProvided()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                SkipAuth = true,
                WorkspaceId = "ws-proxy",
                BaseUrl = "http://localhost",
            }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.True(req.Headers.Contains("anthropic-workspace-id"));
        Assert.Equal("ws-proxy", req.Headers.GetValues("anthropic-workspace-id").Single());
    }

    [Fact]
    public void SkipAuth_PreservesWithOptions()
    {
        var client = new AnthropicAwsClient(
            new() { SkipAuth = true, BaseUrl = "http://localhost" }
        );
        var modified = client.WithOptions(opts => opts);
        Assert.NotNull(modified);
    }

    [Fact]
    public void SkipAuth_PreservesWithRawResponse()
    {
        var client = new AnthropicAwsClient(
            new() { SkipAuth = true, BaseUrl = "http://localhost" }
        );
        var raw = client.WithRawResponse;
        Assert.NotNull(raw);
    }

    #endregion

    #region Auth Precedence

    [Fact]
    public void Constructor_ExplicitSigV4Creds_Succeeds()
    {
        var client = new AnthropicAwsClient(
            new()
            {
                AwsAccessKey = "AKIA_TEST",
                AwsSecretAccessKey = "secret",
                AwsRegion = "us-east-1",
                WorkspaceId = "default",
            }
        );
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_EnvApiKey_Succeeds()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_API_KEY", "env-key");
        var client = new AnthropicAwsClient(
            new() { WorkspaceId = "default", BaseUrl = "http://localhost" }
        );
        Assert.NotNull(client);
    }

    [Fact]
    public async Task ApiKeyArg_TakesPrecedenceOverEnvApiKey()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_API_KEY", "env-key");
        var client = new AnthropicAwsClient(
            new()
            {
                ApiKey = "arg-key",
                WorkspaceId = "default",
                BaseUrl = "http://localhost",
            }
        );
        var req = await AnthropicAwsClientTests.SendOneRequest(client);

        Assert.Equal("arg-key", req.Headers.GetValues("X-Api-Key").Single());
    }

    #endregion
}
