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

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Update an existing environment's configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EnvironmentUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EnvironmentID { get; init; }

    /// <summary>
    /// Updated environment configuration
    /// </summary>
    public EnvironmentUpdateParamsConfig? Config
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EnvironmentUpdateParamsConfig>("config");
        }
        init { this._rawBodyData.Set("config", value); }
    }

    /// <summary>
    /// Updated description of the environment
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
    /// User-provided metadata key-value pairs. Set a value to null or empty string
    /// to delete the key.
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
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Updated name for the environment
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// The visibility scope for this environment. 'organization' makes the environment
    /// visible to all accounts. 'account' restricts visibility to the owning account only.
    /// </summary>
    public ApiEnum<string, EnvironmentUpdateParamsScope>? Scope
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, EnvironmentUpdateParamsScope>
            >("scope");
        }
        init { this._rawBodyData.Set("scope", value); }
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

    public EnvironmentUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnvironmentUpdateParams(EnvironmentUpdateParams environmentUpdateParams)
        : base(environmentUpdateParams)
    {
        this.EnvironmentID = environmentUpdateParams.EnvironmentID;

        this._rawBodyData = new(environmentUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EnvironmentUpdateParams(
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
    EnvironmentUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string environmentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.EnvironmentID = environmentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EnvironmentUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string environmentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            environmentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["EnvironmentID"] = JsonSerializer.SerializeToElement(this.EnvironmentID),
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

    public virtual bool Equals(EnvironmentUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EnvironmentID?.Equals(other.EnvironmentID) ?? other.EnvironmentID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/environments/{0}", this.EnvironmentID)
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
        EnvironmentService.AddDefaultHeaders(request);
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
/// Updated environment configuration
/// </summary>
[JsonConverter(typeof(EnvironmentUpdateParamsConfigConverter))]
public record class EnvironmentUpdateParamsConfig : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return Match(
                betaCloudConfigParams: (x) => x.Type,
                betaSelfHostedConfigParams: (x) => x.Type
            );
        }
    }

    public EnvironmentUpdateParamsConfig(BetaCloudConfigParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EnvironmentUpdateParamsConfig(
        BetaSelfHostedConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EnvironmentUpdateParamsConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCloudConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCloudConfigParams(out var value)) {
    ///     // `value` is of type `BetaCloudConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCloudConfigParams([NotNullWhen(true)] out BetaCloudConfigParams? value)
    {
        value = this.Value as BetaCloudConfigParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSelfHostedConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSelfHostedConfigParams(out var value)) {
    ///     // `value` is of type `BetaSelfHostedConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSelfHostedConfigParams(
        [NotNullWhen(true)] out BetaSelfHostedConfigParams? value
    )
    {
        value = this.Value as BetaSelfHostedConfigParams;
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
    ///     (BetaCloudConfigParams value) =&gt; {...},
    ///     (BetaSelfHostedConfigParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaCloudConfigParams> betaCloudConfigParams,
        System::Action<BetaSelfHostedConfigParams> betaSelfHostedConfigParams
    )
    {
        switch (this.Value)
        {
            case BetaCloudConfigParams value:
                betaCloudConfigParams(value);
                break;
            case BetaSelfHostedConfigParams value:
                betaSelfHostedConfigParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of EnvironmentUpdateParamsConfig"
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
    ///     (BetaCloudConfigParams value) =&gt; {...},
    ///     (BetaSelfHostedConfigParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaCloudConfigParams, T> betaCloudConfigParams,
        System::Func<BetaSelfHostedConfigParams, T> betaSelfHostedConfigParams
    )
    {
        return this.Value switch
        {
            BetaCloudConfigParams value => betaCloudConfigParams(value),
            BetaSelfHostedConfigParams value => betaSelfHostedConfigParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of EnvironmentUpdateParamsConfig"
            ),
        };
    }

    public static implicit operator EnvironmentUpdateParamsConfig(BetaCloudConfigParams value) =>
        new(value);

    public static implicit operator EnvironmentUpdateParamsConfig(
        BetaSelfHostedConfigParams value
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
                "Data did not match any variant of EnvironmentUpdateParamsConfig"
            );
        }
        this.Switch(
            (betaCloudConfigParams) => betaCloudConfigParams.Validate(),
            (betaSelfHostedConfigParams) => betaSelfHostedConfigParams.Validate()
        );
    }

    public virtual bool Equals(EnvironmentUpdateParamsConfig? other) =>
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
            BetaCloudConfigParams _ => 0,
            BetaSelfHostedConfigParams _ => 1,
            _ => -1,
        };
    }
}

sealed class EnvironmentUpdateParamsConfigConverter : JsonConverter<EnvironmentUpdateParamsConfig?>
{
    public override EnvironmentUpdateParamsConfig? Read(
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
            case "cloud":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCloudConfigParams>(
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
            case "self_hosted":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSelfHostedConfigParams>(
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
                return new EnvironmentUpdateParamsConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        EnvironmentUpdateParamsConfig? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// The visibility scope for this environment. 'organization' makes the environment
/// visible to all accounts. 'account' restricts visibility to the owning account only.
/// </summary>
[JsonConverter(typeof(EnvironmentUpdateParamsScopeConverter))]
public enum EnvironmentUpdateParamsScope
{
    Organization,
    Account,
}

sealed class EnvironmentUpdateParamsScopeConverter : JsonConverter<EnvironmentUpdateParamsScope>
{
    public override EnvironmentUpdateParamsScope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization" => EnvironmentUpdateParamsScope.Organization,
            "account" => EnvironmentUpdateParamsScope.Account,
            _ => (EnvironmentUpdateParamsScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EnvironmentUpdateParamsScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EnvironmentUpdateParamsScope.Organization => "organization",
                EnvironmentUpdateParamsScope.Account => "account",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
