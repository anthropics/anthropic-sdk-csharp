using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// Anthropic has withdrawn or paused its approval of customer-owned storage for this
/// profile, so the region does not apply the control.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageRegionSuspended,
        BetaGoogleManagedStorageRegionSuspendedFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageRegionSuspended : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("suspended")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedStorageRegionSuspended()
    {
        this.Type = JsonSerializer.SerializeToElement("suspended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageRegionSuspended(
        BetaGoogleManagedStorageRegionSuspended betaGoogleManagedStorageRegionSuspended
    )
        : base(betaGoogleManagedStorageRegionSuspended) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageRegionSuspended(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("suspended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageRegionSuspended(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageRegionSuspendedFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageRegionSuspended FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedStorageRegionSuspended(
        BetaGoogleManagedBucketReference? effectiveBucket
    )
        : this()
    {
        this.EffectiveBucket = effectiveBucket;
    }
}

class BetaGoogleManagedStorageRegionSuspendedFromRaw
    : IFromRawJson<BetaGoogleManagedStorageRegionSuspended>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageRegionSuspended FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageRegionSuspended.FromRawUnchecked(rawData);
}
