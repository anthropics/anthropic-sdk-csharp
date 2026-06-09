using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Moq;
using Moq.Protected;
using Messages = Anthropic.Models.Messages;

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
    public async Task WithOptions_SequentialRequests_DoesNotReattachHandlers()
    {
        const string messageJson = """
            {"id":"msg_x","type":"message","role":"assistant","model":"claude-sonnet-4-5","content":[{"type":"text","text":"hi"}],"stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":1,"output_tokens":1}}
            """;
        var calls = 0;

        AnthropicClient client = new()
        {
            ApiKey = "my-anthropic-api-key",
            Handlers = new List<DelegatingHandler>
            {
                Handler.Create(
                    (request, next, cancellationToken) =>
                    {
                        calls++;
                        return Task.FromResult(
                            new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new StringContent(
                                    messageJson,
                                    Encoding.UTF8,
                                    "application/json"
                                ),
                            }
                        );
                    }
                ),
            },
        };

        MessageCreateParams parameters = new()
        {
            MaxTokens = 64,
            Messages = [new() { Content = "hello", Role = Role.User }],
            Model = Messages::Model.ClaudeSonnet4_5,
        };

        // Beta Create derives a per-request client via WithOptions (max_tokens-based
        // timeout); the derived options must not rebuild the handler chain over the
        // already-attached handlers on subsequent requests.
        await client.Beta.Messages.Create(parameters, TestContext.Current.CancellationToken);
        await client.Beta.Messages.Create(parameters, TestContext.Current.CancellationToken);

        Assert.Equal(2, calls);
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
