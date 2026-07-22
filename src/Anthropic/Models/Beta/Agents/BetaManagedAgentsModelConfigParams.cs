using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// An object that defines additional configuration control over model use
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsModelConfigParams,
        BetaManagedAgentsModelConfigParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsModelConfigParams : JsonModel
{
    /// <summary>
    /// The model that will power your agent.
    ///
    /// <para>See [models](https://docs.anthropic.com/en/docs/models-overview) for
    /// additional details and options.</para>
    /// </summary>
    public required ApiEnum<string, BetaManagedAgentsModel> ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsModel>>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// How hard Claude works on each inference call. Accepts a bare level string
    /// (`"high"`) or `{"type": "high"}`. On create, omitting it resolves the per-model
    /// default; on update, omitting it leaves the stored value unchanged.
    /// </summary>
    public BetaManagedAgentsModelConfigParamsEffort? Effort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsModelConfigParamsEffort>(
                "effort"
            );
        }
        init { this._rawData.Set("effort", value); }
    }

    /// <summary>
    /// Inference speed mode. `fast` provides significantly faster output token generation
    /// at premium pricing. Not all models support `fast`; invalid combinations are
    /// rejected at create time.
    /// </summary>
    public ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed>
            >("speed");
        }
        init { this._rawData.Set("speed", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ID.Raw();
        this.Effort?.Validate();
        this.Speed?.Validate();
    }

    public BetaManagedAgentsModelConfigParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsModelConfigParams(
        BetaManagedAgentsModelConfigParams betaManagedAgentsModelConfigParams
    )
        : base(betaManagedAgentsModelConfigParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsModelConfigParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsModelConfigParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsModelConfigParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsModelConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsModelConfigParams(ApiEnum<string, BetaManagedAgentsModel> id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsModelConfigParamsFromRaw : IFromRawJson<BetaManagedAgentsModelConfigParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsModelConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsModelConfigParams.FromRawUnchecked(rawData);
}

/// <summary>
/// How hard Claude works on each inference call. Accepts a bare level string (`"high"`)
/// or `{"type": "high"}`. On create, omitting it resolves the per-model default;
/// on update, omitting it leaves the stored value unchanged.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsModelConfigParamsEffortConverter))]
public record class BetaManagedAgentsModelConfigParamsEffort : ModelBase
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

    public BetaManagedAgentsModelConfigParamsEffort(
        ApiEnum<string, BetaManagedAgentsEffortLevel> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortLow value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortMedium value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortHigh value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortXhigh value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortMax value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsModelConfigParamsEffort(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of BetaManagedAgentsEffortLevel>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsEffortLevel(out var value)) {
    ///     // `value` is of type `ApiEnum&lt;string, BetaManagedAgentsEffortLevel&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsEffortLevel(
        [NotNullWhen(true)] out ApiEnum<string, BetaManagedAgentsEffortLevel>? value
    )
    {
        value = this.Value as ApiEnum<string, BetaManagedAgentsEffortLevel>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEffortLow"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsEffortLow(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEffortLow`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsEffortLow(
        [NotNullWhen(true)] out BetaManagedAgentsEffortLow? value
    )
    {
        value = this.Value as BetaManagedAgentsEffortLow;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEffortMedium"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsEffortMedium(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEffortMedium`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsEffortMedium(
        [NotNullWhen(true)] out BetaManagedAgentsEffortMedium? value
    )
    {
        value = this.Value as BetaManagedAgentsEffortMedium;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEffortHigh"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsEffortHigh(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEffortHigh`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsEffortHigh(
        [NotNullWhen(true)] out BetaManagedAgentsEffortHigh? value
    )
    {
        value = this.Value as BetaManagedAgentsEffortHigh;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEffortXhigh"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsEffortXhigh(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEffortXhigh`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsEffortXhigh(
        [NotNullWhen(true)] out BetaManagedAgentsEffortXhigh? value
    )
    {
        value = this.Value as BetaManagedAgentsEffortXhigh;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEffortMax"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsEffortMax(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEffortMax`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsEffortMax(
        [NotNullWhen(true)] out BetaManagedAgentsEffortMax? value
    )
    {
        value = this.Value as BetaManagedAgentsEffortMax;
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
    ///     (ApiEnum&lt;string, BetaManagedAgentsEffortLevel&gt; value) =&gt; {...},
    ///     (BetaManagedAgentsEffortLow value) =&gt; {...},
    ///     (BetaManagedAgentsEffortMedium value) =&gt; {...},
    ///     (BetaManagedAgentsEffortHigh value) =&gt; {...},
    ///     (BetaManagedAgentsEffortXhigh value) =&gt; {...},
    ///     (BetaManagedAgentsEffortMax value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ApiEnum<string, BetaManagedAgentsEffortLevel>> betaManagedAgentsEffortLevel,
        System::Action<BetaManagedAgentsEffortLow> betaManagedAgentsEffortLow,
        System::Action<BetaManagedAgentsEffortMedium> betaManagedAgentsEffortMedium,
        System::Action<BetaManagedAgentsEffortHigh> betaManagedAgentsEffortHigh,
        System::Action<BetaManagedAgentsEffortXhigh> betaManagedAgentsEffortXhigh,
        System::Action<BetaManagedAgentsEffortMax> betaManagedAgentsEffortMax
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, BetaManagedAgentsEffortLevel> value:
                betaManagedAgentsEffortLevel(value);
                break;
            case BetaManagedAgentsEffortLow value:
                betaManagedAgentsEffortLow(value);
                break;
            case BetaManagedAgentsEffortMedium value:
                betaManagedAgentsEffortMedium(value);
                break;
            case BetaManagedAgentsEffortHigh value:
                betaManagedAgentsEffortHigh(value);
                break;
            case BetaManagedAgentsEffortXhigh value:
                betaManagedAgentsEffortXhigh(value);
                break;
            case BetaManagedAgentsEffortMax value:
                betaManagedAgentsEffortMax(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsModelConfigParamsEffort"
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
    ///     (ApiEnum&lt;string, BetaManagedAgentsEffortLevel&gt; value) =&gt; {...},
    ///     (BetaManagedAgentsEffortLow value) =&gt; {...},
    ///     (BetaManagedAgentsEffortMedium value) =&gt; {...},
    ///     (BetaManagedAgentsEffortHigh value) =&gt; {...},
    ///     (BetaManagedAgentsEffortXhigh value) =&gt; {...},
    ///     (BetaManagedAgentsEffortMax value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ApiEnum<string, BetaManagedAgentsEffortLevel>, T> betaManagedAgentsEffortLevel,
        System::Func<BetaManagedAgentsEffortLow, T> betaManagedAgentsEffortLow,
        System::Func<BetaManagedAgentsEffortMedium, T> betaManagedAgentsEffortMedium,
        System::Func<BetaManagedAgentsEffortHigh, T> betaManagedAgentsEffortHigh,
        System::Func<BetaManagedAgentsEffortXhigh, T> betaManagedAgentsEffortXhigh,
        System::Func<BetaManagedAgentsEffortMax, T> betaManagedAgentsEffortMax
    )
    {
        return this.Value switch
        {
            ApiEnum<string, BetaManagedAgentsEffortLevel> value => betaManagedAgentsEffortLevel(
                value
            ),
            BetaManagedAgentsEffortLow value => betaManagedAgentsEffortLow(value),
            BetaManagedAgentsEffortMedium value => betaManagedAgentsEffortMedium(value),
            BetaManagedAgentsEffortHigh value => betaManagedAgentsEffortHigh(value),
            BetaManagedAgentsEffortXhigh value => betaManagedAgentsEffortXhigh(value),
            BetaManagedAgentsEffortMax value => betaManagedAgentsEffortMax(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsModelConfigParamsEffort"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsModelConfigParamsEffort(
        ApiEnum<string, BetaManagedAgentsEffortLevel> value
    ) => new(value);

    public static implicit operator BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortLevel value
    ) => new(value);

    public static implicit operator BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortLow value
    ) => new(value);

    public static implicit operator BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortMedium value
    ) => new(value);

    public static implicit operator BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortHigh value
    ) => new(value);

    public static implicit operator BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortXhigh value
    ) => new(value);

    public static implicit operator BetaManagedAgentsModelConfigParamsEffort(
        BetaManagedAgentsEffortMax value
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
                "Data did not match any variant of BetaManagedAgentsModelConfigParamsEffort"
            );
        }
        this.Switch(
            (betaManagedAgentsEffortLevel) => betaManagedAgentsEffortLevel.Validate(),
            (betaManagedAgentsEffortLow) => betaManagedAgentsEffortLow.Validate(),
            (betaManagedAgentsEffortMedium) => betaManagedAgentsEffortMedium.Validate(),
            (betaManagedAgentsEffortHigh) => betaManagedAgentsEffortHigh.Validate(),
            (betaManagedAgentsEffortXhigh) => betaManagedAgentsEffortXhigh.Validate(),
            (betaManagedAgentsEffortMax) => betaManagedAgentsEffortMax.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsModelConfigParamsEffort? other) =>
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
            ApiEnum<string, BetaManagedAgentsEffortLevel> _ => 0,
            BetaManagedAgentsEffortLow _ => 1,
            BetaManagedAgentsEffortMedium _ => 2,
            BetaManagedAgentsEffortHigh _ => 3,
            BetaManagedAgentsEffortXhigh _ => 4,
            BetaManagedAgentsEffortMax _ => 5,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsModelConfigParamsEffortConverter
    : JsonConverter<BetaManagedAgentsModelConfigParamsEffort?>
{
    public override BetaManagedAgentsModelConfigParamsEffort? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BetaManagedAgentsEffortLevel>
            >(element, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortLow>(
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
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortMedium>(
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
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortHigh>(
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
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortXhigh>(
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
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortMax>(
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
        BetaManagedAgentsModelConfigParamsEffort? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// How hard Claude works on each turn. Higher levels favor reasoning depth over latency.
/// Not all models accept every level; invalid combinations are rejected at create time.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsEffortLevelConverter))]
public enum BetaManagedAgentsEffortLevel
{
    Low,
    Medium,
    High,
    Xhigh,
    Max,
}

sealed class BetaManagedAgentsEffortLevelConverter : JsonConverter<BetaManagedAgentsEffortLevel>
{
    public override BetaManagedAgentsEffortLevel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => BetaManagedAgentsEffortLevel.Low,
            "medium" => BetaManagedAgentsEffortLevel.Medium,
            "high" => BetaManagedAgentsEffortLevel.High,
            "xhigh" => BetaManagedAgentsEffortLevel.Xhigh,
            "max" => BetaManagedAgentsEffortLevel.Max,
            _ => (BetaManagedAgentsEffortLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEffortLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEffortLevel.Low => "low",
                BetaManagedAgentsEffortLevel.Medium => "medium",
                BetaManagedAgentsEffortLevel.High => "high",
                BetaManagedAgentsEffortLevel.Xhigh => "xhigh",
                BetaManagedAgentsEffortLevel.Max => "max",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Inference speed mode. `fast` provides significantly faster output token generation
/// at premium pricing. Not all models support `fast`; invalid combinations are rejected
/// at create time.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsModelConfigParamsSpeedConverter))]
public enum BetaManagedAgentsModelConfigParamsSpeed
{
    Standard,
    Fast,
}

sealed class BetaManagedAgentsModelConfigParamsSpeedConverter
    : JsonConverter<BetaManagedAgentsModelConfigParamsSpeed>
{
    public override BetaManagedAgentsModelConfigParamsSpeed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => BetaManagedAgentsModelConfigParamsSpeed.Standard,
            "fast" => BetaManagedAgentsModelConfigParamsSpeed.Fast,
            _ => (BetaManagedAgentsModelConfigParamsSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsModelConfigParamsSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsModelConfigParamsSpeed.Standard => "standard",
                BetaManagedAgentsModelConfigParamsSpeed.Fast => "fast",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
