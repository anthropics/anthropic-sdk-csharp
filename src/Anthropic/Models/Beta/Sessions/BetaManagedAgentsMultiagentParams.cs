using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Multiagent orchestration configuration.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMultiagentParamsConverter))]
public record class BetaManagedAgentsMultiagentParams : ModelBase
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

    public BetaManagedAgentsMultiagentParams(
        BetaManagedAgentsMultiagentCoordinatorParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentParams(
        BetaManagedAgentsMultiagent20261001Params value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMultiagentCoordinatorParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCoordinator(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMultiagentCoordinatorParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCoordinator(
        [NotNullWhen(true)] out BetaManagedAgentsMultiagentCoordinatorParams? value
    )
    {
        value = this.Value as BetaManagedAgentsMultiagentCoordinatorParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMultiagent20261001Params"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMultiagent20261001(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMultiagent20261001Params`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMultiagent20261001(
        [NotNullWhen(true)] out BetaManagedAgentsMultiagent20261001Params? value
    )
    {
        value = this.Value as BetaManagedAgentsMultiagent20261001Params;
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
    ///     (BetaManagedAgentsMultiagentCoordinatorParams value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagent20261001Params value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsMultiagentCoordinatorParams> coordinator,
        System::Action<BetaManagedAgentsMultiagent20261001Params> multiagent20261001
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsMultiagentCoordinatorParams value:
                coordinator(value);
                break;
            case BetaManagedAgentsMultiagent20261001Params value:
                multiagent20261001(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsMultiagentParams"
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
    ///     (BetaManagedAgentsMultiagentCoordinatorParams value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagent20261001Params value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsMultiagentCoordinatorParams, T> coordinator,
        System::Func<BetaManagedAgentsMultiagent20261001Params, T> multiagent20261001
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsMultiagentCoordinatorParams value => coordinator(value),
            BetaManagedAgentsMultiagent20261001Params value => multiagent20261001(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsMultiagentParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsMultiagentParams(
        BetaManagedAgentsMultiagentCoordinatorParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMultiagentParams(
        BetaManagedAgentsMultiagent20261001Params value
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
                "Data did not match any variant of BetaManagedAgentsMultiagentParams"
            );
        }
        this.Switch(
            (coordinator) => coordinator.Validate(),
            (multiagent20261001) => multiagent20261001.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsMultiagentParams? other) =>
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
            BetaManagedAgentsMultiagentCoordinatorParams _ => 0,
            BetaManagedAgentsMultiagent20261001Params _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsMultiagentParamsConverter
    : JsonConverter<BetaManagedAgentsMultiagentParams>
{
    public override BetaManagedAgentsMultiagentParams? Read(
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
            case "coordinator":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMultiagentCoordinatorParams>(
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
            case "multiagent_20261001":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMultiagent20261001Params>(
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
                return new BetaManagedAgentsMultiagentParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
