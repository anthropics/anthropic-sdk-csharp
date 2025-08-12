using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaCodeExecutionToolResultBlockContentVariants = Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultBlockContentConverter))]
public abstract record class BetaCodeExecutionToolResultBlockContent
{
    internal BetaCodeExecutionToolResultBlockContent() { }

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionToolResultError value
    ) =>
        new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultErrorVariant(
            value
        );

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionResultBlock value
    ) =>
        new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlockVariant(
            value
        );

    public abstract void Validate();
}

sealed class BetaCodeExecutionToolResultBlockContentConverter
    : JsonConverter<BetaCodeExecutionToolResultBlockContent>
{
    public override BetaCodeExecutionToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultErrorVariant(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlockVariant(
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

    public override void Write(
        Utf8JsonWriter writer,
        BetaCodeExecutionToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultErrorVariant(
                var betaCodeExecutionToolResultError
            ) => betaCodeExecutionToolResultError,
            BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlockVariant(
                var betaCodeExecutionResultBlock
            ) => betaCodeExecutionResultBlock,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
