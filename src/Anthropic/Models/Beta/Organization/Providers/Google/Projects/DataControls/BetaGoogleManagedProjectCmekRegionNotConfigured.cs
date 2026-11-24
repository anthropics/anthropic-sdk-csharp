using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// No key is set for this region.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectCmekRegionNotConfigured,
        BetaGoogleManagedProjectCmekRegionNotConfiguredFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectCmekRegionNotConfigured : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("not_configured")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedProjectCmekRegionNotConfigured()
    {
        this.Type = JsonSerializer.SerializeToElement("not_configured");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekRegionNotConfigured(
        BetaGoogleManagedProjectCmekRegionNotConfigured betaGoogleManagedProjectCmekRegionNotConfigured
    )
        : base(betaGoogleManagedProjectCmekRegionNotConfigured) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectCmekRegionNotConfigured(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("not_configured");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectCmekRegionNotConfigured(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectCmekRegionNotConfiguredFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectCmekRegionNotConfigured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekRegionNotConfigured(string? effectiveExternalKeyID)
        : this()
    {
        this.EffectiveExternalKeyID = effectiveExternalKeyID;
    }
}

class BetaGoogleManagedProjectCmekRegionNotConfiguredFromRaw
    : IFromRawJson<BetaGoogleManagedProjectCmekRegionNotConfigured>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectCmekRegionNotConfigured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectCmekRegionNotConfigured.FromRawUnchecked(rawData);
}
