using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties.BlockVariants;

namespace Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties;

[JsonConverter(typeof(BlockConverter))]
public abstract record class Block
{
    internal Block() { }

    public static implicit operator Block(BetaTextBlockParam value) =>
        new BetaTextBlockParamVariant(value);

    public static implicit operator Block(BetaImageBlockParam value) =>
        new BetaImageBlockParamVariant(value);

    public static implicit operator Block(BetaSearchResultBlockParam value) =>
        new BetaSearchResultBlockParamVariant(value);

    public bool TryPickBetaTextBlockParamVariant([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = (this as BetaTextBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaImageBlockParamVariant(
        [NotNullWhen(true)] out BetaImageBlockParam? value
    )
    {
        value = (this as BetaImageBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaSearchResultBlockParamVariant(
        [NotNullWhen(true)] out BetaSearchResultBlockParam? value
    )
    {
        value = (this as BetaSearchResultBlockParamVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaTextBlockParamVariant> betaTextBlockParam,
        Action<BetaImageBlockParamVariant> betaImageBlockParam,
        Action<BetaSearchResultBlockParamVariant> betaSearchResultBlockParam
    )
    {
        switch (this)
        {
            case BetaTextBlockParamVariant inner:
                betaTextBlockParam(inner);
                break;
            case BetaImageBlockParamVariant inner:
                betaImageBlockParam(inner);
                break;
            case BetaSearchResultBlockParamVariant inner:
                betaSearchResultBlockParam(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaTextBlockParamVariant, T> betaTextBlockParam,
        Func<BetaImageBlockParamVariant, T> betaImageBlockParam,
        Func<BetaSearchResultBlockParamVariant, T> betaSearchResultBlockParam
    )
    {
        return this switch
        {
            BetaTextBlockParamVariant inner => betaTextBlockParam(inner),
            BetaImageBlockParamVariant inner => betaImageBlockParam(inner),
            BetaSearchResultBlockParamVariant inner => betaSearchResultBlockParam(inner),
            _ => throw new InvalidOperationException(),
        };
    }

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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextBlockParamVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaImageBlockParamVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaSearchResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaSearchResultBlockParamVariant(deserialized);
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
            BetaTextBlockParamVariant(var betaTextBlockParam) => betaTextBlockParam,
            BetaImageBlockParamVariant(var betaImageBlockParam) => betaImageBlockParam,
            BetaSearchResultBlockParamVariant(var betaSearchResultBlockParam) =>
                betaSearchResultBlockParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
