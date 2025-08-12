using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebSearchToolResultBlockContentVariants = Anthropic.Models.Messages.WebSearchToolResultBlockContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockContentConverter))]
public abstract record class WebSearchToolResultBlockContent
{
    internal WebSearchToolResultBlockContent() { }

    public static implicit operator WebSearchToolResultBlockContent(
        WebSearchToolResultError value
    ) => new WebSearchToolResultBlockContentVariants::WebSearchToolResultErrorVariant(value);

    public static implicit operator WebSearchToolResultBlockContent(
        List<WebSearchResultBlock> value
    ) => new WebSearchToolResultBlockContentVariants::WebSearchResultBlocks(value);

    public abstract void Validate();
}

sealed class WebSearchToolResultBlockContentConverter
    : JsonConverter<WebSearchToolResultBlockContent>
{
    public override WebSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockContentVariants::WebSearchToolResultErrorVariant(
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
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlock>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockContentVariants::WebSearchResultBlocks(
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
        WebSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            WebSearchToolResultBlockContentVariants::WebSearchToolResultErrorVariant(
                var webSearchToolResultError
            ) => webSearchToolResultError,
            WebSearchToolResultBlockContentVariants::WebSearchResultBlocks(
                var webSearchResultBlocks
            ) => webSearchResultBlocks,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
