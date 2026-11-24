using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// A Cloud Storage bucket, named by the project that holds it and by its own name.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectEffectiveBucket,
        BetaGoogleManagedProjectEffectiveBucketFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectEffectiveBucket : JsonModel
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
        _ = this.ProjectNumber;
    }

    public BetaGoogleManagedProjectEffectiveBucket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectEffectiveBucket(
        BetaGoogleManagedProjectEffectiveBucket betaGoogleManagedProjectEffectiveBucket
    )
        : base(betaGoogleManagedProjectEffectiveBucket) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectEffectiveBucket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectEffectiveBucket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectEffectiveBucketFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectEffectiveBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectEffectiveBucketFromRaw
    : IFromRawJson<BetaGoogleManagedProjectEffectiveBucket>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectEffectiveBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectEffectiveBucket.FromRawUnchecked(rawData);
}
