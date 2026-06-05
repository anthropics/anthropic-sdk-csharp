using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Core;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests;

public class HandlersTest : TestBase
{
    record class BlankParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // do nothing
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    sealed class RecordingHandler : DelegatingHandler
    {
        private readonly List<string> _calls;
        private readonly string _name;

        public RecordingHandler(List<string> calls, string name)
        {
            _calls = calls;
            _name = name;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            _calls.Add(_name);
            return base.SendAsync(request, cancellationToken);
        }
    }

    [Fact]
    public async Task HandlersAttach_LastIsInnermost()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);
        var calls = new List<string>();
        var handlers = new List<DelegatingHandler>
        {
            new RecordingHandler(calls, "outer"),
            new RecordingHandler(calls, "inner"),
        };

        AnthropicClient client = new() { HttpClient = httpClient, Handlers = handlers };

        // Mutating the original list after construction has no effect on the client.
        handlers.Add(new RecordingHandler(calls, "late"));

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        Assert.Equal(new List<string> { "outer", "inner" }, calls);

        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task CreatedHandler_Works()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);
        var calls = new List<string>();

        AnthropicClient client = new()
        {
            HttpClient = httpClient,
            Handlers = new List<DelegatingHandler>
            {
                Handler.Create(
                    async (request, next, cancellationToken) =>
                    {
                        calls.Add("before");
                        var response = await next(request, cancellationToken);
                        calls.Add("after");
                        return response;
                    }
                ),
            },
        };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        Assert.Equal(new List<string> { "before", "after" }, calls);
    }

    [Fact]
    public void AttachedHandler_Throws()
    {
        var handler = new RecordingHandler(new List<string>(), "outer")
        {
            InnerHandler = new HttpClientHandler(),
        };

        Assert.Throws<ArgumentException>(() =>
            new AnthropicClient() { Handlers = new List<DelegatingHandler> { handler } }
        );
    }
}
