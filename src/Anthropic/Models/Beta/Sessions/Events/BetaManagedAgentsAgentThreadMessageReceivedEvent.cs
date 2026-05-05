using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Delivery event written to the target thread's input stream when an agent-to-agent
/// message arrives.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentThreadMessageReceivedEvent,
        BetaManagedAgentsAgentThreadMessageReceivedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentThreadMessageReceivedEvent : JsonModel
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
    /// Message content blocks.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsAgentThreadMessageReceivedEventContent> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsAgentThreadMessageReceivedEventContent>
            >("content");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<BetaManagedAgentsAgentThreadMessageReceivedEventContent>
            >("content", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Public `sthr_` ID of the thread that sent the message.
    /// </summary>
    public required string FromSessionThreadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("from_session_thread_id");
        }
        init { this._rawData.Set("from_session_thread_id", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Name of the callable agent this message came from. Absent when received from
    /// the primary agent.
    /// </summary>
    public string? FromAgentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from_agent_name");
        }
        init { this._rawData.Set("from_agent_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.FromSessionThreadID;
        _ = this.ProcessedAt;
        this.Type.Validate();
        _ = this.FromAgentName;
    }

    public BetaManagedAgentsAgentThreadMessageReceivedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentThreadMessageReceivedEvent(
        BetaManagedAgentsAgentThreadMessageReceivedEvent betaManagedAgentsAgentThreadMessageReceivedEvent
    )
        : base(betaManagedAgentsAgentThreadMessageReceivedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentThreadMessageReceivedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentThreadMessageReceivedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentThreadMessageReceivedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentThreadMessageReceivedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentThreadMessageReceivedEventFromRaw
    : IFromRawJson<BetaManagedAgentsAgentThreadMessageReceivedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentThreadMessageReceivedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentThreadMessageReceivedEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Content block in a user message. Can be `text`, `image`, or `document`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsAgentThreadMessageReceivedEventContentConverter))]
public record class BetaManagedAgentsAgentThreadMessageReceivedEventContent : ModelBase
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

    public BetaManagedAgentsAgentThreadMessageReceivedEventContent(
        BetaManagedAgentsTextBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentThreadMessageReceivedEventContent(
        BetaManagedAgentsImageBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentThreadMessageReceivedEventContent(
        BetaManagedAgentsDocumentBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentThreadMessageReceivedEventContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTextBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTextBlock(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTextBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTextBlock(
        [NotNullWhen(true)] out BetaManagedAgentsTextBlock? value
    )
    {
        value = this.Value as BetaManagedAgentsTextBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsImageBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsImageBlock(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsImageBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsImageBlock(
        [NotNullWhen(true)] out BetaManagedAgentsImageBlock? value
    )
    {
        value = this.Value as BetaManagedAgentsImageBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsDocumentBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsDocumentBlock(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsDocumentBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsDocumentBlock(
        [NotNullWhen(true)] out BetaManagedAgentsDocumentBlock? value
    )
    {
        value = this.Value as BetaManagedAgentsDocumentBlock;
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
    ///     (BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (BetaManagedAgentsImageBlock value) =&gt; {...},
    ///     (BetaManagedAgentsDocumentBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsTextBlock> betaManagedAgentsTextBlock,
        System::Action<BetaManagedAgentsImageBlock> betaManagedAgentsImageBlock,
        System::Action<BetaManagedAgentsDocumentBlock> betaManagedAgentsDocumentBlock
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsTextBlock value:
                betaManagedAgentsTextBlock(value);
                break;
            case BetaManagedAgentsImageBlock value:
                betaManagedAgentsImageBlock(value);
                break;
            case BetaManagedAgentsDocumentBlock value:
                betaManagedAgentsDocumentBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsAgentThreadMessageReceivedEventContent"
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
    ///     (BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (BetaManagedAgentsImageBlock value) =&gt; {...},
    ///     (BetaManagedAgentsDocumentBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsTextBlock, T> betaManagedAgentsTextBlock,
        System::Func<BetaManagedAgentsImageBlock, T> betaManagedAgentsImageBlock,
        System::Func<BetaManagedAgentsDocumentBlock, T> betaManagedAgentsDocumentBlock
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsTextBlock value => betaManagedAgentsTextBlock(value),
            BetaManagedAgentsImageBlock value => betaManagedAgentsImageBlock(value),
            BetaManagedAgentsDocumentBlock value => betaManagedAgentsDocumentBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsAgentThreadMessageReceivedEventContent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsAgentThreadMessageReceivedEventContent(
        BetaManagedAgentsTextBlock value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentThreadMessageReceivedEventContent(
        BetaManagedAgentsImageBlock value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentThreadMessageReceivedEventContent(
        BetaManagedAgentsDocumentBlock value
    ) => new(value);

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
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsAgentThreadMessageReceivedEventContent"
            );
        }
        this.Switch(
            (betaManagedAgentsTextBlock) => betaManagedAgentsTextBlock.Validate(),
            (betaManagedAgentsImageBlock) => betaManagedAgentsImageBlock.Validate(),
            (betaManagedAgentsDocumentBlock) => betaManagedAgentsDocumentBlock.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsAgentThreadMessageReceivedEventContent? other) =>
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
            BetaManagedAgentsTextBlock _ => 0,
            BetaManagedAgentsImageBlock _ => 1,
            BetaManagedAgentsDocumentBlock _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsAgentThreadMessageReceivedEventContentConverter
    : JsonConverter<BetaManagedAgentsAgentThreadMessageReceivedEventContent>
{
    public override BetaManagedAgentsAgentThreadMessageReceivedEventContent? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTextBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsImageBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDocumentBlock>(
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
                return new BetaManagedAgentsAgentThreadMessageReceivedEventContent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsAgentThreadMessageReceivedEventTypeConverter))]
public enum BetaManagedAgentsAgentThreadMessageReceivedEventType
{
    AgentThreadMessageReceived,
}

sealed class BetaManagedAgentsAgentThreadMessageReceivedEventTypeConverter
    : JsonConverter<BetaManagedAgentsAgentThreadMessageReceivedEventType>
{
    public override BetaManagedAgentsAgentThreadMessageReceivedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.thread_message_received" =>
                BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
            _ => (BetaManagedAgentsAgentThreadMessageReceivedEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentThreadMessageReceivedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived =>
                    "agent.thread_message_received",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
