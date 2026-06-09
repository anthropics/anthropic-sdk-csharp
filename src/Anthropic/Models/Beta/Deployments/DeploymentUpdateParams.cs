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
using Anthropic.Models.Beta.Sessions;
using Anthropic.Services.Beta;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// Update Deployment
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DeploymentUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DeploymentID { get; init; }

    /// <summary>
    /// Agent to deploy. Accepts the `agent` ID string, which re-pins to the latest
    /// version, or an `agent` object with both id and version specified. Omit to
    /// preserve. Cannot be cleared.
    /// </summary>
    public DeploymentUpdateParamsAgent? Agent
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DeploymentUpdateParamsAgent>("agent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("agent", value);
        }
    }

    /// <summary>
    /// Description. Omit to preserve; send empty string or null to clear.
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
    /// ID of the `environment` where sessions run. Omit to preserve. Cannot be cleared.
    /// </summary>
    public string? EnvironmentID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("environment_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("environment_id", value);
        }
    }

    /// <summary>
    /// Initial events. Full replacement. Omit to preserve. Cannot be cleared. At
    /// least 1, maximum 50.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsDeploymentInitialEventParams>? InitialEvents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<BetaManagedAgentsDeploymentInitialEventParams>
            >("initial_events");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<BetaManagedAgentsDeploymentInitialEventParams>?>(
                "initial_events",
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
    /// Human-readable name. Must be non-empty. Omit to preserve. Cannot be cleared.
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
    /// Session resources. Full replacement. Omit to preserve; send empty array or
    /// null to clear. Maximum 500.
    /// </summary>
    public IReadOnlyList<DeploymentUpdateParamsResource>? Resources
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<DeploymentUpdateParamsResource>
            >("resources");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<DeploymentUpdateParamsResource>?>(
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
    /// Vault IDs. Full replacement. Omit to preserve; send empty array or null to
    /// clear. Maximum 50.
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

    public DeploymentUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeploymentUpdateParams(DeploymentUpdateParams deploymentUpdateParams)
        : base(deploymentUpdateParams)
    {
        this.DeploymentID = deploymentUpdateParams.DeploymentID;

        this._rawBodyData = new(deploymentUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DeploymentUpdateParams(
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
    DeploymentUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string deploymentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.DeploymentID = deploymentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DeploymentUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string deploymentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            deploymentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["DeploymentID"] = JsonSerializer.SerializeToElement(this.DeploymentID),
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

    public virtual bool Equals(DeploymentUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.DeploymentID?.Equals(other.DeploymentID) ?? other.DeploymentID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/deployments/{0}", this.DeploymentID)
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
/// Agent to deploy. Accepts the `agent` ID string, which re-pins to the latest version,
/// or an `agent` object with both id and version specified. Omit to preserve. Cannot
/// be cleared.
/// </summary>
[JsonConverter(typeof(DeploymentUpdateParamsAgentConverter))]
public record class DeploymentUpdateParamsAgent : ModelBase
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

    public DeploymentUpdateParamsAgent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DeploymentUpdateParamsAgent(
        BetaManagedAgentsAgentParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DeploymentUpdateParamsAgent(JsonElement element)
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
    /// type <see cref="BetaManagedAgentsAgentParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAgentParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAgentParams(
        [NotNullWhen(true)] out BetaManagedAgentsAgentParams? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentParams;
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
    ///     (BetaManagedAgentsAgentParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<BetaManagedAgentsAgentParams> betaManagedAgentsAgentParams
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case BetaManagedAgentsAgentParams value:
                betaManagedAgentsAgentParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of DeploymentUpdateParamsAgent"
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
    ///     (string value) =&gt; {...},
    ///     (BetaManagedAgentsAgentParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<BetaManagedAgentsAgentParams, T> betaManagedAgentsAgentParams
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            BetaManagedAgentsAgentParams value => betaManagedAgentsAgentParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of DeploymentUpdateParamsAgent"
            ),
        };
    }

    public static implicit operator DeploymentUpdateParamsAgent(string value) => new(value);

    public static implicit operator DeploymentUpdateParamsAgent(
        BetaManagedAgentsAgentParams value
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
                "Data did not match any variant of DeploymentUpdateParamsAgent"
            );
        }
        this.Switch(
            (_) => { },
            (betaManagedAgentsAgentParams) => betaManagedAgentsAgentParams.Validate()
        );
    }

    public virtual bool Equals(DeploymentUpdateParamsAgent? other) =>
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
            BetaManagedAgentsAgentParams _ => 1,
            _ => -1,
        };
    }
}

sealed class DeploymentUpdateParamsAgentConverter : JsonConverter<DeploymentUpdateParamsAgent>
{
    public override DeploymentUpdateParamsAgent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentParams>(
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

    public override void Write(
        Utf8JsonWriter writer,
        DeploymentUpdateParamsAgent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Union of resources that can be mounted into a session.
/// </summary>
[JsonConverter(typeof(DeploymentUpdateParamsResourceConverter))]
public record class DeploymentUpdateParamsResource : ModelBase
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

    public DeploymentUpdateParamsResource(
        BetaManagedAgentsGitHubRepositoryResourceParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DeploymentUpdateParamsResource(
        BetaManagedAgentsFileResourceParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DeploymentUpdateParamsResource(
        BetaManagedAgentsMemoryStoreResourceParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DeploymentUpdateParamsResource(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsGitHubRepositoryResourceParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsGitHubRepositoryResourceParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsGitHubRepositoryResourceParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsGitHubRepositoryResourceParams(
        [NotNullWhen(true)] out BetaManagedAgentsGitHubRepositoryResourceParams? value
    )
    {
        value = this.Value as BetaManagedAgentsGitHubRepositoryResourceParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsFileResourceParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsFileResourceParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsFileResourceParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsFileResourceParams(
        [NotNullWhen(true)] out BetaManagedAgentsFileResourceParams? value
    )
    {
        value = this.Value as BetaManagedAgentsFileResourceParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMemoryStoreResourceParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMemoryStoreResourceParam(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMemoryStoreResourceParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMemoryStoreResourceParam(
        [NotNullWhen(true)] out BetaManagedAgentsMemoryStoreResourceParam? value
    )
    {
        value = this.Value as BetaManagedAgentsMemoryStoreResourceParam;
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
    ///     (BetaManagedAgentsGitHubRepositoryResourceParams value) =&gt; {...},
    ///     (BetaManagedAgentsFileResourceParams value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreResourceParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsGitHubRepositoryResourceParams> betaManagedAgentsGitHubRepositoryResourceParams,
        System::Action<BetaManagedAgentsFileResourceParams> betaManagedAgentsFileResourceParams,
        System::Action<BetaManagedAgentsMemoryStoreResourceParam> betaManagedAgentsMemoryStoreResourceParam
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsGitHubRepositoryResourceParams value:
                betaManagedAgentsGitHubRepositoryResourceParams(value);
                break;
            case BetaManagedAgentsFileResourceParams value:
                betaManagedAgentsFileResourceParams(value);
                break;
            case BetaManagedAgentsMemoryStoreResourceParam value:
                betaManagedAgentsMemoryStoreResourceParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of DeploymentUpdateParamsResource"
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
    ///     (BetaManagedAgentsGitHubRepositoryResourceParams value) =&gt; {...},
    ///     (BetaManagedAgentsFileResourceParams value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreResourceParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsGitHubRepositoryResourceParams,
            T
        > betaManagedAgentsGitHubRepositoryResourceParams,
        System::Func<BetaManagedAgentsFileResourceParams, T> betaManagedAgentsFileResourceParams,
        System::Func<
            BetaManagedAgentsMemoryStoreResourceParam,
            T
        > betaManagedAgentsMemoryStoreResourceParam
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsGitHubRepositoryResourceParams value =>
                betaManagedAgentsGitHubRepositoryResourceParams(value),
            BetaManagedAgentsFileResourceParams value => betaManagedAgentsFileResourceParams(value),
            BetaManagedAgentsMemoryStoreResourceParam value =>
                betaManagedAgentsMemoryStoreResourceParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of DeploymentUpdateParamsResource"
            ),
        };
    }

    public static implicit operator DeploymentUpdateParamsResource(
        BetaManagedAgentsGitHubRepositoryResourceParams value
    ) => new(value);

    public static implicit operator DeploymentUpdateParamsResource(
        BetaManagedAgentsFileResourceParams value
    ) => new(value);

    public static implicit operator DeploymentUpdateParamsResource(
        BetaManagedAgentsMemoryStoreResourceParam value
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
                "Data did not match any variant of DeploymentUpdateParamsResource"
            );
        }
        this.Switch(
            (betaManagedAgentsGitHubRepositoryResourceParams) =>
                betaManagedAgentsGitHubRepositoryResourceParams.Validate(),
            (betaManagedAgentsFileResourceParams) => betaManagedAgentsFileResourceParams.Validate(),
            (betaManagedAgentsMemoryStoreResourceParam) =>
                betaManagedAgentsMemoryStoreResourceParam.Validate()
        );
    }

    public virtual bool Equals(DeploymentUpdateParamsResource? other) =>
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
            BetaManagedAgentsGitHubRepositoryResourceParams _ => 0,
            BetaManagedAgentsFileResourceParams _ => 1,
            BetaManagedAgentsMemoryStoreResourceParam _ => 2,
            _ => -1,
        };
    }
}

sealed class DeploymentUpdateParamsResourceConverter : JsonConverter<DeploymentUpdateParamsResource>
{
    public override DeploymentUpdateParamsResource? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResourceParams>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsFileResourceParams>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreResourceParam>(
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
                return new DeploymentUpdateParamsResource(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeploymentUpdateParamsResource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
