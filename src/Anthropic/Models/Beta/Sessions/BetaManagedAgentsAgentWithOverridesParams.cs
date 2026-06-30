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

    public required ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Replacement MCP server list. Full replacement: the provided array becomes
    /// the MCP servers. Send an empty array to clear; omit to preserve the agent's servers.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsUrlMcpServerParams>? McpServers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<BetaManagedAgentsUrlMcpServerParams>
            >("mcp_servers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsUrlMcpServerParams>?>(
                "mcp_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Replacement model. Accepts the model string, e.g. `claude-opus-4-6`, or a
    /// `model_config` object. Omit to use the agent's model.
    /// </summary>
    public global::Anthropic.Models.Beta.Sessions.Model? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Anthropic.Models.Beta.Sessions.Model>(
                "model"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Replacement skill list. Full replacement: the provided array becomes the
    /// skills. Send an empty array to clear; omit to preserve the agent's skills.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsSkillParams>? Skills
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsSkillParams>>(
                "skills"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsSkillParams>?>(
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
    public IReadOnlyList<global::Anthropic.Models.Beta.Sessions.Tool>? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::Anthropic.Models.Beta.Sessions.Tool>
            >("tools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::Anthropic.Models.Beta.Sessions.Tool>?>(
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
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
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

    public BetaManagedAgentsAgentWithOverridesParams() { }

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
}

class BetaManagedAgentsAgentWithOverridesParamsFromRaw
    : IFromRawJson<BetaManagedAgentsAgentWithOverridesParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentWithOverridesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentWithOverridesParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAgentWithOverridesParamsTypeConverter))]
public enum BetaManagedAgentsAgentWithOverridesParamsType
{
    AgentWithOverrides,
}

sealed class BetaManagedAgentsAgentWithOverridesParamsTypeConverter
    : JsonConverter<BetaManagedAgentsAgentWithOverridesParamsType>
{
    public override BetaManagedAgentsAgentWithOverridesParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent_with_overrides" =>
                BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            _ => (BetaManagedAgentsAgentWithOverridesParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentWithOverridesParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides =>
                    "agent_with_overrides",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Replacement model. Accepts the model string, e.g. `claude-opus-4-6`, or a `model_config`
/// object. Omit to use the agent's model.
/// </summary>
[JsonConverter(typeof(global::Anthropic.Models.Beta.Sessions.ModelConverter))]
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

    public Model(ApiEnum<string, BetaManagedAgentsModel> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(BetaManagedAgentsModelConfigParams value, JsonElement? element = null)
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
    /// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of BetaManagedAgentsModel>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgents(out var value)) {
    ///     // `value` is of type `ApiEnum&lt;string, BetaManagedAgentsModel&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgents(
        [NotNullWhen(true)] out ApiEnum<string, BetaManagedAgentsModel>? value
    )
    {
        value = this.Value as ApiEnum<string, BetaManagedAgentsModel>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsModelConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsModelConfigParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsModelConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsModelConfigParams(
        [NotNullWhen(true)] out BetaManagedAgentsModelConfigParams? value
    )
    {
        value = this.Value as BetaManagedAgentsModelConfigParams;
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
    ///     (ApiEnum&lt;string, BetaManagedAgentsModel&gt; value) =&gt; {...},
    ///     (BetaManagedAgentsModelConfigParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ApiEnum<string, BetaManagedAgentsModel>> betaManagedAgents,
        System::Action<BetaManagedAgentsModelConfigParams> betaManagedAgentsModelConfigParams
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, BetaManagedAgentsModel> value:
                betaManagedAgents(value);
                break;
            case BetaManagedAgentsModelConfigParams value:
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
    ///     (ApiEnum&lt;string, BetaManagedAgentsModel&gt; value) =&gt; {...},
    ///     (BetaManagedAgentsModelConfigParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ApiEnum<string, BetaManagedAgentsModel>, T> betaManagedAgents,
        System::Func<BetaManagedAgentsModelConfigParams, T> betaManagedAgentsModelConfigParams
    )
    {
        return this.Value switch
        {
            ApiEnum<string, BetaManagedAgentsModel> value => betaManagedAgents(value),
            BetaManagedAgentsModelConfigParams value => betaManagedAgentsModelConfigParams(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Model"),
        };
    }

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Model(
        ApiEnum<string, BetaManagedAgentsModel> value
    ) => new((ApiEnum<string, BetaManagedAgentsModel>)value);

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Model(
        BetaManagedAgentsModel value
    ) => new((ApiEnum<string, BetaManagedAgentsModel>)value);

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Model(
        BetaManagedAgentsModelConfigParams value
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Model");
        }
        this.Switch(
            (betaManagedAgents) => betaManagedAgents.Raw(),
            (betaManagedAgentsModelConfigParams) => betaManagedAgentsModelConfigParams.Validate()
        );
    }

    public virtual bool Equals(global::Anthropic.Models.Beta.Sessions.Model? other) =>
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
            ApiEnum<string, BetaManagedAgentsModel> _ => 0,
            BetaManagedAgentsModelConfigParams _ => 1,
            _ => -1,
        };
    }
}

sealed class ModelConverter : JsonConverter<global::Anthropic.Models.Beta.Sessions.Model>
{
    public override global::Anthropic.Models.Beta.Sessions.Model? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsModel>>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Raw();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParams>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Sessions.Model value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Union type for tool configurations in the tools array.
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

    public Tool(BetaManagedAgentsAgentToolset20260401Params value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaManagedAgentsMcpToolsetParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaManagedAgentsCustomToolParams value, JsonElement? element = null)
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
    /// type <see cref="BetaManagedAgentsAgentToolset20260401Params"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAgentToolset20260401Params(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentToolset20260401Params`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAgentToolset20260401Params(
        [NotNullWhen(true)] out BetaManagedAgentsAgentToolset20260401Params? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentToolset20260401Params;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMcpToolsetParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpToolsetParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMcpToolsetParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpToolsetParams(
        [NotNullWhen(true)] out BetaManagedAgentsMcpToolsetParams? value
    )
    {
        value = this.Value as BetaManagedAgentsMcpToolsetParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsCustomToolParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsCustomToolParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsCustomToolParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsCustomToolParams(
        [NotNullWhen(true)] out BetaManagedAgentsCustomToolParams? value
    )
    {
        value = this.Value as BetaManagedAgentsCustomToolParams;
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
    ///     (BetaManagedAgentsAgentToolset20260401Params value) =&gt; {...},
    ///     (BetaManagedAgentsMcpToolsetParams value) =&gt; {...},
    ///     (BetaManagedAgentsCustomToolParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAgentToolset20260401Params> betaManagedAgentsAgentToolset20260401Params,
        System::Action<BetaManagedAgentsMcpToolsetParams> betaManagedAgentsMcpToolsetParams,
        System::Action<BetaManagedAgentsCustomToolParams> betaManagedAgentsCustomToolParams
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAgentToolset20260401Params value:
                betaManagedAgentsAgentToolset20260401Params(value);
                break;
            case BetaManagedAgentsMcpToolsetParams value:
                betaManagedAgentsMcpToolsetParams(value);
                break;
            case BetaManagedAgentsCustomToolParams value:
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
    ///     (BetaManagedAgentsAgentToolset20260401Params value) =&gt; {...},
    ///     (BetaManagedAgentsMcpToolsetParams value) =&gt; {...},
    ///     (BetaManagedAgentsCustomToolParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsAgentToolset20260401Params,
            T
        > betaManagedAgentsAgentToolset20260401Params,
        System::Func<BetaManagedAgentsMcpToolsetParams, T> betaManagedAgentsMcpToolsetParams,
        System::Func<BetaManagedAgentsCustomToolParams, T> betaManagedAgentsCustomToolParams
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAgentToolset20260401Params value =>
                betaManagedAgentsAgentToolset20260401Params(value),
            BetaManagedAgentsMcpToolsetParams value => betaManagedAgentsMcpToolsetParams(value),
            BetaManagedAgentsCustomToolParams value => betaManagedAgentsCustomToolParams(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Tool"),
        };
    }

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Tool(
        BetaManagedAgentsAgentToolset20260401Params value
    ) => new(value);

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Tool(
        BetaManagedAgentsMcpToolsetParams value
    ) => new(value);

    public static implicit operator global::Anthropic.Models.Beta.Sessions.Tool(
        BetaManagedAgentsCustomToolParams value
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
            (betaManagedAgentsAgentToolset20260401Params) =>
                betaManagedAgentsAgentToolset20260401Params.Validate(),
            (betaManagedAgentsMcpToolsetParams) => betaManagedAgentsMcpToolsetParams.Validate(),
            (betaManagedAgentsCustomToolParams) => betaManagedAgentsCustomToolParams.Validate()
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
            BetaManagedAgentsAgentToolset20260401Params _ => 0,
            BetaManagedAgentsMcpToolsetParams _ => 1,
            BetaManagedAgentsCustomToolParams _ => 2,
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
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401Params>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMcpToolsetParams>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsCustomToolParams>(
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
