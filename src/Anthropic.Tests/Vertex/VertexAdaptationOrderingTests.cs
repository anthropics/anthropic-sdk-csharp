using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Vertex;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Vertex;

/// <summary>
/// Verifies that user handlers wrap the Vertex adaptation: handlers observe
/// Anthropic-shaped requests, while the wire carries the rewritten, authorized
/// Vertex request.
/// </summary>
public class VertexAdaptationOrderingTests
{
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
        public string? VersionHeader { get; set; }

        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions _options
        )
        {
            // Skip the other default headers so ambient ANTHROPIC_* env vars can't interfere.
            if (VersionHeader is not null)
            {
                request.Headers.TryAddWithoutValidation("anthropic-version", VersionHeader);
            }
        }

        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override HttpContent? BodyContent() =>
            new StringContent("{\"model\":\"claude-sonnet-4-5\",\"max_tokens\":1024}");
    }

    [Theory]
    [InlineData("2000-01-01", null, "2000-01-01")]
    [InlineData("2000-01-01", "2000-01-02", "2000-01-02")]
    [InlineData(null, null, null)]
    public async Task UserHandlers_ObserveAnthropicShape_WireObservesVertexShape(
        string? versionHeader,
        string? callerVersionHeader,
        string? expectedBodyVersion
    )
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
            .ReturnsAsync(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}"),
                }
            );

        Uri? observedUri = null;
        string? observedBody = null;
        var observedAuthorization = true;

        var client = new AnthropicVertexClient(new FakeVertexCredentials())
        {
            HttpClient = new HttpClient(handlerMock.Object),
            ExtraHeaders = callerVersionHeader is null
                ? null
                : new Dictionary<string, string> { ["anthropic-version"] = callerVersionHeader },
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
                        return await next(request, cancellationToken);
                    }
                ),
            },
        };

        var response = await client.WithRawResponse.Execute(
            new HttpRequest<JsonBodyParams>
            {
                Method = HttpMethod.Post,
                Params = new() { VersionHeader = versionHeader },
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // The user handler observed the Anthropic-shaped request, before authorization.
        Assert.NotNull(observedUri);
        Assert.Equal("/v1/messages", observedUri!.AbsolutePath);
        Assert.Contains("\"model\"", observedBody);
        Assert.False(observedAuthorization);

        // The wire carried the rewritten, authorized Vertex request.
        Assert.NotNull(wireRequest);
        Assert.Equal(
            "/v1/projects/test-project/locations/us-east5/publishers/anthropic/models/claude-sonnet-4-5:rawPredict",
            wireRequest!.RequestUri!.AbsolutePath
        );
        Assert.DoesNotContain("\"model\"", wireBody);
        var wireVersion = JsonNode.Parse(wireBody!)!["anthropic_version"];
        Assert.Equal(expectedBodyVersion, (string?)wireVersion);
        Assert.False(wireRequest.Headers.Contains("anthropic-version"));
        Assert.True(wireRequest.Headers.Contains("Authorization"));
    }
}
