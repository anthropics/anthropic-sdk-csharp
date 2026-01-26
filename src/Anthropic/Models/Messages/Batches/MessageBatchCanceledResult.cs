using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(
    typeof(JsonModelConverter<MessageBatchCanceledResult, MessageBatchCanceledResultFromRaw>)
)]
public sealed record class MessageBatchCanceledResult : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("canceled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public MessageBatchCanceledResult()
    {
        this.Type = JsonSerializer.SerializeToElement("canceled");
    }

    public MessageBatchCanceledResult(MessageBatchCanceledResult messageBatchCanceledResult)
        : base(messageBatchCanceledResult) { }

    public MessageBatchCanceledResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("canceled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchCanceledResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageBatchCanceledResultFromRaw.FromRawUnchecked"/>
    public static MessageBatchCanceledResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageBatchCanceledResultFromRaw : IFromRawJson<MessageBatchCanceledResult>
{
    /// <inheritdoc/>
    public MessageBatchCanceledResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageBatchCanceledResult.FromRawUnchecked(rawData);
}
