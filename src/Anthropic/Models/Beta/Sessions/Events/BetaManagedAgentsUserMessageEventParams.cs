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
/// Parameters for sending a user message to the session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserMessageEventParams,
        BetaManagedAgentsUserMessageEventParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserMessageEventParams : JsonModel
{
    /// <summary>
    /// Array of content blocks for the user message.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsUserMessageEventParamsContent> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsUserMessageEventParamsContent>
            >("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsUserMessageEventParamsContent>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsUserMessageEventParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserMessageEventParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        this.Type.Validate();
    }

    public BetaManagedAgentsUserMessageEventParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserMessageEventParams(
        BetaManagedAgentsUserMessageEventParams betaManagedAgentsUserMessageEventParams
    )
        : base(betaManagedAgentsUserMessageEventParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserMessageEventParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserMessageEventParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserMessageEventParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserMessageEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserMessageEventParamsFromRaw
    : IFromRawJson<BetaManagedAgentsUserMessageEventParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserMessageEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserMessageEventParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Content block in a user message. Can be `text`, `image`, or `document`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsUserMessageEventParamsContentConverter))]
public record class BetaManagedAgentsUserMessageEventParamsContent : ModelBase
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

    public BetaManagedAgentsUserMessageEventParamsContent(
        BetaManagedAgentsTextBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserMessageEventParamsContent(
        BetaManagedAgentsImageBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserMessageEventParamsContent(
        BetaManagedAgentsDocumentBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserMessageEventParamsContent(JsonElement element)
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
                    "Data did not match any variant of BetaManagedAgentsUserMessageEventParamsContent"
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
                "Data did not match any variant of BetaManagedAgentsUserMessageEventParamsContent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsUserMessageEventParamsContent(
        BetaManagedAgentsTextBlock value
    ) => new(value);

    public static implicit operator BetaManagedAgentsUserMessageEventParamsContent(
        BetaManagedAgentsImageBlock value
    ) => new(value);

    public static implicit operator BetaManagedAgentsUserMessageEventParamsContent(
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
                "Data did not match any variant of BetaManagedAgentsUserMessageEventParamsContent"
            );
        }
        this.Switch(
            (betaManagedAgentsTextBlock) => betaManagedAgentsTextBlock.Validate(),
            (betaManagedAgentsImageBlock) => betaManagedAgentsImageBlock.Validate(),
            (betaManagedAgentsDocumentBlock) => betaManagedAgentsDocumentBlock.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsUserMessageEventParamsContent? other) =>
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

sealed class BetaManagedAgentsUserMessageEventParamsContentConverter
    : JsonConverter<BetaManagedAgentsUserMessageEventParamsContent>
{
    public override BetaManagedAgentsUserMessageEventParamsContent? Read(
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
                return new BetaManagedAgentsUserMessageEventParamsContent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserMessageEventParamsContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsUserMessageEventParamsTypeConverter))]
public enum BetaManagedAgentsUserMessageEventParamsType
{
    UserMessage,
}

sealed class BetaManagedAgentsUserMessageEventParamsTypeConverter
    : JsonConverter<BetaManagedAgentsUserMessageEventParamsType>
{
    public override BetaManagedAgentsUserMessageEventParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.message" => BetaManagedAgentsUserMessageEventParamsType.UserMessage,
            _ => (BetaManagedAgentsUserMessageEventParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserMessageEventParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserMessageEventParamsType.UserMessage => "user.message",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
