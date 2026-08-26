using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Federation.Issuers;

/// <summary>
/// Registered external OIDC identity provider.
///
/// <para>Records an external IdP the organization trusts for the RFC 7523 jwt-bearer
/// grant. The `issuer_url` must match the JWT `iss` claim exactly.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaFederationIssuer, BetaFederationIssuerFromRaw>))]
public sealed record class BetaFederationIssuer : JsonModel
{
    /// <summary>
    /// Tagged ID of the federation issuer.
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

    /// <summary>
    /// If set, all rules referencing this issuer reject token exchange.
    /// </summary>
    public required DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// Tagged ID (`user_`/`svac_`) of the actor that archived this issuer.
    /// </summary>
    public required string? ArchivedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("archived_by_actor_id");
        }
        init { this._rawData.Set("archived_by_actor_id", value); }
    }

    /// <summary>
    /// Whether the jwt-bearer exchange enforces JTI single-use (replay protection)
    /// for tokens from this issuer. Applies only to assertions carrying a `jti` claim;
    /// tokens without one are accepted without single-use enforcement.
    /// </summary>
    public required bool CheckJti
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("check_jti");
        }
        init { this._rawData.Set("check_jti", value); }
    }

    /// <summary>
    /// When this issuer was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Tagged ID (`user_`/`svac_`) of the actor that created this issuer.
    /// </summary>
    public required string? CreatedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_by_actor_id");
        }
        init { this._rawData.Set("created_by_actor_id", value); }
    }

    /// <summary>
    /// The `iss` claim value. Incoming JWTs must match exactly.
    /// </summary>
    public required string IssuerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("issuer_url");
        }
        init { this._rawData.Set("issuer_url", value); }
    }

    /// <summary>
    /// How signing keys are obtained for signature verification.
    /// </summary>
    public required BetaFederationIssuerJwks Jwks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaFederationIssuerJwks>("jwks");
        }
        init { this._rawData.Set("jwks", value); }
    }

    /// <summary>
    /// If set, Anthropic's JWKS poller has paused polling for this issuer after
    /// repeated fetch failures. Re-enable by sending `jwks_polling_disabled: false`
    /// via the issuer update endpoint (POST) once the upstream JWKS endpoint is
    /// fixed. An OAuth caller cannot send this when the issuer backs a rule with
    /// any scope other than `workspace:developer` or `workspace:inference`; use
    /// a Console session.
    /// </summary>
    public required DateTimeOffset? JwksPollingDisabledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("jwks_polling_disabled_at");
        }
        init { this._rawData.Set("jwks_polling_disabled_at", value); }
    }

    /// <summary>
    /// Maximum allowed iat→exp spread for assertions from this issuer (1-176400
    /// seconds, i.e. up to 49h). Assertions must carry both `iat` and `exp`; a missing
    /// `iat` is rejected.
    /// </summary>
    public required long MaxJwtLifetimeSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("max_jwt_lifetime_seconds");
        }
        init { this._rawData.Set("max_jwt_lifetime_seconds", value); }
    }

    /// <summary>
    /// Admin-chosen slug identifier.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Status of automatic JWKS polling for a federation issuer.
    ///
    /// <para>Anthropic periodically fetches the issuer's signing keys in the background.
    /// These fields summarize the most recent fetches so the health of the JWKS endpoint
    /// can be monitored.</para>
    /// </summary>
    public required BetaFederationIssuerPollStatus? PollStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaFederationIssuerPollStatus>("poll_status");
        }
        init { this._rawData.Set("poll_status", value); }
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
    /// When this issuer was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Tagged ID (`user_`/`svac_`) of the actor that last updated this issuer.
    /// </summary>
    public required string? UpdatedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_by_actor_id");
        }
        init { this._rawData.Set("updated_by_actor_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.ArchivedByActorID;
        _ = this.CheckJti;
        _ = this.CreatedAt;
        _ = this.CreatedByActorID;
        _ = this.IssuerUrl;
        this.Jwks.Validate();
        _ = this.JwksPollingDisabledAt;
        _ = this.MaxJwtLifetimeSeconds;
        _ = this.Name;
        this.PollStatus?.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("federation_issuer")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        _ = this.UpdatedByActorID;
    }

    public BetaFederationIssuer()
    {
        this.Type = JsonSerializer.SerializeToElement("federation_issuer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFederationIssuer(BetaFederationIssuer betaFederationIssuer)
        : base(betaFederationIssuer) { }
#pragma warning restore CS8618

    public BetaFederationIssuer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("federation_issuer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFederationIssuer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFederationIssuerFromRaw.FromRawUnchecked"/>
    public static BetaFederationIssuer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaFederationIssuerFromRaw : IFromRawJson<BetaFederationIssuer>
{
    /// <inheritdoc/>
    public BetaFederationIssuer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFederationIssuer.FromRawUnchecked(rawData);
}

/// <summary>
/// How signing keys are obtained for signature verification.
/// </summary>
[JsonConverter(typeof(BetaFederationIssuerJwksConverter))]
public record class BetaFederationIssuerJwks : ModelBase
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

    public BetaFederationIssuerJwks(BetaJwksDiscovery value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaFederationIssuerJwks(BetaJwksExplicitUrl value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaFederationIssuerJwks(BetaJwksInline value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaFederationIssuerJwks(JsonElement element)
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
                    "Data did not match any variant of BetaFederationIssuerJwks"
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
                "Data did not match any variant of BetaFederationIssuerJwks"
            ),
        };
    }

    public static implicit operator BetaFederationIssuerJwks(BetaJwksDiscovery value) => new(value);

    public static implicit operator BetaFederationIssuerJwks(BetaJwksExplicitUrl value) =>
        new(value);

    public static implicit operator BetaFederationIssuerJwks(BetaJwksInline value) => new(value);

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
                "Data did not match any variant of BetaFederationIssuerJwks"
            );
        }
        this.Switch(
            (betaJwksDiscovery) => betaJwksDiscovery.Validate(),
            (betaJwksExplicitUrl) => betaJwksExplicitUrl.Validate(),
            (betaJwksInline) => betaJwksInline.Validate()
        );
    }

    public virtual bool Equals(BetaFederationIssuerJwks? other) =>
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

sealed class BetaFederationIssuerJwksConverter : JsonConverter<BetaFederationIssuerJwks>
{
    public override BetaFederationIssuerJwks? Read(
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
                return new BetaFederationIssuerJwks(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaFederationIssuerJwks value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
