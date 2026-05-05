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
/// Echo of a `user.define_outcome` input event. Carries the server-generated `outcome_id`
/// that subsequent `span.outcome_evaluation_*` events reference.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserDefineOutcomeEvent,
        BetaManagedAgentsUserDefineOutcomeEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserDefineOutcomeEvent : JsonModel
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
    /// What the agent should produce. Copied from the input event.
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
    /// Evaluate-then-revise cycles before giving up. Default 3, max 20.
    /// </summary>
    public required int? MaxIterations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_iterations");
        }
        init { this._rawData.Set("max_iterations", value); }
    }

    /// <summary>
    /// Server-generated `outc_` ID for this outcome. Referenced by `span.outcome_evaluation_*`
    /// events and the session's `outcome_evaluations` list.
    /// </summary>
    public required string OutcomeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outcome_id");
        }
        init { this._rawData.Set("outcome_id", value); }
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

    /// <summary>
    /// Rubric for grading the quality of an outcome.
    /// </summary>
    public required Rubric Rubric
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Rubric>("rubric");
        }
        init { this._rawData.Set("rubric", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.MaxIterations;
        _ = this.OutcomeID;
        _ = this.ProcessedAt;
        this.Rubric.Validate();
        this.Type.Validate();
    }

    public BetaManagedAgentsUserDefineOutcomeEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserDefineOutcomeEvent(
        BetaManagedAgentsUserDefineOutcomeEvent betaManagedAgentsUserDefineOutcomeEvent
    )
        : base(betaManagedAgentsUserDefineOutcomeEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserDefineOutcomeEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserDefineOutcomeEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserDefineOutcomeEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserDefineOutcomeEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserDefineOutcomeEventFromRaw
    : IFromRawJson<BetaManagedAgentsUserDefineOutcomeEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserDefineOutcomeEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserDefineOutcomeEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Rubric for grading the quality of an outcome.
/// </summary>
[JsonConverter(typeof(RubricConverter))]
public record class Rubric : ModelBase
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

    public Rubric(BetaManagedAgentsFileRubric value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Rubric(BetaManagedAgentsTextRubric value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Rubric(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsFileRubric"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsFile(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsFileRubric`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsFile(
        [NotNullWhen(true)] out BetaManagedAgentsFileRubric? value
    )
    {
        value = this.Value as BetaManagedAgentsFileRubric;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTextRubric"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsText(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTextRubric`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsText(
        [NotNullWhen(true)] out BetaManagedAgentsTextRubric? value
    )
    {
        value = this.Value as BetaManagedAgentsTextRubric;
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
    ///     (BetaManagedAgentsFileRubric value) =&gt; {...},
    ///     (BetaManagedAgentsTextRubric value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsFileRubric> betaManagedAgentsFile,
        System::Action<BetaManagedAgentsTextRubric> betaManagedAgentsText
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsFileRubric value:
                betaManagedAgentsFile(value);
                break;
            case BetaManagedAgentsTextRubric value:
                betaManagedAgentsText(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Rubric");
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
    ///     (BetaManagedAgentsFileRubric value) =&gt; {...},
    ///     (BetaManagedAgentsTextRubric value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsFileRubric, T> betaManagedAgentsFile,
        System::Func<BetaManagedAgentsTextRubric, T> betaManagedAgentsText
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsFileRubric value => betaManagedAgentsFile(value),
            BetaManagedAgentsTextRubric value => betaManagedAgentsText(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Rubric"
            ),
        };
    }

    public static implicit operator Rubric(BetaManagedAgentsFileRubric value) => new(value);

    public static implicit operator Rubric(BetaManagedAgentsTextRubric value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Rubric");
        }
        this.Switch(
            (betaManagedAgentsFile) => betaManagedAgentsFile.Validate(),
            (betaManagedAgentsText) => betaManagedAgentsText.Validate()
        );
    }

    public virtual bool Equals(Rubric? other) =>
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
            BetaManagedAgentsFileRubric _ => 0,
            BetaManagedAgentsTextRubric _ => 1,
            _ => -1,
        };
    }
}

sealed class RubricConverter : JsonConverter<Rubric>
{
    public override Rubric? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileRubric>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTextRubric>(
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
                return new Rubric(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Rubric value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsUserDefineOutcomeEventTypeConverter))]
public enum BetaManagedAgentsUserDefineOutcomeEventType
{
    UserDefineOutcome,
}

sealed class BetaManagedAgentsUserDefineOutcomeEventTypeConverter
    : JsonConverter<BetaManagedAgentsUserDefineOutcomeEventType>
{
    public override BetaManagedAgentsUserDefineOutcomeEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.define_outcome" => BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome,
            _ => (BetaManagedAgentsUserDefineOutcomeEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserDefineOutcomeEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome =>
                    "user.define_outcome",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
