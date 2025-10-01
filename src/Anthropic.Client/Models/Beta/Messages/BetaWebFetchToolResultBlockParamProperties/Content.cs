using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using ContentVariants = Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultBlockParamProperties.ContentVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultBlockParamProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(BetaWebFetchToolResultErrorBlockParam value) =>
        new ContentVariants::BetaWebFetchToolResultErrorBlockParam(value);

    public static implicit operator Content(BetaWebFetchBlockParam value) =>
        new ContentVariants::BetaWebFetchBlockParam(value);

    public bool TryPickBetaWebFetchToolResultErrorBlockParam(
        [NotNullWhen(true)] out BetaWebFetchToolResultErrorBlockParam? value
    )
    {
        value = (this as ContentVariants::BetaWebFetchToolResultErrorBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebFetchBlockParam([NotNullWhen(true)] out BetaWebFetchBlockParam? value)
    {
        value = (this as ContentVariants::BetaWebFetchBlockParam)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::BetaWebFetchToolResultErrorBlockParam> betaWebFetchToolResultErrorBlockParam,
        Action<ContentVariants::BetaWebFetchBlockParam> betaWebFetchBlockParam
    )
    {
        switch (this)
        {
            case ContentVariants::BetaWebFetchToolResultErrorBlockParam inner:
                betaWebFetchToolResultErrorBlockParam(inner);
                break;
            case ContentVariants::BetaWebFetchBlockParam inner:
                betaWebFetchBlockParam(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<
            ContentVariants::BetaWebFetchToolResultErrorBlockParam,
            T
        > betaWebFetchToolResultErrorBlockParam,
        Func<ContentVariants::BetaWebFetchBlockParam, T> betaWebFetchBlockParam
    )
    {
        return this switch
        {
            ContentVariants::BetaWebFetchToolResultErrorBlockParam inner =>
                betaWebFetchToolResultErrorBlockParam(inner),
            ContentVariants::BetaWebFetchBlockParam inner => betaWebFetchBlockParam(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public abstract void Validate();
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
                return new ContentVariants::BetaWebFetchToolResultErrorBlockParam(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ContentVariants::BetaWebFetchToolResultErrorBlockParam",
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
                return new ContentVariants::BetaWebFetchBlockParam(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ContentVariants::BetaWebFetchBlockParam",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::BetaWebFetchToolResultErrorBlockParam(
                var betaWebFetchToolResultErrorBlockParam
            ) => betaWebFetchToolResultErrorBlockParam,
            ContentVariants::BetaWebFetchBlockParam(var betaWebFetchBlockParam) =>
                betaWebFetchBlockParam,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
