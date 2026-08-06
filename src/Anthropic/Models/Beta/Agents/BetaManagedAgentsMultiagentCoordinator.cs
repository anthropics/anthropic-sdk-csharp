using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Resolved coordinator topology with a concrete agent roster.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentCoordinator,
        BetaManagedAgentsMultiagentCoordinatorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentCoordinator : JsonModel
{
    /// <summary>
    /// Agents the coordinator may spawn as session threads, each resolved to a specific version.
    /// </summary>
    public required IReadOnlyList<Agent> Agents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Agent>>("agents");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Agent>>(
                "agents",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Agents)
        {
            item.Validate();
        }
        this.Type.Validate();
    }

    public BetaManagedAgentsMultiagentCoordinator() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentCoordinator(
        BetaManagedAgentsMultiagentCoordinator betaManagedAgentsMultiagentCoordinator
    )
        : base(betaManagedAgentsMultiagentCoordinator) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentCoordinator(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentCoordinator(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentCoordinatorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentCoordinator FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentCoordinatorFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentCoordinator>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentCoordinator FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentCoordinator.FromRawUnchecked(rawData);
}

/// <summary>
/// A resolved multiagent roster entry.
/// </summary>
[JsonConverter(typeof(AgentConverter))]
public record class Agent : ModelBase
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

    public Agent(BetaManagedAgentsAgentReference value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Agent(BetaManagedAgentsAdvisor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Agent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentReference"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAgentReference(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentReference`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAgentReference(
        [NotNullWhen(true)] out BetaManagedAgentsAgentReference? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentReference;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAdvisor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAdvisor(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAdvisor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAdvisor(
        [NotNullWhen(true)] out BetaManagedAgentsAdvisor? value
    )
    {
        value = this.Value as BetaManagedAgentsAdvisor;
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
    ///     (BetaManagedAgentsAgentReference value) =&gt; {...},
    ///     (BetaManagedAgentsAdvisor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAgentReference> betaManagedAgentsAgentReference,
        System::Action<BetaManagedAgentsAdvisor> betaManagedAgentsAdvisor
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAgentReference value:
                betaManagedAgentsAgentReference(value);
                break;
            case BetaManagedAgentsAdvisor value:
                betaManagedAgentsAdvisor(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Agent");
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
    ///     (BetaManagedAgentsAgentReference value) =&gt; {...},
    ///     (BetaManagedAgentsAdvisor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsAgentReference, T> betaManagedAgentsAgentReference,
        System::Func<BetaManagedAgentsAdvisor, T> betaManagedAgentsAdvisor
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAgentReference value => betaManagedAgentsAgentReference(value),
            BetaManagedAgentsAdvisor value => betaManagedAgentsAdvisor(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Agent"),
        };
    }

    public static implicit operator Agent(BetaManagedAgentsAgentReference value) => new(value);

    public static implicit operator Agent(BetaManagedAgentsAdvisor value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Agent");
        }
        this.Switch(
            (betaManagedAgentsAgentReference) => betaManagedAgentsAgentReference.Validate(),
            (betaManagedAgentsAdvisor) => betaManagedAgentsAdvisor.Validate()
        );
    }

    public virtual bool Equals(Agent? other) =>
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
            BetaManagedAgentsAgentReference _ => 0,
            BetaManagedAgentsAdvisor _ => 1,
            _ => -1,
        };
    }
}

sealed class AgentConverter : JsonConverter<Agent>
{
    public override Agent? Read(
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
            case "agent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentReference>(
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
            case "advisor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAdvisor>(
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
                return new Agent(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Agent value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsMultiagentCoordinatorTypeConverter))]
public enum BetaManagedAgentsMultiagentCoordinatorType
{
    Coordinator,
}

sealed class BetaManagedAgentsMultiagentCoordinatorTypeConverter
    : JsonConverter<BetaManagedAgentsMultiagentCoordinatorType>
{
    public override BetaManagedAgentsMultiagentCoordinatorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coordinator" => BetaManagedAgentsMultiagentCoordinatorType.Coordinator,
            _ => (BetaManagedAgentsMultiagentCoordinatorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentCoordinatorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMultiagentCoordinatorType.Coordinator => "coordinator",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
