using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageDeltaUsage, MessageDeltaUsageFromRaw>))]
public sealed record class MessageDeltaUsage : JsonModel
{
    /// <summary>
    /// The cumulative number of input tokens used to create the cache entry.
    /// </summary>
    public required long? CacheCreationInputTokens
    {
        get
        {
            return JsonModel.GetNullableStruct<long>(this.RawData, "cache_creation_input_tokens");
        }
        init { JsonModel.Set(this._rawData, "cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of input tokens read from the cache.
    /// </summary>
    public required long? CacheReadInputTokens
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "cache_read_input_tokens"); }
        init { JsonModel.Set(this._rawData, "cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of input tokens which were used.
    /// </summary>
    public required long? InputTokens
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "input_tokens"); }
        init { JsonModel.Set(this._rawData, "input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of output tokens which were used.
    /// </summary>
    public required long OutputTokens
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "output_tokens"); }
        init { JsonModel.Set(this._rawData, "output_tokens", value); }
    }

    /// <summary>
    /// The number of server tool requests.
    /// </summary>
    public required ServerToolUsage? ServerToolUse
    {
        get { return JsonModel.GetNullableClass<ServerToolUsage>(this.RawData, "server_tool_use"); }
        init { JsonModel.Set(this._rawData, "server_tool_use", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
    }

    public MessageDeltaUsage() { }

    public MessageDeltaUsage(MessageDeltaUsage messageDeltaUsage)
        : base(messageDeltaUsage) { }

    public MessageDeltaUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageDeltaUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageDeltaUsageFromRaw.FromRawUnchecked"/>
    public static MessageDeltaUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageDeltaUsageFromRaw : IFromRawJson<MessageDeltaUsage>
{
    /// <inheritdoc/>
    public MessageDeltaUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageDeltaUsage.FromRawUnchecked(rawData);
}
