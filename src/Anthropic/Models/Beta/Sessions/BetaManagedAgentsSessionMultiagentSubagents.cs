using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Whether the agent can spawn session threads.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionMultiagentSubagentsConverter))]
public record class BetaManagedAgentsSessionMultiagentSubagents : ModelBase
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
                BetaManagedAgentsSessionMultiagentSubagentsEnabled x => x.Type,
                BetaManagedAgentsMultiagentSubagentsDisabled x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsSessionMultiagentSubagents(
        BetaManagedAgentsSessionMultiagentSubagentsEnabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionMultiagentSubagents(
        BetaManagedAgentsMultiagentSubagentsDisabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionMultiagentSubagents(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionMultiagentSubagentsEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionMultiagentSubagentsEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled(
        [NotNullWhen(true)] out BetaManagedAgentsSessionMultiagentSubagentsEnabled? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionMultiagentSubagentsEnabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMultiagentSubagentsDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMultiagentSubagentsDisabled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMultiagentSubagentsDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMultiagentSubagentsDisabled(
        [NotNullWhen(true)] out BetaManagedAgentsMultiagentSubagentsDisabled? value
    )
    {
        value = this.Value as BetaManagedAgentsMultiagentSubagentsDisabled;
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
    ///     (BetaManagedAgentsSessionMultiagentSubagentsEnabled value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagentSubagentsDisabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsSessionMultiagentSubagentsEnabled> enabled,
        System::Action<BetaManagedAgentsMultiagentSubagentsDisabled> multiagentSubagentsDisabled
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsSessionMultiagentSubagentsEnabled value:
                enabled(value);
                break;
            case BetaManagedAgentsMultiagentSubagentsDisabled value:
                multiagentSubagentsDisabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSessionMultiagentSubagents"
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
    ///     (BetaManagedAgentsSessionMultiagentSubagentsEnabled value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagentSubagentsDisabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsSessionMultiagentSubagentsEnabled, T> enabled,
        System::Func<BetaManagedAgentsMultiagentSubagentsDisabled, T> multiagentSubagentsDisabled
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsSessionMultiagentSubagentsEnabled value => enabled(value),
            BetaManagedAgentsMultiagentSubagentsDisabled value => multiagentSubagentsDisabled(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionMultiagentSubagents"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSessionMultiagentSubagents(
        BetaManagedAgentsSessionMultiagentSubagentsEnabled value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionMultiagentSubagents(
        BetaManagedAgentsMultiagentSubagentsDisabled value
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
                "Data did not match any variant of BetaManagedAgentsSessionMultiagentSubagents"
            );
        }
        this.Switch(
            (enabled) => enabled.Validate(),
            (multiagentSubagentsDisabled) => multiagentSubagentsDisabled.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsSessionMultiagentSubagents? other) =>
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
            BetaManagedAgentsSessionMultiagentSubagentsEnabled _ => 0,
            BetaManagedAgentsMultiagentSubagentsDisabled _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSessionMultiagentSubagentsConverter
    : JsonConverter<BetaManagedAgentsSessionMultiagentSubagents>
{
    public override BetaManagedAgentsSessionMultiagentSubagents? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentSubagentsEnabled>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSubagentsDisabled>(
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
                return new BetaManagedAgentsSessionMultiagentSubagents(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionMultiagentSubagents value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
