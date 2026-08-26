using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Federation.Issuers;

/// <summary>
/// Status of automatic JWKS polling for a federation issuer.
///
/// <para>Anthropic periodically fetches the issuer's signing keys in the background.
/// These fields summarize the most recent fetches so the health of the JWKS endpoint
/// can be monitored.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaFederationIssuerPollStatus,
        BetaFederationIssuerPollStatusFromRaw
    >)
)]
public sealed record class BetaFederationIssuerPollStatus : JsonModel
{
    /// <summary>
    /// Consecutive fetch failures since the last success.
    /// </summary>
    public required long ConsecutiveFailures
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("consecutive_failures");
        }
        init { this._rawData.Set("consecutive_failures", value); }
    }

    /// <summary>
    /// When the last successful fetch completed.
    /// </summary>
    public required DateTimeOffset? LastFetchedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_fetched_at");
        }
        init { this._rawData.Set("last_fetched_at", value); }
    }

    /// <summary>
    /// When the next fetch is scheduled. Null if paused.
    /// </summary>
    public required DateTimeOffset? NextPollAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("next_poll_at");
        }
        init { this._rawData.Set("next_poll_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConsecutiveFailures;
        _ = this.LastFetchedAt;
        _ = this.NextPollAt;
    }

    public BetaFederationIssuerPollStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFederationIssuerPollStatus(
        BetaFederationIssuerPollStatus betaFederationIssuerPollStatus
    )
        : base(betaFederationIssuerPollStatus) { }
#pragma warning restore CS8618

    public BetaFederationIssuerPollStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFederationIssuerPollStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFederationIssuerPollStatusFromRaw.FromRawUnchecked"/>
    public static BetaFederationIssuerPollStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaFederationIssuerPollStatusFromRaw : IFromRawJson<BetaFederationIssuerPollStatus>
{
    /// <inheritdoc/>
    public BetaFederationIssuerPollStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFederationIssuerPollStatus.FromRawUnchecked(rawData);
}
