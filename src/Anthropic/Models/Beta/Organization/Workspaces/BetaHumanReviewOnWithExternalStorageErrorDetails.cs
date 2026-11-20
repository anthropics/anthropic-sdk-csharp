using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// The request would leave the Workspace with `inference_data_privacy.safeguards_storage`
/// set to External Storage and `inference_data_privacy.human_review` enabled. Anthropic
/// doesn't offer human review of data in a customer's own storage. Set `human_review`
/// to `disabled`, or `safeguards_storage` to `internal`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaHumanReviewOnWithExternalStorageErrorDetails,
        BetaHumanReviewOnWithExternalStorageErrorDetailsFromRaw
    >)
)]
public sealed record class BetaHumanReviewOnWithExternalStorageErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("human_review_on_with_external_storage")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaHumanReviewOnWithExternalStorageErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("human_review_on_with_external_storage");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaHumanReviewOnWithExternalStorageErrorDetails(
        BetaHumanReviewOnWithExternalStorageErrorDetails betaHumanReviewOnWithExternalStorageErrorDetails
    )
        : base(betaHumanReviewOnWithExternalStorageErrorDetails) { }
#pragma warning restore CS8618

    public BetaHumanReviewOnWithExternalStorageErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("human_review_on_with_external_storage");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaHumanReviewOnWithExternalStorageErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaHumanReviewOnWithExternalStorageErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaHumanReviewOnWithExternalStorageErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaHumanReviewOnWithExternalStorageErrorDetailsFromRaw
    : IFromRawJson<BetaHumanReviewOnWithExternalStorageErrorDetails>
{
    /// <inheritdoc/>
    public BetaHumanReviewOnWithExternalStorageErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaHumanReviewOnWithExternalStorageErrorDetails.FromRawUnchecked(rawData);
}
