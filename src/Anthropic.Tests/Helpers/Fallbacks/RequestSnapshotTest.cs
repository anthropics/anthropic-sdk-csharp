using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Anthropic.Helpers;
using Anthropic.Helpers.Fallbacks;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Helpers.Fallbacks;

public class RequestSnapshotTest
{
    static readonly Uri Uri = new("https://example.test/v1/messages");

    static readonly FallbackDiagnostics Quiet = new(TextWriter.Null);

    static BetaFallbackParam Entry(string json) =>
        JsonSerializer.Deserialize<BetaFallbackParam>(json)!;

    static RequestSnapshot Snapshot(
        string body = """{"model": "original", "max_tokens": 10}""",
        IReadOnlyList<BetaFallbackParam>? entries = null,
        int initialIndex = -1,
        BetaFallbackState? state = null,
        IReadOnlyList<KeyValuePair<string, string[]>>? headers = null,
        FallbackDiagnostics? diagnostics = null
    )
    {
        using HttpRequestMessage request = new(HttpMethod.Post, Uri);
        return new RequestSnapshot(Uri, request)
        {
            Entries = entries ?? [Entry("""{"model": "fallback"}""")],
            Diagnostics = diagnostics ?? Quiet,
            Headers = headers ?? [new("x-custom", ["v"])],
            ContentHeaders = [new("Content-Type", ["application/json"])],
            BodyBytes = Encoding.UTF8.GetBytes(body),
            State = state,
            InitialIndex = initialIndex,
            IsStreaming = false,
        };
    }

    /// <summary>A transport answering with the given statuses, in order.</summary>
    static FakeTransport Transport(params int[] statuses)
    {
        FakeTransport transport = new();
        foreach (var status in statuses)
        {
            transport.EnqueueJson(status, "{}");
        }
        return transport;
    }

    static async Task Send(
        RequestSnapshot snapshot,
        FakeTransport transport,
        int index,
        string? fallbackCreditToken = null
    )
    {
        using HttpMessageInvoker invoker = new(transport);
        using var response = await snapshot.Send(
            invoker.SendAsync,
            index,
            fallbackCreditToken,
            TestContext.Current.CancellationToken
        );
    }

    static async Task SendHop(
        RequestSnapshot snapshot,
        FakeTransport transport,
        int index,
        string fallbackCreditToken,
        IReadOnlyList<JsonObject> continuation
    )
    {
        using HttpMessageInvoker invoker = new(transport);
        using var response = await snapshot.SendHop(
            invoker.SendAsync,
            index,
            fallbackCreditToken,
            continuation,
            static () => false,
            TestContext.Current.CancellationToken
        );
    }

    static async Task<JsonObject> Body(
        RequestSnapshot snapshot,
        int index,
        string? fallbackCreditToken = null
    )
    {
        var transport = Transport(200);
        await Send(snapshot, transport, index, fallbackCreditToken);
        return transport.JsonBodies[0];
    }

    static async Task<JsonObject> HopBody(
        RequestSnapshot snapshot,
        int index,
        string fallbackCreditToken,
        IReadOnlyList<JsonObject> continuation
    )
    {
        var transport = Transport(200);
        await SendHop(snapshot, transport, index, fallbackCreditToken, continuation);
        return transport.JsonBodies[0];
    }

    [Fact]
    public async Task OriginalRequestKeepsTheBodyBytesVerbatim()
    {
        // Odd spacing is preserved because index -1 sends the snapshot bytes untouched.
        var snapshot = Snapshot(body: """{ "model" : "original",   "max_tokens":10 }""");

        var transport = Transport(200);
        await Send(snapshot, transport, -1);

        Assert.Equal("""{ "model" : "original",   "max_tokens":10 }""", transport.RawBodies[0]);
        Assert.Equal(HttpMethod.Post, transport.Requests[0].Method);
        Assert.Equal(Uri, transport.Requests[0].RequestUri);
    }

    [Fact]
    public async Task EntryFieldsOverlayTheBody()
    {
        var snapshot = Snapshot(
            entries: [Entry("""{"model": "opus", "max_tokens": 99, "temperature": 0.5}""")]
        );

        var body = await Body(snapshot, 0);

        Assert.Equal("opus", (string?)body["model"]);
        Assert.Equal(99, (int)body["max_tokens"]!);
        Assert.Equal(0.5, (double)body["temperature"]!);
    }

    [Fact]
    public async Task RequestAddsTheCreditTokenWhenGiven()
    {
        var snapshot = Snapshot();

        // Sent in the object form with best_effort mode, so a token-layer failure serves the
        // retry at normal price instead of a 400.
        var token = (await Body(snapshot, 0, "credit"))["fallback_credit_token"];
        Assert.Equal("credit", (string?)token?["token"]);
        Assert.Equal("best_effort", (string?)token?["mode"]);
        Assert.False((await Body(snapshot, 0)).ContainsKey("fallback_credit_token"));
    }

    [Fact]
    public async Task RequestCarriesTheSnapshottedHeaders()
    {
        var snapshot = Snapshot(
            headers: [new("anthropic-beta", ["b1", "b2"]), new("x-custom", ["v"])]
        );

        var transport = Transport(200);
        await Send(snapshot, transport, -1);

        var request = transport.Requests[0];
        Assert.Equal(["b1", "b2"], request.Headers.GetValues("anthropic-beta"));
        Assert.Equal(["v"], request.Headers.GetValues("x-custom"));
        Assert.Equal("application/json", request.Content!.Headers.ContentType!.MediaType);
    }

    [Fact]
    public async Task HopRequestSwapsModelAndTokenAndAppendsTheContinuation()
    {
        var snapshot = Snapshot(
            body: """{"model": "original", "messages": [{"role": "user", "content": "hi"}]}"""
        );
        List<JsonObject> continuation =
        [
            (JsonObject)JsonNode.Parse("""{"type": "text", "text": "partial"}""")!,
        ];

        var body = await HopBody(snapshot, 0, "token-1", continuation);

        Assert.Equal("fallback", (string?)body["model"]);
        Assert.Equal("token-1", (string?)body["fallback_credit_token"]?["token"]);
        Assert.Equal("best_effort", (string?)body["fallback_credit_token"]?["mode"]);
        var messages = (JsonArray)body["messages"]!;
        Assert.Equal(2, messages.Count);
        Assert.Equal("assistant", (string?)messages[1]!["role"]);
        Assert.Equal("partial", (string?)messages[1]!["content"]![0]!["text"]);
    }

    [Fact]
    public async Task HopRequestOmitsTheAssistantTurnWithoutAContinuation()
    {
        var snapshot = Snapshot(
            body: """{"model": "m", "messages": [{"role": "user", "content": "hi"}]}"""
        );

        var body = await HopBody(snapshot, 0, "t", []);

        Assert.Single((JsonArray)body["messages"]!);
    }

    [Fact]
    public async Task HopRequestBuildsFromThePinnedEntryBody()
    {
        // A pinned initial index means the token binds to that entry's overrides, so the
        // hop body keeps them.
        var snapshot = Snapshot(
            entries:
            [
                Entry("""{"model": "opus", "max_tokens": 500}"""),
                Entry("""{"model": "next-model"}"""),
            ],
            initialIndex: 0
        );

        var body = await HopBody(snapshot, 1, "t", []);

        Assert.Equal("next-model", (string?)body["model"]);
        Assert.Equal(500, (int)body["max_tokens"]!);
    }

    [Fact]
    public async Task HopRequestRemovesSpeedWhenTheEntrySetsItToNull()
    {
        var snapshot = Snapshot(
            body: """{"model": "original", "speed": "fast"}""",
            entries: [Entry("""{"model": "fallback", "speed": null}""")]
        );

        var body = await HopBody(snapshot, 0, "t", []);

        Assert.False(body.ContainsKey("speed"));
    }

    [Fact]
    public async Task HopRequestOverridesSpeedWhenTheEntrySetsIt()
    {
        var snapshot = Snapshot(
            body: """{"model": "original", "speed": "fast"}""",
            entries: [Entry("""{"model": "fallback", "speed": "standard"}""")]
        );

        var body = await HopBody(snapshot, 0, "t", []);

        Assert.Equal("standard", (string?)body["speed"]);
    }

    [Fact]
    public async Task HopRequestKeepsSpeedWhenTheEntryOmitsIt()
    {
        var snapshot = Snapshot(
            body: """{"model": "original", "speed": "fast"}""",
            entries: [Entry("""{"model": "fallback"}""")]
        );

        var body = await HopBody(snapshot, 0, "t", []);

        Assert.Equal("fast", (string?)body["speed"]);
    }

    [Fact]
    public async Task HopRequestIgnoresTheOtherEntryOverrides()
    {
        var snapshot = Snapshot(
            body: """{"model": "original", "max_tokens": 10}""",
            entries: [Entry("""{"model": "fallback", "max_tokens": 99}""")]
        );

        var body = await HopBody(snapshot, 0, "t", []);

        Assert.Equal(10, (int)body["max_tokens"]!);
    }

    [Fact]
    public async Task HopRequestDoesNotMutateTheContinuationBlocks()
    {
        var snapshot = Snapshot();
        var block = (JsonObject)JsonNode.Parse("""{"type": "text", "text": "x"}""")!;

        await HopBody(snapshot, 0, "t", [block]);

        Assert.Equal("""{"type":"text","text":"x"}""", block.ToJsonString());
    }

    [Fact]
    public async Task AHopThatTakesFastFromThePinnedEntryIsRetriedWithoutSpeed()
    {
        var snapshot = Snapshot(
            entries:
            [
                Entry("""{"model": "opus", "speed": "fast"}"""),
                Entry("""{"model": "next-model"}"""),
            ],
            initialIndex: 0
        );

        var transport = Transport(429, 200);
        await SendHop(snapshot, transport, 1, "t", []);

        Assert.Equal(["next-model", "next-model"], transport.Models);
        Assert.Equal("fast", (string?)transport.JsonBodies[0]["speed"]);
        Assert.False(transport.JsonBodies[1].ContainsKey("speed"));
    }

    [Fact]
    public async Task AnEntryThatSetsFastOnARequestWithoutSpeedIsNotRetriedWithoutIt()
    {
        var snapshot = Snapshot(entries: [Entry("""{"model": "opus", "speed": "fast"}""")]);

        var transport = Transport(429);
        await Send(snapshot, transport, 0);

        Assert.Equal(["fast"], transport.Speeds);
    }

    [Fact]
    public void ModelAtReadsTheOriginalOrTheEntrySpelling()
    {
        var snapshot = Snapshot(
            body: """{"model": "original"}""",
            entries: [Entry("""{"model": "opus"}""")]
        );

        Assert.Equal("original", snapshot.ModelAt(-1));
        Assert.Equal("opus", snapshot.ModelAt(0));
    }

    [Fact]
    public void ModelAtIsEmptyWhenTheBodyHasNoModel()
    {
        Assert.Equal("", Snapshot(body: """{"max_tokens": 1}""").ModelAt(-1));
    }

    [Fact]
    public void PinWritesTheIndexToTheAmbientState()
    {
        var state = BetaFallbackState.Create();
        var snapshot = Snapshot(state: state);

        snapshot.Pin(0);

        Assert.Equal(0, state.Index);
    }

    [Fact]
    public void PinWithoutStateWarnsOnce()
    {
        StringWriter writer = new();
        var snapshot = Snapshot(diagnostics: new FallbackDiagnostics(writer));

        snapshot.Pin(0);
        snapshot.Pin(0);

        var warnings = writer.ToString();
        Assert.Contains("fell back without an ambient", warnings);
        Assert.Single(warnings.Split(["WARNING"], StringSplitOptions.RemoveEmptyEntries));
    }
}
