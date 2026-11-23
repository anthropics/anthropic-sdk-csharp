using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(
    typeof(JsonModelConverter<BetaInferenceDataPrivacy, BetaInferenceDataPrivacyFromRaw>)
)]
public sealed record class BetaInferenceDataPrivacy : JsonModel
{
    /// <summary>
    /// The Workspace's human review setting. Human review is off only while this
    /// is `disabled` and Anthropic's approval stands.
    /// </summary>
    public BetaAnthropicHumanReview? HumanReview
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaAnthropicHumanReview>("human_review");
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
    /// `external` sends it to the External Storage that `external_storage_id` names.
    /// `internal` means no External Storage: it goes to Anthropic's storage or,
    /// on a cloud provider's platform, to that provider's storage. A recent change
    /// may not have taken effect yet.
    /// </summary>
    public BetaStorageMember? SafeguardsStorage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaStorageMember>("safeguards_storage");
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
    /// findings about those transcripts) go. `external` sends them to the External
    /// Storage that `external_storage_id` names. `internal` means no External Storage,
    /// so no copies are made. A recent change may not have taken effect yet.
    /// </summary>
    public BetaStorageMember? TranscriptsStorage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaStorageMember>("transcripts_storage");
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

    public BetaInferenceDataPrivacy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaInferenceDataPrivacy(BetaInferenceDataPrivacy betaInferenceDataPrivacy)
        : base(betaInferenceDataPrivacy) { }
#pragma warning restore CS8618

    public BetaInferenceDataPrivacy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInferenceDataPrivacy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInferenceDataPrivacyFromRaw.FromRawUnchecked"/>
    public static BetaInferenceDataPrivacy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaInferenceDataPrivacyFromRaw : IFromRawJson<BetaInferenceDataPrivacy>
{
    /// <inheritdoc/>
    public BetaInferenceDataPrivacy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInferenceDataPrivacy.FromRawUnchecked(rawData);
}
