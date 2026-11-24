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
/// The region stopped retrying verification before the configured bucket passed.
/// To restart verification, send the region a bucket again. It can be the same bucket.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageRegionFailed,
        BetaGoogleManagedStorageRegionFailedFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageRegionFailed : JsonModel
{
    /// <summary>
    /// The bucket that the region applies now. While a replacement bucket is `pending`
    /// or `failed`, this is the previous bucket. `null` when the region applies no bucket.
    /// </summary>
    public required BetaGoogleManagedBucketReference? EffectiveBucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaGoogleManagedBucketReference>(
                "effective_bucket"
            );
        }
        init { this._rawData.Set("effective_bucket", value); }
    }

    /// <summary>
    /// The checks that the last reported verification attempt failed.
    /// </summary>
    public required IReadOnlyList<BetaGoogleManagedStorageFailedCheck> FailedChecks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaGoogleManagedStorageFailedCheck>
            >("failed_checks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaGoogleManagedStorageFailedCheck>>(
                "failed_checks",
                ImmutableArray.ToImmutableArray(value)
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
        this.EffectiveBucket?.Validate();
        foreach (var item in this.FailedChecks)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("failed")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedStorageRegionFailed()
    {
        this.Type = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageRegionFailed(
        BetaGoogleManagedStorageRegionFailed betaGoogleManagedStorageRegionFailed
    )
        : base(betaGoogleManagedStorageRegionFailed) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageRegionFailed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageRegionFailed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageRegionFailedFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageRegionFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedStorageRegionFailedFromRaw
    : IFromRawJson<BetaGoogleManagedStorageRegionFailed>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageRegionFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageRegionFailed.FromRawUnchecked(rawData);
}
