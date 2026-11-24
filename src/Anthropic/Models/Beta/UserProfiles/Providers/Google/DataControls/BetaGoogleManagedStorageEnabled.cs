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
/// The control is on and has a bucket for at least one region.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageEnabled,
        BetaGoogleManagedStorageEnabledFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageEnabled : JsonModel
{
    /// <summary>
    /// The bucket configured for each region, keyed by region code. A region with
    /// no bucket is left out.
    /// </summary>
    public required IReadOnlyDictionary<string, BetaGoogleManagedStorageBucket> Buckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                FrozenDictionary<string, BetaGoogleManagedStorageBucket>
            >("buckets");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, BetaGoogleManagedStorageBucket>>(
                "buckets",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Buckets that a region has retired, earliest `expires_at` first.
    /// </summary>
    public required IReadOnlyList<BetaGoogleManagedRetiredBucket> RetiredBuckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaGoogleManagedRetiredBucket>>(
                "retired_buckets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaGoogleManagedRetiredBucket>>(
                "retired_buckets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Each region's status for the control, keyed by region code. A region that
    /// your organization is not offered may have no entry, and Anthropic may add regions.
    /// </summary>
    public required IReadOnlyDictionary<string, BetaGoogleManagedStorageRegionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                FrozenDictionary<string, BetaGoogleManagedStorageRegionStatus>
            >("status");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, BetaGoogleManagedStorageRegionStatus>>(
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
        foreach (var item in this.Buckets.Values)
        {
            item.Validate();
        }
        foreach (var item in this.RetiredBuckets)
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

    public BetaGoogleManagedStorageEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageEnabled(
        BetaGoogleManagedStorageEnabled betaGoogleManagedStorageEnabled
    )
        : base(betaGoogleManagedStorageEnabled) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageEnabledFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedStorageEnabledFromRaw : IFromRawJson<BetaGoogleManagedStorageEnabled>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageEnabled.FromRawUnchecked(rawData);
}
