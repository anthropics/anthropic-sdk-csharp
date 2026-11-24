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
/// The region is verifying the configured bucket.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectStorageRegionPending,
        BetaGoogleManagedProjectStorageRegionPendingFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectStorageRegionPending : JsonModel
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
    /// The checks that the latest reported verification attempt failed. Empty when
    /// none has failed.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("pending")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedProjectStorageRegionPending()
    {
        this.Type = JsonSerializer.SerializeToElement("pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageRegionPending(
        BetaGoogleManagedProjectStorageRegionPending betaGoogleManagedProjectStorageRegionPending
    )
        : base(betaGoogleManagedProjectStorageRegionPending) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectStorageRegionPending(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectStorageRegionPending(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectStorageRegionPendingFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectStorageRegionPending FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectStorageRegionPendingFromRaw
    : IFromRawJson<BetaGoogleManagedProjectStorageRegionPending>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectStorageRegionPending FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectStorageRegionPending.FromRawUnchecked(rawData);
}
