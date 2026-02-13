using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
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
public record class MessageBatchResult : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
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

    public MessageBatchResult(MessageBatchSucceededResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MessageBatchResult(MessageBatchErroredResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MessageBatchResult(MessageBatchCanceledResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MessageBatchResult(MessageBatchExpiredResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MessageBatchResult(JsonElement element)
    {
        this._element = element;
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
    public override void Validate()
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

    public virtual bool Equals(MessageBatchResult? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            MessageBatchSucceededResult _ => 0,
            MessageBatchErroredResult _ => 1,
            MessageBatchCanceledResult _ => 2,
            MessageBatchExpiredResult _ => 3,
            _ => -1,
        };
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
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
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "errored":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchErroredResult>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "canceled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchCanceledResult>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "expired":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessageBatchExpiredResult>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new MessageBatchResult(element);
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
