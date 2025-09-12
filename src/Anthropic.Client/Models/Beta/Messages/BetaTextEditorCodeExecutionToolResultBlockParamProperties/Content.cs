using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultBlockParamProperties.ContentVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultBlockParamProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(
        BetaTextEditorCodeExecutionToolResultErrorParam value
    ) => new ContentVariants::BetaTextEditorCodeExecutionToolResultErrorParam(value);

    public static implicit operator Content(
        BetaTextEditorCodeExecutionViewResultBlockParam value
    ) => new ContentVariants::BetaTextEditorCodeExecutionViewResultBlockParam(value);

    public static implicit operator Content(
        BetaTextEditorCodeExecutionCreateResultBlockParam value
    ) => new ContentVariants::BetaTextEditorCodeExecutionCreateResultBlockParam(value);

    public static implicit operator Content(
        BetaTextEditorCodeExecutionStrReplaceResultBlockParam value
    ) => new ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlockParam(value);

    public bool TryPickBetaTextEditorCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultErrorParam? value
    )
    {
        value = (this as ContentVariants::BetaTextEditorCodeExecutionToolResultErrorParam)?.Value;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionViewResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionViewResultBlockParam? value
    )
    {
        value = (this as ContentVariants::BetaTextEditorCodeExecutionViewResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionCreateResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionCreateResultBlockParam? value
    )
    {
        value = (this as ContentVariants::BetaTextEditorCodeExecutionCreateResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionStrReplaceResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionStrReplaceResultBlockParam? value
    )
    {
        value = (
            this as ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlockParam
        )?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::BetaTextEditorCodeExecutionToolResultErrorParam> betaTextEditorCodeExecutionToolResultErrorParam,
        Action<ContentVariants::BetaTextEditorCodeExecutionViewResultBlockParam> betaTextEditorCodeExecutionViewResultBlockParam,
        Action<ContentVariants::BetaTextEditorCodeExecutionCreateResultBlockParam> betaTextEditorCodeExecutionCreateResultBlockParam,
        Action<ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlockParam> betaTextEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        switch (this)
        {
            case ContentVariants::BetaTextEditorCodeExecutionToolResultErrorParam inner:
                betaTextEditorCodeExecutionToolResultErrorParam(inner);
                break;
            case ContentVariants::BetaTextEditorCodeExecutionViewResultBlockParam inner:
                betaTextEditorCodeExecutionViewResultBlockParam(inner);
                break;
            case ContentVariants::BetaTextEditorCodeExecutionCreateResultBlockParam inner:
                betaTextEditorCodeExecutionCreateResultBlockParam(inner);
                break;
            case ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlockParam inner:
                betaTextEditorCodeExecutionStrReplaceResultBlockParam(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            ContentVariants::BetaTextEditorCodeExecutionToolResultErrorParam,
            T
        > betaTextEditorCodeExecutionToolResultErrorParam,
        Func<
            ContentVariants::BetaTextEditorCodeExecutionViewResultBlockParam,
            T
        > betaTextEditorCodeExecutionViewResultBlockParam,
        Func<
            ContentVariants::BetaTextEditorCodeExecutionCreateResultBlockParam,
            T
        > betaTextEditorCodeExecutionCreateResultBlockParam,
        Func<
            ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlockParam,
            T
        > betaTextEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        return this switch
        {
            ContentVariants::BetaTextEditorCodeExecutionToolResultErrorParam inner =>
                betaTextEditorCodeExecutionToolResultErrorParam(inner),
            ContentVariants::BetaTextEditorCodeExecutionViewResultBlockParam inner =>
                betaTextEditorCodeExecutionViewResultBlockParam(inner),
            ContentVariants::BetaTextEditorCodeExecutionCreateResultBlockParam inner =>
                betaTextEditorCodeExecutionCreateResultBlockParam(inner),
            ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlockParam inner =>
                betaTextEditorCodeExecutionStrReplaceResultBlockParam(inner),
            _ => throw new InvalidOperationException(),
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
        List<JsonException> exceptions = [];

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultErrorParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new ContentVariants::BetaTextEditorCodeExecutionToolResultErrorParam(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlockParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new ContentVariants::BetaTextEditorCodeExecutionViewResultBlockParam(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlockParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new ContentVariants::BetaTextEditorCodeExecutionCreateResultBlockParam(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionStrReplaceResultBlockParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlockParam(
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

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::BetaTextEditorCodeExecutionToolResultErrorParam(
                var betaTextEditorCodeExecutionToolResultErrorParam
            ) => betaTextEditorCodeExecutionToolResultErrorParam,
            ContentVariants::BetaTextEditorCodeExecutionViewResultBlockParam(
                var betaTextEditorCodeExecutionViewResultBlockParam
            ) => betaTextEditorCodeExecutionViewResultBlockParam,
            ContentVariants::BetaTextEditorCodeExecutionCreateResultBlockParam(
                var betaTextEditorCodeExecutionCreateResultBlockParam
            ) => betaTextEditorCodeExecutionCreateResultBlockParam,
            ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlockParam(
                var betaTextEditorCodeExecutionStrReplaceResultBlockParam
            ) => betaTextEditorCodeExecutionStrReplaceResultBlockParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
