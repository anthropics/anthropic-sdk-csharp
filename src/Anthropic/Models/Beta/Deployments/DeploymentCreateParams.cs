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
using Sessions = Anthropic.Models.Beta.Sessions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// Create Deployment
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DeploymentCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Agent to deploy. Accepts the `agent` ID string, which pins the latest version,
    /// or an `agent` object with both id and version specified. The agent must exist
    /// and not be archived.
    /// </summary>
    public required Agent Agent
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Agent>("agent");
        }
        init { this._rawBodyData.Set("agent", value); }
    }

    /// <summary>
    /// ID of the `environment` defining the container configuration for sessions
    /// created from this deployment.
    /// </summary>
    public required string EnvironmentID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("environment_id");
        }
        init { this._rawBodyData.Set("environment_id", value); }
    }

    /// <summary>
    /// Events to send to each session immediately after creation. At least 1, maximum 50.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsDeploymentInitialEventParams> InitialEvents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsDeploymentInitialEventParams>
            >("initial_events");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<BetaManagedAgentsDeploymentInitialEventParams>>(
                "initial_events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Human-readable name for the deployment.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Description of what the deployment does.
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
    /// Arbitrary key-value metadata. Maximum 16 pairs, keys up to 64 chars, values
    /// up to 512 chars.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Resources (e.g. repositories, files) to mount into each session's container.
    /// Maximum 500.
    /// </summary>
    public IReadOnlyList<Resource>? Resources
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Resource>>("resources");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Resource>?>(
                "resources",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// 5-field POSIX cron schedule. Literal wall-clock matching in the configured timezone.
    /// </summary>
    public BetaManagedAgentsScheduleParams? Schedule
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaManagedAgentsScheduleParams>("schedule");
        }
        init { this._rawBodyData.Set("schedule", value); }
    }

    /// <summary>
    /// Vault IDs for stored credentials the agent can use during sessions created
    /// from this deployment. Maximum 50.
    /// </summary>
    public IReadOnlyList<string>? VaultIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("vault_ids");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "vault_ids",
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

    public DeploymentCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeploymentCreateParams(DeploymentCreateParams deploymentCreateParams)
        : base(deploymentCreateParams)
    {
        this._rawBodyData = new(deploymentCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DeploymentCreateParams(
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
    DeploymentCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DeploymentCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(DeploymentCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/deployments")
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
        DeploymentService.AddDefaultHeaders(request);
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
/// Agent to deploy. Accepts the `agent` ID string, which pins the latest version,
/// or an `agent` object with both id and version specified. The agent must exist
/// and not be archived.
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

    public Agent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Agent(Sessions::BetaManagedAgentsAgentParams value, JsonElement? element = null)
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
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Sessions::BetaManagedAgentsAgentParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAgentParams(out var value)) {
    ///     // `value` is of type `Sessions::BetaManagedAgentsAgentParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAgentParams(
        [NotNullWhen(true)] out Sessions::BetaManagedAgentsAgentParams? value
    )
    {
        value = this.Value as Sessions::BetaManagedAgentsAgentParams;
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
    ///     (string value) =&gt; {...},
    ///     (Sessions::BetaManagedAgentsAgentParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Sessions::BetaManagedAgentsAgentParams> betaManagedAgentsAgentParams
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Sessions::BetaManagedAgentsAgentParams value:
                betaManagedAgentsAgentParams(value);
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
    ///     (string value) =&gt; {...},
    ///     (Sessions::BetaManagedAgentsAgentParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<Sessions::BetaManagedAgentsAgentParams, T> betaManagedAgentsAgentParams
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            Sessions::BetaManagedAgentsAgentParams value => betaManagedAgentsAgentParams(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Agent"),
        };
    }

    public static implicit operator Agent(string value) => new(value);

    public static implicit operator Agent(Sessions::BetaManagedAgentsAgentParams value) =>
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Agent");
        }
        this.Switch(
            (_) => { },
            (betaManagedAgentsAgentParams) => betaManagedAgentsAgentParams.Validate()
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
            string _ => 0,
            Sessions::BetaManagedAgentsAgentParams _ => 1,
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
        try
        {
            var deserialized = JsonSerializer.Deserialize<Sessions::BetaManagedAgentsAgentParams>(
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Agent value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Union of resources that can be mounted into a session.
/// </summary>
[JsonConverter(typeof(ResourceConverter))]
public record class Resource : ModelBase
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

    public string? MountPath
    {
        get
        {
            return Match<string?>(
                betaManagedAgentsGitHubRepositoryResourceParams: (x) => x.MountPath,
                betaManagedAgentsFileResourceParams: (x) => x.MountPath,
                betaManagedAgentsMemoryStoreResourceParam: (_) => null
            );
        }
    }

    public Resource(
        Sessions::BetaManagedAgentsGitHubRepositoryResourceParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(
        Sessions::BetaManagedAgentsFileResourceParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(
        Sessions::BetaManagedAgentsMemoryStoreResourceParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Sessions::BetaManagedAgentsGitHubRepositoryResourceParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsGitHubRepositoryResourceParams(out var value)) {
    ///     // `value` is of type `Sessions::BetaManagedAgentsGitHubRepositoryResourceParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsGitHubRepositoryResourceParams(
        [NotNullWhen(true)] out Sessions::BetaManagedAgentsGitHubRepositoryResourceParams? value
    )
    {
        value = this.Value as Sessions::BetaManagedAgentsGitHubRepositoryResourceParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Sessions::BetaManagedAgentsFileResourceParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsFileResourceParams(out var value)) {
    ///     // `value` is of type `Sessions::BetaManagedAgentsFileResourceParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsFileResourceParams(
        [NotNullWhen(true)] out Sessions::BetaManagedAgentsFileResourceParams? value
    )
    {
        value = this.Value as Sessions::BetaManagedAgentsFileResourceParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Sessions::BetaManagedAgentsMemoryStoreResourceParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMemoryStoreResourceParam(out var value)) {
    ///     // `value` is of type `Sessions::BetaManagedAgentsMemoryStoreResourceParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMemoryStoreResourceParam(
        [NotNullWhen(true)] out Sessions::BetaManagedAgentsMemoryStoreResourceParam? value
    )
    {
        value = this.Value as Sessions::BetaManagedAgentsMemoryStoreResourceParam;
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
    ///     (Sessions::BetaManagedAgentsGitHubRepositoryResourceParams value) =&gt; {...},
    ///     (Sessions::BetaManagedAgentsFileResourceParams value) =&gt; {...},
    ///     (Sessions::BetaManagedAgentsMemoryStoreResourceParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Sessions::BetaManagedAgentsGitHubRepositoryResourceParams> betaManagedAgentsGitHubRepositoryResourceParams,
        System::Action<Sessions::BetaManagedAgentsFileResourceParams> betaManagedAgentsFileResourceParams,
        System::Action<Sessions::BetaManagedAgentsMemoryStoreResourceParam> betaManagedAgentsMemoryStoreResourceParam
    )
    {
        switch (this.Value)
        {
            case Sessions::BetaManagedAgentsGitHubRepositoryResourceParams value:
                betaManagedAgentsGitHubRepositoryResourceParams(value);
                break;
            case Sessions::BetaManagedAgentsFileResourceParams value:
                betaManagedAgentsFileResourceParams(value);
                break;
            case Sessions::BetaManagedAgentsMemoryStoreResourceParam value:
                betaManagedAgentsMemoryStoreResourceParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Resource"
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
    ///     (Sessions::BetaManagedAgentsGitHubRepositoryResourceParams value) =&gt; {...},
    ///     (Sessions::BetaManagedAgentsFileResourceParams value) =&gt; {...},
    ///     (Sessions::BetaManagedAgentsMemoryStoreResourceParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            Sessions::BetaManagedAgentsGitHubRepositoryResourceParams,
            T
        > betaManagedAgentsGitHubRepositoryResourceParams,
        System::Func<
            Sessions::BetaManagedAgentsFileResourceParams,
            T
        > betaManagedAgentsFileResourceParams,
        System::Func<
            Sessions::BetaManagedAgentsMemoryStoreResourceParam,
            T
        > betaManagedAgentsMemoryStoreResourceParam
    )
    {
        return this.Value switch
        {
            Sessions::BetaManagedAgentsGitHubRepositoryResourceParams value =>
                betaManagedAgentsGitHubRepositoryResourceParams(value),
            Sessions::BetaManagedAgentsFileResourceParams value =>
                betaManagedAgentsFileResourceParams(value),
            Sessions::BetaManagedAgentsMemoryStoreResourceParam value =>
                betaManagedAgentsMemoryStoreResourceParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Resource"
            ),
        };
    }

    public static implicit operator Resource(
        Sessions::BetaManagedAgentsGitHubRepositoryResourceParams value
    ) => new(value);

    public static implicit operator Resource(Sessions::BetaManagedAgentsFileResourceParams value) =>
        new(value);

    public static implicit operator Resource(
        Sessions::BetaManagedAgentsMemoryStoreResourceParam value
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Resource");
        }
        this.Switch(
            (betaManagedAgentsGitHubRepositoryResourceParams) =>
                betaManagedAgentsGitHubRepositoryResourceParams.Validate(),
            (betaManagedAgentsFileResourceParams) => betaManagedAgentsFileResourceParams.Validate(),
            (betaManagedAgentsMemoryStoreResourceParam) =>
                betaManagedAgentsMemoryStoreResourceParam.Validate()
        );
    }

    public virtual bool Equals(Resource? other) =>
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
            Sessions::BetaManagedAgentsGitHubRepositoryResourceParams _ => 0,
            Sessions::BetaManagedAgentsFileResourceParams _ => 1,
            Sessions::BetaManagedAgentsMemoryStoreResourceParam _ => 2,
            _ => -1,
        };
    }
}

sealed class ResourceConverter : JsonConverter<Resource>
{
    public override Resource? Read(
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
            case "github_repository":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Sessions::BetaManagedAgentsGitHubRepositoryResourceParams>(
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
            case "file":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Sessions::BetaManagedAgentsFileResourceParams>(
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
            case "memory_store":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Sessions::BetaManagedAgentsMemoryStoreResourceParam>(
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
                return new Resource(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Resource value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
