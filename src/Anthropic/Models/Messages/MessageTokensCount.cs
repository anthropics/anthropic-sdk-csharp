using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageTokensCount, MessageTokensCountFromRaw>))]
public sealed record class MessageTokensCount : JsonModel
{
    /// <summary>
    /// The total number of tokens across the provided list of messages, system prompt,
    /// and tools.
    /// </summary>
    public required long InputTokens
    {
        get { return this._rawData.GetNotNullStruct<long>("input_tokens"); }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputTokens;
    }

    public MessageTokensCount() { }

    public MessageTokensCount(MessageTokensCount messageTokensCount)
        : base(messageTokensCount) { }

    public MessageTokensCount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageTokensCount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageTokensCountFromRaw.FromRawUnchecked"/>
    public static MessageTokensCount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageTokensCount(long inputTokens)
        : this()
    {
        this.InputTokens = inputTokens;
    }
}

class MessageTokensCountFromRaw : IFromRawJson<MessageTokensCount>
{
    /// <inheritdoc/>
    public MessageTokensCount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageTokensCount.FromRawUnchecked(rawData);
}
