using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(
    typeof(JsonModelConverter<MessageBatchExpiredResult, MessageBatchExpiredResultFromRaw>)
)]
public sealed record class MessageBatchExpiredResult : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("expired")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public MessageBatchExpiredResult()
    {
        this.Type = JsonSerializer.SerializeToElement("expired");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageBatchExpiredResult(MessageBatchExpiredResult messageBatchExpiredResult)
        : base(messageBatchExpiredResult) { }
#pragma warning restore CS8618

    public MessageBatchExpiredResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("expired");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchExpiredResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageBatchExpiredResultFromRaw.FromRawUnchecked"/>
    public static MessageBatchExpiredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageBatchExpiredResultFromRaw : IFromRawJson<MessageBatchExpiredResult>
{
    /// <inheritdoc/>
    public MessageBatchExpiredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageBatchExpiredResult.FromRawUnchecked(rawData);
}
