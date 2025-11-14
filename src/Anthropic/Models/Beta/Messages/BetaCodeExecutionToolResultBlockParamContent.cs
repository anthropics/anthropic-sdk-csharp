using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultBlockParamContentConverter))]
public record class BetaCodeExecutionToolResultBlockParamContent
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(errorParam: (x) => x.Type, resultBlockParam: (x) => x.Type); }
    }

    public BetaCodeExecutionToolResultBlockParamContent(BetaCodeExecutionToolResultErrorParam value)
    {
        Value = value;
    }

    public BetaCodeExecutionToolResultBlockParamContent(BetaCodeExecutionResultBlockParam value)
    {
        Value = value;
    }

    BetaCodeExecutionToolResultBlockParamContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaCodeExecutionToolResultBlockParamContent CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickErrorParam(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as BetaCodeExecutionToolResultErrorParam;
        return value != null;
    }

    public bool TryPickResultBlockParam(
        [NotNullWhen(true)] out BetaCodeExecutionResultBlockParam? value
    )
    {
        value = this.Value as BetaCodeExecutionResultBlockParam;
        return value != null;
    }

    public void Switch(
        System::Action<BetaCodeExecutionToolResultErrorParam> errorParam,
        System::Action<BetaCodeExecutionResultBlockParam> resultBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaCodeExecutionToolResultErrorParam value:
                errorParam(value);
                break;
            case BetaCodeExecutionResultBlockParam value:
                resultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaCodeExecutionToolResultBlockParamContent"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaCodeExecutionToolResultErrorParam, T> errorParam,
        System::Func<BetaCodeExecutionResultBlockParam, T> resultBlockParam
    )
    {
        return this.Value switch
        {
            BetaCodeExecutionToolResultErrorParam value => errorParam(value),
            BetaCodeExecutionResultBlockParam value => resultBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCodeExecutionToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionToolResultErrorParam value
    ) => new(value);

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionResultBlockParam value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCodeExecutionToolResultBlockParamContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BetaCodeExecutionToolResultBlockParamContentConverter
    : JsonConverter<BetaCodeExecutionToolResultBlockParamContent>
{
    public override BetaCodeExecutionToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultErrorParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaCodeExecutionToolResultBlockParamContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaCodeExecutionToolResultErrorParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaCodeExecutionToolResultBlockParamContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaCodeExecutionResultBlockParam'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaCodeExecutionToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
