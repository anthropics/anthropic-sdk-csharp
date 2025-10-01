using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using BetaWebSearchToolResultBlockParamContentVariants = Anthropic.Client.Models.Beta.Messages.BetaWebSearchToolResultBlockParamContentVariants;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockParamContentConverter))]
public abstract record class BetaWebSearchToolResultBlockParamContent
{
    internal BetaWebSearchToolResultBlockParamContent() { }

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        List<BetaWebSearchResultBlockParam> value
    ) => new BetaWebSearchToolResultBlockParamContentVariants::ResultBlock(value);

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        BetaWebSearchToolRequestError value
    ) => new BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError(value);

    public bool TryPickResultBlock(
        [NotNullWhen(true)] out List<BetaWebSearchResultBlockParam>? value
    )
    {
        value = (this as BetaWebSearchToolResultBlockParamContentVariants::ResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickRequestError([NotNullWhen(true)] out BetaWebSearchToolRequestError? value)
    {
        value = (
            this as BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError
        )?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaWebSearchToolResultBlockParamContentVariants::ResultBlock> resultBlock,
        Action<BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError> requestError
    )
    {
        switch (this)
        {
            case BetaWebSearchToolResultBlockParamContentVariants::ResultBlock inner:
                resultBlock(inner);
                break;
            case BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError inner:
                requestError(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
                );
        }
    }

    public T Match<T>(
        Func<BetaWebSearchToolResultBlockParamContentVariants::ResultBlock, T> resultBlock,
        Func<
            BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError,
            T
        > requestError
    )
    {
        return this switch
        {
            BetaWebSearchToolResultBlockParamContentVariants::ResultBlock inner => resultBlock(
                inner
            ),
            BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError inner =>
                requestError(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
            ),
        };
    }

    public abstract void Validate();
}

sealed class BetaWebSearchToolResultBlockParamContentConverter
    : JsonConverter<BetaWebSearchToolResultBlockParamContent>
{
    public override BetaWebSearchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolRequestError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError",
                    e
                )
            );
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
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant BetaWebSearchToolResultBlockParamContentVariants::ResultBlock",
                    e
                )
            );
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
            BetaWebSearchToolResultBlockParamContentVariants::ResultBlock(var resultBlock) =>
                resultBlock,
            BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError(
                var requestError
            ) => requestError,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
