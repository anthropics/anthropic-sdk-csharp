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
/// The region stopped retrying verification before the configured bucket passed.
/// To restart verification, send the region a bucket again. It can be the same bucket.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectStorageRegionFailed,
        BetaGoogleManagedProjectStorageRegionFailedFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectStorageRegionFailed : JsonModel
{
    /// <summary>
    /// The bucket that the region applies now. While a replacement bucket is `pending`
    /// or `failed`, this is the previous bucket. `null` when the region applies no bucket.
    /// </summary>
    public required BetaGoogleManagedProjectEffectiveBucket? EffectiveBucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaGoogleManagedProjectEffectiveBucket>(
                "effective_bucket"
            );
        }
        init { this._rawData.Set("effective_bucket", value); }
    }

    /// <summary>
    /// The checks that the last reported verification attempt failed.
    /// </summary>
    public required IReadOnlyList<BetaGoogleManagedProjectStorageFailedCheck> FailedChecks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaGoogleManagedProjectStorageFailedCheck>
            >("failed_checks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaGoogleManagedProjectStorageFailedCheck>>(
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

    public BetaGoogleManagedProjectStorageRegionFailed()
    {
        this.Type = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageRegionFailed(
        BetaGoogleManagedProjectStorageRegionFailed betaGoogleManagedProjectStorageRegionFailed
    )
        : base(betaGoogleManagedProjectStorageRegionFailed) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectStorageRegionFailed(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectStorageRegionFailed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectStorageRegionFailedFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectStorageRegionFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectStorageRegionFailedFromRaw
    : IFromRawJson<BetaGoogleManagedProjectStorageRegionFailed>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectStorageRegionFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectStorageRegionFailed.FromRawUnchecked(rawData);
}
