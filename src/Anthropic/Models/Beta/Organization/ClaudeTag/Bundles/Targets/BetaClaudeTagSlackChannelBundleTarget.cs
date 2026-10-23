using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

/// <summary>
/// One Bundle attached to one Slack channel. The Bundle can be used in that channel only.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackChannelBundleTarget,
        BetaClaudeTagSlackChannelBundleTargetFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackChannelBundleTarget : JsonModel
{
    /// <summary>
    /// The Bundle Target's identifier. Starts with `btgt_`. No two Bundle Targets
    /// have the same one, and the same Bundle and target always give the same one,
    /// also after a detach and a new attach. It is opaque.
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
    /// Time the Bundle was attached.
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
    /// The identifier of the Slack channel the Bundle is attached to, starting with
    /// `slch_`. It is the channel object's `id`, not Slack's `channel_id`.
    /// </summary>
    public required string SlackChannelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("slack_channel_id");
        }
        init { this._rawData.Set("slack_channel_id", value); }
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
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.SlackChannelID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("slack_channel")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagSlackChannelBundleTarget()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackChannelBundleTarget(
        BetaClaudeTagSlackChannelBundleTarget betaClaudeTagSlackChannelBundleTarget
    )
        : base(betaClaudeTagSlackChannelBundleTarget) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackChannelBundleTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackChannelBundleTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackChannelBundleTargetFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackChannelBundleTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagSlackChannelBundleTargetFromRaw
    : IFromRawJson<BetaClaudeTagSlackChannelBundleTarget>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackChannelBundleTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackChannelBundleTarget.FromRawUnchecked(rawData);
}
