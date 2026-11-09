using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Every new top-level message in the channel gets its own reply from Claude, in
/// a thread under it. Available where it is enabled for the channel, and only once
/// Claude has been used in the channel.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaClaudeTagReplyModeThread, BetaClaudeTagReplyModeThreadFromRaw>)
)]
public sealed record class BetaClaudeTagReplyModeThread : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("thread")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagReplyModeThread()
    {
        this.Type = JsonSerializer.SerializeToElement("thread");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagReplyModeThread(BetaClaudeTagReplyModeThread betaClaudeTagReplyModeThread)
        : base(betaClaudeTagReplyModeThread) { }
#pragma warning restore CS8618

    public BetaClaudeTagReplyModeThread(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thread");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagReplyModeThread(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagReplyModeThreadFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagReplyModeThread FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagReplyModeThreadFromRaw : IFromRawJson<BetaClaudeTagReplyModeThread>
{
    /// <inheritdoc/>
    public BetaClaudeTagReplyModeThread FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagReplyModeThread.FromRawUnchecked(rawData);
}
