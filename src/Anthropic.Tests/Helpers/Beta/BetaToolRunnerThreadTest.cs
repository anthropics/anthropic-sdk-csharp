using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Exceptions;
using Anthropic.Helpers;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta.Messages;
using static Anthropic.Tests.Helpers.Beta.MessageThreadTestSupport;

namespace Anthropic.Tests.Helpers.Beta;

// Shares the collection with the other tests that read stderr, where the runner's warnings go.
[Collection("console stderr")]
public class BetaToolRunnerThreadTest
{
    static MessageCreateParams Params() =>
        new()
        {
            Model = "claude-sonnet-4-5",
            MaxTokens = 1024,
            System = "Be brief.",
            Messages = [User("Weather?")],
        };

    static ThreadCreateParams ThreadParams() =>
        new()
        {
            Model = "claude-sonnet-4-5",
            MaxTokens = 1024,
            System = "Be brief.",
            Messages = [User("Weather?")],
        };

    static MessageCreateParams CompactionParams() =>
        Params() with
        {
            Betas = ["compact-2026-09-04"],
        };

    static BetaMessageThread CompactionThread(FakeTransport transport, BetaRunnableTool tool) =>
        Messages(transport)
            .Thread(
                ThreadParams() with
                {
                    Betas = ["compact-2026-09-04"],
                    Tools = [tool.Definition],
                }
            );

    sealed class Counter
    {
        public int Runs;
    }

    static BetaRunnableTool Tool(string name, Counter counter) =>
        new()
        {
            Name = name,
            Definition = new BetaTool
            {
                Name = name,
                InputSchema = new InputSchema(new Dictionary<string, JsonElement>()),
            },
            Run = (toolUse, _) =>
            {
                Interlocked.Increment(ref counter.Runs);
                return Task.FromResult<BetaToolResultBlockParamContent>($"ran {toolUse.ID}");
            },
        };

    static JsonObject Text(string text) => new() { ["type"] = "text", ["text"] = text };

    static JsonObject Call(string id, string name = "get_weather") =>
        new()
        {
            ["type"] = "tool_use",
            ["id"] = id,
            ["name"] = name,
            ["input"] = new JsonObject(),
        };

    static string Reply(string id, string stopReason, params JsonObject[] content) =>
        new JsonObject
        {
            ["id"] = id,
            ["type"] = "message",
            ["role"] = "assistant",
            ["model"] = "claude-sonnet-4-5",
            ["content"] = new JsonArray([.. content]),
            ["stop_reason"] = stopReason,
            ["stop_sequence"] = null,
            ["usage"] = new JsonObject { ["input_tokens"] = 1, ["output_tokens"] = 1 },
        }.ToJsonString();

    static string Final(string id) => Reply(id, "end_turn", Text("Sunny."));

    static string ToolUse(string id, params string[] calls) =>
        Reply(id, "tool_use", [.. calls.Select(call => Call(call))]);

    static string Summary(string id) =>
        Reply(
            id,
            "compaction",
            new JsonObject { ["type"] = "compaction", ["content"] = "Summary." }
        );

    static string ThreadError(string errorCode) =>
        new JsonObject
        {
            ["type"] = "error",
            ["error"] = new JsonObject
            {
                ["type"] = "invalid_request_error",
                ["message"] = "refused",
                ["details"] = new JsonObject { ["error_code"] = errorCode },
            },
        }.ToJsonString();

    static string Event(JsonObject data) =>
        $"event: {data["type"]!.GetValue<string>()}\ndata: {data.ToJsonString()}\n\n";

    static string Stream(string reply)
    {
        var message = JsonNode.Parse(reply)!.AsObject();
        var content = message["content"]!.AsArray();
        var start = JsonNode.Parse(reply)!.AsObject();
        start["content"] = new JsonArray();
        start["stop_reason"] = null;
        start["usage"]!.AsObject().Remove("iterations");
        var usage = new JsonObject { ["output_tokens"] = 2 };
        if (message["usage"]!["iterations"] is { } iterations)
        {
            usage["iterations"] = iterations.DeepClone();
        }
        var events = Event(new JsonObject { ["type"] = "message_start", ["message"] = start });
        for (var index = 0; index < content.Count; index++)
        {
            events += Event(
                new JsonObject
                {
                    ["type"] = "content_block_start",
                    ["index"] = index,
                    ["content_block"] = content[index]!.DeepClone(),
                }
            );
            events += Event(new JsonObject { ["type"] = "content_block_stop", ["index"] = index });
        }
        events += Event(
            new JsonObject
            {
                ["type"] = "message_delta",
                ["delta"] = new JsonObject
                {
                    ["stop_reason"] = message["stop_reason"]!.GetValue<string>(),
                    ["stop_sequence"] = null,
                },
                ["usage"] = usage,
            }
        );
        return events + Event(new JsonObject { ["type"] = "message_stop" });
    }

    /// <summary>One word per message: its role, or the ids its tool results answer.</summary>
    static string[] Shape(JsonNode messages) =>
        [
            .. messages
                .AsArray()
                .Select(message =>
                    message!["content"] is JsonArray blocks
                    && blocks.Any(block => block!["type"]!.GetValue<string>() == "tool_result")
                        ? string.Join(
                            "+",
                            blocks.Select(block => block!["tool_use_id"]!.GetValue<string>())
                        )
                        : message["role"]!.GetValue<string>()
                ),
        ];

    static string[] Shape(JsonObject request) => Shape(request["messages"]!);

    static string[] Shape(IEnumerable<BetaMessageParam> messages) =>
        Shape(JsonSerializer.SerializeToNode(messages.Select(message => message.Json))!);

    static string FirstBlockType(JsonObject request) =>
        request["messages"]![0]!["content"]![0]!["type"]!.GetValue<string>();

    static async Task<List<BetaMessage>> Run(BetaToolRunner runner)
    {
        var replies = new List<BetaMessage>();
        await foreach (var reply in runner.WithCancellation(TestContext.Current.CancellationToken))
        {
            replies.Add(reply);
        }
        return replies;
    }

    /// <summary>Runs to the end, and calls <paramref name="afterTurn"/> with the index of each turn.</summary>
    static async Task RunTurns(BetaToolRunner runner, bool streaming, Action<int>? afterTurn = null)
    {
        var index = 0;
        if (streaming)
        {
            await foreach (var turn in runner.Streaming(TestContext.Current.CancellationToken))
            {
                await foreach (var _ in turn) { }
                afterTurn?.Invoke(index++);
            }
            return;
        }

        await foreach (var _ in runner.WithCancellation(TestContext.Current.CancellationToken))
        {
            afterTurn?.Invoke(index++);
        }
    }

    /// <summary>Runs to the end, and calls <paramref name="act"/> once, after the turn at that index.</summary>
    static Task RunTurns(BetaToolRunner runner, bool streaming, int afterTurn, Action act) =>
        RunTurns(runner, streaming, Only(afterTurn, act));

    static Action<int> Only(int index, Action act) =>
        turn =>
        {
            if (turn == index)
            {
                act();
            }
        };

    /// <summary>Runs to the end, and calls <paramref name="afterTurn"/> with each reply but the final one.</summary>
    static async Task RunReplies(
        BetaToolRunner runner,
        bool streaming,
        Action<BetaMessage> afterTurn
    )
    {
        void AfterTurn(BetaMessage reply)
        {
            if (reply.StopReason?.Raw() != "end_turn")
            {
                afterTurn(reply);
            }
        }

        if (streaming)
        {
            await foreach (var turn in runner.Streaming(TestContext.Current.CancellationToken))
            {
                var aggregator = new BetaMessageContentAggregator();
                await foreach (var _ in aggregator.CollectAsync(turn)) { }
                AfterTurn(aggregator.Message());
            }
            return;
        }

        await foreach (var reply in runner.WithCancellation(TestContext.Current.CancellationToken))
        {
            AfterTurn(reply);
        }
    }

    /// <summary>A reply as a caller who manages the history sends it back.</summary>
    static BetaMessageParam Copy(BetaMessage reply) =>
        new BetaAssistantMessageParam
        {
            Content = new BetaMessageContentParam(
                JsonSerializer.SerializeToElement(
                    reply.Content.Select(block => block.Json).ToArray()
                )
            ),
        };

    /// <summary>The caller's own results for tool calls.</summary>
    static BetaMessageParam Mine(params string[] calls) =>
        new BetaUserMessageParam
        {
            Content = calls
                .Select(call =>
                    (BetaContentBlockParam)new BetaToolResultBlockParam(call) { Content = "mine" }
                )
                .ToList(),
        };

    static string[] Calls(BetaMessage reply) =>
        [
            .. reply
                .Content.Select(block => block.TryPickToolUse(out var call) ? call.ID : null)
                .OfType<string>(),
        ];

    static FakeTransport Replies(params string[] replies) => Replies(false, replies);

    static FakeTransport Replies(bool streaming, params string[] replies) =>
        EnqueueReplies(new FakeTransport(), streaming, replies);

    static FakeTransport EnqueueReplies(
        FakeTransport transport,
        bool streaming,
        params string[] replies
    )
    {
        foreach (var reply in replies)
        {
            _ = streaming ? transport.EnqueueSse(Stream(reply)) : transport.EnqueueJson(200, reply);
        }
        return transport;
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task RunnerThreadsByDefault(bool streaming)
    {
        var transport = Replies(streaming, ToolUse("msg_a", "toolu_1"), Final("msg_b"));
        var counter = new Counter();
        var runner = Messages(transport).ToolRunner(Params(), [Tool("get_weather", counter)]);

        await RunTurns(runner, streaming);

        Assert.Equal(1, counter.Runs);
        AssertCreate(transport.JsonBodies[0]);
        Assert.NotNull(transport.JsonBodies[0]["tools"]);
        var next = transport.JsonBodies[1];
        AssertContinue(next, "msg_a");
        Assert.Equal(["toolu_1"], Shape(next));
        Assert.False(next.ContainsKey("tools"));
        Assert.False(next.ContainsKey("system"));
        foreach (var index in new[] { 0, 1 })
        {
            Assert.Equal([ThreadsBeta], Betas(transport, index));
            Assert.Equal(["BetaToolRunner, message-thread"], transport.HelperHeaderValues(index));
        }
        Assert.Equal(["user"], Shape(runner.Params.Messages));
    }

    [Fact]
    public async Task ThreadFalseOptsOut()
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"), Final("msg_b"));
        var runner = Messages(transport)
            .ToolRunner(Params(), [Tool("get_weather", new Counter())], thread: false);

        await Run(runner);

        foreach (var index in new[] { 0, 1 })
        {
            Assert.False(transport.JsonBodies[index].ContainsKey("thread"));
            Assert.Empty(Betas(transport, index));
            Assert.NotNull(transport.JsonBodies[index]["tools"]);
            Assert.Equal(["BetaToolRunner"], transport.HelperHeaderValues(index));
        }
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(transport.JsonBodies[1]));
    }

    [Theory]
    [InlineData(true, "mine, BetaToolRunner, message-thread")]
    [InlineData(false, "mine, BetaToolRunner")]
    public async Task HelperTagsJoinTheCallers(bool thread, string expected)
    {
        var transport = Replies(Final("msg_a"));
        var parameters = MessageCreateParams.FromRawUnchecked(
            new Dictionary<string, JsonElement>
            {
                ["X-Stainless-Helper"] = JsonSerializer.SerializeToElement("mine"),
            },
            Params().RawQueryData,
            Params().RawBodyData
        );

        await Run(Messages(transport).ToolRunner(parameters, [], thread));

        Assert.Equal([expected], transport.HelperHeaderValues(0));
    }

    sealed class VertexClientOfTheCallers(Anthropic.Vertex.IAnthropicVertexCredentials credentials)
        : Anthropic.Vertex.AnthropicVertexClient(credentials) { }

    static AnthropicClient ClientWithoutThreads(string name, FakeTransport transport)
    {
        var http = new HttpClient(transport);
        var vertexCredentials = new Anthropic.Vertex.AnthropicVertexCredentials(
            "us-east5",
            "project",
            Google.Apis.Auth.OAuth2.GoogleCredential.FromAccessToken("token")
        );
        return name switch
        {
            "bedrock" => new Anthropic.Bedrock.AnthropicBedrockClient(
                new Anthropic.Bedrock.AnthropicBedrockApiTokenCredentials
                {
                    BearerToken = "token",
                    Region = "us-east-1",
                }
            )
            {
                HttpClient = http,
                MaxRetries = 0,
            },
            "mantle" => new Anthropic.Bedrock.AnthropicBedrockMantleClient(
                new() { ApiKey = "test-key", AwsRegion = "us-east-1" }
            )
            {
                HttpClient = http,
                MaxRetries = 0,
            },
            "vertex" => new Anthropic.Vertex.AnthropicVertexClient(vertexCredentials)
            {
                HttpClient = http,
                MaxRetries = 0,
            },
            _ => new VertexClientOfTheCallers(vertexCredentials)
            {
                HttpClient = http,
                MaxRetries = 0,
            },
        };
    }

    [Theory]
    [InlineData("bedrock")]
    [InlineData("mantle")]
    [InlineData("vertex")]
    [InlineData("derived from vertex")]
    public async Task RunnerNeverThreadsOnAClientWithoutThreads(string name)
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"), Final("msg_b"));
        var service = ClientWithoutThreads(name, transport).Beta.Messages;

        await Run(service.ToolRunner(Params(), [Tool("get_weather", new Counter())]));

        foreach (var index in new[] { 0, 1 })
        {
            Assert.False(transport.JsonBodies[index].ContainsKey("thread"));
            Assert.Empty(Betas(transport, index));
            Assert.DoesNotContain(ThreadsBeta, transport.RawBodies[index]);
            Assert.Equal(["BetaToolRunner"], transport.HelperHeaderValues(index));
        }
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(transport.JsonBodies[1]));
        Assert.Throws<NotSupportedException>(() => service.Thread(ThreadParams()));
    }

    [Fact]
    public async Task RunnerThreadsOnAMessageServiceOfTheCallers()
    {
        var replies = new Queue<string>([ToolUse("msg_a", "toolu_1"), Final("msg_b")]);
        var sent = new List<MessageCreateParams>();
        var service = new Moq.Mock<Anthropic.Services.Beta.IMessageService>();
        service
            .Setup(s =>
                s.Create(Moq.It.IsAny<MessageCreateParams>(), Moq.It.IsAny<CancellationToken>())
            )
            .Returns(
                (MessageCreateParams parameters, CancellationToken _) =>
                {
                    sent.Add(parameters);
                    return Task.FromResult(
                        JsonSerializer.Deserialize<BetaMessage>(
                            replies.Dequeue(),
                            Anthropic.Core.ModelBase.SerializerOptions
                        )!
                    );
                }
            );
        var counter = new Counter();
        var runner = service.Object.ToolRunner(Params(), [Tool("get_weather", counter)]);

        await Run(runner);

        Assert.Equal(1, counter.Runs);
        Assert.Equal(2, sent.Count);
        Assert.True(sent[0].Thread!.TryPickThreadCreateParams(out _));
        Assert.True(sent[1].Thread!.TryPickThreadContinueParams(out var continues));
        Assert.Equal("msg_a", continues.PreviousMessageID);
        Assert.Equal(["toolu_1"], Shape(sent[1].Messages));
        Assert.All(sent, parameters => Assert.Equal([ThreadsBeta], parameters.Betas!));
        Assert.NotNull(service.Object.Thread(ThreadParams()));
    }

    [Theory]
    [InlineData("create", true)]
    [InlineData("create", false)]
    [InlineData("continue", true)]
    [InlineData("continue", false)]
    public async Task ThreadOfTheCallersIsRefused(string type, bool thread)
    {
        const string Refusal =
            "`Thread` cannot be set on a tool runner. The runner sets it for each request itself. "
            + "To run without a message thread, pass `thread: false`.";
        var transport = Replies(ToolUse("msg_a", "toolu_1"));
        var counter = new Counter();
        IBetaRunnableTool[] tools = [Tool("get_weather", counter)];

        var error = Assert.Throws<ArgumentException>(() =>
            Messages(transport).ToolRunner(WithThread(Params(), type), tools, thread)
        );

        Assert.StartsWith(Refusal, error.Message);
        Assert.Equal(0, transport.RequestCount);

        var runner = Messages(transport).ToolRunner(Params(), tools, thread);
        error = await Assert.ThrowsAsync<ArgumentException>(() =>
            RunTurns(runner, false, _ => runner.SetParams(current => WithThread(current, type)))
        );

        Assert.StartsWith(Refusal, error.Message);
        Assert.Equal(1, transport.RequestCount);
        Assert.Equal(0, counter.Runs);
    }

    [Fact]
    public async Task UnsupportedRequestContinuesUnthreaded()
    {
        var transport = new FakeTransport().EnqueueJson(
            400,
            ThreadError("thread_unsupported_request")
        );
        EnqueueReplies(transport, false, ToolUse("msg_a", "toolu_1"), Final("msg_b"));

        await Run(Messages(transport).ToolRunner(Params(), [Tool("get_weather", new Counter())]));

        AssertCreate(transport.JsonBodies[0]);
        foreach (var index in new[] { 1, 2 })
        {
            Assert.False(transport.JsonBodies[index].ContainsKey("thread"));
            Assert.Empty(Betas(transport, index));
            Assert.NotNull(transport.JsonBodies[index]["tools"]);
            Assert.Equal(["BetaToolRunner, message-thread"], transport.HelperHeaderValues(index));
        }
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(transport.JsonBodies[2]));
    }

    [Fact]
    public async Task ThreadGoneMidLoopReplaysUnderCreate()
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, Final("msg_b"));
        var counter = new Counter();

        var replies = await Run(
            Messages(transport).ToolRunner(Params(), [Tool("get_weather", counter)])
        );

        Assert.Equal(["msg_a", "msg_b"], replies.Select(reply => reply.ID));
        Assert.Equal(1, counter.Runs);
        AssertContinue(transport.JsonBodies[1], "msg_a");
        AssertCreate(transport.JsonBodies[2]);
        Assert.NotNull(transport.JsonBodies[2]["tools"]);
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(transport.JsonBodies[2]));
    }

    [Fact]
    public async Task ThreadGoneAgainRightAfterAReplayContinuesUnthreaded()
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, ToolUse("msg_b", "toolu_2"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, ToolUse("msg_c", "toolu_3"))
            .EnqueueJson(200, Final("msg_d"));
        var counter = new Counter();

        var replies = await Run(
            Messages(transport).ToolRunner(Params(), [Tool("get_weather", counter)])
        );

        Assert.Equal(["msg_a", "msg_b", "msg_c", "msg_d"], replies.Select(reply => reply.ID));
        Assert.Equal(3, counter.Runs);
        AssertCreate(transport.JsonBodies[2]);
        AssertContinue(transport.JsonBodies[3], "msg_b");
        Assert.False(transport.JsonBodies[4].ContainsKey("thread"));
        Assert.Equal(
            ["user", "assistant", "toolu_1", "assistant", "toolu_2"],
            Shape(transport.JsonBodies[4])
        );
        Assert.NotNull(transport.JsonBodies[4]["tools"]);
        Assert.False(transport.JsonBodies[5].ContainsKey("thread"));
        Assert.Equal(7, transport.JsonBodies[5]["messages"]!.AsArray().Count);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task PausedTurnResumesWithNoMessages(bool streaming)
    {
        var transport = Replies(
            streaming,
            Reply("msg_a", "pause_turn", Text("Working")),
            Final("msg_b")
        );

        await RunTurns(Messages(transport).ToolRunner(Params(), []), streaming);

        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Empty(Shape(transport.JsonBodies[1]));
    }

    static string Paused(string id) => Reply(id, "pause_turn", Text("Working"));

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MessageAppendedWhileATurnIsPausedGoesOutWhenTheTurnResumes(bool streaming)
    {
        var transport = Replies(streaming, Paused("msg_a"), Final("msg_b"));
        var thread = Messages(transport).Thread(ThreadParams());
        var runner = thread.ToolRunner([]);

        await RunTurns(runner, streaming, afterTurn: 0, () => thread.Append(User("Briefly.")));

        Assert.Equal(2, transport.RequestCount);
        AssertContinues(transport.JsonBodies[1], "msg_a", Said("Briefly."));
        Assert.Equal(["user", "assistant", "user", "assistant"], Shape(thread.Messages));
        Assert.Equal(["user"], Shape(runner.Params.Messages));
    }

    [Fact]
    public async Task HistoryReplacedWhileATurnIsPausedStartsANewThreadWithAllOfIt()
    {
        var transport = Replies(Paused("msg_a"), Final("msg_b"));
        var runner = Messages(transport).ToolRunner(Params(), []);

        await RunTurns(
            runner,
            false,
            afterTurn: 0,
            () => runner.SetParams(current => current with { Messages = [User("Rewritten")] })
        );

        AssertCreate(transport.JsonBodies[1]);
        AssertMessages(transport.JsonBodies[1]["messages"]!, Said("Rewritten"));
    }

    [Fact]
    public async Task MessageAppendedWhileATurnIsPausedGoesOutWithTheHistoryWithoutAThread()
    {
        var transport = new FakeTransport().EnqueueJson(
            400,
            ThreadError("thread_unsupported_request")
        );
        EnqueueReplies(transport, false, Paused("msg_a"), Final("msg_b"));
        var thread = Messages(transport)
            .Thread(
                ThreadParams() with
                {
                    UnsupportedRequestBehavior = BetaUnsupportedRequestBehavior.ContinueUnthreaded,
                }
            );

        await RunTurns(
            thread.ToolRunner([]),
            false,
            afterTurn: 0,
            () => thread.Append(User("Briefly."))
        );

        Assert.False(transport.JsonBodies[2].ContainsKey("thread"));
        Assert.Equal(["user", "assistant", "user"], Shape(transport.JsonBodies[2]));
    }

    static string InContainer(string reply, string id)
    {
        var message = JsonNode.Parse(reply)!.AsObject();
        message["container"] = new JsonObject
        {
            ["id"] = id,
            ["expires_at"] = "2030-01-01T00:00:00Z",
        };
        return message.ToJsonString();
    }

    [Fact]
    public async Task ContainerOfTheReplyIsSentOnLaterTurns()
    {
        var transport = Replies(
            InContainer(ToolUse("msg_a", "toolu_1"), "container_a"),
            Final("msg_b")
        );

        await Run(Messages(transport).ToolRunner(Params(), [Tool("get_weather", new Counter())]));

        Assert.False(transport.JsonBodies[0].ContainsKey("container"));
        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal("container_a", transport.JsonBodies[1]["container"]!.GetValue<string>());
    }

    [Theory]
    [InlineData(false, null, "container_a")]
    [InlineData(true, null, "container_a")]
    [InlineData(false, "container_mine", "container_mine")]
    [InlineData(true, "container_mine", "container_mine")]
    public async Task WithoutAThreadTheContainerOfTheReplyIsSentUnlessTheCallerNamedOne(
        bool streaming,
        string? named,
        string expected
    )
    {
        var transport = Replies(
            streaming,
            InContainer(ToolUse("msg_a", "toolu_1"), "container_a"),
            Final("msg_b")
        );
        var parameters = named == null ? Params() : Params() with { Container = named };
        var runner = Messages(transport)
            .ToolRunner(parameters, [Tool("get_weather", new Counter())], thread: false);

        await RunTurns(runner, streaming);

        Assert.Equal(expected, transport.JsonBodies[1]["container"]!.GetValue<string>());
    }

    [Fact]
    public async Task ToolChangeTravelsInTheContinueAndStaysWithItsRunner()
    {
        var transport = Replies(
            ToolUse("msg_a", "toolu_1"),
            Final("msg_b"),
            Reply("msg_c", "tool_use", Call("toolu_2", "get_time")),
            Final("msg_d")
        );
        var weather = Tool("get_weather", new Counter());
        var timeRuns = new Counter();
        var thread = Messages(transport)
            .Thread(ThreadParams() with { Tools = [weather.Definition] });
        var runner = thread.ToolRunner([weather]);

        await RunTurns(
            runner,
            false,
            afterTurn: 0,
            () => runner.AddTools(Tool("get_time", timeRuns))
        );
        thread.Append(User("Time?"));
        await Run(thread.ToolRunner([weather]));

        var next = transport.JsonBodies[1];
        AssertContinue(next, "msg_a");
        Assert.Equal(["toolu_1", "system"], Shape(next));
        Assert.False(next.ContainsKey("tools"));
        Assert.Equal(0, timeRuns.Runs);
        Assert.Single(thread.Params.Tools!);
    }

    static string Said(string text) => $$"""{"role":"user","content":"{{text}}"}""";

    static string Result(string id) =>
        $$"""{"role":"user","content":[{"type":"tool_result","tool_use_id":"{{id}}","content":"ran {{id}}"}]}""";

    static string NotFound(string id, string name) =>
        $$"""{"role":"user","content":[{"type":"tool_result","tool_use_id":"{{id}}","content":"Tool '{{name}}' not found","is_error":true}]}""";

    static string Addition(string name) =>
        """{"role":"system","content":[{"type":"tool_addition","tool":{"type":"tool_definition","definition":{"name":"NAME","input_schema":{"type":"object"}}}}]}""".Replace(
            "NAME",
            name
        );

    static string Removal(string name) =>
        """{"role":"system","content":[{"type":"tool_removal","tool":{"type":"tool_reference","name":"NAME"}}]}""".Replace(
            "NAME",
            name
        );

    static void AssertMessages(JsonNode actual, params string[] expected) =>
        Assert.True(
            JsonNode.DeepEquals(JsonNode.Parse($"[{string.Join(",", expected)}]"), actual),
            actual.ToJsonString()
        );

    /// <summary>Asserts a continue from that reply, with exactly these messages and no tools.</summary>
    static void AssertContinues(
        JsonObject request,
        string previousMessageID,
        params string[] messages
    )
    {
        AssertContinue(request, previousMessageID);
        Assert.False(request.ContainsKey("tools"));
        AssertMessages(request["messages"]!, messages);
    }

    /// <summary>Calls to <c>get_weather</c>, <c>lookup</c> and <c>get_weather</c>, then the end.</summary>
    static string[] RepliesToChangingTools =>
        [
            ToolUse("msg_a", "toolu_1"),
            Reply("msg_b", "tool_use", Call("toolu_2", "lookup")),
            ToolUse("msg_c", "toolu_3"),
            Final("msg_d"),
        ];

    /// <summary>
    /// Runs to the end. Adds <c>lookup</c> after the first turn and removes <c>get_weather</c>
    /// after the second.
    /// </summary>
    static Task RunChangingTools(BetaToolRunner runner, bool streaming, Counter lookupRuns) =>
        RunTurns(
            runner,
            streaming,
            turn =>
            {
                if (turn == 0)
                {
                    runner.AddTools(Tool("lookup", lookupRuns));
                }
                else if (turn == 1)
                {
                    runner.RemoveTools("get_weather");
                }
            }
        );

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task AddedAndRemovedToolsTravelInTheContinuesOfTheRunnersOwnThread(bool streaming)
    {
        var transport = Replies(streaming, RepliesToChangingTools);
        var weatherRuns = new Counter();
        var lookupRuns = new Counter();
        var runner = Messages(transport).ToolRunner(Params(), [Tool("get_weather", weatherRuns)]);

        await RunChangingTools(runner, streaming, lookupRuns);

        Assert.Equal(4, transport.RequestCount);
        Assert.Equal(1, weatherRuns.Runs);
        Assert.Equal(1, lookupRuns.Runs);
        var create = transport.JsonBodies[0];
        AssertCreate(create);
        AssertMessages(create["messages"]!, Said("Weather?"));
        Assert.Equal(
            "get_weather",
            Assert.Single(create["tools"]!.AsArray())!["name"]!.GetValue<string>()
        );
        AssertContinues(transport.JsonBodies[1], "msg_a", Result("toolu_1"), Addition("lookup"));
        AssertContinues(
            transport.JsonBodies[2],
            "msg_b",
            Result("toolu_2"),
            Removal("get_weather")
        );
        AssertContinues(transport.JsonBodies[3], "msg_c", NotFound("toolu_3", "get_weather"));
    }

    [Fact]
    public async Task AddedAndRemovedToolsStayInTheHistoryOfAThreadThatGoesOn()
    {
        var transport = Replies([Final("msg_0"), .. RepliesToChangingTools, Final("msg_e")]);
        var weather = Tool("get_weather", new Counter());
        var lookupRuns = new Counter();
        var thread = Messages(transport)
            .Thread(ThreadParams() with { Messages = [], Tools = [weather.Definition] });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        thread.Append(User("Weather?"));

        await RunChangingTools(thread.ToolRunner([weather]), false, lookupRuns);
        await thread.Send(User("Thanks"), TestContext.Current.CancellationToken);

        Assert.Equal(6, transport.RequestCount);
        Assert.Equal(1, lookupRuns.Runs);
        AssertCreate(transport.JsonBodies[0]);
        AssertContinues(transport.JsonBodies[1], "msg_0", Said("Weather?"));
        AssertContinues(transport.JsonBodies[2], "msg_a", Result("toolu_1"), Addition("lookup"));
        AssertContinues(
            transport.JsonBodies[3],
            "msg_b",
            Result("toolu_2"),
            Removal("get_weather")
        );
        AssertContinues(transport.JsonBodies[4], "msg_c", NotFound("toolu_3", "get_weather"));
        AssertContinues(transport.JsonBodies[5], "msg_d", Said("Thanks"));
        AssertMessages(
            JsonSerializer.SerializeToNode(
                thread
                    .Messages.Where(message => message.Role.Raw() == "system")
                    .Select(message => message.Json)
            )!,
            Addition("lookup"),
            Removal("get_weather")
        );
        Assert.Single(thread.Params.Tools!);
    }

    [Fact]
    public async Task AppendedMessagesKeepTheThreadAndFollowTheToolResults()
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"), Final("msg_b"));
        var tool = Tool("get_weather", new Counter());
        var thread = Messages(transport).Thread(ThreadParams() with { Tools = [tool.Definition] });

        await RunTurns(
            thread.ToolRunner([tool]),
            false,
            afterTurn: 0,
            () =>
            {
                thread.Append(User("In one word."));
                thread.Append(User("Please."));
            }
        );

        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal(["toolu_1", "user", "user"], Shape(transport.JsonBodies[1]));
    }

    [Theory]
    [InlineData("Weather?", "continue", new[] { "toolu_1", "user" })]
    [InlineData("Weather in Paris?", "create", new[] { "user", "assistant", "toolu_1", "user" })]
    public async Task HistoryThatBeginsWithTheOldOneKeepsTheThreadAndAnyOtherStartsANewOne(
        string question,
        string thread,
        string[] sent
    )
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"), Final("msg_b"));
        var runner = Messages(transport).ToolRunner(Params(), [Tool("get_weather", new Counter())]);

        await RunReplies(
            runner,
            false,
            reply =>
                runner.SetParams(current =>
                    current with
                    {
                        Messages =
                        [
                            User(question),
                            Copy(reply),
                            Mine("toolu_1"),
                            User("In one word."),
                        ],
                    }
                )
        );

        var next = transport.JsonBodies[1];
        Assert.Equal(thread, next["thread"]!["type"]!.GetValue<string>());
        Assert.Equal(sent, Shape(next));
        Assert.Equal(thread == "create", next.ContainsKey("tools"));
    }

    [Fact]
    public async Task SetParamsReplacesTheFieldsAndKeepsTheThread()
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"), Final("msg_b"));
        var runner = Messages(transport)
            .ToolRunner(
                Params() with
                {
                    StopSequences = ["END"],
                },
                [Tool("get_weather", new Counter())]
            );

        await RunReplies(
            runner,
            false,
            reply =>
                runner.SetParams(
                    Params() with
                    {
                        MaxTokens = 2048,
                        Messages = [.. runner.Params.Messages, Copy(reply), Mine("toolu_1")],
                    }
                )
        );

        Assert.NotNull(transport.JsonBodies[0]["stop_sequences"]);
        var next = transport.JsonBodies[1];
        AssertContinue(next, "msg_a");
        Assert.Equal(["toolu_1"], Shape(next));
        Assert.Equal(2048, next["max_tokens"]!.GetValue<int>());
        Assert.False(next.ContainsKey("stop_sequences"));
        Assert.Equal(["BetaToolRunner, message-thread"], transport.HelperHeaderValues(1));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ChangedSystemIsRefusedBeforeAnyToolRunsWhileTheThreadContinues(bool streaming)
    {
        var transport = Replies(streaming, ToolUse("msg_a", "toolu_1"));
        var counter = new Counter();
        var runner = Messages(transport).ToolRunner(Params(), [Tool("get_weather", counter)]);

        var error = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            RunTurns(
                runner,
                streaming,
                _ => runner.SetParams(current => current with { System = "Be thorough." })
            )
        );

        Assert.Equal(Refusal("`System`"), error.Message);
        Assert.Equal(1, transport.RequestCount);
        Assert.Equal(0, counter.Runs);
    }

    const string Continued = "continued";
    const string Rewritten = "rewritten";

    static MessageCreateParams WithAnotherSystem(
        MessageCreateParams current,
        string history,
        BetaMessage reply
    ) =>
        current with
        {
            System = "Be thorough.",
            Messages =
                history == Continued
                    ? [.. current.Messages, Copy(reply), Mine("toolu_1")]
                    : [User("Rewritten")],
        };

    [Theory]
    [InlineData(Continued, false)]
    [InlineData(Continued, true)]
    [InlineData(Rewritten, false)]
    [InlineData(Rewritten, true)]
    public async Task ChangedSystemIsRefusedWhateverHistoryComesWithIt(
        string history,
        bool streaming
    )
    {
        var transport = Replies(streaming, ToolUse("msg_a", "toolu_1"));
        var counter = new Counter();
        var runner = Messages(transport).ToolRunner(Params(), [Tool("get_weather", counter)]);

        var error = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            RunReplies(
                runner,
                streaming,
                reply => runner.SetParams(current => WithAnotherSystem(current, history, reply))
            )
        );

        Assert.Equal(Refusal("`System`"), error.Message);
        Assert.Equal(1, transport.RequestCount);
        Assert.Equal(0, counter.Runs);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ChangedSystemIsRefusedWhileATurnIsPaused(bool streaming)
    {
        var transport = Replies(streaming, Paused("msg_a"));
        var runner = Messages(transport).ToolRunner(Params(), []);

        var error = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            RunTurns(
                runner,
                streaming,
                _ => runner.SetParams(current => current with { System = "Be thorough." })
            )
        );

        Assert.Equal(Refusal("`System`"), error.Message);
        Assert.Equal(1, transport.RequestCount);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ChangedSystemGoesOutBeforeTheFirstRequestAndAfterACompaction(bool streaming)
    {
        var transport = Replies(
            streaming,
            ToolUse("msg_a", "toolu_1"),
            Summary("msg_c"),
            Final("msg_b")
        );
        var runner = Messages(transport)
            .ToolRunner(CompactionParams(), [Tool("get_weather", new Counter())]);
        runner.SetParams(current => current with { System = "Be thorough." });

        await RunWithCompaction(
            runner,
            streaming,
            () => runner.SetParams(current => current with { System = "Be kind." })
        );

        Assert.Equal(
            ["Be thorough.", "Be thorough.", "Be kind."],
            transport.JsonBodies.Select(request => request["system"]!.GetValue<string>())
        );
    }

    [Fact]
    public async Task RunnerOverAThreadContinuesItAndLeavesItReadyToContinue()
    {
        var transport = Replies(
            Final("msg_a"),
            ToolUse("msg_b", "toolu_1"),
            Final("msg_c"),
            Final("msg_d")
        );
        var counter = new Counter();
        var tool = Tool("get_weather", counter);
        var thread = Messages(transport)
            .Thread(ThreadParams() with { Messages = [], Tools = [tool.Definition] });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        thread.Append(User("Weather?"));

        var replies = await Run(thread.ToolRunner([tool]));
        await thread.Send(User("Thanks"), TestContext.Current.CancellationToken);

        Assert.Equal(["msg_b", "msg_c"], replies.Select(reply => reply.ID));
        Assert.Equal(1, counter.Runs);
        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal(["user"], Shape(transport.JsonBodies[1]));
        Assert.Equal(["toolu_1"], Shape(transport.JsonBodies[2]));
        AssertContinue(transport.JsonBodies[3], "msg_c");
        Assert.Equal(["message-thread"], transport.HelperHeaderValues(0));
        Assert.Equal(["BetaToolRunner, message-thread"], transport.HelperHeaderValues(1));
        Assert.Equal(["message-thread"], transport.HelperHeaderValues(3));
        Assert.Equal(8, thread.Messages.Count);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task RawThreadOfTheCallersIsReplaced(bool update)
    {
        var transport = Replies(Final("msg_a"), Final("msg_b"), Final("msg_c"));
        var raw = WithThread(Params(), "continue");
        var thread = Messages(transport)
            .Thread(
                update
                    ? ThreadParams()
                    : ThreadCreateParams.FromRawUnchecked(
                        raw.RawHeaderData,
                        raw.RawQueryData,
                        raw.RawBodyData
                    )
            );
        if (update)
        {
            thread.Update(_ =>
                ThreadSendParams.FromRawUnchecked(
                    raw.RawHeaderData,
                    raw.RawQueryData,
                    raw.RawBodyData
                )
            );
        }

        await thread.Send(TestContext.Current.CancellationToken);
        await thread.Send(User("Again"), TestContext.Current.CancellationToken);
        thread.Append(User("Once more"));
        await Run(thread.ToolRunner([]));

        AssertCreate(transport.JsonBodies[0]);
        AssertContinue(transport.JsonBodies[1], "msg_a");
        AssertContinue(transport.JsonBodies[2], "msg_b");
        Assert.False(thread.Params.RawBodyData.ContainsKey("thread"));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task RunThatStopsAtItsLimitLeavesTheToolResultsAndTheContainerOnTheThread(
        bool streaming
    )
    {
        var transport = Replies(streaming, InContainer(ToolUse("msg_a", "toolu_1"), "container_a"))
            .EnqueueJson(200, Final("msg_b"));
        var counter = new Counter();
        var tool = Tool("get_weather", counter);
        var thread = Messages(transport).Thread(ThreadParams() with { Tools = [tool.Definition] });

        await RunTurns(thread.ToolRunner([tool], maxIterations: 1), streaming);

        Assert.Equal(1, counter.Runs);
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(thread.Messages));

        await thread.Send(User("Thanks"), TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[1];
        AssertContinue(next, "msg_a");
        Assert.Equal(["toolu_1", "user"], Shape(next));
        Assert.Equal("container_a", next["container"]!.GetValue<string>());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task RefusalEndsTheRunAndIsNotRecordedOnTheThread(bool streaming)
    {
        var transport = Replies(
                streaming,
                ToolUse("msg_a", "toolu_1"),
                Reply("msg_refused", "refusal", Text("No."))
            )
            .EnqueueJson(200, Final("msg_b"));
        var counter = new Counter();
        var tool = Tool("get_weather", counter);
        var thread = Messages(transport).Thread(ThreadParams() with { Tools = [tool.Definition] });

        await RunTurns(thread.ToolRunner([tool]), streaming);

        Assert.Equal(2, transport.RequestCount);
        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(thread.Messages));
        Assert.Equal("msg_a", thread.LastMessage?.ID);

        await thread.Send(User("Thanks"), TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[2];
        AssertCreate(next);
        Assert.Equal(["user", "assistant", "toolu_1", "user"], Shape(next));
        Assert.NotNull(next["system"]);
        Assert.NotNull(next["tools"]);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task RefusalOfATurnSentAgainAfterAPartialReplyEndsTheRun(bool streaming)
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"))
            .EnqueueSse(Stream(Reply("msg_b", "end_turn", Text("Looking."))));
        EnqueueReplies(transport, streaming, Reply("msg_refused", "refusal", Text("No.")));
        var counter = new Counter();
        var tool = Tool("get_weather", counter);
        var thread = Messages(transport).Thread(ThreadParams() with { Tools = [tool.Definition] });
        await thread.Send(TestContext.Current.CancellationToken);
        var results = new BetaUserMessageParam
        {
            Content = new List<BetaContentBlockParam> { new BetaToolResultBlockParam("toolu_1") },
        };
        await foreach (
            var streamEvent in thread.SendStreaming(results, TestContext.Current.CancellationToken)
        )
        {
            if (streamEvent.Json.GetProperty("type").GetString() == "content_block_stop")
            {
                break;
            }
        }
        Assert.Equal(["user", "assistant", "toolu_1", "assistant"], Shape(thread.Messages));

        await RunTurns(thread.ToolRunner([tool]), streaming);

        Assert.Equal(0, counter.Runs);
        Assert.Equal(3, transport.RequestCount);
        AssertCreate(transport.JsonBodies[2]);
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(transport.JsonBodies[2]));
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(thread.Messages));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task CompactionPendingWhenARefusalEndsTheRunIsSent(bool streaming)
    {
        var transport = Replies(
            streaming,
            ToolUse("msg_a", "toolu_1"),
            Reply("msg_refused", "refusal", Text("No.")),
            Summary("msg_c")
        );
        var runner = Messages(transport)
            .ToolRunner(CompactionParams(), [Tool("get_weather", new Counter())]);

        await RunTurns(runner, streaming, afterTurn: 1, () => runner.CompactBeforeNextTurn());

        Assert.Equal(3, transport.RequestCount);
        var compaction = transport.JsonBodies[2];
        Assert.NotNull(compaction["compaction"]);
        AssertCreate(compaction);
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(compaction));
        Assert.Equal(["assistant"], Shape(runner.Params.Messages));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ReplyOfAFallbackModelOnlyStartsANewThread(bool streaming)
    {
        var fallback = JsonNode.Parse(
            Reply("msg_a", "tool_use", FallbackBlock("claude-sonnet-4-5"), Call("toolu_1"))
        )!;
        fallback["usage"]!["iterations"] = FallbackIterations("claude-sonnet-4-5");
        var transport = Replies(
            streaming,
            fallback.ToJsonString(),
            ToolUse("msg_b", "toolu_2"),
            Final("msg_c")
        );
        var counter = new Counter();
        var runner = Messages(transport)
            .ToolRunner(
                Params() with
                {
                    Fallbacks = new List<BetaFallbackParam> { new(FallbackModel) },
                    Betas = [FallbackBeta],
                },
                [Tool("get_weather", counter)]
            );

        await RunTurns(runner, streaming);

        Assert.Equal(2, counter.Runs);
        var next = transport.JsonBodies[1];
        AssertCreate(next);
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(next));
        Assert.NotNull(next["system"]);
        Assert.NotNull(next["tools"]);
        AssertContinue(transport.JsonBodies[2], "msg_b");
        Assert.Equal(["toolu_2"], Shape(transport.JsonBodies[2]));
        foreach (var index in new[] { 1, 2 })
        {
            Assert.Equal(
                "claude-sonnet-4-5",
                transport.JsonBodies[index]["model"]!.GetValue<string>()
            );
            Assert.Equal(
                transport.JsonBodies[0]["fallbacks"]!.ToJsonString(),
                transport.JsonBodies[index]["fallbacks"]!.ToJsonString()
            );
            Assert.Equal(Betas(transport, 0), Betas(transport, index));
        }
        Assert.Equal("claude-sonnet-4-5", runner.Params.Model.Raw());
        Assert.Equal(
            transport.JsonBodies[0]["fallbacks"]!.ToJsonString(),
            runner.Params.RawBodyData["fallbacks"].GetRawText()
        );
    }

    [Fact]
    public async Task RefusedReplyIsTheResultOfTheRun()
    {
        var transport = Replies(
            ToolUse("msg_a", "toolu_1"),
            Reply("msg_refused", "refusal", Text("No."))
        );
        var runner = Messages(transport).ToolRunner(Params(), [Tool("get_weather", new Counter())]);

        var result = await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        Assert.Equal("msg_refused", result.ID);
        Assert.Equal(["user"], Shape(runner.Params.Messages));
    }

    sealed class Forecast
    {
        public string Sky { get; set; } = "";
    }

    [Fact]
    public async Task RunnerOverATypedThreadSendsItsOutputFormat()
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"), Final("msg_b"));
        var tool = Tool("get_weather", new Counter());
        var thread = Messages(transport)
            .Thread<Forecast>(ThreadParams() with { Tools = [tool.Definition] });

        await Run(thread.ToolRunner([tool]));

        AssertCreate(transport.JsonBodies[0]);
        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.NotNull(transport.JsonBodies[0]["output_config"]!["format"]);
        Assert.Equal(
            transport.JsonBodies[0]["output_config"]!.ToJsonString(),
            transport.JsonBodies[1]["output_config"]!.ToJsonString()
        );
        Assert.Equal("msg_b", thread.LastMessage!.ID);
    }

    [Fact]
    public async Task RunnerOverADefaultThreadRaisesUnsupportedRequest()
    {
        var transport = new FakeTransport().EnqueueJson(
            400,
            ThreadError("thread_unsupported_request")
        );
        var thread = Messages(transport).Thread(ThreadParams());

        await Assert.ThrowsAnyAsync<AnthropicApiException>(() => Run(thread.ToolRunner([])));

        Assert.Equal(1, transport.RequestCount);
    }

    [Fact]
    public async Task RunnerOverAThreadThatHoldsAPartialReplyKeepsTheThreadItStarts()
    {
        var transport = new FakeTransport()
            .EnqueueSse(Stream(Reply("msg_a", "end_turn", Text("Looking."))))
            .EnqueueJson(200, ToolUse("msg_b", "toolu_1"))
            .EnqueueJson(200, Final("msg_c"));
        var tool = Tool("get_weather", new Counter());
        var thread = Messages(transport).Thread(ThreadParams() with { Tools = [tool.Definition] });
        await foreach (
            var streamEvent in thread.SendStreaming(TestContext.Current.CancellationToken)
        )
        {
            if (streamEvent.Json.GetProperty("type").GetString() == "content_block_stop")
            {
                break;
            }
        }

        await Run(thread.ToolRunner([tool]));

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(["user"], Shape(transport.JsonBodies[1]));
        AssertContinue(transport.JsonBodies[2], "msg_b");
        Assert.Equal(["toolu_1"], Shape(transport.JsonBodies[2]));
    }

    [Fact]
    public async Task RunnerWithAToolTheThreadLacksIsRefusedWhileTheThreadContinues()
    {
        var transport = Replies(Final("msg_a"), Final("msg_b"));
        var thread = Messages(transport).Thread(ThreadParams() with { Messages = [] });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        var error = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            Run(thread.ToolRunner([Tool("get_weather", new Counter())]))
        );

        Assert.Equal(Refusal("`Tools`"), error.Message);
        Assert.Equal(1, transport.RequestCount);
        await Run(thread.ToolRunner([]));
        AssertContinue(transport.JsonBodies[1], "msg_a");
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task NewRunnerFromTheParamsOfARunnerSendsEachDefinitionOnce(bool thread)
    {
        var transport = Replies(Final("msg_a"), Final("msg_b"));
        var tool = Tool("get_weather", new Counter());
        var messages = Messages(transport);
        var first = messages.ToolRunner(
            Params() with
            {
                Tools = [Tool("get_time", new Counter()).Definition],
            },
            [tool],
            thread
        );
        await Run(first);

        await Run(
            messages.ToolRunner(
                first.Params with
                {
                    System = "Be thorough.",
                    Messages = [.. first.Params.Messages, User("And in Rome?")],
                },
                [tool],
                thread
            )
        );

        var next = transport.JsonBodies[1];
        Assert.Equal("Be thorough.", next["system"]!.GetValue<string>());
        Assert.Equal(
            transport.JsonBodies[0]["tools"]!.ToJsonString(),
            next["tools"]!.ToJsonString()
        );
        Assert.Equal(2, next["tools"]!.AsArray().Count);
        Assert.Equal(thread ? """{"type":"create"}""" : null, next["thread"]?.ToJsonString());
    }

    [Fact]
    public async Task CompactionStartsANewThreadAndSoDoesTheSummary()
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"), Summary("msg_c"), Final("msg_b"));
        var runner = Messages(transport)
            .ToolRunner(CompactionParams(), [Tool("get_weather", new Counter())]);

        await RunTurns(runner, false, afterTurn: 0, () => runner.CompactBeforeNextTurn());

        var compaction = transport.JsonBodies[1];
        Assert.NotNull(compaction["compaction"]);
        AssertCreate(compaction);
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(compaction));
        var next = transport.JsonBodies[2];
        Assert.False(next.ContainsKey("compaction"));
        AssertCreate(next);
        Assert.Equal(["assistant"], Shape(next));
        Assert.Equal("compaction", FirstBlockType(next));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task CompactionThatTheApiCannotThreadCostsOneRequestAndEndsThreading(
        bool streaming
    )
    {
        var transport = Replies(streaming, ToolUse("msg_a", "toolu_1"))
            .EnqueueJson(400, ThreadError("thread_unsupported_request"));
        EnqueueReplies(
            transport,
            streaming,
            Summary("msg_c"),
            ToolUse("msg_b", "toolu_2"),
            Final("msg_d")
        );
        var runner = Messages(transport)
            .ToolRunner(CompactionParams(), [Tool("get_weather", new Counter())]);

        await RunTurns(runner, streaming, afterTurn: 0, () => runner.CompactBeforeNextTurn());

        Assert.Equal(5, transport.RequestCount);
        var rejected = transport.JsonBodies[1];
        Assert.NotNull(rejected["compaction"]);
        AssertCreate(rejected);
        Assert.NotNull(transport.JsonBodies[2]["compaction"]);
        Assert.Equal(
            rejected["messages"]!.ToJsonString(),
            transport.JsonBodies[2]["messages"]!.ToJsonString()
        );
        foreach (var index in new[] { 2, 3, 4 })
        {
            Assert.False(transport.JsonBodies[index].ContainsKey("thread"));
            Assert.Equal(["compact-2026-09-04"], Betas(transport, index));
        }
        Assert.Equal(["assistant"], Shape(transport.JsonBodies[3]));
        Assert.Equal(["assistant", "assistant", "toolu_2"], Shape(transport.JsonBodies[4]));
    }

    [Fact]
    public async Task CompactionThatTheApiCannotThreadIsRaisedOnAThreadThatRaises()
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"))
            .EnqueueJson(400, ThreadError("thread_unsupported_request"));
        var tool = Tool("get_weather", new Counter());
        var thread = CompactionThread(transport, tool);
        var runner = thread.ToolRunner([tool]);

        await Assert.ThrowsAsync<AnthropicBadRequestException>(() =>
            RunTurns(runner, false, afterTurn: 0, () => runner.CompactBeforeNextTurn())
        );

        Assert.Equal(2, transport.RequestCount);
        Assert.Equal(["user", "assistant", "toolu_1"], Shape(thread.Messages));
    }

    /// <summary>
    /// Runs to the end, compacts after the first turn and calls <paramref name="act"/> while the
    /// caller holds the compaction response.
    /// </summary>
    static Task RunWithCompaction(BetaToolRunner runner, bool streaming, Action act) =>
        RunTurns(
            runner,
            streaming,
            turn =>
            {
                if (turn == 0)
                {
                    runner.CompactBeforeNextTurn();
                }
                else if (turn == 1)
                {
                    act();
                }
            }
        );

    /// <summary>One word per message: its text, or the type of its first block.</summary>
    static string[] Texts(JsonObject request) =>
        [
            .. request["messages"]!
                .AsArray()
                .Select(message =>
                    (
                        message!["content"] as JsonValue ?? message["content"]![0]!["type"]!
                    ).GetValue<string>()
                ),
        ];

    [Theory]
    [InlineData(false, false)]
    [InlineData(false, true)]
    [InlineData(true, false)]
    [InlineData(true, true)]
    public async Task MessagesAppendedToTheThreadDuringACompactionFollowTheSummary(
        bool streaming,
        bool inOneCall
    )
    {
        var transport = Replies(
            streaming,
            ToolUse("msg_a", "toolu_1"),
            Summary("msg_c"),
            Final("msg_b")
        );
        var tool = Tool("get_weather", new Counter());
        var thread = CompactionThread(transport, tool);
        var runner = thread.ToolRunner([tool]);

        await RunWithCompaction(
            runner,
            streaming,
            () =>
            {
                Assert.Throws<AnthropicException>(() => runner.PushMessages(User("Briefly.")));
                if (inOneCall)
                {
                    thread.Append(User("In one word."), User("Please."));
                }
                else
                {
                    thread.Append(User("In one word."));
                    thread.Append(User("Please."));
                }
            }
        );

        var next = transport.JsonBodies[2];
        AssertCreate(next);
        Assert.Equal(["compaction", "In one word.", "Please."], Texts(next));
        Assert.Equal(["assistant", "user", "user", "assistant"], Shape(thread.Messages));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MessageAppendedToTheThreadBeforeTheCompactionStreamIsReadIsKept(bool summary)
    {
        var transport = Replies(
            true,
            ToolUse("msg_a", "toolu_1"),
            summary ? Summary("msg_c") : Reply("msg_c", "max_tokens"),
            Final("msg_b")
        );
        var tool = Tool("get_weather", new Counter());
        var thread = CompactionThread(transport, tool);
        var runner = thread.ToolRunner([tool]);

        var turns = 0;
        await foreach (var turn in runner.Streaming(TestContext.Current.CancellationToken))
        {
            if (turns++ == 1)
            {
                thread.Append(User("In one word."));
            }
            await foreach (var _ in turn) { }
            if (turns == 1)
            {
                runner.CompactBeforeNextTurn();
            }
        }

        string[] compacted = ["user", "assistant", "toolu_1", "user"];
        Assert.Equal(compacted, Shape(transport.JsonBodies[1]));
        Assert.Equal(summary ? ["assistant", "user"] : compacted, Shape(transport.JsonBodies[2]));
        Assert.Equal("In one word.", Texts(transport.JsonBodies[2])[^1]);
    }

    [Fact]
    public async Task MessagesAppendedDuringACompactionOfAThreadThatHeldAPartialReplyFollowTheSummary()
    {
        var transport = new FakeTransport()
            .EnqueueSse(Stream(Reply("msg_a", "end_turn", Text("Looking."))))
            .EnqueueJson(200, Summary("msg_c"))
            .EnqueueJson(200, Final("msg_b"));
        var tool = Tool("get_weather", new Counter());
        var thread = CompactionThread(transport, tool);
        await foreach (
            var streamEvent in thread.SendStreaming(TestContext.Current.CancellationToken)
        )
        {
            if (streamEvent.Json.GetProperty("type").GetString() == "content_block_stop")
            {
                break;
            }
        }
        var runner = thread.ToolRunner([tool]);
        runner.CompactBeforeNextTurn();

        await RunTurns(
            runner,
            false,
            afterTurn: 0,
            () => thread.Append(User("In one word."), User("Please."))
        );

        Assert.Equal(["user"], Shape(transport.JsonBodies[1]));
        Assert.Equal(["compaction", "In one word.", "Please."], Texts(transport.JsonBodies[2]));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MessageAppendedToTheThreadDuringACompactionAfterTheFinalTurnStaysStaged(
        bool streaming
    )
    {
        var transport = Replies(streaming, Final("msg_a"), Summary("msg_c"))
            .EnqueueJson(200, Final("msg_b"));
        var tool = Tool("get_weather", new Counter());
        var thread = CompactionThread(transport, tool);

        await RunWithCompaction(
            thread.ToolRunner([tool]),
            streaming,
            () => thread.Append(User("And tomorrow?"))
        );

        Assert.Equal(2, transport.RequestCount);
        Assert.Equal(["assistant", "user"], Shape(thread.Messages));

        await thread.Send(TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[2];
        AssertCreate(next);
        Assert.Equal(["assistant", "user"], Shape(next));
        Assert.Equal("compaction", FirstBlockType(next));
    }

    [Fact]
    public async Task CompactionResponseAppendedToTheThreadAgainIsKeptOnce()
    {
        var transport = Replies(ToolUse("msg_a", "toolu_1"), Summary("msg_c"), Final("msg_b"));
        var tool = Tool("get_weather", new Counter());
        var thread = CompactionThread(transport, tool);
        var runner = thread.ToolRunner([tool]);

        await foreach (var reply in runner.WithCancellation(TestContext.Current.CancellationToken))
        {
            if (reply.ID == "msg_a")
            {
                runner.CompactBeforeNextTurn();
            }
            thread.Append(reply);
        }

        Assert.Equal(["assistant"], Shape(transport.JsonBodies[2]));
        Assert.Equal("compaction", FirstBlockType(transport.JsonBodies[2]));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MessageAppendedToTheThreadDuringACompactionWithoutASummaryFollowsTheHistory(
        bool streaming
    )
    {
        var transport = Replies(
            streaming,
            ToolUse("msg_a", "toolu_1"),
            Reply("msg_c", "max_tokens"),
            Final("msg_b")
        );
        var tool = Tool("get_weather", new Counter());
        var thread = CompactionThread(transport, tool);

        await RunWithCompaction(
            thread.ToolRunner([tool]),
            streaming,
            () => thread.Append(User("In one word."))
        );

        Assert.Equal(["user", "assistant", "toolu_1", "user"], Shape(transport.JsonBodies[2]));
    }

    [Theory]
    [InlineData("message_start")]
    [InlineData("content_block_stop")]
    public async Task CompactionStreamTheCallerStopsReadingThrows(string lastEventRead)
    {
        var transport = Replies(
            true,
            ToolUse("msg_a", "toolu_1"),
            Summary("msg_c"),
            Final("msg_b")
        );
        var runner = Messages(transport)
            .ToolRunner(CompactionParams(), [Tool("get_weather", new Counter())]);

        var turns = 0;
        await Assert.ThrowsAsync<AnthropicInvalidDataException>(async () =>
        {
            await foreach (var turn in runner.Streaming(TestContext.Current.CancellationToken))
            {
                var compaction = turns++ == 1;
                await foreach (var streamEvent in turn)
                {
                    if (
                        compaction
                        && streamEvent.Json.GetProperty("type").GetString() == lastEventRead
                    )
                    {
                        break;
                    }
                }
                runner.CompactBeforeNextTurn();
            }
        });

        Assert.Equal(2, turns);
        Assert.Equal(2, transport.RequestCount);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MessageAppendedToTheThreadOnTheFinalTurnIsCompacted(bool streaming)
    {
        var transport = Replies(streaming, Final("msg_a"), Summary("msg_c"));
        var tool = Tool("get_weather", new Counter());
        var thread = CompactionThread(transport, tool);
        var runner = thread.ToolRunner([tool]);

        await RunTurns(
            runner,
            streaming,
            afterTurn: 0,
            () =>
            {
                runner.CompactBeforeNextTurn();
                thread.Append(User("And tomorrow?"));
            }
        );

        Assert.NotNull(transport.JsonBodies[1]["compaction"]);
        Assert.Equal(["user", "assistant", "user"], Shape(transport.JsonBodies[1]));
        Assert.Equal(["assistant"], Shape(thread.Messages));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task StreamTheServerCutsOffThrows(bool afterTheReplyStarts)
    {
        var cutOff = afterTheReplyStarts
            ? Stream(Reply("msg_a", "tool_use", Text("Looking."), Call("toolu_1")))
                .Replace(Event(new JsonObject { ["type"] = "message_stop" }), "")
            : Event(new JsonObject { ["type"] = "ping" });
        var transport = new FakeTransport().EnqueueSse(cutOff).EnqueueSse(Stream(Final("msg_b")));
        var counter = new Counter();
        var runner = Messages(transport)
            .ToolRunner(Params(), [Tool("get_weather", counter)], maxIterations: 3);

        await Assert.ThrowsAsync<AnthropicInvalidDataException>(() =>
            RunTurns(runner, streaming: true)
        );

        AssertCreate(transport.JsonBodies[0]);
        Assert.Equal(1, transport.RequestCount);
        Assert.Equal(0, counter.Runs);
        Assert.Equal(["user"], Shape(runner.Params.Messages));
    }

    [Fact]
    public async Task StreamTheCallerStopsReadingThrowsAndLeavesThePartialReplyOnTheThread()
    {
        var transport = new FakeTransport()
            .EnqueueSse(Stream(Reply("msg_a", "tool_use", Text("Looking."), Call("toolu_1"))))
            .EnqueueJson(200, Final("msg_b"));
        var counter = new Counter();
        var tool = Tool("get_weather", counter);
        var thread = Messages(transport).Thread(ThreadParams() with { Tools = [tool.Definition] });

        var turns = 0;
        await Assert.ThrowsAsync<AnthropicInvalidDataException>(async () =>
        {
            await foreach (
                var turn in thread
                    .ToolRunner([tool])
                    .Streaming(TestContext.Current.CancellationToken)
            )
            {
                await foreach (var streamEvent in turn)
                {
                    if (streamEvent.Json.GetProperty("type").GetString() == "content_block_stop")
                    {
                        break;
                    }
                }
                turns++;
            }
        });
        await thread.Send(User("Go on"), TestContext.Current.CancellationToken);

        Assert.Equal(1, turns);
        Assert.Equal(0, counter.Runs);
        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(["user", "assistant", "user"], Shape(transport.JsonBodies[1]));
    }

    const string Default = "default";
    const string OptOut = "opt-out";
    const string Unsupported = "unsupported";

    static readonly string[] s_modes = [Default, OptOut, Unsupported];

    public static TheoryData<string, bool> ModesAndStreaming()
    {
        var data = new TheoryData<string, bool>();
        foreach (var mode in s_modes)
        {
            data.Add(mode, false);
            data.Add(mode, true);
        }
        return data;
    }

    /// <summary>
    /// A run with default settings, with the opt-out, or with default settings against an API that
    /// rejects the first request as unsupported.
    /// </summary>
    sealed class ModeRun(string mode, bool streaming, params string[] replies)
    {
        public FakeTransport Transport { get; } =
            EnqueueReplies(
                mode == Unsupported
                    ? new FakeTransport().EnqueueJson(
                        400,
                        ThreadError("thread_unsupported_request")
                    )
                    : new FakeTransport(),
                streaming,
                replies
            );

        public Counter Counter { get; } = new();

        public BetaToolRunner Runner(MessageCreateParams parameters) =>
            Messages(Transport)
                .ToolRunner(parameters, [Tool("get_weather", Counter)], thread: mode != OptOut);

        /// <summary>The requests that were answered with a reply.</summary>
        public List<JsonObject> Answered
        {
            get
            {
                var rejected = mode == Unsupported ? 1 : 0;
                Assert.Equal(replies.Length + rejected, Transport.RequestCount);
                return [.. Transport.JsonBodies.Skip(rejected)];
            }
        }

        /// <summary>
        /// The conversation that each answered request puts before the model: its messages, after
        /// those of the turn that it continues. Each tool result comes with what it says.
        /// </summary>
        public string[][] Seen()
        {
            var held = new Dictionary<string, JsonArray>();
            var seen = new List<string[]>();
            var answered = Answered;
            for (var index = 0; index < answered.Count; index++)
            {
                var previous = answered[index]["thread"]?["previous_message_id"];
                var conversation = new JsonArray(
                    [
                        .. (previous == null ? [] : held[previous.GetValue<string>()])
                            .Concat(answered[index]["messages"]!.AsArray())
                            .Select(message => message!.DeepClone()),
                    ]
                );
                seen.Add(
                    [
                        .. conversation.Select(message =>
                            message!["content"] is JsonArray blocks
                            && blocks.Any(block => block!["tool_use_id"] != null)
                                ? string.Join(
                                    "+",
                                    blocks.Select(block =>
                                        $"{block!["tool_use_id"]}={block["content"]}"
                                    )
                                )
                                : message["role"]!.GetValue<string>()
                        ),
                    ]
                );

                var reply = JsonNode.Parse(replies[index])!;
                conversation.Add(
                    new JsonObject
                    {
                        ["role"] = "assistant",
                        ["content"] = reply["content"]!.DeepClone(),
                    }
                );
                held[reply["id"]!.GetValue<string>()] = conversation;
            }
            return [.. seen];
        }
    }

    sealed class TakeOver(
        string[] replies,
        Action<BetaToolRunner, BetaMessage> afterTurn,
        string[][] seen,
        string[] byDefault,
        int runs = 1,
        IReadOnlyList<BetaMessageParam>? initial = null
    )
    {
        public string[] Replies => replies;

        public Action<BetaToolRunner, BetaMessage> AfterTurn => afterTurn;

        /// <summary>The conversation that each request puts before the model, in every mode.</summary>
        public string[][] Seen => seen;

        /// <summary>Whether each request creates or continues with default settings.</summary>
        public string[] ByDefault => byDefault;

        public int Runs => runs;

        public IReadOnlyList<BetaMessageParam> Initial => initial ?? [User("Weather?")];
    }

    static readonly string[] s_takeOvers =
    [
        "own result and a follow-up",
        "two turns in a row",
        "second turn only",
        "own result only",
        "one of two calls",
        "user message only",
        "history the caller keeps",
        "appended to the params",
        "tool turn left out of a longer history",
        "copy of a paused turn",
    ];

    static TakeOver TakeOverNamed(string name)
    {
        string[] oneCall = [ToolUse("msg_a", "toolu_1"), Final("msg_b")];
        string[] twoTurns =
        [
            ToolUse("msg_a", "toolu_1"),
            ToolUse("msg_b", "toolu_2"),
            Final("msg_c"),
        ];
        string[][] bothTurnsMine =
        [
            ["user"],
            ["user", "assistant", "toolu_1=mine"],
            ["user", "assistant", "toolu_1=mine", "assistant", "toolu_2=mine"],
        ];
        var kept = new List<BetaMessageParam> { User("Weather?") };
        return name switch
        {
            "own result and a follow-up" => new(
                oneCall,
                (runner, reply) =>
                    runner.PushMessages(Copy(reply), Mine("toolu_1"), User("Briefly.")),
                [
                    ["user"],
                    ["user", "assistant", "toolu_1=mine", "user"],
                ],
                ["create", "continue"]
            ),
            "two turns in a row" => new(
                twoTurns,
                (runner, reply) => runner.PushMessages(Copy(reply), Mine(Calls(reply))),
                bothTurnsMine,
                ["create", "continue", "continue"],
                runs: 2
            ),
            "second turn only" => new(
                twoTurns,
                (runner, reply) =>
                {
                    if (reply.ID == "msg_b")
                    {
                        runner.PushMessages(Copy(reply), Mine("toolu_2"));
                    }
                },
                [
                    ["user"],
                    ["user", "assistant", "toolu_1=ran toolu_1"],
                    ["user", "assistant", "toolu_2=mine"],
                ],
                ["create", "continue", "create"],
                runs: 2
            ),
            "own result only" => new(
                oneCall,
                (runner, _) => runner.PushMessages(Mine("toolu_1")),
                [
                    ["user"],
                    ["user", "toolu_1=mine"],
                ],
                ["create", "create"]
            ),
            "one of two calls" => new(
                [ToolUse("msg_a", "toolu_1", "toolu_2"), Final("msg_b")],
                (runner, reply) => runner.PushMessages(Copy(reply), Mine("toolu_1")),
                [
                    ["user"],
                    ["user", "assistant", "toolu_1=mine"],
                ],
                ["create", "continue"],
                runs: 2
            ),
            "user message only" => new(
                oneCall,
                (runner, _) => runner.PushMessages(User("Briefly.")),
                [
                    ["user"],
                    ["user", "user"],
                ],
                ["create", "create"]
            ),
            "history the caller keeps" => new(
                twoTurns,
                (runner, reply) =>
                {
                    kept.Add(Copy(reply));
                    kept.Add(Mine(Calls(reply)));
                    runner.SetParams(Params() with { Messages = [.. kept] });
                },
                bothTurnsMine,
                ["create", "continue", "continue"],
                runs: 2
            ),
            "appended to the params" => new(
                oneCall,
                (runner, reply) =>
                    runner.SetParams(current =>
                        current with
                        {
                            Messages = [.. current.Messages, Copy(reply), Mine("toolu_1")],
                        }
                    ),
                [
                    ["user"],
                    ["user", "assistant", "toolu_1=mine"],
                ],
                ["create", "continue"]
            ),
            "tool turn left out of a longer history" => new(
                oneCall,
                (runner, _) =>
                    runner.SetParams(current =>
                        current with
                        {
                            Messages = [.. current.Messages, User("No tools.")],
                        }
                    ),
                [
                    ["user", "assistant", "user"],
                    ["user", "assistant", "user", "user"],
                ],
                ["create", "create"],
                initial:
                [
                    User("Hello"),
                    new BetaAssistantMessageParam { Content = "Hi." },
                    User("Weather?"),
                ]
            ),
            "copy of a paused turn" => new(
                [Paused("msg_a"), Final("msg_b")],
                (runner, reply) => runner.PushMessages(Copy(reply)),
                [
                    ["user"],
                    ["user", "assistant"],
                ],
                ["create", "continue"],
                runs: 0
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(name), name, null),
        };
    }

    public static TheoryData<string, string, bool> TakeOvers()
    {
        var data = new TheoryData<string, string, bool>();
        foreach (var name in s_takeOvers)
        {
            foreach (var mode in s_modes)
            {
                data.Add(name, mode, false);
                data.Add(name, mode, true);
            }
        }
        return data;
    }

    [Theory]
    [MemberData(nameof(TakeOvers))]
    public async Task CallerWhoChangesTheParamsManagesTheHistory(
        string name,
        string mode,
        bool streaming
    )
    {
        var takeOver = TakeOverNamed(name);
        var run = new ModeRun(mode, streaming, takeOver.Replies);
        var runner = run.Runner(Params() with { Messages = takeOver.Initial });

        await RunReplies(runner, streaming, reply => takeOver.AfterTurn(runner, reply));

        Assert.Equal(takeOver.Seen, run.Seen());
        Assert.Equal(takeOver.Runs, run.Counter.Runs);
        Assert.Equal(
            mode == Default ? takeOver.ByDefault : takeOver.ByDefault.Select(_ => (string?)null),
            run.Answered.Select(request => request["thread"]?["type"]?.GetValue<string>())
        );
    }

    [Theory]
    [MemberData(nameof(ModesAndStreaming))]
    public async Task ChangedFieldAloneSendsTheParamsWithoutTheTurn(string mode, bool streaming)
    {
        var run = new ModeRun(mode, streaming, ToolUse("msg_a", "toolu_1"), Final("msg_b"));
        var runner = run.Runner(Params());

        await RunReplies(
            runner,
            streaming,
            _ =>
                runner.SetParams(current =>
                    current with
                    {
                        MaxTokens = 2048,
                        StopSequences = ["END"],
                    }
                )
        );

        Assert.Equal(
            [
                ["user"],
                ["user"],
            ],
            run.Seen()
        );
        Assert.Equal(1, run.Counter.Runs);
        Assert.Equal(2048, run.Answered[1]["max_tokens"]!.GetValue<int>());
        Assert.Equal("""["END"]""", run.Answered[1]["stop_sequences"]!.ToJsonString());
    }

    [Theory]
    [InlineData(OptOut, null, false)]
    [InlineData(OptOut, null, true)]
    [InlineData(OptOut, Continued, false)]
    [InlineData(OptOut, Continued, true)]
    [InlineData(OptOut, Rewritten, false)]
    [InlineData(OptOut, Rewritten, true)]
    [InlineData(Unsupported, null, false)]
    [InlineData(Unsupported, null, true)]
    [InlineData(Unsupported, Continued, false)]
    [InlineData(Unsupported, Continued, true)]
    [InlineData(Unsupported, Rewritten, false)]
    [InlineData(Unsupported, Rewritten, true)]
    public async Task ChangedSystemGoesOutWithoutAThread(
        string mode,
        string? history,
        bool streaming
    )
    {
        var run = new ModeRun(mode, streaming, ToolUse("msg_a", "toolu_1"), Final("msg_b"));
        var runner = run.Runner(Params());

        await RunReplies(
            runner,
            streaming,
            reply =>
                runner.SetParams(current =>
                    history == null
                        ? current with
                        {
                            System = "Be thorough.",
                        }
                        : WithAnotherSystem(current, history, reply)
                )
        );

        Assert.Equal("Be thorough.", run.Answered[1]["system"]!.GetValue<string>());
        Assert.Equal(1, run.Counter.Runs);
    }

    [Theory]
    [MemberData(nameof(ModesAndStreaming))]
    public async Task ParamsHoldOnlyWhatTheCallerSet(string mode, bool streaming)
    {
        var run = new ModeRun(
            mode,
            streaming,
            ToolUse("msg_a", "toolu_1"),
            ToolUse("msg_b", "toolu_2"),
            Final("msg_c")
        );
        var runner = run.Runner(Params());

        await RunTurns(
            runner,
            streaming,
            _ => Assert.Equal(["user"], Shape(runner.Params.Messages))
        );

        Assert.Equal(["user"], Shape(runner.Params.Messages));
        Assert.Equal(3, run.Answered.Count);
    }

    [Theory]
    [MemberData(nameof(ModesAndStreaming))]
    public async Task NewRunnerFromTheParamsOfARunThatStoppedStartsFromWhatTheCallerSet(
        string mode,
        bool streaming
    )
    {
        var run = new ModeRun(mode, false, ToolUse("msg_a", "toolu_1"));
        var stopped = run.Runner(Params());
        await foreach (var _ in stopped.WithCancellation(TestContext.Current.CancellationToken))
        {
            break;
        }
        var next = new ModeRun(mode, streaming, Final("msg_b"));

        await RunTurns(next.Runner(stopped.Params), streaming);

        Assert.Equal(
            [
                ["user"],
            ],
            next.Seen()
        );
    }

    [Theory]
    [MemberData(nameof(ModesAndStreaming))]
    public async Task CompactionAfterATurnTheCallerManagedSummarizesTheCallersHistory(
        string mode,
        bool streaming
    )
    {
        var run = new ModeRun(
            mode,
            streaming,
            ToolUse("msg_a", "toolu_1"),
            Summary("msg_summary"),
            Final("msg_b")
        );
        var runner = run.Runner(CompactionParams());

        await RunReplies(
            runner,
            streaming,
            reply =>
            {
                if (reply.ID == "msg_a")
                {
                    runner.PushMessages(Copy(reply), Mine("toolu_1"));
                    runner.CompactBeforeNextTurn();
                }
            }
        );

        Assert.Equal(
            [
                ["user"],
                ["user", "assistant", "toolu_1=mine"],
                ["assistant"],
            ],
            run.Seen()
        );
        Assert.NotNull(run.Answered[1]["compaction"]);
        Assert.Equal(1, run.Counter.Runs);
    }

    [Theory]
    [InlineData(Default, null)]
    [InlineData(Default, "message_start")]
    [InlineData(Default, "content_block_stop")]
    [InlineData(OptOut, null)]
    [InlineData(OptOut, "message_start")]
    [InlineData(OptOut, "content_block_stop")]
    public async Task StreamThatIsNotReadToItsEndThrows(string mode, string? lastEventRead)
    {
        var run = new ModeRun(mode, true, ToolUse("msg_a", "toolu_1"), Final("msg_b"));

        var turns = 0;
        await Assert.ThrowsAsync<AnthropicInvalidDataException>(async () =>
        {
            await foreach (
                var turn in run.Runner(Params()).Streaming(TestContext.Current.CancellationToken)
            )
            {
                turns++;
                if (lastEventRead == null)
                {
                    continue;
                }
                await foreach (var streamEvent in turn)
                {
                    if (streamEvent.Json.GetProperty("type").GetString() == lastEventRead)
                    {
                        break;
                    }
                }
            }
        });

        Assert.Equal(1, turns);
        Assert.Equal(lastEventRead == null ? 0 : 1, run.Transport.RequestCount);
        Assert.Equal(0, run.Counter.Runs);
    }
}
