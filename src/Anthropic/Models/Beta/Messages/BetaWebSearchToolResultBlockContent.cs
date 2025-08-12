using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaWebSearchToolResultBlockContentVariants = Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockContentConverter))]
public abstract record class BetaWebSearchToolResultBlockContent
{
    internal BetaWebSearchToolResultBlockContent() { }

    public static implicit operator BetaWebSearchToolResultBlockContent(
        BetaWebSearchToolResultError value
    ) =>
        new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultErrorVariant(value);

    public static implicit operator BetaWebSearchToolResultBlockContent(
        List<BetaWebSearchResultBlock> value
    ) => new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks(value);

    public abstract void Validate();
}

sealed class BetaWebSearchToolResultBlockContentConverter
    : JsonConverter<BetaWebSearchToolResultBlockContent>
{
    public override BetaWebSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultErrorVariant(
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
            var deserialized = JsonSerializer.Deserialize<List<BetaWebSearchResultBlock>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks(
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
        BetaWebSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultErrorVariant(
                var betaWebSearchToolResultError
            ) => betaWebSearchToolResultError,
            BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks(
                var betaWebSearchResultBlocks
            ) => betaWebSearchResultBlocks,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
