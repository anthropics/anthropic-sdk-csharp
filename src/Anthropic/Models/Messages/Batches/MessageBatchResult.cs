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

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MessageBatchSucceededResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSucceeded(out var value)) {
    ///     // `value` is of type `MessageBatchSucceededResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSucceeded([NotNullWhen(true)] out MessageBatchSucceededResult? value)
    {
        value = this.Value as MessageBatchSucceededResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MessageBatchErroredResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickErrored(out var value)) {
    ///     // `value` is of type `MessageBatchErroredResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickErrored([NotNullWhen(true)] out MessageBatchErroredResult? value)
    {
        value = this.Value as MessageBatchErroredResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MessageBatchCanceledResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCanceled(out var value)) {
    ///     // `value` is of type `MessageBatchCanceledResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCanceled([NotNullWhen(true)] out MessageBatchCanceledResult? value)
    {
        value = this.Value as MessageBatchCanceledResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MessageBatchExpiredResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExpired(out var value)) {
    ///     // `value` is of type `MessageBatchExpiredResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExpired([NotNullWhen(true)] out MessageBatchExpiredResult? value)
    {
        value = this.Value as MessageBatchExpiredResult;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (MessageBatchSucceededResult value) => {...},
    ///     (MessageBatchErroredResult value) => {...},
    ///     (MessageBatchCanceledResult value) => {...},
    ///     (MessageBatchExpiredResult value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (MessageBatchSucceededResult value) => {...},
    ///     (MessageBatchErroredResult value) => {...},
    ///     (MessageBatchCanceledResult value) => {...},
    ///     (MessageBatchExpiredResult value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageBatchResult"
            );
        }
        this.Switch(
            (succeeded) => succeeded.Validate(),
            (errored) => errored.Validate(),
            (canceled) => canceled.Validate(),
            (expired) => expired.Validate()
        );
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
