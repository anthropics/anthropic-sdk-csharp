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
    static readonly Uri Uri = new("https://example.test/v1/messages?beta=true");

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

#pragma warning disable xUnit1051 // net472's HttpContent has no CancellationToken overload
    static async Task<JsonObject> Body(HttpRequestMessage request) =>
        (JsonObject)JsonNode.Parse(await request.Content!.ReadAsStringAsync())!;

    static Task<string> ReadContent(HttpRequestMessage request) =>
        request.Content!.ReadAsStringAsync();
#pragma warning restore xUnit1051

    [Fact]
    public async Task OriginalRequestKeepsTheBodyBytesVerbatim()
    {
        // Odd spacing is preserved because index -1 sends the snapshot bytes untouched.
        var snapshot = Snapshot(body: """{ "model" : "original",   "max_tokens":10 }""");

        var request = snapshot.Request(-1);

        Assert.Equal("""{ "model" : "original",   "max_tokens":10 }""", await ReadContent(request));
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal(Uri, request.RequestUri);
    }

    [Fact]
    public async Task EntryFieldsOverlayTheBody()
    {
        var snapshot = Snapshot(
            entries: [Entry("""{"model": "opus", "max_tokens": 99, "temperature": 0.5}""")]
        );

        var body = await Body(snapshot.Request(0));

        Assert.Equal("opus", (string?)body["model"]);
        Assert.Equal(99, (int)body["max_tokens"]!);
        Assert.Equal(0.5, (double)body["temperature"]!);
    }

    [Fact]
    public async Task RequestAddsTheCreditTokenWhenGiven()
    {
        var snapshot = Snapshot();

        Assert.Equal(
            "credit",
            (string?)(await Body(snapshot.Request(0, "credit")))["fallback_credit_token"]
        );
        Assert.False((await Body(snapshot.Request(0))).ContainsKey("fallback_credit_token"));
    }

    [Fact]
    public void RequestCarriesTheSnapshottedHeaders()
    {
        var snapshot = Snapshot(
            headers: [new("anthropic-beta", ["b1", "b2"]), new("x-custom", ["v"])]
        );

        var request = snapshot.Request(-1);

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

        var body = await Body(snapshot.HopRequest("fallback", "token-1", continuation));

        Assert.Equal("fallback", (string?)body["model"]);
        Assert.Equal("token-1", (string?)body["fallback_credit_token"]);
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

        var body = await Body(snapshot.HopRequest("fallback", "t", []));

        Assert.Single((JsonArray)body["messages"]!);
    }

    [Fact]
    public async Task HopRequestBuildsFromThePinnedEntryBody()
    {
        // A pinned initial index means the token binds to that entry's overrides, so the
        // hop body keeps them.
        var snapshot = Snapshot(
            entries: [Entry("""{"model": "opus", "max_tokens": 500}""")],
            initialIndex: 0
        );

        var body = await Body(snapshot.HopRequest("next-model", "t", []));

        Assert.Equal("next-model", (string?)body["model"]);
        Assert.Equal(500, (int)body["max_tokens"]!);
    }

    [Fact]
    public void HopRequestDoesNotMutateTheContinuationBlocks()
    {
        var snapshot = Snapshot();
        var block = (JsonObject)JsonNode.Parse("""{"type": "text", "text": "x"}""")!;

        using (snapshot.HopRequest("m", "t", [block])) { }

        Assert.Equal("""{"type":"text","text":"x"}""", block.ToJsonString());
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
