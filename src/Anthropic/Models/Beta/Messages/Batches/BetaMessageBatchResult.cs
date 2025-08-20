using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.Batches.BetaMessageBatchResultVariants;

namespace Anthropic.Models.Beta.Messages.Batches;

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
        new BetaMessageBatchSucceededResultVariant(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchErroredResult value) =>
        new BetaMessageBatchErroredResultVariant(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchCanceledResult value) =>
        new BetaMessageBatchCanceledResultVariant(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchExpiredResult value) =>
        new BetaMessageBatchExpiredResultVariant(value);

    public bool TryPickBetaMessageBatchSucceededResultVariant(
        [NotNullWhen(true)] out BetaMessageBatchSucceededResult? value
    )
    {
        value = (this as BetaMessageBatchSucceededResultVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaMessageBatchErroredResultVariant(
        [NotNullWhen(true)] out BetaMessageBatchErroredResult? value
    )
    {
        value = (this as BetaMessageBatchErroredResultVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaMessageBatchCanceledResultVariant(
        [NotNullWhen(true)] out BetaMessageBatchCanceledResult? value
    )
    {
        value = (this as BetaMessageBatchCanceledResultVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaMessageBatchExpiredResultVariant(
        [NotNullWhen(true)] out BetaMessageBatchExpiredResult? value
    )
    {
        value = (this as BetaMessageBatchExpiredResultVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaMessageBatchSucceededResultVariant> betaMessageBatchSucceededResult,
        Action<BetaMessageBatchErroredResultVariant> betaMessageBatchErroredResult,
        Action<BetaMessageBatchCanceledResultVariant> betaMessageBatchCanceledResult,
        Action<BetaMessageBatchExpiredResultVariant> betaMessageBatchExpiredResult
    )
    {
        switch (this)
        {
            case BetaMessageBatchSucceededResultVariant inner:
                betaMessageBatchSucceededResult(inner);
                break;
            case BetaMessageBatchErroredResultVariant inner:
                betaMessageBatchErroredResult(inner);
                break;
            case BetaMessageBatchCanceledResultVariant inner:
                betaMessageBatchCanceledResult(inner);
                break;
            case BetaMessageBatchExpiredResultVariant inner:
                betaMessageBatchExpiredResult(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaMessageBatchSucceededResultVariant, T> betaMessageBatchSucceededResult,
        Func<BetaMessageBatchErroredResultVariant, T> betaMessageBatchErroredResult,
        Func<BetaMessageBatchCanceledResultVariant, T> betaMessageBatchCanceledResult,
        Func<BetaMessageBatchExpiredResultVariant, T> betaMessageBatchExpiredResult
    )
    {
        return this switch
        {
            BetaMessageBatchSucceededResultVariant inner => betaMessageBatchSucceededResult(inner),
            BetaMessageBatchErroredResultVariant inner => betaMessageBatchErroredResult(inner),
            BetaMessageBatchCanceledResultVariant inner => betaMessageBatchCanceledResult(inner),
            BetaMessageBatchExpiredResultVariant inner => betaMessageBatchExpiredResult(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaMessageBatchResultConverter : JsonConverter<BetaMessageBatchResult>
{
    public override BetaMessageBatchResult? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaMessageBatchSucceededResult>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaMessageBatchSucceededResultVariant(deserialized);
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
                        return new BetaMessageBatchErroredResultVariant(deserialized);
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
                        return new BetaMessageBatchCanceledResultVariant(deserialized);
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
                        return new BetaMessageBatchExpiredResultVariant(deserialized);
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
            BetaMessageBatchSucceededResultVariant(var betaMessageBatchSucceededResult) =>
                betaMessageBatchSucceededResult,
            BetaMessageBatchErroredResultVariant(var betaMessageBatchErroredResult) =>
                betaMessageBatchErroredResult,
            BetaMessageBatchCanceledResultVariant(var betaMessageBatchCanceledResult) =>
                betaMessageBatchCanceledResult,
            BetaMessageBatchExpiredResultVariant(var betaMessageBatchExpiredResult) =>
                betaMessageBatchExpiredResult,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
