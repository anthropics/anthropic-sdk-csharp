using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultBlockParamProperties;

[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaBashCodeExecutionToolResultErrorParam: (x) => x.Type,
                betaBashCodeExecutionResultBlockParam: (x) => x.Type
            );
        }
    }

    public Content(BetaBashCodeExecutionToolResultErrorParam value)
    {
        Value = value;
    }

    public Content(BetaBashCodeExecutionResultBlockParam value)
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

    public bool TryPickBetaBashCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as BetaBashCodeExecutionToolResultErrorParam;
        return value != null;
    }

    public bool TryPickBetaBashCodeExecutionResultBlockParam(
        [NotNullWhen(true)] out BetaBashCodeExecutionResultBlockParam? value
    )
    {
        value = this.Value as BetaBashCodeExecutionResultBlockParam;
        return value != null;
    }

    public void Switch(
        Action<BetaBashCodeExecutionToolResultErrorParam> betaBashCodeExecutionToolResultErrorParam,
        Action<BetaBashCodeExecutionResultBlockParam> betaBashCodeExecutionResultBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaBashCodeExecutionToolResultErrorParam value:
                betaBashCodeExecutionToolResultErrorParam(value);
                break;
            case BetaBashCodeExecutionResultBlockParam value:
                betaBashCodeExecutionResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<
            BetaBashCodeExecutionToolResultErrorParam,
            T
        > betaBashCodeExecutionToolResultErrorParam,
        Func<BetaBashCodeExecutionResultBlockParam, T> betaBashCodeExecutionResultBlockParam
    )
    {
        return this.Value switch
        {
            BetaBashCodeExecutionToolResultErrorParam value =>
                betaBashCodeExecutionToolResultErrorParam(value),
            BetaBashCodeExecutionResultBlockParam value => betaBashCodeExecutionResultBlockParam(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
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
            var deserialized =
                JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultErrorParam>(
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
                    "Data does not match union variant 'BetaBashCodeExecutionToolResultErrorParam'",
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
                deserialized.Validate();
                return new Content(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaBashCodeExecutionResultBlockParam'",
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
