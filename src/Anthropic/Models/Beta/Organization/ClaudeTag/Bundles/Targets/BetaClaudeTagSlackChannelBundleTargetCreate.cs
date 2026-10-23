using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

/// <summary>
/// Attach the Bundle to a Slack channel.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackChannelBundleTargetCreate,
        BetaClaudeTagSlackChannelBundleTargetCreateFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackChannelBundleTargetCreate : JsonModel
{
    /// <summary>
    /// The identifier of the Slack channel to attach the Bundle to, starting with
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
        _ = this.SlackChannelID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("slack_channel")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagSlackChannelBundleTargetCreate()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackChannelBundleTargetCreate(
        BetaClaudeTagSlackChannelBundleTargetCreate betaClaudeTagSlackChannelBundleTargetCreate
    )
        : base(betaClaudeTagSlackChannelBundleTargetCreate) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackChannelBundleTargetCreate(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackChannelBundleTargetCreate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackChannelBundleTargetCreateFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackChannelBundleTargetCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaClaudeTagSlackChannelBundleTargetCreate(string slackChannelID)
        : this()
    {
        this.SlackChannelID = slackChannelID;
    }
}

class BetaClaudeTagSlackChannelBundleTargetCreateFromRaw
    : IFromRawJson<BetaClaudeTagSlackChannelBundleTargetCreate>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackChannelBundleTargetCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackChannelBundleTargetCreate.FromRawUnchecked(rawData);
}
