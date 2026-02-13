using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Anthropic.Core;

static class FriendlyJsonPrinter
{
    public static JsonElement PrintValue(JsonElement value) => value;

    public static JsonElement PrintValue(IReadOnlyDictionary<string, JsonElement> value) =>
        JsonSerializer.SerializeToElement(value);

    public static JsonElement PrintValue(IReadOnlyList<JsonElement> value) =>
        JsonSerializer.SerializeToElement(value);

    public static JsonElement PrintValue(IReadOnlyDictionary<string, MultipartJsonElement> value)
    {
        int binaryContentCount = 0;
        var ret = new Dictionary<string, JsonElement>();
        foreach (var item in value)
        {
            ret[item.Key] = PrintValue(
                item.Value.Json,
                item.Value.BinaryContents,
                ref binaryContentCount
            );
        }
        return PrintValue(ret);
    }

    public static JsonElement PrintValue(MultipartJsonElement value)
    {
        int binaryContentCount = 0;
        return PrintValue(value.Json, value.BinaryContents, ref binaryContentCount);
    }

    static JsonElement PrintValue(
        JsonElement json,
        IReadOnlyDictionary<Guid, BinaryContent> binaryContent,
        ref int binaryContentCount
    )
    {
        switch (json.ValueKind)
        {
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
                return json;
            case JsonValueKind.String:
                return json.TryGetGuid(out var guid) && binaryContent.ContainsKey(guid)
                    ? JsonSerializer.SerializeToElement($"[Binary Content {binaryContentCount++}]")
                    : json;
            case JsonValueKind.Object:
            {
                var ret = new Dictionary<string, JsonElement>();
                foreach (var item in json.EnumerateObject())
                {
                    ret[item.Name] = PrintValue(item.Value, binaryContent, ref binaryContentCount);
                }
                return PrintValue(ret);
            }
            case JsonValueKind.Array:
            {
                var ret = new List<JsonElement>();
                foreach (var item in json.EnumerateArray())
                {
                    ret.Add(PrintValue(item, binaryContent, ref binaryContentCount));
                }
                return PrintValue(ret);
            }
            default:
                throw new InvalidOperationException("Unreachable");
        }
    }
}
