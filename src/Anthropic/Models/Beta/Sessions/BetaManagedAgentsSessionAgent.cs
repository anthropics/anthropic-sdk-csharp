using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Resolved `agent` definition for a `session`. Snapshot of the `agent` at `session`
/// creation time.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsSessionAgent, BetaManagedAgentsSessionAgentFromRaw>)
)]
public sealed record class BetaManagedAgentsSessionAgent : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Execution principal snapshotted from the agent at session creation. Always
    /// present; `{"type": "service_account"}` when runs carry no customer-named principal.
    /// </summary>
    public required Agents::BetaManagedAgentsExecutionIdentity ExecutionIdentity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Agents::BetaManagedAgentsExecutionIdentity>(
                "execution_identity"
            );
        }
        init { this._rawData.Set("execution_identity", value); }
    }

    public required IReadOnlyList<Agents::BetaManagedAgentsMcpServerUrlDefinition> McpServers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<Agents::BetaManagedAgentsMcpServerUrlDefinition>
            >("mcp_servers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Agents::BetaManagedAgentsMcpServerUrlDefinition>>(
                "mcp_servers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Model identifier and configuration.
    /// </summary>
    public required Agents::BetaManagedAgentsModelConfig Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Agents::BetaManagedAgentsModelConfig>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// Resolved multiagent orchestration configuration. Null when the agent is single-threaded.
    /// </summary>
    public required BetaManagedAgentsSessionMultiagent? Multiagent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsSessionMultiagent>("multiagent");
        }
        init { this._rawData.Set("multiagent", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required IReadOnlyList<Skill> Skills
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Skill>>("skills");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Skill>>(
                "skills",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string? System
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system");
        }
        init { this._rawData.Set("system", value); }
    }

    public required IReadOnlyList<BetaManagedAgentsSessionAgentTool> Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsSessionAgentTool>
            >("tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSessionAgentTool>>(
                "tools",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required int Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        this.ExecutionIdentity.Validate();
        foreach (var item in this.McpServers)
        {
            item.Validate();
        }
        this.Model.Validate();
        this.Multiagent?.Validate();
        _ = this.Name;
        foreach (var item in this.Skills)
        {
            item.Validate();
        }
        _ = this.System;
        foreach (var item in this.Tools)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("agent")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Version;
    }

    public BetaManagedAgentsSessionAgent()
    {
        this.Type = JsonSerializer.SerializeToElement("agent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionAgent(
        BetaManagedAgentsSessionAgent betaManagedAgentsSessionAgent
    )
        : base(betaManagedAgentsSessionAgent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionAgent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionAgent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionAgentFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionAgentFromRaw : IFromRawJson<BetaManagedAgentsSessionAgent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionAgent.FromRawUnchecked(rawData);
}

/// <summary>
/// Resolved skill as returned in API responses.
/// </summary>
[JsonConverter(typeof(SkillConverter))]
public record class Skill : ModelBase
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

    public string SkillID
    {
        get
        {
            return this.Value switch
            {
                Agents::BetaManagedAgentsAnthropicSkill x => x.SkillID,
                Agents::BetaManagedAgentsCustomSkill x => x.SkillID,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "skill_id"),
            };
        }
    }

    public ApiEnum<string, SkillType> Type
    {
        get
        {
            return this.Value switch
            {
                Agents::BetaManagedAgentsAnthropicSkill _ => SkillType.Anthropic,
                Agents::BetaManagedAgentsCustomSkill _ => SkillType.Custom,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ApiEnum<string, SkillType>>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public string Version
    {
        get
        {
            return this.Value switch
            {
                Agents::BetaManagedAgentsAnthropicSkill x => x.Version,
                Agents::BetaManagedAgentsCustomSkill x => x.Version,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "version"),
            };
        }
    }

    public Skill(Agents::BetaManagedAgentsAnthropicSkill value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Skill(Agents::BetaManagedAgentsCustomSkill value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Skill(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsAnthropicSkill"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAnthropic(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsAnthropicSkill`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAnthropic(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsAnthropicSkill? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsAnthropicSkill;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsCustomSkill"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsCustom(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsCustomSkill`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsCustom(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsCustomSkill? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsCustomSkill;
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
    ///     (Agents::BetaManagedAgentsAnthropicSkill value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsCustomSkill value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Agents::BetaManagedAgentsAnthropicSkill> betaManagedAgentsAnthropic,
        Action<Agents::BetaManagedAgentsCustomSkill> betaManagedAgentsCustom
    )
    {
        switch (this.Value)
        {
            case Agents::BetaManagedAgentsAnthropicSkill value:
                betaManagedAgentsAnthropic(value);
                break;
            case Agents::BetaManagedAgentsCustomSkill value:
                betaManagedAgentsCustom(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Skill");
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
    ///     (Agents::BetaManagedAgentsAnthropicSkill value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsCustomSkill value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Agents::BetaManagedAgentsAnthropicSkill, T> betaManagedAgentsAnthropic,
        Func<Agents::BetaManagedAgentsCustomSkill, T> betaManagedAgentsCustom
    )
    {
        return this.Value switch
        {
            Agents::BetaManagedAgentsAnthropicSkill value => betaManagedAgentsAnthropic(value),
            Agents::BetaManagedAgentsCustomSkill value => betaManagedAgentsCustom(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Skill"),
        };
    }

    public static implicit operator Skill(Agents::BetaManagedAgentsAnthropicSkill value) =>
        new(value);

    public static implicit operator Skill(Agents::BetaManagedAgentsCustomSkill value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Skill");
        }
        this.Switch(
            (betaManagedAgentsAnthropic) => betaManagedAgentsAnthropic.Validate(),
            (betaManagedAgentsCustom) => betaManagedAgentsCustom.Validate()
        );
    }

    public virtual bool Equals(Skill? other) =>
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
            Agents::BetaManagedAgentsAnthropicSkill _ => 0,
            Agents::BetaManagedAgentsCustomSkill _ => 1,
            _ => -1,
        };
    }
}

sealed class SkillConverter : JsonConverter<Skill>
{
    public override Skill? Read(
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
            case "anthropic":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsAnthropicSkill>(
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
            case "custom":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsCustomSkill>(
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
                return new Skill(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Skill value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(SkillTypeConverter))]
public enum SkillType
{
    Anthropic,
    Custom,
}

sealed class SkillTypeConverter : JsonConverter<SkillType>
{
    public override SkillType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic" => SkillType.Anthropic,
            "custom" => SkillType.Custom,
            _ => (SkillType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SkillType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SkillType.Anthropic => "anthropic",
                SkillType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Union type for tool configurations returned in API responses.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionAgentToolConverter))]
public record class BetaManagedAgentsSessionAgentTool : ModelBase
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

    public ApiEnum<string, BetaManagedAgentsSessionAgentToolType> Type
    {
        get
        {
            return this.Value switch
            {
                Agents::BetaManagedAgentsAgentToolset20260401 _ =>
                    BetaManagedAgentsSessionAgentToolType.AgentToolset20260401,
                Agents::BetaManagedAgentsMcpToolset _ =>
                    BetaManagedAgentsSessionAgentToolType.McpToolset,
                Agents::BetaManagedAgentsCustomTool _ =>
                    BetaManagedAgentsSessionAgentToolType.Custom,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaManagedAgentsSessionAgentToolType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsSessionAgentTool(
        Agents::BetaManagedAgentsAgentToolset20260401 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionAgentTool(
        Agents::BetaManagedAgentsMcpToolset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionAgentTool(
        Agents::BetaManagedAgentsCustomTool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionAgentTool(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsAgentToolset20260401"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAgentToolset20260401(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsAgentToolset20260401`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAgentToolset20260401(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsAgentToolset20260401? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsAgentToolset20260401;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsMcpToolset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpToolset(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsMcpToolset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpToolset(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsMcpToolset? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsMcpToolset;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsCustomTool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsCustom(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsCustomTool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsCustom(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsCustomTool? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsCustomTool;
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
    ///     (Agents::BetaManagedAgentsAgentToolset20260401 value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMcpToolset value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsCustomTool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Agents::BetaManagedAgentsAgentToolset20260401> betaManagedAgentsAgentToolset20260401,
        Action<Agents::BetaManagedAgentsMcpToolset> betaManagedAgentsMcpToolset,
        Action<Agents::BetaManagedAgentsCustomTool> betaManagedAgentsCustom
    )
    {
        switch (this.Value)
        {
            case Agents::BetaManagedAgentsAgentToolset20260401 value:
                betaManagedAgentsAgentToolset20260401(value);
                break;
            case Agents::BetaManagedAgentsMcpToolset value:
                betaManagedAgentsMcpToolset(value);
                break;
            case Agents::BetaManagedAgentsCustomTool value:
                betaManagedAgentsCustom(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSessionAgentTool"
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
    ///     (Agents::BetaManagedAgentsAgentToolset20260401 value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMcpToolset value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsCustomTool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<
            Agents::BetaManagedAgentsAgentToolset20260401,
            T
        > betaManagedAgentsAgentToolset20260401,
        Func<Agents::BetaManagedAgentsMcpToolset, T> betaManagedAgentsMcpToolset,
        Func<Agents::BetaManagedAgentsCustomTool, T> betaManagedAgentsCustom
    )
    {
        return this.Value switch
        {
            Agents::BetaManagedAgentsAgentToolset20260401 value =>
                betaManagedAgentsAgentToolset20260401(value),
            Agents::BetaManagedAgentsMcpToolset value => betaManagedAgentsMcpToolset(value),
            Agents::BetaManagedAgentsCustomTool value => betaManagedAgentsCustom(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionAgentTool"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSessionAgentTool(
        Agents::BetaManagedAgentsAgentToolset20260401 value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionAgentTool(
        Agents::BetaManagedAgentsMcpToolset value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionAgentTool(
        Agents::BetaManagedAgentsCustomTool value
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
                "Data did not match any variant of BetaManagedAgentsSessionAgentTool"
            );
        }
        this.Switch(
            (betaManagedAgentsAgentToolset20260401) =>
                betaManagedAgentsAgentToolset20260401.Validate(),
            (betaManagedAgentsMcpToolset) => betaManagedAgentsMcpToolset.Validate(),
            (betaManagedAgentsCustom) => betaManagedAgentsCustom.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsSessionAgentTool? other) =>
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
            Agents::BetaManagedAgentsAgentToolset20260401 _ => 0,
            Agents::BetaManagedAgentsMcpToolset _ => 1,
            Agents::BetaManagedAgentsCustomTool _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSessionAgentToolConverter
    : JsonConverter<BetaManagedAgentsSessionAgentTool>
{
    public override BetaManagedAgentsSessionAgentTool? Read(
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
            case "agent_toolset_20260401":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsAgentToolset20260401>(
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
            case "mcp_toolset":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsMcpToolset>(
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
            case "custom":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsCustomTool>(
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
                return new BetaManagedAgentsSessionAgentTool(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionAgentTool value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsSessionAgentToolTypeConverter))]
public enum BetaManagedAgentsSessionAgentToolType
{
    AgentToolset20260401,
    McpToolset,
    Custom,
}

sealed class BetaManagedAgentsSessionAgentToolTypeConverter
    : JsonConverter<BetaManagedAgentsSessionAgentToolType>
{
    public override BetaManagedAgentsSessionAgentToolType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent_toolset_20260401" => BetaManagedAgentsSessionAgentToolType.AgentToolset20260401,
            "mcp_toolset" => BetaManagedAgentsSessionAgentToolType.McpToolset,
            "custom" => BetaManagedAgentsSessionAgentToolType.Custom,
            _ => (BetaManagedAgentsSessionAgentToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionAgentToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionAgentToolType.AgentToolset20260401 =>
                    "agent_toolset_20260401",
                BetaManagedAgentsSessionAgentToolType.McpToolset => "mcp_toolset",
                BetaManagedAgentsSessionAgentToolType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
