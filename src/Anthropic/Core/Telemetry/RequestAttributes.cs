using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using static Anthropic.Core.Telemetry.ActivityTags;
using static Anthropic.Core.Telemetry.SemanticConventions;
using BetaMessages = Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// The request attributes of a Messages call span. The Messages methods start their span with
/// them, from the parameters they are called with, so that a sampler sees them.
/// </summary>
static class RequestAttributes
{
    /// <summary>
    /// Starts the call span of a Messages create method of <paramref name="client"/>, with the
    /// request attributes for a sampler to decide on: those of <paramref name="parameters"/>,
    /// whether the method asks for a <paramref name="stream"/>, and the beta versions that its
    /// requests carry. In content mode it also sets the request's content. Returns the span, and
    /// what it wrote of the content for the response's content to be written beside it.
    ///
    /// <para>Never throws into the API call, and sets no content on a span that is not
    /// recording. When the client would emit no span (<see cref="ApiCallSpans.IsEnabled"/>), it
    /// reads nothing of <paramref name="parameters"/>.</para>
    /// </summary>
    internal static (Activity?, RequestContent?) StartMessagesCreateSpan(
        IAnthropicClientWithRawResponse client,
        Messages::MessageCreateParams parameters,
        bool stream
    )
    {
        if (!ApiCallSpans.IsEnabled(client))
        {
            return (null, null);
        }
        var span = StartMessagesCreateSpan(
            client,
            parameters,
            parameters.RawBodyData,
            tags =>
                AddMessagesCreateRequestAttributes(
                    tags,
                    maxTokens: parameters.MaxTokens,
                    temperature: parameters.Temperature,
                    topP: parameters.TopP,
                    topK: parameters.TopK,
                    stream: stream,
                    effort: parameters.OutputConfig?.Effort?.Raw(),
                    outputFormat: parameters.OutputConfig?.Format != null,
                    serviceTier: parameters.ServiceTier?.Raw(),
                    thinkingType: parameters.Thinking?.Json.Text("type"),
                    thinkingBudgetTokens: parameters.Thinking is { } thinking
                    && thinking.TryPickEnabled(out var enabled)
                        ? enabled.BudgetTokens
                        : null,
                    betas: Betas(parameters, client)
                )
        );
        return (
            span,
            SetMessagesCreateRequestContent(span, OpenTelemetry(client), parameters.RawBodyData)
        );
    }

    /// <inheritdoc cref="StartMessagesCreateSpan(IAnthropicClientWithRawResponse, Messages::MessageCreateParams, bool)"/>
    internal static (Activity?, RequestContent?) StartMessagesCreateSpan(
        IAnthropicClientWithRawResponse client,
        BetaMessages::MessageCreateParams parameters,
        bool stream
    )
    {
        if (!ApiCallSpans.IsEnabled(client))
        {
            return (null, null);
        }
        var span = StartMessagesCreateSpan(
            client,
            parameters,
            parameters.RawBodyData,
            tags =>
                AddMessagesCreateRequestAttributes(
                    tags,
                    maxTokens: parameters.MaxTokens,
                    temperature: parameters.Temperature,
                    topP: parameters.TopP,
                    topK: parameters.TopK,
                    stream: stream,
                    effort: parameters.OutputConfig?.Effort?.Raw(),
                    // The request sets `output_config.format`, or the deprecated `output_format`.
#pragma warning disable CS0618
                    outputFormat: parameters.OutputConfig?.Format != null
                        || parameters.OutputFormat != null,
#pragma warning restore CS0618
                    serviceTier: parameters.ServiceTier?.Raw(),
                    thinkingType: parameters.Thinking?.Json.Text("type"),
                    thinkingBudgetTokens: parameters.Thinking is { } thinking
                    && thinking.TryPickEnabled(out var enabled)
                        ? enabled.BudgetTokens
                        : null,
                    betas: Betas(parameters, client)
                )
        );
        return (
            span,
            SetMessagesCreateRequestContent(span, OpenTelemetry(client), parameters.RawBodyData)
        );
    }

    /// <summary>
    /// Starts the call span of a Messages create method of <paramref name="client"/>, whose
    /// request has <paramref name="parameters"/> and their <paramref name="body"/>, with the
    /// operation, the attributes that every Messages call span starts with, and those that
    /// <paramref name="addRequestAttributes"/> adds.
    /// </summary>
    static Activity? StartMessagesCreateSpan(
        IAnthropicClientWithRawResponse client,
        ParamsBase parameters,
        IReadOnlyDictionary<string, JsonElement> body,
        Action<List<KeyValuePair<string, object?>>> addRequestAttributes
    )
    {
        var tags = StartAttributes(client, parameters, body);
        tags.Add(new(AttributeGenAiOperationName, GenAiOperationName.Chat));
        // A failure to record telemetry must not fail the API call, and a model throws for a
        // required field that the parameters do not have.
        try
        {
            addRequestAttributes(tags);
        }
        catch (Exception) { }
        return Tracing.StartApiCallSpan(
            OpenTelemetry(client),
            "anthropic.messages.create",
            tags,
            Source(client)
        );
    }

    /// <summary>
    /// The attributes that the call span of a Messages method of <paramref name="client"/>, whose
    /// request has <paramref name="parameters"/> and their <paramref name="body"/>, starts with
    /// whatever the method: those of the client's options, the HTTP method and the route of the
    /// request, and the model. Every Messages method sends a <c>POST</c>. A method sees its client
    /// through the client's public interface, which does not have all the options, so they are
    /// those of the SDK's own client class.
    /// </summary>
    static List<KeyValuePair<string, object?>> StartAttributes(
        IAnthropicClientWithRawResponse client,
        ParamsBase parameters,
        IReadOnlyDictionary<string, JsonElement> body
    )
    {
        var tags = client is AnthropicClientWithRawResponse { Options: var options }
            ? ApiCallSpans.StartAttributes(options)
            : [];
        Tracing.AddRequestAttributes(tags, HttpMethod.Post, parameters);
        tags.AddTag(AttributeGenAiRequestModel, body.Text("model"));
        return tags;
    }

    /// <summary>
    /// Adds to <paramref name="tags"/> the request attributes of a Messages create call, stable or
    /// beta, from the values of its parameters.
    /// </summary>
    static void AddMessagesCreateRequestAttributes(
        List<KeyValuePair<string, object?>> tags,
        long maxTokens,
        double? temperature,
        double? topP,
        long? topK,
        bool stream,
        string? effort,
        bool outputFormat,
        string? serviceTier,
        string? thinkingType,
        long? thinkingBudgetTokens,
        List<string> betas
    )
    {
        tags.Add(new(AttributeGenAiRequestMaxTokens, maxTokens));
        tags.AddTag(AttributeGenAiRequestTemperature, temperature);
        tags.AddTag(AttributeGenAiRequestTopP, topP);
        tags.AddTag(AttributeGenAiRequestTopK, topK);
        if (stream)
        {
            tags.Add(new(AttributeGenAiRequestStream, true));
        }
        tags.AddTag(AttributeGenAiRequestReasoningLevel, effort);
        if (outputFormat)
        {
            tags.Add(new(AttributeGenAiOutputType, GenAiOutputType.Json));
        }
        tags.AddTag(AttributeAnthropicRequestServiceTier, serviceTier);
        tags.AddTag(AttributeAnthropicThinkingType, thinkingType);
        tags.AddTag(AttributeAnthropicThinkingBudgetTokens, thinkingBudgetTokens);
        if (betas.Count > 0)
        {
            tags.Add(new(AttributeAnthropicBeta, betas.ToArray()));
        }
    }

    /// <summary>
    /// Starts the call span of a Messages count-tokens method of <paramref name="client"/>, stable
    /// or beta, whose request has <paramref name="parameters"/> and their <paramref name="body"/>,
    /// with the model for a sampler to decide on.
    /// </summary>
    internal static Activity? StartCountTokensSpan(
        IAnthropicClientWithRawResponse client,
        ParamsBase parameters,
        IReadOnlyDictionary<string, JsonElement> body
    ) =>
        ApiCallSpans.IsEnabled(client)
            ? Tracing.StartApiCallSpan(
                OpenTelemetry(client),
                "anthropic.messages.count_tokens",
                StartAttributes(client, parameters, body),
                Source(client)
            )
            : null;

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
    /// The <c>anthropic-beta</c> values that a call's requests carry: those of
    /// <paramref name="parameters"/>, then those of the extra headers of <paramref name="client"/>.
    /// A method sees its client through the client's public interface, which does not have the
    /// extra headers, so they are those of the SDK's own client class.
    /// </summary>
    static List<string> Betas(ParamsBase parameters, IAnthropicClientWithRawResponse client)
    {
        var betas = new List<string>();
        if (parameters.RawHeaderData.Property("anthropic-beta") is { } header)
        {
            switch (header.ValueKind)
            {
                case JsonValueKind.String:
                    AddBetas(betas, header.GetString());
                    break;
                case JsonValueKind.Array:
                    foreach (var item in header.EnumerateArray())
                    {
                        AddBetas(betas, item.StringValue());
                    }
                    break;
            }
        }
        if (
            client is AnthropicClientWithRawResponse { Options.ExtraHeaders: { } extraHeaders }
            && extraHeaders.TryGetValue("anthropic-beta", out var extra)
        )
        {
            AddBetas(betas, extra);
        }
        return betas;
    }

    /// <summary>
    /// Adds to <paramref name="betas"/> the beta versions in <paramref name="header"/>, one
    /// comma-separated <c>anthropic-beta</c> header value.
    /// </summary>
    static void AddBetas(List<string> betas, string? header)
    {
        foreach (var beta in (header ?? "").Split(','))
        {
            var name = beta.Trim();
            if (name.Length > 0)
            {
                betas.Add(name);
            }
        }
    }

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
