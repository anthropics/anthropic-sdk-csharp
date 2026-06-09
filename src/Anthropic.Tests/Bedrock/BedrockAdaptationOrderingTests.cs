using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Bedrock;
using Anthropic.Core;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Bedrock;

/// <summary>
/// Verifies that user handlers wrap the Bedrock adaptation: handlers observe
/// Anthropic-shaped requests and SSE responses, while the wire carries the
/// rewritten, signed Bedrock request and the raw EventStream response.
/// </summary>
public class BedrockAdaptationOrderingTests
{
    private sealed class FakeBedrockCredentials : IAnthropicBedrockCredentials
    {
        public string Region => "us-east-1";

        public Task Apply(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation(
                "Authorization",
                "AWS4-HMAC-SHA256 test-signature"
            );
            return Task.CompletedTask;
        }
    }

    private record class JsonBodyParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // Skip default headers so ambient ANTHROPIC_* env vars can't interfere.
        }

        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override HttpContent? BodyContent() =>
            new StringContent(
                "{\"model\":\"claude-sonnet-4-5\",\"stream\":true,\"max_tokens\":1024}"
            );
    }

    [Fact]
    public async Task UserHandlers_ObserveAnthropicShape_WireObservesBedrockShape()
    {
        HttpRequestMessage? wireRequest = null;
        string? wireBody = null;
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Callback<HttpRequestMessage, CancellationToken>(
                (req, cancellationToken) =>
                {
                    // Clone what we assert on — the request is disposed after SendAsync.
                    wireBody = req.Content!.ReadAsStringAsync(
#if NET
                            cancellationToken
#endif
                        )
                        .GetAwaiter()
                        .GetResult();
                    var clone = new HttpRequestMessage(req.Method, req.RequestUri);
                    foreach (var header in req.Headers)
                    {
                        clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                    wireRequest = clone;
                }
            )
            .ReturnsAsync(() =>
            {
                // A Bedrock streaming response: AWS EventStream framing on the wire.
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ByteArrayContent([]),
                };
                response.Content.Headers.ContentType = new("application/vnd.amazon.eventstream");
                response.Headers.TryAddWithoutValidation(
                    "x-amzn-bedrock-content-type",
                    "application/json"
                );
                return response;
            });

        Uri? observedUri = null;
        string? observedBody = null;
        var observedAuthorization = true;
        string? observedResponseContentType = null;

        var client = new AnthropicBedrockClient(new FakeBedrockCredentials())
        {
            HttpClient = new HttpClient(handlerMock.Object),
            Handlers = new List<DelegatingHandler>
            {
                Handler.Create(
                    async (request, next, cancellationToken) =>
                    {
                        observedUri = request.RequestUri;
                        observedBody = await request.Content!.ReadAsStringAsync(
#if NET
                            cancellationToken
#endif
                        );
                        observedAuthorization = request.Headers.Contains("Authorization");
                        var response = await next(request, cancellationToken);
                        observedResponseContentType = response
                            .Content
                            .Headers
                            .ContentType
                            ?.MediaType;
                        return response;
                    }
                ),
            },
        };

        var response = await client.WithRawResponse.Execute(
            new HttpRequest<JsonBodyParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // The user handler observed the Anthropic-shaped request, before signing.
        Assert.NotNull(observedUri);
        Assert.Equal("/v1/messages", observedUri!.AbsolutePath);
        Assert.Contains("\"model\"", observedBody);
        Assert.Contains("\"stream\"", observedBody);
        Assert.False(observedAuthorization);

        // The wire carried the rewritten, signed Bedrock request.
        Assert.NotNull(wireRequest);
        Assert.Equal(
            "/model/claude-sonnet-4-5/invoke-with-response-stream",
            wireRequest!.RequestUri!.AbsolutePath
        );
        Assert.DoesNotContain("\"model\"", wireBody);
        Assert.DoesNotContain("\"stream\"", wireBody);
        Assert.Contains("\"anthropic_version\"", wireBody);
        Assert.True(wireRequest.Headers.Contains("Authorization"));

        // The user handler observed the response already translated to SSE.
        Assert.Equal("text/event-stream", observedResponseContentType);
    }
}
