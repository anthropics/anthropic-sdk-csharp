using System;

namespace Anthropic.Core;

/// <summary>
/// The telemetry that a client emits through OpenTelemetry.
///
/// <para>A <c>bool</c> converts to this type, so <c>OpenTelemetry = false</c> is the short form of
/// <c>OpenTelemetry = new() { Traces = false }</c>.</para>
///
/// <para>Options that <c>WithOptions</c> sets take the place of those of the client it was called
/// on, as a whole: the two are not merged, so the new options hold every setting that the new
/// client is to have. What they leave unset has its default.</para>
///
/// <para>The <c>ANTHROPIC_OPEN_TELEMETRY</c>,
/// <c>ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE</c> and
/// <c>ANTHROPIC_OPEN_TELEMETRY_TRACES_MAX_CONTENT_BYTES</c> environment variables apply only to a
/// client that is given no options: it reads them once, when it is made. A client that is given
/// options, even empty ones, takes none of them, and what its options leave unset has its
/// default.</para>
///
/// <para>There is no setting for the trace context headers alone (<c>traceparent</c>,
/// <c>tracestate</c> and the baggage): the client sends them with every call that it emits a
/// span for. To stop them, set
/// <c>System.Diagnostics.DistributedContextPropagator.Current</c> to
/// <c>DistributedContextPropagator.CreateNoOutputPropagator()</c> when the application starts.
/// That is .NET's own setting, and it holds for every <c>HttpClient</c> in the process.</para>
/// </summary>
public sealed record class OpenTelemetryOptions
{
    /// <summary>
    /// The spans that the client emits. A <c>bool</c> converts to
    /// <see cref="OpenTelemetryTraces"/>, so <c>Traces = false</c> is the short form of
    /// <c>Traces = new() { Enabled = false }</c>. A setting that this leaves unset has its
    /// default.
    /// </summary>
    public OpenTelemetryTraces? Traces { get; init; }

    /// <summary>
    /// Sets <see cref="Traces"/> to <paramref name="traces"/>.
    /// </summary>
    public static implicit operator OpenTelemetryOptions(bool traces) => new() { Traces = traces };
}

/// <summary>
/// The spans that a client emits, and what they hold.
///
/// <para>A <c>bool</c> converts to this type, so <c>Traces = true</c> is the short form of
/// <c>Traces = new() { Enabled = true }</c>.</para>
/// </summary>
public sealed record class OpenTelemetryTraces
{
    /// <summary>
    /// Whether the client emits a span for each API call. When false, it emits none, and the
    /// other settings are not used.
    ///
    /// <para>The spans come from the <c>System.Diagnostics.ActivitySource</c> named
    /// <c>com.anthropic.sdk.csharp</c>, so a call emits one only when a listener is registered on
    /// that source. An application that uses the OpenTelemetry .NET SDK registers one by adding the
    /// source to its tracer provider. The spans of a client for a cloud platform come from a
    /// source of that platform's package, named after it, such as
    /// <c>com.anthropic.sdk.csharp.bedrock</c>; <c>AddSource("com.anthropic.sdk.csharp*")</c> adds
    /// them all.</para>
    ///
    /// <para>When unset, it is true. For a client that is given no
    /// <see cref="OpenTelemetryOptions"/>, it is true unless the <c>ANTHROPIC_OPEN_TELEMETRY</c>
    /// environment variable is <c>false</c>.</para>
    /// </summary>
    public bool? Enabled { get; init; }

    /// <summary>
    /// Whether the spans hold the content of the requests and responses: the messages, the system
    /// prompt, the stop sequences, and the tool calls and their results. See
    /// <see cref="OpenTelemetryContentMode"/>.
    ///
    /// <para>When unset, it is <see cref="OpenTelemetryContentMode.MetadataOnly"/>. For a client
    /// that is given no <see cref="OpenTelemetryOptions"/>, it is that unless the
    /// <c>ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE</c> environment variable is
    /// <c>content</c>.</para>
    /// </summary>
    public OpenTelemetryContentMode? ContentMode { get; init; }

    /// <summary>
    /// The most content that one span holds, at least 1. The size of the content is counted in
    /// bytes of UTF-8, which is how a span is exported. Content over it loses the stop
    /// sequences, or a tool call's arguments, when they are over it by themselves, and then
    /// message parts, the oldest first, or the last blocks of a tool's result. The span then has
    /// <c>anthropic.content.truncated</c>.
    ///
    /// <para>When unset, it is 750000. For a client that is given no
    /// <see cref="OpenTelemetryOptions"/>, it is that unless the
    /// <c>ANTHROPIC_OPEN_TELEMETRY_TRACES_MAX_CONTENT_BYTES</c> environment variable is a whole
    /// number that is at least 1.</para>
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">The value is less than 1.</exception>
    public long? MaxContentBytes
    {
        get { return _maxContentBytes; }
        init
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(MaxContentBytes),
                    value,
                    "MaxContentBytes must be at least 1. Leave it unset for the default."
                );
            }
            _maxContentBytes = value;
        }
    }

    readonly long? _maxContentBytes;

    /// <summary>
    /// Sets <see cref="Enabled"/> to <paramref name="enabled"/>.
    /// </summary>
    public static implicit operator OpenTelemetryTraces(bool enabled) =>
        new() { Enabled = enabled };
}

/// <summary>
/// What the spans of a client hold about the requests and responses.
/// </summary>
public enum OpenTelemetryContentMode
{
    /// <summary>
    /// The spans hold metadata only: the model, the token usage, the stop reason, and the like.
    /// </summary>
    MetadataOnly,

    /// <summary>
    /// The spans also hold the messages of the request and the response, the system prompt, the
    /// stop sequences, and the arguments and results of the tools that a tool runner executes.
    /// They leave out a thinking block's signature, redacted thinking and the fields that the API
    /// encrypts, and image and document data, which is large and binary.
    /// </summary>
    Content,
}

/// <summary>
/// The OpenTelemetry options of one API call, set through <c>WithOptions</c> on a client or a
/// service. See <see cref="ClientOptions.OpenTelemetryRequest"/>.
/// </summary>
public sealed record class OpenTelemetryRequestOptions
{
    /// <summary>
    /// An identifier that the application chose for the conversation that the call belongs to.
    /// The SDK sets it as <c>gen_ai.conversation.id</c> on the call's span, and does not send it
    /// to the API. Without one, the span of a call to a Session thread's path has the thread's
    /// ID there, and the span of any other call has no <c>gen_ai.conversation.id</c>.
    ///
    /// <para>An empty string is set, and names no conversation.</para>
    /// </summary>
    public string? ConversationId { get; init; }
}
