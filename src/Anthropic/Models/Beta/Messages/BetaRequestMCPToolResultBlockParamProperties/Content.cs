using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Models.Beta.Messages.BetaRequestMCPToolResultBlockParamProperties.ContentVariants;

namespace Anthropic.Models.Beta.Messages.BetaRequestMCPToolResultBlockParamProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<BetaTextBlockParam> value) =>
        new ContentVariants::BetaMCPToolResultBlockParamContent(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as ContentVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickBetaMCPToolResultBlockParam(
        [NotNullWhen(true)] out List<BetaTextBlockParam>? value
    )
    {
        value = (this as ContentVariants::BetaMCPToolResultBlockParamContent)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::String> @string,
        Action<ContentVariants::BetaMCPToolResultBlockParamContent> betaMCPToolResultBlockParamContent
    )
    {
        switch (this)
        {
            case ContentVariants::String inner:
                @string(inner);
                break;
            case ContentVariants::BetaMCPToolResultBlockParamContent inner:
                betaMCPToolResultBlockParamContent(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ContentVariants::String, T> @string,
        Func<
            ContentVariants::BetaMCPToolResultBlockParamContent,
            T
        > betaMCPToolResultBlockParamContent
    )
    {
        return this switch
        {
            ContentVariants::String inner => @string(inner),
            ContentVariants::BetaMCPToolResultBlockParamContent inner =>
                betaMCPToolResultBlockParamContent(inner),
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
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<BetaTextBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentVariants::BetaMCPToolResultBlockParamContent(deserialized);
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
            ContentVariants::String(var @string) => @string,
            ContentVariants::BetaMCPToolResultBlockParamContent(
                var betaMCPToolResultBlockParamContent
            ) => betaMCPToolResultBlockParamContent,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
