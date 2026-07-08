using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// One entry in the `fallbacks` chain on a `/v1/messages` request.
///
/// <para>`model` is required. The override fields (`max_tokens`, `thinking`, `output_config`,
/// and `speed`) set the corresponding parameter for this attempt only and are validated
/// as if the request were made to `model`. Any other key is rejected at parse time.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaFallbackParam, BetaFallbackParamFromRaw>))]
public sealed record class BetaFallbackParam : JsonModel
{
    /// <summary>
    /// The model that will complete your prompt.
    ///
    /// <para>See [models](https://docs.anthropic.com/en/docs/models-overview) for
    /// additional details and options.</para>
    /// </summary>
    public required ApiEnum<string, Model> Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Model>>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    public long? MaxTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_tokens");
        }
        init { this._rawData.Set("max_tokens", value); }
    }

    public BetaOutputConfig? OutputConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaOutputConfig>("output_config");
        }
        init { this._rawData.Set("output_config", value); }
    }

    public ApiEnum<string, BetaFallbackParamSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaFallbackParamSpeed>>("speed");
        }
        init { this._rawData.Set("speed", value); }
    }

    public Thinking? Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Thinking>("thinking");
        }
        init { this._rawData.Set("thinking", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Model.Raw();
        _ = this.MaxTokens;
        this.OutputConfig?.Validate();
        this.Speed?.Validate();
        this.Thinking?.Validate();
    }

    public BetaFallbackParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackParam(BetaFallbackParam betaFallbackParam)
        : base(betaFallbackParam) { }
#pragma warning restore CS8618

    public BetaFallbackParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackParamFromRaw.FromRawUnchecked"/>
    public static BetaFallbackParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaFallbackParam(ApiEnum<string, Model> model)
        : this()
    {
        this.Model = model;
    }
}

class BetaFallbackParamFromRaw : IFromRawJson<BetaFallbackParam>
{
    /// <inheritdoc/>
    public BetaFallbackParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaFallbackParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaFallbackParamSpeedConverter))]
public enum BetaFallbackParamSpeed
{
    Standard,
    Fast,
}

sealed class BetaFallbackParamSpeedConverter : JsonConverter<BetaFallbackParamSpeed>
{
    public override BetaFallbackParamSpeed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => BetaFallbackParamSpeed.Standard,
            "fast" => BetaFallbackParamSpeed.Fast,
            _ => (BetaFallbackParamSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaFallbackParamSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaFallbackParamSpeed.Standard => "standard",
                BetaFallbackParamSpeed.Fast => "fast",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ThinkingConverter))]
public record class Thinking : ModelBase
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
                betaThinkingConfigEnabled: (x) => x.Type,
                betaThinkingConfigDisabled: (x) => x.Type,
                betaThinkingConfigAdaptive: (x) => x.Type
            );
        }
    }

    public Thinking(BetaThinkingConfigEnabled value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Thinking(BetaThinkingConfigDisabled value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Thinking(BetaThinkingConfigAdaptive value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Thinking(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingConfigEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaThinkingConfigEnabled(out var value)) {
    ///     // `value` is of type `BetaThinkingConfigEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaThinkingConfigEnabled(
        [NotNullWhen(true)] out BetaThinkingConfigEnabled? value
    )
    {
        value = this.Value as BetaThinkingConfigEnabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingConfigDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaThinkingConfigDisabled(out var value)) {
    ///     // `value` is of type `BetaThinkingConfigDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaThinkingConfigDisabled(
        [NotNullWhen(true)] out BetaThinkingConfigDisabled? value
    )
    {
        value = this.Value as BetaThinkingConfigDisabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingConfigAdaptive"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaThinkingConfigAdaptive(out var value)) {
    ///     // `value` is of type `BetaThinkingConfigAdaptive`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaThinkingConfigAdaptive(
        [NotNullWhen(true)] out BetaThinkingConfigAdaptive? value
    )
    {
        value = this.Value as BetaThinkingConfigAdaptive;
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
    ///     (BetaThinkingConfigEnabled value) =&gt; {...},
    ///     (BetaThinkingConfigDisabled value) =&gt; {...},
    ///     (BetaThinkingConfigAdaptive value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaThinkingConfigEnabled> betaThinkingConfigEnabled,
        System::Action<BetaThinkingConfigDisabled> betaThinkingConfigDisabled,
        System::Action<BetaThinkingConfigAdaptive> betaThinkingConfigAdaptive
    )
    {
        switch (this.Value)
        {
            case BetaThinkingConfigEnabled value:
                betaThinkingConfigEnabled(value);
                break;
            case BetaThinkingConfigDisabled value:
                betaThinkingConfigDisabled(value);
                break;
            case BetaThinkingConfigAdaptive value:
                betaThinkingConfigAdaptive(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Thinking"
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
    ///     (BetaThinkingConfigEnabled value) =&gt; {...},
    ///     (BetaThinkingConfigDisabled value) =&gt; {...},
    ///     (BetaThinkingConfigAdaptive value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaThinkingConfigEnabled, T> betaThinkingConfigEnabled,
        System::Func<BetaThinkingConfigDisabled, T> betaThinkingConfigDisabled,
        System::Func<BetaThinkingConfigAdaptive, T> betaThinkingConfigAdaptive
    )
    {
        return this.Value switch
        {
            BetaThinkingConfigEnabled value => betaThinkingConfigEnabled(value),
            BetaThinkingConfigDisabled value => betaThinkingConfigDisabled(value),
            BetaThinkingConfigAdaptive value => betaThinkingConfigAdaptive(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Thinking"
            ),
        };
    }

    public static implicit operator Thinking(BetaThinkingConfigEnabled value) => new(value);

    public static implicit operator Thinking(BetaThinkingConfigDisabled value) => new(value);

    public static implicit operator Thinking(BetaThinkingConfigAdaptive value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Thinking");
        }
        this.Switch(
            (betaThinkingConfigEnabled) => betaThinkingConfigEnabled.Validate(),
            (betaThinkingConfigDisabled) => betaThinkingConfigDisabled.Validate(),
            (betaThinkingConfigAdaptive) => betaThinkingConfigAdaptive.Validate()
        );
    }

    public virtual bool Equals(Thinking? other) =>
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
            BetaThinkingConfigEnabled _ => 0,
            BetaThinkingConfigDisabled _ => 1,
            BetaThinkingConfigAdaptive _ => 2,
            _ => -1,
        };
    }
}

sealed class ThinkingConverter : JsonConverter<Thinking?>
{
    public override Thinking? Read(
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
            case "enabled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigEnabled>(
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
            case "disabled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigDisabled>(
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
            case "adaptive":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigAdaptive>(
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
                return new Thinking(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Thinking? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
