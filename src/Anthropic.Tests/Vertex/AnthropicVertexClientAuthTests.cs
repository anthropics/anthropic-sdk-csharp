using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Vertex;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Vertex;

/// <summary>
/// Verifies that the first-party <c>ANTHROPIC_API_KEY</c> / <c>ANTHROPIC_AUTH_TOKEN</c>
/// env fallbacks never reach Google through the Vertex client: auth comes solely from
/// the Vertex credentials provider, like the Foundry/Bedrock/Mantle/AWS clients.
/// </summary>
[Collection("EnvVarMutating")]
public class AnthropicVertexClientAuthTests : IDisposable
{
    private readonly string? _origApiKey;
    private readonly string? _origAuthToken;

    public AnthropicVertexClientAuthTests()
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

    private sealed class FakeVertexCredentials : IAnthropicVertexCredentials
    {
        public string Region => "us-east5";
        public string Project => "test-project";

        public ValueTask ApplyAsync(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation("Authorization", "Bearer vertex-token");
            return default;
        }
    }

    private record class JsonBodyParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions options
        )
        {
            // The default headers include any first-party credential the client still
            // carries — exactly what this test asserts never reaches the wire.
            AddDefaultHeaders(request, options);
        }

        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override HttpContent? BodyContent() =>
            new StringContent("{\"model\":\"claude-sonnet-4-5\",\"max_tokens\":1024}");
    }

    [Fact]
    public async Task EnvCredentials_NotSentToVertex()
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

        var client = new AnthropicVertexClient(new FakeVertexCredentials())
        {
            HttpClient = new HttpClient(handlerMock.Object),
            Handlers = new List<DelegatingHandler>(),
        };

        await client.WithRawResponse.Execute(
            new HttpRequest<JsonBodyParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(wireRequest);
        Assert.False(wireRequest!.Headers.Contains("X-Api-Key"));
        var authValues = wireRequest.Headers.GetValues("Authorization");
        Assert.Equal(["Bearer vertex-token"], authValues);
    }
}
