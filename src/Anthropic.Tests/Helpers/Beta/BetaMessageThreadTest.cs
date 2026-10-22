using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Helpers;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta.Messages;
using static Anthropic.Tests.Helpers.Beta.MessageThreadTestSupport;

namespace Anthropic.Tests.Helpers.Beta;

public class BetaMessageThreadTest
{
    static ThreadCreateParams Params() =>
        new()
        {
            Model = "claude-sonnet-4-5",
            MaxTokens = 1024,
            Messages = [],
        };

    static BetaTool WeatherTool() =>
        new()
        {
            Name = "get_weather",
            InputSchema = new InputSchema(new Dictionary<string, JsonElement>()),
        };

    static string Reply(
        string id,
        string text = "Hi",
        string stopReason = "end_turn",
        string? container = null
    ) =>
        new JsonObject
        {
            ["id"] = id,
            ["type"] = "message",
            ["role"] = "assistant",
            ["model"] = "claude-sonnet-4-5",
            ["content"] = new JsonArray(new JsonObject { ["type"] = "text", ["text"] = text }),
            ["stop_reason"] = stopReason,
            ["stop_sequence"] = null,
            ["container"] =
                container == null
                    ? null
                    : new JsonObject
                    {
                        ["id"] = container,
                        ["expires_at"] = "2030-01-01T00:00:00Z",
                    },
            ["usage"] = new JsonObject { ["input_tokens"] = 1, ["output_tokens"] = 1 },
        }.ToJsonString();

    static string ThreadError(string? errorCode, string type = "invalid_request_error")
    {
        var error = new JsonObject { ["type"] = type, ["message"] = "thread_not_found" };
        if (errorCode != null)
        {
            error["details"] = new JsonObject { ["error_code"] = errorCode };
        }
        return new JsonObject { ["type"] = "error", ["error"] = error }.ToJsonString();
    }

    static string Event(string data) =>
        $"event: {JsonNode.Parse(data)!["type"]!.GetValue<string>()}\ndata: {data}\n\n";

    static string MessageStart(string id) =>
        Event(
            """{"type":"message_start","message":{"id":"ID","type":"message","role":"assistant","model":"claude-sonnet-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":1,"output_tokens":1}}}""".Replace(
                "ID",
                id
            )
        );

    static string BlockEvent(string type, int index, string member, JsonObject value) =>
        Event(
            new JsonObject
            {
                ["type"] = type,
                ["index"] = index,
                [member] = value,
            }.ToJsonString()
        );

    static string TextStart(int index) =>
        BlockEvent(
            "content_block_start",
            index,
            "content_block",
            new JsonObject { ["type"] = "text", ["text"] = "" }
        );

    static string TextDelta(int index, string text) =>
        BlockEvent(
            "content_block_delta",
            index,
            "delta",
            new JsonObject { ["type"] = "text_delta", ["text"] = text }
        );

    static string ToolUseStart(int index, string id) =>
        BlockEvent(
            "content_block_start",
            index,
            "content_block",
            new JsonObject
            {
                ["type"] = "tool_use",
                ["id"] = id,
                ["name"] = "get_weather",
                ["input"] = new JsonObject(),
            }
        );

    static string InputDelta(int index, string partialJson) =>
        BlockEvent(
            "content_block_delta",
            index,
            "delta",
            new JsonObject { ["type"] = "input_json_delta", ["partial_json"] = partialJson }
        );

    static string BlockStop(int index) =>
        Event(new JsonObject { ["type"] = "content_block_stop", ["index"] = index }.ToJsonString());

    static string MessageEnd(string stopReason = "end_turn", JsonArray? iterations = null)
    {
        var usage = new JsonObject { ["output_tokens"] = 2 };
        if (iterations != null)
        {
            usage["iterations"] = iterations;
        }
        return Event(
                new JsonObject
                {
                    ["type"] = "message_delta",
                    ["delta"] = new JsonObject
                    {
                        ["stop_reason"] = stopReason,
                        ["stop_sequence"] = null,
                    },
                    ["usage"] = usage,
                }.ToJsonString()
            ) + Event("""{"type":"message_stop"}""");
    }

    static string WholeStream(string id, string text = "Hi", string stopReason = "end_turn") =>
        MessageStart(id)
        + TextStart(0)
        + TextDelta(0, text)
        + BlockStop(0)
        + MessageEnd(stopReason);

    static FakeTransport Replies(params string[] replies)
    {
        var transport = new FakeTransport();
        foreach (var reply in replies)
        {
            transport.EnqueueJson(200, reply);
        }
        return transport;
    }

    static async Task ReadToEnd(IAsyncEnumerable<BetaRawMessageStreamEvent> stream)
    {
        await foreach (var _ in stream) { }
    }

    /// <summary>Reads a stream that ends early. Whether that throws is the stream's own behavior.</summary>
    static async Task ReadUntilItEnds(IAsyncEnumerable<BetaRawMessageStreamEvent> stream)
    {
        try
        {
            await ReadToEnd(stream);
        }
        catch (Exception e) when (IsStreamFailure(e)) { }
    }

    static string[] Roles(JsonObject body) =>
        [.. body["messages"]!.AsArray().Select(message => message!["role"]!.GetValue<string>())];

    static string[] Texts(JsonObject body) =>
        [
            .. body["messages"]!
                .AsArray()
                .Select(message =>
                    message!["content"] is JsonValue text
                        ? text.GetValue<string>()
                        : message["content"]!.ToJsonString()
                ),
        ];

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task SendWithNothingStagedGoesOutAndTheApiAnswers(bool streaming)
    {
        var transport = new FakeTransport()
            .EnqueueJson(400, ThreadError(null))
            .EnqueueJson(200, Reply("msg_a"))
            .EnqueueJson(400, ThreadError(null));
        var thread = Messages(transport).Thread(Params());
        async Task SendNothing()
        {
            if (streaming)
            {
                await ReadToEnd(thread.SendStreaming(TestContext.Current.CancellationToken));
                return;
            }
            await thread.Send(TestContext.Current.CancellationToken);
        }

        await Assert.ThrowsAsync<AnthropicBadRequestException>(SendNothing);
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        await Assert.ThrowsAsync<AnthropicBadRequestException>(SendNothing);

        Assert.Equal(3, transport.RequestCount);
        AssertCreate(transport.JsonBodies[0]);
        Assert.Empty(transport.JsonBodies[0]["messages"]!.AsArray());
        AssertContinue(transport.JsonBodies[2], "msg_a");
        Assert.Empty(transport.JsonBodies[2]["messages"]!.AsArray());
        Assert.Equal("msg_a", thread.PreviousMessageID);
        Assert.Equal(2, thread.Messages.Count);
    }

    [Theory]
    [InlineData(404, "thread_not_found")]
    [InlineData(409, "thread_already_continued")]
    [InlineData(409, "thread_continue_in_flight")]
    public async Task RejectedContinueReplaysUnderCreate(int status, string errorCode)
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Reply("msg_a"))
            .EnqueueJson(status, ThreadError(errorCode))
            .EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport).Thread(Params() with { System = "Be brief." });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        var reply = await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        Assert.Equal("msg_b", reply.ID);
        Assert.Equal(3, transport.RequestCount);
        AssertContinue(transport.JsonBodies[1], "msg_a");
        var replay = transport.JsonBodies[2];
        AssertCreate(replay);
        Assert.Equal(["user", "assistant", "user"], Roles(replay));
        Assert.NotNull(replay["system"]);
        Assert.Equal("msg_b", thread.PreviousMessageID);
    }

    [Fact]
    public async Task ReplayCodeOnCreateIsRaisedAfterOneRequest()
    {
        var transport = new FakeTransport().EnqueueJson(404, ThreadError("thread_not_found"));
        var thread = Messages(transport).Thread(Params());

        await Assert.ThrowsAnyAsync<AnthropicApiException>(() =>
            thread.Send(User("Hello"), TestContext.Current.CancellationToken)
        );

        Assert.Equal(1, transport.RequestCount);
        Assert.Empty(thread.Messages);
    }

    [Theory]
    [InlineData(404, null)]
    [InlineData(400, null)]
    [InlineData(400, "thread_fingerprint_mismatch")]
    [InlineData(400, "a_code_of_a_later_api_version")]
    public async Task OtherErrorsAreRaisedAndChangeNothing(int status, string? errorCode)
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Reply("msg_a"))
            .EnqueueJson(status, ThreadError(errorCode));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        await Assert.ThrowsAnyAsync<AnthropicApiException>(() =>
            thread.Send(User("Again"), TestContext.Current.CancellationToken)
        );

        Assert.Equal(2, transport.RequestCount);
        Assert.Equal("msg_a", thread.PreviousMessageID);
        Assert.Equal(2, thread.Messages.Count);
    }

    [Fact]
    public async Task FailedReplayLeavesACreateWithTheWholeHistory()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Reply("msg_a"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(500, ThreadError(null, "api_error"))
            .EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        await Assert.ThrowsAnyAsync<AnthropicApiException>(() =>
            thread.Send(User("Again"), TestContext.Current.CancellationToken)
        );
        Assert.Null(thread.PreviousMessageID);

        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[3]);
        Assert.Equal(["user", "assistant", "user"], Roles(transport.JsonBodies[3]));
    }

    [Fact]
    public async Task ContinueUnthreadedSendsTheWholeHistoryWithoutAThread()
    {
        var transport = new FakeTransport()
            .EnqueueJson(400, ThreadError("thread_unsupported_request"))
            .EnqueueJson(200, Reply("msg_a"))
            .EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport)
            .Thread(
                Params() with
                {
                    System = "Be brief.",
                    Betas = ["context-management-2025-06-27"],
                    UnsupportedRequestBehavior = BetaUnsupportedRequestBehavior.ContinueUnthreaded,
                }
            );

        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[0]);
        foreach (var index in new[] { 1, 2 })
        {
            Assert.False(transport.JsonBodies[index].ContainsKey("thread"));
            Assert.NotNull(transport.JsonBodies[index]["system"]);
            Assert.Equal(["context-management-2025-06-27"], Betas(transport, index));
        }
        Assert.Equal(["user", "assistant", "user"], Roles(transport.JsonBodies[2]));
        Assert.Null(thread.PreviousMessageID);
    }

    [Theory]
    [InlineData(BetaUnsupportedRequestBehavior.ContinueUnthreaded)]
    [InlineData(BetaUnsupportedRequestBehavior.Error)]
    public async Task ThreadNotFoundAgainRightAfterAReplay(BetaUnsupportedRequestBehavior behavior)
    {
        var transport = Replies(Reply("msg_a"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, Reply("msg_b"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, Reply("msg_c"))
            .EnqueueJson(200, Reply("msg_d"));
        var thread = Messages(transport)
            .Thread(Params() with { System = "Be brief.", UnsupportedRequestBehavior = behavior });
        foreach (var text in new[] { "m1", "m2", "m3", "m4" })
        {
            await thread.Send(User(text), TestContext.Current.CancellationToken);
        }

        Assert.Equal(6, transport.RequestCount);
        AssertContinue(transport.JsonBodies[1], "msg_a");
        AssertCreate(transport.JsonBodies[2]);
        AssertContinue(transport.JsonBodies[3], "msg_b");
        var again = transport.JsonBodies[4];
        Assert.Equal(["user", "assistant", "user", "assistant", "user"], Roles(again));
        Assert.NotNull(again["system"]);
        if (behavior == BetaUnsupportedRequestBehavior.Error)
        {
            AssertCreate(again);
            AssertContinue(transport.JsonBodies[5], "msg_c");
            return;
        }

        Assert.False(again.ContainsKey("thread"));
        Assert.False(transport.JsonBodies[5].ContainsKey("thread"));
        Assert.Equal(7, transport.JsonBodies[5]["messages"]!.AsArray().Count);
        Assert.Null(thread.PreviousMessageID);
    }

    [Theory]
    [InlineData(200, null)]
    [InlineData(409, "thread_already_continued")]
    [InlineData(409, "thread_continue_in_flight")]
    public async Task ThreadNotFoundLaterOrAfterAnotherRejectionReplaysUnderCreate(
        int status,
        string? errorCode
    )
    {
        var transport = Replies(Reply("msg_a"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, Reply("msg_b"));
        if (errorCode != null)
        {
            transport.EnqueueJson(status, ThreadError(errorCode));
        }
        transport
            .EnqueueJson(200, Reply("msg_c"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, Reply("msg_d"))
            .EnqueueJson(200, Reply("msg_e"));
        var thread = Messages(transport)
            .Thread(
                Params() with
                {
                    UnsupportedRequestBehavior = BetaUnsupportedRequestBehavior.ContinueUnthreaded,
                }
            );
        foreach (var text in new[] { "m1", "m2", "m3", "m4", "m5" })
        {
            await thread.Send(User(text), TestContext.Current.CancellationToken);
        }

        var last = transport.RequestCount - 1;
        AssertContinue(transport.JsonBodies[last - 2], "msg_c");
        AssertCreate(transport.JsonBodies[last - 1]);
        AssertContinue(transport.JsonBodies[last], "msg_d");
    }

    static async Task Turn(
        BetaMessageThread thread,
        string entryPoint,
        IEnumerable<BetaMessageParam> messages,
        Func<ThreadSendParams, ThreadSendParams>? configure = null
    )
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        if (entryPoint == "Send")
        {
            await thread.Send(messages, configure, cancellationToken);
        }
        else
        {
            await ReadToEnd(thread.SendStreaming(messages, configure, cancellationToken));
        }
    }

    static FakeTransport EnqueueReply(
        FakeTransport transport,
        string entryPoint,
        string id,
        string stopReason = "end_turn"
    ) =>
        entryPoint == "SendStreaming"
            ? transport.EnqueueSse(WholeStream(id, stopReason: stopReason))
            : transport.EnqueueJson(200, Reply(id, stopReason: stopReason));

    static FakeTransport EnqueueFailure(FakeTransport transport, string failure) =>
        failure switch
        {
            "connection error" => transport.EnqueueFailure(
                new HttpRequestException("Connection refused")
            ),
            "cancellation" => transport.EnqueueFailure(new OperationCanceledException()),
            _ => transport.EnqueueJson(int.Parse(failure), ThreadError(null)),
        };

    [Theory]
    [InlineData("Send", "400")]
    [InlineData("Send", "529")]
    [InlineData("Send", "connection error")]
    [InlineData("Send", "cancellation")]
    [InlineData("SendStreaming", "400")]
    [InlineData("SendStreaming", "529")]
    [InlineData("SendStreaming", "connection error")]
    [InlineData("SendStreaming", "cancellation")]
    public async Task CallThatFailsBeforeAReplyStartsTakesBackItsMessages(
        string entryPoint,
        string failure
    )
    {
        var transport = Replies(Reply("msg_a"));
        EnqueueFailure(transport, failure);
        EnqueueFailure(transport, failure);
        EnqueueReply(transport, entryPoint, "msg_b");
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        await Assert.ThrowsAnyAsync<Exception>(() => Turn(thread, entryPoint, [User("Bad")]));
        await Assert.ThrowsAnyAsync<Exception>(() => Turn(thread, entryPoint, [User("Good")]));

        Assert.Equal(["Hello"], UserTexts(thread.Messages));
        Assert.Equal("msg_a", thread.PreviousMessageID);

        await Turn(thread, entryPoint, [User("Good")]);

        Assert.Equal(4, transport.RequestCount);
        foreach (var index in new[] { 2, 3 })
        {
            AssertContinue(transport.JsonBodies[index], "msg_a");
            Assert.Equal(["Good"], Texts(transport.JsonBodies[index]));
        }
        Assert.Equal(["Hello", "Good"], UserTexts(thread.Messages));
    }

    [Theory]
    [InlineData("Send")]
    [InlineData("SendStreaming")]
    public async Task FailedCallLeavesWhatWasAppendedStaged(string entryPoint)
    {
        var transport = Replies(Reply("msg_a")).EnqueueJson(400, ThreadError(null));
        EnqueueReply(transport, entryPoint, "msg_b");
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        thread.Append(User("Appended"));

        await Assert.ThrowsAsync<AnthropicBadRequestException>(() =>
            Turn(thread, entryPoint, [User("Passed"), User("Passed too")])
        );

        Assert.Equal(["Appended", "Passed", "Passed too"], Texts(transport.JsonBodies[1]));
        Assert.Equal(["Hello", "Appended"], UserTexts(thread.Messages));

        await Turn(thread, entryPoint, []);

        AssertContinue(transport.JsonBodies[2], "msg_a");
        Assert.Equal(["Appended"], Texts(transport.JsonBodies[2]));
    }

    [Fact]
    public async Task FailedCallOnATypedThreadTakesBackItsMessage()
    {
        var transport = new FakeTransport()
            .EnqueueJson(529, ThreadError(null, "overloaded_error"))
            .EnqueueJson(200, City("msg_a", "Paris"));
        var thread = Messages(transport).Thread<Answer>(Params());

        await Assert.ThrowsAnyAsync<AnthropicApiException>(() =>
            thread.Send(User("Where?"), TestContext.Current.CancellationToken)
        );
        Assert.Empty(thread.Messages);

        await thread.Send(User("Where?"), TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(["Where?"], Texts(transport.JsonBodies[1]));
    }

    [Theory]
    [InlineData("Send")]
    [InlineData("SendStreaming")]
    public async Task RefusedTurnIsNotRecordedAndTheNextTurnStartsANewThread(string entryPoint)
    {
        var transport = Replies(Reply("msg_a"));
        EnqueueReply(transport, entryPoint, "msg_refused", "refusal");
        EnqueueReply(transport, entryPoint, "msg_b");
        EnqueueReply(transport, entryPoint, "msg_c");
        var thread = Messages(transport)
            .Thread(Params() with { System = "Be brief.", Tools = [WeatherTool()] });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        await Turn(thread, entryPoint, [User("Bad")]);

        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal(["user", "assistant"], thread.Messages.Select(message => message.Role.Raw()));
        Assert.Equal("msg_a", thread.LastMessage?.ID);
        Assert.Null(thread.PreviousMessageID);

        await Turn(thread, entryPoint, [User("Good")]);
        await Turn(thread, entryPoint, [User("Again")]);

        var next = transport.JsonBodies[2];
        AssertCreate(next);
        Assert.Equal(["user", "assistant", "user"], Roles(next));
        Assert.Equal("Good", Texts(next)[2]);
        Assert.NotNull(next["system"]);
        Assert.NotNull(next["tools"]);
        AssertContinue(transport.JsonBodies[3], "msg_b");
        Assert.Equal(["Hello", "Good", "Again"], UserTexts(thread.Messages));
    }

    [Theory]
    [InlineData("Send")]
    [InlineData("SendStreaming")]
    public async Task RefusedTurnLeavesWhatWasAppendedStaged(string entryPoint)
    {
        var transport = Replies(Reply("msg_a"));
        EnqueueReply(transport, entryPoint, "msg_refused", "refusal");
        EnqueueReply(transport, entryPoint, "msg_b");
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        thread.Append(User("Appended"));

        await Turn(thread, entryPoint, [User("Bad")]);

        Assert.Equal(["Appended", "Bad"], Texts(transport.JsonBodies[1]));
        Assert.Equal(["Hello", "Appended"], UserTexts(thread.Messages));

        await Turn(thread, entryPoint, [User("Good")]);

        AssertCreate(transport.JsonBodies[2]);
        Assert.Equal(["user", "assistant", "user", "user"], Roles(transport.JsonBodies[2]));
        Assert.Equal(["Appended", "Good"], Texts(transport.JsonBodies[2]).Skip(2));
    }

    [Fact]
    public async Task RefusalTheCallerStopsReadingBeforeMessageStopIsNotRecorded()
    {
        var transport = Replies(Reply("msg_a"))
            .EnqueueSse(WholeStream("msg_refused", "No.", "refusal"))
            .EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport).Thread(Params() with { System = "Be brief." });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        thread.Append(User("Appended"));

        await foreach (
            var streamEvent in thread.SendStreaming(
                User("Bad"),
                TestContext.Current.CancellationToken
            )
        )
        {
            if (streamEvent.Json.GetProperty("type").GetString() == "message_delta")
            {
                break;
            }
        }

        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal(["Hello", "Appended"], UserTexts(thread.Messages));
        Assert.Equal(3, thread.Messages.Count);
        Assert.Equal("msg_a", thread.LastMessage?.ID);

        await thread.Send(User("Good"), TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[2];
        AssertCreate(next);
        Assert.Equal(["user", "assistant", "user", "user"], Roles(next));
        Assert.Equal(["Appended", "Good"], Texts(next).Skip(2));
        Assert.NotNull(next["system"]);
    }

    [Fact]
    public async Task RefusedFirstTurnLeavesTheThreadAsItWasCreated()
    {
        var transport = Replies(Reply("msg_refused", "No.", "refusal"), Reply("msg_a"));
        var thread = Messages(transport).Thread(Params() with { Messages = [User("Hello")] });

        var refused = await thread.Send(
            [User("Bad")],
            fields => fields with { System = "Be brief.", Tools = [WeatherTool()] },
            TestContext.Current.CancellationToken
        );

        Assert.Equal("msg_refused", refused.ID);
        Assert.Equal("refusal", refused.StopReason?.Raw());
        Assert.Equal("No.", Assert.Single(refused.Content).Json.GetProperty("text").GetString());
        Assert.Null(thread.LastMessage);

        await thread.Send(User("Good"), TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[1];
        AssertCreate(next);
        Assert.Equal(["Hello", "Good"], Texts(next));
        Assert.False(next.ContainsKey("system"));
        Assert.False(next.ContainsKey("tools"));
    }

    [Fact]
    public async Task RefusedTurnWithoutAThreadIsNotRecordedEither()
    {
        var transport = new FakeTransport()
            .EnqueueJson(400, ThreadError("thread_unsupported_request"))
            .EnqueueJson(200, Reply("msg_a"))
            .EnqueueJson(200, Reply("msg_refused", stopReason: "refusal"))
            .EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport)
            .Thread(
                Params() with
                {
                    UnsupportedRequestBehavior = BetaUnsupportedRequestBehavior.ContinueUnthreaded,
                }
            );
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        await thread.Send(User("Bad"), TestContext.Current.CancellationToken);
        await thread.Send(User("Good"), TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[3];
        Assert.False(next.ContainsKey("thread"));
        Assert.Equal(["user", "assistant", "user"], Roles(next));
        Assert.Equal("Good", Texts(next)[2]);
    }

    [Fact]
    public async Task RefusedTurnOnATypedThreadIsNotRecorded()
    {
        var transport = Replies(Reply("msg_refused", "No.", "refusal"), City("msg_a", "Paris"));
        var thread = Messages(transport).Thread<Answer>(Params());

        var refused = await thread.Send(User("Bad"), TestContext.Current.CancellationToken);

        Assert.Equal("msg_refused", refused.ID);
        Assert.Null(thread.LastMessage);
        Assert.Empty(thread.Messages);

        await thread.Send(User("Where?"), TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(["Where?"], Texts(transport.JsonBodies[1]));
    }

    static BetaMessageParam Marked(params string[] texts) =>
        new BetaUserMessageParam
        {
            Content = texts
                .Select(text =>
                    (BetaContentBlockParam)new BetaTextBlockParam(text) { CacheControl = new() }
                )
                .ToList(),
        };

    /// <summary>The texts of the text blocks that have a <c>cache_control</c>.</summary>
    static string[] MarkedTexts(JsonNode messages) =>
        [
            .. messages
                .AsArray()
                .SelectMany(message => message!["content"] as JsonArray ?? [])
                .Where(block => block!["cache_control"] != null)
                .Select(block => block!["text"]!.GetValue<string>()),
        ];

    static string[] MarkedTexts(IEnumerable<BetaMessageParam> messages) =>
        MarkedTexts(JsonSerializer.SerializeToNode(messages.Select(message => message.Json))!);

    [Fact]
    public async Task ReplayLeavesOutTheCacheControlOfRecordedMessagesOnTheWireOnly()
    {
        var transport = Replies([.. Enumerable.Range(1, 5).Select(turn => Reply($"msg_{turn}"))])
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, Reply("msg_6"));
        var thread = Messages(transport).Thread(Params());
        string[] texts = ["m1", "m2", "m3", "m4", "m5", "m6"];
        var given = texts.Select(text => Marked(text)).ToList();

        foreach (var message in given)
        {
            await thread.Send(message, TestContext.Current.CancellationToken);
        }

        AssertContinue(transport.JsonBodies[5], "msg_5");
        Assert.Equal(["m6"], MarkedTexts(transport.JsonBodies[5]["messages"]!));
        var replay = transport.JsonBodies[6];
        AssertCreate(replay);
        Assert.Equal(11, replay["messages"]!.AsArray().Count);
        Assert.Equal(["m6"], MarkedTexts(replay["messages"]!));
        Assert.Equal(texts, MarkedTexts(thread.Messages));
        Assert.Equal(texts, MarkedTexts(thread.Params.Messages));
        Assert.Equal(texts, MarkedTexts(given));
    }

    [Fact]
    public async Task FirstRequestOfAThreadIsSentAsGiven()
    {
        var transport = Replies(Reply("msg_a"));
        var thread = Messages(transport).Thread(Params() with { Messages = [Marked("Initial")] });
        thread.Append(Marked("Appended"));

        await thread.Send(Marked("Passed"), TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[0]);
        Assert.Equal(
            ["Initial", "Appended", "Passed"],
            MarkedTexts(transport.JsonBodies[0]["messages"]!)
        );
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MessageThatNoReplyAnsweredIsSentAgainAsGiven(bool withANewMessage)
    {
        var transport = Replies(Reply("msg_a"))
            .EnqueueSse(MessageStart("msg_b"))
            .EnqueueJson(200, Reply("msg_c"));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(Marked("Hello"), TestContext.Current.CancellationToken);
        await ReadUntilItEnds(
            thread.SendStreaming(
                Marked("Again", "And again"),
                TestContext.Current.CancellationToken
            )
        );

        await thread.Send(
            withANewMessage ? [Marked("New")] : [],
            cancellationToken: TestContext.Current.CancellationToken
        );

        var replay = transport.JsonBodies[2];
        AssertCreate(replay);
        Assert.Equal(
            withANewMessage ? ["user", "assistant", "user", "user"] : ["user", "assistant", "user"],
            Roles(replay)
        );
        Assert.Equal(
            withANewMessage ? ["Again", "And again", "New"] : ["Again", "And again"],
            MarkedTexts(replay["messages"]!)
        );
    }

    [Fact]
    public async Task ReplayLeavesOutTheCacheControlOfBlocksAndKeepsFreeFormValues()
    {
        // A replay leaves out the marker at each MARKER. Any other `cache_control` goes as given.
        const string History = """
            [
              {"role":"assistant","content":[
                {MARKER"type":"compaction","content":"Summary.","tool_changes":[
                  {"type":"tool_addition","cache_control":{"type":"ephemeral"},"tool":
                    {"type":"tool_definition","definition":
                      {"name":"get_time","input_schema":{"type":"object"},"cache_control":{"type":"ephemeral"}}}}]}]},
              {"role":"system","content":[
                {MARKER"type":"tool_addition","tool":{"type":"tool_definition","definition":
                  {MARKER"name":"get_weather",
                   "input_schema":{"type":"object","properties":{"cache_control":{"type":"string"}}},
                   "input_examples":[{"cache_control":"no-store"}]}}}]},
              {"role":"user","content":[
                {MARKER"type":"text","text":"Weather?"},
                {MARKER"type":"document","source":{"type":"content","content":[
                  {MARKER"type":"text","text":"Forecast"}]}}]},
              {"role":"assistant","content":[
                {"type":"server_tool_use","id":"srvtoolu_1","name":"tool_search_tool_regex","input":{"pattern":"weather"}},
                {MARKER"type":"tool_search_tool_result","tool_use_id":"srvtoolu_1","content":
                  {"type":"tool_search_tool_search_result","tool_references":[
                    {MARKER"type":"tool_reference","tool_name":"get_weather"}]}},
                {MARKER"type":"tool_use","id":"toolu_1","name":"get_weather","input":{"cache_control":"no-store"}}]},
              {"role":"user","content":[
                {MARKER"type":"tool_result","tool_use_id":"toolu_1","content":[
                  {MARKER"type":"text","text":"Sunny"}]}]}
            ]
            """;
        static string[] Json(string history) =>
            [.. JsonNode.Parse(history)!.AsArray().Select(message => message!.ToJsonString())];
        var given = Json(History.Replace("MARKER", "\"cache_control\":{\"type\":\"ephemeral\"},"));
        var transport = Replies(Reply("msg_a"), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(
            given.Select(message => new BetaMessageParam(
                JsonSerializer.Deserialize<JsonElement>(message)
            )),
            cancellationToken: TestContext.Current.CancellationToken
        );

        await thread.Fork().Send(User("Thanks"), TestContext.Current.CancellationToken);

        Assert.Equal(given, Json(transport.JsonBodies[0]["messages"]!.ToJsonString()));
        Assert.Equal(
            Json(History.Replace("MARKER", "")),
            Json(transport.JsonBodies[1]["messages"]!.ToJsonString()).Take(given.Length)
        );
        Assert.Equal(given, thread.Messages.Take(given.Length).Select(m => m.Json.GetRawText()));
    }

    [Fact]
    public async Task ReplayKeepsTheCacheControlOutsideTheMessages()
    {
        var transport = Replies(Reply("msg_a"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport)
            .Thread(
                Params() with
                {
                    System = new List<BetaTextBlockParam>
                    {
                        new("Be brief.") { CacheControl = new() },
                    },
                    Tools = [WeatherTool() with { CacheControl = new() }],
                    CacheControl = new(),
                }
            );
        await thread.Send(Marked("Hello"), TestContext.Current.CancellationToken);

        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        var replay = transport.JsonBodies[2];
        AssertCreate(replay);
        Assert.Empty(MarkedTexts(replay["messages"]!));
        foreach (var field in new[] { "system", "tools", "cache_control" })
        {
            Assert.Equal(
                transport.JsonBodies[0][field]!.ToJsonString(),
                replay[field]!.ToJsonString()
            );
        }
        Assert.NotNull(replay["system"]![0]!["cache_control"]);
        Assert.NotNull(replay["tools"]![0]!["cache_control"]);
    }

    [Fact]
    public async Task RequestWithoutAThreadLeavesOutTheCacheControlOfRecordedMessages()
    {
        var transport = new FakeTransport()
            .EnqueueJson(400, ThreadError("thread_unsupported_request"))
            .EnqueueJson(200, Reply("msg_a"))
            .EnqueueJson(200, Reply("msg_b"))
            .EnqueueJson(200, Reply("msg_c"));
        var thread = Messages(transport)
            .Thread(
                Params() with
                {
                    UnsupportedRequestBehavior = BetaUnsupportedRequestBehavior.ContinueUnthreaded,
                }
            );

        await thread.Send(Marked("m1"), TestContext.Current.CancellationToken);
        await thread.Send(Marked("m2"), TestContext.Current.CancellationToken);
        await thread.Send(Marked("m3"), TestContext.Current.CancellationToken);

        Assert.Equal(["m1"], MarkedTexts(transport.JsonBodies[1]["messages"]!));
        Assert.Equal(["m2"], MarkedTexts(transport.JsonBodies[2]["messages"]!));
        Assert.False(transport.JsonBodies[3].ContainsKey("thread"));
        Assert.Equal(5, transport.JsonBodies[3]["messages"]!.AsArray().Count);
        Assert.Equal(["m3"], MarkedTexts(transport.JsonBodies[3]["messages"]!));
    }

    [Fact]
    public async Task FirstRequestOfAForkLeavesOutTheCacheControlOfRecordedMessages()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(Marked("Hello"), TestContext.Current.CancellationToken);
        thread.Append(Marked("Appended"));

        var fork = thread.Fork();
        await fork.Send(Marked("On the fork"), TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(
            ["Appended", "On the fork"],
            MarkedTexts(transport.JsonBodies[1]["messages"]!)
        );
        Assert.Equal(["Hello", "Appended", "On the fork"], MarkedTexts(fork.Messages));
    }

    static ThreadCreateParams ParamsWithFallbacks() =>
        Params() with
        {
            Fallbacks = new List<BetaFallbackParam> { new(FallbackModel) },
            Betas = [FallbackBeta],
        };

    static FakeTransport EnqueueFallbackReply(
        FakeTransport transport,
        string entryPoint,
        string id,
        string stopReason = "end_turn"
    )
    {
        var iterations = FallbackIterations("claude-sonnet-4-5");
        var block = FallbackBlock("claude-sonnet-4-5");
        if (entryPoint == "SendStreaming")
        {
            return transport.EnqueueSse(
                MessageStart(id)
                    + BlockEvent("content_block_start", 0, "content_block", block)
                    + BlockStop(0)
                    + TextStart(1)
                    + TextDelta(1, "Hi")
                    + BlockStop(1)
                    + MessageEnd(stopReason, iterations)
            );
        }

        var reply = JsonNode.Parse(Reply(id, stopReason: stopReason))!;
        reply["content"]!.AsArray().Insert(0, block);
        reply["usage"]!["iterations"] = iterations;
        return transport.EnqueueJson(200, reply.ToJsonString());
    }

    [Theory]
    [InlineData("Send")]
    [InlineData("SendStreaming")]
    public async Task ReplyOfAFallbackModelOnlyStartsANewThread(string entryPoint)
    {
        var transport = EnqueueFallbackReply(new FakeTransport(), entryPoint, "msg_a");
        EnqueueFallbackReply(transport, entryPoint, "msg_b");
        EnqueueReply(transport, entryPoint, "msg_c");
        EnqueueReply(transport, entryPoint, "msg_d");
        var given = ParamsWithFallbacks() with { System = "Be brief.", Tools = [WeatherTool()] };
        var thread = Messages(transport).Thread(given);

        await Turn(thread, entryPoint, [User("Hello")]);

        Assert.Null(thread.PreviousMessageID);
        Assert.Equal("msg_a", thread.LastMessage?.ID);

        await Turn(thread, entryPoint, [User("Again")]);
        await Turn(thread, entryPoint, [User("Once more")]);
        await Turn(thread, entryPoint, [User("And again")]);

        var afterAFallback = transport.JsonBodies[1];
        AssertCreate(afterAFallback);
        Assert.Equal(["user", "assistant", "user"], Roles(afterAFallback));
        Assert.Equal(
            ["fallback", "text"],
            afterAFallback["messages"]![1]!["content"]!
                .AsArray()
                .Select(block => block!["type"]!.GetValue<string>())
        );
        AssertCreate(transport.JsonBodies[2]);
        Assert.Equal(5, transport.JsonBodies[2]["messages"]!.AsArray().Count);
        AssertContinue(transport.JsonBodies[3], "msg_c");
        Assert.Equal(["And again"], Texts(transport.JsonBodies[3]));
        foreach (var index in new[] { 1, 2, 3 })
        {
            string[] sent =
                index == 3 ? ["model", "fallbacks"] : ["model", "fallbacks", "system", "tools"];
            foreach (var field in sent)
            {
                Assert.Equal(
                    transport.JsonBodies[0][field]!.ToJsonString(),
                    transport.JsonBodies[index][field]!.ToJsonString()
                );
            }
            Assert.Equal(Betas(transport, 0), Betas(transport, index));
        }
        Assert.Equal("claude-sonnet-4-5", transport.JsonBodies[0]["model"]!.GetValue<string>());
        Assert.Equal("claude-sonnet-4-5", thread.Params.Model.Raw());
        Assert.Equal(
            transport.JsonBodies[0]["fallbacks"]!.ToJsonString(),
            thread.Params.RawBodyData["fallbacks"].GetRawText()
        );
    }

    [Fact]
    public async Task RefusalOfAFallbackModelIsNotRecorded()
    {
        var transport = EnqueueFallbackReply(new FakeTransport(), "Send", "msg_refused", "refusal")
            .EnqueueJson(200, Reply("msg_a"));
        var thread = Messages(transport).Thread(ParamsWithFallbacks());

        await thread.Send(User("Bad"), TestContext.Current.CancellationToken);
        await thread.Send(User("Good"), TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[1];
        AssertCreate(next);
        Assert.Equal(["Good"], Texts(next));
        Assert.Equal("claude-sonnet-4-5", next["model"]!.GetValue<string>());
        Assert.NotNull(next["fallbacks"]);
    }

    [Fact]
    public async Task ReplyOfTheRequestedModelContinuesTheThread()
    {
        var reply = JsonNode.Parse(Reply("msg_a"))!;
        reply["usage"]!["iterations"] = new JsonArray(Iteration("message", "claude-sonnet-4-5"));
        var transport = Replies(reply.ToJsonString(), Reply("msg_b"));
        var thread = Messages(transport).Thread(ParamsWithFallbacks());

        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[1];
        AssertContinue(next, "msg_a");
        Assert.Equal("claude-sonnet-4-5", next["model"]!.GetValue<string>());
        Assert.NotNull(next["fallbacks"]);
    }

    [Fact]
    public async Task ReplyOfAFallbackModelWithoutAThreadChangesNothing()
    {
        var transport = new FakeTransport().EnqueueJson(
            400,
            ThreadError("thread_unsupported_request")
        );
        EnqueueFallbackReply(transport, "Send", "msg_a").EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport)
            .Thread(
                ParamsWithFallbacks() with
                {
                    UnsupportedRequestBehavior = BetaUnsupportedRequestBehavior.ContinueUnthreaded,
                }
            );

        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[2];
        Assert.False(next.ContainsKey("thread"));
        Assert.Equal("claude-sonnet-4-5", next["model"]!.GetValue<string>());
        Assert.NotNull(next["fallbacks"]);
        Assert.Equal("claude-sonnet-4-5", thread.Params.Model.Raw());
    }

    static ThreadSendParams Changed(ThreadSendParams parameters, string change) =>
        change switch
        {
            "system" => parameters with { System = "Be thorough." },
            "tools" => parameters with { Tools = [WeatherTool() with { Description = "New" }] },
            _ => parameters with { System = "Be thorough.", Tools = [] },
        };

    [Theory]
    [InlineData("system", "`System`", false, "Send")]
    [InlineData("system", "`System`", true, "Send")]
    [InlineData("system", "`System`", false, "SendStreaming")]
    [InlineData("tools", "`Tools`", false, "Send")]
    [InlineData("both", "`System` and `Tools`", false, "Send")]
    public async Task ChangedSystemOrToolsIsRefusedUntilItIsPutBack(
        string change,
        string named,
        bool forOneTurn,
        string entryPoint
    )
    {
        var transport = Replies(Reply("msg_a"));
        EnqueueReply(transport, entryPoint, "msg_b");
        var thread = Messages(transport)
            .Thread(Params() with { System = "Be brief.", Tools = [WeatherTool()] });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        thread.Append(User("Staged"));

        if (!forOneTurn)
        {
            thread.Update(parameters => Changed(parameters, change));
        }
        var error = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            Turn(
                thread,
                entryPoint,
                [User("Again")],
                forOneTurn ? parameters => Changed(parameters, change) : null
            )
        );

        Assert.Equal(Refusal(named), error.Message);
        Assert.Equal(1, transport.RequestCount);
        Assert.Equal("msg_a", thread.PreviousMessageID);
        Assert.Equal(["Hello", "Staged"], UserTexts(thread.Messages));

        if (!forOneTurn)
        {
            thread.Update(parameters =>
                parameters with
                {
                    System = "Be brief.",
                    Tools = [WeatherTool()],
                }
            );
        }
        await Turn(thread, entryPoint, [User("Again")]);

        Assert.Equal(2, transport.RequestCount);
        var next = transport.JsonBodies[1];
        AssertContinue(next, "msg_a");
        Assert.Equal(["Staged", "Again"], Texts(next));
        Assert.False(next.ContainsKey("system"));
        Assert.False(next.ContainsKey("tools"));
        Assert.Equal("msg_b", thread.PreviousMessageID);
    }

    [Fact]
    public async Task SystemAndToolsOfTheTurnThatCreatesTheThreadAreTheThreadsFromThenOn()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params() with { System = "Be brief." });
        await thread.Send(
            [User("Hello")],
            parameters => parameters with { System = "Be thorough.", Tools = [WeatherTool()] },
            TestContext.Current.CancellationToken
        );

        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal("Be thorough.", thread.Params.RawBodyData["system"].GetString());
        Assert.Single(thread.Params.Tools!);
    }

    [Fact]
    public async Task ChangeBeforeTheFirstTurnGoesOutWithTheCreate()
    {
        var transport = Replies(Reply("msg_a"));
        var thread = Messages(transport).Thread(Params() with { System = "Be brief." });

        thread.Update(parameters => Changed(parameters, "system"));
        await thread.Send(
            [User("Hello")],
            parameters => Changed(parameters, "tools"),
            TestContext.Current.CancellationToken
        );

        AssertCreate(transport.JsonBodies[0]);
        Assert.Equal("Be thorough.", transport.JsonBodies[0]["system"]!.GetValue<string>());
        Assert.Single(transport.JsonBodies[0]["tools"]!.AsArray());
    }

    [Fact]
    public async Task ToolRemovalInAnAppendedSystemMessageGoesOutWithTheContinueAsGiven()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params() with { Tools = [WeatherTool()] });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        thread.Append(
            new BetaSystemMessageParam
            {
                Content = new BetaSystemMessageParamContent(
                    [
                        new BetaRequestToolRemovalBlock(
                            new BetaToolChangeToolReference("get_weather")
                        ),
                    ]
                ),
            }
        );
        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        var next = transport.JsonBodies[1];
        AssertContinue(next, "msg_a");
        Assert.False(next.ContainsKey("tools"));
        Assert.True(
            JsonNode.DeepEquals(
                JsonNode.Parse(
                    """[{"role":"system","content":[{"type":"tool_removal","tool":{"type":"tool_reference","name":"get_weather"}}]},{"role":"user","content":"Again"}]"""
                ),
                next["messages"]
            ),
            next["messages"]!.ToJsonString()
        );
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task NewThreadFromTheParamsOrAForkTakesTheChange(bool fork)
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"), Reply("msg_c"));
        var client = Client(transport);
        var thread = client.Beta.Messages.Thread(Params() with { System = "Be brief." });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        thread.Append(User("Again"));

        BetaMessageThread changed;
        if (fork)
        {
            changed = thread.Fork();
            changed.Update(parameters => Changed(parameters, "both"));
        }
        else
        {
            changed = client.Beta.Messages.Thread(
                thread.Params with
                {
                    System = "Be thorough.",
                    Tools = [],
                }
            );
        }
        await changed.Send(TestContext.Current.CancellationToken);
        await thread.Send(TestContext.Current.CancellationToken);

        var create = transport.JsonBodies[1];
        AssertCreate(create);
        Assert.Equal(["user", "assistant", "user"], Roles(create));
        Assert.Equal("Be thorough.", create["system"]!.GetValue<string>());
        Assert.Empty(create["tools"]!.AsArray());
        AssertContinue(transport.JsonBodies[2], "msg_a");
    }

    [Fact]
    public async Task ThreadsBetaJoinsTheCallersBetasOnce()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"));
        var thread = Messages(transport)
            .Thread(Params() with { Betas = [ThreadsBeta, "context-management-2025-06-27"] });

        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        foreach (var index in new[] { 0, 1 })
        {
            Assert.Equal([ThreadsBeta, "context-management-2025-06-27"], Betas(transport, index));
        }
        Assert.Equal(
            [ThreadsBeta, "context-management-2025-06-27"],
            thread.Params.Betas!.Select(beta => beta.Raw())
        );
    }

    static Dictionary<string, JsonElement> Headers(params (string Name, string Value)[] headers) =>
        headers.ToDictionary(
            header => header.Name,
            header => JsonSerializer.SerializeToElement(header.Value)
        );

    static ThreadCreateParams WithHeaders(
        ThreadCreateParams parameters,
        params (string Name, string Value)[] headers
    ) =>
        ThreadCreateParams.FromRawUnchecked(
            Headers(headers),
            parameters.RawQueryData,
            parameters.RawBodyData
        );

    static ThreadSendParams WithHeaders(
        ThreadSendParams parameters,
        params (string Name, string Value)[] headers
    ) =>
        ThreadSendParams.FromRawUnchecked(
            Headers(headers),
            parameters.RawQueryData,
            parameters.RawBodyData
        );

    /// <summary>The lines of a header in each request, joined by <c>|</c>: empty when it has none.</summary>
    static string[] Header(FakeTransport transport, string name) =>
        [
            .. transport.RequestHeaders.Select(headers =>
                string.Join(
                    "|",
                    headers
                        .Where(header =>
                            string.Equals(header.Key, name, StringComparison.OrdinalIgnoreCase)
                        )
                        .SelectMany(header => header.Value)
                )
            ),
        ];

    [Fact]
    public async Task WhatIsGivenLaterReplacesTheThreadsValueWhole()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"), Reply("msg_c"));
        transport
            .Enqueue(() =>
            {
                var overloaded = transport.Response(
                    500,
                    ThreadError(null, "api_error"),
                    "application/json"
                );
                overloaded.Headers.Add("retry-after-ms", "1");
                return Task.FromResult(overloaded);
            })
            .EnqueueJson(200, Reply("msg_d"));
        var thread = Messages(transport)
            .WithOptions(options =>
                options with
                {
                    Timeout = TimeSpan.FromSeconds(30),
                    MaxRetries = 1,
                }
            )
            .Thread(WithHeaders(Params(), ("x-one", "thread"), ("x-two", "thread")));
        var cancellationToken = TestContext.Current.CancellationToken;

        await thread.Send(User("One"), cancellationToken);
        await thread.Send(
            [User("Two")],
            fields => WithHeaders(fields, ("x-one", "turn")),
            cancellationToken
        );
        await thread.Send(User("Three"), cancellationToken);
        thread.Update(fields => WithHeaders(fields, ("x-two", "updated")));
        await thread.Send(User("Four"), cancellationToken);

        Assert.Equal(["thread", "turn", "thread", "", ""], Header(transport, "x-one"));
        Assert.Equal(["thread", "", "thread", "updated", "updated"], Header(transport, "x-two"));

        // The timeout and the retries are those of the service the thread was created from.
        Assert.All(
            Header(transport, "x-stainless-timeout"),
            timeout => Assert.Equal("30", timeout)
        );
        Assert.Equal("msg_d", thread.PreviousMessageID);
    }

    [Theory]
    [InlineData("Send")]
    [InlineData("SendStreaming")]
    public async Task EveryRequestCarriesTheHelperTag(string entryPoint)
    {
        var transport = new FakeTransport();
        EnqueueReply(transport, entryPoint, "msg_a")
            .EnqueueJson(404, ThreadError("thread_not_found"));
        EnqueueReply(transport, entryPoint, "msg_b")
            .EnqueueJson(400, ThreadError("thread_unsupported_request"));
        EnqueueReply(transport, entryPoint, "msg_c");
        var thread = Messages(transport)
            .Thread(
                Params() with
                {
                    UnsupportedRequestBehavior = BetaUnsupportedRequestBehavior.ContinueUnthreaded,
                }
            );

        await Turn(thread, entryPoint, [User("One")]);
        await Turn(thread, entryPoint, [User("Two")]);
        await Turn(thread, entryPoint, [User("Three")]);

        AssertCreate(transport.JsonBodies[0]);
        AssertContinue(transport.JsonBodies[1], "msg_a");
        AssertCreate(transport.JsonBodies[2]);
        AssertContinue(transport.JsonBodies[3], "msg_b");
        Assert.False(transport.JsonBodies[4].ContainsKey("thread"));
        Assert.Equal(
            Enumerable.Repeat("message-thread", 5),
            Header(transport, "x-stainless-helper")
        );
    }

    [Fact]
    public async Task HelperTagJoinsTheCallersAndNoLaterHeadersDropIt()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"), Reply("msg_c"));
        var thread = Messages(transport)
            .Thread(WithHeaders(Params(), ("X-Stainless-Helper", "mine")));
        var cancellationToken = TestContext.Current.CancellationToken;

        await thread.Send(User("One"), cancellationToken);
        await thread.Send([User("Two")], fields => WithHeaders(fields), cancellationToken);
        thread.Update(fields =>
            WithHeaders(fields, ("x-stainless-helper", "message-thread, other"))
        );
        await thread.Send(User("Three"), cancellationToken);

        Assert.Equal(
            ["mine, message-thread", "message-thread", "message-thread, other"],
            Header(transport, "x-stainless-helper")
        );
    }

    [Fact]
    public async Task StagingTheReplyAsAParamIsANoOp()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());
        var reply = await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        thread.Append(
            new BetaAssistantMessageParam
            {
                Content = new BetaMessageContentParam(
                    JsonSerializer.SerializeToElement(reply.Content.Select(block => block.Json))
                ),
            }
        );
        Assert.Equal(2, thread.Messages.Count);
        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        Assert.Equal(["Again"], Texts(transport.JsonBodies[1]));
    }

    [Theory]
    [InlineData("Send")]
    [InlineData("SendStreaming")]
    [InlineData("Send on a typed thread")]
    [InlineData("Append")]
    public async Task ReplyGoesOutAsAnAssistantMessageWithItsContentAsTheApiSentIt(string method)
    {
        const string Content =
            """[{"type":"text","text":"Hi","a_later_field":1},{"type":"a_later_block","data":"x"}]""";
        var received = JsonNode.Parse(Reply("msg_a"))!;
        received["content"] = JsonNode.Parse(Content);
        var transport = Replies(received.ToJsonString());
        var reply = await Messages(transport)
            .Thread(Params())
            .Send(User("Hello"), TestContext.Current.CancellationToken);
        var thread = Messages(transport).Thread(Params());

        switch (method)
        {
            case "Send":
                transport.EnqueueJson(200, Reply("msg_b"));
                await thread.Send(reply, TestContext.Current.CancellationToken);
                break;
            case "SendStreaming":
                transport.EnqueueSse(WholeStream("msg_b"));
                await ReadToEnd(thread.SendStreaming(reply, TestContext.Current.CancellationToken));
                break;
            case "Send on a typed thread":
                transport.EnqueueJson(200, Reply("msg_b", text: """{"city":"Paris"}"""));
                await Messages(transport)
                    .Thread<Answer>(Params())
                    .Send(reply, TestContext.Current.CancellationToken);
                break;
            default:
                transport.EnqueueJson(200, Reply("msg_b"));
                thread.Append(reply);
                await thread.Send(TestContext.Current.CancellationToken);
                break;
        }

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(["assistant"], Roles(transport.JsonBodies[1]));
        Assert.Equal([Content], Texts(transport.JsonBodies[1]));
        Assert.Equal(
            ["content", "role"],
            transport.JsonBodies[1]["messages"]![0]!
                .AsObject()
                .Select(field => field.Key)
                .OrderBy(key => key, StringComparer.Ordinal)
        );
    }

    [Fact]
    public async Task StagingTheLastReplyIsANoOp()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());
        var reply = await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        thread.Append(reply);
        Assert.Equal(2, thread.Messages.Count);
        thread.Append(User("Again"));
        await thread.Send(reply, TestContext.Current.CancellationToken);

        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal(["Again"], Texts(transport.JsonBodies[1]));
        Assert.Equal(4, thread.Messages.Count);
    }

    [Fact]
    public async Task EarlierReplyIsStaged()
    {
        var transport = Replies(
            Reply("msg_a", text: "One"),
            Reply("msg_b", text: "Two"),
            Reply("msg_c")
        );
        var thread = Messages(transport).Thread(Params());
        var first = await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        var second = await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        thread.Append(first, second);
        await thread.Send(TestContext.Current.CancellationToken);

        AssertContinue(transport.JsonBodies[2], "msg_b");
        Assert.Equal(["assistant"], Roles(transport.JsonBodies[2]));
        Assert.Equal(["""[{"type":"text","text":"One"}]"""], Texts(transport.JsonBodies[2]));
    }

    [Fact]
    public async Task NullReplyIsRefused()
    {
        var thread = Messages(new FakeTransport()).Thread(Params());
        var cancellationToken = TestContext.Current.CancellationToken;

        Assert.Throws<ArgumentNullException>(() => thread.Append((BetaMessage[])null!));
        Assert.Throws<ArgumentNullException>(() =>
            thread.SendStreaming((BetaMessage)null!, cancellationToken)
        );
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            thread.Send((BetaMessage)null!, cancellationToken)
        );
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            Messages(new FakeTransport())
                .Thread<Answer>(Params())
                .Send((BetaMessage)null!, cancellationToken)
        );
    }

    [Theory]
    [InlineData("pause_turn")]
    [InlineData("compaction")]
    public async Task UnfinishedTurnResumesWithNoMessages(string stopReason)
    {
        var transport = Replies(Reply("msg_a", stopReason: stopReason), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        await thread.Send(TestContext.Current.CancellationToken);

        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Empty(transport.JsonBodies[1]["messages"]!.AsArray());
        Assert.Equal("msg_b", thread.PreviousMessageID);
    }

    [Fact]
    public async Task UnknownStopReasonPassesThrough()
    {
        var transport = Replies(Reply("msg_a", stopReason: "a_later_stop_reason"));
        var thread = Messages(transport).Thread(Params());

        var reply = await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        Assert.Equal("a_later_stop_reason", reply.StopReason!.Raw());
        Assert.Equal("msg_a", thread.PreviousMessageID);
    }

    [Fact]
    public async Task ContainerOfTheReplyIsSentOnLaterTurns()
    {
        var transport = Replies(Reply("msg_a", container: "container_1"), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());

        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        Assert.False(transport.JsonBodies[0].ContainsKey("container"));
        Assert.Equal("container_1", transport.JsonBodies[1]["container"]!.GetValue<string>());
    }

    [Fact]
    public async Task ContainerGivenByTheCallerIsKept()
    {
        var transport = Replies(Reply("msg_a", container: "container_1"), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params() with { Container = "container_mine" });

        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        Assert.Equal("container_mine", transport.JsonBodies[1]["container"]!.GetValue<string>());
    }

    [Fact]
    public async Task ForkOfAFinishedThreadSendsTheHistoryItHolds()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        var fork = thread.Fork();
        await fork.Send(TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(["user", "assistant"], Roles(transport.JsonBodies[1]));
        Assert.Equal(3, fork.Messages.Count);
        Assert.Equal(2, thread.Messages.Count);
    }

    [Fact]
    public async Task ForkKeepsTheLastMessage()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"), Reply("msg_c"));
        var thread = Messages(transport).Thread(Params());
        var reply = await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        var fork = thread.Fork();

        Assert.Same(reply, fork.LastMessage);
        fork.Append(reply);
        Assert.Equal(2, fork.Messages.Count);

        await thread.Send(User("On the source"), TestContext.Current.CancellationToken);

        Assert.Equal("msg_b", thread.LastMessage?.ID);
        Assert.Equal("msg_a", fork.LastMessage?.ID);

        await fork.Send(User("On the fork"), TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[2]);
        Assert.Equal(["user", "assistant", "user"], Roles(transport.JsonBodies[2]));
        Assert.Equal("msg_c", fork.LastMessage?.ID);
        Assert.Equal("msg_b", thread.LastMessage?.ID);
    }

    sealed class Answer
    {
        public string City { get; set; } = "";
    }

    static string City(string id, string city) => Reply(id, text: $$"""{"city":"{{city}}"}""");

    static string? CityOf(BetaStructuredMessage<Answer>? reply) =>
        Assert.Single(reply!.Content).Parsed()?.City;

    [Fact]
    public async Task TypedThreadKeepsItsUnsupportedRequestBehavior()
    {
        var transport = new FakeTransport()
            .EnqueueJson(400, ThreadError("thread_unsupported_request"))
            .EnqueueJson(200, City("msg_a", "Paris"));
        var thread = Messages(transport)
            .Thread<Answer>(
                Params() with
                {
                    UnsupportedRequestBehavior = BetaUnsupportedRequestBehavior.ContinueUnthreaded,
                }
            );

        var reply = await thread.Send(User("Where?"), TestContext.Current.CancellationToken);

        Assert.Equal("Paris", CityOf(reply));
        AssertCreate(transport.JsonBodies[0]);
        Assert.False(transport.JsonBodies[1].ContainsKey("thread"));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ThreadFromTheParamsKeepsTheUnsupportedRequestBehavior(bool typed)
    {
        var transport = new FakeTransport()
            .EnqueueJson(400, ThreadError("thread_unsupported_request"))
            .EnqueueJson(200, Reply("msg_a"));
        var service = Messages(transport);
        var given = Params() with
        {
            UnsupportedRequestBehavior = BetaUnsupportedRequestBehavior.ContinueUnthreaded,
        };
        var parameters = typed
            ? service.Thread<Answer>(given).Params
            : service.Thread(given).Params;

        await service.Thread(parameters).Send(User("Hello"), TestContext.Current.CancellationToken);

        Assert.Equal(given.UnsupportedRequestBehavior, parameters.UnsupportedRequestBehavior);
        AssertCreate(transport.JsonBodies[0]);
        Assert.False(transport.JsonBodies[1].ContainsKey("thread"));
    }

    static ThreadCreateParams ParamsWithEffort() =>
        Params() with
        {
            OutputConfig = new() { Effort = Effort.Low },
        };

    [Fact]
    public async Task TypedThreadSendsItsOutputFormatWithEveryTurn()
    {
        var transport = Replies(City("msg_a", "Paris"), City("msg_b", "Rome"))
            .EnqueueSse(WholeStream("msg_c", """{"city":"Oslo"}"""))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueJson(200, City("msg_d", "Lima"));
        var thread = Messages(transport).Thread<Answer>(ParamsWithEffort());
        var cancellationToken = TestContext.Current.CancellationToken;

        Assert.Null(thread.LastMessage);
        var first = await thread.Send(
            [User("Where?")],
            fields => fields with { MaxTokens = 16 },
            cancellationToken
        );
        var second = await thread.Send(User("Where else?"), cancellationToken);
        await ReadToEnd(thread.SendStreaming(User("And?"), cancellationToken));
        var streamed = thread.LastMessage;
        thread.Update(fields => fields with { MaxTokens = 2048 });
        thread.Append(User("One more"));
        var last = await thread.Send(cancellationToken);

        Assert.Equal(
            ["Paris", "Rome", "Oslo", "Lima"],
            new[] { first, second, streamed, last }.Select(CityOf)
        );
        Assert.Equal("msg_d", thread.PreviousMessageID);
        Assert.Equal(8, thread.Messages.Count);
        var bodies = transport.JsonBodies;
        AssertCreate(bodies[0]);
        AssertContinue(bodies[1], "msg_a");
        AssertContinue(bodies[2], "msg_b");
        AssertContinue(bodies[3], "msg_c");
        AssertCreate(bodies[4]);
        Assert.Equal(
            new JsonObject
            {
                ["effort"] = "low",
                ["format"] = JsonSerializer.SerializeToNode(
                    StructuredOutput.CreateBetaJsonFormat<Answer>(),
                    ModelBase.SerializerOptions
                ),
            }.ToJsonString(),
            bodies[0]["output_config"]!.ToJsonString()
        );
        Assert.All(
            bodies,
            body =>
            {
                Assert.True(JsonNode.DeepEquals(bodies[0]["output_config"], body["output_config"]));
                Assert.False(body.ContainsKey("output_format"));
            }
        );
        Assert.Equal([ThreadsBeta], Betas(transport, 0));
        Assert.Equal(
            [16, 1024, 1024, 2048, 2048],
            bodies.Select(body => body["max_tokens"]!.GetValue<int>())
        );
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ParamsOfATypedThreadCreateAThreadWithTheSameOutputConfig(bool typed)
    {
        var transport = Replies(City("msg_a", "Paris"), City("msg_b", "Rome"));
        var service = Messages(transport);
        var thread = service.Thread<Answer>(ParamsWithEffort());
        var cancellationToken = TestContext.Current.CancellationToken;
        await thread.Send(User("Where?"), cancellationToken);

        if (typed)
        {
            await service.Thread<Answer>(thread.Params).Send(User("Again"), cancellationToken);
        }
        else
        {
            await service.Thread(thread.Params).Send(User("Again"), cancellationToken);
        }

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(["user", "assistant", "user"], Roles(transport.JsonBodies[1]));
        Assert.Equal(
            transport.JsonBodies[0]["output_config"]!.ToJsonString(),
            transport.JsonBodies[1]["output_config"]!.ToJsonString()
        );
    }

    [Fact]
    public async Task ForkOfATypedThreadHasItsTypeAndItsOutputFormat()
    {
        var transport = Replies(City("msg_a", "Paris"), City("msg_b", "Rome"));
        var thread = Messages(transport).Thread<Answer>(Params());
        await thread.Send(User("Where?"), TestContext.Current.CancellationToken);

        var fork = thread.Fork();

        Assert.Equal("Paris", CityOf(fork.LastMessage));
        Assert.Equal(
            "Rome",
            CityOf(await fork.Send(User("Where else?"), TestContext.Current.CancellationToken))
        );
        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(
            transport.JsonBodies[0]["output_config"]!.ToJsonString(),
            transport.JsonBodies[1]["output_config"]!.ToJsonString()
        );
        Assert.Equal("msg_a", thread.PreviousMessageID);
        Assert.Equal("msg_b", fork.PreviousMessageID);
    }

    [Fact]
    public async Task StreamedTurnCreatesThenContinues()
    {
        var transport = new FakeTransport()
            .EnqueueSse(WholeStream("msg_a"))
            .EnqueueSse(WholeStream("msg_b", "Again"));
        var thread = Messages(transport).Thread(Params());

        var events = new List<string>();
        await foreach (
            var streamEvent in thread.SendStreaming(
                User("Hello"),
                TestContext.Current.CancellationToken
            )
        )
        {
            events.Add(streamEvent.Json.GetProperty("type").GetString()!);
        }
        await ReadToEnd(thread.SendStreaming(User("Again"), TestContext.Current.CancellationToken));

        Assert.Equal("message_start", events[0]);
        Assert.Equal("message_stop", events[^1]);
        AssertCreate(transport.JsonBodies[0]);
        Assert.True(transport.JsonBodies[0]["stream"]!.GetValue<bool>());
        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal(["Again"], Texts(transport.JsonBodies[1]));
        Assert.Equal("msg_b", thread.PreviousMessageID);
        Assert.Equal(
            "Again",
            Assert.Single(thread.LastMessage!.Content).Json.GetProperty("text").GetString()
        );
        Assert.Equal("end_turn", thread.LastMessage.StopReason!.Raw());
        Assert.All(transport.Issued, stream => Assert.True(stream.Disposed));
    }

    [Fact]
    public async Task NothingIsSentUntilTheStreamIsRead()
    {
        var transport = new FakeTransport();
        var thread = Messages(transport).Thread(Params());

        var stream = thread.SendStreaming(User("Hello"), TestContext.Current.CancellationToken);

        Assert.NotNull(stream);
        Assert.Equal(0, transport.RequestCount);
        Assert.Empty(thread.Messages);
        await Task.CompletedTask;
    }

    [Fact]
    public async Task StreamReplaysWhenTheThreadIsGone()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Reply("msg_a"))
            .EnqueueJson(404, ThreadError("thread_not_found"))
            .EnqueueSse(WholeStream("msg_b"));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        await ReadToEnd(thread.SendStreaming(User("Again"), TestContext.Current.CancellationToken));

        AssertContinue(transport.JsonBodies[1], "msg_a");
        AssertCreate(transport.JsonBodies[2]);
        Assert.True(transport.JsonBodies[2]["stream"]!.GetValue<bool>());
        Assert.Equal(["user", "assistant", "user"], Roles(transport.JsonBodies[2]));
        Assert.Equal("msg_b", thread.PreviousMessageID);
    }

    [Fact]
    public async Task FailedStreamRequestOfTheFirstTurnTakesBackItsMessage()
    {
        var transport = new FakeTransport()
            .EnqueueJson(500, ThreadError(null, "api_error"))
            .EnqueueSse(WholeStream("msg_a"));
        var thread = Messages(transport).Thread(Params());

        await Assert.ThrowsAnyAsync<AnthropicApiException>(async () =>
        {
            await ReadToEnd(
                thread.SendStreaming(User("Hello"), TestContext.Current.CancellationToken)
            );
        });
        Assert.Empty(thread.Messages);

        await ReadToEnd(thread.SendStreaming(User("Hello"), TestContext.Current.CancellationToken));

        Assert.Equal(["Hello"], Texts(transport.JsonBodies[1]));
        AssertCreate(transport.JsonBodies[1]);
    }

    [Theory]
    [InlineData("the body cannot be read")]
    [InlineData("an error event")]
    [InlineData("the caller stops reading")]
    public async Task StreamThatEndsBeforeMessageStartTakesBackItsMessage(string ending)
    {
        var transport = Replies(Reply("msg_a"));
        _ = ending switch
        {
            "the body cannot be read" => transport.EnqueueStreaming(new ThrowingStream()),
            "an error event" => transport.EnqueueSse(
                Event(
                    """{"type":"error","error":{"type":"overloaded_error","message":"Overloaded"}}"""
                )
            ),
            _ => transport.EnqueueSse(
                Event("""{"type":"an_event_of_a_later_api_version"}""") + WholeStream("msg_unread")
            ),
        };
        transport.EnqueueSse(WholeStream("msg_b"));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        try
        {
            await foreach (
                var _ in thread.SendStreaming(User("Again"), TestContext.Current.CancellationToken)
            )
            {
                break;
            }
        }
        catch (Exception e) when (IsStreamFailure(e)) { }

        Assert.Equal(["Hello"], UserTexts(thread.Messages));
        Assert.Equal("msg_a", thread.PreviousMessageID);

        await ReadToEnd(thread.SendStreaming(User("Again"), TestContext.Current.CancellationToken));

        AssertContinue(transport.JsonBodies[2], "msg_a");
        Assert.Equal(["Again"], Texts(transport.JsonBodies[2]));
    }

    [Fact]
    public async Task FailedCallAfterAPartialReplyLeavesTheThreadAsThePartialReplyLeftIt()
    {
        var transport = new FakeTransport()
            .EnqueueSse(MessageStart("msg_a") + TextStart(0) + TextDelta(0, "Par"))
            .EnqueueJson(400, ThreadError(null))
            .EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());
        await ReadUntilItEnds(
            thread.SendStreaming(User("Hello"), TestContext.Current.CancellationToken)
        );

        await Assert.ThrowsAsync<AnthropicBadRequestException>(() =>
            thread.Send(User("New"), TestContext.Current.CancellationToken)
        );

        Assert.Equal(["user", "assistant", "user"], Roles(transport.JsonBodies[1]));
        Assert.Equal(["user", "assistant"], thread.Messages.Select(message => message.Role.Raw()));
        Assert.Equal("msg_a", thread.LastMessage!.ID);

        await thread.Send(TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[2]);
        Assert.Equal(["Hello"], Texts(transport.JsonBodies[2]));
    }

    [Fact]
    public async Task StreamThatEndsWithoutMessageStopRecordsThePartialReply()
    {
        var cutOff =
            MessageStart("msg_a")
            + TextStart(0)
            + TextDelta(0, "Done. ")
            + BlockStop(0)
            + ToolUseStart(1, "toolu_1")
            + InputDelta(1, """{"city":"Par""");
        var transport = new FakeTransport().EnqueueSse(cutOff).EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());

        await ReadUntilItEnds(
            thread.SendStreaming(User("Hello"), TestContext.Current.CancellationToken)
        );

        Assert.Null(thread.PreviousMessageID);
        Assert.Equal(["user", "assistant"], thread.Messages.Select(message => message.Role.Raw()));
        var partial = Assert.Single(thread.LastMessage!.Content);
        Assert.Equal("Done. ", partial.Json.GetProperty("text").GetString());

        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(["user", "assistant", "user"], Roles(transport.JsonBodies[1]));
        Assert.Equal("msg_b", thread.PreviousMessageID);
    }

    [Theory]
    [InlineData("text", new[] { "", "Par" })]
    [InlineData("text without text", new[] { "" })]
    [InlineData("tool call", new[] { "" })]
    public async Task PartialReplyKeepsAFinishedTextBlockWithoutText(
        string unfinished,
        string[] recorded
    )
    {
        var cutOff =
            MessageStart("msg_a")
            + TextStart(0)
            + BlockStop(0)
            + unfinished switch
            {
                "text" => TextStart(1) + TextDelta(1, "Par"),
                "text without text" => TextStart(1),
                _ => ToolUseStart(1, "toolu_1") + InputDelta(1, """{"city":"Par"""),
            };
        var transport = new FakeTransport().EnqueueSse(cutOff).EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());

        await ReadUntilItEnds(
            thread.SendStreaming(User("Hello"), TestContext.Current.CancellationToken)
        );

        Assert.Equal(
            recorded,
            thread.LastMessage!.Content.Select(block => block.Json.GetProperty("text").GetString())
        );

        await thread.Send(User("Again"), TestContext.Current.CancellationToken);

        Assert.Equal(
            recorded,
            transport.JsonBodies[1]["messages"]![1]!["content"]!
                .AsArray()
                .Select(block => block!["text"]!.GetValue<string>())
        );
    }

    [Fact]
    public async Task CallerWhoStopsReadingKeepsTheOpenTextAndReleasesTheResponse()
    {
        var transport = new FakeTransport()
            .EnqueueSse(
                MessageStart("msg_a")
                    + TextStart(0)
                    + TextDelta(0, "Par")
                    + TextDelta(0, "tial")
                    + BlockStop(0)
                    + MessageEnd()
            )
            .EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());

        await foreach (
            var streamEvent in thread.SendStreaming(
                User("Hello"),
                TestContext.Current.CancellationToken
            )
        )
        {
            if (streamEvent.Json.GetProperty("type").GetString() == "content_block_delta")
            {
                break;
            }
        }

        Assert.Equal(
            "Par",
            Assert.Single(thread.LastMessage!.Content).Json.GetProperty("text").GetString()
        );
        Assert.Null(thread.PreviousMessageID);
        Assert.All(transport.Issued, stream => Assert.True(stream.Disposed));

        // With no message, the turn is sent again in place of the partial reply.
        await thread.Send(TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal(["Hello"], Texts(transport.JsonBodies[1]));
        Assert.Equal(["user", "assistant"], thread.Messages.Select(message => message.Role.Raw()));
        Assert.Equal("msg_b", thread.LastMessage!.ID);
    }

    [Fact]
    public async Task StreamCutOffBeforeAnyContentAddsNoReply()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Reply("msg_a"))
            .EnqueueSse(MessageStart("msg_b") + ToolUseStart(0, "toolu_1"))
            .EnqueueJson(200, Reply("msg_c"));
        var thread = Messages(transport).Thread(Params());
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);

        await foreach (
            var streamEvent in thread.SendStreaming(
                User("Again"),
                TestContext.Current.CancellationToken
            )
        )
        {
            if (streamEvent.Json.GetProperty("type").GetString() == "content_block_start")
            {
                break;
            }
        }

        Assert.Equal(
            ["user", "assistant", "user"],
            thread.Messages.Select(message => message.Role.Raw())
        );
        Assert.Null(thread.PreviousMessageID);
        Assert.Equal("msg_a", thread.LastMessage!.ID);

        await thread.Send(TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[2]);
        Assert.Equal(["user", "assistant", "user"], Roles(transport.JsonBodies[2]));
    }

    [Fact]
    public async Task SendDuringAStreamIsRefusedAndAppendIsStagedAfterTheReply()
    {
        var transport = new FakeTransport()
            .EnqueueSse(WholeStream("msg_a"))
            .EnqueueJson(200, Reply("msg_b"));
        var thread = Messages(transport).Thread(Params());

        var refused = 0;
        await foreach (
            var streamEvent in thread.SendStreaming(
                User("Hello"),
                TestContext.Current.CancellationToken
            )
        )
        {
            if (streamEvent.Json.GetProperty("type").GetString() != "content_block_start")
            {
                continue;
            }

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                thread.Send(User("Too early"), TestContext.Current.CancellationToken)
            );
            refused++;
            thread.Append(User("Later"));
            Assert.Equal(["user", "user"], thread.Messages.Select(message => message.Role.Raw()));
        }

        Assert.Equal(1, refused);
        Assert.Equal(1, transport.RequestCount);
        Assert.Equal(
            ["user", "assistant", "user"],
            thread.Messages.Select(message => message.Role.Raw())
        );

        await thread.Send(TestContext.Current.CancellationToken);

        AssertContinue(transport.JsonBodies[1], "msg_a");
        Assert.Equal(["Later"], Texts(transport.JsonBodies[1]));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ForkAfterAPartialReplySendsTheTurnAgainWhenGivenNoMessage(bool streaming)
    {
        var transport = new FakeTransport().EnqueueSse(
            MessageStart("msg_a") + TextStart(0) + TextDelta(0, "Par")
        );
        var thread = Messages(transport).Thread(Params());
        await ReadUntilItEnds(
            thread.SendStreaming(User("Hello"), TestContext.Current.CancellationToken)
        );

        var fork = thread.Fork();
        var forkOfTheFork = fork.Fork();
        var forkGivenAMessage = thread.Fork();
        foreach (var resent in new[] { fork, forkOfTheFork })
        {
            Assert.Equal("msg_a", resent.LastMessage!.ID);
            if (streaming)
            {
                transport.EnqueueSse(WholeStream("msg_b"));
                await ReadToEnd(resent.SendStreaming(TestContext.Current.CancellationToken));
            }
            else
            {
                transport.EnqueueJson(200, Reply("msg_b"));
                await resent.Send(TestContext.Current.CancellationToken);
            }

            AssertCreate(transport.JsonBodies[^1]);
            Assert.Equal(["Hello"], Texts(transport.JsonBodies[^1]));
            Assert.Equal(
                ["user", "assistant"],
                resent.Messages.Select(message => message.Role.Raw())
            );
            Assert.Equal("msg_b", resent.LastMessage!.ID);
        }

        transport.EnqueueJson(200, Reply("msg_c"));
        await forkGivenAMessage.Send(User("New"), TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[^1]);
        Assert.Equal(
            ["Hello", """[{"type":"text","text":"Par"}]""", "New"],
            Texts(transport.JsonBodies[^1])
        );
        Assert.Equal("msg_a", thread.LastMessage!.ID);
        Assert.Equal(["user", "assistant"], thread.Messages.Select(message => message.Role.Raw()));
    }

    [Fact]
    public async Task ForkAndItsSourceDoNotSeeEachOthersChanges()
    {
        var transport = Replies(Reply("msg_a"), Reply("msg_b"), Reply("msg_c"));
        var thread = Messages(transport).Thread(Params() with { System = "Be brief." });
        await thread.Send(User("Hello"), TestContext.Current.CancellationToken);
        thread.Append(User("Staged before the fork"));

        var fork = thread.Fork();
        thread.Append(User("On the source"));
        fork.Append(User("On the fork"));
        fork.Update(current => current with { System = "Be long." });

        Assert.Equal(
            ["Hello", "Staged before the fork", "On the source"],
            UserTexts(thread.Messages)
        );
        Assert.Equal(["Hello", "Staged before the fork", "On the fork"], UserTexts(fork.Messages));
        Assert.Equal("msg_a", thread.PreviousMessageID);

        await fork.Send(TestContext.Current.CancellationToken);
        await thread.Send(TestContext.Current.CancellationToken);

        AssertCreate(transport.JsonBodies[1]);
        Assert.Equal("Be long.", transport.JsonBodies[1]["system"]!.GetValue<string>());
        Assert.Equal(["user", "assistant", "user", "user"], Roles(transport.JsonBodies[1]));
        AssertContinue(transport.JsonBodies[2], "msg_a");
        Assert.False(transport.JsonBodies[2].ContainsKey("system"));
        Assert.Equal(["user", "user"], Roles(transport.JsonBodies[2]));
        Assert.Equal("msg_b", fork.LastMessage?.ID);
        Assert.Equal("msg_c", thread.LastMessage?.ID);
    }

    static string[] UserTexts(IEnumerable<BetaMessageParam> messages) =>
        [
            .. messages
                .Where(message => message.Role.Raw() == "user")
                .Select(message => message.Json.GetProperty("content").GetString()!),
        ];
}
