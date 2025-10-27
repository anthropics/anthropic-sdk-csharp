using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultBlockParamProperties;

[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaWebFetchToolResultErrorBlockParam: (x) => x.Type,
                betaWebFetchBlockParam: (x) => x.Type
            );
        }
    }

    public Content(BetaWebFetchToolResultErrorBlockParam value)
    {
        Value = value;
    }

    public Content(BetaWebFetchBlockParam value)
    {
        Value = value;
    }

    Content(UnknownVariant value)
    {
        Value = value;
    }

    public static Content CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaWebFetchToolResultErrorBlockParam(
        [NotNullWhen(true)] out BetaWebFetchToolResultErrorBlockParam? value
    )
    {
        value = this.Value as BetaWebFetchToolResultErrorBlockParam;
        return value != null;
    }

    public bool TryPickBetaWebFetchBlockParam([NotNullWhen(true)] out BetaWebFetchBlockParam? value)
    {
        value = this.Value as BetaWebFetchBlockParam;
        return value != null;
    }

    public void Switch(
        Action<BetaWebFetchToolResultErrorBlockParam> betaWebFetchToolResultErrorBlockParam,
        Action<BetaWebFetchBlockParam> betaWebFetchBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaWebFetchToolResultErrorBlockParam value:
                betaWebFetchToolResultErrorBlockParam(value);
                break;
            case BetaWebFetchBlockParam value:
                betaWebFetchBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<BetaWebFetchToolResultErrorBlockParam, T> betaWebFetchToolResultErrorBlockParam,
        Func<BetaWebFetchBlockParam, T> betaWebFetchBlockParam
    )
    {
        return this.Value switch
        {
            BetaWebFetchToolResultErrorBlockParam value => betaWebFetchToolResultErrorBlockParam(
                value
            ),
            BetaWebFetchBlockParam value => betaWebFetchBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchToolResultErrorBlockParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchBlockParam'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
