using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// Contains a Message output if processing was successful, an error response if processing
/// failed, or the reason why processing was not attempted, such as cancellation
/// or expiration.
/// </summary>
[JsonConverter(typeof(MessageBatchResultConverter))]
public record class MessageBatchResult
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                succeeded: (x) => x.Type,
                errored: (x) => x.Type,
                canceled: (x) => x.Type,
                expired: (x) => x.Type
            );
        }
    }

    public MessageBatchResult(MessageBatchSucceededResult value)
    {
        Value = value;
    }

    public MessageBatchResult(MessageBatchErroredResult value)
    {
        Value = value;
    }

    public MessageBatchResult(MessageBatchCanceledResult value)
    {
        Value = value;
    }

    public MessageBatchResult(MessageBatchExpiredResult value)
    {
        Value = value;
    }

    MessageBatchResult(UnknownVariant value)
    {
        Value = value;
    }

    public static MessageBatchResult CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickSucceeded([NotNullWhen(true)] out MessageBatchSucceededResult? value)
    {
        value = this.Value as MessageBatchSucceededResult;
        return value != null;
    }

    public bool TryPickErrored([NotNullWhen(true)] out MessageBatchErroredResult? value)
    {
        value = this.Value as MessageBatchErroredResult;
        return value != null;
    }

    public bool TryPickCanceled([NotNullWhen(true)] out MessageBatchCanceledResult? value)
    {
        value = this.Value as MessageBatchCanceledResult;
        return value != null;
    }

    public bool TryPickExpired([NotNullWhen(true)] out MessageBatchExpiredResult? value)
    {
        value = this.Value as MessageBatchExpiredResult;
        return value != null;
    }

    public void Switch(
        Action<MessageBatchSucceededResult> succeeded,
        Action<MessageBatchErroredResult> errored,
        Action<MessageBatchCanceledResult> canceled,
        Action<MessageBatchExpiredResult> expired
    )
    {
        switch (this.Value)
        {
            case MessageBatchSucceededResult value:
                succeeded(value);
                break;
            case MessageBatchErroredResult value:
                errored(value);
                break;
            case MessageBatchCanceledResult value:
                canceled(value);
                break;
            case MessageBatchExpiredResult value:
                expired(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of MessageBatchResult"
                );
        }
    }

    public T Match<T>(
        Func<MessageBatchSucceededResult, T> succeeded,
        Func<MessageBatchErroredResult, T> errored,
        Func<MessageBatchCanceledResult, T> canceled,
        Func<MessageBatchExpiredResult, T> expired
    )
    {
        return this.Value switch
        {
            MessageBatchSucceededResult value => succeeded(value),
            MessageBatchErroredResult value => errored(value),
            MessageBatchCanceledResult value => canceled(value),
            MessageBatchExpiredResult value => expired(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageBatchResult"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageBatchResult"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchSucceededResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new MessageBatchResult(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'MessageBatchSucceededResult'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "errored":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchErroredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new MessageBatchResult(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'MessageBatchErroredResult'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "canceled":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchCanceledResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new MessageBatchResult(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'MessageBatchCanceledResult'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "expired":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchExpiredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new MessageBatchResult(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'MessageBatchExpiredResult'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageBatchResult value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
