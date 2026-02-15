using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaWebFetchToolResultBlock, BetaWebFetchToolResultBlockFromRaw>)
)]
public sealed record class BetaWebFetchToolResultBlock : JsonModel
{
    public required BetaWebFetchToolResultBlockContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaWebFetchToolResultBlockContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required string ToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_use_id");
        }
        init { this._rawData.Set("tool_use_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_fetch_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebFetchToolResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchToolResultBlock(BetaWebFetchToolResultBlock betaWebFetchToolResultBlock)
        : base(betaWebFetchToolResultBlock) { }
#pragma warning restore CS8618

    public BetaWebFetchToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchToolResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchToolResultBlockFromRaw : IFromRawJson<BetaWebFetchToolResultBlock>
{
    /// <inheritdoc/>
    public BetaWebFetchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchToolResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaWebFetchToolResultBlockContentConverter))]
public record class BetaWebFetchToolResultBlockContent : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return Match(
                betaWebFetchToolResultErrorBlock: (x) => x.Type,
                betaWebFetchBlock: (x) => x.Type
            );
        }
    }

    public BetaWebFetchToolResultBlockContent(
        BetaWebFetchToolResultErrorBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebFetchToolResultBlockContent(BetaWebFetchBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebFetchToolResultBlockContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchToolResultErrorBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchToolResultErrorBlock(out var value)) {
    ///     // `value` is of type `BetaWebFetchToolResultErrorBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchToolResultErrorBlock(
        [NotNullWhen(true)] out BetaWebFetchToolResultErrorBlock? value
    )
    {
        value = this.Value as BetaWebFetchToolResultErrorBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchBlock(out var value)) {
    ///     // `value` is of type `BetaWebFetchBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchBlock([NotNullWhen(true)] out BetaWebFetchBlock? value)
    {
        value = this.Value as BetaWebFetchBlock;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (BetaWebFetchToolResultErrorBlock value) => {...},
    ///     (BetaWebFetchBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaWebFetchToolResultErrorBlock> betaWebFetchToolResultErrorBlock,
        System::Action<BetaWebFetchBlock> betaWebFetchBlock
    )
    {
        switch (this.Value)
        {
            case BetaWebFetchToolResultErrorBlock value:
                betaWebFetchToolResultErrorBlock(value);
                break;
            case BetaWebFetchBlock value:
                betaWebFetchBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebFetchToolResultBlockContent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (BetaWebFetchToolResultErrorBlock value) => {...},
    ///     (BetaWebFetchBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaWebFetchToolResultErrorBlock, T> betaWebFetchToolResultErrorBlock,
        System::Func<BetaWebFetchBlock, T> betaWebFetchBlock
    )
    {
        return this.Value switch
        {
            BetaWebFetchToolResultErrorBlock value => betaWebFetchToolResultErrorBlock(value),
            BetaWebFetchBlock value => betaWebFetchBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebFetchToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaWebFetchToolResultBlockContent(
        BetaWebFetchToolResultErrorBlock value
    ) => new(value);

    public static implicit operator BetaWebFetchToolResultBlockContent(BetaWebFetchBlock value) =>
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
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebFetchToolResultBlockContent"
            );
        }
        this.Switch(
            (betaWebFetchToolResultErrorBlock) => betaWebFetchToolResultErrorBlock.Validate(),
            (betaWebFetchBlock) => betaWebFetchBlock.Validate()
        );
    }

    public virtual bool Equals(BetaWebFetchToolResultBlockContent? other) =>
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
            BetaWebFetchToolResultErrorBlock _ => 0,
            BetaWebFetchBlock _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaWebFetchToolResultBlockContentConverter
    : JsonConverter<BetaWebFetchToolResultBlockContent>
{
    public override BetaWebFetchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlock>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlock>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebFetchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
