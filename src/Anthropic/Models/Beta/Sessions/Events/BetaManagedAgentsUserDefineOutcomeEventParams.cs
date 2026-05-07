using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Parameters for defining an outcome the agent should work toward. The agent begins
/// work on receipt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserDefineOutcomeEventParams,
        BetaManagedAgentsUserDefineOutcomeEventParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserDefineOutcomeEventParams : JsonModel
{
    /// <summary>
    /// What the agent should produce. This is the task specification.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Rubric for grading the quality of an outcome.
    /// </summary>
    public required BetaManagedAgentsUserDefineOutcomeEventParamsRubric Rubric
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsUserDefineOutcomeEventParamsRubric>(
                "rubric"
            );
        }
        init { this._rawData.Set("rubric", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Eval→revision cycles before giving up. Default 3, max 20.
    /// </summary>
    public int? MaxIterations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_iterations");
        }
        init { this._rawData.Set("max_iterations", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        this.Rubric.Validate();
        this.Type.Validate();
        _ = this.MaxIterations;
    }

    public BetaManagedAgentsUserDefineOutcomeEventParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserDefineOutcomeEventParams(
        BetaManagedAgentsUserDefineOutcomeEventParams betaManagedAgentsUserDefineOutcomeEventParams
    )
        : base(betaManagedAgentsUserDefineOutcomeEventParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserDefineOutcomeEventParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserDefineOutcomeEventParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserDefineOutcomeEventParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserDefineOutcomeEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserDefineOutcomeEventParamsFromRaw
    : IFromRawJson<BetaManagedAgentsUserDefineOutcomeEventParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserDefineOutcomeEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserDefineOutcomeEventParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Rubric for grading the quality of an outcome.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsUserDefineOutcomeEventParamsRubricConverter))]
public record class BetaManagedAgentsUserDefineOutcomeEventParamsRubric : ModelBase
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

    public BetaManagedAgentsUserDefineOutcomeEventParamsRubric(
        BetaManagedAgentsFileRubricParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserDefineOutcomeEventParamsRubric(
        BetaManagedAgentsTextRubricParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserDefineOutcomeEventParamsRubric(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsFileRubricParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsFileRubricParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsFileRubricParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsFileRubricParams(
        [NotNullWhen(true)] out BetaManagedAgentsFileRubricParams? value
    )
    {
        value = this.Value as BetaManagedAgentsFileRubricParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTextRubricParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTextRubricParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTextRubricParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTextRubricParams(
        [NotNullWhen(true)] out BetaManagedAgentsTextRubricParams? value
    )
    {
        value = this.Value as BetaManagedAgentsTextRubricParams;
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
    ///     (BetaManagedAgentsFileRubricParams value) =&gt; {...},
    ///     (BetaManagedAgentsTextRubricParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsFileRubricParams> betaManagedAgentsFileRubricParams,
        System::Action<BetaManagedAgentsTextRubricParams> betaManagedAgentsTextRubricParams
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsFileRubricParams value:
                betaManagedAgentsFileRubricParams(value);
                break;
            case BetaManagedAgentsTextRubricParams value:
                betaManagedAgentsTextRubricParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsUserDefineOutcomeEventParamsRubric"
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
    ///     (BetaManagedAgentsFileRubricParams value) =&gt; {...},
    ///     (BetaManagedAgentsTextRubricParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsFileRubricParams, T> betaManagedAgentsFileRubricParams,
        System::Func<BetaManagedAgentsTextRubricParams, T> betaManagedAgentsTextRubricParams
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsFileRubricParams value => betaManagedAgentsFileRubricParams(value),
            BetaManagedAgentsTextRubricParams value => betaManagedAgentsTextRubricParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsUserDefineOutcomeEventParamsRubric"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsUserDefineOutcomeEventParamsRubric(
        BetaManagedAgentsFileRubricParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsUserDefineOutcomeEventParamsRubric(
        BetaManagedAgentsTextRubricParams value
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
                "Data did not match any variant of BetaManagedAgentsUserDefineOutcomeEventParamsRubric"
            );
        }
        this.Switch(
            (betaManagedAgentsFileRubricParams) => betaManagedAgentsFileRubricParams.Validate(),
            (betaManagedAgentsTextRubricParams) => betaManagedAgentsTextRubricParams.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsUserDefineOutcomeEventParamsRubric? other) =>
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
            BetaManagedAgentsFileRubricParams _ => 0,
            BetaManagedAgentsTextRubricParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsUserDefineOutcomeEventParamsRubricConverter
    : JsonConverter<BetaManagedAgentsUserDefineOutcomeEventParamsRubric>
{
    public override BetaManagedAgentsUserDefineOutcomeEventParamsRubric? Read(
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
            case "file":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsFileRubricParams>(
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
            case "text":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsTextRubricParams>(
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
                return new BetaManagedAgentsUserDefineOutcomeEventParamsRubric(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserDefineOutcomeEventParamsRubric value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsUserDefineOutcomeEventParamsTypeConverter))]
public enum BetaManagedAgentsUserDefineOutcomeEventParamsType
{
    UserDefineOutcome,
}

sealed class BetaManagedAgentsUserDefineOutcomeEventParamsTypeConverter
    : JsonConverter<BetaManagedAgentsUserDefineOutcomeEventParamsType>
{
    public override BetaManagedAgentsUserDefineOutcomeEventParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.define_outcome" =>
                BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
            _ => (BetaManagedAgentsUserDefineOutcomeEventParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserDefineOutcomeEventParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome =>
                    "user.define_outcome",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
