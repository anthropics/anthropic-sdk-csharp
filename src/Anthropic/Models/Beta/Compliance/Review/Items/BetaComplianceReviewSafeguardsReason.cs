using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// Anthropic flagged the item for your organization to review.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewSafeguardsReason,
        BetaComplianceReviewSafeguardsReasonFromRaw
    >)
)]
public sealed record class BetaComplianceReviewSafeguardsReason : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("safeguards_review")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewSafeguardsReason()
    {
        this.Type = JsonSerializer.SerializeToElement("safeguards_review");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewSafeguardsReason(
        BetaComplianceReviewSafeguardsReason betaComplianceReviewSafeguardsReason
    )
        : base(betaComplianceReviewSafeguardsReason) { }
#pragma warning restore CS8618

    public BetaComplianceReviewSafeguardsReason(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("safeguards_review");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewSafeguardsReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewSafeguardsReasonFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewSafeguardsReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewSafeguardsReasonFromRaw
    : IFromRawJson<BetaComplianceReviewSafeguardsReason>
{
    /// <inheritdoc/>
    public BetaComplianceReviewSafeguardsReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewSafeguardsReason.FromRawUnchecked(rawData);
}
