using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaContentBlockSourceContentVariants = Anthropic.Models.Beta.Messages.BetaContentBlockSourceContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaContentBlockSourceContentConverter))]
public abstract record class BetaContentBlockSourceContent
{
    internal BetaContentBlockSourceContent() { }

    public static implicit operator BetaContentBlockSourceContent(BetaTextBlockParam value) =>
        new BetaContentBlockSourceContentVariants::BetaTextBlockParamVariant(value);

    public static implicit operator BetaContentBlockSourceContent(BetaImageBlockParam value) =>
        new BetaContentBlockSourceContentVariants::BetaImageBlockParamVariant(value);

    public abstract void Validate();
}

sealed class BetaContentBlockSourceContentConverter : JsonConverter<BetaContentBlockSourceContent>
{
    public override BetaContentBlockSourceContent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "text":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockSourceContentVariants::BetaTextBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "image":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockSourceContentVariants::BetaImageBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            default:
            {
                throw new global::System.Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaContentBlockSourceContentVariants::BetaTextBlockParamVariant(
                var betaTextBlockParam
            ) => betaTextBlockParam,
            BetaContentBlockSourceContentVariants::BetaImageBlockParamVariant(
                var betaImageBlockParam
            ) => betaImageBlockParam,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
