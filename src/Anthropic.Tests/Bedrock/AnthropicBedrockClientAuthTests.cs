using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Bedrock;
using Anthropic.Core;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Bedrock;

/// <summary>
/// Verifies that the first-party <c>ANTHROPIC_API_KEY</c> / <c>ANTHROPIC_AUTH_TOKEN</c>
/// env fallbacks never reach AWS through the Bedrock client: auth comes solely from the
/// credentials provider, like the Mantle and AWS clients.
/// </summary>
[Collection("EnvVarMutating")]
public class AnthropicBedrockClientAuthTests : IDisposable
{
    private readonly string? _origApiKey;
    private readonly string? _origAuthToken;

    public AnthropicBedrockClientAuthTests()
    {
        _origApiKey = Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY");
        _origAuthToken = Environment.GetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN");
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", "first-party-api-key");
        Environment.SetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN", "first-party-auth-token");
    }

    public void Dispose()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", _origApiKey);
        Environment.SetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN", _origAuthToken);
        GC.SuppressFinalize(this);
    }

    private sealed class RecordingBedrockCredentials : IAnthropicBedrockCredentials
    {
        public string Region => "us-east-1";

        public bool? ApiKeyPresentAtSigning { get; private set; }

        public string[]? AuthorizationAtSigning { get; private set; }

        public Task Apply(HttpRequestMessage requestMessage)
        {
            ApiKeyPresentAtSigning = requestMessage.Headers.Contains("X-Api-Key");
            AuthorizationAtSigning = requestMessage.Headers.Contains("Authorization")
                ? [.. requestMessage.Headers.GetValues("Authorization")]
                : [];
            requestMessage.Headers.TryAddWithoutValidation(
                "Authorization",
                "AWS4-HMAC-SHA256 test-signature"
            );
            return Task.CompletedTask;
        }
    }

    private record class JsonBodyParams : ParamsBase
    {
        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions options
        )
        {
            AddDefaultHeaders(request, options);
        }

        internal override HttpContent? BodyContent() =>
            new StringContent(
                "{\"model\":\"claude-sonnet-4-5\",\"max_tokens\":1024}",
                Encoding.UTF8,
                "application/json"
            );
    }

    private sealed class SentRequest(
        RecordingBedrockCredentials credentials,
        HttpRequestMessage wire
    )
    {
        public RecordingBedrockCredentials Credentials { get; } = credentials;

        public HttpRequestMessage Wire { get; } = wire;
    }

    private static async Task<SentRequest> SendOneRequest(
        Func<AnthropicBedrockClient, HttpClient, IAnthropicClient> configure
    )
    {
        HttpRequestMessage? wireRequest = null;
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
                    // Clone what we assert on — the request is disposed after SendAsync.
                    var clone = new HttpRequestMessage(req.Method, req.RequestUri);
                    foreach (var header in req.Headers)
                    {
                        clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                    wireRequest = clone;
                }
            )
            .ReturnsAsync(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}"),
                }
            );

        var credentials = new RecordingBedrockCredentials();
        var client = configure(
            new AnthropicBedrockClient(credentials),
            new HttpClient(handlerMock.Object)
        );

        await client.WithRawResponse.Execute(
            new HttpRequest<JsonBodyParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(wireRequest);
        return new SentRequest(credentials, wireRequest!);
    }

    [Fact]
    public async Task FirstPartyEnvCredentials_NeitherSignedNorSent()
    {
        var sent = await SendOneRequest(
            (client, httpClient) =>
                client.WithOptions(opts =>
                {
                    opts.HttpClient = httpClient;
                    return opts;
                })
        );

        Assert.False(sent.Credentials.ApiKeyPresentAtSigning);
        Assert.NotNull(sent.Credentials.AuthorizationAtSigning);
        Assert.Empty(sent.Credentials.AuthorizationAtSigning!);
        Assert.False(sent.Wire.Headers.Contains("X-Api-Key"));
        string[] wireAuthorization = [.. sent.Wire.Headers.GetValues("Authorization")];
        Assert.Equal(["AWS4-HMAC-SHA256 test-signature"], wireAuthorization);
    }

    [Fact]
    public async Task ExplicitApiKey_StillHonored()
    {
        var sent = await SendOneRequest(
            (client, httpClient) =>
                client.WithOptions(opts =>
                {
                    opts.HttpClient = httpClient;
                    opts.ApiKey = "explicit-key";
                    return opts;
                })
        );

        Assert.True(sent.Credentials.ApiKeyPresentAtSigning);
        Assert.True(sent.Wire.Headers.Contains("X-Api-Key"));
    }
}
