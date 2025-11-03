using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultBlockParamProperties;

[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaTextEditorCodeExecutionToolResultErrorParam: (x) => x.Type,
                betaTextEditorCodeExecutionViewResultBlockParam: (x) => x.Type,
                betaTextEditorCodeExecutionCreateResultBlockParam: (x) => x.Type,
                betaTextEditorCodeExecutionStrReplaceResultBlockParam: (x) => x.Type
            );
        }
    }

    public Content(BetaTextEditorCodeExecutionToolResultErrorParam value)
    {
        Value = value;
    }

    public Content(BetaTextEditorCodeExecutionViewResultBlockParam value)
    {
        Value = value;
    }

    public Content(BetaTextEditorCodeExecutionCreateResultBlockParam value)
    {
        Value = value;
    }

    public Content(BetaTextEditorCodeExecutionStrReplaceResultBlockParam value)
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

    public bool TryPickBetaTextEditorCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultErrorParam;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionViewResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionViewResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionViewResultBlockParam;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionCreateResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionCreateResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionCreateResultBlockParam;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionStrReplaceResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionStrReplaceResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionStrReplaceResultBlockParam;
        return value != null;
    }

    public void Switch(
        Action<BetaTextEditorCodeExecutionToolResultErrorParam> betaTextEditorCodeExecutionToolResultErrorParam,
        Action<BetaTextEditorCodeExecutionViewResultBlockParam> betaTextEditorCodeExecutionViewResultBlockParam,
        Action<BetaTextEditorCodeExecutionCreateResultBlockParam> betaTextEditorCodeExecutionCreateResultBlockParam,
        Action<BetaTextEditorCodeExecutionStrReplaceResultBlockParam> betaTextEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaTextEditorCodeExecutionToolResultErrorParam value:
                betaTextEditorCodeExecutionToolResultErrorParam(value);
                break;
            case BetaTextEditorCodeExecutionViewResultBlockParam value:
                betaTextEditorCodeExecutionViewResultBlockParam(value);
                break;
            case BetaTextEditorCodeExecutionCreateResultBlockParam value:
                betaTextEditorCodeExecutionCreateResultBlockParam(value);
                break;
            case BetaTextEditorCodeExecutionStrReplaceResultBlockParam value:
                betaTextEditorCodeExecutionStrReplaceResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<
            BetaTextEditorCodeExecutionToolResultErrorParam,
            T
        > betaTextEditorCodeExecutionToolResultErrorParam,
        Func<
            BetaTextEditorCodeExecutionViewResultBlockParam,
            T
        > betaTextEditorCodeExecutionViewResultBlockParam,
        Func<
            BetaTextEditorCodeExecutionCreateResultBlockParam,
            T
        > betaTextEditorCodeExecutionCreateResultBlockParam,
        Func<
            BetaTextEditorCodeExecutionStrReplaceResultBlockParam,
            T
        > betaTextEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        return this.Value switch
        {
            BetaTextEditorCodeExecutionToolResultErrorParam value =>
                betaTextEditorCodeExecutionToolResultErrorParam(value),
            BetaTextEditorCodeExecutionViewResultBlockParam value =>
                betaTextEditorCodeExecutionViewResultBlockParam(value),
            BetaTextEditorCodeExecutionCreateResultBlockParam value =>
                betaTextEditorCodeExecutionCreateResultBlockParam(value),
            BetaTextEditorCodeExecutionStrReplaceResultBlockParam value =>
                betaTextEditorCodeExecutionStrReplaceResultBlockParam(value),
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultErrorParam>(
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
                    "Data does not match union variant 'BetaTextEditorCodeExecutionToolResultErrorParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlockParam>(
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
                    "Data does not match union variant 'BetaTextEditorCodeExecutionViewResultBlockParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlockParam>(
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
                    "Data does not match union variant 'BetaTextEditorCodeExecutionCreateResultBlockParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionStrReplaceResultBlockParam>(
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
                    "Data does not match union variant 'BetaTextEditorCodeExecutionStrReplaceResultBlockParam'",
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
