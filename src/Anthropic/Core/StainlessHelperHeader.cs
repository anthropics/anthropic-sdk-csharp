using System;
using System.Collections.Generic;
using System.Linq;

namespace Anthropic.Core;

/// <summary>
/// Single source of truth for the <c>x-stainless-helper</c> telemetry header — the key, the
/// closed set of tag values shared verbatim across SDKs, and the comma-append merge.
/// </summary>
internal static class StainlessHelperHeader
{
    /// <summary>
    /// Telemetry header naming the SDK helper(s) a request came from. Always this lowercase form;
    /// header lookups are case-insensitive but a single canonical casing keeps every call site
    /// greppable.
    /// </summary>
    internal const string Name = "x-stainless-helper";

    // Closed value vocabulary. Existing values keep their original spellings — telemetry consumers
    // match on them, so renames lose history. New tags are hyphenated lowercase.
    internal const string BetaToolRunner = "BetaToolRunner";
    internal const string FallbackRefusalMiddleware = "fallback-refusal-middleware";

    /// <summary>
    /// Returns the <see cref="Name"/> header value to set after appending <paramref name="value"/>
    /// to whatever is already present in <paramref name="headers"/> — existing tags keep their
    /// position, the new tag goes at the end, duplicates are dropped, joined as one
    /// comma-separated string. The backend logs the header as one opaque string, so a second
    /// header line or a clobbered value loses data.
    /// </summary>
    internal static string MergedValue(
        IEnumerable<KeyValuePair<string, string[]>> headers,
        string value
    ) =>
        string.Join(
            ", ",
            headers
                .Where(header =>
                    string.Equals(header.Key, Name, StringComparison.OrdinalIgnoreCase)
                )
                .SelectMany(header => header.Value)
                .SelectMany(existing => existing.Split(','))
                .Select(existing => existing.Trim())
                .Where(token => token.Length > 0)
                .Append(value)
                .Distinct()
        );
}
