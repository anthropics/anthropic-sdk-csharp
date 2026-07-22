using System.Text.Json;
using System.Text.Json.Nodes;

namespace Anthropic.Core;

/// <summary>Loosely-typed reads over <see cref="JsonNode"/> trees, shared by the fallback
/// helpers, which handle wire JSON raw rather than through the typed models.</summary>
internal static class JsonNodes
{
    public static string? GetString(JsonNode? node) =>
        node is JsonValue value && value.TryGetValue(out string? text) ? text : null;

    public static long? GetLong(JsonNode? node) =>
        node is JsonValue value && value.TryGetValue(out long number) ? number : null;

    public static int GetInt(JsonNode? node) =>
        node is JsonValue value && value.TryGetValue(out int number) ? number : 0;

    /// <summary>Parses JSON text to an object, or <c>null</c> if it isn't valid JSON or isn't an
    /// object.</summary>
    public static JsonObject? ParseObject(string json)
    {
        try
        {
            return JsonNode.Parse(json) as JsonObject;
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
