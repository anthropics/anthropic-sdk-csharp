using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Exceptions;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;
using Moq;
using static Anthropic.Tests.Helpers.Beta.BetaToolRunnerTest;

namespace Anthropic.Tests.Helpers.Beta;

// Shares the collection with the other tests that read stderr, where the runner's warnings go.
[Collection("console stderr")]
public class BetaToolRunnerCompactionTest
{
    private const string CompactionBlock =
        """{"type":"compaction","content":"Summary so far.","encrypted_content":null,"signature":"sig_01"}""";

    private const string CompactionBlockAlone =
        $$"""[{"role":"assistant","content":[{{CompactionBlock}}]}]""";

    private const string UnmodelledBlock =
        """{"type":"mcp_tool_listing","mcp_server_name":"docs","tools":[]}""";

    /// <summary>
    /// A messages service that hands out the given responses in order and records each
    /// request. A request beyond the last response fails the test.
    /// </summary>
    private sealed class Script
    {
        private readonly Mock<IMessageService> _mock = new();

        public List<MessageCreateParams> Requests { get; } = [];

        public IMessageService Service => _mock.Object;

        public Script(params BetaMessage[] responses)
        {
            var remaining = new Queue<BetaMessage>(responses);
            _mock
                .Setup(s =>
                    s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
                )
                .ReturnsAsync((MessageCreateParams p, CancellationToken _) => Next(p, remaining));
        }

        public Script(params IAsyncEnumerable<BetaRawMessageStreamEvent>[] streams)
        {
            var remaining = new Queue<IAsyncEnumerable<BetaRawMessageStreamEvent>>(streams);
            _mock
                .Setup(s =>
                    s.CreateStreaming(
                        It.IsAny<MessageCreateParams>(),
                        It.IsAny<CancellationToken>()
                    )
                )
                .Returns((MessageCreateParams p, CancellationToken _) => Next(p, remaining));
        }

        private T Next<T>(MessageCreateParams request, Queue<T> remaining)
        {
            Requests.Add(request);
            return remaining.Dequeue();
        }
    }

    private static BetaContentBlock Block(string json) =>
        JsonSerializer.Deserialize<BetaContentBlock>(json)!;

    private static BetaMessage ToolUseTurn(string id = "tu_1") =>
        MakeMessage(
            [
                MakeToolUseBlock(
                    id,
                    "get_weather",
                    new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                ),
            ],
            BetaStopReason.ToolUse
        );

    private static BetaMessage FinalTurn(BetaStopReason stopReason = BetaStopReason.EndTurn) =>
        MakeMessage([MakeTextBlock("Done.")], stopReason);

    private static BetaMessage CompactedResponse(params string[] blocks) =>
        MakeMessage(
            [.. (blocks.Length == 0 ? [CompactionBlock] : blocks).Select(Block)],
            BetaStopReason.Compaction
        );

    private static BetaToolRunner WeatherRunner(
        Script script,
        MessageCreateParams? parameters = null,
        int? maxIterations = null
    ) =>
        script.Service.ToolRunner(
            parameters ?? BaseParams,
            [MakeWeatherToolSync(_ => "Sunny")],
            maxIterations
        );

    private static BetaContextManagementConfig ContextManagementWith(Edit edit) =>
        new() { Edits = [edit] };

    private static void AssertJson(string expectedJson, JsonElement actual)
    {
        using var expected = JsonDocument.Parse(expectedJson);
        Assert.True(
            JsonElement.DeepEquals(expected.RootElement, actual),
            $"Expected {expectedJson} but got {actual.GetRawText()}"
        );
    }

    private static List<string> Roles(MessageCreateParams request) =>
        [
            .. request
                .RawBodyData["messages"]
                .EnumerateArray()
                .Select(m => m.GetProperty("role").GetString()!),
        ];

    private static string? LastBlockType(MessageCreateParams request) =>
        request
            .RawBodyData["messages"]
            .EnumerateArray()
            .Last()
            .GetProperty("content")
            .EnumerateArray()
            .Last()
            .GetProperty("type")
            .GetString();

    [Fact]
    public async Task CompactBeforeNextTurn_IsSentAfterToolResults()
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(
            ToolUseTurn(),
            CompactedResponse(CompactionBlock, UnmodelledBlock),
            FinalTurn()
        );
        BetaToolRunner runner = null!;
        runner = script.Service.ToolRunner(
            BaseParams with
            {
                Betas = ["compact-2026-09-04"],
                ContextManagement = ContextManagementWith(new BetaClearToolUses20250919Edit()),
            },
            [
                MakeWeatherToolSync(_ =>
                {
                    // A later call, here from inside a tool, replaces the pending compaction.
                    runner.CompactBeforeNextTurn(new() { Instructions = "Keep the units." });
                    return "Sunny";
                }),
            ],
            // The compaction request is not a model turn, so both real turns still fit.
            maxIterations: 2
        );

        var yielded = new List<BetaMessage>();
        await foreach (var message in runner.WithCancellation(ct))
        {
            yielded.Add(message);
            if (message.StopReason == BetaStopReason.ToolUse)
            {
                runner.CompactBeforeNextTurn(new() { Instructions = "Keep the city." });
            }
            else if (message.StopReason == BetaStopReason.Compaction)
            {
                // There is nothing new to summarize yet, so this one is ignored.
                runner.CompactBeforeNextTurn();
            }
        }

        Assert.Equal(
            [BetaStopReason.ToolUse, BetaStopReason.Compaction, BetaStopReason.EndTurn],
            yielded.Select(m => m.StopReason!.Value())
        );
        Assert.True(yielded[1].Content[0].TryPickCompaction(out var block));
        Assert.Equal("Summary so far.", block!.Content);

        Assert.Equal(3, script.Requests.Count);
        var first = script.Requests[0];
        var compaction = script.Requests[1];
        var after = script.Requests[2];

        Assert.False(first.RawBodyData.ContainsKey("compaction"));
        AssertJson(
            """{"type":"summarize","instructions":"Keep the units."}""",
            compaction.RawBodyData["compaction"]
        );
        Assert.False(compaction.RawBodyData.ContainsKey("context_management"));
        Assert.Equal(["user", "assistant", "user"], Roles(compaction));
        Assert.Equal("tool_result", LastBlockType(compaction));
        Assert.True(
            JsonElement.DeepEquals(first.RawBodyData["tools"], compaction.RawBodyData["tools"])
        );

        // The history is the response as it came, the block this SDK doesn't model included.
        AssertJson(
            $$"""[{"role":"assistant","content":[{{CompactionBlock}},{{UnmodelledBlock}}]}]""",
            after.RawBodyData["messages"]
        );
        Assert.False(after.RawBodyData.ContainsKey("compaction"));
        Assert.True(
            JsonElement.DeepEquals(
                first.RawBodyData["context_management"],
                after.RawBodyData["context_management"]
            )
        );
        // The beta is the caller's to pass; the runner sends what it was given and nothing more.
        Assert.All(
            script.Requests,
            r => AssertJson("""["compact-2026-09-04"]""", r.RawHeaderData["anthropic-beta"])
        );
    }

    [Fact]
    public async Task CompactBeforeNextTurn_BeforeFirstIteration_IsFirstRequest()
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(CompactedResponse(), FinalTurn());
        var runner = WeatherRunner(script);

        // An edit made before the compaction request is part of what gets summarized.
        runner.PushMessages(new BetaMessageParam { Content = "And in NYC?", Role = Role.User });
        runner.CompactBeforeNextTurn();
        var final = await runner.RunUntilDoneAsync(ct);

        Assert.Equal(BetaStopReason.EndTurn, final.StopReason!.Value());
        Assert.Equal(2, script.Requests.Count);
        AssertJson("""{"type":"summarize"}""", script.Requests[0].RawBodyData["compaction"]);
        AssertJson(
            """[{"role":"user","content":"Hello"},{"role":"user","content":"And in NYC?"}]""",
            script.Requests[0].RawBodyData["messages"]
        );
        Assert.All(
            script.Requests,
            r => Assert.False(r.RawHeaderData.ContainsKey("anthropic-beta"))
        );
    }

    [Theory]
    [InlineData("""{"type":"any"}""", false, true)]
    [InlineData("""{"type":"tool","name":"get_weather"}""", false, true)]
    [InlineData("""{"type":"auto"}""", true, true)]
    [InlineData("""{"type":"auto"}""", true, false)]
    public async Task CompactionRequest_LeavesOffTheReplyOnlyParams(
        string toolChoice,
        bool toolChoiceIsSent,
        bool outputConfigHasEffort
    )
    {
        var ct = TestContext.Current.CancellationToken;
        var format = new BetaJsonOutputFormat
        {
            Schema = new Dictionary<string, JsonElement>
            {
                ["type"] = JsonSerializer.SerializeToElement("object"),
            },
        };
        BetaOutputConfig outputConfig = outputConfigHasEffort
            ? new() { Effort = Effort.Low, Format = format }
            : new() { Format = format };
        var parameters = BaseParams with
        {
            Betas = ["compact-2026-09-04"],
            System = "Be brief.",
            StopSequences = ["END"],
            ToolChoice = JsonSerializer.Deserialize<BetaToolChoice>(toolChoice)!,
            OutputConfig = outputConfig,
            OutputFormat = format,
            Fallbacks = new List<BetaFallbackParam>
            {
                new("fallback-model") { OutputConfig = outputConfig },
            },
        };
        var script = new Script(CompactedResponse(), FinalTurn());
        var runner = WeatherRunner(script, parameters);

        runner.CompactBeforeNextTurn();
        await runner.RunUntilDoneAsync(ct);

        Assert.Equal(2, script.Requests.Count);
        var compaction = script.Requests[0];
        var after = script.Requests[1];

        Assert.True(compaction.RawBodyData.ContainsKey("compaction"));
        Assert.False(compaction.RawBodyData.ContainsKey("stop_sequences"));
        Assert.False(compaction.RawBodyData.ContainsKey("output_format"));
        if (outputConfigHasEffort)
        {
            AssertJson("""{"effort":"low"}""", compaction.RawBodyData["output_config"]);
            AssertJson(
                """[{"model":"fallback-model","output_config":{"effort":"low"}}]""",
                compaction.RawBodyData["fallbacks"]
            );
        }
        else
        {
            Assert.False(compaction.RawBodyData.ContainsKey("output_config"));
            AssertJson("""[{"model":"fallback-model"}]""", compaction.RawBodyData["fallbacks"]);
        }
        Assert.Equal(toolChoiceIsSent, compaction.RawBodyData.ContainsKey("tool_choice"));
        foreach (var key in new[] { "tools", "system", "max_tokens" })
        {
            Assert.True(
                JsonElement.DeepEquals(after.RawBodyData[key], compaction.RawBodyData[key]),
                key
            );
        }

        foreach (
            var key in new[]
            {
                "stop_sequences",
                "tool_choice",
                "output_config",
                "output_format",
                "fallbacks",
            }
        )
        {
            Assert.True(
                JsonElement.DeepEquals(parameters.RawBodyData[key], after.RawBodyData[key]),
                key
            );
        }
        Assert.All(
            script.Requests,
            r => AssertJson("""["compact-2026-09-04"]""", r.RawHeaderData["anthropic-beta"])
        );
    }

    private static BetaMessageParam WeatherToolRemoval =>
        new()
        {
            Role = Role.System,
            Content = new BetaMessageParamContent(
                [new BetaRequestToolRemovalBlock(new BetaToolChangeToolReference("get_weather"))]
            ),
        };

    [Fact]
    public async Task Compaction_KeepsARemovalThatOnlyTheHistoryHeld()
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(CompactedResponse(), ToolUseTurn(), FinalTurn());
        var runs = 0;
        var runner = script.Service.ToolRunner(
            BaseParams,
            [
                MakeWeatherToolSync(_ =>
                {
                    runs++;
                    return "Sunny";
                }),
            ]
        );

        runner.PushMessages(WeatherToolRemoval);
        runner.CompactBeforeNextTurn();
        await runner.RunUntilDoneAsync(ct);

        Assert.Equal(0, runs);
        var result = script
            .Requests[2]
            .RawBodyData["messages"]
            .EnumerateArray()
            .Last()
            .GetProperty("content")
            .EnumerateArray()
            .Single();
        Assert.True(result.GetProperty("is_error").GetBoolean());
        Assert.Equal("Tool 'get_weather' not found", result.GetProperty("content").GetString());
    }

    [Fact]
    public async Task Compaction_KeepsAToolAddedBackWhileItsResponseIsHandled()
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(CompactedResponse(), ToolUseTurn(), FinalTurn());
        var weatherTool = MakeWeatherToolSync(_ => "Sunny");
        var runner = script.Service.ToolRunner(BaseParams, [weatherTool]);

        runner.PushMessages(WeatherToolRemoval);
        runner.CompactBeforeNextTurn();
        await foreach (var message in runner.WithCancellation(ct))
        {
            if (message.StopReason == BetaStopReason.Compaction)
            {
                runner.AddTools(weatherTool);
            }
        }

        Assert.Equal(["assistant", "system"], Roles(script.Requests[1]));
        Assert.Equal("tool_addition", LastBlockType(script.Requests[1]));
        var result = script
            .Requests[2]
            .RawBodyData["messages"]
            .EnumerateArray()
            .Last()
            .GetProperty("content")
            .EnumerateArray()
            .Single();
        Assert.Equal("Sunny", result.GetProperty("content").GetString());
    }

    [Fact]
    public async Task CompactBeforeNextTurn_DuringPausedTurn_WaitsForTheTurnToFinish()
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(MakePausedTurn(), ToolUseTurn(), CompactedResponse(), FinalTurn());
        var runner = WeatherRunner(script);

        await foreach (var message in runner.WithCancellation(ct))
        {
            if (message.StopReason == BetaStopReason.PauseTurn)
            {
                runner.CompactBeforeNextTurn();
            }
        }

        Assert.Equal(4, script.Requests.Count);
        var resumed = script.Requests[1];
        var compaction = script.Requests[2];
        Assert.False(resumed.RawBodyData.ContainsKey("compaction"));
        Assert.Equal(["user", "assistant"], Roles(resumed));
        Assert.Equal("server_tool_use", LastBlockType(resumed));
        Assert.True(compaction.RawBodyData.ContainsKey("compaction"));
        Assert.Equal("tool_result", LastBlockType(compaction));
    }

    // A cut-off turn with no tool call in it is complete, so it compacts like a final answer.
    [Theory]
    [InlineData(BetaStopReason.EndTurn)]
    [InlineData(BetaStopReason.MaxTokens)]
    public async Task CompactBeforeNextTurn_OnTheFinalTurn_CompactsThenStops(
        BetaStopReason stopReason
    )
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(FinalTurn(stopReason), CompactedResponse());
        // The final turn is also the last iteration allowed; the compaction still goes out.
        var runner = WeatherRunner(script, maxIterations: 1);

        var stopReasons = new List<BetaStopReason>();
        await foreach (var message in runner.WithCancellation(ct))
        {
            stopReasons.Add(message.StopReason!.Value());
            runner.CompactBeforeNextTurn();
        }

        Assert.Equal([stopReason, BetaStopReason.Compaction], stopReasons);
        Assert.Equal(2, script.Requests.Count);
        AssertJson("""{"type":"summarize"}""", script.Requests[1].RawBodyData["compaction"]);
        AssertJson(
            """
            [
              {"role":"user","content":"Hello"},
              {"role":"assistant","content":[{"type":"text","text":"Done."}]}
            ]
            """,
            script.Requests[1].RawBodyData["messages"]
        );
        AssertJson(CompactionBlockAlone, runner.Params.RawBodyData["messages"]);
    }

    [Fact]
    public async Task CompactBeforeNextTurn_FinalTurnWithUnrunToolCalls_SkipsAndWarns()
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(ToolUseTurn() with { StopReason = BetaStopReason.MaxTokens });
        var runner = WeatherRunner(script);

        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            await foreach (var _ in runner.WithCancellation(ct))
            {
                runner.CompactBeforeNextTurn();
            }
        });

        Assert.Single(script.Requests);
        Assert.Contains("the pending compaction was skipped", stderr);
        Assert.Contains("stop_reason: max_tokens", stderr);
        AssertJson(
            """[{"role":"user","content":"Hello"}]""",
            runner.Params.RawBodyData["messages"]
        );
    }

    [Fact]
    public async Task CompactBeforeNextTurn_AtMaxIterationsAfterAToolTurn_IsDropped()
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(ToolUseTurn());
        var runner = WeatherRunner(script, maxIterations: 1);

        await foreach (var _ in runner.WithCancellation(ct))
        {
            runner.CompactBeforeNextTurn();
        }

        Assert.Single(script.Requests);
    }

    // A compaction that fails to produce a summary comes back either as a block without
    // content or as an empty message with the summarization call's own stop reason.
    [Theory]
    [InlineData("""[{"type":"compaction","content":null}]""", BetaStopReason.Compaction)]
    [InlineData("[]", BetaStopReason.MaxTokens)]
    public async Task CompactionResponse_WithoutASummary_KeepsTheHistoryAndWarns(
        string contentJson,
        BetaStopReason stopReason
    )
    {
        var ct = TestContext.Current.CancellationToken;
        var content = JsonSerializer.Deserialize<List<BetaContentBlock>>(contentJson)!;
        var script = new Script(ToolUseTurn(), MakeMessage(content, stopReason), FinalTurn());
        var runner = WeatherRunner(script);

        var yielded = 0;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            await foreach (var _ in runner.WithCancellation(ct))
            {
                // The second call is made on the compaction response, so it is ignored: no retry
                // is sent.
                if (++yielded <= 2)
                {
                    runner.CompactBeforeNextTurn();
                }
            }
        });

        Assert.Equal(3, script.Requests.Count);
        Assert.True(
            JsonElement.DeepEquals(
                script.Requests[1].RawBodyData["messages"],
                script.Requests[2].RawBodyData["messages"]
            )
        );
        Assert.False(script.Requests[2].RawBodyData.ContainsKey("compaction"));
        Assert.Contains("compaction produced no summary", stderr);
    }

    [Theory]
    [InlineData(CompactionBlock, BetaStopReason.Compaction)]
    [InlineData("""{"type":"compaction","content":null}""", BetaStopReason.EndTurn)]
    public async Task RunUntilDoneAsync_AfterAFinalTurnCompaction_ReturnsTheSummaryOrTheFinalTurn(
        string compactionBlock,
        BetaStopReason expected
    )
    {
        var ct = TestContext.Current.CancellationToken;
        var responses = new Queue<BetaMessage>([FinalTurn(), CompactedResponse(compactionBlock)]);
        BetaToolRunner runner = null!;
        var mock = new Mock<IMessageService>();
        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
            {
                // Stands in for a caller that asks while the final turn is being produced.
                runner.CompactBeforeNextTurn();
                return responses.Dequeue();
            });
        runner = mock.Object.ToolRunner(BaseParams, []);

        var result = await runner.RunUntilDoneAsync(ct);

        Assert.Empty(responses);
        Assert.Equal(expected, result.StopReason!.Value());
    }

    [Fact]
    public async Task Messages_CannotBeChangedWhileCompacting()
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(ToolUseTurn(), CompactedResponse(), FinalTurn());
        var runner = WeatherRunner(script);

        await foreach (var message in runner.WithCancellation(ct))
        {
            if (message.StopReason == BetaStopReason.ToolUse)
            {
                runner.CompactBeforeNextTurn();
            }
            else if (message.StopReason == BetaStopReason.Compaction)
            {
                var fromPush = Assert.Throws<AnthropicException>(() =>
                    runner.PushMessages(
                        new BetaMessageParam { Content = "And in NYC?", Role = Role.User }
                    )
                );
                var fromSet = Assert.Throws<AnthropicException>(() =>
                    runner.SetParams(p => p with { Messages = [] })
                );
                Assert.Contains("while the conversation is being compacted", fromPush.Message);
                Assert.Equal(fromPush.Message, fromSet.Message);
                // Other params can still change, and the change is kept after the history is
                // replaced.
                runner.SetParams(p => p with { MaxTokens = 2048 });
            }
        }

        var after = script.Requests[2];
        AssertJson(CompactionBlockAlone, after.RawBodyData["messages"]);
        Assert.Equal(2048, after.MaxTokens);
    }

    [Fact]
    public async Task CompactionRequest_ThatFails_ClearsTheState()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new AnthropicIOException("connection reset", new()));
        var runner = mock.Object.ToolRunner(BaseParams, []);

        runner.CompactBeforeNextTurn();
        await Assert.ThrowsAsync<AnthropicIOException>(() => runner.RunUntilDoneAsync(ct));

        // Nothing is compacting any more, so the messages can change again.
        runner.PushMessages(new BetaMessageParam { Content = "And in NYC?", Role = Role.User });
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public void CompactionParam_IsRefusedOnAToolRunner()
    {
        var script = new Script(FinalTurn());
        var withCompaction = BaseParams with { Compaction = new() };

        var fromConstructor = Assert.Throws<AnthropicException>(() =>
            script.Service.ToolRunner(withCompaction, [])
        );
        var runner = WeatherRunner(script);
        var fromSetter = Assert.Throws<AnthropicException>(() => runner.SetParams(withCompaction));
        var fromMutator = Assert.Throws<AnthropicException>(() =>
            runner.SetParams(p => p with { Compaction = new() })
        );

        Assert.Contains("`compaction` param cannot be set on a tool runner", fromSetter.Message);
        Assert.Contains("`CompactBeforeNextTurn()`", fromSetter.Message);
        Assert.Equal(fromSetter.Message, fromConstructor.Message);
        Assert.Equal(fromSetter.Message, fromMutator.Message);
        Assert.Null(runner.Params.Compaction);
    }

    [Fact]
    public async Task CompactionEdit_IsRefusedWhereItIsIntroduced()
    {
        var ct = TestContext.Current.CancellationToken;
        var withCompactionEdit = ContextManagementWith(new BetaCompact20260112Edit());

        // The edit is there first: the call is refused.
        var script = new Script(CompactedResponse(), FinalTurn());
        var runner = WeatherRunner(
            script,
            BaseParams with
            {
                ContextManagement = withCompactionEdit,
            }
        );
        var fromCall = Assert.Throws<AnthropicException>(() => runner.CompactBeforeNextTurn());
        Assert.Contains("can't be combined with a compaction edit", fromCall.Message);

        // The compaction is pending first: adding the edit is refused, and nothing changes.
        runner = WeatherRunner(script);
        runner.CompactBeforeNextTurn();
        var whilePending = Assert.Throws<AnthropicException>(() =>
            runner.SetParams(p => p with { ContextManagement = withCompactionEdit })
        );
        Assert.Equal(fromCall.Message, whilePending.Message);
        Assert.Null(runner.Params.ContextManagement);

        await foreach (var message in runner.WithCancellation(ct))
        {
            if (message.StopReason == BetaStopReason.Compaction)
            {
                // The same goes while the compaction response is being handled.
                Assert.Throws<AnthropicException>(() =>
                    runner.SetParams(p => p with { ContextManagement = withCompactionEdit })
                );
            }
        }

        // With nothing pending the edit is the API's to judge.
        runner.SetParams(p => p with { ContextManagement = withCompactionEdit });
    }

    private static IAsyncEnumerable<BetaRawMessageStreamEvent> MessageStream(
        string stopReason,
        params string[] contentBlockEvents
    ) =>
        MakeEventStream(
            [
                """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                .. contentBlockEvents,
                $$$"""{"type":"message_delta","delta":{"stop_reason":"{{{stopReason}}}","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}""",
            ]
        );

    // The shared loop is covered above; this proves the streaming runner's aggregated message
    // goes back as it came too, with both blocks arriving whole on their start events.
    [Fact]
    public async Task Streaming_CompactionResponse_BecomesTheHistoryAsItCame()
    {
        var ct = TestContext.Current.CancellationToken;
        var script = new Script(
            MessageStream(
                "tool_use",
                """{"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"tu_1","name":"get_weather","input":{}}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"location\":\"SF\"}"}}""",
                """{"type":"content_block_stop","index":0}"""
            ),
            MessageStream(
                "compaction",
                $$"""{"type":"content_block_start","index":0,"content_block":{{CompactionBlock}}}""",
                """{"type":"content_block_stop","index":0}""",
                $$"""{"type":"content_block_start","index":1,"content_block":{{UnmodelledBlock}}}""",
                """{"type":"content_block_stop","index":1}"""
            ),
            MessageStream(
                "end_turn",
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Done."}}""",
                """{"type":"content_block_stop","index":0}"""
            )
        );
        var runner = WeatherRunner(script);

        var streams = 0;
        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
            if (++streams == 1)
            {
                runner.CompactBeforeNextTurn();
            }
        }

        Assert.Equal(3, script.Requests.Count);
        AssertJson("""{"type":"summarize"}""", script.Requests[1].RawBodyData["compaction"]);
        Assert.Equal("tool_result", LastBlockType(script.Requests[1]));
        AssertJson(
            $$"""[{"role":"assistant","content":[{{CompactionBlock}},{{UnmodelledBlock}}]}]""",
            script.Requests[2].RawBodyData["messages"]
        );
    }
}
