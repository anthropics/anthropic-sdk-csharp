using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// In an organization managed through AWS or Google Cloud, the request would leave
/// the Workspace with `inference_data_privacy.human_review` disabled and `inference_data_privacy.transcripts_storage`
/// not set to External Storage. With human review disabled, the organization reviews
/// its own flagged requests, and it receives them only in that storage.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTranscriptsStorageRequiredErrorDetails,
        BetaTranscriptsStorageRequiredErrorDetailsFromRaw
    >)
)]
public sealed record class BetaTranscriptsStorageRequiredErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("transcripts_storage_required")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTranscriptsStorageRequiredErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("transcripts_storage_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTranscriptsStorageRequiredErrorDetails(
        BetaTranscriptsStorageRequiredErrorDetails betaTranscriptsStorageRequiredErrorDetails
    )
        : base(betaTranscriptsStorageRequiredErrorDetails) { }
#pragma warning restore CS8618

    public BetaTranscriptsStorageRequiredErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("transcripts_storage_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTranscriptsStorageRequiredErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTranscriptsStorageRequiredErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaTranscriptsStorageRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTranscriptsStorageRequiredErrorDetailsFromRaw
    : IFromRawJson<BetaTranscriptsStorageRequiredErrorDetails>
{
    /// <inheritdoc/>
    public BetaTranscriptsStorageRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTranscriptsStorageRequiredErrorDetails.FromRawUnchecked(rawData);
}
