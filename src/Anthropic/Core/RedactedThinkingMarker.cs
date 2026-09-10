using System.Text.Json;
using Microsoft.Extensions.AI;

namespace Anthropic.Core;

/// <summary>
/// Marks <see cref="TextReasoningContent"/> that came from a <c>redacted_thinking</c> block, shared
/// by the stable and beta chat clients.
/// </summary>
/// <remarks>
/// A <c>thinking</c> block whose display was omitted also arrives as empty text plus opaque data, so
/// the two can't be told apart from the content alone. <see cref="AIContent.RawRepresentation"/>
/// tells them apart until the history is serialized, since it is not persisted. This marker lives
/// in <see cref="AIContent.AdditionalProperties"/>, which is.
/// </remarks>
internal static class RedactedThinkingMarker
{
    internal const string Key = "anthropic:redacted_thinking";

    /// <summary>Marks <paramref name="content"/> as redacted thinking and returns it.</summary>
    internal static TextReasoningContent MarkRedacted(this TextReasoningContent content)
    {
        (content.AdditionalProperties ??= [])[Key] = true;
        return content;
    }

    /// <summary>
    /// Whether <paramref name="content"/> carries the marker, either as set by
    /// <see cref="MarkRedacted"/> or as it reads back after a JSON round trip.
    /// </summary>
    internal static bool IsMarkedRedacted(this AIContent content) =>
        content.AdditionalProperties?.TryGetValue(Key, out object? value) == true
        && value is true or JsonElement { ValueKind: JsonValueKind.True };
}
