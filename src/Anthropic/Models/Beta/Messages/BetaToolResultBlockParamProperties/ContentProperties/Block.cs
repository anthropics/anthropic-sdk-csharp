using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BlockVariants = Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties.BlockVariants;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties;

[JsonConverter(typeof(BlockConverter))]
public abstract record class Block
{
    internal Block() { }

    public static implicit operator Block(Messages::BetaTextBlockParam value) =>
        new BlockVariants::BetaTextBlockParamVariant(value);

    public static implicit operator Block(Messages::BetaImageBlockParam value) =>
        new BlockVariants::BetaImageBlockParamVariant(value);

    public static implicit operator Block(Messages::BetaSearchResultBlockParam value) =>
        new BlockVariants::BetaSearchResultBlockParamVariant(value);

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
            case "text":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Messages::BetaTextBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BlockVariants::BetaTextBlockParamVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "image":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Messages::BetaImageBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BlockVariants::BetaImageBlockParamVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "search_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::BetaSearchResultBlockParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BlockVariants::BetaSearchResultBlockParamVariant(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Block value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            BlockVariants::BetaTextBlockParamVariant(var betaTextBlockParam) => betaTextBlockParam,
            BlockVariants::BetaImageBlockParamVariant(var betaImageBlockParam) =>
                betaImageBlockParam,
            BlockVariants::BetaSearchResultBlockParamVariant(var betaSearchResultBlockParam) =>
                betaSearchResultBlockParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
