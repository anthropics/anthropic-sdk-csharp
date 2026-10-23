using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The value comes from the channel that a code channel was started from. A parent
/// channel contributes `instructions` and `environment_id` only.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackParentChannelSettingSource,
        BetaClaudeTagSlackParentChannelSettingSourceFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackParentChannelSettingSource : JsonModel
{
    /// <summary>
    /// The parent channel's identifier, starting with `slch_`.
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("slack_parent_channel")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagSlackParentChannelSettingSource()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_parent_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackParentChannelSettingSource(
        BetaClaudeTagSlackParentChannelSettingSource betaClaudeTagSlackParentChannelSettingSource
    )
        : base(betaClaudeTagSlackParentChannelSettingSource) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackParentChannelSettingSource(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_parent_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackParentChannelSettingSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackParentChannelSettingSourceFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackParentChannelSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaClaudeTagSlackParentChannelSettingSource(string slackChannelID)
        : this()
    {
        this.SlackChannelID = slackChannelID;
    }
}

class BetaClaudeTagSlackParentChannelSettingSourceFromRaw
    : IFromRawJson<BetaClaudeTagSlackParentChannelSettingSource>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackParentChannelSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackParentChannelSettingSource.FromRawUnchecked(rawData);
}
