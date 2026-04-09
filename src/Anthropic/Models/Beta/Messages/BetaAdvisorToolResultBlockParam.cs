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
    typeof(JsonModelConverter<
        BetaAdvisorToolResultBlockParam,
        BetaAdvisorToolResultBlockParamFromRaw
    >)
)]
public sealed record class BetaAdvisorToolResultBlockParam : JsonModel
{
    public required BetaAdvisorToolResultBlockParamContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAdvisorToolResultBlockParamContent>("content");
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
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
        this.CacheControl?.Validate();
    }

    public BetaAdvisorToolResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorToolResultBlockParam(
        BetaAdvisorToolResultBlockParam betaAdvisorToolResultBlockParam
    )
        : base(betaAdvisorToolResultBlockParam) { }
#pragma warning restore CS8618

    public BetaAdvisorToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaAdvisorToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAdvisorToolResultBlockParamFromRaw : IFromRawJson<BetaAdvisorToolResultBlockParam>
{
    /// <inheritdoc/>
    public BetaAdvisorToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorToolResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaAdvisorToolResultBlockParamContentConverter))]
public record class BetaAdvisorToolResultBlockParamContent : ModelBase
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
                betaAdvisorToolResultErrorParam: (x) => x.Type,
                betaAdvisorResultBlockParam: (x) => x.Type,
                betaAdvisorRedactedResultBlockParam: (x) => x.Type
            );
        }
    }

    public BetaAdvisorToolResultBlockParamContent(
        BetaAdvisorToolResultErrorParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAdvisorToolResultBlockParamContent(
        BetaAdvisorResultBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAdvisorToolResultBlockParamContent(
        BetaAdvisorRedactedResultBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAdvisorToolResultBlockParamContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAdvisorToolResultErrorParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAdvisorToolResultErrorParam(out var value)) {
    ///     // `value` is of type `BetaAdvisorToolResultErrorParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAdvisorToolResultErrorParam(
        [NotNullWhen(true)] out BetaAdvisorToolResultErrorParam? value
    )
    {
        value = this.Value as BetaAdvisorToolResultErrorParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAdvisorResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAdvisorResultBlockParam(out var value)) {
    ///     // `value` is of type `BetaAdvisorResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAdvisorResultBlockParam(
        [NotNullWhen(true)] out BetaAdvisorResultBlockParam? value
    )
    {
        value = this.Value as BetaAdvisorResultBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAdvisorRedactedResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAdvisorRedactedResultBlockParam(out var value)) {
    ///     // `value` is of type `BetaAdvisorRedactedResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAdvisorRedactedResultBlockParam(
        [NotNullWhen(true)] out BetaAdvisorRedactedResultBlockParam? value
    )
    {
        value = this.Value as BetaAdvisorRedactedResultBlockParam;
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
    ///     (BetaAdvisorToolResultErrorParam value) =&gt; {...},
    ///     (BetaAdvisorResultBlockParam value) =&gt; {...},
    ///     (BetaAdvisorRedactedResultBlockParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaAdvisorToolResultErrorParam> betaAdvisorToolResultErrorParam,
        System::Action<BetaAdvisorResultBlockParam> betaAdvisorResultBlockParam,
        System::Action<BetaAdvisorRedactedResultBlockParam> betaAdvisorRedactedResultBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaAdvisorToolResultErrorParam value:
                betaAdvisorToolResultErrorParam(value);
                break;
            case BetaAdvisorResultBlockParam value:
                betaAdvisorResultBlockParam(value);
                break;
            case BetaAdvisorRedactedResultBlockParam value:
                betaAdvisorRedactedResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaAdvisorToolResultBlockParamContent"
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
    ///     (BetaAdvisorToolResultErrorParam value) =&gt; {...},
    ///     (BetaAdvisorResultBlockParam value) =&gt; {...},
    ///     (BetaAdvisorRedactedResultBlockParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaAdvisorToolResultErrorParam, T> betaAdvisorToolResultErrorParam,
        System::Func<BetaAdvisorResultBlockParam, T> betaAdvisorResultBlockParam,
        System::Func<BetaAdvisorRedactedResultBlockParam, T> betaAdvisorRedactedResultBlockParam
    )
    {
        return this.Value switch
        {
            BetaAdvisorToolResultErrorParam value => betaAdvisorToolResultErrorParam(value),
            BetaAdvisorResultBlockParam value => betaAdvisorResultBlockParam(value),
            BetaAdvisorRedactedResultBlockParam value => betaAdvisorRedactedResultBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaAdvisorToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator BetaAdvisorToolResultBlockParamContent(
        BetaAdvisorToolResultErrorParam value
    ) => new(value);

    public static implicit operator BetaAdvisorToolResultBlockParamContent(
        BetaAdvisorResultBlockParam value
    ) => new(value);

    public static implicit operator BetaAdvisorToolResultBlockParamContent(
        BetaAdvisorRedactedResultBlockParam value
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
                "Data did not match any variant of BetaAdvisorToolResultBlockParamContent"
            );
        }
        this.Switch(
            (betaAdvisorToolResultErrorParam) => betaAdvisorToolResultErrorParam.Validate(),
            (betaAdvisorResultBlockParam) => betaAdvisorResultBlockParam.Validate(),
            (betaAdvisorRedactedResultBlockParam) => betaAdvisorRedactedResultBlockParam.Validate()
        );
    }

    public virtual bool Equals(BetaAdvisorToolResultBlockParamContent? other) =>
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
            BetaAdvisorToolResultErrorParam _ => 0,
            BetaAdvisorResultBlockParam _ => 1,
            BetaAdvisorRedactedResultBlockParam _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaAdvisorToolResultBlockParamContentConverter
    : JsonConverter<BetaAdvisorToolResultBlockParamContent>
{
    public override BetaAdvisorToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaAdvisorToolResultErrorParam>(
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
            var deserialized = JsonSerializer.Deserialize<BetaAdvisorResultBlockParam>(
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
            var deserialized = JsonSerializer.Deserialize<BetaAdvisorRedactedResultBlockParam>(
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

    public override void Write(
        Utf8JsonWriter writer,
        BetaAdvisorToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
