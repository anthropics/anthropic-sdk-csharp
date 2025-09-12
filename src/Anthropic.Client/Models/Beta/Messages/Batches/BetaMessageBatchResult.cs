using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaMessageBatchResultVariants = Anthropic.Client.Models.Beta.Messages.Batches.BetaMessageBatchResultVariants;

namespace Anthropic.Client.Models.Beta.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// Contains a Message output if processing was successful, an error response if processing
/// failed, or the reason why processing was not attempted, such as cancellation
/// or expiration.
/// </summary>
[JsonConverter(typeof(BetaMessageBatchResultConverter))]
public abstract record class BetaMessageBatchResult
{
    internal BetaMessageBatchResult() { }

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchSucceededResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchSucceededResult(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchErroredResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchErroredResult(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchCanceledResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchCanceledResult(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchExpiredResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchExpiredResult(value);

    public bool TryPickSucceeded([NotNullWhen(true)] out BetaMessageBatchSucceededResult? value)
    {
        value = (this as BetaMessageBatchResultVariants::BetaMessageBatchSucceededResult)?.Value;
        return value != null;
    }

    public bool TryPickErrored([NotNullWhen(true)] out BetaMessageBatchErroredResult? value)
    {
        value = (this as BetaMessageBatchResultVariants::BetaMessageBatchErroredResult)?.Value;
        return value != null;
    }

    public bool TryPickCanceled([NotNullWhen(true)] out BetaMessageBatchCanceledResult? value)
    {
        value = (this as BetaMessageBatchResultVariants::BetaMessageBatchCanceledResult)?.Value;
        return value != null;
    }

    public bool TryPickExpired([NotNullWhen(true)] out BetaMessageBatchExpiredResult? value)
    {
        value = (this as BetaMessageBatchResultVariants::BetaMessageBatchExpiredResult)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaMessageBatchResultVariants::BetaMessageBatchSucceededResult> succeeded,
        Action<BetaMessageBatchResultVariants::BetaMessageBatchErroredResult> errored,
        Action<BetaMessageBatchResultVariants::BetaMessageBatchCanceledResult> canceled,
        Action<BetaMessageBatchResultVariants::BetaMessageBatchExpiredResult> expired
    )
    {
        switch (this)
        {
            case BetaMessageBatchResultVariants::BetaMessageBatchSucceededResult inner:
                succeeded(inner);
                break;
            case BetaMessageBatchResultVariants::BetaMessageBatchErroredResult inner:
                errored(inner);
                break;
            case BetaMessageBatchResultVariants::BetaMessageBatchCanceledResult inner:
                canceled(inner);
                break;
            case BetaMessageBatchResultVariants::BetaMessageBatchExpiredResult inner:
                expired(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaMessageBatchResultVariants::BetaMessageBatchSucceededResult, T> succeeded,
        Func<BetaMessageBatchResultVariants::BetaMessageBatchErroredResult, T> errored,
        Func<BetaMessageBatchResultVariants::BetaMessageBatchCanceledResult, T> canceled,
        Func<BetaMessageBatchResultVariants::BetaMessageBatchExpiredResult, T> expired
    )
    {
        return this switch
        {
            BetaMessageBatchResultVariants::BetaMessageBatchSucceededResult inner => succeeded(
                inner
            ),
            BetaMessageBatchResultVariants::BetaMessageBatchErroredResult inner => errored(inner),
            BetaMessageBatchResultVariants::BetaMessageBatchCanceledResult inner => canceled(inner),
            BetaMessageBatchResultVariants::BetaMessageBatchExpiredResult inner => expired(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchSucceededResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaMessageBatchResultVariants::BetaMessageBatchSucceededResult(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchErroredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaMessageBatchResultVariants::BetaMessageBatchErroredResult(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchCanceledResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaMessageBatchResultVariants::BetaMessageBatchCanceledResult(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchExpiredResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaMessageBatchResultVariants::BetaMessageBatchExpiredResult(
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
        BetaMessageBatchResult value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaMessageBatchResultVariants::BetaMessageBatchSucceededResult(var succeeded) =>
                succeeded,
            BetaMessageBatchResultVariants::BetaMessageBatchErroredResult(var errored) => errored,
            BetaMessageBatchResultVariants::BetaMessageBatchCanceledResult(var canceled) =>
                canceled,
            BetaMessageBatchResultVariants::BetaMessageBatchExpiredResult(var expired) => expired,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
