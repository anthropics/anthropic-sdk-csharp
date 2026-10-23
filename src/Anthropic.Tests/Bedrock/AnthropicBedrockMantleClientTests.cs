using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Bedrock;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;
using Moq;
using Moq.Protected;
using BetaMessages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Bedrock;

[Collection("EnvVarMutating")]
public class AnthropicBedrockMantleClientTests : IDisposable
{
    private readonly string? _origMantleApiKey;
    private readonly string? _origAwsApiKey;
    private readonly string? _origAwsRegion;
    private readonly string? _origAwsDefaultRegion;
    private readonly string? _origAnthropicApiKey;
    private readonly string? _origAnthropicAuthToken;
    private readonly string? _origMantleBaseUrl;

    public AnthropicBedrockMantleClientTests()
    {
        _origMantleApiKey = Environment.GetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK");
        _origAwsApiKey = Environment.GetEnvironmentVariable("ANTHROPIC_AWS_API_KEY");
        _origAwsRegion = Environment.GetEnvironmentVariable("AWS_REGION");
        _origAwsDefaultRegion = Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION");
        _origAnthropicApiKey = Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY");
        _origAnthropicAuthToken = Environment.GetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN");
        _origMantleBaseUrl = Environment.GetEnvironmentVariable(
            "ANTHROPIC_BEDROCK_MANTLE_BASE_URL"
        );

        // Clear env so tests don't pick up ambient state
        Environment.SetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_AWS_API_KEY", null);
        Environment.SetEnvironmentVariable("AWS_REGION", null);
        Environment.SetEnvironmentVariable("AWS_DEFAULT_REGION", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN", null);
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
        Environment.SetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN", _origAnthropicAuthToken);
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
    public async Task ApiKeyMode_EnvAuthTokenNotDoubledWithBearer()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN", "first-party-auth-token");
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "sk-test-key", BaseUrl = "http://localhost" }
        );
        var req = await SendOneRequest(client);

        // Exactly one Authorization value — the gateway bearer, never the ambient
        // first-party token.
        Assert.Equal("Bearer sk-test-key", req.Headers.GetValues("Authorization").Single());
        Assert.False(req.Headers.Contains("X-Api-Key"));
    }

    [Fact]
    public async Task SigV4Mode_EnvAuthTokenNotSentAsBearer()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN", "first-party-auth-token");
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

        // Exactly one Authorization value — the SigV4 signature, never the ambient
        // first-party bearer token.
        Assert.False(req.Headers.Contains("X-Api-Key"));
        Assert.StartsWith(
            "AWS4-HMAC-SHA256 Credential=AKIAIOSFODNN7EXAMPLE/",
            req.Headers.GetValues("Authorization").Single()
        );
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task SigV4Mode_EnvCredentialsNotSentAsBearer(bool freshOptions)
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", "first-party-api-key");
        Environment.SetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN", "first-party-auth-token");
        var client = new AnthropicBedrockMantleClient(
            new()
            {
                AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                AwsRegion = "us-east-1",
                BaseUrl = "http://localhost",
            }
        );
        if (freshOptions)
        {
            client = Assert.IsType<AnthropicBedrockMantleClient>(
                client.WithOptions(opts => new ClientOptions { BaseUrl = opts.BaseUrl })
            );
        }
        var req = await SendOneRequest(client);

        // Exactly one Authorization value — the SigV4 signature, never an ambient
        // first-party credential.
        Assert.StartsWith(
            "AWS4-HMAC-SHA256 Credential=AKIAIOSFODNN7EXAMPLE/",
            req.Headers.GetValues("Authorization").Single()
        );
    }

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

    #region SigV4 Signature Verification

    const string SigV4AccessKey = "AKIAIOSFODNN7EXAMPLE";
    const string SigV4SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
    const string MessageJson = """
        {"id":"msg_x","type":"message","role":"assistant","model":"anthropic.claude-3","content":[{"type":"text","text":"hi"}],"stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":1,"output_tokens":1}}
        """;

    static AnthropicBedrockMantleClient CreateSigV4ClientAgainst(HttpMessageHandler gateway) =>
        new(
            new()
            {
                AwsAccessKey = SigV4AccessKey,
                AwsSecretAccessKey = SigV4SecretKey,
                AwsRegion = "us-east-1",
                ClientOptions = new() { HttpClient = new HttpClient(gateway) },
            }
        );

    [Fact]
    public async Task SigV4Mode_MessagesCreate_SignatureVerifies()
    {
        var gateway = new SigV4VerifyingHandler(SigV4SecretKey, MessageJson);
        var client = CreateSigV4ClientAgainst(gateway);

        var message = await client.Messages.Create(
            new MessageCreateParams
            {
                MaxTokens = 16,
                Messages = [new UserMessageParam { Content = "hello" }],
                Model = "anthropic.claude-3",
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal("msg_x", message.ID);
        Assert.Equal("", gateway.VerifiedRequestUris.Single().Query);
    }

    [Fact]
    public async Task SigV4Mode_RepeatedQueryKey_SignatureVerifies()
    {
        var gateway = new SigV4VerifyingHandler(SigV4SecretKey, MessageJson);
        var client = CreateSigV4ClientAgainst(gateway);

        var message = await client.Messages.Create(
            new MessageCreateParams(
                rawHeaderData: new Dictionary<string, JsonElement>(),
                rawQueryData: new Dictionary<string, JsonElement>
                {
                    ["tag"] = JsonSerializer.SerializeToElement(new List<string> { "b", "a" }),
                },
                rawBodyData: new Dictionary<string, JsonElement>()
            )
            {
                MaxTokens = 16,
                Messages = [new UserMessageParam { Content = "hello" }],
                Model = "anthropic.claude-3",
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal("msg_x", message.ID);
        Assert.Equal("?tag%5b%5d=b&tag%5b%5d=a", gateway.VerifiedRequestUris.Single().Query);
    }

    #endregion

    #region User Profile ID

    const string UserProfileIDHeader = "anthropic-user-profile-id";

    sealed class ApiKeyGateway : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        ) =>
            Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(MessageJson, Encoding.UTF8, "application/json"),
                }
            );
    }

    /// <summary>
    /// In SigV4 mode the gateway answers 403 unless the signature covers the request as sent.
    /// </summary>
    static (AnthropicBedrockMantleClient Client, WireRecordingHandler Wire) CreateRecordedClient(
        bool sigV4 = true
    )
    {
        var wire = new WireRecordingHandler(
            sigV4 ? new SigV4VerifyingHandler(SigV4SecretKey, MessageJson) : new ApiKeyGateway()
        );
        var client = sigV4
            ? CreateSigV4ClientAgainst(wire)
            : new AnthropicBedrockMantleClient(
                new()
                {
                    ApiKey = "sk-test-key",
                    BaseUrl = "http://localhost",
                    ClientOptions = new() { HttpClient = new HttpClient(wire) },
                }
            );
        return (client, wire);
    }

    static Dictionary<string, JsonElement> RawBody(string? userProfileID) =>
        userProfileID == null
            ? []
            : new() { ["user_profile_id"] = JsonSerializer.SerializeToElement(userProfileID) };

    static MessageCreateParams CreateParams(
        string? userProfileID,
        string? bodyUserProfileID = null
    ) =>
        new(
            rawHeaderData: new Dictionary<string, JsonElement>(),
            rawQueryData: new Dictionary<string, JsonElement>(),
            rawBodyData: RawBody(bodyUserProfileID)
        )
        {
            MaxTokens = 16,
            Messages = [new UserMessageParam { Content = "hello" }],
            Model = "anthropic.claude-3",
            UserProfileID = userProfileID,
        };

    static BetaMessages::MessageCreateParams BetaCreateParams(
        string? userProfileID,
        string? bodyUserProfileID = null
    ) =>
        new(
            rawHeaderData: new Dictionary<string, JsonElement>(),
            rawQueryData: new Dictionary<string, JsonElement>(),
            rawBodyData: RawBody(bodyUserProfileID)
        )
        {
            MaxTokens = 16,
            Messages = [new BetaMessages::BetaUserMessageParam { Content = "hello" }],
            Model = "anthropic.claude-3",
            UserProfileID = userProfileID,
        };

    static async Task<WireRequest> CreateMessage(
        bool beta,
        string? userProfileID,
        string? bodyUserProfileID = null,
        bool sigV4 = true
    )
    {
        var (client, wire) = CreateRecordedClient(sigV4);
        if (beta)
        {
            await client.Beta.Messages.Create(
                BetaCreateParams(userProfileID, bodyUserProfileID),
                TestContext.Current.CancellationToken
            );
        }
        else
        {
            await client.Messages.Create(
                CreateParams(userProfileID, bodyUserProfileID),
                TestContext.Current.CancellationToken
            );
        }

        var request = wire.Requests.Single();
        Assert.EndsWith("/v1/messages", request.Uri.AbsolutePath);
        Assert.Equal("", request.Uri.Query);
        return request;
    }

    [Theory]
    [InlineData(false, true)]
    [InlineData(true, true)]
    [InlineData(false, false)]
    [InlineData(true, false)]
    public async Task UserProfileID_MessagesCreate_SentInBodyInsteadOfHeader(bool beta, bool sigV4)
    {
        var withoutID = await CreateMessage(beta, userProfileID: null, sigV4: sigV4);
        var request = await CreateMessage(beta, "uprof_test", sigV4: sigV4);

        Assert.False(request.Headers.ContainsKey(UserProfileIDHeader));
        var expectedBody = withoutID.JsonBody;
        expectedBody["user_profile_id"] = "uprof_test";
        Assert.Equal(expectedBody.ToJsonString(), request.Body);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task UserProfileID_MessagesCreateStreaming_SentInBodyInsteadOfHeader(bool beta)
    {
        var (client, wire) = CreateRecordedClient();
        if (beta)
        {
            using var response = await client.WithRawResponse.Beta.Messages.CreateStreaming(
                BetaCreateParams("uprof_test"),
                TestContext.Current.CancellationToken
            );
        }
        else
        {
            using var response = await client.WithRawResponse.Messages.CreateStreaming(
                CreateParams("uprof_test"),
                TestContext.Current.CancellationToken
            );
        }

        var request = wire.Requests.Single();
        Assert.False(request.Headers.ContainsKey(UserProfileIDHeader));
        Assert.True(request.JsonBody["stream"]!.GetValue<bool>());
        Assert.Equal("uprof_test", request.JsonBody["user_profile_id"]!.GetValue<string>());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task UserProfileID_NotSet_AbsentFromBody(bool beta)
    {
        var request = await CreateMessage(beta, userProfileID: null);

        Assert.False(request.Headers.ContainsKey(UserProfileIDHeader));
        Assert.False(request.JsonBody.ContainsKey("user_profile_id"));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task UserProfileID_AlsoInBody_BodyValueWins(bool beta)
    {
        var request = await CreateMessage(beta, "uprof_header", bodyUserProfileID: "uprof_body");

        Assert.False(request.Headers.ContainsKey(UserProfileIDHeader));
        Assert.Equal("uprof_body", request.JsonBody["user_profile_id"]!.GetValue<string>());
    }

    [Fact]
    public async Task UserProfileID_ClientExtraHeader_SentInBodyInsteadOfHeader()
    {
        var (client, wire) = CreateRecordedClient();
        await client
            .WithOptions(options =>
            {
                options.ExtraHeaders = new Dictionary<string, string>
                {
                    [UserProfileIDHeader] = "uprof_test",
                };
                return options;
            })
            .Messages.Create(
                CreateParams(userProfileID: null),
                TestContext.Current.CancellationToken
            );

        var request = wire.Requests.Single();
        Assert.False(request.Headers.ContainsKey(UserProfileIDHeader));
        Assert.Equal("uprof_test", request.JsonBody["user_profile_id"]!.GetValue<string>());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task UserProfileID_CountTokens_SentInBodyInsteadOfHeader(bool beta)
    {
        var (client, wire) = CreateRecordedClient();
        if (beta)
        {
            await client.WithRawResponse.Beta.Messages.CountTokens(
                new()
                {
                    Messages = [new BetaMessages::BetaUserMessageParam { Content = "hello" }],
                    Model = "anthropic.claude-3",
                    UserProfileID = "uprof_test",
                },
                TestContext.Current.CancellationToken
            );
        }
        else
        {
            await client.WithRawResponse.Messages.CountTokens(
                new()
                {
                    Messages = [new UserMessageParam { Content = "hello" }],
                    Model = "anthropic.claude-3",
                    UserProfileID = "uprof_test",
                },
                TestContext.Current.CancellationToken
            );
        }

        var request = wire.Requests.Single();
        Assert.EndsWith("/v1/messages/count_tokens", request.Uri.AbsolutePath);
        Assert.Equal("", request.Uri.Query);
        Assert.False(request.Headers.ContainsKey(UserProfileIDHeader));
        Assert.Equal("uprof_test", request.JsonBody["user_profile_id"]!.GetValue<string>());
    }

    [Fact]
    public async Task UserProfileID_Batches_KeepsHeader()
    {
        var (client, wire) = CreateRecordedClient();
        await client.WithRawResponse.Messages.Batches.Create(
            new()
            {
                Requests =
                [
                    new()
                    {
                        CustomID = "my-custom-id-1",
                        Params = new()
                        {
                            MaxTokens = 16,
                            Messages = [new UserMessageParam { Content = "hello" }],
                            Model = "anthropic.claude-3",
                        },
                    },
                ],
                UserProfileID = "uprof_test",
            },
            TestContext.Current.CancellationToken
        );

        var request = wire.Requests.Single();
        Assert.EndsWith("/v1/messages/batches", request.Uri.AbsolutePath);
        Assert.Equal("uprof_test", request.Headers[UserProfileIDHeader]);
        Assert.False(request.JsonBody.ContainsKey("user_profile_id"));
    }

    record class UneditableBodyParams : ParamsBase
    {
        public string Body { get; set; } = "";

        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions options
        )
        {
            AddDefaultHeaders(request, options);
            request.Headers.Add(UserProfileIDHeader, "uprof_test");
        }

        public override Uri Url(ClientOptions options)
        {
            return new Uri($"{options.BaseUrl}/v1/messages");
        }

        internal override HttpContent? BodyContent()
        {
            return new StringContent(Body, Encoding.UTF8, "application/json");
        }
    }

    [Theory]
    [InlineData("[1]")]
    [InlineData("not json")]
    public async Task UserProfileID_BodyIsNotAJsonObject_RequestUnchanged(string body)
    {
        var (client, wire) = CreateRecordedClient();
        await client.WithRawResponse.Execute(
            new HttpRequest<UneditableBodyParams>
            {
                Method = HttpMethod.Post,
                Params = new() { Body = body },
            },
            TestContext.Current.CancellationToken
        );

        var request = wire.Requests.Single();
        Assert.Equal("uprof_test", request.Headers[UserProfileIDHeader]);
        Assert.Equal(body, request.Body);
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
    public void Files_ThrowsNotSupportedException()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.Throws<NotSupportedException>(() => client.Files);
    }

    [Fact]
    public void Skills_ThrowsNotSupportedException()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.Throws<NotSupportedException>(() => client.Skills);
    }

    [Fact]
    public void UserProfiles_ThrowsNotSupportedException()
    {
        var client = new AnthropicBedrockMantleClient(
            new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
        );
        Assert.Throws<NotSupportedException>(() => client.UserProfiles);
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
