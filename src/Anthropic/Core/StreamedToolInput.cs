using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Anthropic.Core;

/// <summary>Reassembles a streamed tool block's <c>input</c>, shared by the stable and beta
/// message aggregators so both apply the same tolerance rules.</summary>
internal static class StreamedToolInput
{
    /// <summary>
    /// Returns <paramref name="block"/> with its <c>"input"</c> replaced by the JSON object the
    /// <c>input_json_delta</c> fragments concatenate to, keeping every other field the start block
    /// carried. <c>tool_use</c>, <c>server_tool_use</c> and <c>mcp_tool_use</c> start with
    /// <c>"input": {}</c> and stream the real JSON as deltas.
    ///
    /// <para>The start block is returned unchanged when there is nothing usable to merge: no
    /// deltas arrived, the stream was cut mid-delta (e.g. by <c>max_tokens</c>) leaving JSON that
    /// can never parse, or the fragments form something other than an object. All three are legal
    /// streams, so aggregation must still yield the block rather than throw.</para>
    /// </summary>
    public static T WithMergedInput<T>(
        T block,
        IEnumerable<string> partialJsons,
        Func<IReadOnlyDictionary<string, JsonElement>, T> fromRaw
    )
        where T : JsonModel
    {
        var mergedJson = string.Concat(partialJsons);
        if (string.IsNullOrEmpty(mergedJson))
        {
            return block;
        }

        JsonElement input;
        try
        {
            input = JsonSerializer.Deserialize<JsonElement>(mergedJson);
        }
        catch (JsonException)
        {
            return block;
        }
        if (input.ValueKind != JsonValueKind.Object)
        {
            return block;
        }

        var raw = block.RawData.ToDictionary(kv => kv.Key, kv => kv.Value);
        raw["input"] = input;
        return fromRaw(raw);
    }
}
