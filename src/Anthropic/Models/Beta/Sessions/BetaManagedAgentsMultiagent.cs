using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Resolved multiagent orchestration configuration as returned in API responses.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMultiagentConverter))]
public record class BetaManagedAgentsMultiagent : ModelBase
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

    public ApiEnum<string, BetaManagedAgentsMultiagentType> Type
    {
        get
        {
            return this.Value switch
            {
                Agents::BetaManagedAgentsMultiagentCoordinator _ =>
                    BetaManagedAgentsMultiagentType.Coordinator,
                Agents::BetaManagedAgentsMultiagent20261001 _ =>
                    BetaManagedAgentsMultiagentType.Multiagent20261001,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaManagedAgentsMultiagentType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsMultiagent(
        Agents::BetaManagedAgentsMultiagentCoordinator value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagent(
        Agents::BetaManagedAgentsMultiagent20261001 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsMultiagentCoordinator"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCoordinator(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsMultiagentCoordinator`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCoordinator(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsMultiagentCoordinator? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsMultiagentCoordinator;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsMultiagent20261001"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMultiagent20261001(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsMultiagent20261001`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMultiagent20261001(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsMultiagent20261001? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsMultiagent20261001;
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
    ///     (Agents::BetaManagedAgentsMultiagentCoordinator value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMultiagent20261001 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Agents::BetaManagedAgentsMultiagentCoordinator> coordinator,
        Action<Agents::BetaManagedAgentsMultiagent20261001> multiagent20261001
    )
    {
        switch (this.Value)
        {
            case Agents::BetaManagedAgentsMultiagentCoordinator value:
                coordinator(value);
                break;
            case Agents::BetaManagedAgentsMultiagent20261001 value:
                multiagent20261001(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsMultiagent"
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
    ///     (Agents::BetaManagedAgentsMultiagentCoordinator value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMultiagent20261001 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Agents::BetaManagedAgentsMultiagentCoordinator, T> coordinator,
        Func<Agents::BetaManagedAgentsMultiagent20261001, T> multiagent20261001
    )
    {
        return this.Value switch
        {
            Agents::BetaManagedAgentsMultiagentCoordinator value => coordinator(value),
            Agents::BetaManagedAgentsMultiagent20261001 value => multiagent20261001(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsMultiagent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsMultiagent(
        Agents::BetaManagedAgentsMultiagentCoordinator value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMultiagent(
        Agents::BetaManagedAgentsMultiagent20261001 value
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
                "Data did not match any variant of BetaManagedAgentsMultiagent"
            );
        }
        this.Switch(
            (coordinator) => coordinator.Validate(),
            (multiagent20261001) => multiagent20261001.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsMultiagent? other) =>
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
            Agents::BetaManagedAgentsMultiagentCoordinator _ => 0,
            Agents::BetaManagedAgentsMultiagent20261001 _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsMultiagentConverter : JsonConverter<BetaManagedAgentsMultiagent>
{
    public override BetaManagedAgentsMultiagent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsMultiagentCoordinator>(
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
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsMultiagent20261001>(
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
                return new BetaManagedAgentsMultiagent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsMultiagentTypeConverter))]
public enum BetaManagedAgentsMultiagentType
{
    Coordinator,
    Multiagent20261001,
}

sealed class BetaManagedAgentsMultiagentTypeConverter
    : JsonConverter<BetaManagedAgentsMultiagentType>
{
    public override BetaManagedAgentsMultiagentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coordinator" => BetaManagedAgentsMultiagentType.Coordinator,
            "multiagent_20261001" => BetaManagedAgentsMultiagentType.Multiagent20261001,
            _ => (BetaManagedAgentsMultiagentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMultiagentType.Coordinator => "coordinator",
                BetaManagedAgentsMultiagentType.Multiagent20261001 => "multiagent_20261001",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
