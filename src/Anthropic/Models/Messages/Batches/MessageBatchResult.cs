using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// <para>Contains a Message output if processing was successful, an error response
/// if processing failed, or the reason why processing was not attempted, such as
/// cancellation or expiration.</para>
/// </summary>
[JsonConverter(typeof(MessageBatchResultConverter))]
public record class MessageBatchResult
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

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

    public MessageBatchResult(MessageBatchSucceededResult value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageBatchResult(MessageBatchErroredResult value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageBatchResult(MessageBatchCanceledResult value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageBatchResult(MessageBatchExpiredResult value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageBatchResult(JsonElement json)
    {
        this._json = json;
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
        System::Action<MessageBatchSucceededResult> succeeded,
        System::Action<MessageBatchErroredResult> errored,
        System::Action<MessageBatchCanceledResult> canceled,
        System::Action<MessageBatchExpiredResult> expired
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
        System::Func<MessageBatchSucceededResult, T> succeeded,
        System::Func<MessageBatchErroredResult, T> errored,
        System::Func<MessageBatchCanceledResult, T> canceled,
        System::Func<MessageBatchExpiredResult, T> expired
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

    public static implicit operator MessageBatchResult(MessageBatchSucceededResult value) =>
        new(value);

    public static implicit operator MessageBatchResult(MessageBatchErroredResult value) =>
        new(value);

    public static implicit operator MessageBatchResult(MessageBatchCanceledResult value) =>
        new(value);

    public static implicit operator MessageBatchResult(MessageBatchExpiredResult value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageBatchResult"
            );
        }
    }

    public virtual bool Equals(MessageBatchResult? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class MessageBatchResultConverter : JsonConverter<MessageBatchResult>
{
    public override MessageBatchResult? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchSucceededResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "errored":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchErroredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "canceled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchCanceledResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "expired":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchExpiredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new MessageBatchResult(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageBatchResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
