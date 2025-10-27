using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockParamContentConverter))]
public record class BetaWebSearchToolResultBlockParamContent
{
    public object Value { get; private init; }

    public BetaWebSearchToolResultBlockParamContent(List<BetaWebSearchResultBlockParam> value)
    {
        Value = value;
    }

    public BetaWebSearchToolResultBlockParamContent(BetaWebSearchToolRequestError value)
    {
        Value = value;
    }

    BetaWebSearchToolResultBlockParamContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaWebSearchToolResultBlockParamContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickResultBlock(
        [NotNullWhen(true)] out List<BetaWebSearchResultBlockParam>? value
    )
    {
        value = this.Value as List<BetaWebSearchResultBlockParam>;
        return value != null;
    }

    public bool TryPickRequestError([NotNullWhen(true)] out BetaWebSearchToolRequestError? value)
    {
        value = this.Value as BetaWebSearchToolRequestError;
        return value != null;
    }

    public void Switch(
        Action<List<BetaWebSearchResultBlockParam>> resultBlock,
        Action<BetaWebSearchToolRequestError> requestError
    )
    {
        switch (this.Value)
        {
            case List<BetaWebSearchResultBlockParam> value:
                resultBlock(value);
                break;
            case BetaWebSearchToolRequestError value:
                requestError(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
                );
        }
    }

    public T Match<T>(
        Func<List<BetaWebSearchResultBlockParam>, T> resultBlock,
        Func<BetaWebSearchToolRequestError, T> requestError
    )
    {
        return this.Value switch
        {
            List<BetaWebSearchResultBlockParam> value => resultBlock(value),
            BetaWebSearchToolRequestError value => requestError(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                deserialized.Validate();
                return new BetaWebSearchToolResultBlockParamContent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebSearchToolRequestError'",
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
                return new BetaWebSearchToolResultBlockParamContent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaWebSearchResultBlockParam>'",
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
