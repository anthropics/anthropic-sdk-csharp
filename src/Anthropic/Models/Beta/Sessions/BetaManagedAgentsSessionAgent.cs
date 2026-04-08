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

    public required IReadOnlyList<BetaManagedAgentsMcpServerUrlDefinition> McpServers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsMcpServerUrlDefinition>
            >("mcp_servers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsMcpServerUrlDefinition>>(
                "mcp_servers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Model identifier and configuration.
    /// </summary>
    public required BetaManagedAgentsModelConfig Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsModelConfig>("model");
        }
        init { this._rawData.Set("model", value); }
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

    public required IReadOnlyList<global::Anthropic.Models.Beta.Sessions.Skill> Skills
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::Anthropic.Models.Beta.Sessions.Skill>
            >("skills");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::Anthropic.Models.Beta.Sessions.Skill>>(
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

    public required IReadOnlyList<global::Anthropic.Models.Beta.Sessions.Tool> Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::Anthropic.Models.Beta.Sessions.Tool>
            >("tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::Anthropic.Models.Beta.Sessions.Tool>>(
                "tools",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionAgentType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionAgentType>
            >("type");
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
        foreach (var item in this.McpServers)
        {
            item.Validate();
        }
        this.Model.Validate();
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
        this.Type.Validate();
        _ = this.Version;
    }

    public BetaManagedAgentsSessionAgent() { }

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
[JsonConverter(typeof(global::Anthropic.Models.Beta.Sessions.SkillConverter))]
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
            return Match(
                betaManagedAgentsAnthropic: (x) => x.SkillID,
                betaManagedAgentsCustom: (x) => x.SkillID
            );
        }
    }

    public string Version
    {
        get
        {
            return Match(
                betaManagedAgentsAnthropic: (x) => x.Version,
                betaManagedAgentsCustom: (x) => x.Version
            );
        }
    }

    public Skill(BetaManagedAgentsAnthropicSkill value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Skill(BetaManagedAgentsCustomSkill value, JsonElement? element = null)
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
    /// type <see cref="BetaManagedAgentsAnthropicSkill"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAnthropic(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAnthropicSkill`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAnthropic(
        [NotNullWhen(true)] out BetaManagedAgentsAnthropicSkill? value
    )
    {
        value = this.Value as BetaManagedAgentsAnthropicSkill;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsCustomSkill"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsCustom(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsCustomSkill`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsCustom(
        [NotNullWhen(true)] out BetaManagedAgentsCustomSkill? value
    )
    {
        value = this.Value as BetaManagedAgentsCustomSkill;
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
    ///     (BetaManagedAgentsAnthropicSkill value) =&gt; {...},
    ///     (BetaManagedAgentsCustomSkill value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAnthropicSkill> betaManagedAgentsAnthropic,
        System::Action<BetaManagedAgentsCustomSkill> betaManagedAgentsCustom
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAnthropicSkill value:
                betaManagedAgentsAnthropic(value);
                break;
            case BetaManagedAgentsCustomSkill value:
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
    ///     (BetaManagedAgentsAnthropicSkill value) =&gt; {...},
    ///     (BetaManagedAgentsCustomSkill value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsAnthropicSkill, T> betaManagedAgentsAnthropic,
        System::Func<BetaManagedAgentsCustomSkill, T> betaManagedAgentsCustom
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAnthropicSkill value => betaManagedAgentsAnthropic(value),
            BetaManagedAgentsCustomSkill value => betaManagedAgentsCustom(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Skill"),
        };
    }

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Skill(
        BetaManagedAgentsAnthropicSkill value
    ) => new(value);

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Skill(
        BetaManagedAgentsCustomSkill value
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Skill");
        }
        this.Switch(
            (betaManagedAgentsAnthropic) => betaManagedAgentsAnthropic.Validate(),
            (betaManagedAgentsCustom) => betaManagedAgentsCustom.Validate()
        );
    }

    public virtual bool Equals(global::Anthropic.Models.Beta.Sessions.Skill? other) =>
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
            BetaManagedAgentsAnthropicSkill _ => 0,
            BetaManagedAgentsCustomSkill _ => 1,
            _ => -1,
        };
    }
}

sealed class SkillConverter : JsonConverter<global::Anthropic.Models.Beta.Sessions.Skill>
{
    public override global::Anthropic.Models.Beta.Sessions.Skill? Read(
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
            case "anthropic":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAnthropicSkill>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCustomSkill>(
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
                return new global::Anthropic.Models.Beta.Sessions.Skill(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Sessions.Skill value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Union type for tool configurations returned in API responses.
/// </summary>
[JsonConverter(typeof(global::Anthropic.Models.Beta.Sessions.ToolConverter))]
public record class Tool : ModelBase
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

    public Tool(BetaManagedAgentsAgentToolset20260401 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaManagedAgentsMcpToolset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaManagedAgentsCustomTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentToolset20260401"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAgentToolset20260401(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentToolset20260401`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAgentToolset20260401(
        [NotNullWhen(true)] out BetaManagedAgentsAgentToolset20260401? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentToolset20260401;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMcpToolset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpToolset(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMcpToolset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpToolset(
        [NotNullWhen(true)] out BetaManagedAgentsMcpToolset? value
    )
    {
        value = this.Value as BetaManagedAgentsMcpToolset;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsCustomTool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsCustom(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsCustomTool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsCustom(
        [NotNullWhen(true)] out BetaManagedAgentsCustomTool? value
    )
    {
        value = this.Value as BetaManagedAgentsCustomTool;
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
    ///     (BetaManagedAgentsAgentToolset20260401 value) =&gt; {...},
    ///     (BetaManagedAgentsMcpToolset value) =&gt; {...},
    ///     (BetaManagedAgentsCustomTool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAgentToolset20260401> betaManagedAgentsAgentToolset20260401,
        System::Action<BetaManagedAgentsMcpToolset> betaManagedAgentsMcpToolset,
        System::Action<BetaManagedAgentsCustomTool> betaManagedAgentsCustom
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAgentToolset20260401 value:
                betaManagedAgentsAgentToolset20260401(value);
                break;
            case BetaManagedAgentsMcpToolset value:
                betaManagedAgentsMcpToolset(value);
                break;
            case BetaManagedAgentsCustomTool value:
                betaManagedAgentsCustom(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
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
    ///     (BetaManagedAgentsAgentToolset20260401 value) =&gt; {...},
    ///     (BetaManagedAgentsMcpToolset value) =&gt; {...},
    ///     (BetaManagedAgentsCustomTool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsAgentToolset20260401,
            T
        > betaManagedAgentsAgentToolset20260401,
        System::Func<BetaManagedAgentsMcpToolset, T> betaManagedAgentsMcpToolset,
        System::Func<BetaManagedAgentsCustomTool, T> betaManagedAgentsCustom
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAgentToolset20260401 value => betaManagedAgentsAgentToolset20260401(
                value
            ),
            BetaManagedAgentsMcpToolset value => betaManagedAgentsMcpToolset(value),
            BetaManagedAgentsCustomTool value => betaManagedAgentsCustom(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Tool"),
        };
    }

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Tool(
        BetaManagedAgentsAgentToolset20260401 value
    ) => new(value);

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Tool(
        BetaManagedAgentsMcpToolset value
    ) => new(value);

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Tool(
        BetaManagedAgentsCustomTool value
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
        }
        this.Switch(
            (betaManagedAgentsAgentToolset20260401) =>
                betaManagedAgentsAgentToolset20260401.Validate(),
            (betaManagedAgentsMcpToolset) => betaManagedAgentsMcpToolset.Validate(),
            (betaManagedAgentsCustom) => betaManagedAgentsCustom.Validate()
        );
    }

    public virtual bool Equals(global::Anthropic.Models.Beta.Sessions.Tool? other) =>
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
            BetaManagedAgentsAgentToolset20260401 _ => 0,
            BetaManagedAgentsMcpToolset _ => 1,
            BetaManagedAgentsCustomTool _ => 2,
            _ => -1,
        };
    }
}

sealed class ToolConverter : JsonConverter<global::Anthropic.Models.Beta.Sessions.Tool>
{
    public override global::Anthropic.Models.Beta.Sessions.Tool? Read(
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
            case "agent_toolset_20260401":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpToolset>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCustomTool>(
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
                return new global::Anthropic.Models.Beta.Sessions.Tool(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Sessions.Tool value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsSessionAgentTypeConverter))]
public enum BetaManagedAgentsSessionAgentType
{
    Agent,
}

sealed class BetaManagedAgentsSessionAgentTypeConverter
    : JsonConverter<BetaManagedAgentsSessionAgentType>
{
    public override BetaManagedAgentsSessionAgentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent" => BetaManagedAgentsSessionAgentType.Agent,
            _ => (BetaManagedAgentsSessionAgentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionAgentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionAgentType.Agent => "agent",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
