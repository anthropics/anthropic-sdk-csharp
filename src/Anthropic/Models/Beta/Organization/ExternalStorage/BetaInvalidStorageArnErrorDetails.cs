using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// On Claude Platform on AWS, the External Storage ID in the request is neither
/// a bucket ARN nor an `estrg_` ID, or is the `estrg_` ID of AWS storage. Name AWS
/// storage by its bucket ARN, `arn:&lt;partition&gt;:s3:::&lt;bucket_name&gt;`, which
/// responses return as its `id`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaInvalidStorageArnErrorDetails,
        BetaInvalidStorageArnErrorDetailsFromRaw
    >)
)]
public sealed record class BetaInvalidStorageArnErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("invalid_storage_arn")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaInvalidStorageArnErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("invalid_storage_arn");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaInvalidStorageArnErrorDetails(
        BetaInvalidStorageArnErrorDetails betaInvalidStorageArnErrorDetails
    )
        : base(betaInvalidStorageArnErrorDetails) { }
#pragma warning restore CS8618

    public BetaInvalidStorageArnErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("invalid_storage_arn");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInvalidStorageArnErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInvalidStorageArnErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaInvalidStorageArnErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaInvalidStorageArnErrorDetailsFromRaw : IFromRawJson<BetaInvalidStorageArnErrorDetails>
{
    /// <inheritdoc/>
    public BetaInvalidStorageArnErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInvalidStorageArnErrorDetails.FromRawUnchecked(rawData);
}
