using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// Anthropic is waiting for a response to the case.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComplianceReviewCaseOpen, BetaComplianceReviewCaseOpenFromRaw>)
)]
public sealed record class BetaComplianceReviewCaseOpen : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("open")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewCaseOpen()
    {
        this.Type = JsonSerializer.SerializeToElement("open");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewCaseOpen(BetaComplianceReviewCaseOpen betaComplianceReviewCaseOpen)
        : base(betaComplianceReviewCaseOpen) { }
#pragma warning restore CS8618

    public BetaComplianceReviewCaseOpen(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("open");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewCaseOpen(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewCaseOpenFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewCaseOpen FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewCaseOpenFromRaw : IFromRawJson<BetaComplianceReviewCaseOpen>
{
    /// <inheritdoc/>
    public BetaComplianceReviewCaseOpen FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewCaseOpen.FromRawUnchecked(rawData);
}
