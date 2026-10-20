using System;
using System.Globalization;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// What the OpenTelemetry options of a client come to when it is given none: what the tracing
/// environment variables say. The client's options read them once
/// (<see cref="ClientOptions.ResolvedOpenTelemetry"/>), so that a later change of the process
/// environment does not reach a client that exists, nor a client that <c>WithOptions</c> makes
/// from it, whose options are a copy that keeps what was read. Options that are set take
/// nothing from the variables: what they leave unset has its built-in default.
/// </summary>
sealed class OpenTelemetryDefaults
{
    internal const string TracesVariable = "ANTHROPIC_OPEN_TELEMETRY";

    internal const string ContentModeVariable = "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE";

    internal const string MaxContentBytesVariable =
        "ANTHROPIC_OPEN_TELEMETRY_TRACES_MAX_CONTENT_BYTES";

    readonly OpenTelemetryOptions _fromEnvironment = new()
    {
        Traces = new()
        {
            Enabled = ReadEnabled(),
            ContentMode = ReadContentMode(),
            MaxContentBytes = ReadMaxContentBytes(),
        },
    };

    /// <summary>
    /// Whether the variable leaves the spans on: it does unless it is <c>false</c>.
    /// </summary>
    static bool ReadEnabled() =>
        !string.Equals(
            Environment.GetEnvironmentVariable(TracesVariable),
            "false",
            StringComparison.OrdinalIgnoreCase
        );

    /// <summary>
    /// The content mode that the variable selects: <c>content</c>, or else metadata only.
    /// </summary>
    static OpenTelemetryContentMode ReadContentMode() =>
        string.Equals(
            Environment.GetEnvironmentVariable(ContentModeVariable),
            "content",
            StringComparison.OrdinalIgnoreCase
        )
            ? OpenTelemetryContentMode.Content
            : OpenTelemetryContentMode.MetadataOnly;

    /// <summary>
    /// The size limit that the variable gives: a whole number that is at least 1, or else
    /// <see cref="Content.ContentLimit"/>.
    /// </summary>
    static long ReadMaxContentBytes() =>
        long.TryParse(
            Environment.GetEnvironmentVariable(MaxContentBytesVariable),
            NumberStyles.Integer,
            CultureInfo.InvariantCulture,
            out var maxContentBytes
        )
        && maxContentBytes >= 1
            ? maxContentBytes
            : Content.ContentLimit;

    /// <summary>
    /// <paramref name="options"/> with nothing left unset. Without options, every setting is what
    /// the variables said. With options, the variables do not count, whichever settings the
    /// options set: what they leave unset has its built-in default.
    /// </summary>
    internal OpenTelemetryOptions Resolve(OpenTelemetryOptions? options)
    {
        if (options == null)
        {
            return _fromEnvironment;
        }
        if (
            options is
            { Traces: { Enabled: not null, ContentMode: not null, MaxContentBytes: not null } }
        )
        {
            return options;
        }
        var traces = options.Traces ?? new();
        return options with
        {
            Traces = traces with
            {
                Enabled = traces.Enabled ?? true,
                ContentMode = traces.ContentMode ?? OpenTelemetryContentMode.MetadataOnly,
                MaxContentBytes = traces.MaxContentBytes ?? Content.ContentLimit,
            },
        };
    }
}
