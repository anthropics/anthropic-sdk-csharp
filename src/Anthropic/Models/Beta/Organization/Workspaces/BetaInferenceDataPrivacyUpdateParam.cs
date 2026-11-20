using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// Changes to where the Workspace's retained inference data and transcript copies
/// go, and to whether Anthropic's human review applies. An omitted member is unchanged;
/// a member cannot be null.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaInferenceDataPrivacyUpdateParam,
        BetaInferenceDataPrivacyUpdateParamFromRaw
    >)
)]
public sealed record class BetaInferenceDataPrivacyUpdateParam : JsonModel
{
    /// <summary>
    /// Whether Anthropic's human review applies to the Workspace from now on. `disabled`
    /// needs Anthropic's approval. When omitted, unchanged. Cannot be null.
    /// </summary>
    public BetaAnthropicHumanReviewParam? HumanReview
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaAnthropicHumanReviewParam>("human_review");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("human_review");
                return;
            }

            this._rawData.Set("human_review", value);
        }
    }

    /// <summary>
    /// Where the data Anthropic's safeguards systems retain for the Workspace goes
    /// once the change takes effect. `external` sends it to the External Storage
    /// that `external_storage_id` names. `internal` means no External Storage: it
    /// goes to Anthropic's storage or, on a cloud provider's platform, to that provider's
    /// storage. When omitted, unchanged. Cannot be null.
    /// </summary>
    public BetaStorageMemberParam? SafeguardsStorage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaStorageMemberParam>("safeguards_storage");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("safeguards_storage");
                return;
            }

            this._rawData.Set("safeguards_storage", value);
        }
    }

    /// <summary>
    /// Where copies of the Workspace's transcripts and its cases (Anthropic's safety
    /// findings about those transcripts) go once the change takes effect. `external`
    /// sends them to the External Storage that `external_storage_id` names. `internal`
    /// means no External Storage, so no more copies are made. When omitted, unchanged.
    /// Cannot be null.
    /// </summary>
    public BetaStorageMemberParam? TranscriptsStorage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaStorageMemberParam>("transcripts_storage");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("transcripts_storage");
                return;
            }

            this._rawData.Set("transcripts_storage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.HumanReview?.Validate();
        this.SafeguardsStorage?.Validate();
        this.TranscriptsStorage?.Validate();
    }

    public BetaInferenceDataPrivacyUpdateParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaInferenceDataPrivacyUpdateParam(
        BetaInferenceDataPrivacyUpdateParam betaInferenceDataPrivacyUpdateParam
    )
        : base(betaInferenceDataPrivacyUpdateParam) { }
#pragma warning restore CS8618

    public BetaInferenceDataPrivacyUpdateParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInferenceDataPrivacyUpdateParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInferenceDataPrivacyUpdateParamFromRaw.FromRawUnchecked"/>
    public static BetaInferenceDataPrivacyUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaInferenceDataPrivacyUpdateParamFromRaw : IFromRawJson<BetaInferenceDataPrivacyUpdateParam>
{
    /// <inheritdoc/>
    public BetaInferenceDataPrivacyUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInferenceDataPrivacyUpdateParam.FromRawUnchecked(rawData);
}
