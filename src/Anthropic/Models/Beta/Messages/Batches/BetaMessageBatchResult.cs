using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaMessageBatchResultVariants = Anthropic.Models.Beta.Messages.Batches.BetaMessageBatchResultVariants;

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
        new BetaMessageBatchResultVariants::BetaMessageBatchSucceededResultVariant(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchErroredResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchErroredResultVariant(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchCanceledResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchCanceledResultVariant(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchExpiredResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchExpiredResultVariant(value);

    public abstract void Validate();
}

sealed class BetaMessageBatchResultConverter : JsonConverter<BetaMessageBatchResult>
{
    public override BetaMessageBatchResult? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
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
                        return new BetaMessageBatchResultVariants::BetaMessageBatchSucceededResultVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaMessageBatchResultVariants::BetaMessageBatchErroredResultVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaMessageBatchResultVariants::BetaMessageBatchCanceledResultVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaMessageBatchResultVariants::BetaMessageBatchExpiredResultVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            default:
            {
                throw new global::System.Exception();
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
            BetaMessageBatchResultVariants::BetaMessageBatchSucceededResultVariant(
                var betaMessageBatchSucceededResult
            ) => betaMessageBatchSucceededResult,
            BetaMessageBatchResultVariants::BetaMessageBatchErroredResultVariant(
                var betaMessageBatchErroredResult
            ) => betaMessageBatchErroredResult,
            BetaMessageBatchResultVariants::BetaMessageBatchCanceledResultVariant(
                var betaMessageBatchCanceledResult
            ) => betaMessageBatchCanceledResult,
            BetaMessageBatchResultVariants::BetaMessageBatchExpiredResultVariant(
                var betaMessageBatchExpiredResult
            ) => betaMessageBatchExpiredResult,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
