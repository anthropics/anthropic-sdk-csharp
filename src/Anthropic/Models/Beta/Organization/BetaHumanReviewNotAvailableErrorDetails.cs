using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// Human review can't be set as requested on this Workspace, so the request changed
/// nothing. The error's `message` says what to do instead.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaHumanReviewNotAvailableErrorDetails,
        BetaHumanReviewNotAvailableErrorDetailsFromRaw
    >)
)]
public sealed record class BetaHumanReviewNotAvailableErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("human_review_not_available")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaHumanReviewNotAvailableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("human_review_not_available");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaHumanReviewNotAvailableErrorDetails(
        BetaHumanReviewNotAvailableErrorDetails betaHumanReviewNotAvailableErrorDetails
    )
        : base(betaHumanReviewNotAvailableErrorDetails) { }
#pragma warning restore CS8618

    public BetaHumanReviewNotAvailableErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("human_review_not_available");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaHumanReviewNotAvailableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaHumanReviewNotAvailableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaHumanReviewNotAvailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaHumanReviewNotAvailableErrorDetailsFromRaw
    : IFromRawJson<BetaHumanReviewNotAvailableErrorDetails>
{
    /// <inheritdoc/>
    public BetaHumanReviewNotAvailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaHumanReviewNotAvailableErrorDetails.FromRawUnchecked(rawData);
}
