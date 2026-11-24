using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// Anthropic has withdrawn or paused its approval of customer-managed keys for this
/// profile, so the region does not apply the control.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedCmekRegionSuspended,
        BetaGoogleManagedCmekRegionSuspendedFromRaw
    >)
)]
public sealed record class BetaGoogleManagedCmekRegionSuspended : JsonModel
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

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EffectiveExternalKeyID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("suspended")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedCmekRegionSuspended()
    {
        this.Type = JsonSerializer.SerializeToElement("suspended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedCmekRegionSuspended(
        BetaGoogleManagedCmekRegionSuspended betaGoogleManagedCmekRegionSuspended
    )
        : base(betaGoogleManagedCmekRegionSuspended) { }
#pragma warning restore CS8618

    public BetaGoogleManagedCmekRegionSuspended(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("suspended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedCmekRegionSuspended(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedCmekRegionSuspendedFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedCmekRegionSuspended FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedCmekRegionSuspended(string? effectiveExternalKeyID)
        : this()
    {
        this.EffectiveExternalKeyID = effectiveExternalKeyID;
    }
}

class BetaGoogleManagedCmekRegionSuspendedFromRaw
    : IFromRawJson<BetaGoogleManagedCmekRegionSuspended>
{
    /// <inheritdoc/>
    public BetaGoogleManagedCmekRegionSuspended FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedCmekRegionSuspended.FromRawUnchecked(rawData);
}
