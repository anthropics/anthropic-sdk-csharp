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
/// A Managed Agents `agent`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaManagedAgentsAgent, BetaManagedAgentsAgentFromRaw>))]
public sealed record class BetaManagedAgentsAgent : JsonModel
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

    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
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

    public required IReadOnlyList<BetaManagedAgentsAgentTool> Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsAgentTool>>(
                "tools"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsAgentTool>>(
                "tools",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, global::Anthropic.Models.Beta.Agents.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Agents.Type>
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
    /// The agent's current version. Starts at 1 and increments when the agent is modified.
    /// </summary>
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
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.Description;
        foreach (var item in this.McpServers)
        {
            item.Validate();
        }
        _ = this.Metadata;
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
        _ = this.UpdatedAt;
        _ = this.Version;
    }

    public BetaManagedAgentsAgent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgent(BetaManagedAgentsAgent betaManagedAgentsAgent)
        : base(betaManagedAgentsAgent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentFromRaw : IFromRawJson<BetaManagedAgentsAgent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgent.FromRawUnchecked(rawData);
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

    public static implicit operator Skill(BetaManagedAgentsAnthropicSkill value) => new(value);

    public static implicit operator Skill(BetaManagedAgentsCustomSkill value) => new(value);

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
            BetaManagedAgentsAnthropicSkill _ => 0,
            BetaManagedAgentsCustomSkill _ => 1,
            _ => -1,
        };
    }
}

sealed class SkillConverter : JsonConverter<Skill>
{
    public override Skill? Read(
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
                return new Skill(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Skill value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Union type for tool configurations returned in API responses.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsAgentToolConverter))]
public record class BetaManagedAgentsAgentTool : ModelBase
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

    public BetaManagedAgentsAgentTool(
        BetaManagedAgentsAgentToolset20260401 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentTool(
        BetaManagedAgentsMcpToolset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentTool(
        BetaManagedAgentsCustomTool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentTool(JsonElement element)
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
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsAgentTool"
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
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsAgentTool"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsAgentTool(
        BetaManagedAgentsAgentToolset20260401 value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentTool(BetaManagedAgentsMcpToolset value) =>
        new(value);

    public static implicit operator BetaManagedAgentsAgentTool(BetaManagedAgentsCustomTool value) =>
        new(value);

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
                "Data did not match any variant of BetaManagedAgentsAgentTool"
            );
        }
        this.Switch(
            (betaManagedAgentsAgentToolset20260401) =>
                betaManagedAgentsAgentToolset20260401.Validate(),
            (betaManagedAgentsMcpToolset) => betaManagedAgentsMcpToolset.Validate(),
            (betaManagedAgentsCustom) => betaManagedAgentsCustom.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsAgentTool? other) =>
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

sealed class BetaManagedAgentsAgentToolConverter : JsonConverter<BetaManagedAgentsAgentTool>
{
    public override BetaManagedAgentsAgentTool? Read(
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
                return new BetaManagedAgentsAgentTool(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentTool value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Agent,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Agents.Type>
{
    public override global::Anthropic.Models.Beta.Agents.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent" => global::Anthropic.Models.Beta.Agents.Type.Agent,
            _ => (global::Anthropic.Models.Beta.Agents.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Agents.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Agents.Type.Agent => "agent",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
