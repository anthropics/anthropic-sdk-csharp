using System;
using System.Collections.Generic;
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
/// Verifies that user handlers wrap the Foundry adaptation: the backend credentials
/// are applied inside, after all user handlers have run.
/// </summary>
public class FoundryAdaptationOrderingTests
{
    private sealed class FakeFoundryCredentials : IAnthropicFoundryCredentials
    {
        public string ResourceName => "test-resource";

        public void Apply(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation("api-key", "test-api-key");
        }
    }

    private record class BlankParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // Skip default headers so ambient ANTHROPIC_* env vars can't interfere.
        }

        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");
    }

    [Fact]
    public async Task UserHandlers_RunBeforeCredentialsAreApplied()
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

        var observedApiKey = true;

        var client = new AnthropicFoundryClient(new FakeFoundryCredentials())
        {
            HttpClient = new HttpClient(handlerMock.Object),
            Handlers = new List<DelegatingHandler>
            {
                Handler.Create(
                    (request, next, cancellationToken) =>
                    {
                        observedApiKey = request.Headers.Contains("api-key");
                        return next(request, cancellationToken);
                    }
                ),
            },
        };

        var response = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // The user handler ran before the backend credentials were applied.
        Assert.False(observedApiKey);
        Assert.NotNull(wireRequest);
        Assert.True(wireRequest!.Headers.Contains("api-key"));
    }

    [Fact]
    public async Task WithRawResponseWithOptions_FreshOptions_KeepsBackendAdaptation()
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

        var client = new AnthropicFoundryClient(new FakeFoundryCredentials());

        // A modifier that returns fresh options (rather than mutating its copy) must not
        // strip the backend adaptation from the derived client.
        var rawClient = client.WithRawResponse.WithOptions(options => new ClientOptions
        {
            BaseUrl = options.BaseUrl,
            HttpClient = new HttpClient(handlerMock.Object),
        });

        var response = await rawClient.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(wireRequest);
        Assert.True(wireRequest!.Headers.Contains("api-key"));
    }
}
