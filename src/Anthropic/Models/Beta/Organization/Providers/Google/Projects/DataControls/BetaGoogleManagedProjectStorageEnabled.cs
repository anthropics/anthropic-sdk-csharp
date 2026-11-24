using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// The control is on and has a bucket for at least one region.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectStorageEnabled,
        BetaGoogleManagedProjectStorageEnabledFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectStorageEnabled : JsonModel
{
    /// <summary>
    /// The bucket configured for each region, keyed by region code. A region with
    /// no bucket is left out.
    /// </summary>
    public required IReadOnlyDictionary<string, BetaGoogleManagedProjectStorageBucket> Buckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                FrozenDictionary<string, BetaGoogleManagedProjectStorageBucket>
            >("buckets");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, BetaGoogleManagedProjectStorageBucket>>(
                "buckets",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Buckets that a region has retired, earliest `expires_at` first.
    /// </summary>
    public required IReadOnlyList<BetaGoogleManagedProjectRetiredBucket> RetiredBuckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaGoogleManagedProjectRetiredBucket>
            >("retired_buckets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaGoogleManagedProjectRetiredBucket>>(
                "retired_buckets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Each region's status for the control, keyed by region code. A region that
    /// your organization is not offered may have no entry, and Anthropic may add regions.
    /// </summary>
    public required IReadOnlyDictionary<string, BetaGoogleManagedProjectStorageRegionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                FrozenDictionary<string, BetaGoogleManagedProjectStorageRegionStatus>
            >("status");
        }
        init
        {
            this._rawData.Set<
                FrozenDictionary<string, BetaGoogleManagedProjectStorageRegionStatus>
            >("status", FrozenDictionary.ToFrozenDictionary(value));
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

    public BetaGoogleManagedProjectStorageEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageEnabled(
        BetaGoogleManagedProjectStorageEnabled betaGoogleManagedProjectStorageEnabled
    )
        : base(betaGoogleManagedProjectStorageEnabled) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectStorageEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectStorageEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectStorageEnabledFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectStorageEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectStorageEnabledFromRaw
    : IFromRawJson<BetaGoogleManagedProjectStorageEnabled>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectStorageEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectStorageEnabled.FromRawUnchecked(rawData);
}
