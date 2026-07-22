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
/// Model identifier and configuration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsModelConfig, BetaManagedAgentsModelConfigFromRaw>)
)]
public sealed record class BetaManagedAgentsModelConfig : JsonModel
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
    /// How hard Claude works on each turn. Sets `output_config.effort` on every Messages
    /// call the session makes.
    /// </summary>
    public Effort? Effort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Effort>("effort");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("effort", value);
        }
    }

    /// <summary>
    /// Inference speed mode. `fast` provides significantly faster output token generation
    /// at premium pricing. Not all models support `fast`; invalid combinations are
    /// rejected at create time.
    /// </summary>
    public ApiEnum<string, Speed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Speed>>("speed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("speed", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ID.Raw();
        this.Effort?.Validate();
        this.Speed?.Validate();
    }

    public BetaManagedAgentsModelConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsModelConfig(BetaManagedAgentsModelConfig betaManagedAgentsModelConfig)
        : base(betaManagedAgentsModelConfig) { }
#pragma warning restore CS8618

    public BetaManagedAgentsModelConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsModelConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsModelConfigFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsModelConfig(ApiEnum<string, BetaManagedAgentsModel> id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsModelConfigFromRaw : IFromRawJson<BetaManagedAgentsModelConfig>
{
    /// <inheritdoc/>
    public BetaManagedAgentsModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsModelConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// How hard Claude works on each turn. Sets `output_config.effort` on every Messages
/// call the session makes.
/// </summary>
[JsonConverter(typeof(EffortConverter))]
public record class Effort : ModelBase
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

    public Effort(BetaManagedAgentsEffortLow value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Effort(BetaManagedAgentsEffortMedium value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Effort(BetaManagedAgentsEffortHigh value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Effort(BetaManagedAgentsEffortXhigh value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Effort(BetaManagedAgentsEffortMax value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Effort(JsonElement element)
    {
        this._element = element;
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
        System::Action<BetaManagedAgentsEffortLow> betaManagedAgentsEffortLow,
        System::Action<BetaManagedAgentsEffortMedium> betaManagedAgentsEffortMedium,
        System::Action<BetaManagedAgentsEffortHigh> betaManagedAgentsEffortHigh,
        System::Action<BetaManagedAgentsEffortXhigh> betaManagedAgentsEffortXhigh,
        System::Action<BetaManagedAgentsEffortMax> betaManagedAgentsEffortMax
    )
    {
        switch (this.Value)
        {
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
                throw new AnthropicInvalidDataException("Data did not match any variant of Effort");
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
        System::Func<BetaManagedAgentsEffortLow, T> betaManagedAgentsEffortLow,
        System::Func<BetaManagedAgentsEffortMedium, T> betaManagedAgentsEffortMedium,
        System::Func<BetaManagedAgentsEffortHigh, T> betaManagedAgentsEffortHigh,
        System::Func<BetaManagedAgentsEffortXhigh, T> betaManagedAgentsEffortXhigh,
        System::Func<BetaManagedAgentsEffortMax, T> betaManagedAgentsEffortMax
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsEffortLow value => betaManagedAgentsEffortLow(value),
            BetaManagedAgentsEffortMedium value => betaManagedAgentsEffortMedium(value),
            BetaManagedAgentsEffortHigh value => betaManagedAgentsEffortHigh(value),
            BetaManagedAgentsEffortXhigh value => betaManagedAgentsEffortXhigh(value),
            BetaManagedAgentsEffortMax value => betaManagedAgentsEffortMax(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Effort"
            ),
        };
    }

    public static implicit operator Effort(BetaManagedAgentsEffortLow value) => new(value);

    public static implicit operator Effort(BetaManagedAgentsEffortMedium value) => new(value);

    public static implicit operator Effort(BetaManagedAgentsEffortHigh value) => new(value);

    public static implicit operator Effort(BetaManagedAgentsEffortXhigh value) => new(value);

    public static implicit operator Effort(BetaManagedAgentsEffortMax value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Effort");
        }
        this.Switch(
            (betaManagedAgentsEffortLow) => betaManagedAgentsEffortLow.Validate(),
            (betaManagedAgentsEffortMedium) => betaManagedAgentsEffortMedium.Validate(),
            (betaManagedAgentsEffortHigh) => betaManagedAgentsEffortHigh.Validate(),
            (betaManagedAgentsEffortXhigh) => betaManagedAgentsEffortXhigh.Validate(),
            (betaManagedAgentsEffortMax) => betaManagedAgentsEffortMax.Validate()
        );
    }

    public virtual bool Equals(Effort? other) =>
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
            BetaManagedAgentsEffortLow _ => 0,
            BetaManagedAgentsEffortMedium _ => 1,
            BetaManagedAgentsEffortHigh _ => 2,
            BetaManagedAgentsEffortXhigh _ => 3,
            BetaManagedAgentsEffortMax _ => 4,
            _ => -1,
        };
    }
}

sealed class EffortConverter : JsonConverter<Effort>
{
    public override Effort? Read(
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
            case "low":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortLow>(
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
            case "medium":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortMedium>(
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
            case "high":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortHigh>(
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
            case "xhigh":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortXhigh>(
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
            case "max":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEffortMax>(
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
                return new Effort(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Effort value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Inference speed mode. `fast` provides significantly faster output token generation
/// at premium pricing. Not all models support `fast`; invalid combinations are rejected
/// at create time.
/// </summary>
[JsonConverter(typeof(SpeedConverter))]
public enum Speed
{
    Standard,
    Fast,
}

sealed class SpeedConverter : JsonConverter<Speed>
{
    public override Speed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => Speed.Standard,
            "fast" => Speed.Fast,
            _ => (Speed)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Speed value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Speed.Standard => "standard",
                Speed.Fast => "fast",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
