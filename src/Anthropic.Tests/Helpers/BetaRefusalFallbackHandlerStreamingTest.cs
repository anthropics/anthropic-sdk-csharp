using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Helpers;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Helpers;

/// <summary>
/// Tests for <see cref="BetaRefusalFallbackHandler"/>'s streaming splice.
///
/// <para><c>stream-a-refusal.sse</c> and <c>stream-b-fallback.sse</c> are wire-shaped synthetic
/// captures — fable refuses after a thinking + partial-text block and mints a credit token; the
/// fallback model then completes the message. <c>stream-a-toolrefusal.sse</c> is wire-shaped
/// synthetic <c>web_search</c> traffic with a refusal terminal grafted on (a benign prompt can't
/// elicit a mid-tool-loop refusal live).</para>
/// </summary>
[Collection("console stderr")]
public class BetaRefusalFallbackHandlerStreamingTest
{
    const string FallbackModel = "fallback-model";
    const string SecondModel = "second-model";
    const string FableModel = "claude-fable-5";

    const string InvalidRequestError =
        """{"type":"error","error":{"type":"invalid_request_error","message":"bad request"}}""";

    static readonly string StreamA = FallbackTestSupport.Fixture("stream-a-refusal.sse");
    static readonly string StreamB = FallbackTestSupport.Fixture("stream-b-fallback.sse");
    static readonly string StreamATool = FallbackTestSupport.Fixture("stream-a-toolrefusal.sse");

    // --- happy path ---

    [Fact]
    public async Task SplicesTheFallbackOntoTheRefusedStream()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        var events = await Consume(invoker);

        // A's thinking + text are forwarded, a fallback boundary block is emitted at the next
        // monotonic index, then B's blocks continue after it.
        Assert.Equal(
            [(0, "thinking"), (1, "text"), (2, "fallback"), (3, "text")],
            ContentBlockStarts(events)
        );

        // The fallback block carries the from/to model transition.
        var fallback = events.First(e =>
            Type(e) == "content_block_start" && BlockType(e) == "fallback"
        )["content_block"]!;
        Assert.Equal(FableModel, fallback["from"]?["model"]?.GetValue<string>());
        Assert.Equal(FallbackModel, fallback["to"]?["model"]?.GetValue<string>());

        // Exactly one message_start (A's) and one message_stop reach the client — B's
        // message_start is suppressed.
        Assert.Equal(1, events.Count(e => Type(e) == "message_start"));
        Assert.Equal(1, events.Count(e => Type(e) == "message_stop"));
        Assert.Equal(1, events.Count(e => Type(e) == "message_delta"));
    }

    [Fact]
    public async Task RewritesUsageIterationsToTheChainShape()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        var events = await Consume(invoker);

        var messageDelta = events.First(e => Type(e) == "message_delta");
        Assert.Equal("end_turn", StopReason(messageDelta));
        Assert.Equal(
            [("message", FableModel), ("fallback_message", FallbackModel)],
            Iterations(messageDelta)
        );
    }

    [Fact]
    public async Task BuildsTheHopRequestAsAContinuation()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        await Consume(invoker);

        Assert.Equal(2, transport.RequestCount);
        var bodyA = transport.JsonBodies[0];
        var bodyB = transport.JsonBodies[1];

        // Model swapped to the fallback, credit token from A's stop_details set.
        Assert.Equal(FallbackModel, bodyB["model"]?.GetValue<string>());
        Assert.NotEmpty(bodyB["fallback_credit_token"]!.GetValue<string>());

        // max_tokens untouched (any render-shaping change would 400).
        Assert.Equal(1024, bodyB["max_tokens"]?.GetValue<int>());

        // Original turn preserved; one assistant turn appended carrying the [thinking, text]
        // partial output as-is — the prefill claim authorizes it verbatim, so no client-side
        // filtering or trimming.
        var messages = (JsonArray)bodyB["messages"]!;
        Assert.Equal(2, messages.Count);
        Assert.True(JsonNode.DeepEquals(((JsonArray)bodyA["messages"]!)[0], messages[0]));
        var appended = (JsonObject)messages[1]!;
        Assert.Equal("assistant", appended["role"]?.GetValue<string>());
        Assert.Equal(
            ["thinking", "text"],
            ((JsonArray)appended["content"]!).Select(block => block?["type"]?.GetValue<string>())
        );
        Assert.NotEmpty(((JsonArray)appended["content"]!)[0]!["signature"]!.GetValue<string>());
    }

    [Fact]
    public async Task AppendsTheFallbackCreditBetaToTheOriginalAndHopRequests()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        await Consume(invoker);

        Assert.Equal(2, transport.RequestCount);
        for (var index = 0; index < transport.RequestCount; index++)
        {
            Assert.Equal(["fallback-credit-2026-06-01"], transport.BetaHeaderValues(index));
        }
    }

    [Fact]
    public async Task TrimsReplayedFallbackTurnFromTheInitialAndHopRequests()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        var body = StreamingBody();
        body["messages"] = new JsonArray(
            new JsonObject { ["role"] = "user", ["content"] = "hi" },
            new JsonObject
            {
                ["role"] = "assistant",
                ["content"] = new JsonArray(
                    FallbackTestSupport.Block(
                        new BetaThinkingBlockParam { Thinking = "hmm", Signature = "sig" }
                    ),
                    FallbackTestSupport.Block(
                        new BetaFallbackBlockParam
                        {
                            From = new BetaFallbackInfoParam { Model = "primary-model" },
                            To = new BetaFallbackInfoParam { Model = FallbackModel },
                        }
                    ),
                    FallbackTestSupport.Block(new BetaTextBlockParam { Text = "answer" })
                ),
            },
            new JsonObject { ["role"] = "user", ["content"] = "continue" }
        );
        HttpRequestMessage request = new(
            HttpMethod.Post,
            "https://api.example.com/v1/messages?beta=true"
        )
        {
            Content = new StringContent(body.ToJsonString(), Encoding.UTF8, "application/json"),
        };

        using var _ = BetaFallbackState.Create().Use();
        var response = await invoker.SendAsync(request, TestContext.Current.CancellationToken);
        await ReadBody(response);

        Assert.Equal(2, transport.RequestCount);
        // The initial request carries the trimmed turn, and the hop derives from the same
        // trimmed body — no fallback block goes back to the wire from either.
        foreach (var sentBody in transport.JsonBodies)
        {
            var replayed = (JsonObject)((JsonArray)sentBody["messages"]!)[1]!;
            var block = Assert.Single((JsonArray)replayed["content"]!);
            Assert.Equal("text", block?["type"]?.GetValue<string>());
        }
    }

    // --- edge cases ---

    [Fact]
    public async Task AnImmediateRefusalWithACreditTokenStillFallsBack()
    {
        // A refusal before any content block is just a chain with an empty partial: the hop
        // resends the original body with the token attached and the boundary block leads the
        // message.
        var immediateRefusal =
            MessageStartEvent() + RefusalDelta("tok_abc") + Event("""{"type":"message_stop"}""");
        var transport = new FakeTransport().EnqueueSse(immediateRefusal).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        var events = await Consume(invoker);

        Assert.Equal(2, transport.RequestCount);
        var bodyB = transport.JsonBodies[1];
        Assert.Equal("tok_abc", bodyB["fallback_credit_token"]?.GetValue<string>());
        Assert.True(JsonNode.DeepEquals(transport.JsonBodies[0]["messages"], bodyB["messages"]));

        // The boundary block leads, then the fallback's content follows at shifted indices.
        Assert.Equal([(0, "fallback"), (1, "text")], ContentBlockStarts(events));
        Assert.Equal("end_turn", StopReason(events.First(e => Type(e) == "message_delta")));
    }

    [Fact]
    public async Task ARefusalWithoutAPrefillClaimSendsTheSameBody()
    {
        // fallback_has_prefill_claim: false — the partial output may not be resent, so the
        // handler omits the prefill and resends the original body with just the token attached.
        var noClaim =
            MessageStartEvent()
            + Event(
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}"""
            )
            + Event(
                """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Partial. "}}"""
            )
            + Event("""{"type":"content_block_stop","index":0}""")
            + RefusalDelta("tok_abc", hasPrefillClaim: false)
            + Event("""{"type":"message_stop"}""");
        var transport = new FakeTransport().EnqueueSse(noClaim).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        await Consume(invoker);

        var bodyB = transport.JsonBodies[1];
        Assert.Equal("tok_abc", bodyB["fallback_credit_token"]?.GetValue<string>());
        // No appended assistant turn — identical messages (same-body form).
        Assert.True(JsonNode.DeepEquals(transport.JsonBodies[0]["messages"], bodyB["messages"]));
    }

    [Fact]
    public async Task ARefusalWithoutACreditTokenPassesThroughAndWarnsOnce()
    {
        var noToken = WithoutCreditToken(StreamA);
        var transport = new FakeTransport().EnqueueSse(noToken).EnqueueSse(noToken);
        using var invoker = Intercepted(transport, FallbackModel);

        List<JsonObject>? events = null;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            events = await Consume(invoker);
            await Consume(invoker);
        });

        // Only the original requests were made — no fallback — and the missing-token warning
        // can be steady-state (e.g. the beta isn't enabled), so it's rate-limited to once per
        // handler.
        Assert.Equal(2, transport.RequestCount);
        Assert.Single(stderr.Split('\n'), line => line.Contains("no fallback_credit_token"));

        // A passes through unchanged, ending in its own refusal (no fallback block).
        Assert.DoesNotContain(events!, e => BlockType(e) == "fallback");
        Assert.Equal("refusal", StopReason(events!.First(e => Type(e) == "message_delta")));
    }

    [Fact]
    public async Task A400OnThePrefillFormRetriesTheSameHopWithoutThePartial()
    {
        var transport = new FakeTransport()
            .EnqueueSse(StreamA)
            .EnqueueJson(400, InvalidRequestError)
            .EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        List<JsonObject>? events = null;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            events = await Consume(invoker);
        });

        // Attempt 1 appends A's partial; the 400 drops it and attempt 2 redeems the same token
        // against the unchanged body.
        Assert.Equal(3, transport.RequestCount);
        Assert.Contains("retrying without it", stderr);
        var body1 = transport.JsonBodies[1];
        var body2 = transport.JsonBodies[2];
        Assert.Equal(2, ((JsonArray)body1["messages"]!).Count);
        Assert.Equal(FallbackModel, body2["model"]?.GetValue<string>());
        Assert.True(
            JsonNode.DeepEquals(body1["fallback_credit_token"], body2["fallback_credit_token"])
        );
        Assert.True(JsonNode.DeepEquals(transport.JsonBodies[0]["messages"], body2["messages"]));

        // The recovered hop is not a failure: one boundary, a normal completion.
        Assert.DoesNotContain("fallback request to", stderr);
        Assert.Equal(1, events!.Count(e => BlockType(e) == "fallback"));
        Assert.Equal("end_turn", StopReason(events!.First(e => Type(e) == "message_delta")));
    }

    [Fact]
    public async Task AFailedFallbackRequestClosesWithTheHeldRefusal()
    {
        // Give A's refusal a real category/explanation, plus a field the splicer doesn't model
        // (context_management), to prove they thread through.
        var refusedA = StreamA
            .Replace(
                "\"category\":null,\"explanation\":null",
                "\"category\":\"safety\",\"explanation\":\"declined to help\""
            )
            .Replace(
                "{\"type\":\"message_delta\",",
                "{\"type\":\"message_delta\",\"context_management\":{\"applied_edits\":[]},"
            );
        var transport = new FakeTransport()
            .EnqueueSse(refusedA)
            .EnqueueJson(400, InvalidRequestError)
            .EnqueueJson(400, InvalidRequestError);
        using var invoker = Intercepted(transport, FallbackModel);

        List<JsonObject>? events = null;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            events = await Consume(invoker);
        });

        // The prefill form 400s, the same-body retry 400s too — only then does the hop count as
        // failed.
        Assert.Equal(3, transport.RequestCount);
        Assert.Contains($"fallback request to {FallbackModel} failed: HTTP 400", stderr);

        // The fallback boundary block was already emitted, then the held refusal message_delta +
        // message_stop close the stream.
        Assert.Contains(events!, e => BlockType(e) == "fallback");
        var messageDelta = events!.First(e => Type(e) == "message_delta");
        Assert.Equal("refusal", StopReason(messageDelta));
        Assert.Equal("message_stop", Type(events![^1]));

        // The held refusal is surfaced verbatim — category/explanation and the still-unredeemed
        // credit token — with recommended_model pointing at the last hop we tried.
        var stopDetails = messageDelta["delta"]!["stop_details"]!;
        Assert.Equal("safety", stopDetails["category"]?.GetValue<string>());
        Assert.Equal("declined to help", stopDetails["explanation"]?.GetValue<string>());
        Assert.Equal(FallbackModel, stopDetails["recommended_model"]?.GetValue<string>());
        Assert.NotEmpty(stopDetails["fallback_credit_token"]!.GetValue<string>());

        // Fields the splicer doesn't model survive the degraded close verbatim.
        Assert.IsType<JsonArray>(messageDelta["context_management"]?["applied_edits"]);
    }

    [Fact]
    public async Task AFallbackRequestThatThrowsClosesWithTheHeldRefusal()
    {
        var connectionReset = new IOException("connection reset");
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueFailure(connectionReset);
        using var invoker = Intercepted(transport, FallbackModel);

        List<JsonObject>? events = null;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            events = await Consume(invoker);
        });

        // The original error is reported.
        Assert.Contains($"fallback request to {FallbackModel} failed:", stderr);
        Assert.Contains("connection reset", stderr);

        // The stream still closes cleanly: boundary block, then the held refusal message_delta +
        // message_stop — not a hard stream error.
        var messageDelta = events!.First(e => Type(e) == "message_delta");
        Assert.Equal("refusal", StopReason(messageDelta));
        Assert.Equal("message_stop", Type(events![^1]));
    }

    [Fact]
    public async Task ClosingBeforeReadingReleasesTheInitialResponse()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA);
        using var invoker = Intercepted(transport, FallbackModel);

        var response = await Send(invoker, BetaFallbackState.Create());
        response.Dispose();

        Assert.True(Assert.Single(transport.Issued).Disposed);
    }

    [Fact]
    public async Task ClosingDuringAnInFlightHopReleasesItsResponseWhenItResolves()
    {
        TaskCompletionSource<bool> hopStarted = new(
            TaskCreationOptions.RunContinuationsAsynchronously
        );
        TaskCompletionSource<bool> closeDone = new(
            TaskCreationOptions.RunContinuationsAsynchronously
        );
        var cancellationToken = TestContext.Current.CancellationToken;
        FakeTransport transport = new();
        transport
            .EnqueueSse(StreamA)
            .Enqueue(async () =>
            {
                hopStarted.TrySetResult(true);
                await Task.WhenAny(closeDone.Task, Task.Delay(5_000, cancellationToken));
                return transport.Response(200, StreamB, "text/event-stream");
            });
        using var invoker = Intercepted(transport, FallbackModel);
        var response = await Send(invoker, BetaFallbackState.Create());

        // Close while the reader is blocked inside the hop request; the hop's response must
        // still be released once the request resolves.
        var body = await ReadStream(response);
        var reader = Task.Run(
            async () =>
            {
                var buffer = new byte[4096];
                while (await body.ReadAsync(buffer, cancellationToken) > 0) { }
            },
            cancellationToken
        );
        await Task.WhenAny(hopStarted.Task, Task.Delay(5_000, cancellationToken));
        Assert.True(hopStarted.Task.IsCompleted);
        response.Dispose();
        closeDone.TrySetResult(true);
        await Task.WhenAny(reader, Task.Delay(5_000, cancellationToken));

        Assert.True(reader.IsCompleted);
        Assert.Equal(2, transport.Issued.Count);
        Assert.True(transport.Issued[1].Disposed);
    }

    [Fact]
    public async Task WarnsOnceOnAContentDeltaTypeItCannotAccumulate()
    {
        // An unknown delta type can't be folded into the accumulated block, so the prefill may
        // not match the wire output — flagged once per type, while the delta itself still flows
        // to the client.
        var unknownDelta =
            MessageStartEvent()
            + Event(
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}"""
            )
            + Event(
                """{"type":"content_block_delta","index":0,"delta":{"type":"mystery_delta","mystery":"?"}}"""
            )
            + Event(
                """{"type":"content_block_delta","index":0,"delta":{"type":"mystery_delta","mystery":"!"}}"""
            )
            + Event("""{"type":"content_block_stop","index":0}""")
            + RefusalDelta("tok_abc")
            + Event("""{"type":"message_stop"}""");
        var transport = new FakeTransport().EnqueueSse(unknownDelta).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        List<JsonObject>? events = null;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            events = await Consume(invoker);
        });

        Assert.Single(stderr.Split('\n'), line => line.Contains("mystery_delta"));
        Assert.Equal(
            2,
            events!.Count(e => e["delta"]?["type"]?.GetValue<string>() == "mystery_delta")
        );
    }

    [Fact]
    public async Task PassthroughPreservesSseFieldsTheParserSurfaces()
    {
        var wire =
            "retry: 1500\n"
            + "event: message_start\n"
            + "data: "
            + """{"type":"message_start","message":{"id":"msg_a","type":"message","role":"assistant","model":"claude-fable-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":1}}}"""
            + "\n\n"
            + ": keep-alive\nid: 42\nevent: message_delta\n"
            + "data: "
            + """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":3}}"""
            + "\n\n"
            + "event: message_stop\ndata: "
            + """{"type":"message_stop"}"""
            + "\n\n";
        var transport = new FakeTransport().EnqueueSse(wire);
        using var invoker = Intercepted(transport, FallbackModel);

        var response = await Send(invoker, BetaFallbackState.Create());
        var body = await ReadBody(response);

        // Unlike the Java splicer (which forwards raw wire lines), the splice re-frames events
        // from the parsed SSE items: `id:` and `retry:` survive, comment lines are dropped.
        Assert.Equal(wire.Replace(": keep-alive\n", ""), body);
    }

    [Fact]
    public async Task ANonRefusalStreamIsPassedThroughUntouched()
    {
        var normal =
            MessageStartEvent()
            + Event(
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}"""
            )
            + Event(
                """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Sure!"}}"""
            )
            + Event("""{"type":"content_block_stop","index":0}""")
            + Event(
                """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":3}}"""
            )
            + Event("""{"type":"message_stop"}""");
        var transport = new FakeTransport().EnqueueSse(normal);
        using var invoker = Intercepted(transport, FallbackModel);

        var response = await Send(invoker, BetaFallbackState.Create());

        Assert.Equal(normal, await ReadBody(response));
        Assert.Equal(1, transport.RequestCount);
    }

    [Fact]
    public async Task HopEventsAreForwardedAsTheyArrive()
    {
        // The hop's body arrives through a producer stream so the test controls pacing: a delta
        // written while the hop stream is still open must come out of the spliced stream before
        // any further bytes (or the terminal events) are written. A splice that buffers the hop
        // would time out here.
        ProducerStream hopBody = new();
        var immediateRefusal =
            MessageStartEvent() + RefusalDelta("tok_abc") + Event("""{"type":"message_stop"}""");
        var transport = new FakeTransport().EnqueueSse(immediateRefusal).EnqueueStreaming(hopBody);
        using var invoker = Intercepted(transport, FallbackModel);

        var cancellationToken = TestContext.Current.CancellationToken;
        var response = await Send(invoker, BetaFallbackState.Create());
        var body = await ReadStream(response);
        StringBuilder received = new();
        var consumer = Task.Run(
            async () =>
            {
                var buffer = new byte[4096];
                int count;
                while ((count = await body.ReadAsync(buffer, cancellationToken)) > 0)
                {
                    lock (received)
                    {
                        received.Append(Encoding.UTF8.GetString(buffer, 0, count));
                    }
                }
            },
            cancellationToken
        );

        async Task AwaitReceived(string text)
        {
            var deadline = DateTime.UtcNow + TimeSpan.FromSeconds(5);
            while (true)
            {
                lock (received)
                {
                    if (received.ToString().Contains(text))
                    {
                        return;
                    }
                    if (DateTime.UtcNow > deadline)
                    {
                        throw new InvalidOperationException(
                            $"Timed out waiting for {text} in: {received}"
                        );
                    }
                }
                await Task.Delay(10, cancellationToken);
            }
        }

        hopBody.Produce(
            MessageStartEvent()
                + Event(
                    """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}"""
                )
                + Event(
                    """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"First chunk"}}"""
                )
        );
        await AwaitReceived("First chunk");

        hopBody.Produce(
            Event("""{"type":"content_block_stop","index":0}""")
                + Event(
                    """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":3}}"""
                )
                + Event("""{"type":"message_stop"}""")
        );
        hopBody.Complete();
        await Task.WhenAny(consumer, Task.Delay(5_000, cancellationToken));
        await AwaitReceived("message_stop");
    }

    // --- fallback-state pinning ---

    [Fact]
    public async Task PinsTheStateToTheHopThatServed()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);
        var fallbackState = BetaFallbackState.Create();

        await Consume(invoker, fallbackState);

        Assert.Equal(0, fallbackState.Index);
    }

    [Fact]
    public async Task APinnedStateStartsOnThePinnedEntryAndChainsPastIt()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel, SecondModel);
        var fallbackState = BetaFallbackState.Create();
        fallbackState.Index = 0;

        await Consume(invoker, fallbackState);

        Assert.Equal(2, transport.RequestCount);
        // The initial request already carries the pinned entry's params; the mid-stream refusal
        // then chains to the entry after the pin.
        Assert.Equal(FallbackModel, transport.JsonBodies[0]["model"]?.GetValue<string>());
        Assert.Equal(SecondModel, transport.JsonBodies[1]["model"]?.GetValue<string>());
        Assert.Equal(1, fallbackState.Index);
    }

    [Fact]
    public async Task AFullyPinnedChainPassesTheStreamThroughUnwrapped()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA);
        using var invoker = Intercepted(transport, FallbackModel);
        var fallbackState = BetaFallbackState.Create();
        fallbackState.Index = 0;

        var response = await Send(invoker, fallbackState);

        // With nothing to hop to, the response isn't even wrapped — no per-event
        // decode/re-encode overhead, and no error: this is the steady state of a fully-pinned
        // chain.
        Assert.Equal(1, transport.RequestCount);
        Assert.Equal(StreamA, await ReadBody(response));
    }

    [Fact]
    public async Task WarnsOnceWhenFallingBackWithoutState()
    {
        var transport = new FakeTransport()
            .EnqueueSse(StreamA)
            .EnqueueSse(StreamB)
            .EnqueueSse(StreamA)
            .EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            await Consume(invoker, state: null);
            await Consume(invoker, state: null);
        });

        Assert.Equal(4, transport.RequestCount);
        Assert.Single(stderr.Split('\n'), line => line.Contains("BetaFallbackState"));
    }

    // --- fallback chain ---

    /// <summary>
    /// A fallback hop that contributes one text block, then refuses with a fresh token.
    /// </summary>
    static string HopRefusal() =>
        MessageStartEvent()
        + Event(
            """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}"""
        )
        + Event(
            """{"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Partial from B. "}}"""
        )
        + Event("""{"type":"content_block_stop","index":0}""")
        + RefusalDelta("tok_b")
        + Event("""{"type":"message_stop"}""");

    [Fact]
    public async Task ARefusedHopSplicesItsPartialAndChainsToTheNextEntry()
    {
        var transport = new FakeTransport()
            .EnqueueSse(StreamA)
            .EnqueueSse(HopRefusal())
            .EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel, SecondModel);

        var events = await Consume(invoker);

        Assert.Equal(3, transport.RequestCount);

        // Hop 1 redeems A's token; hop 2 redeems the fresh token minted by hop 1's refusal,
        // with hop 1's partial extending the same turn as-is.
        var body1 = transport.JsonBodies[1];
        var body2 = transport.JsonBodies[2];
        Assert.Equal(FallbackModel, body1["model"]?.GetValue<string>());
        Assert.Equal(SecondModel, body2["model"]?.GetValue<string>());
        Assert.Equal("tok_b", body2["fallback_credit_token"]?.GetValue<string>());
        Assert.False(
            JsonNode.DeepEquals(body1["fallback_credit_token"], body2["fallback_credit_token"])
        );
        var content1 = (JsonArray)((JsonArray)body1["messages"]!)[1]!["content"]!;
        var content2 = (JsonArray)((JsonArray)body2["messages"]!)[1]!["content"]!;
        Assert.Equal(content1.Count + 1, content2.Count);
        Assert.Equal("Partial from B. ", content2[content2.Count - 1]?["text"]?.GetValue<string>());

        // One continuous message: A's blocks, boundary, hop 1's partial, boundary, hop 2's
        // blocks — indices stay monotonic across all three streams.
        Assert.Equal(
            [
                (0, "thinking"),
                (1, "text"),
                (2, "fallback"),
                (3, "text"),
                (4, "fallback"),
                (5, "text"),
            ],
            ContentBlockStarts(events)
        );
        var boundaries = events
            .Where(e => Type(e) == "content_block_start" && BlockType(e) == "fallback")
            .Select(e => e["content_block"]!)
            .ToList();
        Assert.Equal(FableModel, boundaries[0]["from"]?["model"]?.GetValue<string>());
        Assert.Equal(FallbackModel, boundaries[0]["to"]?["model"]?.GetValue<string>());
        Assert.Equal(FallbackModel, boundaries[1]["from"]?["model"]?.GetValue<string>());
        Assert.Equal(SecondModel, boundaries[1]["to"]?["model"]?.GetValue<string>());

        // Hop 1's refusal delta is suppressed; the terminal delta carries every hop.
        var deltas = events.Where(e => Type(e) == "message_delta").ToList();
        var delta = Assert.Single(deltas);
        Assert.Equal("end_turn", StopReason(delta));
        Assert.Equal(
            [
                ("message", FableModel),
                ("message", FallbackModel),
                ("fallback_message", SecondModel),
            ],
            Iterations(delta)
        );
        Assert.Equal(1, events.Count(e => Type(e) == "message_stop"));
    }

    [Fact]
    public async Task AnHttpFailedHopIsSkippedAndTheUnredeemedTokenCarriesToTheNextEntry()
    {
        var transport = new FakeTransport()
            .EnqueueSse(StreamA)
            .EnqueueJson(
                529,
                """{"type":"error","error":{"type":"overloaded_error","message":"later"}}"""
            )
            .EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel, SecondModel);

        List<JsonObject>? events = null;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            events = await Consume(invoker);
        });

        Assert.Contains($"fallback request to {FallbackModel} failed: HTTP 529", stderr);
        Assert.Equal(3, transport.RequestCount);

        // Same token and continuation — the failed hop never redeemed them.
        var body1 = transport.JsonBodies[1];
        var body2 = transport.JsonBodies[2];
        Assert.Equal(SecondModel, body2["model"]?.GetValue<string>());
        Assert.True(
            JsonNode.DeepEquals(body1["fallback_credit_token"], body2["fallback_credit_token"])
        );
        Assert.True(JsonNode.DeepEquals(body1["messages"], body2["messages"]));

        // Both boundaries are from A — the failed hop contributed no output.
        var boundaries = events!
            .Where(e => Type(e) == "content_block_start" && BlockType(e) == "fallback")
            .Select(e =>
                (
                    e["content_block"]?["from"]?["model"]?.GetValue<string>(),
                    e["content_block"]?["to"]?["model"]?.GetValue<string>()
                )
            )
            .ToList();
        Assert.Equal([(FableModel, FallbackModel), (FableModel, SecondModel)], boundaries);

        // The failed hop is absent from iterations (no usage came back).
        var delta = events!.First(e => Type(e) == "message_delta");
        Assert.Equal("end_turn", StopReason(delta));
        Assert.Equal(
            [("message", FableModel), ("fallback_message", SecondModel)],
            Iterations(delta)
        );
    }

    [Fact]
    public async Task ATerminalRefusalWithNoEntriesLeftIsEmittedWithTheFullIterationChain()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(HopRefusal());
        using var invoker = Intercepted(transport, FallbackModel);

        var events = await Consume(invoker);

        Assert.Equal(2, transport.RequestCount);
        var delta = events.First(e => Type(e) == "message_delta");
        Assert.Equal("refusal", StopReason(delta));
        // The fresh token reaches the client for a manual retry.
        Assert.Equal(
            "tok_b",
            delta["delta"]?["stop_details"]?["fallback_credit_token"]?.GetValue<string>()
        );
        // Both hops refused, so both keep the refused-hop label — `fallback_message` marks only
        // a hop that served.
        Assert.Equal([("message", FableModel), ("message", FallbackModel)], Iterations(delta));
    }

    [Fact]
    public async Task AHeldRefusalReportsEveryAccumulatedHop()
    {
        // The initial refusal chains to hop 1, which refuses with a fresh token; hop 2's request
        // then fails outright, so hop 1's refusal is held — its terminal delta must still report
        // the whole chain, not just hop 1's self-report.
        var transport = new FakeTransport()
            .EnqueueSse(StreamA)
            .EnqueueSse(HopRefusal())
            .EnqueueFailure(new IOException("connection reset"));
        using var invoker = Intercepted(transport, FallbackModel, SecondModel);

        List<JsonObject>? events = null;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            events = await Consume(invoker);
        });

        Assert.Contains($"fallback request to {SecondModel} failed", stderr);
        var delta = events!.First(e => Type(e) == "message_delta");
        Assert.Equal("refusal", StopReason(delta));
        Assert.Equal(
            "tok_b",
            delta["delta"]?["stop_details"]?["fallback_credit_token"]?.GetValue<string>()
        );
        Assert.Equal(
            SecondModel,
            delta["delta"]?["stop_details"]?["recommended_model"]?.GetValue<string>()
        );
        // Nobody served, so every hop keeps the refused-hop label.
        Assert.Equal([("message", FableModel), ("message", FallbackModel)], Iterations(delta));
    }

    [Fact]
    public async Task HopRequestsCarryThePinnedEntryOverrides()
    {
        // The credit token is minted against the body actually sent — the pinned entry's
        // overrides included — so the hop body must keep them to stay redeemable.
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        var handler = new BetaRefusalFallbackHandler
        {
            Fallbacks =
            [
                BetaFallbackParam.FromRawUnchecked(
                    new Dictionary<string, JsonElement>
                    {
                        ["model"] = JsonSerializer.SerializeToElement(FallbackModel),
                        ["max_tokens"] = JsonSerializer.SerializeToElement(99),
                    }
                ),
                new BetaFallbackParam(SecondModel),
            ],
            InnerHandler = transport,
        };
        using HttpMessageInvoker invoker = new(handler);
        var fallbackState = BetaFallbackState.Create();
        fallbackState.Index = 0;

        await Consume(invoker, fallbackState);

        Assert.Equal(2, transport.RequestCount);
        Assert.Equal(99, transport.JsonBodies[0]["max_tokens"]?.GetValue<int>());
        Assert.Equal(99, transport.JsonBodies[1]["max_tokens"]?.GetValue<int>());
        Assert.Equal(SecondModel, transport.JsonBodies[1]["model"]?.GetValue<string>());
    }

    [Fact]
    public async Task IterationEntriesKeepUnmodeledUsageFields()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        var events = await Consume(invoker);

        var iterations = (JsonArray)
            events.First(e => Type(e) == "message_delta")["usage"]!["iterations"]!;
        // The fixture refusal reports thinking tokens; copying the wire usage keeps them.
        Assert.Equal(
            67,
            iterations[0]?["output_tokens_details"]?["thinking_tokens"]?.GetValue<int>()
        );
        // A hop's self-reported chain doesn't nest.
        Assert.All(
            iterations,
            iteration => Assert.False(((JsonObject)iteration!).ContainsKey("iterations"))
        );
    }

    [Fact]
    public async Task AccumulatesChunkedSignatureDeltas()
    {
        var chunkedSignature =
            MessageStartEvent()
            + Event(
                """{"type":"content_block_start","index":0,"content_block":{"type":"thinking","thinking":"","signature":""}}"""
            )
            + Event(
                """{"type":"content_block_delta","index":0,"delta":{"type":"thinking_delta","thinking":"hm"}}"""
            )
            + Event(
                """{"type":"content_block_delta","index":0,"delta":{"type":"signature_delta","signature":"abc"}}"""
            )
            + Event(
                """{"type":"content_block_delta","index":0,"delta":{"type":"signature_delta","signature":"def"}}"""
            )
            + Event("""{"type":"content_block_stop","index":0}""")
            + RefusalDelta("tok_abc")
            + Event("""{"type":"message_stop"}""");
        var transport = new FakeTransport().EnqueueSse(chunkedSignature).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        await Consume(invoker);

        // The prefill must match the wire output verbatim — a chunked signature is the
        // concatenation of its deltas, like every other accumulated delta type.
        var appended = (JsonObject)((JsonArray)transport.JsonBodies[1]["messages"]!)[1]!;
        var thinking = ((JsonArray)appended["content"]!)[0]!;
        Assert.Equal("abcdef", thinking["signature"]?.GetValue<string>());
    }

    [Fact]
    public async Task DoesNotPinWhenTheChainExhaustsOnARefusal()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(HopRefusal());
        using var invoker = Intercepted(transport, FallbackModel);
        var fallbackState = BetaFallbackState.Create();

        await Consume(invoker, fallbackState);

        // The hop refused; follow-up requests should start back at the original params, not at
        // a model that just refused.
        Assert.Equal(-1, fallbackState.Index);
    }

    [Fact]
    public async Task TheAggregatedMessageCarriesTheIterationsChain()
    {
        var transport = new FakeTransport().EnqueueSse(StreamA).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);
        var events = await Consume(invoker);

        BetaMessageContentAggregator aggregator = new();
        await foreach (var unused in aggregator.CollectAsync(ToStreamEvents(events))) { }
        var message = aggregator.Message();

        Assert.Equal(FallbackModel, message.Model.Raw());
        Assert.NotNull(message.Usage.OutputTokensDetails);
        var iterations = message.Usage.Iterations!;
        Assert.Equal(2, iterations.Count);
        Assert.True(iterations[0].TryPickBetaMessageIterationUsage(out var refused));
        Assert.Equal(FableModel, refused!.Model.Raw());
        Assert.True(iterations[1].TryPickBetaFallbackMessageIterationUsage(out var served));
        Assert.Equal(FallbackModel, served!.Model.Raw());
    }

    static async IAsyncEnumerable<BetaRawMessageStreamEvent> ToStreamEvents(List<JsonObject> events)
    {
        await Task.CompletedTask;
        foreach (var @event in events)
        {
            yield return JsonSerializer.Deserialize<BetaRawMessageStreamEvent>(
                @event.ToJsonString(),
                ModelBase.SerializerOptions
            )!;
        }
    }

    // --- tool-use refusals ---

    [Fact]
    public async Task AToolUseRefusalContinuationReassemblesToolInputsFromTheirDeltas()
    {
        var transport = new FakeTransport().EnqueueSse(StreamATool).EnqueueSse(StreamB);
        using var invoker = Intercepted(transport, FallbackModel);

        var events = await Consume(invoker);

        Assert.Equal(
            [
                (0, "server_tool_use"),
                (1, "web_search_tool_result"),
                (2, "text"),
                (3, "fallback"),
                (4, "text"),
            ],
            ContentBlockStarts(events)
        );

        var appended = (JsonObject)((JsonArray)transport.JsonBodies[1]["messages"]!)[1]!;
        var content = (JsonArray)appended["content"]!;
        Assert.Equal(
            ["server_tool_use", "web_search_tool_result", "text"],
            content.Select(block => block?["type"]?.GetValue<string>())
        );
        // The tool input is the parsed input_json_delta payload, not the empty `{}` from
        // content_block_start.
        var toolUse = content[0]!;
        Assert.Equal("srvtoolu_fixture_a_0001", toolUse["id"]?.GetValue<string>());
        Assert.Equal("web_search", toolUse["name"]?.GetValue<string>());
        Assert.Equal(
            "solar eclipse viewing safety news 2026",
            toolUse["input"]?["query"]?.GetValue<string>()
        );
        // The result block keeps its pairing id.
        Assert.Equal("srvtoolu_fixture_a_0001", content[1]?["tool_use_id"]?.GetValue<string>());
    }

    // --- helpers ---

    static HttpMessageInvoker Intercepted(FakeTransport transport, params string[] fallbackModels)
    {
        var handler = new BetaRefusalFallbackHandler
        {
            Fallbacks = [.. fallbackModels.Select(model => new BetaFallbackParam(model))],
            InnerHandler = transport,
        };
        return new HttpMessageInvoker(handler);
    }

    static string MessageStartEvent() =>
        Event(
            """{"type":"message_start","message":{"id":"msg_a","type":"message","role":"assistant","model":"claude-fable-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":12,"output_tokens":1}}}"""
        );

    static string RefusalDelta(string? token, bool hasPrefillClaim = true)
    {
        var tokenJson = token == null ? "null" : $"\"{token}\"";
        var claimJson = hasPrefillClaim ? "true" : "false";
        return Event(
            """{"type":"message_delta","delta":{"stop_reason":"refusal","stop_sequence":null,"stop_details":{"type":"refusal","category":null,"explanation":null,"fallback_credit_token":"""
                + tokenJson
                + ""","fallback_has_prefill_claim":"""
                + claimJson
                + """}},"usage":{"output_tokens":20}}"""
        );
    }

    /// <summary>Serializes one event payload as an SSE frame (its <c>type</c> is the event
    /// name).</summary>
    static string Event(string data) =>
        $"event: {JsonNode.Parse(data)!["type"]!.GetValue<string>()}\ndata: {data}\n\n";

    static string? Type(JsonObject @event) => @event["type"]?.GetValue<string>();

    static string? BlockType(JsonObject @event) =>
        @event["content_block"]?["type"]?.GetValue<string>();

    static string? StopReason(JsonObject messageDelta) =>
        messageDelta["delta"]?["stop_reason"]?.GetValue<string>();

    static List<(int Index, string? BlockType)> ContentBlockStarts(List<JsonObject> events) =>
        [
            .. events
                .Where(e => Type(e) == "content_block_start")
                .Select(e => (e["index"]!.GetValue<int>(), BlockType(e))),
        ];

    static List<(string? Type, string? Model)> Iterations(JsonObject messageDelta) =>
        [
            .. ((JsonArray)messageDelta["usage"]!["iterations"]!).Select(iteration =>
                (iteration?["type"]?.GetValue<string>(), iteration?["model"]?.GetValue<string>())
            ),
        ];

    static JsonObject StreamingBody() =>
        new()
        {
            ["model"] = "primary-model",
            ["max_tokens"] = 1024,
            ["messages"] = new JsonArray(new JsonObject { ["role"] = "user", ["content"] = "hi" }),
            ["stream"] = true,
        };

    static HttpRequestMessage StreamingRequest() =>
        new(HttpMethod.Post, "https://api.example.com/v1/messages?beta=true")
        {
            Content = new StringContent(
                StreamingBody().ToJsonString(),
                Encoding.UTF8,
                "application/json"
            ),
        };

    /// <summary>
    /// Executes a streaming request inside the given state's scope (or none when <c>null</c> —
    /// only for tests asserting on the missing-state warning).
    /// </summary>
    static async Task<HttpResponseMessage> Send(
        HttpMessageInvoker invoker,
        BetaFallbackState? state
    )
    {
        if (state == null)
        {
            return await invoker.SendAsync(
                StreamingRequest(),
                TestContext.Current.CancellationToken
            );
        }
        using var _ = state.Use();
        return await invoker.SendAsync(StreamingRequest(), TestContext.Current.CancellationToken);
    }

    /// <summary>Executes a streaming request and decodes the spliced SSE events.</summary>
    static async Task<List<JsonObject>> Consume(HttpMessageInvoker invoker) =>
        await Consume(invoker, BetaFallbackState.Create());

    static async Task<List<JsonObject>> Consume(
        HttpMessageInvoker invoker,
        BetaFallbackState? state
    ) => FallbackTestSupport.ParseEvents(await ReadBody(await Send(invoker, state)));

    static async Task<string> ReadBody(HttpResponseMessage response) =>
        await response.Content.ReadAsStringAsync(
#if NET
            TestContext.Current.CancellationToken
#endif
        );

    static async Task<Stream> ReadStream(HttpResponseMessage response) =>
        await response.Content.ReadAsStreamAsync(
#if NET
            TestContext.Current.CancellationToken
#endif
        );

    /// <summary>Nulls out the fixture refusal's <c>fallback_credit_token</c> value.</summary>
    static string WithoutCreditToken(string sse)
    {
        const string prefix = "\"fallback_credit_token\":\"";
        var start = sse.IndexOf(prefix, StringComparison.Ordinal);
        var end = sse.IndexOf('"', start + prefix.Length);
        return sse.Remove(start, end + 1 - start).Insert(start, "\"fallback_credit_token\":null");
    }
}
