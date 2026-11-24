using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// A message sent to Claude.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewMessageDetails,
        BetaComplianceReviewMessageDetailsFromRaw
    >)
)]
public sealed record class BetaComplianceReviewMessageDetails : JsonModel
{
    /// <summary>
    /// The stored request and response. Null when `content_unavailable_reason` is
    /// set. New types can appear, so accept a type that you don't know.
    /// </summary>
    public required BetaComplianceReviewMessageContent? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComplianceReviewMessageContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Why `content` is null. Null when `content` is set. New types can appear, so
    /// accept a type that you don't know.
    /// </summary>
    public required BetaComplianceReviewContentUnavailableReason? ContentUnavailableReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComplianceReviewContentUnavailableReason>(
                "content_unavailable_reason"
            );
        }
        init { this._rawData.Set("content_unavailable_reason", value); }
    }

    /// <summary>
    /// The model that the call named. Null when none was recorded.
    /// </summary>
    public required string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
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
        this.Content?.Validate();
        this.ContentUnavailableReason?.Validate();
        _ = this.Model;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("message")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewMessageDetails()
    {
        this.Type = JsonSerializer.SerializeToElement("message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewMessageDetails(
        BetaComplianceReviewMessageDetails betaComplianceReviewMessageDetails
    )
        : base(betaComplianceReviewMessageDetails) { }
#pragma warning restore CS8618

    public BetaComplianceReviewMessageDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewMessageDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewMessageDetailsFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewMessageDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewMessageDetailsFromRaw : IFromRawJson<BetaComplianceReviewMessageDetails>
{
    /// <inheritdoc/>
    public BetaComplianceReviewMessageDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewMessageDetails.FromRawUnchecked(rawData);
}
