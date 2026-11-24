using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// Turns the control on, or changes its buckets while it is on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectStorageEnabledParams,
        BetaGoogleManagedProjectStorageEnabledParamsFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectStorageEnabledParams : JsonModel
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
    public IReadOnlyDictionary<string, BetaGoogleManagedProjectBucketReference?>? Buckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, BetaGoogleManagedProjectBucketReference?>
            >("buckets");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("buckets");
                return;
            }

            this._rawData.Set<FrozenDictionary<string, BetaGoogleManagedProjectBucketReference?>?>(
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

    public BetaGoogleManagedProjectStorageEnabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageEnabledParams(
        BetaGoogleManagedProjectStorageEnabledParams betaGoogleManagedProjectStorageEnabledParams
    )
        : base(betaGoogleManagedProjectStorageEnabledParams) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectStorageEnabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectStorageEnabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectStorageEnabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectStorageEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectStorageEnabledParamsFromRaw
    : IFromRawJson<BetaGoogleManagedProjectStorageEnabledParams>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectStorageEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectStorageEnabledParams.FromRawUnchecked(rawData);
}
