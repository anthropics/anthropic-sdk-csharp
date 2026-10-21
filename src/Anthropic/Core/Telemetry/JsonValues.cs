using System.Collections.Generic;
using System.Text.Json;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// Reads over JSON, for the two things that the spans take from JSON rather than from the typed
/// models, so that the stable and beta models share one path: the content attributes, built from
/// the raw <c>messages</c>, <c>system</c> and <c>content</c> of a request and a response, and the
/// response attributes of a streamed Message, tracked over the JSON of its events.
/// </summary>
static class JsonValues
{
    /// <summary>
    /// The property <paramref name="name"/> of this object, or null when this is not an object or
    /// has no such property.
    /// </summary>
    internal static JsonElement? Property(this JsonElement element, string name) =>
        element.ValueKind == JsonValueKind.Object && element.TryGetProperty(name, out var value)
            ? value
            : null;

    /// <summary>
    /// The string property <paramref name="name"/> of this object, or null when it is absent or
    /// not a string.
    /// </summary>
    internal static string? Text(this JsonElement element, string name) =>
        element.Property(name)?.StringValue();

    /// <summary>
    /// The integer property <paramref name="name"/> of this object, or null when it is absent or
    /// not an integer.
    /// </summary>
    internal static long? Long(this JsonElement element, string name) =>
        element.Property(name)?.LongValue();

    internal static string? StringValue(this JsonElement element) =>
        element.ValueKind == JsonValueKind.String ? element.GetString() : null;

    internal static long? LongValue(this JsonElement element) =>
        element.ValueKind == JsonValueKind.Number && element.TryGetInt64(out var number)
            ? number
            : null;

    /// <summary>
    /// The property <paramref name="name"/> of a model's raw data, or null when absent.
    /// </summary>
    internal static JsonElement? Property(
        this IReadOnlyDictionary<string, JsonElement> body,
        string name
    ) => body.TryGetValue(name, out var value) ? value : null;

    /// <inheritdoc cref="Text(JsonElement, string)"/>
    internal static string? Text(this IReadOnlyDictionary<string, JsonElement> body, string name) =>
        body.Property(name)?.StringValue();

    /// <inheritdoc cref="Long(JsonElement, string)"/>
    internal static long? Long(this IReadOnlyDictionary<string, JsonElement> body, string name) =>
        body.Property(name)?.LongValue();
}
