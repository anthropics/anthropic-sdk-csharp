using System;
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

namespace Anthropic.Models.Beta.Organization.Federation.Issuers;

/// <summary>
/// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
/// login --scope org:admin` or a workload identity federation rule; Admin API keys
/// are not accepted. See [Manage WIF with the Admin API](/docs/en/manage-claude/wif-admin-api).
///
/// <para>Partially update a federation issuer.</para>
///
/// <para>Setting `jwks` replaces the full JWKS shape at once. Archived issuers cannot
/// be updated; this returns 400. Create a new issuer instead.</para>
///
/// <para>Updating an issuer that backs a rule with a scope outside `workspace:developer`
/// or `workspace:inference` requires a Console session.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class IssuerUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? FederationIssuerID { get; init; }

    /// <summary>
    /// Whether the jwt-bearer exchange enforces JTI single-use (replay protection)
    /// for tokens from this issuer. Applies only to assertions carrying a `jti` claim;
    /// tokens without one are accepted without single-use enforcement.
    /// </summary>
    public bool? CheckJti
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("check_jti");
        }
        init { this._rawBodyData.Set("check_jti", value); }
    }

    /// <summary>
    /// Replaces the `iss` claim value to match against. For discovery-mode issuers
    /// without a `discovery_base`, this is also the URL Anthropic fetches the OIDC
    /// discovery document and signing keys from, so changing it repoints the JWKS
    /// source. Changing the issuer URL to a well-known shared platform is rejected
    /// while any live rule under this issuer would not constrain tenant identity.
    /// </summary>
    public string? IssuerUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("issuer_url");
        }
        init { this._rawBodyData.Set("issuer_url", value); }
    }

    /// <summary>
    /// Replaces the entire JWKS configuration.
    /// </summary>
    public IssuerUpdateParamsJwks? Jwks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<IssuerUpdateParamsJwks>("jwks");
        }
        init { this._rawBodyData.Set("jwks", value); }
    }

    /// <summary>
    /// Only `false` is accepted, to re-enable polling after the system pauses it.
    /// Polling is paused automatically; sending `true` is rejected.
    /// </summary>
    public bool? JwksPollingDisabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("jwks_polling_disabled");
        }
        init { this._rawBodyData.Set("jwks_polling_disabled", value); }
    }

    /// <summary>
    /// Maximum allowed iat→exp spread for assertions from this issuer (1-176400
    /// seconds, i.e. up to 49h). Assertions must carry both `iat` and `exp`; a missing
    /// `iat` is rejected.
    /// </summary>
    public long? MaxJwtLifetimeSeconds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_jwt_lifetime_seconds");
        }
        init { this._rawBodyData.Set("max_jwt_lifetime_seconds", value); }
    }

    /// <summary>
    /// Replaces the slug identifier (lowercase, digits, hyphens). Unique within the
    /// organization; a duplicate name returns 409.
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

    public IssuerUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IssuerUpdateParams(IssuerUpdateParams issuerUpdateParams)
        : base(issuerUpdateParams)
    {
        this.FederationIssuerID = issuerUpdateParams.FederationIssuerID;

        this._rawBodyData = new(issuerUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public IssuerUpdateParams(
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
    IssuerUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string federationIssuerID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.FederationIssuerID = federationIssuerID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static IssuerUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string federationIssuerID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            federationIssuerID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["FederationIssuerID"] = JsonSerializer.SerializeToElement(
                        this.FederationIssuerID
                    ),
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

    public virtual bool Equals(IssuerUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.FederationIssuerID?.Equals(other.FederationIssuerID)
                ?? other.FederationIssuerID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/organizations/federation_issuers/{0}", this.FederationIssuerID)
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
/// Replaces the entire JWKS configuration.
/// </summary>
[JsonConverter(typeof(IssuerUpdateParamsJwksConverter))]
public record class IssuerUpdateParamsJwks : ModelBase
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
                betaJwksDiscovery: (x) => x.Type,
                betaJwksExplicitUrl: (x) => x.Type,
                betaJwksInline: (x) => x.Type
            );
        }
    }

    public string? CACertPem
    {
        get
        {
            return Match<string?>(
                betaJwksDiscovery: (x) => x.CACertPem,
                betaJwksExplicitUrl: (x) => x.CACertPem,
                betaJwksInline: (_) => null
            );
        }
    }

    public IssuerUpdateParamsJwks(BetaJwksDiscovery value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IssuerUpdateParamsJwks(BetaJwksExplicitUrl value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IssuerUpdateParamsJwks(BetaJwksInline value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public IssuerUpdateParamsJwks(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaJwksDiscovery"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaJwksDiscovery(out var value)) {
    ///     // `value` is of type `BetaJwksDiscovery`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaJwksDiscovery([NotNullWhen(true)] out BetaJwksDiscovery? value)
    {
        value = this.Value as BetaJwksDiscovery;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaJwksExplicitUrl"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaJwksExplicitUrl(out var value)) {
    ///     // `value` is of type `BetaJwksExplicitUrl`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaJwksExplicitUrl([NotNullWhen(true)] out BetaJwksExplicitUrl? value)
    {
        value = this.Value as BetaJwksExplicitUrl;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaJwksInline"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaJwksInline(out var value)) {
    ///     // `value` is of type `BetaJwksInline`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaJwksInline([NotNullWhen(true)] out BetaJwksInline? value)
    {
        value = this.Value as BetaJwksInline;
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
    ///     (BetaJwksDiscovery value) =&gt; {...},
    ///     (BetaJwksExplicitUrl value) =&gt; {...},
    ///     (BetaJwksInline value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaJwksDiscovery> betaJwksDiscovery,
        Action<BetaJwksExplicitUrl> betaJwksExplicitUrl,
        Action<BetaJwksInline> betaJwksInline
    )
    {
        switch (this.Value)
        {
            case BetaJwksDiscovery value:
                betaJwksDiscovery(value);
                break;
            case BetaJwksExplicitUrl value:
                betaJwksExplicitUrl(value);
                break;
            case BetaJwksInline value:
                betaJwksInline(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of IssuerUpdateParamsJwks"
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
    ///     (BetaJwksDiscovery value) =&gt; {...},
    ///     (BetaJwksExplicitUrl value) =&gt; {...},
    ///     (BetaJwksInline value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaJwksDiscovery, T> betaJwksDiscovery,
        Func<BetaJwksExplicitUrl, T> betaJwksExplicitUrl,
        Func<BetaJwksInline, T> betaJwksInline
    )
    {
        return this.Value switch
        {
            BetaJwksDiscovery value => betaJwksDiscovery(value),
            BetaJwksExplicitUrl value => betaJwksExplicitUrl(value),
            BetaJwksInline value => betaJwksInline(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of IssuerUpdateParamsJwks"
            ),
        };
    }

    public static implicit operator IssuerUpdateParamsJwks(BetaJwksDiscovery value) => new(value);

    public static implicit operator IssuerUpdateParamsJwks(BetaJwksExplicitUrl value) => new(value);

    public static implicit operator IssuerUpdateParamsJwks(BetaJwksInline value) => new(value);

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
                "Data did not match any variant of IssuerUpdateParamsJwks"
            );
        }
        this.Switch(
            (betaJwksDiscovery) => betaJwksDiscovery.Validate(),
            (betaJwksExplicitUrl) => betaJwksExplicitUrl.Validate(),
            (betaJwksInline) => betaJwksInline.Validate()
        );
    }

    public virtual bool Equals(IssuerUpdateParamsJwks? other) =>
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
            BetaJwksDiscovery _ => 0,
            BetaJwksExplicitUrl _ => 1,
            BetaJwksInline _ => 2,
            _ => -1,
        };
    }
}

sealed class IssuerUpdateParamsJwksConverter : JsonConverter<IssuerUpdateParamsJwks?>
{
    public override IssuerUpdateParamsJwks? Read(
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
            case "discovery":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaJwksDiscovery>(
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
            case "explicit_url":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaJwksExplicitUrl>(
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
            case "inline":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaJwksInline>(element, options);
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
                return new IssuerUpdateParamsJwks(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        IssuerUpdateParamsJwks? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
