using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Notices;

/// <summary>
/// A message from Anthropic to an organization about its review cases or about the
/// organization as a whole, such as a request to respond by a date, a warning, or
/// a question. A notice doesn't change after Anthropic sends it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComplianceReviewNotice, BetaComplianceReviewNoticeFromRaw>)
)]
public sealed record class BetaComplianceReviewNotice : JsonModel
{
    /// <summary>
    /// The unique ID of the notice (`rvn_...`).
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The IDs of the cases that the notice is about (`rvc_...`). Empty when the
    /// notice is about the whole organization.
    /// </summary>
    public required IReadOnlyList<string> CaseIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("case_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "case_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When Anthropic sent the notice.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// What kind of notice this is.
    /// </summary>
    public required BetaComplianceReviewNoticeKind Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaComplianceReviewNoticeKind>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// The text of the notice.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// The UUID of the organization that the notice is for.
    /// </summary>
    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// The time by which Anthropic asks for an answer. Null when there is no deadline.
    /// Missing it changes nothing on a case, and the time to respond to a case can
    /// end before it.
    /// </summary>
    public required DateTimeOffset? RespondBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("respond_by");
        }
        init { this._rawData.Set("respond_by", value); }
    }

    /// <summary>
    /// The object type, always `compliance_review_notice`.
    /// </summary>
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
        _ = this.ID;
        _ = this.CaseIds;
        _ = this.CreatedAt;
        this.Kind.Validate();
        _ = this.Message;
        _ = this.OrganizationID;
        _ = this.RespondBy;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("compliance_review_notice")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewNotice()
    {
        this.Type = JsonSerializer.SerializeToElement("compliance_review_notice");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewNotice(BetaComplianceReviewNotice betaComplianceReviewNotice)
        : base(betaComplianceReviewNotice) { }
#pragma warning restore CS8618

    public BetaComplianceReviewNotice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compliance_review_notice");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewNotice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewNoticeFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewNotice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewNoticeFromRaw : IFromRawJson<BetaComplianceReviewNotice>
{
    /// <inheritdoc/>
    public BetaComplianceReviewNotice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewNotice.FromRawUnchecked(rawData);
}
