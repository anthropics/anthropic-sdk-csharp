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
/// A user message event in the session conversation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserMessageEvent,
        BetaManagedAgentsUserMessageEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserMessageEvent : JsonModel
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
    /// Array of content blocks comprising the user message.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsUserMessageEventContent> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsUserMessageEventContent>
            >("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsUserMessageEventContent>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsUserMessageEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserMessageEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        this.Type.Validate();
        _ = this.ProcessedAt;
    }

    public BetaManagedAgentsUserMessageEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserMessageEvent(
        BetaManagedAgentsUserMessageEvent betaManagedAgentsUserMessageEvent
    )
        : base(betaManagedAgentsUserMessageEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserMessageEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserMessageEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserMessageEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserMessageEventFromRaw : IFromRawJson<BetaManagedAgentsUserMessageEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserMessageEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Content block in a user message. Can be `text`, `image`, or `document`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsUserMessageEventContentConverter))]
public record class BetaManagedAgentsUserMessageEventContent : ModelBase
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

    public BetaManagedAgentsUserMessageEventContent(
        BetaManagedAgentsTextBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserMessageEventContent(
        BetaManagedAgentsImageBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserMessageEventContent(
        BetaManagedAgentsDocumentBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserMessageEventContent(JsonElement element)
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
                    "Data did not match any variant of BetaManagedAgentsUserMessageEventContent"
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
                "Data did not match any variant of BetaManagedAgentsUserMessageEventContent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsUserMessageEventContent(
        BetaManagedAgentsTextBlock value
    ) => new(value);

    public static implicit operator BetaManagedAgentsUserMessageEventContent(
        BetaManagedAgentsImageBlock value
    ) => new(value);

    public static implicit operator BetaManagedAgentsUserMessageEventContent(
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
                "Data did not match any variant of BetaManagedAgentsUserMessageEventContent"
            );
        }
        this.Switch(
            (betaManagedAgentsTextBlock) => betaManagedAgentsTextBlock.Validate(),
            (betaManagedAgentsImageBlock) => betaManagedAgentsImageBlock.Validate(),
            (betaManagedAgentsDocumentBlock) => betaManagedAgentsDocumentBlock.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsUserMessageEventContent? other) =>
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

sealed class BetaManagedAgentsUserMessageEventContentConverter
    : JsonConverter<BetaManagedAgentsUserMessageEventContent>
{
    public override BetaManagedAgentsUserMessageEventContent? Read(
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
                return new BetaManagedAgentsUserMessageEventContent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserMessageEventContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsUserMessageEventTypeConverter))]
public enum BetaManagedAgentsUserMessageEventType
{
    UserMessage,
}

sealed class BetaManagedAgentsUserMessageEventTypeConverter
    : JsonConverter<BetaManagedAgentsUserMessageEventType>
{
    public override BetaManagedAgentsUserMessageEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.message" => BetaManagedAgentsUserMessageEventType.UserMessage,
            _ => (BetaManagedAgentsUserMessageEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserMessageEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserMessageEventType.UserMessage => "user.message",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
