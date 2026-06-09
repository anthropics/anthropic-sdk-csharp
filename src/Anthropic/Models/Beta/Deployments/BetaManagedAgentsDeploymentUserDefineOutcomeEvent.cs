using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Events = Anthropic.Models.Beta.Sessions.Events;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// An outcome the agent should work toward. The agent begins work on receipt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeploymentUserDefineOutcomeEvent,
        BetaManagedAgentsDeploymentUserDefineOutcomeEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeploymentUserDefineOutcomeEvent : JsonModel
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
    public required Rubric Rubric
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Rubric>("rubric");
        }
        init { this._rawData.Set("rubric", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsDeploymentUserDefineOutcomeEventType>
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

    public BetaManagedAgentsDeploymentUserDefineOutcomeEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeploymentUserDefineOutcomeEvent(
        BetaManagedAgentsDeploymentUserDefineOutcomeEvent betaManagedAgentsDeploymentUserDefineOutcomeEvent
    )
        : base(betaManagedAgentsDeploymentUserDefineOutcomeEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeploymentUserDefineOutcomeEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeploymentUserDefineOutcomeEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeploymentUserDefineOutcomeEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeploymentUserDefineOutcomeEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeploymentUserDefineOutcomeEventFromRaw
    : IFromRawJson<BetaManagedAgentsDeploymentUserDefineOutcomeEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeploymentUserDefineOutcomeEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeploymentUserDefineOutcomeEvent.FromRawUnchecked(rawData);
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

    public Rubric(Events::BetaManagedAgentsFileRubric value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Rubric(Events::BetaManagedAgentsTextRubric value, JsonElement? element = null)
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
    /// type <see cref="Events::BetaManagedAgentsFileRubric"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsFile(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsFileRubric`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsFile(
        [NotNullWhen(true)] out Events::BetaManagedAgentsFileRubric? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsFileRubric;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Events::BetaManagedAgentsTextRubric"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsText(out var value)) {
    ///     // `value` is of type `Events::BetaManagedAgentsTextRubric`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsText(
        [NotNullWhen(true)] out Events::BetaManagedAgentsTextRubric? value
    )
    {
        value = this.Value as Events::BetaManagedAgentsTextRubric;
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
    ///     (Events::BetaManagedAgentsFileRubric value) =&gt; {...},
    ///     (Events::BetaManagedAgentsTextRubric value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Events::BetaManagedAgentsFileRubric> betaManagedAgentsFile,
        System::Action<Events::BetaManagedAgentsTextRubric> betaManagedAgentsText
    )
    {
        switch (this.Value)
        {
            case Events::BetaManagedAgentsFileRubric value:
                betaManagedAgentsFile(value);
                break;
            case Events::BetaManagedAgentsTextRubric value:
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
    ///     (Events::BetaManagedAgentsFileRubric value) =&gt; {...},
    ///     (Events::BetaManagedAgentsTextRubric value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Events::BetaManagedAgentsFileRubric, T> betaManagedAgentsFile,
        System::Func<Events::BetaManagedAgentsTextRubric, T> betaManagedAgentsText
    )
    {
        return this.Value switch
        {
            Events::BetaManagedAgentsFileRubric value => betaManagedAgentsFile(value),
            Events::BetaManagedAgentsTextRubric value => betaManagedAgentsText(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Rubric"
            ),
        };
    }

    public static implicit operator Rubric(Events::BetaManagedAgentsFileRubric value) => new(value);

    public static implicit operator Rubric(Events::BetaManagedAgentsTextRubric value) => new(value);

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
            Events::BetaManagedAgentsFileRubric _ => 0,
            Events::BetaManagedAgentsTextRubric _ => 1,
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
                    var deserialized =
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsFileRubric>(
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
                        JsonSerializer.Deserialize<Events::BetaManagedAgentsTextRubric>(
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

[JsonConverter(typeof(BetaManagedAgentsDeploymentUserDefineOutcomeEventTypeConverter))]
public enum BetaManagedAgentsDeploymentUserDefineOutcomeEventType
{
    UserDefineOutcome,
}

sealed class BetaManagedAgentsDeploymentUserDefineOutcomeEventTypeConverter
    : JsonConverter<BetaManagedAgentsDeploymentUserDefineOutcomeEventType>
{
    public override BetaManagedAgentsDeploymentUserDefineOutcomeEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.define_outcome" =>
                BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
            _ => (BetaManagedAgentsDeploymentUserDefineOutcomeEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeploymentUserDefineOutcomeEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome =>
                    "user.define_outcome",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
