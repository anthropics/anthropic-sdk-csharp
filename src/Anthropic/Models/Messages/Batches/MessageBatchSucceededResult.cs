using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(
    typeof(ModelConverter<MessageBatchSucceededResult, MessageBatchSucceededResultFromRaw>)
)]
public sealed record class MessageBatchSucceededResult : ModelBase
{
    public required Message Message
    {
        get { return ModelBase.GetNotNullClass<Message>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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

    public MessageBatchSucceededResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"succeeded\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchSucceededResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class MessageBatchSucceededResultFromRaw : IFromRaw<MessageBatchSucceededResult>
{
    /// <inheritdoc/>
    public MessageBatchSucceededResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageBatchSucceededResult.FromRawUnchecked(rawData);
}
