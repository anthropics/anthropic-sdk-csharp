using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// No copy of the message was stored.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewContentNotCaptured,
        BetaComplianceReviewContentNotCapturedFromRaw
    >)
)]
public sealed record class BetaComplianceReviewContentNotCaptured : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("not_captured")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewContentNotCaptured()
    {
        this.Type = JsonSerializer.SerializeToElement("not_captured");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewContentNotCaptured(
        BetaComplianceReviewContentNotCaptured betaComplianceReviewContentNotCaptured
    )
        : base(betaComplianceReviewContentNotCaptured) { }
#pragma warning restore CS8618

    public BetaComplianceReviewContentNotCaptured(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("not_captured");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewContentNotCaptured(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewContentNotCapturedFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewContentNotCaptured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewContentNotCapturedFromRaw
    : IFromRawJson<BetaComplianceReviewContentNotCaptured>
{
    /// <inheritdoc/>
    public BetaComplianceReviewContentNotCaptured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewContentNotCaptured.FromRawUnchecked(rawData);
}
