using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// A bucket that a region has retired. Until `expires_at`, keep the bucket and Anthropic's
/// access to it as they were when the bucket passed verification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedRetiredBucket,
        BetaGoogleManagedRetiredBucketFromRaw
    >)
)]
public sealed record class BetaGoogleManagedRetiredBucket : JsonModel
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
    /// When this entry is removed, in RFC 3339 format.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
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

    /// <summary>
    /// The code of the region that retired the bucket.
    /// </summary>
    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BucketName;
        _ = this.ExpiresAt;
        _ = this.ProjectNumber;
        _ = this.Region;
    }

    public BetaGoogleManagedRetiredBucket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedRetiredBucket(
        BetaGoogleManagedRetiredBucket betaGoogleManagedRetiredBucket
    )
        : base(betaGoogleManagedRetiredBucket) { }
#pragma warning restore CS8618

    public BetaGoogleManagedRetiredBucket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedRetiredBucket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedRetiredBucketFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedRetiredBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedRetiredBucketFromRaw : IFromRawJson<BetaGoogleManagedRetiredBucket>
{
    /// <inheritdoc/>
    public BetaGoogleManagedRetiredBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedRetiredBucket.FromRawUnchecked(rawData);
}
