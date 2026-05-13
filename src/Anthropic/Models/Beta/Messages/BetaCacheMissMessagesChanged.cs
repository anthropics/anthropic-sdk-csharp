using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaCacheMissMessagesChanged, BetaCacheMissMessagesChangedFromRaw>)
)]
public sealed record class BetaCacheMissMessagesChanged : JsonModel
{
    /// <summary>
    /// Approximate number of input tokens that would have been read from cache had
    /// the prefix matched the previous request.
    /// </summary>
    public required long CacheMissedInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cache_missed_input_tokens");
        }
        init { this._rawData.Set("cache_missed_input_tokens", value); }
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
        _ = this.CacheMissedInputTokens;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("messages_changed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCacheMissMessagesChanged()
    {
        this.Type = JsonSerializer.SerializeToElement("messages_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCacheMissMessagesChanged(BetaCacheMissMessagesChanged betaCacheMissMessagesChanged)
        : base(betaCacheMissMessagesChanged) { }
#pragma warning restore CS8618

    public BetaCacheMissMessagesChanged(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("messages_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheMissMessagesChanged(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCacheMissMessagesChangedFromRaw.FromRawUnchecked"/>
    public static BetaCacheMissMessagesChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCacheMissMessagesChanged(long cacheMissedInputTokens)
        : this()
    {
        this.CacheMissedInputTokens = cacheMissedInputTokens;
    }
}

class BetaCacheMissMessagesChangedFromRaw : IFromRawJson<BetaCacheMissMessagesChanged>
{
    /// <inheritdoc/>
    public BetaCacheMissMessagesChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCacheMissMessagesChanged.FromRawUnchecked(rawData);
}
