using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MessageBatchResultVariants = Anthropic.Beta.Client.Models.Messages.Batches.MessageBatchResultVariants;

namespace Anthropic.Beta.Client.Models.Messages.Batches;

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
        new MessageBatchResultVariants::MessageBatchSucceededResult(value);

    public static implicit operator MessageBatchResult(MessageBatchErroredResult value) =>
        new MessageBatchResultVariants::MessageBatchErroredResult(value);

    public static implicit operator MessageBatchResult(MessageBatchCanceledResult value) =>
        new MessageBatchResultVariants::MessageBatchCanceledResult(value);

    public static implicit operator MessageBatchResult(MessageBatchExpiredResult value) =>
        new MessageBatchResultVariants::MessageBatchExpiredResult(value);

    public bool TryPickSucceeded([NotNullWhen(true)] out MessageBatchSucceededResult? value)
    {
        value = (this as MessageBatchResultVariants::MessageBatchSucceededResult)?.Value;
        return value != null;
    }

    public bool TryPickErrored([NotNullWhen(true)] out MessageBatchErroredResult? value)
    {
        value = (this as MessageBatchResultVariants::MessageBatchErroredResult)?.Value;
        return value != null;
    }

    public bool TryPickCanceled([NotNullWhen(true)] out MessageBatchCanceledResult? value)
    {
        value = (this as MessageBatchResultVariants::MessageBatchCanceledResult)?.Value;
        return value != null;
    }

    public bool TryPickExpired([NotNullWhen(true)] out MessageBatchExpiredResult? value)
    {
        value = (this as MessageBatchResultVariants::MessageBatchExpiredResult)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MessageBatchResultVariants::MessageBatchSucceededResult> succeeded,
        Action<MessageBatchResultVariants::MessageBatchErroredResult> errored,
        Action<MessageBatchResultVariants::MessageBatchCanceledResult> canceled,
        Action<MessageBatchResultVariants::MessageBatchExpiredResult> expired
    )
    {
        switch (this)
        {
            case MessageBatchResultVariants::MessageBatchSucceededResult inner:
                succeeded(inner);
                break;
            case MessageBatchResultVariants::MessageBatchErroredResult inner:
                errored(inner);
                break;
            case MessageBatchResultVariants::MessageBatchCanceledResult inner:
                canceled(inner);
                break;
            case MessageBatchResultVariants::MessageBatchExpiredResult inner:
                expired(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<MessageBatchResultVariants::MessageBatchSucceededResult, T> succeeded,
        Func<MessageBatchResultVariants::MessageBatchErroredResult, T> errored,
        Func<MessageBatchResultVariants::MessageBatchCanceledResult, T> canceled,
        Func<MessageBatchResultVariants::MessageBatchExpiredResult, T> expired
    )
    {
        return this switch
        {
            MessageBatchResultVariants::MessageBatchSucceededResult inner => succeeded(inner),
            MessageBatchResultVariants::MessageBatchErroredResult inner => errored(inner),
            MessageBatchResultVariants::MessageBatchCanceledResult inner => canceled(inner),
            MessageBatchResultVariants::MessageBatchExpiredResult inner => expired(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class MessageBatchResultConverter : JsonConverter<MessageBatchResult>
{
    public override MessageBatchResult? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                        return new MessageBatchResultVariants::MessageBatchSucceededResult(
                            deserialized
                        );
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
                        return new MessageBatchResultVariants::MessageBatchErroredResult(
                            deserialized
                        );
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
                        return new MessageBatchResultVariants::MessageBatchCanceledResult(
                            deserialized
                        );
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
                        return new MessageBatchResultVariants::MessageBatchExpiredResult(
                            deserialized
                        );
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
            MessageBatchResultVariants::MessageBatchSucceededResult(var succeeded) => succeeded,
            MessageBatchResultVariants::MessageBatchErroredResult(var errored) => errored,
            MessageBatchResultVariants::MessageBatchCanceledResult(var canceled) => canceled,
            MessageBatchResultVariants::MessageBatchExpiredResult(var expired) => expired,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
