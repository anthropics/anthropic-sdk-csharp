using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The value comes from the addressed channel as it is set up under another workspace
/// of its Enterprise Grid: a channel shared across the Grid keeps one Slack channel
/// identifier in every workspace that sees it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackGridChannelSettingSource,
        BetaClaudeTagSlackGridChannelSettingSourceFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackGridChannelSettingSource : JsonModel
{
    /// <summary>
    /// Slack's own identifiers for the channel under that other workspace.
    /// </summary>
    public required BetaClaudeTagSlackChannelIdentifiers Slack
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaClaudeTagSlackChannelIdentifiers>("slack");
        }
        init { this._rawData.Set("slack", value); }
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
        this.Slack.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("slack_grid_channel")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagSlackGridChannelSettingSource()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_grid_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackGridChannelSettingSource(
        BetaClaudeTagSlackGridChannelSettingSource betaClaudeTagSlackGridChannelSettingSource
    )
        : base(betaClaudeTagSlackGridChannelSettingSource) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackGridChannelSettingSource(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_grid_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackGridChannelSettingSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackGridChannelSettingSourceFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackGridChannelSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaClaudeTagSlackGridChannelSettingSource(BetaClaudeTagSlackChannelIdentifiers slack)
        : this()
    {
        this.Slack = slack;
    }
}

class BetaClaudeTagSlackGridChannelSettingSourceFromRaw
    : IFromRawJson<BetaClaudeTagSlackGridChannelSettingSource>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackGridChannelSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackGridChannelSettingSource.FromRawUnchecked(rawData);
}
