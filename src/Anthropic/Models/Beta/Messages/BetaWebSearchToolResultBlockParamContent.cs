using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaWebSearchToolResultBlockParamContentVariants = Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockParamContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockParamContentConverter))]
public abstract record class BetaWebSearchToolResultBlockParamContent
{
    internal BetaWebSearchToolResultBlockParamContent() { }

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        List<BetaWebSearchResultBlockParam> value
    ) => new BetaWebSearchToolResultBlockParamContentVariants::ResultBlock(value);

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        BetaWebSearchToolRequestError value
    ) =>
        new BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestErrorVariant(
            value
        );

    public abstract void Validate();
}

sealed class BetaWebSearchToolResultBlockParamContentConverter
    : JsonConverter<BetaWebSearchToolResultBlockParamContent>
{
    public override BetaWebSearchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolRequestError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestErrorVariant(
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
            var deserialized = JsonSerializer.Deserialize<List<BetaWebSearchResultBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchToolResultBlockParamContentVariants::ResultBlock(
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
        BetaWebSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaWebSearchToolResultBlockParamContentVariants::ResultBlock(var resultBlock) =>
                resultBlock,
            BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestErrorVariant(
                var betaWebSearchToolRequestError
            ) => betaWebSearchToolRequestError,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
