using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Names the resolved permission_policy that produced evaluated_permission, and
/// under auto carries the judgement. Open union: clients must tolerate unknown variants.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsAgentToolEvaluationConverter))]
public record class BetaManagedAgentsAgentToolEvaluation : ModelBase
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
            return this.Value switch
            {
                BetaManagedAgentsAgentToolEvaluationAlwaysAllow x => x.Type,
                BetaManagedAgentsAgentToolEvaluationAlwaysAsk x => x.Type,
                BetaManagedAgentsAgentToolEvaluationAuto x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsAgentToolEvaluation(
        BetaManagedAgentsAgentToolEvaluationAlwaysAllow value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolEvaluation(
        BetaManagedAgentsAgentToolEvaluationAlwaysAsk value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolEvaluation(
        BetaManagedAgentsAgentToolEvaluationAuto value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolEvaluation(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentToolEvaluationAlwaysAllow"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAlwaysAllow(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentToolEvaluationAlwaysAllow`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAlwaysAllow(
        [NotNullWhen(true)] out BetaManagedAgentsAgentToolEvaluationAlwaysAllow? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentToolEvaluationAlwaysAllow;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentToolEvaluationAlwaysAsk"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAlwaysAsk(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentToolEvaluationAlwaysAsk`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAlwaysAsk(
        [NotNullWhen(true)] out BetaManagedAgentsAgentToolEvaluationAlwaysAsk? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentToolEvaluationAlwaysAsk;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentToolEvaluationAuto"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAuto(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentToolEvaluationAuto`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAuto([NotNullWhen(true)] out BetaManagedAgentsAgentToolEvaluationAuto? value)
    {
        value = this.Value as BetaManagedAgentsAgentToolEvaluationAuto;
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
    ///     (BetaManagedAgentsAgentToolEvaluationAlwaysAllow value) =&gt; {...},
    ///     (BetaManagedAgentsAgentToolEvaluationAlwaysAsk value) =&gt; {...},
    ///     (BetaManagedAgentsAgentToolEvaluationAuto value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAgentToolEvaluationAlwaysAllow> alwaysAllow,
        System::Action<BetaManagedAgentsAgentToolEvaluationAlwaysAsk> alwaysAsk,
        System::Action<BetaManagedAgentsAgentToolEvaluationAuto> auto
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAgentToolEvaluationAlwaysAllow value:
                alwaysAllow(value);
                break;
            case BetaManagedAgentsAgentToolEvaluationAlwaysAsk value:
                alwaysAsk(value);
                break;
            case BetaManagedAgentsAgentToolEvaluationAuto value:
                auto(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsAgentToolEvaluation"
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
    ///     (BetaManagedAgentsAgentToolEvaluationAlwaysAllow value) =&gt; {...},
    ///     (BetaManagedAgentsAgentToolEvaluationAlwaysAsk value) =&gt; {...},
    ///     (BetaManagedAgentsAgentToolEvaluationAuto value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsAgentToolEvaluationAlwaysAllow, T> alwaysAllow,
        System::Func<BetaManagedAgentsAgentToolEvaluationAlwaysAsk, T> alwaysAsk,
        System::Func<BetaManagedAgentsAgentToolEvaluationAuto, T> auto
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAgentToolEvaluationAlwaysAllow value => alwaysAllow(value),
            BetaManagedAgentsAgentToolEvaluationAlwaysAsk value => alwaysAsk(value),
            BetaManagedAgentsAgentToolEvaluationAuto value => auto(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsAgentToolEvaluation"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsAgentToolEvaluation(
        BetaManagedAgentsAgentToolEvaluationAlwaysAllow value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolEvaluation(
        BetaManagedAgentsAgentToolEvaluationAlwaysAsk value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolEvaluation(
        BetaManagedAgentsAgentToolEvaluationAuto value
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
                "Data did not match any variant of BetaManagedAgentsAgentToolEvaluation"
            );
        }
        this.Switch(
            (alwaysAllow) => alwaysAllow.Validate(),
            (alwaysAsk) => alwaysAsk.Validate(),
            (auto) => auto.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsAgentToolEvaluation? other) =>
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
            BetaManagedAgentsAgentToolEvaluationAlwaysAllow _ => 0,
            BetaManagedAgentsAgentToolEvaluationAlwaysAsk _ => 1,
            BetaManagedAgentsAgentToolEvaluationAuto _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsAgentToolEvaluationConverter
    : JsonConverter<BetaManagedAgentsAgentToolEvaluation>
{
    public override BetaManagedAgentsAgentToolEvaluation? Read(
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
            case "always_allow":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluationAlwaysAllow>(
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
            case "always_ask":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluationAlwaysAsk>(
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
            case "auto":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluationAuto>(
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
                return new BetaManagedAgentsAgentToolEvaluation(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentToolEvaluation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
