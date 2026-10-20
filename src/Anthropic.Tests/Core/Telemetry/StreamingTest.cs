using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Core.Telemetry;
using Anthropic.Helpers;
using Anthropic.Models.Messages;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

public class StreamingTest : TracingTestBase
{
    [Fact]
    public async Task MessagesCreateStreaming_ReadToTheEnd_RecordsReconstructedMessage()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);

        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal(true, span.GetTagItem("gen_ai.request.stream"));
        Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
        Assert.Equal("claude-test-20260101", span.GetTagItem("gen_ai.response.model"));
        Assert.Equal("tool_use", span.GetTagItem("anthropic.message.stop_reason"));
        Assert.Null(span.GetTagItem("gen_ai.response.finish_reasons"));
        Assert.Equal(8L, span.GetTagItem("gen_ai.usage.input_tokens"));
        Assert.Equal(12L, span.GetTagItem("gen_ai.usage.output_tokens"));
        Assert.Equal(
            4L,
            span.GetTagItem("anthropic.usage.cache_creation.ephemeral_5m_input_tokens")
        );
        Assert.Equal("priority", span.GetTagItem("anthropic.response.service_tier"));
        Assert.IsType<double>(span.GetTagItem("gen_ai.response.time_to_first_chunk"));
        Assert.Equal("req_stream", span.GetTagItem("anthropic.request.id"));
    }

    [Fact]
    public async Task MessagesCreateStreaming_AFallbackModelTakesOver_RecordsThatModel()
    {
        using var trace = new RecordedTrace();
        var events = new[]
        {
            Fixtures.MessageStart,
            (
                "content_block_start",
                """{"type":"content_block_start","index":0,"content_block":{"type":"fallback","from":{"model":"claude-test-20260101"},"to":{"model":"claude-fallback-20260101"},"trigger":{"type":"refusal","category":"cyber"}}}"""
            ),
            ("content_block_stop", """{"type":"content_block_stop","index":0}"""),
            (
                "content_block_start",
                """{"type":"content_block_start","index":1,"content_block":{"type":"text","text":""}}"""
            ),
            (
                "content_block_delta",
                """{"type":"content_block_delta","index":1,"delta":{"type":"text_delta","text":"Hello"}}"""
            ),
            ("content_block_stop", """{"type":"content_block_stop","index":1}"""),
        }
            .Concat(Fixtures.StreamBody.Skip(Fixtures.StreamBody.Length - 2))
            .ToArray();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(events));
        var client = Fixtures.Client(handler);

        await foreach (
            var _ in client.Beta.Messages.CreateStreaming(
                BetaParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal("claude-test", span.GetTagItem("gen_ai.request.model"));
        Assert.Equal("claude-fallback-20260101", span.GetTagItem("gen_ai.response.model"));
    }

    /// <summary>
    /// A stream whose last <c>message_delta</c> reports a compaction, up to <c>message_stop</c>
    /// or without it.
    /// </summary>
    static (string, string)[] StreamWithACompaction(bool messageStop) =>
        [
            Fixtures.MessageStart,
            (
                "message_delta",
                """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"input_tokens":7,"output_tokens":12,"iterations":[{"type":"compaction","input_tokens":100,"output_tokens":30,"cache_read_input_tokens":20,"cache_creation_input_tokens":5,"cache_creation":null},{"type":"message","input_tokens":7,"output_tokens":12,"cache_read_input_tokens":1,"cache_creation_input_tokens":0,"cache_creation":null}]}}"""
            ),
            .. messageStop ? Fixtures.StreamBody.Skip(Fixtures.StreamBody.Length - 1) : [],
        ];

    [Theory]
    [InlineData(OpenTelemetryContentMode.MetadataOnly)]
    [InlineData(OpenTelemetryContentMode.Content)]
    public async Task MessagesCreateStreaming_WithACompaction_HasItsTokensApartFromItsOwn(
        OpenTelemetryContentMode contentMode
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(StreamWithACompaction(messageStop: true))
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = contentMode } }
        );

        await foreach (
            var _ in client.Beta.Messages.CreateStreaming(
                BetaParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(125L, span.GetTagItem("anthropic.usage.compaction.input_tokens"));
        Assert.Equal(30L, span.GetTagItem("anthropic.usage.compaction.output_tokens"));
        Assert.Equal(8L, span.GetTagItem("gen_ai.usage.input_tokens"));
        Assert.Equal(12L, span.GetTagItem("gen_ai.usage.output_tokens"));
    }

    [Fact]
    public async Task MessagesCreateStreaming_EndedAfterMessageDelta_HasWhatItBrought()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(StreamWithACompaction(messageStop: false))
        );
        var client = Fixtures.Client(handler);

        await foreach (
            var _ in client.Beta.Messages.CreateStreaming(
                BetaParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        // The stream ended before `message_stop`, which fails the span and nothing else.
        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("api_error", span.GetTagItem("error.type"));
        Assert.Equal(8L, span.GetTagItem("gen_ai.usage.input_tokens"));
        Assert.Equal(12L, span.GetTagItem("gen_ai.usage.output_tokens"));
        Assert.Equal(125L, span.GetTagItem("anthropic.usage.compaction.input_tokens"));
        Assert.Equal(30L, span.GetTagItem("anthropic.usage.compaction.output_tokens"));
        Assert.Equal("end_turn", span.GetTagItem("anthropic.message.stop_reason"));
    }

    /// <summary>
    /// A stream that ends before its <c>message_delta</c>, whose <c>message_start</c> has every
    /// field that a <c>message_delta</c> would change.
    /// </summary>
    static readonly (string, string)[] StreamWithoutAMessageDelta =
    [
        (
            "message_start",
            """{"type":"message_start","message":{"id":"msg_s","type":"message","role":"assistant","model":"claude-test-20260101","content":[],"stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":7,"output_tokens":1,"output_tokens_details":{"thinking_tokens":1},"iterations":[{"type":"compaction","input_tokens":100,"output_tokens":30,"cache_read_input_tokens":20,"cache_creation_input_tokens":5,"cache_creation":null}]}}}"""
        ),
        .. Fixtures.StreamBody.Skip(1).Take(4),
    ];

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MessagesCreateStreaming_EndedBeforeMessageDelta_SaysNothingOfTheOutput(
        bool beta
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(StreamWithoutAMessageDelta));
        var client = Fixtures.Client(handler);

        if (beta)
        {
            await foreach (
                var _ in client.Beta.Messages.CreateStreaming(
                    BetaParams(),
                    TestContext.Current.CancellationToken
                )
            ) { }
        }
        else
        {
            await foreach (
                var _ in client.Messages.CreateStreaming(
                    MessageParams(),
                    TestContext.Current.CancellationToken
                )
            ) { }
        }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("api_error", span.GetTagItem("error.type"));
        // What `message_start` says of the request is there.
        Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
        Assert.Equal(7L, span.GetTagItem("gen_ai.usage.input_tokens"));
        Assert.NotNull(span.GetTagItem("gen_ai.response.time_to_first_chunk"));
        Assert.DoesNotContain(
            span.TagObjects,
            tag =>
                tag.Key
                    is "anthropic.message.stop_reason"
                        or "gen_ai.usage.output_tokens"
                        or "gen_ai.usage.reasoning.output_tokens"
                        or "anthropic.usage.compaction.input_tokens"
                        or "anthropic.usage.compaction.output_tokens"
        );
    }

    [Fact]
    public async Task MessagesCreateStreaming_ClosedEarly_LeavesStatusUnset()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);

        await foreach (
            var streamEvent in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        )
        {
            if (streamEvent.TryPickStart(out _))
            {
                break;
            }
        }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Null(span.GetTagItem("error.type"));
        Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
        Assert.Equal("priority", span.GetTagItem("anthropic.response.service_tier"));
        Assert.Equal(8L, span.GetTagItem("gen_ai.usage.input_tokens"));
        Assert.Null(span.GetTagItem("gen_ai.usage.output_tokens"));
        Assert.Null(span.GetTagItem("anthropic.message.stop_reason"));
    }

    [Fact]
    public async Task MessagesCreateStreaming_EndedByTheServerBeforeMessageStop_RecordsApiError()
    {
        using var trace = new RecordedTrace();
        // The body ends after `message_delta`, without `message_stop`.
        var events = Fixtures.StreamBody.Take(Fixtures.StreamBody.Length - 1).ToArray();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(events));
        var client = Fixtures.Client(handler);

        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("api_error", span.GetTagItem("error.type"));
        Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
        // The `message_delta` arrived, so what it says of the output is there.
        Assert.Equal(12L, span.GetTagItem("gen_ai.usage.output_tokens"));
        Assert.Equal("tool_use", span.GetTagItem("anthropic.message.stop_reason"));
    }

    [Fact]
    public async Task EventStream_ClosedByTheApplication_LeavesStatusUnset()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(SessionEvent("sevt_1"), SessionEvent("sevt_2"))
        );
        var client = Fixtures.Client(handler);

        await foreach (
            var _ in client.Beta.Sessions.Events.StreamStreaming(
                "sesn_1",
                cancellationToken: TestContext.Current.CancellationToken
            )
        )
        {
            break;
        }

        var span = trace.Single("anthropic.sessions.events.stream");
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Null(span.GetTagItem("error.type"));
    }

    // An event stream has no end event, so the server ending it does not complete the call.
    [Fact]
    public async Task EventStream_EndedByTheServer_LeavesStatusUnset()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(SessionEvent("sevt_1")));
        var client = Fixtures.Client(handler);

        var events = 0;
        await foreach (
            var _ in client.Beta.Sessions.Events.StreamStreaming(
                "sesn_1",
                cancellationToken: TestContext.Current.CancellationToken
            )
        )
        {
            events++;
        }

        Assert.Equal(1, events);
        var span = trace.Single("anthropic.sessions.events.stream");
        Assert.True(span.IsStopped);
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Null(span.GetTagItem("error.type"));
        Assert.Equal("anthropic", span.GetTagItem("gen_ai.provider.name"));
        Assert.Equal("api.example.test", span.GetTagItem("server.address"));
        Assert.Equal(200, span.GetTagItem("http.response.status_code"));
        Assert.Equal("req_stream", span.GetTagItem("anthropic.request.id"));
    }

    static (string, string) SessionEvent(string id) =>
        (
            "session.status_running",
            $$"""{"type":"session.status_running","id":"{{id}}","processed_at":"2026-01-01T00:00:00Z"}"""
        );

    [Fact]
    public async Task MessagesCreateStreaming_DisposedBeforeTheFirstRead_SendsNothingAndEmitsNoSpan()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);

        // The request is sent when the application starts reading the events.
        var events = client
            .Messages.CreateStreaming(MessageParams(), TestContext.Current.CancellationToken)
            .GetAsyncEnumerator(TestContext.Current.CancellationToken);
        await events.DisposeAsync();

        Assert.Empty(handler.Requests);
        Assert.Empty(trace.Spans);
    }

    [Fact]
    public async Task StreamOfASpanThatIsNotRecording_IsNotMarkedAsEndedEarly()
    {
        // A sampler that does not record the span: nothing reads the stream's events for it.
        using var span = new Activity("anthropic.messages.create") { IsAllDataRequested = false };
        span.Start();
        using var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("", Encoding.UTF8, "text/event-stream"),
        };

        await foreach (
            var _ in Tracing.EndApiCallSpanWhenStreamEnds(
                span,
                Events(),
                response,
                hasReadEndEvent: () => false,
                TestContext.Current.CancellationToken
            )
        ) { }

        Assert.True(span.IsStopped);
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Null(span.GetTagItem("error.type"));

        static async IAsyncEnumerable<int> Events()
        {
            await Task.Yield();
            yield return 1;
        }
    }

    [Fact]
    public async Task MessagesCreateStreaming_CanceledWhileReading_LeavesStatusUnset()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            TestContext.Current.CancellationToken
        );

        await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
        {
            await foreach (var _ in client.Messages.CreateStreaming(MessageParams(), cts.Token))
            {
                cts.Cancel();
            }
        });

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Null(span.GetTagItem("error.type"));
        Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
    }

    [Fact]
    public async Task MessagesCreateStreaming_Retried_MeasuresTimeToFirstChunkFromTheStartOfTheCall()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .Respond(_ =>
            {
                var response = ScriptedHandler.Response((HttpStatusCode)503, "{}", "req_a");
                response.Headers.TryAddWithoutValidation("Retry-After-Ms", "100");
                return response;
            })
            .RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);

        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(2, handler.Requests.Count);
        // The first chunk came with the second attempt, after the backoff. The timer that ends the
        // backoff and the stopwatch that measures the chunk are different clocks, hence the margin.
        Assert.True(
            Assert.IsType<double>(span.GetTagItem("gen_ai.response.time_to_first_chunk")) >= 0.08
        );
    }

    /// <summary>
    /// The types of the events of a streamed Messages create call of <paramref name="client"/>,
    /// the stable one or the beta one, as the application reads them. Disposing of it disposes of
    /// the call's stream.
    /// </summary>
    static async IAsyncEnumerable<string?> EventTypes(AnthropicClient client, bool beta)
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        if (beta)
        {
            await foreach (
                var streamEvent in client.Beta.Messages.CreateStreaming(
                    BetaParams(),
                    cancellationToken
                )
            )
            {
                yield return streamEvent.Json.GetProperty("type").GetString();
            }
        }
        else
        {
            await foreach (
                var streamEvent in client.Messages.CreateStreaming(
                    MessageParams(),
                    cancellationToken
                )
            )
            {
                yield return streamEvent.Json.GetProperty("type").GetString();
            }
        }
    }

    // The SDK's own helpers read the stream to its end, so the call completes.
    [Theory]
    [InlineData(false, false)]
    [InlineData(false, true)]
    [InlineData(true, false)]
    [InlineData(true, true)]
    public async Task MessagesCreateStreaming_ReadThroughAnAggregator_EndsOk(
        bool beta,
        bool collected
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);
        var cancellationToken = TestContext.Current.CancellationToken;

        string? stopReason;
        if (beta)
        {
            var events = client.Beta.Messages.CreateStreaming(BetaParams(), cancellationToken);
            BetaMessageContentAggregator aggregator = new();
            if (collected)
            {
                // The application reads the events that the aggregator passes through.
                await foreach (var _ in events.CollectAsync(aggregator)) { }
            }
            var message = collected ? aggregator.Message() : await events.Aggregate();
            stopReason = message.StopReason?.Raw();
        }
        else
        {
            var events = client.Messages.CreateStreaming(MessageParams(), cancellationToken);
            MessageContentAggregator aggregator = new();
            if (collected)
            {
                await foreach (var _ in events.CollectAsync(aggregator)) { }
            }
            var message = collected ? aggregator.Message() : await events.Aggregate();
            stopReason = message.StopReason?.Raw();
        }

        Assert.Equal("tool_use", stopReason);
        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Null(span.GetTagItem("error.type"));
        Assert.Equal("tool_use", span.GetTagItem("anthropic.message.stop_reason"));
        Assert.Equal(12L, span.GetTagItem("gen_ai.usage.output_tokens"));
    }

    // The application cannot tell whether the body ends right after `message_stop`, so closing
    // the stream there cancels the call like any other early close.
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MessagesCreateStreaming_ClosedAfterMessageStopBeforeTheBodyEnds_LeavesStatusUnset(
        bool beta
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);

        await foreach (var type in EventTypes(client, beta))
        {
            if (type == "message_stop")
            {
                break;
            }
        }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Null(span.GetTagItem("error.type"));
        // Everything else is as for a stream that was read to the end.
        Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
        Assert.Equal("tool_use", span.GetTagItem("anthropic.message.stop_reason"));
        Assert.Equal(8L, span.GetTagItem("gen_ai.usage.input_tokens"));
        Assert.Equal(12L, span.GetTagItem("gen_ai.usage.output_tokens"));
        Assert.IsType<double>(span.GetTagItem("gen_ai.response.time_to_first_chunk"));
        Assert.Equal("req_stream", span.GetTagItem("anthropic.request.id"));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MessagesCreateStreaming_TimeToFirstChunk_RunsToTheFirstContentBlockDelta(
        bool beta
    )
    {
        using var trace = new RecordedTrace();
        (string, string)[] events =
        [
            Fixtures.MessageStart,
            ("ping", """{"type":"ping"}"""),
            .. Fixtures.StreamBody.Skip(1),
        ];
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(events));
        var client = Fixtures.Client(handler);

        // The events are read from the body one at a time, so the wait before the application
        // asks for the one after the first `content_block_start` comes before the first
        // `content_block_delta` is received.
        long? readMessageStartAt = null;
        long? askedForTheFirstDeltaAt = null;
        await foreach (var type in EventTypes(client, beta))
        {
            if (type == "message_start")
            {
                readMessageStartAt = Stopwatch.GetTimestamp();
            }
            if (type == "content_block_start" && askedForTheFirstDeltaAt == null)
            {
                await Task.Delay(200, TestContext.Current.CancellationToken);
                askedForTheFirstDeltaAt = Stopwatch.GetTimestamp();
            }
        }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        // The call started before `message_start` was read, and the delta was received after the
        // wait, on the same clock.
        Assert.NotNull(readMessageStartAt);
        Assert.NotNull(askedForTheFirstDeltaAt);
        var wait =
            (double)(askedForTheFirstDeltaAt.Value - readMessageStartAt.Value)
            / Stopwatch.Frequency;
        Assert.True(wait >= 0.1);
        Assert.True(
            Assert.IsType<double>(span.GetTagItem("gen_ai.response.time_to_first_chunk")) >= wait
        );
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MessagesCreateStreaming_WithoutAContentBlockDelta_HasNoTimeToFirstChunk(
        bool beta
    )
    {
        using var trace = new RecordedTrace();
        // The one content block comes whole in its `content_block_start`.
        (string, string)[] events =
        [
            Fixtures.MessageStart,
            (
                "content_block_start",
                """{"type":"content_block_start","index":0,"content_block":{"type":"redacted_thinking","data":"enc_stream"}}"""
            ),
            ("content_block_stop", """{"type":"content_block_stop","index":0}"""),
            .. Fixtures.StreamBody.Skip(Fixtures.StreamBody.Length - 2),
        ];
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(events));
        var client = Fixtures.Client(handler);

        await foreach (var _ in EventTypes(client, beta)) { }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
        Assert.Equal(12L, span.GetTagItem("gen_ai.usage.output_tokens"));
        Assert.Null(span.GetTagItem("gen_ai.response.time_to_first_chunk"));
    }

    public static TheoryData<bool, string> ContentBlockDeltas()
    {
        var deltas = new TheoryData<bool, string>();
        foreach (var beta in new[] { false, true })
        {
            deltas.Add(beta, """{"type":"text_delta","text":"Hello"}""");
            deltas.Add(beta, """{"type":"input_json_delta","partial_json":"{\"q\":"}""");
            deltas.Add(beta, """{"type":"thinking_delta","thinking":"Let me"}""");
            deltas.Add(beta, """{"type":"signature_delta","signature":"sig_stream"}""");
            deltas.Add(
                beta,
                """{"type":"citations_delta","citation":{"type":"char_location","cited_text":"x","document_index":0,"document_title":null,"start_char_index":0,"end_char_index":1,"file_id":null}}"""
            );
            deltas.Add(beta, """{"type":"compaction_delta","content":"Summary"}""");
            // A type that this SDK version does not know.
            deltas.Add(beta, """{"type":"later_delta","later":true}""");
        }
        return deltas;
    }

    [Theory]
    [MemberData(nameof(ContentBlockDeltas))]
    public async Task MessagesCreateStreaming_AContentBlockDeltaOfAnyType_SetsTimeToFirstChunk(
        bool beta,
        string delta
    )
    {
        using var trace = new RecordedTrace();
        (string, string)[] events =
        [
            Fixtures.MessageStart,
            (
                "content_block_start",
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}"""
            ),
            (
                "content_block_delta",
                $$"""{"type":"content_block_delta","index":0,"delta":{{delta}}}"""
            ),
            ("content_block_stop", """{"type":"content_block_stop","index":0}"""),
            .. Fixtures.StreamBody.Skip(Fixtures.StreamBody.Length - 2),
        ];
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(events));
        var client = Fixtures.Client(handler);

        await foreach (var _ in EventTypes(client, beta)) { }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.IsType<double>(span.GetTagItem("gen_ai.response.time_to_first_chunk"));
    }
}
