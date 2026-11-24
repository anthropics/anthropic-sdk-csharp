using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// Anthropic has withdrawn or paused its approval of customer-managed keys for this
/// project, so the region does not apply the control.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectCmekRegionSuspended,
        BetaGoogleManagedProjectCmekRegionSuspendedFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectCmekRegionSuspended : JsonModel
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

    public BetaGoogleManagedProjectCmekRegionSuspended()
    {
        this.Type = JsonSerializer.SerializeToElement("suspended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekRegionSuspended(
        BetaGoogleManagedProjectCmekRegionSuspended betaGoogleManagedProjectCmekRegionSuspended
    )
        : base(betaGoogleManagedProjectCmekRegionSuspended) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectCmekRegionSuspended(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("suspended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectCmekRegionSuspended(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectCmekRegionSuspendedFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectCmekRegionSuspended FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekRegionSuspended(string? effectiveExternalKeyID)
        : this()
    {
        this.EffectiveExternalKeyID = effectiveExternalKeyID;
    }
}

class BetaGoogleManagedProjectCmekRegionSuspendedFromRaw
    : IFromRawJson<BetaGoogleManagedProjectCmekRegionSuspended>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectCmekRegionSuspended FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectCmekRegionSuspended.FromRawUnchecked(rawData);
}
