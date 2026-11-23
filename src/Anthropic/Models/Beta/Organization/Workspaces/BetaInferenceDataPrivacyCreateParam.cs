using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// Where the Workspace's retained inference data and transcript copies go, and whether
/// Anthropic's human review applies. A member cannot be null; omit it instead.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaInferenceDataPrivacyCreateParam,
        BetaInferenceDataPrivacyCreateParamFromRaw
    >)
)]
public sealed record class BetaInferenceDataPrivacyCreateParam : JsonModel
{
    /// <summary>
    /// Whether Anthropic's human review applies to the Workspace. `disabled` needs
    /// Anthropic's approval. When omitted, `enabled`. Cannot be null.
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
    /// Where the data Anthropic's safeguards systems retain for the Workspace goes.
    /// `external` sends it, once the attach takes effect, to the External Storage
    /// that `external_storage_id` names. `internal` means no External Storage: it
    /// goes to Anthropic's storage or, on a cloud provider's platform, to that provider's
    /// storage. When omitted, `internal`. Cannot be null.
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
    /// findings about those transcripts) go. `external` sends them, once the attach
    /// takes effect, to the External Storage that `external_storage_id` names. `internal`
    /// means no External Storage, so no copies are made. When omitted, `internal`.
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

    public BetaInferenceDataPrivacyCreateParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaInferenceDataPrivacyCreateParam(
        BetaInferenceDataPrivacyCreateParam betaInferenceDataPrivacyCreateParam
    )
        : base(betaInferenceDataPrivacyCreateParam) { }
#pragma warning restore CS8618

    public BetaInferenceDataPrivacyCreateParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInferenceDataPrivacyCreateParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInferenceDataPrivacyCreateParamFromRaw.FromRawUnchecked"/>
    public static BetaInferenceDataPrivacyCreateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaInferenceDataPrivacyCreateParamFromRaw : IFromRawJson<BetaInferenceDataPrivacyCreateParam>
{
    /// <inheritdoc/>
    public BetaInferenceDataPrivacyCreateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInferenceDataPrivacyCreateParam.FromRawUnchecked(rawData);
}
