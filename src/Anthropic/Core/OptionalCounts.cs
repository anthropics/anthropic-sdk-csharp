using System.Text.Json;

namespace Anthropic.Core;

/// <summary>Lenient reads of integer counters from a model's raw JSON, for usage fields the
/// spec marks required but some providers omit (Amazon Bedrock leaves
/// <c>server_tool_use.web_fetch_requests</c> out, for example). The typed accessors throw on
/// an absent field; reporting usage shouldn't fail an otherwise successful response.</summary>
internal static class OptionalCounts
{
    /// <summary>Returns the integer at <paramref name="key"/>, or <c>null</c> if the field is
    /// absent, <c>null</c>, or not an integer.</summary>
    public static long? GetLong(JsonModel? model, string key) =>
        model is not null
        && model.RawData.TryGetValue(key, out JsonElement element)
        && element.ValueKind == JsonValueKind.Number
        && element.TryGetInt64(out long value)
            ? value
            : null;
}
