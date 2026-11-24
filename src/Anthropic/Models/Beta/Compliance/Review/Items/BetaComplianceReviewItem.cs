using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// One stored item that the organization it belongs to can read for review.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComplianceReviewItem, BetaComplianceReviewItemFromRaw>)
)]
public sealed record class BetaComplianceReviewItem : JsonModel
{
    /// <summary>
    /// The ID of the item. For a message, its own ID, such as `msg_...`.
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
    /// For a message, who sent it. Null when no sender was recorded. New types can
    /// appear, so accept a type that you don't know.
    /// </summary>
    public required BetaComplianceReviewActor? Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComplianceReviewActor>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    /// <summary>
    /// Read the item, and save any copy you need, by this time. The item can stop
    /// being readable sooner.
    /// </summary>
    public required DateTimeOffset ContentExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("content_expires_at");
        }
        init { this._rawData.Set("content_expires_at", value); }
    }

    /// <summary>
    /// For a message, when Anthropic received the call.
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
    /// What is particular to this kind of item. New types can appear, so accept
    /// a type that you don't know.
    /// </summary>
    public required BetaComplianceReviewItemDetails Details
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaComplianceReviewItemDetails>("details");
        }
        init { this._rawData.Set("details", value); }
    }

    /// <summary>
    /// The UUID of the organization that the item belongs to. For a message, the
    /// organization that sent it.
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
    /// Why the item is readable. New types can appear, so accept a type that you
    /// don't know.
    /// </summary>
    public required BetaComplianceReviewReadReason ReadReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaComplianceReviewReadReason>("read_reason");
        }
        init { this._rawData.Set("read_reason", value); }
    }

    /// <summary>
    /// The object type, always `compliance_review_item`.
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

    /// <summary>
    /// The ID of the user profile that the item was attributed to (`uprof_...`).
    /// Null when none was recorded.
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

    /// <summary>
    /// The ID of the workspace (`wrkspc_...`). Null when the item isn't attributed
    /// to a workspace.
    /// </summary>
    public required string? WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Actor?.Validate();
        _ = this.ContentExpiresAt;
        _ = this.CreatedAt;
        this.Details.Validate();
        _ = this.OrganizationID;
        this.ReadReason.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("compliance_review_item")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserProfileID;
        _ = this.WorkspaceID;
    }

    public BetaComplianceReviewItem()
    {
        this.Type = JsonSerializer.SerializeToElement("compliance_review_item");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewItem(BetaComplianceReviewItem betaComplianceReviewItem)
        : base(betaComplianceReviewItem) { }
#pragma warning restore CS8618

    public BetaComplianceReviewItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compliance_review_item");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewItemFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewItemFromRaw : IFromRawJson<BetaComplianceReviewItem>
{
    /// <inheritdoc/>
    public BetaComplianceReviewItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewItem.FromRawUnchecked(rawData);
}
