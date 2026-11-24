using System;
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
/// The configured bucket passed verification, and the region applies it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageRegionActive,
        BetaGoogleManagedStorageRegionActiveFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageRegionActive : JsonModel
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
    /// The checks that the latest reported daily verification failed. Empty when
    /// it passed.
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

    /// <summary>
    /// When the status last became `active`, in RFC 3339 format.
    /// </summary>
    public required DateTimeOffset ValidatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("validated_at");
        }
        init { this._rawData.Set("validated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.EffectiveBucket?.Validate();
        foreach (var item in this.FailedChecks)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("active")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ValidatedAt;
    }

    public BetaGoogleManagedStorageRegionActive()
    {
        this.Type = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageRegionActive(
        BetaGoogleManagedStorageRegionActive betaGoogleManagedStorageRegionActive
    )
        : base(betaGoogleManagedStorageRegionActive) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageRegionActive(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageRegionActive(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageRegionActiveFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageRegionActive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedStorageRegionActiveFromRaw
    : IFromRawJson<BetaGoogleManagedStorageRegionActive>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageRegionActive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageRegionActive.FromRawUnchecked(rawData);
}
