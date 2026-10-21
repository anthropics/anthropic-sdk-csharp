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
/// Reference to an `agent` plus optional configuration overrides. Each provided
/// field replaces the agent's value for the caller's use; the agent resource is unchanged.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentWithOverridesParams,
        BetaManagedAgentsAgentWithOverridesParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentWithOverridesParams : JsonModel
{
    /// <summary>
    /// The `agent` ID.
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

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Replacement MCP server list. Full replacement: the provided array becomes
    /// the MCP servers. Send an empty array to clear; omit to preserve the agent's servers.
    /// </summary>
    public IReadOnlyList<Agents::BetaManagedAgentsUrlMcpServerParams>? McpServers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<Agents::BetaManagedAgentsUrlMcpServerParams>
            >("mcp_servers");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("mcp_servers");
                return;
            }

            this._rawData.Set<ImmutableArray<Agents::BetaManagedAgentsUrlMcpServerParams>?>(
                "mcp_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Replacement model. Accepts the model string, e.g. `claude-opus-5-5`, or a
    /// `model_config` object. Omit to use the agent's model.
    /// </summary>
    public Model? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Model>("model");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("model");
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Replacement skill list. Full replacement: the provided array becomes the
    /// skills. Send an empty array to clear; omit to preserve the agent's skills.
    /// </summary>
    public IReadOnlyList<Agents::BetaManagedAgentsSkillParams>? Skills
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<Agents::BetaManagedAgentsSkillParams>
            >("skills");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("skills");
                return;
            }

            this._rawData.Set<ImmutableArray<Agents::BetaManagedAgentsSkillParams>?>(
                "skills",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Replacement system prompt. Up to 100,000 characters. Set to null to clear
    /// the agent's system prompt; omit to preserve it.
    /// </summary>
    public string? System
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system");
        }
        init { this._rawData.Set("system", value); }
    }

    /// <summary>
    /// Replacement tool list. Full replacement: the provided array becomes the tool
    /// configuration. Send an empty array to clear; omit to preserve the agent's tools.
    /// </summary>
    public IReadOnlyList<Tool>? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tool>>("tools");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("tools");
                return;
            }

            this._rawData.Set<ImmutableArray<Tool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The specific `agent` version to use. Omit to use the latest version.
    /// </summary>
    public int? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("version");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("version");
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("agent_with_overrides")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.McpServers ?? [])
        {
            item.Validate();
        }
        this.Model?.Validate();
        foreach (var item in this.Skills ?? [])
        {
            item.Validate();
        }
        _ = this.System;
        foreach (var item in this.Tools ?? [])
        {
            item.Validate();
        }
        _ = this.Version;
    }

    public BetaManagedAgentsAgentWithOverridesParams()
    {
        this.Type = JsonSerializer.SerializeToElement("agent_with_overrides");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentWithOverridesParams(
        BetaManagedAgentsAgentWithOverridesParams betaManagedAgentsAgentWithOverridesParams
    )
        : base(betaManagedAgentsAgentWithOverridesParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentWithOverridesParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent_with_overrides");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentWithOverridesParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentWithOverridesParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentWithOverridesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentWithOverridesParams(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsAgentWithOverridesParamsFromRaw
    : IFromRawJson<BetaManagedAgentsAgentWithOverridesParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentWithOverridesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentWithOverridesParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Replacement model. Accepts the model string, e.g. `claude-opus-5-5`, or a `model_config`
/// object. Omit to use the agent's model.
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public record class Model : ModelBase
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

    public Model(ApiEnum<string, Agents::BetaManagedAgentsModel> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(Agents::BetaManagedAgentsModelConfigParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of Agents::BetaManagedAgentsModel.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgents(out var value)) {
    ///     // `value` is of type `ApiEnum&lt;string, Agents::BetaManagedAgentsModel&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgents(
        [NotNullWhen(true)] out ApiEnum<string, Agents::BetaManagedAgentsModel>? value
    )
    {
        value = this.Value as ApiEnum<string, Agents::BetaManagedAgentsModel>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsModelConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsModelConfigParams(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsModelConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsModelConfigParams(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsModelConfigParams? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsModelConfigParams;
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
    ///     (ApiEnum&lt;string, Agents::BetaManagedAgentsModel&gt; value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsModelConfigParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ApiEnum<string, Agents::BetaManagedAgentsModel>> betaManagedAgents,
        Action<Agents::BetaManagedAgentsModelConfigParams> betaManagedAgentsModelConfigParams
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, Agents::BetaManagedAgentsModel> value:
                betaManagedAgents(value);
                break;
            case Agents::BetaManagedAgentsModelConfigParams value:
                betaManagedAgentsModelConfigParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Model");
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
    ///     (ApiEnum&lt;string, Agents::BetaManagedAgentsModel&gt; value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsModelConfigParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ApiEnum<string, Agents::BetaManagedAgentsModel>, T> betaManagedAgents,
        Func<Agents::BetaManagedAgentsModelConfigParams, T> betaManagedAgentsModelConfigParams
    )
    {
        return this.Value switch
        {
            ApiEnum<string, Agents::BetaManagedAgentsModel> value => betaManagedAgents(value),
            Agents::BetaManagedAgentsModelConfigParams value => betaManagedAgentsModelConfigParams(
                value
            ),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Model"),
        };
    }

    public static implicit operator Model(ApiEnum<string, Agents::BetaManagedAgentsModel> value) =>
        new((ApiEnum<string, Agents::BetaManagedAgentsModel>)value);

    public static implicit operator Model(Agents::BetaManagedAgentsModel value) =>
        new((ApiEnum<string, Agents::BetaManagedAgentsModel>)value);

    public static implicit operator Model(Agents::BetaManagedAgentsModelConfigParams value) =>
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Model");
        }
        this.Switch(
            (betaManagedAgents) => betaManagedAgents.Raw(),
            (betaManagedAgentsModelConfigParams) => betaManagedAgentsModelConfigParams.Validate()
        );
    }

    public virtual bool Equals(Model? other) =>
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
            ApiEnum<string, Agents::BetaManagedAgentsModel> _ => 0,
            Agents::BetaManagedAgentsModelConfigParams _ => 1,
            _ => -1,
        };
    }
}

sealed class ModelConverter : JsonConverter<Model>
{
    public override Model? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, Agents::BetaManagedAgentsModel>
            >(element, options);
            if (deserialized != null)
            {
                deserialized.Raw();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<Agents::BetaManagedAgentsModelConfigParams>(
                    element,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Model value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Union type for tool configurations in the tools array.
/// </summary>
[JsonConverter(typeof(ToolConverter))]
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

    public ApiEnum<string, ToolType> Type
    {
        get
        {
            return this.Value switch
            {
                Agents::BetaManagedAgentsAgentToolset20260401Params _ =>
                    ToolType.AgentToolset20260401,
                Agents::BetaManagedAgentsMcpToolsetParams _ => ToolType.McpToolset,
                Agents::BetaManagedAgentsCustomToolParams _ => ToolType.Custom,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ApiEnum<string, ToolType>>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public Tool(
        Agents::BetaManagedAgentsAgentToolset20260401Params value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(Agents::BetaManagedAgentsMcpToolsetParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(Agents::BetaManagedAgentsCustomToolParams value, JsonElement? element = null)
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
    /// type <see cref="Agents::BetaManagedAgentsAgentToolset20260401Params"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAgentToolset20260401Params(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsAgentToolset20260401Params`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAgentToolset20260401Params(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsAgentToolset20260401Params? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsAgentToolset20260401Params;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsMcpToolsetParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpToolsetParams(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsMcpToolsetParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpToolsetParams(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsMcpToolsetParams? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsMcpToolsetParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsCustomToolParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsCustomToolParams(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsCustomToolParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsCustomToolParams(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsCustomToolParams? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsCustomToolParams;
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
    ///     (Agents::BetaManagedAgentsAgentToolset20260401Params value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMcpToolsetParams value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsCustomToolParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Agents::BetaManagedAgentsAgentToolset20260401Params> betaManagedAgentsAgentToolset20260401Params,
        Action<Agents::BetaManagedAgentsMcpToolsetParams> betaManagedAgentsMcpToolsetParams,
        Action<Agents::BetaManagedAgentsCustomToolParams> betaManagedAgentsCustomToolParams
    )
    {
        switch (this.Value)
        {
            case Agents::BetaManagedAgentsAgentToolset20260401Params value:
                betaManagedAgentsAgentToolset20260401Params(value);
                break;
            case Agents::BetaManagedAgentsMcpToolsetParams value:
                betaManagedAgentsMcpToolsetParams(value);
                break;
            case Agents::BetaManagedAgentsCustomToolParams value:
                betaManagedAgentsCustomToolParams(value);
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
    ///     (Agents::BetaManagedAgentsAgentToolset20260401Params value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMcpToolsetParams value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsCustomToolParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<
            Agents::BetaManagedAgentsAgentToolset20260401Params,
            T
        > betaManagedAgentsAgentToolset20260401Params,
        Func<Agents::BetaManagedAgentsMcpToolsetParams, T> betaManagedAgentsMcpToolsetParams,
        Func<Agents::BetaManagedAgentsCustomToolParams, T> betaManagedAgentsCustomToolParams
    )
    {
        return this.Value switch
        {
            Agents::BetaManagedAgentsAgentToolset20260401Params value =>
                betaManagedAgentsAgentToolset20260401Params(value),
            Agents::BetaManagedAgentsMcpToolsetParams value => betaManagedAgentsMcpToolsetParams(
                value
            ),
            Agents::BetaManagedAgentsCustomToolParams value => betaManagedAgentsCustomToolParams(
                value
            ),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Tool"),
        };
    }

    public static implicit operator Tool(
        Agents::BetaManagedAgentsAgentToolset20260401Params value
    ) => new(value);

    public static implicit operator Tool(Agents::BetaManagedAgentsMcpToolsetParams value) =>
        new(value);

    public static implicit operator Tool(Agents::BetaManagedAgentsCustomToolParams value) =>
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
        }
        this.Switch(
            (betaManagedAgentsAgentToolset20260401Params) =>
                betaManagedAgentsAgentToolset20260401Params.Validate(),
            (betaManagedAgentsMcpToolsetParams) => betaManagedAgentsMcpToolsetParams.Validate(),
            (betaManagedAgentsCustomToolParams) => betaManagedAgentsCustomToolParams.Validate()
        );
    }

    public virtual bool Equals(Tool? other) =>
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
            Agents::BetaManagedAgentsAgentToolset20260401Params _ => 0,
            Agents::BetaManagedAgentsMcpToolsetParams _ => 1,
            Agents::BetaManagedAgentsCustomToolParams _ => 2,
            _ => -1,
        };
    }
}

sealed class ToolConverter : JsonConverter<Tool>
{
    public override Tool? Read(
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
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsAgentToolset20260401Params>(
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
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsMcpToolsetParams>(
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
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsCustomToolParams>(
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
                return new Tool(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Tool value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ToolTypeConverter))]
public enum ToolType
{
    AgentToolset20260401,
    McpToolset,
    Custom,
}

sealed class ToolTypeConverter : JsonConverter<ToolType>
{
    public override ToolType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent_toolset_20260401" => ToolType.AgentToolset20260401,
            "mcp_toolset" => ToolType.McpToolset,
            "custom" => ToolType.Custom,
            _ => (ToolType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, ToolType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolType.AgentToolset20260401 => "agent_toolset_20260401",
                ToolType.McpToolset => "mcp_toolset",
                ToolType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
