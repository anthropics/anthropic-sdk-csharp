using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Helpers.Beta;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

/// <summary>
/// Where the tool runner span is current, when it ends, and that the runner does the same work
/// whether it is traced or not.
/// </summary>
public class ToolRunnerSpanContextTest : TracingTestBase
{
    const string SdkSourceName = "com.anthropic.sdk.csharp";

    [Fact]
    public async Task ToolRunner_SteppedFromAnotherTrace_KeepsItsWorkUnderTheToolRunnerSpan()
    {
        using var trace = new RecordedTrace();
        using var everySdkSpan = new StartedSdkSpans();
        // Stands in for an HTTP instrumentation, or a handler of the application's, that starts a
        // span for each request it sends.
        var inHandler = new List<Activity>();
        var handler = new ScriptedHandler()
            .Respond(_ =>
            {
                inHandler.Add(StartAndStop("send"));
                return ScriptedHandler.Response(HttpStatusCode.OK, ToolUseMessage, "req_1");
            })
            .Respond(_ =>
            {
                inHandler.Add(StartAndStop("send"));
                return ScriptedHandler.Response(HttpStatusCode.OK, FinalMessage, "req_2");
            });
        var client = Fixtures.Client(handler);
        Activity? inTool = null;
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [
                Tool(
                    "get_weather",
                    _ =>
                    {
                        inTool = StartAndStop("lookup");
                        return "rainy";
                    }
                ),
            ]
        );

        var enumerator = runner.GetAsyncEnumerator(TestContext.Current.CancellationToken);
        // The first step runs in the test's trace, and leaves the test's span current.
        Assert.True(await enumerator.MoveNextAsync());
        Assert.Same(trace.Root, Activity.Current);

        // The next steps run from a trace that has nothing to do with the first: the tool, the
        // second request, and the end of the loop.
        Activity.Current = null;
        var unrelated = new Activity("unrelated").SetIdFormat(ActivityIdFormat.W3C).Start();
        try
        {
            Assert.True(await enumerator.MoveNextAsync());
            Assert.Same(unrelated, Activity.Current);
            Assert.False(await enumerator.MoveNextAsync());
            Assert.Same(unrelated, Activity.Current);
            await enumerator.DisposeAsync();
            Assert.Same(unrelated, Activity.Current);
        }
        finally
        {
            unrelated.Stop();
            Activity.Current = trace.Root;
        }

        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(trace.Root.SpanId, toolRunnerSpan.ParentSpanId);
        Assert.Equal(ActivityStatusCode.Ok, toolRunnerSpan.Status);
        var toolUseSpan = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal(toolRunnerSpan.SpanId, toolUseSpan.ParentSpanId);
        var callSpans = trace
            .Spans.Where(span => span.OperationName == "anthropic.messages.create")
            .ToList();
        Assert.Equal(2, callSpans.Count);
        Assert.All(callSpans, span => Assert.Equal(toolRunnerSpan.SpanId, span.ParentSpanId));

        // What a handler and a tool start is under the tool runner span too, through the span of
        // the request and of the tool.
        Assert.Equal(2, inHandler.Count);
        Assert.Equal(
            callSpans.Select(span => span.SpanId).OrderBy(id => id.ToHexString()),
            inHandler.Select(span => span.ParentSpanId).OrderBy(id => id.ToHexString())
        );
        Assert.Equal(toolUseSpan.SpanId, inTool?.ParentSpanId);

        // Nothing landed in the unrelated trace.
        Assert.All(inHandler, span => Assert.Equal(trace.Root.TraceId, span.TraceId));
        Assert.Equal(trace.Root.TraceId, inTool?.TraceId);
        Assert.DoesNotContain(everySdkSpan.Started, span => span.TraceId == unrelated.TraceId);
    }

    [Fact]
    public async Task ToolRunner_Streaming_EventsReadFromAnotherTrace_SendTheRequestUnderTheToolRunnerSpan()
    {
        using var trace = new RecordedTrace();
        using var everySdkSpan = new StartedSdkSpans();
        var handler = new ScriptedHandler()
            .RespondStream(Fixtures.Sse(Fixtures.StreamBody))
            .RespondStream(FinalStream);
        var client = Fixtures.Client(handler);
        Activity? inTool = null;
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [
                Tool(
                    "lookup",
                    _ =>
                    {
                        inTool = StartAndStop("lookup");
                        return "found";
                    }
                ),
            ]
        );

        var turns = runner
            .Streaming(TestContext.Current.CancellationToken)
            .GetAsyncEnumerator(TestContext.Current.CancellationToken);
        Assert.True(await turns.MoveNextAsync());
        var firstTurn = turns.Current;

        // The request of a streamed turn is sent when its events are first read: here from a
        // trace that has nothing to do with the one that the loop started in.
        Activity.Current = null;
        var unrelated = new Activity("unrelated").SetIdFormat(ActivityIdFormat.W3C).Start();
        try
        {
            await foreach (var _ in firstTurn)
            {
                Assert.Same(unrelated, Activity.Current);
            }
            Assert.Same(unrelated, Activity.Current);
            // The tool runs in the step that asks for the next turn.
            Assert.True(await turns.MoveNextAsync());
            Assert.Same(unrelated, Activity.Current);
            await foreach (var _ in turns.Current) { }
            Assert.False(await turns.MoveNextAsync());
            await turns.DisposeAsync();
            Assert.Same(unrelated, Activity.Current);
        }
        finally
        {
            unrelated.Stop();
            Activity.Current = trace.Root;
        }

        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(ActivityStatusCode.Ok, toolRunnerSpan.Status);
        Assert.Equal(trace.Root.SpanId, toolRunnerSpan.ParentSpanId);
        var callSpans = trace
            .Spans.Where(span => span.OperationName == "anthropic.messages.create")
            .ToList();
        Assert.Equal(2, callSpans.Count);
        Assert.All(callSpans, span => Assert.Equal(toolRunnerSpan.SpanId, span.ParentSpanId));
        Assert.Equal(
            ["tool_use", "end_turn"],
            callSpans.Select(span => span.GetTagItem("anthropic.message.stop_reason"))
        );
        var toolUseSpan = trace.Single("anthropic.custom_tool_use lookup");
        Assert.Equal(toolRunnerSpan.SpanId, toolUseSpan.ParentSpanId);
        Assert.Equal(toolUseSpan.SpanId, inTool?.ParentSpanId);
        Assert.DoesNotContain(everySdkSpan.Started, span => span.TraceId == unrelated.TraceId);
    }

    [Fact]
    public async Task ToolRunner_NotReadToTheEnd_KeepsItsSpanOpenUntilItIsDisposedOf()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(ToolUseMessage);
        var client = Fixtures.Client(handler);
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [Tool("get_weather", _ => "rainy")]
        );

        var enumerator = runner.GetAsyncEnumerator(TestContext.Current.CancellationToken);
        Assert.True(await enumerator.MoveNextAsync());

        // The application holds a turn, and may never ask for another: the loop has not ended.
        Assert.DoesNotContain(
            trace.Spans,
            span => span.OperationName == "anthropic.messages.tool_runner"
        );

        // Disposing of the enumerator stops the runner: the span ends, once, as canceled.
        await enumerator.DisposeAsync();
        await enumerator.DisposeAsync();

        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(ActivityStatusCode.Unset, toolRunnerSpan.Status);
        Assert.Null(toolRunnerSpan.GetTagItem("error.type"));
        Assert.Same(trace.Root, Activity.Current);
    }

    [Fact]
    public async Task ToolRunner_DoesTheSameWork_WhetherItIsTracedOrNot()
    {
        OpenTelemetryOptions[] options =
        [
            new()
            {
                Traces = new()
                {
                    Enabled = false,
                    ContentMode = OpenTelemetryContentMode.MetadataOnly,
                },
            },
            new()
            {
                Traces = new() { Enabled = false, ContentMode = OpenTelemetryContentMode.Content },
            },
            new()
            {
                Traces = new()
                {
                    Enabled = true,
                    ContentMode = OpenTelemetryContentMode.MetadataOnly,
                },
            },
            new()
            {
                Traces = new() { Enabled = true, ContentMode = OpenTelemetryContentMode.Content },
            },
        ];

        foreach (var streaming in new[] { false, true })
        {
            var runs = new List<(List<string> Requests, List<string> Turns, int SpanCount)>();
            foreach (var openTelemetry in options)
            {
                runs.Add(await Run(openTelemetry, streaming));
            }

            Assert.All(
                runs,
                run =>
                {
                    Assert.Equal(2, run.Requests.Count);
                    Assert.Equal(runs[0].Requests, run.Requests);
                    Assert.Equal(runs[0].Turns, run.Turns);
                }
            );
            // The second request has the conversation that the runner built: the first turn, and
            // the result of its tool.
            Assert.Contains("\"tool_result\"", runs[0].Requests[1], StringComparison.Ordinal);
            Assert.Contains("found it", runs[0].Requests[1], StringComparison.Ordinal);
            Assert.Equal([0, 0, 4, 4], runs.Select(run => run.SpanCount));
        }

        // One conversation of two turns with one tool call, traced as `openTelemetry` says: the
        // body of each request, each turn as the application got it, and the number of spans.
        static async Task<(List<string> Requests, List<string> Turns, int SpanCount)> Run(
            OpenTelemetryOptions openTelemetry,
            bool streaming
        )
        {
            using var trace = new RecordedTrace();
            var requests = new List<string>();
            HttpResponseMessage Record(HttpRequestMessage request, HttpResponseMessage response)
            {
                requests.Add(request.Content!.ReadAsStringAsync().GetAwaiter().GetResult());
                return response;
            }
            var handler = new ScriptedHandler()
                .Respond(request =>
                    Record(
                        request,
                        streaming
                            ? Stream(Fixtures.Sse(Fixtures.StreamBody))
                            : ScriptedHandler.Response(HttpStatusCode.OK, LookupMessage, "req_1")
                    )
                )
                .Respond(request =>
                    Record(
                        request,
                        streaming
                            ? Stream(FinalStream)
                            : ScriptedHandler.Response(HttpStatusCode.OK, FinalMessage, "req_2")
                    )
                );
            var client = Fixtures.Client(handler, openTelemetry);
            var runner = client.Beta.Messages.ToolRunner(
                BetaParams(),
                [Tool("lookup", _ => "found it")]
            );

            var turns = new List<string>();
            if (streaming)
            {
                await foreach (
                    var events in runner.Streaming(TestContext.Current.CancellationToken)
                )
                {
                    var turn = new List<string>();
                    await foreach (var streamEvent in events)
                    {
                        turn.Add(streamEvent.Json.GetRawText());
                    }
                    turns.Add(string.Join("\n", turn));
                }
            }
            else
            {
                await foreach (
                    var message in runner.WithCancellation(TestContext.Current.CancellationToken)
                )
                {
                    turns.Add(JsonSerializer.Serialize(message.RawData));
                }
            }
            return (requests, turns, trace.Spans.Count);
        }

        static HttpResponseMessage Stream(string body)
        {
            var response = ScriptedHandler.Response(HttpStatusCode.OK, body, "req_stream");
            response.Content.Headers.ContentType = new("text/event-stream");
            return response;
        }
    }

    /// <summary>
    /// Every activity of the SDK's source that starts while this listens, in any trace.
    /// </summary>
    sealed class StartedSdkSpans : IDisposable
    {
        readonly ActivityListener _listener;
        readonly List<Activity> _started = [];

        public StartedSdkSpans()
        {
            _listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == SdkSourceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                    ActivitySamplingResult.AllDataAndRecorded,
                ActivityStarted = activity =>
                {
                    lock (_started)
                    {
                        _started.Add(activity);
                    }
                },
            };
            ActivitySource.AddActivityListener(_listener);
        }

        public IReadOnlyList<Activity> Started
        {
            get
            {
                lock (_started)
                {
                    return [.. _started];
                }
            }
        }

        public void Dispose() => _listener.Dispose();
    }

    /// <summary>
    /// A span of the application's own, as a child of the current one.
    /// </summary>
    static Activity StartAndStop(string name)
    {
        var span = new Activity(name).Start();
        span.Stop();
        return span;
    }

    static BetaRunnableTool Tool(string name, Func<Beta.BetaToolUseBlock, string> run) =>
        new()
        {
            Name = name,
            Definition = new Beta.BetaTool { Name = name, InputSchema = new() },
            Run = (block, _) => Task.FromResult<Beta.BetaToolResultBlockParamContent>(run(block)),
        };

    const string ToolUseMessage = """
        {
          "id": "msg_t",
          "type": "message",
          "role": "assistant",
          "model": "claude-test-20260101",
          "content": [{"type": "tool_use", "id": "toolu_w", "name": "get_weather", "input": {"city": "Oslo"}}],
          "stop_reason": "tool_use",
          "stop_sequence": null,
          "usage": {"input_tokens": 10, "output_tokens": 5}
        }
        """;

    const string LookupMessage = """
        {
          "id": "msg_t",
          "type": "message",
          "role": "assistant",
          "model": "claude-test-20260101",
          "content": [{"type": "tool_use", "id": "toolu_9", "name": "lookup", "input": {"q": "x"}}],
          "stop_reason": "tool_use",
          "stop_sequence": null,
          "usage": {"input_tokens": 10, "output_tokens": 5}
        }
        """;

    const string FinalMessage = """
        {
          "id": "msg_f",
          "type": "message",
          "role": "assistant",
          "model": "claude-test-20260101",
          "content": [{"type": "text", "text": "done"}],
          "stop_reason": "end_turn",
          "stop_sequence": null,
          "usage": {"input_tokens": 12, "output_tokens": 2}
        }
        """;

    static readonly string FinalStream = Fixtures.Sse(
        Fixtures.MessageStart,
        (
            "content_block_start",
            """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}"""
        ),
        (
            "content_block_delta",
            """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"done"}}"""
        ),
        ("content_block_stop", """{"type":"content_block_stop","index":0}"""),
        (
            "message_delta",
            """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":2}}"""
        ),
        ("message_stop", """{"type":"message_stop"}""")
    );
}
