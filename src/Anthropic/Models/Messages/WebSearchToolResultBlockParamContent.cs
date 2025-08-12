using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebSearchToolResultBlockParamContentVariants = Anthropic.Models.Messages.WebSearchToolResultBlockParamContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockParamContentConverter))]
public abstract record class WebSearchToolResultBlockParamContent
{
    internal WebSearchToolResultBlockParamContent() { }

    public static implicit operator WebSearchToolResultBlockParamContent(
        List<WebSearchResultBlockParam> value
    ) => new WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem(value);

    public static implicit operator WebSearchToolResultBlockParamContent(
        WebSearchToolRequestError value
    ) => new WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestErrorVariant(value);

    public abstract void Validate();
}

sealed class WebSearchToolResultBlockParamContentConverter
    : JsonConverter<WebSearchToolResultBlockParamContent>
{
    public override WebSearchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolRequestError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestErrorVariant(
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
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem(
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
        WebSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem(
                var webSearchToolResultBlockItem
            ) => webSearchToolResultBlockItem,
            WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestErrorVariant(
                var webSearchToolRequestError
            ) => webSearchToolRequestError,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
