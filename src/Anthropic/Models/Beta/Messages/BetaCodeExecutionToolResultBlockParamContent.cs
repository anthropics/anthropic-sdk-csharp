using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaCodeExecutionToolResultBlockParamContentVariants = Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockParamContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultBlockParamContentConverter))]
public abstract record class BetaCodeExecutionToolResultBlockParamContent
{
    internal BetaCodeExecutionToolResultBlockParamContent() { }

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionToolResultErrorParam value
    ) =>
        new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParamVariant(
            value
        );

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionResultBlockParam value
    ) =>
        new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParamVariant(
            value
        );

    public abstract void Validate();
}

sealed class BetaCodeExecutionToolResultBlockParamContentConverter
    : JsonConverter<BetaCodeExecutionToolResultBlockParamContent>
{
    public override BetaCodeExecutionToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultErrorParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParamVariant(
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
        BetaCodeExecutionToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParamVariant(
                var betaCodeExecutionToolResultErrorParam
            ) => betaCodeExecutionToolResultErrorParam,
            BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParamVariant(
                var betaCodeExecutionResultBlockParam
            ) => betaCodeExecutionResultBlockParam,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
