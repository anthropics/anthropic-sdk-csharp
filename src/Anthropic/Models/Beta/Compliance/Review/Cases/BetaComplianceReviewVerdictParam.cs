using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// Your conclusion on one message of a review case.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewVerdictParam,
        BetaComplianceReviewVerdictParamFromRaw
    >)
)]
public sealed record class BetaComplianceReviewVerdictParam : JsonModel
{
    /// <summary>
    /// Your conclusion on this message.
    /// </summary>
    public required ApiEnum<string, BetaComplianceReviewDetermination> Determination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaComplianceReviewDetermination>
            >("determination");
        }
        init { this._rawData.Set("determination", value); }
    }

    /// <summary>
    /// The `item_id` of one of the case's `transcripts`.
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
    /// The policy category that this message violated, from the values that the
    /// request's `policy_categories` accepts. Optional with `violation`. Leave it
    /// out with `no_violation`.
    /// </summary>
    public ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>? PolicyCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>
            >("policy_category");
        }
        init { this._rawData.Set("policy_category", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Determination.Validate();
        _ = this.ItemID;
        this.PolicyCategory?.Validate();
    }

    public BetaComplianceReviewVerdictParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewVerdictParam(
        BetaComplianceReviewVerdictParam betaComplianceReviewVerdictParam
    )
        : base(betaComplianceReviewVerdictParam) { }
#pragma warning restore CS8618

    public BetaComplianceReviewVerdictParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewVerdictParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewVerdictParamFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewVerdictParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewVerdictParamFromRaw : IFromRawJson<BetaComplianceReviewVerdictParam>
{
    /// <inheritdoc/>
    public BetaComplianceReviewVerdictParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewVerdictParam.FromRawUnchecked(rawData);
}
