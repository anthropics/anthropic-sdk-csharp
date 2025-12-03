using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatchErroredResult, MessageBatchErroredResultFromRaw>))]
public sealed record class MessageBatchErroredResult : ModelBase
{
    public required ErrorResponse Error
    {
        get { return ModelBase.GetNotNullClass<ErrorResponse>(this.RawData, "error"); }
        init { ModelBase.Set(this._rawData, "error", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"errored\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public MessageBatchErroredResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

    public MessageBatchErroredResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchErroredResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class MessageBatchErroredResultFromRaw : IFromRaw<MessageBatchErroredResult>
{
    /// <inheritdoc/>
    public MessageBatchErroredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageBatchErroredResult.FromRawUnchecked(rawData);
}
