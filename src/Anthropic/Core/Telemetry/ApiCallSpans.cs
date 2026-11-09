using System;
using System.Collections.Generic;
using System.Text.Json;
using static Anthropic.Core.Telemetry.ActivityTags;
using static Anthropic.Core.Telemetry.SemanticConventions;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// The <c>gen_ai.*</c> and <c>anthropic.*</c> attributes that every call span has, whatever the
/// method. The span starts with those of the client's options and the resource IDs that the
/// method names on its request (<see cref="StartAttributes"/>), so that a sampler sees them. The
/// client sets those of the response headers when the response of the final attempt arrives
/// (<see cref="SpanAttributes.SetResponseHeaderAttributes"/>), and a method that creates an
/// object sets the object's ID from its response (<see cref="Tracing.SetCreatedId{T}"/>). What a
/// method computes from its own request and response it gives the span it starts: the Messages
/// create methods do (<see cref="RequestAttributes"/>, <see cref="ResponseAttributes"/>,
/// <see cref="StreamRecording"/>).
/// </summary>
static class ApiCallSpans
{
    const string AttributeAnthropicSessionThreadId = "anthropic.session.thread.id";

    /// <summary>
    /// Whether <paramref name="client"/> would emit a span now: something listens to its source,
    /// and its options leave spans on. A method asks before it reads its parameters or builds
    /// attributes for its span, so that an application that does not trace pays for neither.
    /// Whether anything listens is asked first, and the options are read only then.
    /// </summary>
    internal static bool IsEnabled(IAnthropicClientWithRawResponse client) =>
        client is AnthropicClientWithRawResponse { Options: var options }
            ? Tracing.IsEnabled(options)
            : Tracing.HasListeners(null) && Tracing.TracesEnabled(client.OpenTelemetry);

    /// <summary>
    /// The attributes that every span of a client with <paramref name="options"/> starts with, a
    /// tool runner's spans too: the provider, and the conversation ID of the options, or
    /// <paramref name="conversationId"/> when they have none.
    /// </summary>
    internal static List<KeyValuePair<string, object?>> ClientAttributes(
        ClientOptions options,
        object? conversationId = null
    )
    {
        List<KeyValuePair<string, object?>> tags =
        [
            new(AttributeGenAiProviderName, options.OpenTelemetryProviderName),
        ];
        tags.AddTag(
            AttributeGenAiConversationId,
            NonEmpty(options.OpenTelemetryRequest?.ConversationId) ?? conversationId
        );
        return tags;
    }

    /// <summary>
    /// The attributes that the call span of an API call that a client with
    /// <paramref name="options"/> is about to make starts with: those that every span of the client
    /// starts with and the server of the options, then <paramref name="resourceIds"/>, the IDs in
    /// the request's path, each under the name of its attribute. A failed call keeps them. The
    /// server is the host of the base URL, and its port or the scheme's default. A call to a
    /// Session thread's path whose options have no conversation ID has the thread's ID for it.
    /// </summary>
    internal static List<KeyValuePair<string, object?>> StartAttributes(
        ClientOptions options,
        IReadOnlyList<KeyValuePair<string, object?>>? resourceIds = null
    )
    {
        var tags = ClientAttributes(options, SessionThreadId(resourceIds));
        if (Uri.TryCreate(options.BaseUrl, UriKind.Absolute, out var baseUrl))
        {
            // `Uri.Host` keeps an IPv6 literal's brackets, which delimit it in a URL;
            // `server.address` is the bare address.
            tags.Add(new(Tracing.AttributeServerAddress, baseUrl.Host.Trim('[', ']')));
            tags.Add(new(Tracing.AttributeServerPort, baseUrl.Port));
        }
        foreach (var resourceId in resourceIds ?? [])
        {
            tags.AddTag(resourceId.Key, resourceId.Value);
        }
        return tags;
    }

    static object? SessionThreadId(IReadOnlyList<KeyValuePair<string, object?>>? resourceIds)
    {
        foreach (var resourceId in resourceIds ?? [])
        {
            if (resourceId.Key == AttributeAnthropicSessionThreadId)
            {
                return resourceId.Value;
            }
        }
        return null;
    }

    /// <summary>
    /// The attributes that the call span of a Message Batches create call, stable or beta, whose
    /// request has <paramref name="body"/>, starts with besides those of every call span: the
    /// number of requests in the batch.
    /// </summary>
    internal static List<KeyValuePair<string, object?>> BatchesCreateAttributes(
        IReadOnlyDictionary<string, JsonElement> body
    ) =>
        body.Property("requests") is { ValueKind: JsonValueKind.Array } requests
            ? [new("anthropic.message.batch.request_count", requests.GetArrayLength())]
            : [];

    /// <summary>
    /// The resource ID that the call span of a Sessions create call whose request has
    /// <paramref name="body"/> starts with besides those that the SDK's configuration names: the
    /// agent, which the request names by its ID or with an object that has the ID.
    /// </summary>
    internal static List<KeyValuePair<string, object?>> SessionsCreateIds(
        IReadOnlyDictionary<string, JsonElement> body
    )
    {
        List<KeyValuePair<string, object?>> ids = [];
        var agent = body.Property("agent");
        ids.AddTag("gen_ai.agent.id", agent?.StringValue() ?? agent?.Text("id"));
        return ids;
    }

    static string? NonEmpty(string? value) => string.IsNullOrEmpty(value) ? null : value;
}
