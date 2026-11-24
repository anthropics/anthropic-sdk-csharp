using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// The control is on and has a key for at least one region.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaGoogleManagedCmekEnabled, BetaGoogleManagedCmekEnabledFromRaw>)
)]
public sealed record class BetaGoogleManagedCmekEnabled : JsonModel
{
    /// <summary>
    /// The ID of the External Key configured for each region (`ekey_...`), keyed
    /// by region code. A region with no key is left out.
    /// </summary>
    public required IReadOnlyDictionary<string, string> ExternalKeyIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>(
                "external_key_ids"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "external_key_ids",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Keys that a region has retired, earliest `expires_at` first.
    /// </summary>
    public required IReadOnlyList<BetaGoogleManagedRetiredKey> RetiredKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaGoogleManagedRetiredKey>>(
                "retired_keys"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaGoogleManagedRetiredKey>>(
                "retired_keys",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Each region's status for the control, keyed by region code. A region that
    /// your organization is not offered may have no entry, and Anthropic may add regions.
    /// </summary>
    public required IReadOnlyDictionary<string, BetaGoogleManagedCmekRegionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                FrozenDictionary<string, BetaGoogleManagedCmekRegionStatus>
            >("status");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, BetaGoogleManagedCmekRegionStatus>>(
                "status",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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
        _ = this.ExternalKeyIds;
        foreach (var item in this.RetiredKeys)
        {
            item.Validate();
        }
        foreach (var item in this.Status.Values)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedCmekEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedCmekEnabled(BetaGoogleManagedCmekEnabled betaGoogleManagedCmekEnabled)
        : base(betaGoogleManagedCmekEnabled) { }
#pragma warning restore CS8618

    public BetaGoogleManagedCmekEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedCmekEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedCmekEnabledFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedCmekEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedCmekEnabledFromRaw : IFromRawJson<BetaGoogleManagedCmekEnabled>
{
    /// <inheritdoc/>
    public BetaGoogleManagedCmekEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedCmekEnabled.FromRawUnchecked(rawData);
}
