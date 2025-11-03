using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// Contains a Message output if processing was successful, an error response if processing
/// failed, or the reason why processing was not attempted, such as cancellation
/// or expiration.
/// </summary>
[JsonConverter(typeof(BetaMessageBatchResultConverter))]
public record class BetaMessageBatchResult
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

    public BetaMessageBatchResult(BetaMessageBatchSucceededResult value)
    {
        Value = value;
    }

    public BetaMessageBatchResult(BetaMessageBatchErroredResult value)
    {
        Value = value;
    }

    public BetaMessageBatchResult(BetaMessageBatchCanceledResult value)
    {
        Value = value;
    }

    public BetaMessageBatchResult(BetaMessageBatchExpiredResult value)
    {
        Value = value;
    }

    BetaMessageBatchResult(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaMessageBatchResult CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        Action<BetaMessageBatchSucceededResult> succeeded,
        Action<BetaMessageBatchErroredResult> errored,
        Action<BetaMessageBatchCanceledResult> canceled,
        Action<BetaMessageBatchExpiredResult> expired
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
        Func<BetaMessageBatchSucceededResult, T> succeeded,
        Func<BetaMessageBatchErroredResult, T> errored,
        Func<BetaMessageBatchCanceledResult, T> canceled,
        Func<BetaMessageBatchExpiredResult, T> expired
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMessageBatchResult"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BetaMessageBatchResultConverter : JsonConverter<BetaMessageBatchResult>
{
    public override BetaMessageBatchResult? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchSucceededResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaMessageBatchResult(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaMessageBatchSucceededResult'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchErroredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaMessageBatchResult(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaMessageBatchErroredResult'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchCanceledResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaMessageBatchResult(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaMessageBatchCanceledResult'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchExpiredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaMessageBatchResult(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaMessageBatchExpiredResult'",
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
        BetaMessageBatchResult value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
