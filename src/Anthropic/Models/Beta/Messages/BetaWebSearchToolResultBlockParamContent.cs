using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockParamContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockParamContentConverter))]
public abstract record class BetaWebSearchToolResultBlockParamContent
{
    internal BetaWebSearchToolResultBlockParamContent() { }

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        List<BetaWebSearchResultBlockParam> value
    ) => new ResultBlock(value);

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        BetaWebSearchToolRequestError value
    ) => new BetaWebSearchToolRequestErrorVariant(value);

    public bool TryPickResultBlock(
        [NotNullWhen(true)] out List<BetaWebSearchResultBlockParam>? value
    )
    {
        value = (this as ResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebSearchToolRequestErrorVariant(
        [NotNullWhen(true)] out BetaWebSearchToolRequestError? value
    )
    {
        value = (this as BetaWebSearchToolRequestErrorVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ResultBlock> resultBlock,
        Action<BetaWebSearchToolRequestErrorVariant> betaWebSearchToolRequestError
    )
    {
        switch (this)
        {
            case ResultBlock inner:
                resultBlock(inner);
                break;
            case BetaWebSearchToolRequestErrorVariant inner:
                betaWebSearchToolRequestError(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ResultBlock, T> resultBlock,
        Func<BetaWebSearchToolRequestErrorVariant, T> betaWebSearchToolRequestError
    )
    {
        return this switch
        {
            ResultBlock inner => resultBlock(inner),
            BetaWebSearchToolRequestErrorVariant inner => betaWebSearchToolRequestError(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaWebSearchToolResultBlockParamContentConverter
    : JsonConverter<BetaWebSearchToolResultBlockParamContent>
{
    public override BetaWebSearchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
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
                return new BetaWebSearchToolRequestErrorVariant(deserialized);
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
                return new ResultBlock(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ResultBlock(var resultBlock) => resultBlock,
            BetaWebSearchToolRequestErrorVariant(var betaWebSearchToolRequestError) =>
                betaWebSearchToolRequestError,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
