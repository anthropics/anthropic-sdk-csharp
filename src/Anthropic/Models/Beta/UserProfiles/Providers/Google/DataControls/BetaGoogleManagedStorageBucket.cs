using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// The bucket configured for a region.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageBucket,
        BetaGoogleManagedStorageBucketFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageBucket : JsonModel
{
    /// <summary>
    /// The bucket's Cloud Storage name.
    /// </summary>
    public required string BucketName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucket_name");
        }
        init { this._rawData.Set("bucket_name", value); }
    }

    /// <summary>
    /// The resource name of the Cloud KMS key that the bucket encrypts objects under
    /// by default. `null` until the region has confirmed the bucket, and when the
    /// bucket has no default key.
    /// </summary>
    public required string? KmsKeyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("kms_key_name");
        }
        init { this._rawData.Set("kms_key_name", value); }
    }

    /// <summary>
    /// The bucket's location, as Cloud Storage reports it. `null` until the region
    /// has confirmed the bucket.
    /// </summary>
    public required string? Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("location");
        }
        init { this._rawData.Set("location", value); }
    }

    /// <summary>
    /// The ID of the project that holds the bucket. `null` until the region has
    /// confirmed the bucket.
    /// </summary>
    public required string? ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    /// <summary>
    /// The number of the Google Cloud project that holds the bucket, in decimal.
    /// </summary>
    public required string ProjectNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_number");
        }
        init { this._rawData.Set("project_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BucketName;
        _ = this.KmsKeyName;
        _ = this.Location;
        _ = this.ProjectID;
        _ = this.ProjectNumber;
    }

    public BetaGoogleManagedStorageBucket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageBucket(
        BetaGoogleManagedStorageBucket betaGoogleManagedStorageBucket
    )
        : base(betaGoogleManagedStorageBucket) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageBucket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageBucket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageBucketFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedStorageBucketFromRaw : IFromRawJson<BetaGoogleManagedStorageBucket>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageBucket.FromRawUnchecked(rawData);
}
