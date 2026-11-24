using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// The configured key passed validation, and the region applies it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedCmekRegionActive,
        BetaGoogleManagedCmekRegionActiveFromRaw
    >)
)]
public sealed record class BetaGoogleManagedCmekRegionActive : JsonModel
{
    /// <summary>
    /// The ID of the External Key that the region applies now (`ekey_...`). While
    /// a replacement key is `pending` or `failed`, this is the previous key. `null`
    /// when the region applies no key.
    /// </summary>
    public required string? EffectiveExternalKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("effective_external_key_id");
        }
        init { this._rawData.Set("effective_external_key_id", value); }
    }

    /// <summary>
    /// Why Google Cloud KMS refused the region's latest use of the key. `null` when
    /// the region has no refusal to report. A `null` does not mean that the key works.
    /// </summary>
    public required string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// When the region last got a successful answer from Google Cloud KMS for the
    /// key, in RFC 3339 format. `null` when it has none to report.
    /// </summary>
    public required DateTimeOffset? LastCheckedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_checked_at");
        }
        init { this._rawData.Set("last_checked_at", value); }
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
    /// When the status last became `active`, in RFC 3339 format.
    /// </summary>
    public required DateTimeOffset ValidatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("validated_at");
        }
        init { this._rawData.Set("validated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EffectiveExternalKeyID;
        _ = this.Error;
        _ = this.LastCheckedAt;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("active")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ValidatedAt;
    }

    public BetaGoogleManagedCmekRegionActive()
    {
        this.Type = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedCmekRegionActive(
        BetaGoogleManagedCmekRegionActive betaGoogleManagedCmekRegionActive
    )
        : base(betaGoogleManagedCmekRegionActive) { }
#pragma warning restore CS8618

    public BetaGoogleManagedCmekRegionActive(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedCmekRegionActive(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedCmekRegionActiveFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedCmekRegionActive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedCmekRegionActiveFromRaw : IFromRawJson<BetaGoogleManagedCmekRegionActive>
{
    /// <inheritdoc/>
    public BetaGoogleManagedCmekRegionActive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedCmekRegionActive.FromRawUnchecked(rawData);
}
