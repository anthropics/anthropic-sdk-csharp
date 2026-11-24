using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// A Cloud Storage bucket, named by the project that holds it and by its own name.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedBucketReference,
        BetaGoogleManagedBucketReferenceFromRaw
    >)
)]
public sealed record class BetaGoogleManagedBucketReference : JsonModel
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

    public BetaGoogleManagedBucketReference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedBucketReference(
        BetaGoogleManagedBucketReference betaGoogleManagedBucketReference
    )
        : base(betaGoogleManagedBucketReference) { }
#pragma warning restore CS8618

    public BetaGoogleManagedBucketReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedBucketReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedBucketReferenceFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedBucketReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedBucketReferenceFromRaw : IFromRawJson<BetaGoogleManagedBucketReference>
{
    /// <inheritdoc/>
    public BetaGoogleManagedBucketReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedBucketReference.FromRawUnchecked(rawData);
}
