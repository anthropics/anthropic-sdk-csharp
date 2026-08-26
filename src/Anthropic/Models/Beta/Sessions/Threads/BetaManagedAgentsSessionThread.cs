using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Agents = Anthropic.Models.Beta.Agents;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Threads;

/// <summary>
/// An execution thread within a `session`. Each session has one primary thread plus
/// zero or more child threads spawned by the coordinator.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionThread,
        BetaManagedAgentsSessionThreadFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionThread : JsonModel
{
    /// <summary>
    /// Unique identifier for this thread.
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
    /// The resolved agent a session thread runs: a saved-agent snapshot, the platform
    /// advisor entry, or an inline-defined (ephemeral) agent snapshot.
    /// </summary>
    public required Agent Agent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Agent>("agent");
        }
        init { this._rawData.Set("agent", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Parent thread that spawned this thread. Null for the primary thread.
    /// </summary>
    public required string? ParentThreadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parent_thread_id");
        }
        init { this._rawData.Set("parent_thread_id", value); }
    }

    /// <summary>
    /// The session this thread belongs to.
    /// </summary>
    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// Timing statistics for a session thread.
    /// </summary>
    public required BetaManagedAgentsSessionThreadStats? Stats
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsSessionThreadStats>("stats");
        }
        init { this._rawData.Set("stats", value); }
    }

    /// <summary>
    /// SessionThreadStatus enum
    /// </summary>
    public required ApiEnum<string, BetaManagedAgentsSessionThreadStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionThreadStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Threads.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Threads.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Cumulative token usage for a session thread across all turns.
    /// </summary>
    public required BetaManagedAgentsSessionThreadUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsSessionThreadUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Agent.Validate();
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.ParentThreadID;
        _ = this.SessionID;
        this.Stats?.Validate();
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
        this.Usage?.Validate();
    }

    public BetaManagedAgentsSessionThread() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionThread(
        BetaManagedAgentsSessionThread betaManagedAgentsSessionThread
    )
        : base(betaManagedAgentsSessionThread) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionThread(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionThread(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionThreadFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionThread FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionThreadFromRaw : IFromRawJson<BetaManagedAgentsSessionThread>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionThread FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionThread.FromRawUnchecked(rawData);
}

/// <summary>
/// The resolved agent a session thread runs: a saved-agent snapshot, the platform
/// advisor entry, or an inline-defined (ephemeral) agent snapshot.
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

    public Agent(Agents::BetaManagedAgentsSessionThreadAgent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Agent(Agents::BetaManagedAgentsAdvisor value, JsonElement? element = null)
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
    /// type <see cref="Agents::BetaManagedAgentsSessionThreadAgent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSessionThread(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsSessionThreadAgent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSessionThread(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsSessionThreadAgent? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsSessionThreadAgent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsAdvisor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAdvisor(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsAdvisor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAdvisor(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsAdvisor? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsAdvisor;
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
    ///     (Agents::BetaManagedAgentsSessionThreadAgent value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsAdvisor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Agents::BetaManagedAgentsSessionThreadAgent> betaManagedAgentsSessionThread,
        System::Action<Agents::BetaManagedAgentsAdvisor> betaManagedAgentsAdvisor
    )
    {
        switch (this.Value)
        {
            case Agents::BetaManagedAgentsSessionThreadAgent value:
                betaManagedAgentsSessionThread(value);
                break;
            case Agents::BetaManagedAgentsAdvisor value:
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
    ///     (Agents::BetaManagedAgentsSessionThreadAgent value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsAdvisor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Agents::BetaManagedAgentsSessionThreadAgent, T> betaManagedAgentsSessionThread,
        System::Func<Agents::BetaManagedAgentsAdvisor, T> betaManagedAgentsAdvisor
    )
    {
        return this.Value switch
        {
            Agents::BetaManagedAgentsSessionThreadAgent value => betaManagedAgentsSessionThread(
                value
            ),
            Agents::BetaManagedAgentsAdvisor value => betaManagedAgentsAdvisor(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Agent"),
        };
    }

    public static implicit operator Agent(Agents::BetaManagedAgentsSessionThreadAgent value) =>
        new(value);

    public static implicit operator Agent(Agents::BetaManagedAgentsAdvisor value) => new(value);

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
            (betaManagedAgentsSessionThread) => betaManagedAgentsSessionThread.Validate(),
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
            Agents::BetaManagedAgentsSessionThreadAgent _ => 0,
            Agents::BetaManagedAgentsAdvisor _ => 1,
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
                    var deserialized =
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsSessionThreadAgent>(
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
                    var deserialized = JsonSerializer.Deserialize<Agents::BetaManagedAgentsAdvisor>(
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

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    SessionThread,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Sessions.Threads.Type>
{
    public override global::Anthropic.Models.Beta.Sessions.Threads.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session_thread" => global::Anthropic.Models.Beta.Sessions.Threads.Type.SessionThread,
            _ => (global::Anthropic.Models.Beta.Sessions.Threads.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Sessions.Threads.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Sessions.Threads.Type.SessionThread =>
                    "session_thread",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
