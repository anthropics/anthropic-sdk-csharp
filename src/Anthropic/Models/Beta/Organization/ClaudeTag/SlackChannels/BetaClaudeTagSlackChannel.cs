using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.SlackChannels;

/// <summary>
/// A Slack channel set up for Claude Tag, with the settings it stores or, with `include_inherited`,
/// the settings that apply in it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaClaudeTagSlackChannel, BetaClaudeTagSlackChannelFromRaw>)
)]
public sealed record class BetaClaudeTagSlackChannel : JsonModel
{
    /// <summary>
    /// The channel's identifier. Starts with `slch_`. It does not change for as
    /// long as the channel is set up, with one exception: a channel that is not configured
    /// gets a new one when claude.ai replaces its record, which happens only while
    /// the organization's read-only mode is off. A channel that is removed and set
    /// up again also has a new one. The old one keeps returning 404; look the channel
    /// up by its Slack identifiers for the new one.
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
    /// Time the channel was set up, by whichever route. It does not change for as
    /// long as `id` does not.
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
    /// What the channel itself stores or, with `include_inherited`, what applies
    /// in it. `sources` says which.
    /// </summary>
    public required BetaClaudeTagSettings Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaClaudeTagSettings>("settings");
        }
        init { this._rawData.Set("settings", value); }
    }

    /// <summary>
    /// Slack's own identifiers for the channel.
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

    /// <summary>
    /// For each setting, the settings level its value in `settings` comes from.
    /// </summary>
    public required BetaClaudeTagSettingSources Sources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaClaudeTagSettingSources>("sources");
        }
        init { this._rawData.Set("sources", value); }
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

    /// <summary>
    /// Time Claude Tag's record of the channel last changed. It moves on every change
    /// to a setting, and can also move when something no response holds changes,
    /// so a later value says to read the channel again, not that a setting changed.
    /// Attaching or detaching a Bundle does not by itself move it.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Settings.Validate();
        this.Slack.Validate();
        this.Sources.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("slack_channel")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaClaudeTagSlackChannel()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackChannel(BetaClaudeTagSlackChannel betaClaudeTagSlackChannel)
        : base(betaClaudeTagSlackChannel) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_channel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackChannelFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagSlackChannelFromRaw : IFromRawJson<BetaClaudeTagSlackChannel>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackChannel.FromRawUnchecked(rawData);
}
