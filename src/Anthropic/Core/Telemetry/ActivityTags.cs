using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// Sets the attributes of a span that have a value, and leaves out those that have none.
/// </summary>
static class ActivityTags
{
    /// <summary>
    /// Runs <paramref name="record"/> on <paramref name="span"/> when there is one and it is
    /// recording. A failure to record telemetry must not fail the API call, so whatever
    /// <paramref name="record"/> throws is dropped.
    /// </summary>
    internal static void Record(Activity? span, Action<Activity> record)
    {
        if (span is not { IsAllDataRequested: true })
        {
            return;
        }
        try
        {
            record(span);
        }
        catch (Exception) { }
    }

    /// <summary>
    /// Adds the attribute <paramref name="name"/> to <paramref name="tags"/>, the attributes that
    /// a span starts with, when <paramref name="value"/> is present.
    /// </summary>
    internal static void AddTag(
        this List<KeyValuePair<string, object?>> tags,
        string name,
        object? value
    )
    {
        if (value != null)
        {
            tags.Add(new(name, value));
        }
    }

    /// <summary>
    /// Sets the attribute <paramref name="name"/> when <paramref name="value"/> is present. The
    /// overloads keep each attribute's type.
    /// </summary>
    internal static void SetTag(Activity span, string name, string? value)
    {
        if (value != null)
        {
            span.SetTag(name, value);
        }
    }

    /// <inheritdoc cref="SetTag(Activity, string, string?)"/>
    internal static void SetTag(Activity span, string name, long? value)
    {
        if (value is { } number)
        {
            span.SetTag(name, number);
        }
    }

    /// <inheritdoc cref="SetTag(Activity, string, string?)"/>
    internal static void SetTag(Activity span, string name, double? value)
    {
        if (value is { } number)
        {
            span.SetTag(name, number);
        }
    }
}
