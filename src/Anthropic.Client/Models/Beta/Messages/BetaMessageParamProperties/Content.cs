using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaMessageParamProperties;

[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public Content(string value)
    {
        Value = value;
    }

    public Content(List<BetaContentBlockParam> value)
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

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBetaContentBlockParams(
        [NotNullWhen(true)] out List<BetaContentBlockParam>? value
    )
    {
        value = this.Value as List<BetaContentBlockParam>;
        return value != null;
    }

    public void Switch(
        Action<string> @string,
        Action<List<BetaContentBlockParam>> betaContentBlockParams
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<BetaContentBlockParam> value:
                betaContentBlockParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<string, T> @string,
        Func<List<BetaContentBlockParam>, T> betaContentBlockParams
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            List<BetaContentBlockParam> value => betaContentBlockParams(value),
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

    record struct UnknownVariant(JsonElement value);
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
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Content(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<BetaContentBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Content(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaContentBlockParam>'",
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
