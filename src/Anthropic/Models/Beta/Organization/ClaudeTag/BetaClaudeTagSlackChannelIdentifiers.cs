using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The identifiers Slack shows for a channel. They are Slack's own, not identifiers
/// of this API.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackChannelIdentifiers,
        BetaClaudeTagSlackChannelIdentifiersFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackChannelIdentifiers : JsonModel
{
    /// <summary>
    /// Slack's identifier for the channel, starting with `C` or `G`, such as `C0456EFGH`.
    /// </summary>
    public required string ChannelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel_id");
        }
        init { this._rawData.Set("channel_id", value); }
    }

    /// <summary>
    /// Slack's identifier for the workspace the channel is in, starting with `T`,
    /// such as `T0123ABCD`.
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelID;
        _ = this.WorkspaceID;
    }

    public BetaClaudeTagSlackChannelIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackChannelIdentifiers(
        BetaClaudeTagSlackChannelIdentifiers betaClaudeTagSlackChannelIdentifiers
    )
        : base(betaClaudeTagSlackChannelIdentifiers) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackChannelIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackChannelIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackChannelIdentifiersFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackChannelIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagSlackChannelIdentifiersFromRaw
    : IFromRawJson<BetaClaudeTagSlackChannelIdentifiers>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackChannelIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackChannelIdentifiers.FromRawUnchecked(rawData);
}
