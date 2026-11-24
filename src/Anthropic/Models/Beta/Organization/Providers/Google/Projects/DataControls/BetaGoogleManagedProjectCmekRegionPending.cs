using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// The region is validating the configured key, or the key has passed validation
/// and the region has not started to apply it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectCmekRegionPending,
        BetaGoogleManagedProjectCmekRegionPendingFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectCmekRegionPending : JsonModel
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
    /// Why the latest validation attempt failed. `null` when no attempt has failed.
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
        _ = this.Error;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("pending")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedProjectCmekRegionPending()
    {
        this.Type = JsonSerializer.SerializeToElement("pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekRegionPending(
        BetaGoogleManagedProjectCmekRegionPending betaGoogleManagedProjectCmekRegionPending
    )
        : base(betaGoogleManagedProjectCmekRegionPending) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectCmekRegionPending(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectCmekRegionPending(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectCmekRegionPendingFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectCmekRegionPending FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectCmekRegionPendingFromRaw
    : IFromRawJson<BetaGoogleManagedProjectCmekRegionPending>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectCmekRegionPending FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectCmekRegionPending.FromRawUnchecked(rawData);
}
