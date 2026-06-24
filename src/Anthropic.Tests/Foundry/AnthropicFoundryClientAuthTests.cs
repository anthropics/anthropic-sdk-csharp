using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Foundry;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Foundry;

/// <summary>
/// Verifies that the first-party <c>ANTHROPIC_API_KEY</c> / <c>ANTHROPIC_AUTH_TOKEN</c>
/// env fallbacks never reach Azure through the Foundry client: auth comes solely from
/// the Foundry credentials provider, like the Bedrock/Mantle/AWS clients.
/// </summary>
[Collection("EnvVarMutating")]
public class AnthropicFoundryClientAuthTests : IDisposable
{
    private readonly string? _origApiKey;
    private readonly string? _origAuthToken;

    public AnthropicFoundryClientAuthTests()
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

    private record class BlankParams : ParamsBase
    {
        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions options
        )
        {
            AddDefaultHeaders(request, options);
        }
    }

    private static async Task<HttpRequestMessage> SendOneRequest(AnthropicFoundryClient client)
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

        var rawClient = client
            .WithOptions(opts =>
            {
                opts.HttpClient = new HttpClient(handlerMock.Object);
                return opts;
            })
            .WithRawResponse;

        await rawClient.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(wireRequest);
        return wireRequest!;
    }

    [Fact]
    public async Task ApiKeyCredentials_EnvApiKeyNotSentAlongside()
    {
        var client = new AnthropicFoundryClient(
            new AnthropicFoundryApiKeyCredentials("foundry-key", "test-resource")
        );
        var req = await SendOneRequest(client);

        // Exactly one x-api-key value on the wire — the Foundry credential's, never the
        // env-resolved first-party key.
        var apiKeyValues = req.Headers.GetValues("x-api-key").ToArray();
        Assert.Equal(["foundry-key"], apiKeyValues);
        Assert.False(req.Headers.Contains("Authorization"));
    }

    [Fact]
    public async Task IdentityTokenCredentials_EnvCredentialsNotSent()
    {
        var client = new AnthropicFoundryClient(new FakeBearerCredentials());
        var req = await SendOneRequest(client);

        Assert.False(req.Headers.Contains("X-Api-Key"));
        var authValues = req.Headers.GetValues("Authorization").ToArray();
        Assert.Equal(["Bearer foundry-token"], authValues);
    }

    private sealed class FakeBearerCredentials : IAnthropicFoundryCredentials
    {
        public string ResourceName => "test-resource";

        public void Apply(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation("Authorization", "Bearer foundry-token");
        }
    }
}
