using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(
    typeof(JsonModelConverter<MessageBatchSucceededResult, MessageBatchSucceededResultFromRaw>)
)]
public sealed record class MessageBatchSucceededResult : JsonModel
{
    public required Message Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Message>("message");
        }
        init { this._rawData.Set("message", value); }
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
        this.Message.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"succeeded\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public MessageBatchSucceededResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"succeeded\"");
    }

    public MessageBatchSucceededResult(MessageBatchSucceededResult messageBatchSucceededResult)
        : base(messageBatchSucceededResult) { }

    public MessageBatchSucceededResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"succeeded\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchSucceededResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageBatchSucceededResultFromRaw.FromRawUnchecked"/>
    public static MessageBatchSucceededResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageBatchSucceededResult(Message message)
        : this()
    {
        this.Message = message;
    }
}

class MessageBatchSucceededResultFromRaw : IFromRawJson<MessageBatchSucceededResult>
{
    /// <inheritdoc/>
    public MessageBatchSucceededResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageBatchSucceededResult.FromRawUnchecked(rawData);
}
