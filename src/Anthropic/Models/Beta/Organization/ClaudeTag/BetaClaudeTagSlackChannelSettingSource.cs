using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The value comes from the addressed Slack channel itself.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackChannelSettingSource,
        BetaClaudeTagSlackChannelSettingSourceFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackChannelSettingSource : JsonModel
{
    /// <summary>
    /// The channel's identifier, starting with `slch_`.
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

    public BetaClaudeTagSlackChannelSettingSource()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackChannelSettingSource(
        BetaClaudeTagSlackChannelSettingSource betaClaudeTagSlackChannelSettingSource
    )
        : base(betaClaudeTagSlackChannelSettingSource) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackChannelSettingSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackChannelSettingSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackChannelSettingSourceFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackChannelSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaClaudeTagSlackChannelSettingSource(string slackChannelID)
        : this()
    {
        this.SlackChannelID = slackChannelID;
    }
}

class BetaClaudeTagSlackChannelSettingSourceFromRaw
    : IFromRawJson<BetaClaudeTagSlackChannelSettingSource>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackChannelSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackChannelSettingSource.FromRawUnchecked(rawData);
}
