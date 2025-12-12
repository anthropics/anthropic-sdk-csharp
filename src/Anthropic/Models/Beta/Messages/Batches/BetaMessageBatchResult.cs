using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// <para>Contains a Message output if processing was successful, an error response
/// if processing failed, or the reason why processing was not attempted, such as
/// cancellation or expiration.</para>
/// </summary>
[JsonConverter(typeof(BetaMessageBatchResultConverter))]
public record class BetaMessageBatchResult
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

    public BetaMessageBatchResult(BetaMessageBatchSucceededResult value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMessageBatchResult(BetaMessageBatchErroredResult value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMessageBatchResult(BetaMessageBatchCanceledResult value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMessageBatchResult(BetaMessageBatchExpiredResult value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMessageBatchResult(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMessageBatchSucceededResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSucceeded(out var value)) {
    ///     // `value` is of type `BetaMessageBatchSucceededResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSucceeded([NotNullWhen(true)] out BetaMessageBatchSucceededResult? value)
    {
        value = this.Value as BetaMessageBatchSucceededResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMessageBatchErroredResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickErrored(out var value)) {
    ///     // `value` is of type `BetaMessageBatchErroredResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickErrored([NotNullWhen(true)] out BetaMessageBatchErroredResult? value)
    {
        value = this.Value as BetaMessageBatchErroredResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMessageBatchCanceledResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCanceled(out var value)) {
    ///     // `value` is of type `BetaMessageBatchCanceledResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCanceled([NotNullWhen(true)] out BetaMessageBatchCanceledResult? value)
    {
        value = this.Value as BetaMessageBatchCanceledResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMessageBatchExpiredResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExpired(out var value)) {
    ///     // `value` is of type `BetaMessageBatchExpiredResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExpired([NotNullWhen(true)] out BetaMessageBatchExpiredResult? value)
    {
        value = this.Value as BetaMessageBatchExpiredResult;
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
    ///     (BetaMessageBatchSucceededResult value) => {...},
    ///     (BetaMessageBatchErroredResult value) => {...},
    ///     (BetaMessageBatchCanceledResult value) => {...},
    ///     (BetaMessageBatchExpiredResult value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaMessageBatchSucceededResult> succeeded,
        System::Action<BetaMessageBatchErroredResult> errored,
        System::Action<BetaMessageBatchCanceledResult> canceled,
        System::Action<BetaMessageBatchExpiredResult> expired
    )
    {
        switch (this.Value)
        {
            case BetaMessageBatchSucceededResult value:
                succeeded(value);
                break;
            case BetaMessageBatchErroredResult value:
                errored(value);
                break;
            case BetaMessageBatchCanceledResult value:
                canceled(value);
                break;
            case BetaMessageBatchExpiredResult value:
                expired(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaMessageBatchResult"
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
    ///     (BetaMessageBatchSucceededResult value) => {...},
    ///     (BetaMessageBatchErroredResult value) => {...},
    ///     (BetaMessageBatchCanceledResult value) => {...},
    ///     (BetaMessageBatchExpiredResult value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaMessageBatchSucceededResult, T> succeeded,
        System::Func<BetaMessageBatchErroredResult, T> errored,
        System::Func<BetaMessageBatchCanceledResult, T> canceled,
        System::Func<BetaMessageBatchExpiredResult, T> expired
    )
    {
        return this.Value switch
        {
            BetaMessageBatchSucceededResult value => succeeded(value),
            BetaMessageBatchErroredResult value => errored(value),
            BetaMessageBatchCanceledResult value => canceled(value),
            BetaMessageBatchExpiredResult value => expired(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMessageBatchResult"
            ),
        };
    }

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchSucceededResult value) =>
        new(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchErroredResult value) =>
        new(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchCanceledResult value) =>
        new(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchExpiredResult value) =>
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
                "Data did not match any variant of BetaMessageBatchResult"
            );
        }
        this.Switch(
            (succeeded) => succeeded.Validate(),
            (errored) => errored.Validate(),
            (canceled) => canceled.Validate(),
            (expired) => expired.Validate()
        );
    }

    public virtual bool Equals(BetaMessageBatchResult? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaMessageBatchResultConverter : JsonConverter<BetaMessageBatchResult>
{
    public override BetaMessageBatchResult? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchSucceededResult>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchErroredResult>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchCanceledResult>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchExpiredResult>(
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
                return new BetaMessageBatchResult(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaMessageBatchResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
