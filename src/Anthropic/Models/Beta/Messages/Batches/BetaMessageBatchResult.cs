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

    public bool TryPickSucceeded([NotNullWhen(true)] out BetaMessageBatchSucceededResult? value)
    {
        value = this.Value as BetaMessageBatchSucceededResult;
        return value != null;
    }

    public bool TryPickErrored([NotNullWhen(true)] out BetaMessageBatchErroredResult? value)
    {
        value = this.Value as BetaMessageBatchErroredResult;
        return value != null;
    }

    public bool TryPickCanceled([NotNullWhen(true)] out BetaMessageBatchCanceledResult? value)
    {
        value = this.Value as BetaMessageBatchCanceledResult;
        return value != null;
    }

    public bool TryPickExpired([NotNullWhen(true)] out BetaMessageBatchExpiredResult? value)
    {
        value = this.Value as BetaMessageBatchExpiredResult;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMessageBatchResult"
            );
        }
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
