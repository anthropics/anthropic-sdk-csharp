using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// A key that a region has retired. Keep the key usable until `expires_at`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaGoogleManagedRetiredKey, BetaGoogleManagedRetiredKeyFromRaw>)
)]
public sealed record class BetaGoogleManagedRetiredKey : JsonModel
{
    /// <summary>
    /// When this entry is removed, in RFC 3339 format.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// The ID of the retired External Key (`ekey_...`).
    /// </summary>
    public required string ExternalKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("external_key_id");
        }
        init { this._rawData.Set("external_key_id", value); }
    }

    /// <summary>
    /// The code of the region that retired the key.
    /// </summary>
    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpiresAt;
        _ = this.ExternalKeyID;
        _ = this.Region;
    }

    public BetaGoogleManagedRetiredKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedRetiredKey(BetaGoogleManagedRetiredKey betaGoogleManagedRetiredKey)
        : base(betaGoogleManagedRetiredKey) { }
#pragma warning restore CS8618

    public BetaGoogleManagedRetiredKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedRetiredKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedRetiredKeyFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedRetiredKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedRetiredKeyFromRaw : IFromRawJson<BetaGoogleManagedRetiredKey>
{
    /// <inheritdoc/>
    public BetaGoogleManagedRetiredKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedRetiredKey.FromRawUnchecked(rawData);
}
