using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Anthropic.Models.Beta.Sessions;
using static Anthropic.Core.Telemetry.ActivityTags;
using static Anthropic.Core.Telemetry.SemanticConventions;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// The <c>gen_ai.*</c> and <c>anthropic.*</c> attributes that every call span has, whatever the
/// method. The span starts with those of the client's options and the resource IDs that the
/// method names on its request (<see cref="StartAttributes"/>), so that a sampler sees them. The
/// client sets those of the response headers when the response of the final attempt arrives
/// (<see cref="SetResponseHeaderAttributes"/>), and a method that creates an object sets the
/// object's ID from its response (<see cref="Tracing.SetCreatedId{T}"/>). What else a method knows
/// of its own request and response it gives the span it starts: the Messages methods do
/// (<see cref="RequestAttributes"/>, <see cref="ResponseAttributes"/>,
/// <see cref="StreamRecording"/>).
/// </summary>
static class ApiCallSpans
{
    /// <summary>
    /// The attributes that come from response headers, each with its header.
    /// </summary>
    static readonly KeyValuePair<string, string>[] ResponseHeaderAttributes =
    [
        new(AttributeAnthropicRequestId, "request-id"),
        new(AttributeAnthropicOrganizationId, "anthropic-organization-id"),
        new(AttributeAnthropicWorkspaceId, "anthropic-workspace-id"),
    ];

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
    /// The attributes that the call span of a Message Batches create call, stable or beta, starts
    /// with besides those of every call span: the number of requests in the batch, which
    /// <paramref name="requestCount"/> reads from the method's parameters.
    /// </summary>
    internal static List<KeyValuePair<string, object?>> BatchesCreateAttributes(
        Func<int> requestCount
    )
    {
        // A model throws for a required field that the parameters do not have.
        try
        {
            return [new("anthropic.message.batch.request_count", requestCount())];
        }
        catch (Exception)
        {
            return [];
        }
    }

    /// <summary>
    /// The resource IDs that the call span of a Sessions create call with
    /// <paramref name="parameters"/> starts with: the agent and the environment that the request
    /// names, which the API's span of the same name has too.
    /// </summary>
    internal static List<KeyValuePair<string, object?>> SessionsCreateIds(
        SessionCreateParams parameters
    )
    {
        List<KeyValuePair<string, object?>> ids = [];
        // A model throws for a required field that the parameters do not have.
        try
        {
            var agent = parameters.Agent;
            ids.Add(new("gen_ai.agent.id", agent.TryPickString(out var id) ? id : agent.ID));
            ids.Add(new("anthropic.session.environment.id", parameters.EnvironmentID));
        }
        catch (Exception) { }
        return ids;
    }

    /// <summary>
    /// Sets on <paramref name="span"/>, the call span of a Sessions create call, the name and the
    /// model of the agent of <paramref name="created"/>. The model is the one that the Session
    /// resolved, which an override in the request can differ from.
    /// </summary>
    internal static void SetSessionAgent(Activity? span, BetaManagedAgentsSession created) =>
        Record(
            span,
            recordingSpan =>
            {
                var agent = created.Agent;
                SetTag(recordingSpan, "gen_ai.agent.name", agent.Name);
                SetTag(recordingSpan, AttributeGenAiRequestModel, agent.Model.ID.Raw());
            }
        );

    /// <summary>
    /// Sets on <paramref name="span"/>, the call span of an API call, the IDs that the headers of
    /// <paramref name="response"/> carry, the response of the call's final attempt. Does nothing
    /// to a span that is not recording.
    /// </summary>
    internal static void SetResponseHeaderAttributes(Activity span, HttpResponseMessage response)
    {
        if (!span.IsAllDataRequested)
        {
            return;
        }
        foreach (var attribute in ResponseHeaderAttributes)
        {
            SetTag(span, attribute.Key, FirstValue(response.Headers, attribute.Value));
        }
    }

    static string? FirstValue(HttpResponseHeaders headers, string name)
    {
        if (headers.TryGetValues(name, out var values))
        {
            foreach (var value in values)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
            }
        }
        return null;
    }

    static string? NonEmpty(string? value) => string.IsNullOrEmpty(value) ? null : value;
}
