using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Update Agent
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AgentUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AgentID { get; init; }

    /// <summary>
    /// The agent's current version, used to prevent concurrent overwrites. Obtain
    /// this value from a create or retrieve response. The request fails if this does
    /// not match the server's current version.
    /// </summary>
    public required int Version
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<int>("version");
        }
        init { this._rawBodyData.Set("version", value); }
    }

    /// <summary>
    /// Description. Up to 2048 characters. Omit to preserve; send empty string or
    /// null to clear.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// MCP servers. Full replacement. Omit to preserve; send empty array or null
    /// to clear. Names must be unique. Maximum 20.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsUrlMcpServerParams>? McpServers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<BetaManagedAgentsUrlMcpServerParams>
            >("mcp_servers");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<BetaManagedAgentsUrlMcpServerParams>?>(
                "mcp_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Metadata patch. Set a key to a string to upsert it, or to null to delete
    /// it. Omit the field to preserve. The stored bag is limited to 16 keys (up to
    /// 64 chars each) with values up to 512 chars.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string?>>(
                "metadata"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Model identifier. Accepts the [model string](https://platform.claude.com/docs/en/about-claude/models/overview#latest-models-comparison),
    /// e.g. `claude-opus-4-6`, or a `model_config` object for additional configuration
    /// control. Omit to preserve. Cannot be cleared.
    /// </summary>
    public AgentUpdateParamsModel? Model
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AgentUpdateParamsModel>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("model", value);
        }
    }

    /// <summary>
    /// Human-readable name. 1-256 characters. Omit to preserve. Cannot be cleared.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// Skills. Full replacement. Omit to preserve; send empty array or null to clear.
    /// Maximum 20.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsSkillParams>? Skills
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<BetaManagedAgentsSkillParams>
            >("skills");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<BetaManagedAgentsSkillParams>?>(
                "skills",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// System prompt. Up to 100,000 characters. Omit to preserve; send empty string
    /// or null to clear.
    /// </summary>
    public string? System
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("system");
        }
        init { this._rawBodyData.Set("system", value); }
    }

    /// <summary>
    /// Tool configurations available to the agent. Full replacement. Omit to preserve;
    /// send empty array or null to clear. Maximum of 128 tools across all toolsets allowed.
    /// </summary>
    public IReadOnlyList<AgentUpdateParamsTool>? Tools
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AgentUpdateParamsTool>>(
                "tools"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<AgentUpdateParamsTool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AgentUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentUpdateParams(AgentUpdateParams agentUpdateParams)
        : base(agentUpdateParams)
    {
        this.AgentID = agentUpdateParams.AgentID;

        this._rawBodyData = new(agentUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AgentUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string agentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AgentID = agentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AgentUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string agentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            agentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AgentID"] = JsonSerializer.SerializeToElement(this.AgentID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(AgentUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AgentID?.Equals(other.AgentID) ?? other.AgentID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/agents/{0}", this.AgentID)
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        AgentService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Model identifier. Accepts the [model string](https://platform.claude.com/docs/en/about-claude/models/overview#latest-models-comparison),
/// e.g. `claude-opus-4-6`, or a `model_config` object for additional configuration
/// control. Omit to preserve. Cannot be cleared.
/// </summary>
[JsonConverter(typeof(AgentUpdateParamsModelConverter))]
public record class AgentUpdateParamsModel : ModelBase
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

    public AgentUpdateParamsModel(
        ApiEnum<string, BetaManagedAgentsModel> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentUpdateParamsModel(
        BetaManagedAgentsModelConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentUpdateParamsModel(JsonElement element)
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
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of AgentUpdateParamsModel"
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
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of AgentUpdateParamsModel"
            ),
        };
    }

    public static implicit operator AgentUpdateParamsModel(
        ApiEnum<string, BetaManagedAgentsModel> value
    ) => new((ApiEnum<string, BetaManagedAgentsModel>)value);

    public static implicit operator AgentUpdateParamsModel(BetaManagedAgentsModel value) =>
        new((ApiEnum<string, BetaManagedAgentsModel>)value);

    public static implicit operator AgentUpdateParamsModel(
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
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of AgentUpdateParamsModel"
            );
        }
        this.Switch(
            (betaManagedAgents) => betaManagedAgents.Raw(),
            (betaManagedAgentsModelConfigParams) => betaManagedAgentsModelConfigParams.Validate()
        );
    }

    public virtual bool Equals(AgentUpdateParamsModel? other) =>
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

sealed class AgentUpdateParamsModelConverter : JsonConverter<AgentUpdateParamsModel>
{
    public override AgentUpdateParamsModel? Read(
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
        AgentUpdateParamsModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Union type for tool configurations in the tools array.
/// </summary>
[JsonConverter(typeof(AgentUpdateParamsToolConverter))]
public record class AgentUpdateParamsTool : ModelBase
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

    public AgentUpdateParamsTool(
        BetaManagedAgentsAgentToolset20260401Params value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentUpdateParamsTool(
        BetaManagedAgentsMcpToolsetParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentUpdateParamsTool(
        BetaManagedAgentsCustomToolParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentUpdateParamsTool(JsonElement element)
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
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of AgentUpdateParamsTool"
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
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of AgentUpdateParamsTool"
            ),
        };
    }

    public static implicit operator AgentUpdateParamsTool(
        BetaManagedAgentsAgentToolset20260401Params value
    ) => new(value);

    public static implicit operator AgentUpdateParamsTool(
        BetaManagedAgentsMcpToolsetParams value
    ) => new(value);

    public static implicit operator AgentUpdateParamsTool(
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
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of AgentUpdateParamsTool"
            );
        }
        this.Switch(
            (betaManagedAgentsAgentToolset20260401Params) =>
                betaManagedAgentsAgentToolset20260401Params.Validate(),
            (betaManagedAgentsMcpToolsetParams) => betaManagedAgentsMcpToolsetParams.Validate(),
            (betaManagedAgentsCustomToolParams) => betaManagedAgentsCustomToolParams.Validate()
        );
    }

    public virtual bool Equals(AgentUpdateParamsTool? other) =>
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

sealed class AgentUpdateParamsToolConverter : JsonConverter<AgentUpdateParamsTool>
{
    public override AgentUpdateParamsTool? Read(
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
                return new AgentUpdateParamsTool(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentUpdateParamsTool value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
