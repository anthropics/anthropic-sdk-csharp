using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(
    typeof(JsonModelConverter<MessageBatchErroredResult, MessageBatchErroredResultFromRaw>)
)]
public sealed record class MessageBatchErroredResult : JsonModel
{
    public required ErrorResponse Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ErrorResponse>("error");
        }
        init { this._rawData.Set("error", value); }
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
        this.Error.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("errored")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public MessageBatchErroredResult()
    {
        this.Type = JsonSerializer.SerializeToElement("errored");
    }

    public MessageBatchErroredResult(MessageBatchErroredResult messageBatchErroredResult)
        : base(messageBatchErroredResult) { }

    public MessageBatchErroredResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("errored");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchErroredResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageBatchErroredResultFromRaw.FromRawUnchecked"/>
    public static MessageBatchErroredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageBatchErroredResult(ErrorResponse error)
        : this()
    {
        this.Error = error;
    }
}

class MessageBatchErroredResultFromRaw : IFromRawJson<MessageBatchErroredResult>
{
    /// <inheritdoc/>
    public MessageBatchErroredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageBatchErroredResult.FromRawUnchecked(rawData);
}
