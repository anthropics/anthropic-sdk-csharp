using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Events = Anthropic.Models.Beta.Sessions.Events;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Event sent by the client providing the result of an agent-toolset tool execution.
/// Only valid on `self_hosted` environments, where sandbox-routed tools are executed
/// by the client rather than the server.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserToolResultEvent,
        BetaManagedAgentsUserToolResultEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserToolResultEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The id of the `agent.tool_use` event this result corresponds to, which can
    /// be found in the last `session.status_idle` [event's](https://platform.claude.com/docs/en/api/beta/sessions/events/list#beta_managed_agents_session_requires_action.event_ids)
    /// `stop_reason.event_ids` field.
    /// </summary>
    public required string ToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_use_id");
        }
        init { this._rawData.Set("tool_use_id", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsUserToolResultEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserToolResultEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The result content returned by the tool.
    /// </summary>
    public IReadOnlyList<Content>? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Content>>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Content>?>(
                "content",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the tool execution resulted in an error.
    /// </summary>
    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init { this._rawData.Set("is_error", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public System::DateTimeOffset? ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    /// <summary>
    /// Routes this result to a subagent thread. Copy from the `agent.tool_use` event's `session_thread_id`.
    /// </summary>
    public string? SessionThreadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("session_thread_id");
        }
        init { this._rawData.Set("session_thread_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ToolUseID;
        this.Type.Validate();
        foreach (var item in this.Content ?? [])
        {
            item.Validate();
        }
        _ = this.IsError;
        _ = this.ProcessedAt;
        _ = this.SessionThreadID;
    }

    public BetaManagedAgentsUserToolResultEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserToolResultEvent(
        BetaManagedAgentsUserToolResultEvent betaManagedAgentsUserToolResultEvent
    )
        : base(betaManagedAgentsUserToolResultEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserToolResultEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserToolResultEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserToolResultEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserToolResultEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserToolResultEventFromRaw
    : IFromRawJson<BetaManagedAgentsUserToolResultEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserToolResultEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserToolResultEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUserToolResultEventTypeConverter))]
public enum BetaManagedAgentsUserToolResultEventType
{
    UserToolResult,
}

sealed class BetaManagedAgentsUserToolResultEventTypeConverter
    : JsonConverter<BetaManagedAgentsUserToolResultEventType>
{
    public override BetaManagedAgentsUserToolResultEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.tool_result" => BetaManagedAgentsUserToolResultEventType.UserToolResult,
            _ => (BetaManagedAgentsUserToolResultEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserToolResultEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserToolResultEventType.UserToolResult => "user.tool_result",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Content block in a tool result. Can be `text`, `image`, `document`, or `search_result`.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record class Content : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                betaManagedAgentsTextBlock: (_) => null,
                betaManagedAgentsImageBlock: (_) => null,
                betaManagedAgentsDocumentBlock: (x) => x.Title,
                betaManagedAgentsSearchResultBlock: (x) => x.Title
            );
        }
    }

    public Content(Events::BetaManagedAgentsTextBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(Events::BetaManagedAgentsImageBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(Events::BetaManagedAgentsDocumentBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(Events::BetaManagedAgentsSearchResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Events::BetaManagedAgentsTextBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTextBlock(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsTextBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTextBlock(
        [NotNullWhen(true)] out Events::BetaManagedAgentsTextBlock? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsTextBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Events::BetaManagedAgentsImageBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsImageBlock(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsImageBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsImageBlock(
        [NotNullWhen(true)] out Events::BetaManagedAgentsImageBlock? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsImageBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Events::BetaManagedAgentsDocumentBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsDocumentBlock(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsDocumentBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsDocumentBlock(
        [NotNullWhen(true)] out Events::BetaManagedAgentsDocumentBlock? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsDocumentBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Events::BetaManagedAgentsSearchResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSearchResultBlock(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsSearchResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSearchResultBlock(
        [NotNullWhen(true)] out Events::BetaManagedAgentsSearchResultBlock? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsSearchResultBlock;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Events::BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsImageBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsDocumentBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsSearchResultBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Events::BetaManagedAgentsTextBlock> betaManagedAgentsTextBlock,
        System::Action<Events::BetaManagedAgentsImageBlock> betaManagedAgentsImageBlock,
        System::Action<Events::BetaManagedAgentsDocumentBlock> betaManagedAgentsDocumentBlock,
        System::Action<Events::BetaManagedAgentsSearchResultBlock> betaManagedAgentsSearchResultBlock
    )
    {
        switch (this.Value)
        {
            case Events::BetaManagedAgentsTextBlock value:
                betaManagedAgentsTextBlock(value);
                break;
            case Events::BetaManagedAgentsImageBlock value:
                betaManagedAgentsImageBlock(value);
                break;
            case Events::BetaManagedAgentsDocumentBlock value:
                betaManagedAgentsDocumentBlock(value);
                break;
            case Events::BetaManagedAgentsSearchResultBlock value:
                betaManagedAgentsSearchResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Events::BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsImageBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsDocumentBlock value) =&gt; {...},
    ///     (Events::BetaManagedAgentsSearchResultBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Events::BetaManagedAgentsTextBlock, T> betaManagedAgentsTextBlock,
        System::Func<Events::BetaManagedAgentsImageBlock, T> betaManagedAgentsImageBlock,
        System::Func<Events::BetaManagedAgentsDocumentBlock, T> betaManagedAgentsDocumentBlock,
        System::Func<
            Events::BetaManagedAgentsSearchResultBlock,
            T
        > betaManagedAgentsSearchResultBlock
    )
    {
        return this.Value switch
        {
            Events::BetaManagedAgentsTextBlock value => betaManagedAgentsTextBlock(value),
            Events::BetaManagedAgentsImageBlock value => betaManagedAgentsImageBlock(value),
            Events::BetaManagedAgentsDocumentBlock value => betaManagedAgentsDocumentBlock(value),
            Events::BetaManagedAgentsSearchResultBlock value => betaManagedAgentsSearchResultBlock(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public static implicit operator Content(Events::BetaManagedAgentsTextBlock value) => new(value);

    public static implicit operator Content(Events::BetaManagedAgentsImageBlock value) =>
        new(value);

    public static implicit operator Content(Events::BetaManagedAgentsDocumentBlock value) =>
        new(value);

    public static implicit operator Content(Events::BetaManagedAgentsSearchResultBlock value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content");
        }
        this.Switch(
            (betaManagedAgentsTextBlock) => betaManagedAgentsTextBlock.Validate(),
            (betaManagedAgentsImageBlock) => betaManagedAgentsImageBlock.Validate(),
            (betaManagedAgentsDocumentBlock) => betaManagedAgentsDocumentBlock.Validate(),
            (betaManagedAgentsSearchResultBlock) => betaManagedAgentsSearchResultBlock.Validate()
        );
    }

    public virtual bool Equals(Content? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Events::BetaManagedAgentsTextBlock _ => 0,
            Events::BetaManagedAgentsImageBlock _ => 1,
            Events::BetaManagedAgentsDocumentBlock _ => 2,
            Events::BetaManagedAgentsSearchResultBlock _ => 3,
            _ => -1,
        };
    }
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "text":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsTextBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "image":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsImageBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "document":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsDocumentBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "search_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsSearchResultBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Content(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
