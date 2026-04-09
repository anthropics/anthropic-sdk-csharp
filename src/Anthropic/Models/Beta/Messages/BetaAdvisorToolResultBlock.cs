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
    typeof(JsonModelConverter<BetaAdvisorToolResultBlock, BetaAdvisorToolResultBlockFromRaw>)
)]
public sealed record class BetaAdvisorToolResultBlock : JsonModel
{
    public required Content Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Content>("content");
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
                JsonSerializer.SerializeToElement("advisor_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAdvisorToolResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorToolResultBlock(BetaAdvisorToolResultBlock betaAdvisorToolResultBlock)
        : base(betaAdvisorToolResultBlock) { }
#pragma warning restore CS8618

    public BetaAdvisorToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorToolResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaAdvisorToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAdvisorToolResultBlockFromRaw : IFromRawJson<BetaAdvisorToolResultBlock>
{
    /// <inheritdoc/>
    public BetaAdvisorToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorToolResultBlock.FromRawUnchecked(rawData);
}

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

    public JsonElement Type
    {
        get
        {
            return Match(
                betaAdvisorToolResultError: (x) => x.Type,
                betaAdvisorResultBlock: (x) => x.Type,
                betaAdvisorRedactedResultBlock: (x) => x.Type
            );
        }
    }

    public Content(BetaAdvisorToolResultError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(BetaAdvisorResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(BetaAdvisorRedactedResultBlock value, JsonElement? element = null)
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
    /// type <see cref="BetaAdvisorToolResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAdvisorToolResultError(out var value)) {
    ///     // `value` is of type `BetaAdvisorToolResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAdvisorToolResultError(
        [NotNullWhen(true)] out BetaAdvisorToolResultError? value
    )
    {
        value = this.Value as BetaAdvisorToolResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAdvisorResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAdvisorResultBlock(out var value)) {
    ///     // `value` is of type `BetaAdvisorResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAdvisorResultBlock([NotNullWhen(true)] out BetaAdvisorResultBlock? value)
    {
        value = this.Value as BetaAdvisorResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAdvisorRedactedResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAdvisorRedactedResultBlock(out var value)) {
    ///     // `value` is of type `BetaAdvisorRedactedResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAdvisorRedactedResultBlock(
        [NotNullWhen(true)] out BetaAdvisorRedactedResultBlock? value
    )
    {
        value = this.Value as BetaAdvisorRedactedResultBlock;
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
    ///     (BetaAdvisorToolResultError value) =&gt; {...},
    ///     (BetaAdvisorResultBlock value) =&gt; {...},
    ///     (BetaAdvisorRedactedResultBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaAdvisorToolResultError> betaAdvisorToolResultError,
        System::Action<BetaAdvisorResultBlock> betaAdvisorResultBlock,
        System::Action<BetaAdvisorRedactedResultBlock> betaAdvisorRedactedResultBlock
    )
    {
        switch (this.Value)
        {
            case BetaAdvisorToolResultError value:
                betaAdvisorToolResultError(value);
                break;
            case BetaAdvisorResultBlock value:
                betaAdvisorResultBlock(value);
                break;
            case BetaAdvisorRedactedResultBlock value:
                betaAdvisorRedactedResultBlock(value);
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
    ///     (BetaAdvisorToolResultError value) =&gt; {...},
    ///     (BetaAdvisorResultBlock value) =&gt; {...},
    ///     (BetaAdvisorRedactedResultBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaAdvisorToolResultError, T> betaAdvisorToolResultError,
        System::Func<BetaAdvisorResultBlock, T> betaAdvisorResultBlock,
        System::Func<BetaAdvisorRedactedResultBlock, T> betaAdvisorRedactedResultBlock
    )
    {
        return this.Value switch
        {
            BetaAdvisorToolResultError value => betaAdvisorToolResultError(value),
            BetaAdvisorResultBlock value => betaAdvisorResultBlock(value),
            BetaAdvisorRedactedResultBlock value => betaAdvisorRedactedResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public static implicit operator Content(BetaAdvisorToolResultError value) => new(value);

    public static implicit operator Content(BetaAdvisorResultBlock value) => new(value);

    public static implicit operator Content(BetaAdvisorRedactedResultBlock value) => new(value);

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
            (betaAdvisorToolResultError) => betaAdvisorToolResultError.Validate(),
            (betaAdvisorResultBlock) => betaAdvisorResultBlock.Validate(),
            (betaAdvisorRedactedResultBlock) => betaAdvisorRedactedResultBlock.Validate()
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
            BetaAdvisorToolResultError _ => 0,
            BetaAdvisorResultBlock _ => 1,
            BetaAdvisorRedactedResultBlock _ => 2,
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
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaAdvisorToolResultError>(
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
            var deserialized = JsonSerializer.Deserialize<BetaAdvisorResultBlock>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaAdvisorRedactedResultBlock>(
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

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
