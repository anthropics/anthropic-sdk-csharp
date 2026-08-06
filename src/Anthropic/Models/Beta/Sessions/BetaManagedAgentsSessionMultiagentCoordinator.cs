using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Resolved coordinator topology with full agent definitions for each roster member.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionMultiagentCoordinator,
        BetaManagedAgentsSessionMultiagentCoordinatorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionMultiagentCoordinator : JsonModel
{
    /// <summary>
    /// Full `agent` definitions the coordinator may spawn as session threads.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsSessionMultiagentCoordinatorAgent> Agents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsSessionMultiagentCoordinatorAgent>
            >("agents");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSessionMultiagentCoordinatorAgent>>(
                "agents",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType>
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

    public BetaManagedAgentsSessionMultiagentCoordinator() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionMultiagentCoordinator(
        BetaManagedAgentsSessionMultiagentCoordinator betaManagedAgentsSessionMultiagentCoordinator
    )
        : base(betaManagedAgentsSessionMultiagentCoordinator) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionMultiagentCoordinator(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionMultiagentCoordinator(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionMultiagentCoordinatorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionMultiagentCoordinator FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionMultiagentCoordinatorFromRaw
    : IFromRawJson<BetaManagedAgentsSessionMultiagentCoordinator>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionMultiagentCoordinator FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionMultiagentCoordinator.FromRawUnchecked(rawData);
}

/// <summary>
/// A session-resolved multiagent roster entry.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionMultiagentCoordinatorAgentConverter))]
public record class BetaManagedAgentsSessionMultiagentCoordinatorAgent : ModelBase
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

    public BetaManagedAgentsSessionMultiagentCoordinatorAgent(
        BetaManagedAgentsSessionThreadAgent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionMultiagentCoordinatorAgent(
        BetaManagedAgentsAdvisor value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionMultiagentCoordinatorAgent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionThreadAgent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSessionThread(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadAgent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSessionThread(
        [NotNullWhen(true)] out BetaManagedAgentsSessionThreadAgent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionThreadAgent;
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
    ///     (BetaManagedAgentsSessionThreadAgent value) =&gt; {...},
    ///     (BetaManagedAgentsAdvisor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsSessionThreadAgent> betaManagedAgentsSessionThread,
        System::Action<BetaManagedAgentsAdvisor> betaManagedAgentsAdvisor
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsSessionThreadAgent value:
                betaManagedAgentsSessionThread(value);
                break;
            case BetaManagedAgentsAdvisor value:
                betaManagedAgentsAdvisor(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSessionMultiagentCoordinatorAgent"
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
    ///     (BetaManagedAgentsSessionThreadAgent value) =&gt; {...},
    ///     (BetaManagedAgentsAdvisor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsSessionThreadAgent, T> betaManagedAgentsSessionThread,
        System::Func<BetaManagedAgentsAdvisor, T> betaManagedAgentsAdvisor
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsSessionThreadAgent value => betaManagedAgentsSessionThread(value),
            BetaManagedAgentsAdvisor value => betaManagedAgentsAdvisor(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionMultiagentCoordinatorAgent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSessionMultiagentCoordinatorAgent(
        BetaManagedAgentsSessionThreadAgent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionMultiagentCoordinatorAgent(
        BetaManagedAgentsAdvisor value
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
                "Data did not match any variant of BetaManagedAgentsSessionMultiagentCoordinatorAgent"
            );
        }
        this.Switch(
            (betaManagedAgentsSessionThread) => betaManagedAgentsSessionThread.Validate(),
            (betaManagedAgentsAdvisor) => betaManagedAgentsAdvisor.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsSessionMultiagentCoordinatorAgent? other) =>
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
            BetaManagedAgentsSessionThreadAgent _ => 0,
            BetaManagedAgentsAdvisor _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSessionMultiagentCoordinatorAgentConverter
    : JsonConverter<BetaManagedAgentsSessionMultiagentCoordinatorAgent>
{
    public override BetaManagedAgentsSessionMultiagentCoordinatorAgent? Read(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgent>(
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
                return new BetaManagedAgentsSessionMultiagentCoordinatorAgent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionMultiagentCoordinatorAgent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsSessionMultiagentCoordinatorTypeConverter))]
public enum BetaManagedAgentsSessionMultiagentCoordinatorType
{
    Coordinator,
}

sealed class BetaManagedAgentsSessionMultiagentCoordinatorTypeConverter
    : JsonConverter<BetaManagedAgentsSessionMultiagentCoordinatorType>
{
    public override BetaManagedAgentsSessionMultiagentCoordinatorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coordinator" => BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
            _ => (BetaManagedAgentsSessionMultiagentCoordinatorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionMultiagentCoordinatorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator => "coordinator",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
