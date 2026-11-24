using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// The region stopped retrying validation before the configured key passed. To restart
/// validation, send the region a key again. It can be the same key.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectCmekRegionFailed,
        BetaGoogleManagedProjectCmekRegionFailedFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectCmekRegionFailed : JsonModel
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
    /// Why the region cannot use the configured key.
    /// </summary>
    public required string Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("error");
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("failed")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedProjectCmekRegionFailed()
    {
        this.Type = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekRegionFailed(
        BetaGoogleManagedProjectCmekRegionFailed betaGoogleManagedProjectCmekRegionFailed
    )
        : base(betaGoogleManagedProjectCmekRegionFailed) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectCmekRegionFailed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectCmekRegionFailed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectCmekRegionFailedFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectCmekRegionFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectCmekRegionFailedFromRaw
    : IFromRawJson<BetaGoogleManagedProjectCmekRegionFailed>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectCmekRegionFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectCmekRegionFailed.FromRawUnchecked(rawData);
}
