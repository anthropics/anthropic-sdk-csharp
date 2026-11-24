using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// One flagged message of a review case.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewTranscript,
        BetaComplianceReviewTranscriptFromRaw
    >)
)]
public sealed record class BetaComplianceReviewTranscript : JsonModel
{
    /// <summary>
    /// The ID of the flagged message.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The ID of the user profile that the message belongs to. Null when the message
    /// belongs to none, or when the profile can no longer be looked up.
    /// </summary>
    public required string? UserProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_profile_id");
        }
        init { this._rawData.Set("user_profile_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ItemID;
        _ = this.UserProfileID;
    }

    public BetaComplianceReviewTranscript() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewTranscript(
        BetaComplianceReviewTranscript betaComplianceReviewTranscript
    )
        : base(betaComplianceReviewTranscript) { }
#pragma warning restore CS8618

    public BetaComplianceReviewTranscript(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewTranscript(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewTranscriptFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewTranscript FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewTranscriptFromRaw : IFromRawJson<BetaComplianceReviewTranscript>
{
    /// <inheritdoc/>
    public BetaComplianceReviewTranscript FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewTranscript.FromRawUnchecked(rawData);
}
