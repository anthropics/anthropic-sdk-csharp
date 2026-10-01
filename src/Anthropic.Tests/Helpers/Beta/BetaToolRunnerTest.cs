using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;
using Moq;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Helpers.Beta;

public class BetaToolRunnerTest
{
    private static readonly JsonSerializerOptions s_jsonOptions = new();

    internal static BetaMessage MakeMessage(
        IReadOnlyList<BetaContentBlock> content,
        BetaStopReason stopReason = BetaStopReason.EndTurn,
        BetaContainer? container = null
    )
    {
        return new()
        {
            ID = "msg_test",
            Content = content,
            Model = Messages::Model.ClaudeOpus4_6,
            StopDetails = null,
            StopReason = stopReason,
            StopSequence = null,
            Usage = new()
            {
                CacheCreation = null,
                CacheCreationInputTokens = null,
                CacheReadInputTokens = null,
                FallbackCredit = null,
                InputTokens = 10,
                OutputTokens = 10,
                OutputTokensDetails = new(0),
                ServerToolUse = null,
                ServiceTier = BetaUsageServiceTier.Standard,
                Speed = null,
                InferenceGeo = null,
                Iterations = null,
            },
            Container = container,
            ContextManagement = null,
            Diagnostics = null,
        };
    }

    internal static BetaContentBlock MakeTextBlock(string text)
    {
        var json = JsonSerializer.SerializeToElement(new { type = "text", text });
        return JsonSerializer.Deserialize<BetaContentBlock>(json, s_jsonOptions)!;
    }

    internal static BetaContentBlock MakeToolUseBlock(
        string id,
        string name,
        Dictionary<string, JsonElement> input
    )
    {
        var json = JsonSerializer.SerializeToElement(
            new
            {
                type = "tool_use",
                id,
                name,
                input,
            }
        );
        return JsonSerializer.Deserialize<BetaContentBlock>(json, s_jsonOptions)!;
    }

    private static BetaContentBlock MakeFallbackBlock()
    {
        var json = JsonSerializer.SerializeToElement(
            new
            {
                type = "fallback",
                from = new { model = "model-a" },
                to = new { model = "model-b" },
                trigger = new { type = "refusal", category = (string?)null },
            }
        );
        return JsonSerializer.Deserialize<BetaContentBlock>(json, s_jsonOptions)!;
    }

    private static BetaContentBlock MakeServerToolUseBlock(string id, string name, object input)
    {
        var json = JsonSerializer.SerializeToElement(
            new
            {
                type = "server_tool_use",
                id,
                name,
                input,
            }
        );
        return JsonSerializer.Deserialize<BetaContentBlock>(json, s_jsonOptions)!;
    }

    private static BetaContentBlock MakeCompactionBlock(string content)
    {
        var json = JsonSerializer.SerializeToElement(new { type = "compaction", content });
        return JsonSerializer.Deserialize<BetaContentBlock>(json, s_jsonOptions)!;
    }

    internal static MessageCreateParams BaseParams =>
        new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
        };

    private static BetaTool WeatherToolDefinition =>
        new()
        {
            Name = "get_weather",
            Description = "Get the weather for a location",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>
                {
                    ["location"] = JsonSerializer.SerializeToElement(
                        new { type = "string", description = "The city name" }
                    ),
                },
                Required = ["location"],
            },
        };

    private static BetaRunnableTool MakeWeatherTool(
        Func<BetaToolUseBlock, CancellationToken, Task<BetaToolResultBlockParamContent>> run
    ) =>
        new()
        {
            Name = "get_weather",
            Definition = WeatherToolDefinition,
            Run = run,
        };

    internal static BetaRunnableTool MakeWeatherToolSync(Func<BetaToolUseBlock, string> run) =>
        new()
        {
            Name = "get_weather",
            Definition = WeatherToolDefinition,
            Run = (block, _) => Task.FromResult<BetaToolResultBlockParamContent>(run(block)),
        };

    [Fact]
    public async Task NoToolUse_ReturnsSingleMessage()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var expected = MakeMessage([MakeTextBlock("Hello!")]);
        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        var runner = mock.Object.ToolRunner(BaseParams, []);
        var result = await runner.RunUntilDoneAsync(ct);

        Assert.Equal("msg_test", result.ID);
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async Task ToolUse_ExecutesToolAndContinues()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return MakeMessage(
                        [
                            MakeToolUseBlock(
                                "tu_1",
                                "get_weather",
                                new()
                                {
                                    ["location"] = JsonSerializer.SerializeToElement(
                                        "San Francisco"
                                    ),
                                }
                            ),
                        ],
                        BetaStopReason.ToolUse
                    );
                }
                return MakeMessage([MakeTextBlock("It's sunny in SF!")]);
            });

        var toolExecuted = false;
        var tool = MakeWeatherTool(
            (toolUse, _) =>
            {
                toolExecuted = true;
                var location = toolUse.Input["location"].GetString();
                return Task.FromResult<BetaToolResultBlockParamContent>(
                    $"Sunny, 72°F in {location}"
                );
            }
        );

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        var result = await runner.RunUntilDoneAsync(ct);

        Assert.True(toolExecuted);
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );
    }

    [Fact]
    public async Task ToolNotFound_ReturnsErrorResult()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeMessage(
                            [MakeToolUseBlock("tu_1", "nonexistent_tool", new())],
                            BetaStopReason.ToolUse
                        );
                    }
                    secondCallParams = p;
                    return MakeMessage([MakeTextBlock("I couldn't find that tool.")]);
                }
            );

        var runner = mock.Object.ToolRunner(BaseParams, []);
        await runner.RunUntilDoneAsync(ct);

        Assert.NotNull(secondCallParams);
        // messages: [original user, assistant with tool_use, user with tool_result]
        Assert.Equal(3, secondCallParams!.Messages.Count);
    }

    private static BetaMessageParam MakeSystemToolChangeMessage(BetaContentBlockParam block) =>
        new() { Role = Role.System, Content = new BetaMessageParamContent([block]) };

    private static BetaContentBlockParam MakeToolRemovalBlock(string name) =>
        new BetaRequestToolRemovalBlock(new BetaToolChangeToolReference(name));

    private static BetaContentBlockParam MakeToolAdditionBlock(string name) =>
        new BetaRequestToolAdditionBlock(new BetaToolChangeToolReference(name));

    /// <summary>
    /// Runs one tool round-trip and returns the tool_result the runner sent back.
    /// </summary>
    private static async Task<JsonElement> RunAndCaptureToolResult(
        MessageCreateParams parameters,
        IReadOnlyList<IBetaRunnableTool> tools,
        string toolName,
        CancellationToken ct
    )
    {
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeMessage(
                            [
                                MakeToolUseBlock(
                                    "tu_1",
                                    toolName,
                                    new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                                ),
                            ],
                            BetaStopReason.ToolUse
                        );
                    }
                    secondCallParams = p;
                    return MakeMessage([MakeTextBlock("Done")]);
                }
            );

        var runner = mock.Object.ToolRunner(parameters, tools);
        await runner.RunUntilDoneAsync(ct);

        Assert.NotNull(secondCallParams);
        var userMsg = secondCallParams!.Messages[secondCallParams.Messages.Count - 1];
        return Assert.Single(userMsg.Content.Json.EnumerateArray());
    }

    [Fact]
    public async Task ToolRemoval_TreatsRemovedToolAsNotFound()
    {
        var ct = TestContext.Current.CancellationToken;
        var toolExecuted = false;
        var tool = MakeWeatherToolSync(_ =>
        {
            toolExecuted = true;
            return "Sunny";
        });

        // Baseline: the model calls a tool that was never defined.
        var neverDefinedResult = await RunAndCaptureToolResult(BaseParams, [], "get_weather", ct);

        // A system message removes the tool before the assistant turn.
        var paramsWithRemoval = BaseParams with
        {
            Messages =
            [
                new() { Content = "Hello", Role = Role.User },
                MakeSystemToolChangeMessage(MakeToolRemovalBlock("get_weather")),
            ],
        };
        var removedResult = await RunAndCaptureToolResult(
            paramsWithRemoval,
            [tool],
            "get_weather",
            ct
        );

        Assert.False(toolExecuted);
        Assert.True(removedResult.GetProperty("is_error").GetBoolean());
        Assert.Equal(
            neverDefinedResult.GetProperty("content").GetString(),
            removedResult.GetProperty("content").GetString()
        );
        Assert.Equal(
            neverDefinedResult.GetProperty("is_error").GetBoolean(),
            removedResult.GetProperty("is_error").GetBoolean()
        );
    }

    [Fact]
    public async Task ToolRemoval_PushedDuringToolUseTurn_IsHonored()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return MakeMessage(
                        [
                            MakeToolUseBlock(
                                "tu_1",
                                "get_weather",
                                new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                            ),
                        ],
                        BetaStopReason.ToolUse
                    );
                }
                return MakeMessage([MakeTextBlock("Done")]);
            });

        var toolExecuted = false;
        var tool = MakeWeatherToolSync(_ =>
        {
            toolExecuted = true;
            return "Sunny";
        });

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);

        await foreach (var msg in runner.WithCancellation(ct))
        {
            if (callCount == 1)
            {
                // Remove the tool while the runner is yielding the tool_use turn — before it
                // executes the calls for the assistant message just returned.
                runner.PushMessages(
                    MakeSystemToolChangeMessage(MakeToolRemovalBlock("get_weather"))
                );
            }
        }

        // The removal is folded from the live params at dispatch, so the removed tool
        // never runs — its side effects don't fire only to have the results dropped.
        Assert.False(toolExecuted);
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );
    }

    [Fact]
    public async Task ToolAddition_AfterRemoval_ReenablesTool()
    {
        var ct = TestContext.Current.CancellationToken;
        var toolExecuted = false;
        var tool = MakeWeatherToolSync(_ =>
        {
            toolExecuted = true;
            return "Sunny";
        });

        var paramsWithReaddition = BaseParams with
        {
            Messages =
            [
                new() { Content = "Hello", Role = Role.User },
                MakeSystemToolChangeMessage(MakeToolRemovalBlock("get_weather")),
                MakeSystemToolChangeMessage(MakeToolAdditionBlock("get_weather")),
            ],
        };
        var result = await RunAndCaptureToolResult(paramsWithReaddition, [tool], "get_weather", ct);

        Assert.True(toolExecuted);
        Assert.Equal("Sunny", result.GetProperty("content").GetString());
    }

    // --- AddTools / RemoveTools ---

    /// <summary>
    /// A messages service that hands out the given turns in order and records each request.
    /// </summary>
    private sealed class ScriptedTurns
    {
        public List<MessageCreateParams> Requests { get; } = [];

        public IMessageService Service { get; }

        public ScriptedTurns(params BetaMessage[] turns)
        {
            var remaining = new Queue<BetaMessage>(turns);
            var mock = new Mock<IMessageService>();
            mock.Setup(s =>
                    s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
                )
                .ReturnsAsync(
                    (MessageCreateParams p, CancellationToken _) =>
                    {
                        Requests.Add(p);
                        return remaining.Dequeue();
                    }
                );
            Service = mock.Object;
        }

        public ScriptedTurns(params IAsyncEnumerable<BetaRawMessageStreamEvent>[] turns)
        {
            var remaining = new Queue<IAsyncEnumerable<BetaRawMessageStreamEvent>>(turns);
            var mock = new Mock<IMessageService>();
            mock.Setup(s =>
                    s.CreateStreaming(
                        It.IsAny<MessageCreateParams>(),
                        It.IsAny<CancellationToken>()
                    )
                )
                .Returns(
                    (MessageCreateParams p, CancellationToken _) =>
                    {
                        Requests.Add(p);
                        return remaining.Dequeue();
                    }
                );
            Service = mock.Object;
        }
    }

    private static BetaMessage MakeToolUseTurn(params string[] toolNames) =>
        MakeMessage(
            [.. toolNames.Select(name => MakeToolUseBlock($"tu_{name}", name, new()))],
            BetaStopReason.ToolUse
        );

    private static BetaMessage MakeFinalTurn() => MakeMessage([MakeTextBlock("Done")]);

    private static BetaTool TimeToolDefinition =>
        new()
        {
            Name = "get_time",
            Description = "Get the current time",
            InputSchema = new(),
        };

    private static BetaRunnableTool MakeRecordingTool(
        string name,
        BetaTool definition,
        List<string> calls,
        string? result = null
    ) =>
        new()
        {
            Name = name,
            Definition = definition,
            Run = (_, _) =>
            {
                calls.Add(result ?? name);
                return Task.FromResult<BetaToolResultBlockParamContent>(result ?? name);
            },
        };

    private static string ToolAdditionJson(BetaToolUnion definition) =>
        """{"type":"tool_addition","tool":{"type":"tool_definition","definition":"""
        + JsonSerializer.Serialize(definition, s_jsonOptions)
        + "}}";

    private static string ToolRemovalJson(string name) =>
        """{"type":"tool_removal","tool":{"type":"tool_reference","name":"""
        + JsonSerializer.Serialize(name)
        + "}}";

    private static string ToolChangesJson(params string[] blocks) =>
        """{"role":"system","content":[""" + string.Join(",", blocks) + "]}";

    private static List<JsonElement> SentMessages(MessageCreateParams request) =>
        [.. request.RawBodyData["messages"].EnumerateArray()];

    private static List<string?> SentRoles(MessageCreateParams request) =>
        [.. SentMessages(request).Select(m => m.GetProperty("role").GetString())];

    private static void AssertJson(string expectedJson, JsonElement actual)
    {
        using var expected = JsonDocument.Parse(expectedJson);
        Assert.True(
            JsonElement.DeepEquals(expected.RootElement, actual),
            $"Expected {expectedJson} but got {actual.GetRawText()}"
        );
    }

    /// <summary>
    /// Asserts that a request's last two messages are the results of the turn's tool calls,
    /// then <paramref name="expectedToolChangesJson"/>.
    /// </summary>
    private static List<JsonElement> AssertToolResultsThenToolChanges(
        MessageCreateParams request,
        string expectedToolChangesJson
    )
    {
        var messages = SentMessages(request);
        AssertJson(expectedToolChangesJson, messages[^1]);
        var toolResults = messages[^2];
        Assert.Equal("user", toolResults.GetProperty("role").GetString());
        return [.. toolResults.GetProperty("content").EnumerateArray()];
    }

    private static void AssertToolNotFound(JsonElement toolResult, string name)
    {
        Assert.True(toolResult.GetProperty("is_error").GetBoolean());
        Assert.Equal($"Tool '{name}' not found", toolResult.GetProperty("content").GetString());
    }

    private static void AssertToolsNeverChange(ScriptedTurns turns) =>
        Assert.Single(turns.Requests.Select(r => r.RawBodyData["tools"].GetRawText()).Distinct());

    [Fact]
    public async Task AddTools_RunsToolFromTheRequestCarryingItsDefinition()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(
            MakeToolUseTurn("get_weather"),
            MakeToolUseTurn("get_time"),
            MakeFinalTurn()
        );
        var calls = new List<string>();
        var runner = turns.Service.ToolRunner(
            BaseParams,
            [MakeRecordingTool("get_weather", WeatherToolDefinition, calls)]
        );

        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1)
            {
                runner.AddTools(MakeRecordingTool("get_time", TimeToolDefinition, calls));
            }
        }

        Assert.Equal(["get_weather", "get_time"], calls);
        AssertToolsNeverChange(turns);
        AssertToolResultsThenToolChanges(
            turns.Requests[1],
            ToolChangesJson(ToolAdditionJson(TimeToolDefinition))
        );
    }

    [Fact]
    public async Task ToolChanges_BeforeFirstRequest_FollowInitialMessagesWithoutBetaHeader()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(MakeFinalTurn());
        var runner = turns.Service.ToolRunner(BaseParams, []);

        runner.AddTools(MakeRecordingTool("get_time", TimeToolDefinition, []));
        await runner.RunUntilDoneAsync(ct);

        var request = Assert.Single(turns.Requests);
        Assert.Equal(["user", "system"], SentRoles(request));
        Assert.Null(request.Betas);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task RemoveTools_RefusesCallAlreadyInTurn(bool byName)
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(MakeToolUseTurn("get_weather"), MakeFinalTurn());
        var calls = new List<string>();
        var weatherTool = MakeRecordingTool("get_weather", WeatherToolDefinition, calls);
        var runner = turns.Service.ToolRunner(BaseParams, [weatherTool]);

        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1)
            {
                if (byName)
                {
                    runner.RemoveTools("get_weather");
                }
                else
                {
                    runner.RemoveTools(weatherTool);
                }
            }
        }

        Assert.Empty(calls);
        var toolResults = AssertToolResultsThenToolChanges(
            turns.Requests[1],
            ToolChangesJson(ToolRemovalJson("get_weather"))
        );
        AssertToolNotFound(Assert.Single(toolResults), "get_weather");
    }

    [Fact]
    public async Task RemoveTools_ToolStaysRemovedWhenRemovalLeavesHistory_UntilAddedAgain()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(
            MakeToolUseTurn("get_weather"),
            MakeToolUseTurn("get_weather"),
            MakeToolUseTurn("get_weather"),
            MakeFinalTurn()
        );
        var calls = new List<string>();
        var weatherTool = MakeRecordingTool("get_weather", WeatherToolDefinition, calls);
        var runner = turns.Service.ToolRunner(BaseParams, [weatherTool]);

        runner.RemoveTools(weatherTool);
        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1)
            {
                runner.SetParams(p =>
                    p with
                    {
                        Messages = [new() { Content = "Start over", Role = Role.User }],
                    }
                );
            }
            else if (turns.Requests.Count == 3)
            {
                runner.AddTools(weatherTool);
            }
        }

        Assert.Equal(["user"], SentRoles(turns.Requests[1]));
        AssertToolNotFound(
            Assert.Single(
                SentMessages(turns.Requests[2])[^1].GetProperty("content").EnumerateArray()
            ),
            "get_weather"
        );
        Assert.Equal(["get_weather"], calls);
    }

    [Fact]
    public async Task ToolChanges_InOneTurn_AreSentTogetherInCallOrder()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(
            MakeToolUseTurn("get_weather"),
            MakeToolUseTurn("get_time", "get_weather"),
            MakeFinalTurn()
        );
        var calls = new List<string>();
        var weatherTool = MakeRecordingTool("get_weather", WeatherToolDefinition, calls);
        var runner = turns.Service.ToolRunner(BaseParams, [weatherTool]);

        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1)
            {
                runner.AddTools(MakeRecordingTool("get_time", TimeToolDefinition, calls));
                runner.RemoveTools("get_time", "get_weather");
                runner.AddTools(weatherTool);
            }
        }

        // Adding then removing a name, or removing then adding it, is not collapsed.
        var firstResults = AssertToolResultsThenToolChanges(
            turns.Requests[1],
            ToolChangesJson(
                ToolAdditionJson(TimeToolDefinition),
                ToolRemovalJson("get_time"),
                ToolRemovalJson("get_weather"),
                ToolAdditionJson(WeatherToolDefinition)
            )
        );
        Assert.Equal("get_weather", Assert.Single(firstResults).GetProperty("content").GetString());

        Assert.Equal(["get_weather", "get_weather"], calls);
        var results = SentMessages(turns.Requests[2])[^1]
            .GetProperty("content")
            .EnumerateArray()
            .ToList();
        AssertToolNotFound(results[0], "get_time");
        Assert.Equal("get_weather", results[1].GetProperty("content").GetString());
    }

    [Fact]
    public async Task AddTools_ReplacesToolOfSameNameForCallAlreadyInTurn()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(
            MakeToolUseTurn("get_weather"),
            MakeToolUseTurn("get_weather"),
            MakeFinalTurn()
        );
        var calls = new List<string>();
        var runner = turns.Service.ToolRunner(
            BaseParams,
            [MakeRecordingTool("get_weather", WeatherToolDefinition, calls, "old")]
        );

        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1)
            {
                runner.AddTools(
                    MakeRecordingTool("get_weather", WeatherToolDefinition, calls, "new")
                );
            }
        }

        Assert.Equal(["new", "new"], calls);
    }

    [Fact]
    public async Task AddTools_AnswersCallAlreadyInTurnFromTheToolAddedUnderItsName()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(MakeToolUseTurn("get_weather"), MakeFinalTurn());
        var calls = new List<string>();
        var runner = turns.Service.ToolRunner(
            BaseParams,
            [MakeRecordingTool("get_weather", WeatherToolDefinition, calls, "old")]
        );
        var forecastDefinition = WeatherToolDefinition with { Description = "Get the forecast" };

        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1)
            {
                runner.AddTools(MakeRecordingTool("get_weather", forecastDefinition, calls, "new"));
            }
        }

        Assert.Equal(["new"], calls);
        var toolResults = AssertToolResultsThenToolChanges(
            turns.Requests[1],
            ToolChangesJson(ToolAdditionJson(forecastDefinition))
        );
        Assert.Equal("new", Assert.Single(toolResults).GetProperty("content").GetString());
    }

    [Fact]
    public async Task AddTools_RunsCallAlreadyInTurnToAToolTheHistoryRemoved()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(MakeToolUseTurn("get_weather"), MakeFinalTurn());
        var calls = new List<string>();
        var weatherTool = MakeRecordingTool("get_weather", WeatherToolDefinition, calls);
        var runner = turns.Service.ToolRunner(
            BaseParams with
            {
                Messages =
                [
                    .. BaseParams.Messages,
                    MakeSystemToolChangeMessage(MakeToolRemovalBlock("get_weather")),
                ],
            },
            [weatherTool]
        );

        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1)
            {
                runner.AddTools(weatherTool);
            }
        }

        Assert.Equal(["get_weather"], calls);
    }

    [Fact]
    public async Task AddTools_RawDefinitions_AreSentAsGivenAndNeverRun()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(MakeToolUseTurn("get_time"), MakeFinalTurn());
        var runner = turns.Service.ToolRunner(BaseParams, []);

        runner.AddTools(new BetaWebSearchTool20250305 { MaxUses = 3 }, TimeToolDefinition);
        await runner.RunUntilDoneAsync(ct);

        AssertJson(
            ToolChangesJson(
                """{"type":"tool_addition","tool":{"type":"tool_definition","definition":{"type":"web_search_20250305","name":"web_search","max_uses":3}}}""",
                ToolAdditionJson(TimeToolDefinition)
            ),
            SentMessages(turns.Requests[0])[1]
        );
        AssertToolNotFound(
            Assert.Single(
                SentMessages(turns.Requests[1])[^1].GetProperty("content").EnumerateArray()
            ),
            "get_time"
        );
    }

    [Fact]
    public async Task AddTools_RawDefinition_DropsRunnableToolOfSameName()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(
            MakeToolUseTurn("get_weather"),
            MakeToolUseTurn("get_weather"),
            MakeFinalTurn()
        );
        var calls = new List<string>();
        var runner = turns.Service.ToolRunner(
            BaseParams,
            [MakeRecordingTool("get_weather", WeatherToolDefinition, calls)]
        );

        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1)
            {
                runner.AddTools(WeatherToolDefinition);
            }
        }

        Assert.Empty(calls);
        AssertToolNotFound(
            Assert.Single(
                SentMessages(turns.Requests[2])[^1].GetProperty("content").EnumerateArray()
            ),
            "get_weather"
        );
    }

    [Fact]
    public async Task ToolChanges_WaitOnlyWhileAPausedTurnIsResumed()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(
            MakePausedTurn(),
            MakeMessage([MakeCompactionBlock("Summary so far.")], BetaStopReason.Compaction),
            MakeFinalTurn()
        );
        var runner = turns.Service.ToolRunner(BaseParams, []);

        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1)
            {
                runner.AddTools(TimeToolDefinition);
            }
        }

        Assert.Equal(["user", "assistant"], SentRoles(turns.Requests[1]));
        Assert.Equal(["user", "assistant", "assistant", "system"], SentRoles(turns.Requests[2]));
    }

    [Fact]
    public async Task ToolChanges_PendingWhenRunEnds_AreNeverSent()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(MakeFinalTurn());
        var runner = turns.Service.ToolRunner(BaseParams, [MakeWeatherToolSync(_ => "Sunny")]);

        await foreach (var _ in runner.WithCancellation(ct))
        {
            runner.AddTools(TimeToolDefinition);
            runner.RemoveTools("get_weather");
        }

        Assert.Equal(["user"], SentRoles(Assert.Single(turns.Requests)));
    }

    [Fact]
    public async Task ToolChanges_MadeByToolsRunningInParallel_AreAllSent()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(MakeToolUseTurn("first", "second"), MakeFinalTurn());
        using var bothRunning = new Barrier(2);
        BetaToolRunner runner = null!;
        BetaRunnableTool MakeTool(string name, Action change) =>
            new()
            {
                Name = name,
                Definition = TimeToolDefinition with { Name = name },
                Run = (_, _) =>
                    Task.Run<BetaToolResultBlockParamContent>(() =>
                    {
                        Assert.True(bothRunning.SignalAndWait(TimeSpan.FromSeconds(10), ct));
                        change();
                        return name;
                    }),
            };
        runner = turns.Service.ToolRunner(
            BaseParams,
            [
                MakeTool("first", () => runner.RemoveTools("second")),
                MakeTool("second", () => runner.AddTools(TimeToolDefinition)),
            ]
        );

        await runner.RunUntilDoneAsync(ct);

        var changes = SentMessages(turns.Requests[1])[^1];
        Assert.Equal("system", changes.GetProperty("role").GetString());
        Assert.Equal(
            ["tool_addition", "tool_removal"],
            changes
                .GetProperty("content")
                .EnumerateArray()
                .Select(block => block.GetProperty("type").GetString())
                .OrderBy(type => type)
        );
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task ToolChanges_AndACompactionOnOneTurn_GoOutInTheCompactionRequest(bool addFirst)
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(
            MakeToolUseTurn("get_weather"),
            MakeMessage([MakeCompactionBlock("Summary so far.")], BetaStopReason.Compaction),
            MakeToolUseTurn("get_time"),
            MakeFinalTurn()
        );
        var calls = new List<string>();
        var timeTool = MakeRecordingTool("get_time", TimeToolDefinition, calls);
        var runner = turns.Service.ToolRunner(
            BaseParams,
            [MakeRecordingTool("get_weather", WeatherToolDefinition, calls)]
        );

        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 1 && addFirst)
            {
                runner.AddTools(timeTool);
                runner.CompactBeforeNextTurn();
            }
            else if (turns.Requests.Count == 1)
            {
                runner.CompactBeforeNextTurn();
                runner.AddTools(timeTool);
            }
        }

        Assert.True(turns.Requests[1].RawBodyData.ContainsKey("compaction"));
        AssertToolResultsThenToolChanges(
            turns.Requests[1],
            ToolChangesJson(ToolAdditionJson(TimeToolDefinition))
        );
        Assert.Equal(["assistant"], SentRoles(turns.Requests[2]));
        Assert.Equal(["get_weather", "get_time"], calls);
    }

    [Fact]
    public async Task RemoveTools_BeforeACompaction_IsSentWithItAndHoldsUntilAddTools()
    {
        var ct = TestContext.Current.CancellationToken;
        var compaction = JsonSerializer.Deserialize<BetaContentBlock>(
            """{"type":"compaction","content":"Summary so far.","encrypted_content":null,"signature":"sig_01","tool_changes":[{"type":"tool_removal","tool":{"type":"tool_reference","name":"get_weather"}}]}""",
            s_jsonOptions
        )!;
        var turns = new ScriptedTurns(
            MakeMessage([compaction], BetaStopReason.Compaction),
            MakeToolUseTurn("get_weather"),
            MakeToolUseTurn("get_weather"),
            MakeFinalTurn()
        );
        var calls = new List<string>();
        var weatherTool = MakeRecordingTool("get_weather", WeatherToolDefinition, calls);
        var runner = turns.Service.ToolRunner(BaseParams, [weatherTool]);

        runner.RemoveTools(weatherTool);
        runner.CompactBeforeNextTurn();
        await foreach (var _ in runner.WithCancellation(ct))
        {
            if (turns.Requests.Count == 3)
            {
                runner.AddTools(weatherTool);
            }
        }

        Assert.True(turns.Requests[0].RawBodyData.ContainsKey("compaction"));
        Assert.Equal(["user", "system"], SentRoles(turns.Requests[0]));
        Assert.Equal(["assistant"], SentRoles(turns.Requests[1]));
        AssertToolNotFound(
            Assert.Single(
                SentMessages(turns.Requests[2])[^1].GetProperty("content").EnumerateArray()
            ),
            "get_weather"
        );
        Assert.Equal(["get_weather"], calls);
    }

    private static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeToolUseStream(string name) =>
        MakeEventStream(
            """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
            """{"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"tu_NAME","name":"NAME","input":{}}}""".Replace(
                "NAME",
                name
            ),
            """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{}"}}""",
            """{"type":"content_block_stop","index":0}""",
            """{"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":10}}""",
            """{"type":"message_stop"}"""
        );

    private static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeStream(
        string text,
        string stopReason
    ) =>
        MakeEventStream(
            """{"type":"message_start","message":{"id":"msg_2","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
            """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
            """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"TEXT"}}""".Replace(
                "TEXT",
                text
            ),
            """{"type":"content_block_stop","index":0}""",
            """{"type":"message_delta","delta":{"stop_reason":"STOP_REASON","stop_sequence":null},"usage":{"output_tokens":10}}""".Replace(
                "STOP_REASON",
                stopReason
            ),
            """{"type":"message_stop"}"""
        );

    [Fact]
    public async Task Streaming_ToolChanges_WaitForPausedTurnThenAreSentAfterToolResults()
    {
        var ct = TestContext.Current.CancellationToken;
        var turns = new ScriptedTurns(
            MakeStream("Let me look that up.", "pause_turn"),
            MakeToolUseStream("get_weather"),
            MakeToolUseStream("get_time"),
            MakeStream("Done", "end_turn")
        );
        var calls = new List<string>();
        var weatherTool = MakeRecordingTool("get_weather", WeatherToolDefinition, calls);
        var runner = turns.Service.ToolRunner(BaseParams, [weatherTool]);

        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
            if (turns.Requests.Count == 1)
            {
                runner.RemoveTools(weatherTool);
                runner.AddTools(MakeRecordingTool("get_time", TimeToolDefinition, calls));
            }
        }

        Assert.Equal(["get_time"], calls);
        AssertToolsNeverChange(turns);
        Assert.Equal(["user", "assistant"], SentRoles(turns.Requests[1]));
        var toolResults = AssertToolResultsThenToolChanges(
            turns.Requests[2],
            ToolChangesJson(ToolRemovalJson("get_weather"), ToolAdditionJson(TimeToolDefinition))
        );
        AssertToolNotFound(Assert.Single(toolResults), "get_weather");
    }

    [Fact]
    public async Task ToolException_ReturnsErrorResult()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return MakeMessage(
                        [
                            MakeToolUseBlock(
                                "tu_1",
                                "get_weather",
                                new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                            ),
                        ],
                        BetaStopReason.ToolUse
                    );
                }
                return MakeMessage([MakeTextBlock("Sorry about the error.")]);
            });

        var tool = MakeWeatherTool(
            (_, _) =>
                Task.FromException<BetaToolResultBlockParamContent>(
                    new InvalidOperationException("API is down")
                )
        );

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        var result = await runner.RunUntilDoneAsync(ct);

        // Should complete without throwing — the error is sent back to the model.
        Assert.NotNull(result);
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );
    }

    [Fact]
    public async Task MaxIterations_StopsLoop()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
                MakeMessage(
                    [
                        MakeToolUseBlock(
                            "tu_1",
                            "get_weather",
                            new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                        ),
                    ],
                    BetaStopReason.ToolUse
                )
            );

        var tool = MakeWeatherToolSync(_ => "Sunny");
        var runner = mock.Object.ToolRunner(BaseParams, [tool], maxIterations: 3);

        var messages = new List<BetaMessage>();
        await foreach (var msg in runner.WithCancellation(ct))
        {
            messages.Add(msg);
        }

        Assert.Equal(3, messages.Count);
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(3)
        );
    }

    [Fact]
    public async Task SingleConsumption_ThrowsOnSecondIteration()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(MakeMessage([MakeTextBlock("Hello")]));

        var runner = mock.Object.ToolRunner(BaseParams, []);
        await runner.RunUntilDoneAsync(ct);

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await foreach (var _ in runner.WithCancellation(ct)) { }
        });
    }

    [Fact]
    public async Task MultipleToolCalls_AllExecuted()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return MakeMessage(
                        [
                            MakeToolUseBlock(
                                "tu_1",
                                "get_weather",
                                new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                            ),
                            MakeToolUseBlock(
                                "tu_2",
                                "get_weather",
                                new() { ["location"] = JsonSerializer.SerializeToElement("NYC") }
                            ),
                        ],
                        BetaStopReason.ToolUse
                    );
                }
                return MakeMessage([MakeTextBlock("SF is sunny, NYC is cloudy.")]);
            });

        var executedLocations = new List<string>();
        var tool = MakeWeatherTool(
            (toolUse, _) =>
            {
                var location = toolUse.Input["location"].GetString()!;
                executedLocations.Add(location);
                return Task.FromResult<BetaToolResultBlockParamContent>($"Weather in {location}");
            }
        );

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        await runner.RunUntilDoneAsync(ct);

        Assert.Equal(2, executedLocations.Count);
        Assert.Contains("SF", executedLocations);
        Assert.Contains("NYC", executedLocations);
    }

    [Fact]
    public async Task PlainToolDefinitions_MergedWithRunnableTools()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        MessageCreateParams? capturedParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    capturedParams = p;
                    return MakeMessage([MakeTextBlock("Done")]);
                }
            );

        var plainTool = new BetaTool
        {
            Name = "web_search",
            Description = "Search the web",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>
                {
                    ["query"] = JsonSerializer.SerializeToElement(new { type = "string" }),
                },
            },
        };

        var runnableTool = MakeWeatherToolSync(_ => "Sunny");

        var paramsWithPlainTool = BaseParams with { Tools = [plainTool] };

        var runner = mock.Object.ToolRunner(paramsWithPlainTool, [runnableTool]);
        await runner.RunUntilDoneAsync(ct);

        Assert.NotNull(capturedParams);
        Assert.Equal(2, capturedParams!.Tools!.Count);
    }

    [Fact]
    public async Task InterfaceImplementation_Works()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return MakeMessage(
                        [
                            MakeToolUseBlock(
                                "tu_1",
                                "get_weather",
                                new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                            ),
                        ],
                        BetaStopReason.ToolUse
                    );
                }
                return MakeMessage([MakeTextBlock("Sunny!")]);
            });

        // Use a class that implements IBetaRunnableTool directly.
        var tool = new CustomWeatherTool();
        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        var result = await runner.RunUntilDoneAsync(ct);

        Assert.NotNull(result);
        Assert.True(tool.WasExecuted);
    }

    [Fact]
    public async Task CancellationToken_ForwardedToServiceAndTool()
    {
        using var cts = new CancellationTokenSource();
        var ct = cts.Token;

        var mock = new Mock<IMessageService>();
        CancellationToken capturedServiceToken = default;
        CancellationToken capturedToolToken = default;
        var callCount = 0;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams _, CancellationToken token) =>
                {
                    capturedServiceToken = token;
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeMessage(
                            [
                                MakeToolUseBlock(
                                    "tu_1",
                                    "get_weather",
                                    new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                                ),
                            ],
                            BetaStopReason.ToolUse
                        );
                    }
                    return MakeMessage([MakeTextBlock("Done")]);
                }
            );

        var tool = new BetaRunnableTool
        {
            Name = "get_weather",
            Definition = WeatherToolDefinition,
            Run = (_, token) =>
            {
                capturedToolToken = token;
                return Task.FromResult<BetaToolResultBlockParamContent>("Sunny");
            },
        };

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        await runner.RunUntilDoneAsync(ct);

        Assert.Equal(ct, capturedServiceToken);
        Assert.Equal(ct, capturedToolToken);
    }

    [Fact]
    public async Task Cancellation_DuringApiCall_Propagates()
    {
        using var cts = new CancellationTokenSource();
        var mock = new Mock<IMessageService>();

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .Returns(
                (MessageCreateParams _, CancellationToken ct) =>
                    Task.FromException<BetaMessage>(new OperationCanceledException(ct))
            );

        var runner = mock.Object.ToolRunner(BaseParams, []);

        await Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await runner.RunUntilDoneAsync(cts.Token);
        });
    }

    [Fact]
    public async Task Cancellation_DuringToolExecution_Propagates()
    {
        using var cts = new CancellationTokenSource();
        var mock = new Mock<IMessageService>();

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                MakeMessage(
                    [
                        MakeToolUseBlock(
                            "tu_1",
                            "get_weather",
                            new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                        ),
                    ],
                    BetaStopReason.ToolUse
                )
            );

        var tool = new BetaRunnableTool
        {
            Name = "get_weather",
            Definition = WeatherToolDefinition,
            Run = (_, ct) =>
            {
                cts.Cancel();
                ct.ThrowIfCancellationRequested();
                return Task.FromResult<BetaToolResultBlockParamContent>("unreachable");
            },
        };

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);

        await Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await runner.RunUntilDoneAsync(cts.Token);
        });
    }

    // --- Tier 2: Params mutation ---

    [Fact]
    public async Task SetParams_SkipsAutoAppend()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeMessage(
                            [
                                MakeToolUseBlock(
                                    "tu_1",
                                    "get_weather",
                                    new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                                ),
                            ],
                            BetaStopReason.ToolUse
                        );
                    }
                    secondCallParams = p;
                    return MakeMessage([MakeTextBlock("Done")]);
                }
            );

        var tool = MakeWeatherToolSync(_ => "Sunny");
        var runner = mock.Object.ToolRunner(BaseParams, [tool]);

        await foreach (var msg in runner.WithCancellation(ct))
        {
            if (callCount == 1)
            {
                // Mutate params — runner should skip auto-append
                runner.SetParams(p =>
                    p with
                    {
                        Messages = [new() { Content = "Custom history", Role = Role.User }],
                    }
                );
            }
        }

        Assert.NotNull(secondCallParams);
        // Should use our custom messages, not the auto-appended ones.
        Assert.Single(secondCallParams!.Messages);
    }

    [Fact]
    public async Task PushMessages_AppendsToHistory()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeMessage(
                            [
                                MakeToolUseBlock(
                                    "tu_1",
                                    "get_weather",
                                    new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                                ),
                            ],
                            BetaStopReason.ToolUse
                        );
                    }
                    secondCallParams = p;
                    return MakeMessage([MakeTextBlock("Done")]);
                }
            );

        var tool = MakeWeatherToolSync(_ => "Sunny");
        var runner = mock.Object.ToolRunner(BaseParams, [tool]);

        await foreach (var msg in runner.WithCancellation(ct))
        {
            if (callCount == 1)
            {
                // Push additional context — runner skips auto-append and uses
                // the updated messages from PushMessages.
                runner.PushMessages(
                    new BetaMessageParam { Content = "Extra context", Role = Role.User }
                );
            }
        }

        Assert.NotNull(secondCallParams);
        // Messages: original user + pushed message (auto-append skipped due to mutation)
        Assert.Equal(2, secondCallParams!.Messages.Count);
    }

    [Fact]
    public void Params_ExposesCurrentState()
    {
        var mock = new Mock<IMessageService>();
        var runner = mock.Object.ToolRunner(BaseParams, []);

        Assert.Equal(1024, runner.Params.MaxTokens);
    }

    // --- Tier 2: Helper header ---

    [Fact]
    public async Task HelperHeader_SentOnApiCalls()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        MessageCreateParams? capturedParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    capturedParams = p;
                    return MakeMessage([MakeTextBlock("Done")]);
                }
            );

        var runner = mock.Object.ToolRunner(BaseParams, []);
        await runner.RunUntilDoneAsync(ct);

        Assert.NotNull(capturedParams);
        Assert.True(capturedParams!.RawHeaderData.ContainsKey("x-stainless-helper"));
        Assert.Equal(
            "BetaToolRunner",
            capturedParams.RawHeaderData["x-stainless-helper"].GetString()
        );
    }

    // --- Tier 2: Streaming ---

    [Fact]
    public async Task Streaming_YieldsEventsAndAggregates()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();

        mock.Setup(s =>
                s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
            )
            .Returns(() =>
                MakeEventStream(
                    """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                    """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
                    """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Hello!"}}""",
                    """{"type":"content_block_stop","index":0}""",
                    """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}""",
                    """{"type":"message_stop"}"""
                )
            );

        var runner = mock.Object.ToolRunner(BaseParams, []);
        var eventCount = 0;

        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var evt in stream.WithCancellation(ct))
            {
                eventCount++;
            }
        }

        Assert.Equal(6, eventCount);
    }

    [Fact]
    public async Task Streaming_ToolLoop_ExecutesToolsAndContinues()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeToolUseStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":"tool_use","stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"tu_1","name":"get_weather","input":{}}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"location\":"}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"\"SF\"}"}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeTextStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_2","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"It's sunny!"}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        mock.Setup(s =>
                s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
            )
            .Returns(() =>
            {
                callCount++;
                return callCount == 1 ? MakeToolUseStream() : MakeTextStream();
            });

        var toolExecuted = false;
        var tool = new BetaRunnableTool
        {
            Name = "get_weather",
            Definition = WeatherToolDefinition,
            Run = (_, _) =>
            {
                toolExecuted = true;
                return Task.FromResult<BetaToolResultBlockParamContent>("Sunny");
            },
        };

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        var iterationCount = 0;

        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
            iterationCount++;
        }

        Assert.True(toolExecuted);
        Assert.Equal(2, iterationCount);
        mock.Verify(
            s => s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );
    }

    internal static async IAsyncEnumerable<BetaRawMessageStreamEvent> MakeEventStream(
        params string[] jsonEvents
    )
    {
        foreach (var json in jsonEvents)
        {
            yield return JsonSerializer.Deserialize<BetaRawMessageStreamEvent>(
                json,
                s_jsonOptions
            )!;
        }
        await Task.CompletedTask;
    }

    [Fact]
    public async Task Streaming_SingleConsumption_ThrowsOnSecondCall()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();

        mock.Setup(s =>
                s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
            )
            .Returns(() =>
                MakeEventStream(
                    """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                    """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
                    """{"type":"content_block_stop","index":0}""",
                    """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}""",
                    """{"type":"message_stop"}"""
                )
            );

        var runner = mock.Object.ToolRunner(BaseParams, []);

        // Consume the streaming runner.
        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
        }

        // Second call should throw.
        Assert.Throws<InvalidOperationException>(() => runner.Streaming(ct));
    }

    // --- Strong candidates: Parallel execution ---

    [Fact]
    public async Task ParallelExecution_ToolsRunConcurrently()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return MakeMessage(
                        [
                            MakeToolUseBlock(
                                "tu_1",
                                "get_weather",
                                new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                            ),
                            MakeToolUseBlock(
                                "tu_2",
                                "get_weather",
                                new() { ["location"] = JsonSerializer.SerializeToElement("NYC") }
                            ),
                        ],
                        BetaStopReason.ToolUse
                    );
                }
                return MakeMessage([MakeTextBlock("Done")]);
            });

        var concurrentCount = 0;
        var maxConcurrent = 0;
        var lockObj = new object();

        var tool = new BetaRunnableTool
        {
            Name = "get_weather",
            Definition = WeatherToolDefinition,
            Run = async (toolUse, _) =>
            {
                lock (lockObj)
                {
                    concurrentCount++;
                    if (concurrentCount > maxConcurrent)
                        maxConcurrent = concurrentCount;
                }

                // Simulate async work to allow parallelism.
                await Task.Delay(50, ct);

                lock (lockObj)
                {
                    concurrentCount--;
                }

                var location = toolUse.Input["location"].GetString();
                return (BetaToolResultBlockParamContent)$"Weather in {location}";
            },
        };

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        await runner.RunUntilDoneAsync(ct);

        // Both tools should have run concurrently.
        Assert.Equal(2, maxConcurrent);
    }

    [Fact]
    public async Task ParallelExecution_ResultOrderMatchesToolUseOrder()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeMessage(
                            [
                                MakeToolUseBlock(
                                    "tu_first",
                                    "get_weather",
                                    new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                                ),
                                MakeToolUseBlock(
                                    "tu_second",
                                    "get_weather",
                                    new()
                                    {
                                        ["location"] = JsonSerializer.SerializeToElement("NYC"),
                                    }
                                ),
                            ],
                            BetaStopReason.ToolUse
                        );
                    }
                    secondCallParams = p;
                    return MakeMessage([MakeTextBlock("Done")]);
                }
            );

        var tool = new BetaRunnableTool
        {
            Name = "get_weather",
            Definition = WeatherToolDefinition,
            Run = async (toolUse, _) =>
            {
                var location = toolUse.Input["location"].GetString()!;
                // Second tool finishes faster to verify ordering is preserved.
                if (location == "SF")
                    await Task.Delay(50, ct);
                return (BetaToolResultBlockParamContent)$"Weather in {location}";
            },
        };

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        await runner.RunUntilDoneAsync(ct);

        Assert.NotNull(secondCallParams);
        // The user message with tool results should be the last message.
        var userMsg = secondCallParams!.Messages[secondCallParams.Messages.Count - 1];
        var contentJson = userMsg.Content.Json;
        var results = new List<JsonElement>();
        foreach (var item in contentJson.EnumerateArray())
            results.Add(item);

        // First result should be for tu_first, second for tu_second.
        Assert.Equal("tu_first", results[0].GetProperty("tool_use_id").GetString());
        Assert.Equal("tu_second", results[1].GetProperty("tool_use_id").GetString());
    }

    // --- Strong candidates: ToolError ---

    [Fact]
    public async Task ToolError_UsesStructuredContent()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeMessage(
                            [
                                MakeToolUseBlock(
                                    "tu_1",
                                    "get_weather",
                                    new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                                ),
                            ],
                            BetaStopReason.ToolUse
                        );
                    }
                    secondCallParams = p;
                    return MakeMessage([MakeTextBlock("I see the error.")]);
                }
            );

        var tool = new BetaRunnableTool
        {
            Name = "get_weather",
            Definition = WeatherToolDefinition,
            Run = (_, _) =>
                throw new BetaToolError("Weather service is unavailable for this region"),
        };

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        await runner.RunUntilDoneAsync(ct);

        Assert.NotNull(secondCallParams);
        // Verify the error content was passed through (not just ex.Message).
        var userMsg = secondCallParams!.Messages[secondCallParams.Messages.Count - 1];
        var resultJsonEnumerator = userMsg.Content.Json.EnumerateArray();
        resultJsonEnumerator.MoveNext();
        var resultJson = resultJsonEnumerator.Current;
        Assert.True(resultJson.GetProperty("is_error").GetBoolean());
        Assert.Equal(
            "Weather service is unavailable for this region",
            resultJson.GetProperty("content").GetString()
        );
    }

    [Fact]
    public async Task ToolError_WithStructuredContent_PassesThrough()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return MakeMessage(
                        [
                            MakeToolUseBlock(
                                "tu_1",
                                "get_weather",
                                new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                            ),
                        ],
                        BetaStopReason.ToolUse
                    );
                }
                return MakeMessage([MakeTextBlock("Got it.")]);
            });

        // Use structured content (BetaToolResultBlockParamContent) in the error.
        var errorContent = new BetaToolResultBlockParamContent("Detailed error with context");
        var tool = new BetaRunnableTool
        {
            Name = "get_weather",
            Definition = WeatherToolDefinition,
            Run = (_, _) => throw new BetaToolError(errorContent),
        };

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        var result = await runner.RunUntilDoneAsync(ct);

        // Should complete without propagating — error sent to model.
        Assert.NotNull(result);
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );
    }

    // --- Refusal and fallback-seam handling ---

    [Fact]
    public async Task Refusal_EndsLoopWithoutExecutingTools()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                MakeMessage(
                    [
                        MakeToolUseBlock(
                            "tu_1",
                            "get_weather",
                            new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                        ),
                    ],
                    BetaStopReason.Refusal
                )
            );

        var toolExecuted = false;
        var tool = MakeWeatherToolSync(_ =>
        {
            toolExecuted = true;
            return "Sunny";
        });

        // maxIterations bounds the damage if refusal handling regresses — a runner that
        // retries a refusal here would otherwise loop forever against the mock.
        var runner = mock.Object.ToolRunner(BaseParams, [tool], maxIterations: 3);
        var result = await runner.RunUntilDoneAsync(ct);

        // A refusal-terminated turn is terminal: no tool execution, no follow-up request.
        Assert.False(toolExecuted);
        Assert.Equal(BetaStopReason.Refusal, result.StopReason!.Value());
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async Task FallbackSeam_OnlyPostSeamToolsExecuted()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeMessage(
                            [
                                MakeToolUseBlock(
                                    "tu_pre",
                                    "get_weather",
                                    new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                                ),
                                MakeFallbackBlock(),
                                MakeToolUseBlock(
                                    "tu_post",
                                    "get_weather",
                                    new()
                                    {
                                        ["location"] = JsonSerializer.SerializeToElement("NYC"),
                                    }
                                ),
                            ],
                            BetaStopReason.ToolUse
                        );
                    }
                    secondCallParams = p;
                    return MakeMessage([MakeTextBlock("Done")]);
                }
            );

        var executedIDs = new List<string>();
        var tool = MakeWeatherTool(
            (toolUse, _) =>
            {
                executedIDs.Add(toolUse.ID);
                return Task.FromResult<BetaToolResultBlockParamContent>("Sunny");
            }
        );

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        await runner.RunUntilDoneAsync(ct);

        // Only the post-seam call runs; the pre-seam call belongs to the refused attempt.
        var executedID = Assert.Single(executedIDs);
        Assert.Equal("tu_post", executedID);

        // The tool_result turn answers only the post-seam call; a pre-seam result would be
        // orphaned once the fallback handler trims the pre-seam tool_use from history.
        Assert.NotNull(secondCallParams);
        var userMsg = secondCallParams!.Messages[secondCallParams.Messages.Count - 1];
        var resultJson = Assert.Single(userMsg.Content.Json.EnumerateArray());
        Assert.Equal("tu_post", resultJson.GetProperty("tool_use_id").GetString());
    }

    [Fact]
    public async Task Streaming_Refusal_EndsLoopWithoutExecutingTools()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();

        mock.Setup(s =>
                s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
            )
            .Returns(() =>
                MakeEventStream(
                    """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                    """{"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"tu_1","name":"get_weather","input":{}}}""",
                    """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"location\":\"SF\"}"}}""",
                    """{"type":"content_block_stop","index":0}""",
                    """{"type":"message_delta","delta":{"stop_reason":"refusal","stop_sequence":null},"usage":{"output_tokens":10}}""",
                    """{"type":"message_stop"}"""
                )
            );

        var toolExecuted = false;
        var tool = MakeWeatherToolSync(_ =>
        {
            toolExecuted = true;
            return "Sunny";
        });

        // maxIterations bounds the damage if refusal handling regresses — a runner that
        // retries a refusal here would otherwise loop forever against the mock.
        var runner = mock.Object.ToolRunner(BaseParams, [tool], maxIterations: 3);
        var iterationCount = 0;

        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
            iterationCount++;
        }

        Assert.False(toolExecuted);
        Assert.Equal(1, iterationCount);
        mock.Verify(
            s => s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async Task Streaming_FallbackSeam_OnlyPostSeamToolsExecuted()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeSeamStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"tu_pre","name":"get_weather","input":{}}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"location\":\"SF\"}"}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"content_block_start","index":1,"content_block":{"type":"fallback","from":{"model":"model-a"},"to":{"model":"model-b"}}}""",
                """{"type":"content_block_stop","index":1}""",
                """{"type":"content_block_start","index":2,"content_block":{"type":"tool_use","id":"tu_post","name":"get_weather","input":{}}}""",
                """{"type":"content_block_delta","index":2,"delta":{"type":"input_json_delta","partial_json":"{\"location\":\"NYC\"}"}}""",
                """{"type":"content_block_stop","index":2}""",
                """{"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeTextStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_2","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Done"}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        mock.Setup(s =>
                s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
            )
            .Returns(() =>
            {
                callCount++;
                return callCount == 1 ? MakeSeamStream() : MakeTextStream();
            });

        var executedIDs = new List<string>();
        var tool = MakeWeatherTool(
            (toolUse, _) =>
            {
                executedIDs.Add(toolUse.ID);
                return Task.FromResult<BetaToolResultBlockParamContent>("Sunny");
            }
        );

        var runner = mock.Object.ToolRunner(BaseParams, [tool]);
        var iterationCount = 0;

        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
            iterationCount++;
        }

        var executedID = Assert.Single(executedIDs);
        Assert.Equal("tu_post", executedID);
        Assert.Equal(2, iterationCount);
        mock.Verify(
            s => s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );
    }

    private static BetaContainer ServerContainer =>
        new()
        {
            ID = "container_123",
            ExpiresAt = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
            Skills = null,
        };

    private static async Task<List<MessageCreateParams>> RunContainerLoopAsync(
        MessageCreateParams parameters,
        CancellationToken ct
    )
    {
        var mock = new Mock<IMessageService>();
        var captured = new List<MessageCreateParams>();
        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    captured.Add(p);
                    return captured.Count == 1
                        ? MakeMessage(
                            [MakeToolUseBlock("tu_1", "get_weather", new())],
                            BetaStopReason.ToolUse,
                            ServerContainer
                        )
                        : MakeMessage([MakeTextBlock("Done")]);
                }
            );

        var runner = mock.Object.ToolRunner(parameters, [MakeWeatherToolSync(_ => "Sunny")]);
        await runner.RunUntilDoneAsync(ct);
        return captured;
    }

    [Fact]
    public async Task Container_FromResponse_ReusedOnNextRequest()
    {
        var ct = TestContext.Current.CancellationToken;

        var captured = await RunContainerLoopAsync(BaseParams, ct);

        Assert.Equal(2, captured.Count);
        Assert.Null(captured[0].Container);
        Assert.Equal("container_123", captured[1].Container?.Value);
    }

    [Fact]
    public async Task Container_PinnedByCaller_NotReplaced()
    {
        var ct = TestContext.Current.CancellationToken;

        var captured = await RunContainerLoopAsync(
            BaseParams with
            {
                Container = "container_mine",
            },
            ct
        );

        Assert.Equal("container_mine", captured[1].Container?.Value);
    }

    [Fact]
    public async Task Container_PinnedParamsWithoutID_GetIDFilledIn()
    {
        var ct = TestContext.Current.CancellationToken;
        var skill = new BetaSkillParams { SkillID = "pdf", Type = BetaSkillParamsType.Anthropic };

        var captured = await RunContainerLoopAsync(
            BaseParams with
            {
                Container = new BetaContainerParams { Skills = [skill] },
            },
            ct
        );

        Assert.True(captured[1].Container!.TryPickBetaContainerParams(out var sent));
        Assert.Equal("container_123", sent.ID);
        Assert.Equal([skill], sent.Skills);
    }

    [Fact]
    public async Task Streaming_Container_FromResponse_ReusedOnNextRequest()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var captured = new List<MessageCreateParams>();

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeToolUseStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"tu_1","name":"get_weather","input":{}}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"location\":\"SF\"}"}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null,"container":{"id":"container_123","expires_at":"2026-01-01T00:00:00Z"}},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeTextStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_2","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Done"}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        mock.Setup(s =>
                s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
            )
            .Returns(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    captured.Add(p);
                    return captured.Count == 1 ? MakeToolUseStream() : MakeTextStream();
                }
            );

        var runner = mock.Object.ToolRunner(BaseParams, [MakeWeatherToolSync(_ => "Sunny")]);
        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
        }

        Assert.Equal(2, captured.Count);
        Assert.Null(captured[0].Container);
        Assert.Equal("container_123", captured[1].Container?.Value);
    }

    // --- stop_reason classification ---

    // Reaches the private classifier via reflection so every generated stop reason must
    // appear in the expected map below: a new enum member fails here until classified.
    [Fact]
    public void DetermineNextStepFromStopReason_CoversEveryStopReason()
    {
        var expected = new Dictionary<BetaStopReason, string>
        {
            [BetaStopReason.EndTurn] = "Stop",
            [BetaStopReason.MaxTokens] = "Stop",
            [BetaStopReason.StopSequence] = "Stop",
            [BetaStopReason.ToolUse] = "RunTools",
            [BetaStopReason.PauseTurn] = "Resume",
            [BetaStopReason.Compaction] = "Resume",
            [BetaStopReason.Refusal] = "Stop",
            [BetaStopReason.ModelContextWindowExceeded] = "Stop",
        };
        var determineNextStep = typeof(BetaToolRunner).GetMethod(
            "DetermineNextStepFromStopReason",
            BindingFlags.NonPublic | BindingFlags.Static
        );
        Assert.NotNull(determineNextStep);
        string NextStepFor(BetaMessage message) =>
            determineNextStep!.Invoke(null, [message])!.ToString()!;

        foreach (BetaStopReason reason in Enum.GetValues(typeof(BetaStopReason)))
        {
            Assert.True(expected.ContainsKey(reason), $"Unclassified stop reason: {reason}");
            Assert.Equal(expected[reason], NextStepFor(MakeMessage([], reason)));
        }

        // Values newer than this SDK and a missing stop reason stop the loop.
        Assert.Equal(
            "Stop",
            NextStepFor(MakeMessage([]) with { StopReason = "some_future_reason" })
        );
        Assert.Equal("Stop", NextStepFor(MakeMessage([]) with { StopReason = null }));
    }

    [Fact]
    public async Task MaxTokens_EndsLoopWithoutExecutingTools()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                MakeMessage(
                    [
                        MakeTextBlock("Checking the weather"),
                        MakeToolUseBlock(
                            "tu_1",
                            "get_weather",
                            new() { ["location"] = JsonSerializer.SerializeToElement("SF") }
                        ),
                    ],
                    BetaStopReason.MaxTokens
                )
            );

        var toolExecuted = false;
        var tool = MakeWeatherToolSync(_ =>
        {
            toolExecuted = true;
            throw new InvalidOperationException("tool must not run on a truncated turn");
        });

        var runner = mock.Object.ToolRunner(BaseParams, [tool], maxIterations: 3);
        var result = await runner.RunUntilDoneAsync(ct);

        // A max_tokens turn is final: its (possibly truncated) tool call is not executed and
        // no follow-up request is sent.
        Assert.False(toolExecuted);
        Assert.Equal(BetaStopReason.MaxTokens, result.StopReason!.Value());
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async Task Streaming_MaxTokens_EndsLoopWithoutExecutingTools()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();

        mock.Setup(s =>
                s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
            )
            .Returns(() =>
                MakeEventStream(
                    """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                    """{"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"tu_1","name":"get_weather","input":{}}}""",
                    """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"location\":\"SF\"}"}}""",
                    """{"type":"content_block_stop","index":0}""",
                    """{"type":"message_delta","delta":{"stop_reason":"max_tokens","stop_sequence":null},"usage":{"output_tokens":10}}""",
                    """{"type":"message_stop"}"""
                )
            );

        var toolExecuted = false;
        var tool = MakeWeatherToolSync(_ =>
        {
            toolExecuted = true;
            throw new InvalidOperationException("tool must not run on a truncated turn");
        });

        var runner = mock.Object.ToolRunner(BaseParams, [tool], maxIterations: 3);
        var iterationCount = 0;

        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
            iterationCount++;
        }

        Assert.False(toolExecuted);
        Assert.Equal(1, iterationCount);
        mock.Verify(
            s => s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    // --- pause_turn ---

    internal static BetaMessage MakePausedTurn() =>
        MakeMessage(
            [
                MakeTextBlock("Let me look that up."),
                MakeServerToolUseBlock("srvtoolu_1", "web_search", new { query = "weather in SF" }),
            ],
            BetaStopReason.PauseTurn
        );

    [Fact]
    public async Task PauseTurn_ResendsPausedTurnAndContinues()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakePausedTurn();
                    }
                    secondCallParams = p;
                    return MakeMessage([MakeTextBlock("It's sunny in SF!")]);
                }
            );

        var runner = mock.Object.ToolRunner(BaseParams, [MakeWeatherToolSync(_ => "Sunny")]);
        var result = await runner.RunUntilDoneAsync(ct);

        Assert.Equal(BetaStopReason.EndTurn, result.StopReason!.Value());
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );

        // The paused assistant turn is sent back unchanged (no tool_result turn) so the
        // server resumes it.
        Assert.NotNull(secondCallParams);
        Assert.Equal(2, secondCallParams!.Messages.Count);
        var appended = secondCallParams.Messages[1];
        Assert.Equal(Role.Assistant, appended.Role.Value());
        Assert.Equal(
            ["text", "server_tool_use"],
            appended.Content.Json.EnumerateArray().Select(b => b.GetProperty("type").GetString())
        );
    }

    [Fact]
    public async Task PauseTurn_StopsAtMaxIterations()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => MakePausedTurn());

        var runner = mock.Object.ToolRunner(BaseParams, [], maxIterations: 3);
        var result = await runner.RunUntilDoneAsync(ct);

        Assert.Equal(BetaStopReason.PauseTurn, result.StopReason!.Value());
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(3)
        );
    }

    [Fact]
    public async Task Streaming_PauseTurn_ResendsPausedTurnAndContinues()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakePausedStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Let me look that up."}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"content_block_start","index":1,"content_block":{"type":"server_tool_use","id":"srvtoolu_1","name":"web_search","input":{},"caller":{"type":"direct"}}}""",
                """{"type":"content_block_delta","index":1,"delta":{"type":"input_json_delta","partial_json":""}}""",
                """{"type":"content_block_delta","index":1,"delta":{"type":"input_json_delta","partial_json":"{\"query\": \"weath"}}""",
                """{"type":"content_block_delta","index":1,"delta":{"type":"input_json_delta","partial_json":"er in SF\"}"}}""",
                """{"type":"content_block_stop","index":1}""",
                """{"type":"message_delta","delta":{"stop_reason":"pause_turn","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeTextStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_2","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"It's sunny in SF!"}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        mock.Setup(s =>
                s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
            )
            .Returns(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakePausedStream();
                    }
                    secondCallParams = p;
                    return MakeTextStream();
                }
            );

        var runner = mock.Object.ToolRunner(BaseParams, [MakeWeatherToolSync(_ => "Sunny")]);
        var iterationCount = 0;

        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
            iterationCount++;
        }

        Assert.Equal(2, iterationCount);
        mock.Verify(
            s => s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );

        Assert.NotNull(secondCallParams);
        Assert.Equal(2, secondCallParams!.Messages.Count);
        var appended = secondCallParams.Messages[1];
        Assert.Equal(Role.Assistant, appended.Role.Value());
        var blocks = appended.Content.Json.EnumerateArray().ToList();
        Assert.Equal(
            ["text", "server_tool_use"],
            blocks.Select(b => b.GetProperty("type").GetString())
        );
        Assert.Equal("Let me look that up.", blocks[0].GetProperty("text").GetString());
        Assert.Equal(
            "weather in SF",
            blocks[1].GetProperty("input").GetProperty("query").GetString()
        );
    }

    // --- compaction ---

    [Fact]
    public async Task Compaction_ResendsCompactedTurnAndContinues()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeMessage(
                            [MakeCompactionBlock("Summary of the conversation so far.")],
                            BetaStopReason.Compaction
                        );
                    }
                    secondCallParams = p;
                    return MakeMessage([MakeTextBlock("It's sunny in SF!")]);
                }
            );

        var runner = mock.Object.ToolRunner(BaseParams, [MakeWeatherToolSync(_ => "Sunny")]);
        var result = await runner.RunUntilDoneAsync(ct);

        Assert.Equal(BetaStopReason.EndTurn, result.StopReason!.Value());
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );

        // The compaction turn is sent back unchanged as the last message — no tool_result
        // turn follows it — so the model answers on the next request.
        Assert.NotNull(secondCallParams);
        Assert.Equal(2, secondCallParams!.Messages.Count);
        var appended = secondCallParams.Messages[1];
        Assert.Equal(Role.Assistant, appended.Role.Value());
        var block = Assert.Single(appended.Content.Json.EnumerateArray());
        Assert.Equal("compaction", block.GetProperty("type").GetString());
        Assert.Equal(
            "Summary of the conversation so far.",
            block.GetProperty("content").GetString()
        );
    }

    [Fact]
    public async Task Streaming_Compaction_ResendsCompactedTurnAndContinues()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;
        MessageCreateParams? secondCallParams = null;
        const string ToolChanges =
            """[{"type":"tool_removal","tool":{"type":"tool_reference","name":"get_tides"}},{"type":"tool_addition","tool":{"type":"tool_definition","definition":{"name":"get_time","description":"Get the local time.","input_schema":{"type":"object","properties":{"zone":{"type":"string"},"city":{"type":"string"}},"required":["zone"]}}}}]""";

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeCompactionStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_1","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"compaction","content":null,"encrypted_content":null,"signature":"sig_01","tool_changes":"""
                    + ToolChanges
                    + "}}",
                """{"type":"content_block_delta","index":0,"delta":{"type":"compaction_delta","content":"Summary of the conversation so far.","encrypted_content":null}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"message_delta","delta":{"stop_reason":"compaction","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        static IAsyncEnumerable<BetaRawMessageStreamEvent> MakeTextStream()
        {
            return MakeEventStream(
                """{"type":"message_start","message":{"id":"msg_2","type":"message","role":"assistant","content":[],"model":"claude-opus-4-6-20250929","stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":10}}}""",
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}""",
                """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"It's sunny in SF!"}}""",
                """{"type":"content_block_stop","index":0}""",
                """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}""",
                """{"type":"message_stop"}"""
            );
        }

        mock.Setup(s =>
                s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
            )
            .Returns(
                (MessageCreateParams p, CancellationToken _) =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return MakeCompactionStream();
                    }
                    secondCallParams = p;
                    return MakeTextStream();
                }
            );

        var runner = mock.Object.ToolRunner(BaseParams, [MakeWeatherToolSync(_ => "Sunny")]);
        var iterationCount = 0;

        await foreach (var stream in runner.Streaming(ct).WithCancellation(ct))
        {
            await foreach (var _ in stream.WithCancellation(ct)) { }
            iterationCount++;
        }

        Assert.Equal(2, iterationCount);
        mock.Verify(
            s => s.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );

        Assert.NotNull(secondCallParams);
        Assert.Equal(2, secondCallParams!.Messages.Count);
        var appended = secondCallParams.Messages[1];
        Assert.Equal(Role.Assistant, appended.Role.Value());
        var block = Assert.Single(appended.Content.Json.EnumerateArray());
        Assert.Equal("compaction", block.GetProperty("type").GetString());
        Assert.Equal(
            "Summary of the conversation so far.",
            block.GetProperty("content").GetString()
        );
        // The block arrives whole on content_block_start; what the deltas don't carry is
        // sent back as it arrived.
        Assert.Equal("sig_01", block.GetProperty("signature").GetString());
        Assert.Equal(ToolChanges, block.GetProperty("tool_changes").GetRawText());
    }

    private class CustomWeatherTool : IBetaRunnableTool
    {
        public bool WasExecuted { get; private set; }

        public string Name => "get_weather";

        public BetaToolUnion Definition => WeatherToolDefinition;

        public Task<BetaToolResultBlockParamContent> ExecuteAsync(
            BetaToolUseBlock toolUseBlock,
            CancellationToken cancellationToken
        )
        {
            WasExecuted = true;
            var location = toolUseBlock.Input["location"].GetString();
            return Task.FromResult<BetaToolResultBlockParamContent>($"Sunny in {location}");
        }
    }
}
