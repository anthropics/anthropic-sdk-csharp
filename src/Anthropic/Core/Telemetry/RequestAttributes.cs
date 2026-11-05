using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using static Anthropic.Core.Telemetry.ActivityTags;
using static Anthropic.Core.Telemetry.SemanticConventions;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// The request attributes of a Messages create call span. The Messages create methods start their
/// span with them, from the parameters they are called with, so that a sampler sees them. Those
/// that the SDK's configuration names come from <see cref="SpanAttributes"/>, and those computed
/// from the request from here.
/// </summary>
static class RequestAttributes
{
    const string MessagesCreateSpanName = "anthropic.messages.create";

    /// <summary>
    /// Starts the call span of a Messages create method of <paramref name="client"/>, stable or
    /// beta, with the request attributes for a sampler to decide on: those of the client's
    /// options, those that the SDK's configuration takes from <paramref name="parameters"/> and
    /// from the <c>anthropic-beta</c> values that the call's requests carry, and the output type.
    /// In content mode it also sets the request's content. Returns the span, and what it wrote of
    /// the content for the response's content to be written beside it.
    ///
    /// <para>Never throws into the API call, and sets no content on a span that is not
    /// recording. When the client would emit no span (<see cref="ApiCallSpans.IsEnabled"/>), it
    /// reads nothing of <paramref name="parameters"/>.</para>
    /// </summary>
    internal static (Activity?, RequestContent?) StartMessagesCreateSpan(
        IAnthropicClientWithRawResponse client,
        ParamsBase parameters
    )
    {
        if (!ApiCallSpans.IsEnabled(client))
        {
            return (null, null);
        }
        // A method sees its client through the client's public interface, which does not have
        // all the options, so they are those of the SDK's own client class.
        var options = (client as AnthropicClientWithRawResponse)?.Options;
        var tags = options is { } known ? ApiCallSpans.StartAttributes(known) : [];
        // Every Messages method sends a `POST`.
        Tracing.AddRequestAttributes(tags, HttpMethod.Post, parameters);
        SpanAttributes.AddRequestAttributes(
            tags,
            MessagesCreateSpanName,
            parameters,
            options?.ExtraHeaders
        );
        var body = parameters.SpanBody ?? new Dictionary<string, JsonElement>();
        if (HasOutputFormat(body))
        {
            tags.Add(new(AttributeGenAiOutputType, GenAiOutputType.Json));
        }
        var span = Tracing.StartApiCallSpan(
            OpenTelemetry(client),
            MessagesCreateSpanName,
            tags,
            Source(client)
        );
        return (span, SetMessagesCreateRequestContent(span, OpenTelemetry(client), body));
    }

    /// <summary>
    /// Whether the request with <paramref name="body"/> asks for output in a format: it sets
    /// <c>output_config.format</c>, or the deprecated <c>output_format</c>.
    /// </summary>
    static bool HasOutputFormat(IReadOnlyDictionary<string, JsonElement> body) =>
        body.Property("output_config")?.Property("format") is { ValueKind: not JsonValueKind.Null }
        || body.Property("output_format") is { ValueKind: not JsonValueKind.Null };

    /// <summary>
    /// The OpenTelemetry options of <paramref name="client"/> with nothing left unset
    /// (<see cref="OpenTelemetryDefaults.Resolve"/>). A client without options has what the
    /// environment said when it was made, or when the client it was made from was. A client that
    /// is not the SDK's own has only its options and nothing that was read when it was made, so
    /// without options it reads the environment at each call.
    /// </summary>
    internal static OpenTelemetryOptions OpenTelemetry(IAnthropicClientWithRawResponse client) =>
        client is AnthropicClientWithRawResponse { Options: var options }
            ? options.ResolvedOpenTelemetry
            : new OpenTelemetryDefaults().Resolve(client.OpenTelemetry);

    static ActivitySource? Source(IAnthropicClientWithRawResponse client) =>
        (client as AnthropicClientWithRawResponse)?.Options.OpenTelemetrySource;

    /// <summary>
    /// Sets on <paramref name="span"/>, the call span that a Messages create method of a client
    /// with the OpenTelemetry <paramref name="options"/> just started, the content of the request
    /// with <paramref name="body"/>, as <see cref="Content.SetRequestContent"/>
    /// does. Returns what it wrote, and null outside content mode, for a span that is not
    /// recording, and when the content cannot be written.
    /// </summary>
    static RequestContent? SetMessagesCreateRequestContent(
        Activity? span,
        OpenTelemetryOptions options,
        IReadOnlyDictionary<string, JsonElement> body
    )
    {
        RequestContent? content = null;
        if (Content.IsRecorded(options))
        {
            Record(
                span,
                recordingSpan =>
                    content = Content.SetRequestContent(
                        recordingSpan,
                        body.Property("system"),
                        body.Property("messages"),
                        body.Property("stop_sequences"),
                        Content.Limit(options)
                    )
            );
        }
        return content;
    }
}
