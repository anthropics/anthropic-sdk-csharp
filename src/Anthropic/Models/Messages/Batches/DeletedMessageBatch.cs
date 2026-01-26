using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(typeof(JsonModelConverter<DeletedMessageBatch, DeletedMessageBatchFromRaw>))]
public sealed record class DeletedMessageBatch : JsonModel
{
    /// <summary>
    /// ID of the Message Batch.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Deleted object type.
    ///
    /// <para>For Message Batches, this is always `"message_batch_deleted"`.</para>
    /// </summary>
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
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("message_batch_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public DeletedMessageBatch()
    {
        this.Type = JsonSerializer.SerializeToElement("message_batch_deleted");
    }

    public DeletedMessageBatch(DeletedMessageBatch deletedMessageBatch)
        : base(deletedMessageBatch) { }

    public DeletedMessageBatch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("message_batch_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedMessageBatch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeletedMessageBatchFromRaw.FromRawUnchecked"/>
    public static DeletedMessageBatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeletedMessageBatch(string id)
        : this()
    {
        this.ID = id;
    }
}

class DeletedMessageBatchFromRaw : IFromRawJson<DeletedMessageBatch>
{
    /// <inheritdoc/>
    public DeletedMessageBatch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeletedMessageBatch.FromRawUnchecked(rawData);
}
