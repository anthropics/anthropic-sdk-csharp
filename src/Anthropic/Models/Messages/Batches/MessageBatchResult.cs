using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MessageBatchResultVariants = Anthropic.Models.Messages.Batches.MessageBatchResultVariants;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// Contains a Message output if processing was successful, an error response if processing
/// failed, or the reason why processing was not attempted, such as cancellation
/// or expiration.
/// </summary>
[JsonConverter(typeof(MessageBatchResultConverter))]
public abstract record class MessageBatchResult
{
    internal MessageBatchResult() { }

    public static implicit operator MessageBatchResult(MessageBatchSucceededResult value) =>
        new MessageBatchResultVariants::MessageBatchSucceededResultVariant(value);

    public static implicit operator MessageBatchResult(MessageBatchErroredResult value) =>
        new MessageBatchResultVariants::MessageBatchErroredResultVariant(value);

    public static implicit operator MessageBatchResult(MessageBatchCanceledResult value) =>
        new MessageBatchResultVariants::MessageBatchCanceledResultVariant(value);

    public static implicit operator MessageBatchResult(MessageBatchExpiredResult value) =>
        new MessageBatchResultVariants::MessageBatchExpiredResultVariant(value);

    public abstract void Validate();
}

sealed class MessageBatchResultConverter : JsonConverter<MessageBatchResult>
{
    public override MessageBatchResult? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "succeeded":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchSucceededResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new MessageBatchResultVariants::MessageBatchSucceededResultVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "errored":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchErroredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new MessageBatchResultVariants::MessageBatchErroredResultVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "canceled":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchCanceledResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new MessageBatchResultVariants::MessageBatchCanceledResultVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "expired":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchExpiredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new MessageBatchResultVariants::MessageBatchExpiredResultVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            default:
            {
                throw new global::System.Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageBatchResult value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            MessageBatchResultVariants::MessageBatchSucceededResultVariant(
                var messageBatchSucceededResult
            ) => messageBatchSucceededResult,
            MessageBatchResultVariants::MessageBatchErroredResultVariant(
                var messageBatchErroredResult
            ) => messageBatchErroredResult,
            MessageBatchResultVariants::MessageBatchCanceledResultVariant(
                var messageBatchCanceledResult
            ) => messageBatchCanceledResult,
            MessageBatchResultVariants::MessageBatchExpiredResultVariant(
                var messageBatchExpiredResult
            ) => messageBatchExpiredResult,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
