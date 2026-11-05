using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace Anthropic.Core;

/// <summary>
/// The attributes that the SDK's configuration names for the call spans, and what sets them
/// on a span. The values come from the JSON of a request and of a response, as sent and as
/// received, so a field that this version of the SDK does not know is read like any other.
/// </summary>
internal static class SpanAttributes
{
    /// <summary>
    /// The JSON type of the source of an attribute, as the API's description has it.
    /// </summary>
    internal enum JsonType
    {
        /// <summary>
        /// The description gives the source no single type, so a value is recorded as the type
        /// that it has.
        /// </summary>
        Unknown,
        String,
        Integer,
        Number,
        Boolean,
    }

    /// <summary>
    /// The source of the attribute <paramref name="Attribute"/> of a call span: the names of the
    /// properties that lead to its value from the root of a JSON object, or the name of a header,
    /// in <paramref name="Path"/>, and the type of that value, or of its items when
    /// <paramref name="IsArray"/>.
    /// </summary>
    internal readonly record struct Source(
        string Attribute,
        string[] Path,
        JsonType Type = JsonType.Unknown,
        bool IsArray = false
    );

    /// <summary>
    /// The attributes that the SDK's configuration gives the call spans with one name.
    /// </summary>
    internal sealed class Table
    {
        /// <summary>The attributes with a fixed value.</summary>
        internal KeyValuePair<string, object?>[] Constants { get; init; } = [];

        /// <summary>The attributes from the JSON body of the request.</summary>
        internal Source[] Request { get; init; } = [];

        /// <summary>The attributes from the headers of the request.</summary>
        internal Source[] RequestHeaders { get; init; } = [];

        /// <summary>
        /// The attribute that the span of a call that streams has, as <c>true</c>. Its path leads
        /// to the property of the request's body that asks for a stream, and is empty when every
        /// call with this span name streams.
        /// </summary>
        internal Source? Stream { get; init; }

        /// <summary>The attributes from the JSON body of the response.</summary>
        internal Source[] Response { get; init; } = [];
    }

    /// <summary>
    /// The attributes that the SDK's configuration gives the call spans, by span name.
    /// </summary>
    internal static readonly Dictionary<string, Table> Tables = new()
    {
        ["anthropic.messages.create"] = new()
        {
            Constants = [new("gen_ai.operation.name", "chat")],
            Request =
            [
                new("gen_ai.request.model", ["model"], JsonType.String),
                new("gen_ai.request.max_tokens", ["max_tokens"], JsonType.Integer),
                new("gen_ai.request.reasoning.level", ["output_config", "effort"], JsonType.String),
                new("anthropic.request.service_tier", ["service_tier"], JsonType.String),
                new("anthropic.thinking.type", ["thinking", "type"], JsonType.String),
                new(
                    "anthropic.thinking.budget_tokens",
                    ["thinking", "budget_tokens"],
                    JsonType.Integer
                ),
            ],
            RequestHeaders =
            [
                new("anthropic.beta", ["anthropic-beta"], JsonType.String, IsArray: true),
            ],
            Stream = new("gen_ai.request.stream", ["stream"]),
            Response =
            [
                new("gen_ai.response.id", ["id"], JsonType.String),
                new("gen_ai.response.model", ["model"], JsonType.String),
                new(
                    "gen_ai.usage.cache_write.input_tokens",
                    ["usage", "cache_creation_input_tokens"],
                    JsonType.Integer
                ),
                new(
                    "gen_ai.usage.cache_read.input_tokens",
                    ["usage", "cache_read_input_tokens"],
                    JsonType.Integer
                ),
                new(
                    "anthropic.usage.cache_creation.ephemeral_5m_input_tokens",
                    ["usage", "cache_creation", "ephemeral_5m_input_tokens"],
                    JsonType.Integer
                ),
                new(
                    "anthropic.usage.cache_creation.ephemeral_1h_input_tokens",
                    ["usage", "cache_creation", "ephemeral_1h_input_tokens"],
                    JsonType.Integer
                ),
                new("anthropic.response.service_tier", ["usage", "service_tier"], JsonType.String),
                new("gen_ai.usage.output_tokens", ["usage", "output_tokens"], JsonType.Integer),
                new(
                    "gen_ai.usage.reasoning.output_tokens",
                    ["usage", "output_tokens_details", "thinking_tokens"],
                    JsonType.Integer
                ),
                new("anthropic.message.stop_reason", ["stop_reason"], JsonType.String),
            ],
        },
        ["anthropic.messages.count_tokens"] = new()
        {
            Request = [new("gen_ai.request.model", ["model"], JsonType.String)],
            Response =
            [
                new(
                    "anthropic.message.count_tokens.input_tokens",
                    ["input_tokens"],
                    JsonType.Integer
                ),
            ],
        },
        ["anthropic.sessions.create"] = new()
        {
            Request =
            [
                new("anthropic.session.environment.id", ["environment_id"], JsonType.String),
            ],
            Response =
            [
                new("gen_ai.agent.name", ["agent", "name"], JsonType.String),
                new("gen_ai.request.model", ["agent", "model", "id"], JsonType.String),
            ],
        },
    };

    /// <summary>
    /// Adds to <paramref name="tags"/>, the attributes that a call span named
    /// <paramref name="spanName"/> starts with, those that the SDK's configuration gives the spans
    /// of that name from the request with <paramref name="parameters"/>: the constants, the fields
    /// of the body, the headers, and whether the call streams. A header's values are those of the
    /// parameters, then those of <paramref name="clientHeaders"/>, the headers that the client
    /// sends with every request. A source that the request lacks, or whose value has another type
    /// than the API's description gives it, adds nothing, and neither does an attribute that
    /// <paramref name="tags"/> already has, such as a resource ID.
    ///
    /// <para>Never throws into the API call.</para>
    /// </summary>
    internal static void AddRequestAttributes(
        List<KeyValuePair<string, object?>> tags,
        string? spanName,
        ParamsBase parameters,
        IReadOnlyDictionary<string, string>? clientHeaders = null
    )
    {
        if (spanName == null || !Tables.TryGetValue(spanName, out var table))
        {
            return;
        }
        try
        {
            foreach (var constant in table.Constants)
            {
                Add(tags, constant.Key, constant.Value);
            }
            var body = parameters.SpanBody;
            foreach (var source in table.Request)
            {
                Add(tags, source.Attribute, Value(body, source));
            }
            foreach (var source in table.RequestHeaders)
            {
                Add(
                    tags,
                    source.Attribute,
                    HeaderValue(parameters.RawHeaderData, clientHeaders, source)
                );
            }
            if (
                table.Stream is { } stream
                && (
                    stream.Path.Length == 0
                    || Json(body, stream.Path) is { ValueKind: JsonValueKind.True }
                )
            )
            {
                Add(tags, stream.Attribute, true);
            }
        }
        catch (Exception)
        {
            // A failure to record telemetry must not fail the API call.
        }
    }

    static void Add(List<KeyValuePair<string, object?>> tags, string name, object? value)
    {
        if (value != null && !tags.Exists(tag => tag.Key == name))
        {
            tags.Add(new(name, value));
        }
    }

    /// <summary>
    /// Sets on <paramref name="span"/>, a call span, the attributes that the SDK's configuration
    /// gives the spans of its name from <paramref name="response"/>, the JSON body of the call's
    /// response. A field that the response lacks, or whose value has another type than the API's
    /// description gives it, sets nothing.
    ///
    /// <para>Never throws into the API call, and does nothing without a span, or to one that is
    /// not recording.</para>
    /// </summary>
    internal static void SetResponseAttributes(
        Activity? span,
        IReadOnlyDictionary<string, JsonElement> response
    )
    {
        if (
            span is not { IsAllDataRequested: true }
            || !Tables.TryGetValue(span.OperationName, out var table)
        )
        {
            return;
        }
        try
        {
            foreach (var source in table.Response)
            {
                if (Value(response, source) is { } value)
                {
                    span.SetTag(source.Attribute, value);
                }
            }
        }
        catch (Exception)
        {
            // A failure to record telemetry must not fail the API call.
        }
    }

    /// <summary>
    /// The JSON at <paramref name="path"/> in <paramref name="json"/>, or null when a property on
    /// the way is absent or its value is not an object.
    /// </summary>
    static JsonElement? Json(IReadOnlyDictionary<string, JsonElement>? json, string[] path)
    {
        if (json == null || path.Length == 0 || !json.TryGetValue(path[0], out var value))
        {
            return null;
        }
        for (var index = 1; index < path.Length; index++)
        {
            if (
                value.ValueKind != JsonValueKind.Object
                || !value.TryGetProperty(path[index], out var property)
            )
            {
                return null;
            }
            value = property;
        }
        return value;
    }

    /// <summary>
    /// The value of the attribute of <paramref name="source"/> in <paramref name="json"/>, or null
    /// when <paramref name="json"/> has none of the source's type.
    /// </summary>
    static object? Value(IReadOnlyDictionary<string, JsonElement>? json, Source source)
    {
        if (Json(json, source.Path) is not { } value)
        {
            return null;
        }
        if (!source.IsArray)
        {
            return Scalar(value, source.Type);
        }
        if (value.ValueKind != JsonValueKind.Array)
        {
            return null;
        }
        return source.Type switch
        {
            JsonType.String => Items<string>(value, source.Type),
            JsonType.Integer => Items<long>(value, source.Type),
            JsonType.Number => Items<double>(value, source.Type),
            JsonType.Boolean => Items<bool>(value, source.Type),
            _ => null,
        };
    }

    static T[]? Items<T>(JsonElement array, JsonType type)
    {
        List<T> items = [];
        foreach (var item in array.EnumerateArray())
        {
            if (Scalar(item, type) is not T value)
            {
                return null;
            }
            items.Add(value);
        }
        return [.. items];
    }

    static object? Scalar(JsonElement value, JsonType type) =>
        (type, value.ValueKind) switch
        {
            (JsonType.String or JsonType.Unknown, JsonValueKind.String) => value.GetString(),
            (JsonType.Integer or JsonType.Unknown, JsonValueKind.Number)
                when value.TryGetInt64(out var integer) => integer,
            (JsonType.Number or JsonType.Unknown, JsonValueKind.Number) => value.GetDouble(),
            (JsonType.Boolean or JsonType.Unknown, JsonValueKind.True or JsonValueKind.False) =>
                value.GetBoolean(),
            _ => null,
        };

    /// <summary>
    /// The value of the attribute of <paramref name="source"/>, a header, in
    /// <paramref name="headers"/>, those of a request's parameters, and
    /// <paramref name="clientHeaders"/>: each value of the header, where one header can list
    /// several between commas, as an array or, for a header that the API's description gives one
    /// value, as that value. Null when no header has a value.
    /// </summary>
    static object? HeaderValue(
        IReadOnlyDictionary<string, JsonElement> headers,
        IReadOnlyDictionary<string, string>? clientHeaders,
        Source source
    )
    {
        List<string> values = [];
        foreach (var header in headers)
        {
            if (!string.Equals(header.Key, source.Path[0], StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }
            if (header.Value.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in header.Value.EnumerateArray())
                {
                    AddHeaderValues(values, item);
                }
            }
            else
            {
                AddHeaderValues(values, header.Value);
            }
        }
        foreach (var header in clientHeaders ?? Enumerable.Empty<KeyValuePair<string, string>>())
        {
            if (string.Equals(header.Key, source.Path[0], StringComparison.OrdinalIgnoreCase))
            {
                AddHeaderValues(values, header.Value);
            }
        }
        if (values.Count == 0)
        {
            return null;
        }
        return source.IsArray ? values.ToArray() : string.Join(",", values);
    }

    static void AddHeaderValues(List<string> values, JsonElement header)
    {
        if (header.ValueKind == JsonValueKind.String)
        {
            AddHeaderValues(values, header.GetString());
        }
    }

    static void AddHeaderValues(List<string> values, string? header)
    {
        foreach (var part in (header ?? "").Split(','))
        {
            var value = part.Trim();
            if (value.Length > 0)
            {
                values.Add(value);
            }
        }
    }

    /// <summary>
    /// The attributes that come from the headers of a response, each with its header.
    /// </summary>
    static readonly KeyValuePair<string, string>[] ResponseHeaders =
    [
        new("anthropic.request.id", "request-id"),
        new("anthropic.organization.id", "anthropic-organization-id"),
        new("anthropic.workspace.id", "anthropic-workspace-id"),
    ];

    /// <summary>
    /// Sets on <paramref name="span"/>, the call span of an API call, the attributes that the
    /// SDK's configuration takes from the headers of <paramref name="response"/>, the response of
    /// the call's final attempt: each has the first value of its header that is not empty. Does
    /// nothing to a span that is not recording.
    /// </summary>
    internal static void SetResponseHeaderAttributes(Activity span, HttpResponseMessage response)
    {
        if (!span.IsAllDataRequested)
        {
            return;
        }
        foreach (var attribute in ResponseHeaders)
        {
            if (!response.Headers.TryGetValues(attribute.Value, out var values))
            {
                continue;
            }
            foreach (var value in values)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    span.SetTag(attribute.Key, value);
                    break;
                }
            }
        }
    }
}
