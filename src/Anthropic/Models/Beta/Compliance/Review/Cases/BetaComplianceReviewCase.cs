using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// A record of an organization's messages that Anthropic flagged and sent to the
/// organization to review. It lists the messages by ID and doesn't include their content.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComplianceReviewCase, BetaComplianceReviewCaseFromRaw>)
)]
public sealed record class BetaComplianceReviewCase : JsonModel
{
    /// <summary>
    /// The unique ID of the case (`rvc_...`).
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
    /// When Anthropic sent the case. The time you have to respond starts here.
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
    /// The action that Anthropic took before it sent the case. Null when it took none.
    /// </summary>
    public required BetaComplianceReviewEnforcementAction? EnforcementAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComplianceReviewEnforcementAction>(
                "enforcement_action"
            );
        }
        init { this._rawData.Set("enforcement_action", value); }
    }

    /// <summary>
    /// The UUID of the organization that sent the flagged messages, which the case
    /// belongs to.
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
    /// Anthropic's labels for why the messages were flagged, such as `cyber` or
    /// `fraud`. There is at least one. New values can appear, so accept a value
    /// that you don't know.
    /// </summary>
    public required IReadOnlyList<
        ApiEnum<string, BetaComplianceReviewPolicyCategory>
    > PolicyCategories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, BetaComplianceReviewPolicyCategory>>
            >("policy_categories");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, BetaComplianceReviewPolicyCategory>>>(
                "policy_categories",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether Anthropic is still waiting for a response.
    /// </summary>
    public required BetaComplianceReviewCaseStatus Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaComplianceReviewCaseStatus>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The flagged messages. There is at least one, and the list isn't paginated.
    /// </summary>
    public required IReadOnlyList<BetaComplianceReviewTranscript> Transcripts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaComplianceReviewTranscript>>(
                "transcripts"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaComplianceReviewTranscript>>(
                "transcripts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The object type, always `compliance_review_case`.
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
    /// When the case last changed. It changes when Anthropic sends the case, when
    /// the case closes, and when Anthropic sends a notice about the case.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// The ID of the workspace that sent the flagged messages (`wrkspc_...`). Null
    /// when the messages have no workspace, and it can be null for the default workspace.
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
        _ = this.CreatedAt;
        this.EnforcementAction?.Validate();
        _ = this.OrganizationID;
        foreach (var item in this.PolicyCategories)
        {
            item.Validate();
        }
        this.Status.Validate();
        foreach (var item in this.Transcripts)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("compliance_review_case")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        _ = this.WorkspaceID;
    }

    public BetaComplianceReviewCase()
    {
        this.Type = JsonSerializer.SerializeToElement("compliance_review_case");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewCase(BetaComplianceReviewCase betaComplianceReviewCase)
        : base(betaComplianceReviewCase) { }
#pragma warning restore CS8618

    public BetaComplianceReviewCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compliance_review_case");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewCaseFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewCaseFromRaw : IFromRawJson<BetaComplianceReviewCase>
{
    /// <inheritdoc/>
    public BetaComplianceReviewCase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewCase.FromRawUnchecked(rawData);
}
