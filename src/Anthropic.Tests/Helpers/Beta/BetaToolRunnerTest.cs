using System;
using System.Collections.Generic;
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

    private static BetaMessage MakeMessage(
        IReadOnlyList<BetaContentBlock> content,
        BetaStopReason stopReason = BetaStopReason.EndTurn
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
                InputTokens = 10,
                OutputTokens = 10,
                ServerToolUse = null,
                ServiceTier = BetaUsageServiceTier.Standard,
                Speed = null,
                InferenceGeo = null,
                Iterations = null,
            },
            Container = null,
            ContextManagement = null,
        };
    }

    private static BetaContentBlock MakeTextBlock(string text)
    {
        var json = JsonSerializer.SerializeToElement(new { type = "text", text });
        return JsonSerializer.Deserialize<BetaContentBlock>(json, s_jsonOptions)!;
    }

    private static BetaContentBlock MakeToolUseBlock(
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

    private static MessageCreateParams BaseParams =>
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

    private static BetaRunnableTool MakeWeatherToolSync(Func<BetaToolUseBlock, string> run) =>
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

        // The aggregator collects the message_stop event but doesn't yield it.
        Assert.Equal(5, eventCount);
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

    private static async IAsyncEnumerable<BetaRawMessageStreamEvent> MakeEventStream(
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
