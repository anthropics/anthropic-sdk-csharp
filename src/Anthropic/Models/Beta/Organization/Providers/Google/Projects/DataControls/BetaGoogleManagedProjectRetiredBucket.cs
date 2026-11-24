using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// A bucket that a region has retired. Until `expires_at`, keep the bucket and Anthropic's
/// access to it as they were when the bucket passed verification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectRetiredBucket,
        BetaGoogleManagedProjectRetiredBucketFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectRetiredBucket : JsonModel
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

    public BetaGoogleManagedProjectRetiredBucket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectRetiredBucket(
        BetaGoogleManagedProjectRetiredBucket betaGoogleManagedProjectRetiredBucket
    )
        : base(betaGoogleManagedProjectRetiredBucket) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectRetiredBucket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectRetiredBucket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectRetiredBucketFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectRetiredBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectRetiredBucketFromRaw
    : IFromRawJson<BetaGoogleManagedProjectRetiredBucket>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectRetiredBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectRetiredBucket.FromRawUnchecked(rawData);
}
