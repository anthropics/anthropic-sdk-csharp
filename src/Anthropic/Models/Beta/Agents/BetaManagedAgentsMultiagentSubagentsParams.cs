using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Whether the agent can spawn session threads.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMultiagentSubagentsParamsConverter))]
public record class BetaManagedAgentsMultiagentSubagentsParams : ModelBase
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
                BetaManagedAgentsMultiagentSubagentsEnabledParams x => x.Type,
                BetaManagedAgentsMultiagentSubagentsDisabledParams x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsMultiagentSubagentsParams(
        BetaManagedAgentsMultiagentSubagentsEnabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentSubagentsParams(
        BetaManagedAgentsMultiagentSubagentsDisabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentSubagentsParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMultiagentSubagentsEnabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMultiagentSubagentsEnabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled(
        [NotNullWhen(true)] out BetaManagedAgentsMultiagentSubagentsEnabledParams? value
    )
    {
        value = this.Value as BetaManagedAgentsMultiagentSubagentsEnabledParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMultiagentSubagentsDisabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMultiagentSubagentsDisabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled(
        [NotNullWhen(true)] out BetaManagedAgentsMultiagentSubagentsDisabledParams? value
    )
    {
        value = this.Value as BetaManagedAgentsMultiagentSubagentsDisabledParams;
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
    ///     (BetaManagedAgentsMultiagentSubagentsEnabledParams value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagentSubagentsDisabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsMultiagentSubagentsEnabledParams> enabled,
        System::Action<BetaManagedAgentsMultiagentSubagentsDisabledParams> disabled
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsMultiagentSubagentsEnabledParams value:
                enabled(value);
                break;
            case BetaManagedAgentsMultiagentSubagentsDisabledParams value:
                disabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsMultiagentSubagentsParams"
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
    ///     (BetaManagedAgentsMultiagentSubagentsEnabledParams value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagentSubagentsDisabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsMultiagentSubagentsEnabledParams, T> enabled,
        System::Func<BetaManagedAgentsMultiagentSubagentsDisabledParams, T> disabled
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsMultiagentSubagentsEnabledParams value => enabled(value),
            BetaManagedAgentsMultiagentSubagentsDisabledParams value => disabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsMultiagentSubagentsParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsMultiagentSubagentsParams(
        BetaManagedAgentsMultiagentSubagentsEnabledParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMultiagentSubagentsParams(
        BetaManagedAgentsMultiagentSubagentsDisabledParams value
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
                "Data did not match any variant of BetaManagedAgentsMultiagentSubagentsParams"
            );
        }
        this.Switch((enabled) => enabled.Validate(), (disabled) => disabled.Validate());
    }

    public virtual bool Equals(BetaManagedAgentsMultiagentSubagentsParams? other) =>
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
            BetaManagedAgentsMultiagentSubagentsEnabledParams _ => 0,
            BetaManagedAgentsMultiagentSubagentsDisabledParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsMultiagentSubagentsParamsConverter
    : JsonConverter<BetaManagedAgentsMultiagentSubagentsParams>
{
    public override BetaManagedAgentsMultiagentSubagentsParams? Read(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSubagentsEnabledParams>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSubagentsDisabledParams>(
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
                return new BetaManagedAgentsMultiagentSubagentsParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentSubagentsParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
