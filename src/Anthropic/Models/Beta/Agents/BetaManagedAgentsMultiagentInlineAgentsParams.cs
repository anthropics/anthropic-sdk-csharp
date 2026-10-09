using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Whether the agent can define inline agents. The agent defines an inline agent
/// itself, in a workflow run's plan or when it spawns a session thread, and the
/// inline agent is not saved.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMultiagentInlineAgentsParamsConverter))]
public record class BetaManagedAgentsMultiagentInlineAgentsParams : ModelBase
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
                BetaManagedAgentsMultiagentInlineAgentsEnabledParams x => x.Type,
                BetaManagedAgentsMultiagentInlineAgentsDisabledParams x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsMultiagentInlineAgentsParams(
        BetaManagedAgentsMultiagentInlineAgentsEnabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentInlineAgentsParams(
        BetaManagedAgentsMultiagentInlineAgentsDisabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentInlineAgentsParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMultiagentInlineAgentsEnabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMultiagentInlineAgentsEnabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled(
        [NotNullWhen(true)] out BetaManagedAgentsMultiagentInlineAgentsEnabledParams? value
    )
    {
        value = this.Value as BetaManagedAgentsMultiagentInlineAgentsEnabledParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMultiagentInlineAgentsDisabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMultiagentInlineAgentsDisabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled(
        [NotNullWhen(true)] out BetaManagedAgentsMultiagentInlineAgentsDisabledParams? value
    )
    {
        value = this.Value as BetaManagedAgentsMultiagentInlineAgentsDisabledParams;
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
    ///     (BetaManagedAgentsMultiagentInlineAgentsEnabledParams value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagentInlineAgentsDisabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsMultiagentInlineAgentsEnabledParams> enabled,
        System::Action<BetaManagedAgentsMultiagentInlineAgentsDisabledParams> disabled
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsMultiagentInlineAgentsEnabledParams value:
                enabled(value);
                break;
            case BetaManagedAgentsMultiagentInlineAgentsDisabledParams value:
                disabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsMultiagentInlineAgentsParams"
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
    ///     (BetaManagedAgentsMultiagentInlineAgentsEnabledParams value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagentInlineAgentsDisabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsMultiagentInlineAgentsEnabledParams, T> enabled,
        System::Func<BetaManagedAgentsMultiagentInlineAgentsDisabledParams, T> disabled
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsMultiagentInlineAgentsEnabledParams value => enabled(value),
            BetaManagedAgentsMultiagentInlineAgentsDisabledParams value => disabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsMultiagentInlineAgentsParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsMultiagentInlineAgentsParams(
        BetaManagedAgentsMultiagentInlineAgentsEnabledParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMultiagentInlineAgentsParams(
        BetaManagedAgentsMultiagentInlineAgentsDisabledParams value
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
                "Data did not match any variant of BetaManagedAgentsMultiagentInlineAgentsParams"
            );
        }
        this.Switch((enabled) => enabled.Validate(), (disabled) => disabled.Validate());
    }

    public virtual bool Equals(BetaManagedAgentsMultiagentInlineAgentsParams? other) =>
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
            BetaManagedAgentsMultiagentInlineAgentsEnabledParams _ => 0,
            BetaManagedAgentsMultiagentInlineAgentsDisabledParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsMultiagentInlineAgentsParamsConverter
    : JsonConverter<BetaManagedAgentsMultiagentInlineAgentsParams>
{
    public override BetaManagedAgentsMultiagentInlineAgentsParams? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMultiagentInlineAgentsEnabledParams>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMultiagentInlineAgentsDisabledParams>(
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
                return new BetaManagedAgentsMultiagentInlineAgentsParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentInlineAgentsParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
