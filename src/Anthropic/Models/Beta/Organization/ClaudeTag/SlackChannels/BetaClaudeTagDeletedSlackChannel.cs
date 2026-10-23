using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.SlackChannels;

/// <summary>
/// Confirms that a Slack channel was removed from Claude Tag.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagDeletedSlackChannel,
        BetaClaudeTagDeletedSlackChannelFromRaw
    >)
)]
public sealed record class BetaClaudeTagDeletedSlackChannel : JsonModel
{
    /// <summary>
    /// The removed channel's identifier.
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("slack_channel_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagDeletedSlackChannel()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_channel_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagDeletedSlackChannel(
        BetaClaudeTagDeletedSlackChannel betaClaudeTagDeletedSlackChannel
    )
        : base(betaClaudeTagDeletedSlackChannel) { }
#pragma warning restore CS8618

    public BetaClaudeTagDeletedSlackChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_channel_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagDeletedSlackChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagDeletedSlackChannelFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagDeletedSlackChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaClaudeTagDeletedSlackChannel(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaClaudeTagDeletedSlackChannelFromRaw : IFromRawJson<BetaClaudeTagDeletedSlackChannel>
{
    /// <inheritdoc/>
    public BetaClaudeTagDeletedSlackChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagDeletedSlackChannel.FromRawUnchecked(rawData);
}
