using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaCodeExecutionToolResultBlockParamContentVariants = Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockParamContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultBlockParamContentConverter))]
public abstract record class BetaCodeExecutionToolResultBlockParamContent
{
    internal BetaCodeExecutionToolResultBlockParamContent() { }

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionToolResultErrorParam value
    ) =>
        new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParam(
            value
        );

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionResultBlockParam value
    ) =>
        new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParam(
            value
        );

    public bool TryPickErrorParam(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultErrorParam? value
    )
    {
        value = (
            this
            as BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParam
        )?.Value;
        return value != null;
    }

    public bool TryPickResultBlockParam(
        [NotNullWhen(true)] out BetaCodeExecutionResultBlockParam? value
    )
    {
        value = (
            this
            as BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParam
        )?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParam> errorParam,
        Action<BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParam> resultBlockParam
    )
    {
        switch (this)
        {
            case BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParam inner:
                errorParam(inner);
                break;
            case BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParam inner:
                resultBlockParam(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParam,
            T
        > errorParam,
        Func<
            BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParam,
            T
        > resultBlockParam
    )
    {
        return this switch
        {
            BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParam inner =>
                errorParam(inner),
            BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParam inner =>
                resultBlockParam(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaCodeExecutionToolResultBlockParamContentConverter
    : JsonConverter<BetaCodeExecutionToolResultBlockParamContent>
{
    public override BetaCodeExecutionToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultErrorParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParam(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParam(
                    deserialized
                );
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
        BetaCodeExecutionToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParam(
                var errorParam
            ) => errorParam,
            BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParam(
                var resultBlockParam
            ) => resultBlockParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
