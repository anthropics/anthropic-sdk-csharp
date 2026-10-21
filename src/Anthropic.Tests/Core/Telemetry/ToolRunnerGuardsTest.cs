using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Helpers.Beta;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

/// <summary>
/// The spans of a tool runner never change what the loop does with the application's tools. Each
/// test has an activity source of its own, so that what it listens to, or leaves without a
/// listener, is not what the tests that run beside it listen to.
/// </summary>
public sealed class ToolRunnerGuardsTest : IDisposable
{
    readonly ActivitySource _source = new("anthropic.tests.guards." + Guid.NewGuid().ToString("N"));
    readonly List<IDisposable> _disposables = [];

    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
        _source.Dispose();
    }

    AnthropicClient Client(ScriptedHandler handler, OpenTelemetryOptions? openTelemetry = null) =>
        new()
        {
            HttpClient = new HttpClient(handler),
            BaseUrl = Fixtures.BaseUrl,
            ApiKey = "test-key",
            MaxRetries = 0,
            OpenTelemetry = openTelemetry,
            OpenTelemetrySource = _source,
        };

    /// <summary>
    /// Listens to this test's source, and collects its activities as they stop.
    /// </summary>
    ConcurrentQueue<Activity> Listen(Action<Activity>? stopped = null)
    {
        ConcurrentQueue<Activity> spans = new();
        ActivityListener listener = new()
        {
            ShouldListenTo = source => ReferenceEquals(source, _source),
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity =>
            {
                spans.Enqueue(activity);
                stopped?.Invoke(activity);
            },
        };
        ActivitySource.AddActivityListener(listener);
        _disposables.Add(listener);
        return spans;
    }

    static Beta.MessageCreateParams Params() =>
        new()
        {
            MaxTokens = 64,
            Messages = [new Beta.BetaUserMessageParam { Content = "Weather?" }],
            Model = "claude-test",
        };

    /// <summary>
    /// The body of the request that answers the model's tool call, once it has been sent.
    /// </summary>
    string? _toolResultRequest;

    /// <summary>
    /// Answers the first request with a call of the tool, and keeps the body of the second.
    /// </summary>
    ScriptedHandler Handler() =>
        new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .Respond(request =>
            {
                _toolResultRequest = request.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
                return ScriptedHandler.Response(HttpStatusCode.OK, Fixtures.MessageJson, "req_2");
            });

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

    /// <summary>
    /// A tool of the application's own class, whose definition is computed at each read, and
    /// throws once <see cref="DefinitionThrows"/> is set.
    /// </summary>
    sealed class WeatherTool : IBetaRunnableTool
    {
        public int DefinitionReads { get; private set; }

        public bool DefinitionThrows { get; set; }

        public string Name => "get_weather";

        public Beta.BetaToolUnion Definition
        {
            get
            {
                DefinitionReads++;
                if (DefinitionThrows)
                {
                    throw new InvalidOperationException("definition");
                }
                return new Beta.BetaTool
                {
                    Name = "get_weather",
                    Description = "Gets the weather of a city.",
                    InputSchema = new() { Properties = new Dictionary<string, JsonElement>() },
                };
            }
        }

        public Task<Beta.BetaToolResultBlockParamContent> ExecuteAsync(
            Beta.BetaToolUseBlock toolUseBlock,
            CancellationToken cancellationToken
        ) => Task.FromResult<Beta.BetaToolResultBlockParamContent>("rainy");
    }

    /// <summary>
    /// The tool result that the runner sent back to the model, as the JSON of its block.
    /// </summary>
    JsonElement SentToolResult()
    {
        var body = JsonDocument.Parse(Assert.IsType<string>(_toolResultRequest)).RootElement;
        foreach (var message in body.GetProperty("messages").EnumerateArray())
        {
            if (message.GetProperty("content").ValueKind != JsonValueKind.Array)
            {
                continue;
            }
            foreach (var block in message.GetProperty("content").EnumerateArray())
            {
                if (block.GetProperty("type").GetString() == "tool_result")
                {
                    return block;
                }
            }
        }
        throw new InvalidOperationException("The runner sent no tool result.");
    }

    void AssertRanTheTool()
    {
        var result = SentToolResult();
        Assert.Equal("rainy", result.GetProperty("content").GetString());
        Assert.False(
            result.TryGetProperty("is_error", out var isError)
                && isError.ValueKind == JsonValueKind.True
        );
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task WithoutASpanToStart_TheRunnerDoesNotReadAToolsDefinitionAgain(bool tracesOff)
    {
        // Something listens, so only the option keeps the second case from a span.
        var spans = tracesOff ? Listen() : new();
        var tool = new WeatherTool();
        var runner = Client(Handler(), tracesOff ? false : null)
            .Beta.Messages.ToolRunner(Params(), [tool]);
        var readsToMakeTheRunner = tool.DefinitionReads;
        tool.DefinitionThrows = true;

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        Assert.Equal(readsToMakeTheRunner, tool.DefinitionReads);
        AssertRanTheTool();
        Assert.Empty(spans);
    }

    [Fact]
    public async Task AToolWhoseDefinitionThrows_StillRuns_AndItsSpanHasNoDescription()
    {
        var spans = Listen();
        var tool = new WeatherTool();
        var runner = Client(Handler()).Beta.Messages.ToolRunner(Params(), [tool]);
        tool.DefinitionThrows = true;

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        AssertRanTheTool();
        var toolSpan = Assert.Single(
            spans,
            span => span.OperationName == "anthropic.custom_tool_use get_weather"
        );
        Assert.Equal(ActivityStatusCode.Ok, toolSpan.Status);
        Assert.Null(toolSpan.GetTagItem("gen_ai.tool.description"));
        Assert.Equal(
            ActivityStatusCode.Ok,
            Assert
                .Single(spans, span => span.OperationName == "anthropic.messages.tool_runner")
                .Status
        );
    }

    [Fact]
    public async Task AListenerThatThrowsAsASpanStops_DoesNotFailTheLoop()
    {
        var spans = Listen(_ => throw new InvalidOperationException("listener"));
        var runner = Client(Handler()).Beta.Messages.ToolRunner(Params(), [new WeatherTool()]);
        // In the W3C format whatever the runtime's default, as the other tracing tests are.
        var application = new Activity("application").SetIdFormat(ActivityIdFormat.W3C).Start();
        try
        {
            var message = await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

            Assert.Equal("msg_1", message.ID);
            Assert.Same(application, Activity.Current);
        }
        finally
        {
            application.Stop();
        }

        AssertRanTheTool();
        // Two requests, the tool, and the loop.
        Assert.Equal(4, spans.Count);
    }
}
