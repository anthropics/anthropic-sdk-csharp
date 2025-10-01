using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using ContentVariants = Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultBlockParamProperties.ContentVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultBlockParamProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(BetaBashCodeExecutionToolResultErrorParam value) =>
        new ContentVariants::BetaBashCodeExecutionToolResultErrorParam(value);

    public static implicit operator Content(BetaBashCodeExecutionResultBlockParam value) =>
        new ContentVariants::BetaBashCodeExecutionResultBlockParam(value);

    public bool TryPickBetaBashCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultErrorParam? value
    )
    {
        value = (this as ContentVariants::BetaBashCodeExecutionToolResultErrorParam)?.Value;
        return value != null;
    }

    public bool TryPickBetaBashCodeExecutionResultBlockParam(
        [NotNullWhen(true)] out BetaBashCodeExecutionResultBlockParam? value
    )
    {
        value = (this as ContentVariants::BetaBashCodeExecutionResultBlockParam)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::BetaBashCodeExecutionToolResultErrorParam> betaBashCodeExecutionToolResultErrorParam,
        Action<ContentVariants::BetaBashCodeExecutionResultBlockParam> betaBashCodeExecutionResultBlockParam
    )
    {
        switch (this)
        {
            case ContentVariants::BetaBashCodeExecutionToolResultErrorParam inner:
                betaBashCodeExecutionToolResultErrorParam(inner);
                break;
            case ContentVariants::BetaBashCodeExecutionResultBlockParam inner:
                betaBashCodeExecutionResultBlockParam(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<
            ContentVariants::BetaBashCodeExecutionToolResultErrorParam,
            T
        > betaBashCodeExecutionToolResultErrorParam,
        Func<
            ContentVariants::BetaBashCodeExecutionResultBlockParam,
            T
        > betaBashCodeExecutionResultBlockParam
    )
    {
        return this switch
        {
            ContentVariants::BetaBashCodeExecutionToolResultErrorParam inner =>
                betaBashCodeExecutionToolResultErrorParam(inner),
            ContentVariants::BetaBashCodeExecutionResultBlockParam inner =>
                betaBashCodeExecutionResultBlockParam(inner),
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
            var deserialized =
                JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultErrorParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new ContentVariants::BetaBashCodeExecutionToolResultErrorParam(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ContentVariants::BetaBashCodeExecutionToolResultErrorParam",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentVariants::BetaBashCodeExecutionResultBlockParam(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ContentVariants::BetaBashCodeExecutionResultBlockParam",
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
            ContentVariants::BetaBashCodeExecutionToolResultErrorParam(
                var betaBashCodeExecutionToolResultErrorParam
            ) => betaBashCodeExecutionToolResultErrorParam,
            ContentVariants::BetaBashCodeExecutionResultBlockParam(
                var betaBashCodeExecutionResultBlockParam
            ) => betaBashCodeExecutionResultBlockParam,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
