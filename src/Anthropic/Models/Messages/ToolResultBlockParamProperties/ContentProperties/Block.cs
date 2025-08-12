using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BlockVariants = Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties.BlockVariants;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties;

[JsonConverter(typeof(BlockConverter))]
public abstract record class Block
{
    internal Block() { }

    public static implicit operator Block(Messages::TextBlockParam value) =>
        new BlockVariants::TextBlockParamVariant(value);

    public static implicit operator Block(Messages::ImageBlockParam value) =>
        new BlockVariants::ImageBlockParamVariant(value);

    public static implicit operator Block(Messages::SearchResultBlockParam value) =>
        new BlockVariants::SearchResultBlockParamVariant(value);

    public abstract void Validate();
}

sealed class BlockConverter : JsonConverter<Block>
{
    public override Block? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::TextBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BlockVariants::TextBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::ImageBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BlockVariants::ImageBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::SearchResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BlockVariants::SearchResultBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Block value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            BlockVariants::TextBlockParamVariant(var textBlockParam) => textBlockParam,
            BlockVariants::ImageBlockParamVariant(var imageBlockParam) => imageBlockParam,
            BlockVariants::SearchResultBlockParamVariant(var searchResultBlockParam) =>
                searchResultBlockParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
