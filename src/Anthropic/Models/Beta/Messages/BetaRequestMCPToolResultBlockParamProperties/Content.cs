using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Models.Beta.Messages.BetaRequestMCPToolResultBlockParamProperties.ContentVariants;
using Messages = Anthropic.Models.Beta.Messages;
using System = System;

namespace Anthropic.Models.Beta.Messages.BetaRequestMCPToolResultBlockParamProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<Messages::BetaTextBlockParam> value) =>
        new ContentVariants::BetaMCPToolResultBlockParamContent(value);

    public abstract void Validate();
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        System::Type _typeToConvert,
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
            var deserialized = JsonSerializer.Deserialize<List<Messages::BetaTextBlockParam>>(
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

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::String(var string1) => string1,
            ContentVariants::BetaMCPToolResultBlockParamContent(
                var betaMCPToolResultBlockParamContent
            ) => betaMCPToolResultBlockParamContent,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
