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
        BetaGoogleManagedProjectBucketReference,
        BetaGoogleManagedProjectBucketReferenceFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectBucketReference : JsonModel
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

    public BetaGoogleManagedProjectBucketReference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectBucketReference(
        BetaGoogleManagedProjectBucketReference betaGoogleManagedProjectBucketReference
    )
        : base(betaGoogleManagedProjectBucketReference) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectBucketReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectBucketReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectBucketReferenceFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectBucketReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectBucketReferenceFromRaw
    : IFromRawJson<BetaGoogleManagedProjectBucketReference>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectBucketReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectBucketReference.FromRawUnchecked(rawData);
}
