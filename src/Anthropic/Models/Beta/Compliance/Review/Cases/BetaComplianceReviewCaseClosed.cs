using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// Anthropic has stopped waiting for a response. A closed case stays closed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewCaseClosed,
        BetaComplianceReviewCaseClosedFromRaw
    >)
)]
public sealed record class BetaComplianceReviewCaseClosed : JsonModel
{
    /// <summary>
    /// Why the case closed. It doesn't change afterwards.
    /// </summary>
    public required BetaComplianceReviewCaseCloseReason Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaComplianceReviewCaseCloseReason>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

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
        this.Reason.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("closed")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewCaseClosed()
    {
        this.Type = JsonSerializer.SerializeToElement("closed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewCaseClosed(
        BetaComplianceReviewCaseClosed betaComplianceReviewCaseClosed
    )
        : base(betaComplianceReviewCaseClosed) { }
#pragma warning restore CS8618

    public BetaComplianceReviewCaseClosed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("closed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewCaseClosed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewCaseClosedFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewCaseClosed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComplianceReviewCaseClosed(BetaComplianceReviewCaseCloseReason reason)
        : this()
    {
        this.Reason = reason;
    }
}

class BetaComplianceReviewCaseClosedFromRaw : IFromRawJson<BetaComplianceReviewCaseClosed>
{
    /// <inheritdoc/>
    public BetaComplianceReviewCaseClosed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewCaseClosed.FromRawUnchecked(rawData);
}
