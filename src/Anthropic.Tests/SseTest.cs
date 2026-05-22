using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models;

namespace Anthropic.Tests;

public class SseTest : TestBase
{
    static readonly TheoryData<string, string[]> _data = new()
    {
        // event and data
        { "event: completion\n" + "data: {\"foo\":true}\n\n", new[] { "{\"foo\": true}" } },
        // event missing data
        { "event: completion\n" + "\n", [] },
        // multiple events and data
        {
            "event: completion\n"
                + "data: {\"foo\":true}\n\n"
                + "event: message_start\n"
                + "data: {\"bar\": false}\n\n",
            new[] { "{\"foo\": true}", "{\"bar\": false}" }
        },
        // multiple events missing data
        { "event: completion\n" + "\n" + "event: message_start\n" + "\n", [] },
        // json-escaped double newline
        {
            "event: completion\n" + "data: {\ndata: \"foo\":\ndata: true }\n\n\n",
            new[] { "{ \"foo\":\ntrue }" }
        },
        // multiple data lines
        {
            "event: completion\n" + "data: { \ndata: \"foo\":\ndata: true }\n\n\n",
            new[] { "{ \"foo\":\ntrue }" }
        },
        // special newline character
        {
            "event: completion\n"
                + "data: {\"content\": \" culpa\"}\n\n"
                + "event: message_start\n"
                + "data: {\"content\": \" \u2028\"}\n\n"
                + "event: completion\n"
                + "data: {\"content\": \"foo\"}\n\n",
            new[]
            {
                "{\"content\": \" culpa\"}",
                "{\"content\": \" \u2028\"}",
                "{\"content\": \"foo\"}",
            }
        },
        // multi-byte character
        {
            "event: completion\n"
                + "data: {\"content\": "
                + "\"\u0438\u0437\u0432\u0435\u0441\u0442\u043d\u0438\"}\n\n}",
            new[] { "{\"content\":\"известни\"}" }
        },
    };

    public static TheoryData<string, string[]> Data
    {
        get { return _data; }
    }

    [Theory]
    [MemberData(nameof(Data))]
    public async Task Sse_Works(
        string events,
        string[] expectedMessageStrings,
        CancellationToken cancellationToken = default
    )
    {
        var expectedMessages = new List<JsonElement>();
        foreach (var message in expectedMessageStrings)
        {
            expectedMessages.Add(JsonSerializer.Deserialize<JsonElement>(message));
        }

        var resp = new HttpResponseMessage() { Content = new StringContent(events) };

        var actualMessages = new List<JsonElement>();
        await foreach (var message in Sse.Enumerate<JsonElement>(resp, cancellationToken))
        {
            actualMessages.Add(message);
        }

        Assert.Equal(expectedMessages.Count, actualMessages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedMessages[i], actualMessages[i]));
        }
    }

    [Fact]
    public async Task SseEventError_Works()
    {
        var resp = new HttpResponseMessage()
        {
            Content = new StringContent("event: error\ndata: unspecified error\n\n"),
        };

        var exception = await Assert.ThrowsAsync<AnthropicSseException>(async () =>
        {
            await foreach (
                var message in Sse.Enumerate<JsonElement>(
                    resp,
                    TestContext.Current.CancellationToken
                )
            ) { }
        });

        Assert.Equal("SSE error returned from server: 'unspecified error'", exception.Message);
    }

    [Fact]
    public void CreateApiException_ExtractsErrorType()
    {
        var body =
            """{"type":"error","error":{"type":"invalid_request_error","message":"Bad request"}}""";
        var ex = AnthropicExceptionFactory.CreateApiException(HttpStatusCode.BadRequest, body);

        Assert.IsType<AnthropicBadRequestException>(ex);
        Assert.Equal(ErrorType.InvalidRequestError, ex.ErrorType);
    }

    [Fact]
    public void CreateApiException_NullErrorType_WhenMissing()
    {
        var body = """{"message":"something went wrong"}""";
        var ex = AnthropicExceptionFactory.CreateApiException(HttpStatusCode.BadRequest, body);

        Assert.Null(ex.ErrorType);
    }

    [Fact]
    public void CreateApiException_NullErrorType_WhenNotJson()
    {
        var ex = AnthropicExceptionFactory.CreateApiException(
            HttpStatusCode.BadGateway,
            "Bad Gateway"
        );

        Assert.Null(ex.ErrorType);
    }

    [Fact]
    public void ExtractErrorType_NullForUnknownType()
    {
        var body = """{"type":"error","error":{"type":"some_future_error","message":"Unknown"}}""";
        var result = AnthropicExceptionFactory.ExtractErrorType(body);

        Assert.Null(result);
    }

    [Fact]
    public async Task StreamingError_SseException_WithErrorType()
    {
        var sseData =
            """{"type":"error","error":{"type":"overloaded_error","message":"Overloaded"}}""";
        var resp = new HttpResponseMessage()
        {
            Content = new StringContent($"event: error\ndata: {sseData}\n\n"),
        };

        var exception = await Assert.ThrowsAsync<AnthropicSseException>(async () =>
        {
            await foreach (
                var message in Sse.Enumerate<JsonElement>(
                    resp,
                    TestContext.Current.CancellationToken
                )
            ) { }
        });

        Assert.Equal(ErrorType.OverloadedError, exception.ErrorType);
    }

    [Fact]
    public async Task StreamingError_NonJsonData_NullErrorType()
    {
        var resp = new HttpResponseMessage()
        {
            Content = new StringContent("event: error\ndata: ThrottlingException\n\n"),
        };

        var exception = await Assert.ThrowsAsync<AnthropicSseException>(async () =>
        {
            await foreach (
                var message in Sse.Enumerate<JsonElement>(
                    resp,
                    TestContext.Current.CancellationToken
                )
            ) { }
        });

        Assert.Null(exception.ErrorType);
    }

    [Fact]
    public void ServiceException_CatchesBothHttpAndSseErrors()
    {
        // HTTP error is catchable as AnthropicServiceException
        var body =
            """{"type":"error","error":{"type":"rate_limit_error","message":"Rate limited"}}""";
        var httpEx = AnthropicExceptionFactory.CreateApiException((HttpStatusCode)429, body);
        Assert.IsType<AnthropicServiceException>(httpEx, exactMatch: false);
        Assert.Equal(ErrorType.RateLimitError, httpEx.ErrorType);

        // SSE error is catchable as AnthropicServiceException
        var sseEx = new AnthropicSseException("SSE error")
        {
            ErrorType = ErrorType.OverloadedError,
        };
        Assert.IsType<AnthropicServiceException>(sseEx, exactMatch: false);
        Assert.Equal(ErrorType.OverloadedError, sseEx.ErrorType);
    }

    [Fact]
    public async Task Sse_SkipsDoneTerminalEvent()
    {
        // Microsoft Foundry sends "data: [DONE]" (without an event: field) after
        // message_stop to signal end-of-stream. SseParser assigns it the default
        // EventType "message", which matches the deserialization case. Without the
        // [DONE] guard this would throw a JsonException.
        var events = """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Hello"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":5}}

            event: message_stop
            data: {"type":"message_stop"}

            data: [DONE]


            """;

        var resp = new HttpResponseMessage() { Content = new StringContent(events) };

        var actualMessages = new List<JsonElement>();
        await foreach (
            var message in Sse.Enumerate<JsonElement>(resp, TestContext.Current.CancellationToken)
        )
        {
            actualMessages.Add(message);
        }

        // Should have received 6 events (start, block_start, delta, block_stop, message_delta, message_stop)
        // and NOT thrown on [DONE]
        Assert.Equal(6, actualMessages.Count);
    }
}
