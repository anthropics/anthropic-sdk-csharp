using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using Anthropic.Helpers.Fallbacks;

namespace Anthropic.Tests.Helpers.Fallbacks;

public class BlockAccumulatorTest
{
    static JsonObject Parse(string json) => (JsonObject)JsonNode.Parse(json)!;

    static BlockAccumulator NewAccumulator(int indexBase = 0) =>
        new(new FallbackDiagnostics(TextWriter.Null), indexBase);

    [Fact]
    public void TextDeltasAccumulateIntoTheBlock()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(Parse("""{"index": 0, "content_block": {"type": "text", "text": ""}}"""));
        accumulator.Delta(
            Parse("""{"index": 0, "delta": {"type": "text_delta", "text": "Hel"}}""")
        );
        accumulator.Delta(Parse("""{"index": 0, "delta": {"type": "text_delta", "text": "lo"}}"""));

        var block = Assert.Single(accumulator.Blocks).Block;
        Assert.Equal("Hello", (string?)block["text"]);
    }

    [Fact]
    public void ThinkingAndSignatureDeltasAccumulate()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(Parse("""{"index": 0, "content_block": {"type": "thinking"}}"""));
        accumulator.Delta(
            Parse("""{"index": 0, "delta": {"type": "thinking_delta", "thinking": "ab"}}""")
        );
        accumulator.Delta(
            Parse("""{"index": 0, "delta": {"type": "signature_delta", "signature": "sig"}}""")
        );

        var block = Assert.Single(accumulator.Blocks).Block;
        Assert.Equal("ab", (string?)block["thinking"]);
        Assert.Equal("sig", (string?)block["signature"]);
    }

    [Fact]
    public void CitationDeltasAppendToACitationsArray()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(Parse("""{"index": 0, "content_block": {"type": "text"}}"""));
        accumulator.Delta(
            Parse(
                """{"index": 0, "delta": {"type": "citations_delta", "citation": {"cited_text": "a"}}}"""
            )
        );

        var citations = (JsonArray)accumulator.Blocks[0].Block["citations"]!;
        Assert.Equal("a", (string?)Assert.Single(citations)!["cited_text"]);
    }

    [Fact]
    public void CompactionDeltasAccumulateBothFieldsIndependently()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(Parse("""{"index": 0, "content_block": {"type": "compaction"}}"""));
        accumulator.Delta(
            Parse("""{"index": 0, "delta": {"type": "compaction_delta", "content": "c1"}}""")
        );
        accumulator.Delta(
            Parse(
                """{"index": 0, "delta": {"type": "compaction_delta", "encrypted_content": "e1"}}"""
            )
        );

        var block = accumulator.Blocks[0].Block;
        Assert.Equal("c1", (string?)block["content"]);
        Assert.Equal("e1", (string?)block["encrypted_content"]);
    }

    [Fact]
    public void UnknownDeltaTypeLeavesTheBlockUnchanged()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(Parse("""{"index": 0, "content_block": {"type": "novel"}}"""));
        accumulator.Delta(Parse("""{"index": 0, "delta": {"type": "novel_delta", "data": "x"}}"""));

        Assert.Equal("""{"type":"novel"}""", accumulator.Blocks[0].Block.ToJsonString());
    }

    [Fact]
    public void EventIndicesAreShiftedByTheIndexBase()
    {
        var accumulator = NewAccumulator(indexBase: 5);
        var start = Parse("""{"index": 0, "content_block": {"type": "text"}}""");
        var delta = Parse("""{"index": 0, "delta": {"type": "text_delta", "text": "x"}}""");
        var stop = Parse("""{"index": 0}""");

        accumulator.Start(start);
        accumulator.Delta(delta);
        accumulator.Stop(stop);

        Assert.Equal(5, (int)start["index"]!);
        Assert.Equal(5, (int)delta["index"]!);
        Assert.Equal(5, (int)stop["index"]!);
        Assert.Equal(6, accumulator.NextIndex);
    }

    [Fact]
    public void NextIndexIsOnePastTheHighestShiftedIndex()
    {
        var accumulator = NewAccumulator(indexBase: 2);
        accumulator.Start(Parse("""{"index": 1, "content_block": {"type": "text"}}"""));
        accumulator.Start(Parse("""{"index": 0, "content_block": {"type": "text"}}"""));

        Assert.Equal(4, accumulator.NextIndex);
    }

    [Fact]
    public void FirstBlockAtAWireIndexWinsDeltaAccumulation()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(
            Parse("""{"index": 0, "content_block": {"type": "text", "text": "first-"}}""")
        );
        accumulator.Start(
            Parse("""{"index": 0, "content_block": {"type": "text", "text": "second-"}}""")
        );
        accumulator.Delta(Parse("""{"index": 0, "delta": {"type": "text_delta", "text": "X"}}"""));

        Assert.Equal(2, accumulator.Blocks.Count);
        Assert.Equal("first-X", (string?)accumulator.Blocks[0].Block["text"]);
        Assert.Equal("second-", (string?)accumulator.Blocks[1].Block["text"]);
    }

    [Fact]
    public void CloseOpenBlocksEmitsAStopPerUnstoppedBlock()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(Parse("""{"index": 0, "content_block": {"type": "text"}}"""));
        accumulator.Start(Parse("""{"index": 1, "content_block": {"type": "text"}}"""));
        accumulator.Stop(Parse("""{"index": 0}"""));

        var stops = accumulator.CloseOpenBlocks();

        var only = Assert.Single(stops);
        Assert.Equal(
            "event: content_block_stop\ndata: {\"type\":\"content_block_stop\",\"index\":1}\n\n",
            Encoding.UTF8.GetString(only)
        );
        Assert.Empty(accumulator.CloseOpenBlocks());
    }

    [Fact]
    public void ToPrefillBlocksReassemblesToolInputFromJsonDeltas()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(
            Parse(
                """{"index": 0, "content_block": {"type": "tool_use", "id": "t1", "input": {}}}"""
            )
        );
        accumulator.Delta(
            Parse(
                """{"index": 0, "delta": {"type": "input_json_delta", "partial_json": "{\"a\":"}}"""
            )
        );
        accumulator.Delta(
            Parse("""{"index": 0, "delta": {"type": "input_json_delta", "partial_json": "1}"}}""")
        );

        var block = Assert.Single(BlockAccumulator.ToPrefillBlocks(accumulator.Blocks));
        Assert.Equal(1, (int)block["input"]!["a"]!);
    }

    [Fact]
    public void ToPrefillBlocksKeepsPlaceholderInputWhenJsonIsInvalid()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(
            Parse("""{"index": 0, "content_block": {"type": "tool_use", "input": {}}}""")
        );
        accumulator.Delta(
            Parse(
                """{"index": 0, "delta": {"type": "input_json_delta", "partial_json": "{oops"}}"""
            )
        );

        var block = Assert.Single(BlockAccumulator.ToPrefillBlocks(accumulator.Blocks));
        Assert.Equal("{}", block["input"]!.ToJsonString());
    }

    [Fact]
    public void ToPrefillBlocksPassesBlocksThroughAsIs()
    {
        var accumulator = NewAccumulator();
        accumulator.Start(
            Parse("""{"index": 0, "content_block": {"type": "text", "text": "hi"}}""")
        );

        var block = Assert.Single(BlockAccumulator.ToPrefillBlocks(accumulator.Blocks));
        Assert.Equal("""{"type":"text","text":"hi"}""", block.ToJsonString());
    }
}
