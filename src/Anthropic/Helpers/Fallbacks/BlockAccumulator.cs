using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using static Anthropic.Core.JsonNodes;

namespace Anthropic.Helpers.Fallbacks;

/// <summary>
/// Block bookkeeping for one stream of the splice: accumulates each content block from its
/// deltas (for the continuation prefill), shifts wire indices by the index base so they stay
/// monotonic across hops, and tracks which blocks are still open so a refusal that cuts
/// mid-block can close them.
///
/// <para>Everything is raw JSON: the credit token is only redeemable when the prefill matches
/// the wire output verbatim, and only raw JSON accumulates deltas onto block types the SDK
/// doesn't model yet, exactly what a brand-new model may stream.</para>
/// </summary>
internal sealed class BlockAccumulator
{
    /// <summary>A response content block being accumulated from its streaming deltas.</summary>
    public sealed class AccumulatedBlock
    {
        public AccumulatedBlock(JsonObject block)
        {
            Block = block;
        }

        public JsonObject Block { get; }

        /// <summary>The block's <c>input_json_delta</c> JSON accumulated so far, if any
        /// arrived.</summary>
        public StringBuilder? PartialJson { get; set; }
    }

    readonly FallbackDiagnostics _diagnostics;
    readonly int _indexBase;

    /// <summary>Shifted indices of blocks started but not yet stopped.</summary>
    readonly List<int> _open = [];

    /// <summary>The accumulating blocks by their original wire index, for delta lookup.</summary>
    readonly Dictionary<int, AccumulatedBlock> _byIndex = [];

    public BlockAccumulator(FallbackDiagnostics diagnostics, int indexBase)
    {
        _diagnostics = diagnostics;
        _indexBase = indexBase;
        NextIndex = indexBase;
    }

    /// <summary>The stream's accumulated blocks, in start order.</summary>
    public List<AccumulatedBlock> Blocks { get; } = [];

    /// <summary>One past the highest shifted block index seen.</summary>
    public int NextIndex { get; private set; }

    /// <summary>Tracks a content_block_start, shifting the event's <c>index</c>.</summary>
    public void Start(JsonObject @event)
    {
        var index = GetInt(@event["index"]);
        var block = (@event["content_block"] as JsonObject)?.DeepClone() as JsonObject ?? [];
        AccumulatedBlock accumulated = new(block);
        Blocks.Add(accumulated);
        // First block at a wire index wins delta accumulation; a duplicate index still enters
        // Blocks (and so the prefill) but never receives deltas.
        if (!_byIndex.TryGetValue(index, out _))
        {
            _byIndex.Add(index, accumulated);
        }
        var shifted = index + _indexBase;
        @event["index"] = shifted;
        _open.Add(shifted);
        NextIndex = shifted + 1 > NextIndex ? shifted + 1 : NextIndex;
    }

    /// <summary>
    /// Applies a content_block_delta to its accumulating block, shifting the event's
    /// <c>index</c>.
    /// </summary>
    public void Delta(JsonObject @event)
    {
        var index = GetInt(@event["index"]);
        if (_byIndex.TryGetValue(index, out var accumulated))
        {
            ApplyDelta(accumulated, @event["delta"]);
        }
        @event["index"] = index + _indexBase;
    }

    /// <summary>Tracks a content_block_stop, shifting the event's <c>index</c>.</summary>
    public void Stop(JsonObject @event)
    {
        var shifted = GetInt(@event["index"]) + _indexBase;
        @event["index"] = shifted;
        _open.Remove(shifted);
        NextIndex = shifted + 1 > NextIndex ? shifted + 1 : NextIndex;
    }

    /// <summary>content_block_stop events for any blocks still open.</summary>
    public List<byte[]> CloseOpenBlocks()
    {
        List<byte[]> stops = [];
        foreach (var index in _open)
        {
            stops.Add(WireShape.ContentBlockStop(index));
        }
        _open.Clear();
        return stops;
    }

    void ApplyDelta(AccumulatedBlock accumulated, JsonNode? delta)
    {
        var block = accumulated.Block;
        switch (delta == null ? "" : GetString(delta["type"]) ?? "")
        {
            case "text_delta":
                block["text"] =
                    (GetString(block["text"]) ?? "") + (GetString(delta!["text"]) ?? "");
                break;
            case "input_json_delta":
                var partialJson = accumulated.PartialJson ??= new StringBuilder();
                partialJson.Append(GetString(delta!["partial_json"]) ?? "");
                break;
            case "citations_delta":
                if (block["citations"] is not JsonArray citations)
                {
                    citations = [];
                    block["citations"] = citations;
                }
                citations.Add(delta!["citation"]?.DeepClone());
                break;
            case "thinking_delta":
                block["thinking"] =
                    (GetString(block["thinking"]) ?? "") + (GetString(delta!["thinking"]) ?? "");
                break;
            case "signature_delta":
                block["signature"] =
                    (GetString(block["signature"]) ?? "") + (GetString(delta!["signature"]) ?? "");
                break;
            case "compaction_delta":
                // The start block leaves both fields null until the deltas arrive.
                if (GetString(delta!["content"]) is { } content)
                {
                    block["content"] = (GetString(block["content"]) ?? "") + content;
                }
                if (GetString(delta["encrypted_content"]) is { } encryptedContent)
                {
                    block["encrypted_content"] =
                        (GetString(block["encrypted_content"]) ?? "") + encryptedContent;
                }
                break;
            default:
                // A delta type this accumulator doesn't know (a brand-new model's, say) can't be
                // folded into the block, so a prefill including it may not match the wire output;
                // the server rejects it and the hop retries without the prefill.
                _diagnostics.WarnDeltaTypeOnce(delta == null ? "" : GetString(delta["type"]) ?? "");
                break;
        }
    }

    /// <summary>
    /// Converts a hop's accumulated response blocks to the appended assistant turn, as-is: a
    /// <c>fallback_has_prefill_claim</c> refusal guarantees the partial output is resendable
    /// verbatim, so no client-side filtering is applied. The only rewrite is reassembling tool
    /// inputs from their accumulated <c>input_json_delta</c> JSON (content_block_start carries
    /// <c>input: {}</c>).
    /// </summary>
    public static List<JsonObject> ToPrefillBlocks(List<AccumulatedBlock> blocks)
    {
        List<JsonObject> prefill = [];
        foreach (var accumulated in blocks)
        {
            if (accumulated.PartialJson is { } partialJson)
            {
                JsonNode? input;
                try
                {
                    input = JsonNode.Parse(partialJson.ToString());
                }
                catch (JsonException)
                {
                    input = null;
                }
                if (input != null)
                {
                    accumulated.Block["input"] = input;
                }
            }
            prefill.Add(accumulated.Block);
        }
        return prefill;
    }
}
