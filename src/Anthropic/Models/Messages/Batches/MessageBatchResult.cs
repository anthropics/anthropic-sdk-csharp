using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.Batches.MessageBatchResultVariants;

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
        new MessageBatchSucceededResultVariant(value);

    public static implicit operator MessageBatchResult(MessageBatchErroredResult value) =>
        new MessageBatchErroredResultVariant(value);

    public static implicit operator MessageBatchResult(MessageBatchCanceledResult value) =>
        new MessageBatchCanceledResultVariant(value);

    public static implicit operator MessageBatchResult(MessageBatchExpiredResult value) =>
        new MessageBatchExpiredResultVariant(value);

    public bool TryPickMessageBatchSucceededResultVariant(
        [NotNullWhen(true)] out MessageBatchSucceededResult? value
    )
    {
        value = (this as MessageBatchSucceededResultVariant)?.Value;
        return value != null;
    }

    public bool TryPickMessageBatchErroredResultVariant(
        [NotNullWhen(true)] out MessageBatchErroredResult? value
    )
    {
        value = (this as MessageBatchErroredResultVariant)?.Value;
        return value != null;
    }

    public bool TryPickMessageBatchCanceledResultVariant(
        [NotNullWhen(true)] out MessageBatchCanceledResult? value
    )
    {
        value = (this as MessageBatchCanceledResultVariant)?.Value;
        return value != null;
    }

    public bool TryPickMessageBatchExpiredResultVariant(
        [NotNullWhen(true)] out MessageBatchExpiredResult? value
    )
    {
        value = (this as MessageBatchExpiredResultVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MessageBatchSucceededResultVariant> messageBatchSucceededResult,
        Action<MessageBatchErroredResultVariant> messageBatchErroredResult,
        Action<MessageBatchCanceledResultVariant> messageBatchCanceledResult,
        Action<MessageBatchExpiredResultVariant> messageBatchExpiredResult
    )
    {
        switch (this)
        {
            case MessageBatchSucceededResultVariant inner:
                messageBatchSucceededResult(inner);
                break;
            case MessageBatchErroredResultVariant inner:
                messageBatchErroredResult(inner);
                break;
            case MessageBatchCanceledResultVariant inner:
                messageBatchCanceledResult(inner);
                break;
            case MessageBatchExpiredResultVariant inner:
                messageBatchExpiredResult(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<MessageBatchSucceededResultVariant, T> messageBatchSucceededResult,
        Func<MessageBatchErroredResultVariant, T> messageBatchErroredResult,
        Func<MessageBatchCanceledResultVariant, T> messageBatchCanceledResult,
        Func<MessageBatchExpiredResultVariant, T> messageBatchExpiredResult
    )
    {
        return this switch
        {
            MessageBatchSucceededResultVariant inner => messageBatchSucceededResult(inner),
            MessageBatchErroredResultVariant inner => messageBatchErroredResult(inner),
            MessageBatchCanceledResultVariant inner => messageBatchCanceledResult(inner),
            MessageBatchExpiredResultVariant inner => messageBatchExpiredResult(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class MessageBatchResultConverter : JsonConverter<MessageBatchResult>
{
    public override MessageBatchResult? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
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
                        return new MessageBatchSucceededResultVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
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
                        return new MessageBatchErroredResultVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
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
                        return new MessageBatchCanceledResultVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
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
                        return new MessageBatchExpiredResultVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
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
            MessageBatchSucceededResultVariant(var messageBatchSucceededResult) =>
                messageBatchSucceededResult,
            MessageBatchErroredResultVariant(var messageBatchErroredResult) =>
                messageBatchErroredResult,
            MessageBatchCanceledResultVariant(var messageBatchCanceledResult) =>
                messageBatchCanceledResult,
            MessageBatchExpiredResultVariant(var messageBatchExpiredResult) =>
                messageBatchExpiredResult,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
