using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// Turns the control on, or changes its buckets while it is on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageEnabledParams,
        BetaGoogleManagedStorageEnabledParamsFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageEnabledParams : JsonModel
{
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
    /// The bucket to use in each region, keyed by region code, such as `us` or `eu`.
    /// An object with `project_number` and `bucket_name` sets that region's bucket,
    /// `null` removes it, and a region you leave out keeps its bucket. A bucket
    /// can serve only one region. While the control is on, at least one region must
    /// have a bucket.
    /// </summary>
    public IReadOnlyDictionary<string, BetaGoogleManagedBucketReference?>? Buckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, BetaGoogleManagedBucketReference?>
            >("buckets");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("buckets");
                return;
            }

            this._rawData.Set<FrozenDictionary<string, BetaGoogleManagedBucketReference?>?>(
                "buckets",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (this.Buckets != null)
        {
            foreach (var item in this.Buckets.Values)
            {
                item?.Validate();
            }
        }
    }

    public BetaGoogleManagedStorageEnabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageEnabledParams(
        BetaGoogleManagedStorageEnabledParams betaGoogleManagedStorageEnabledParams
    )
        : base(betaGoogleManagedStorageEnabledParams) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageEnabledParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageEnabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageEnabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedStorageEnabledParamsFromRaw
    : IFromRawJson<BetaGoogleManagedStorageEnabledParams>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageEnabledParams.FromRawUnchecked(rawData);
}
