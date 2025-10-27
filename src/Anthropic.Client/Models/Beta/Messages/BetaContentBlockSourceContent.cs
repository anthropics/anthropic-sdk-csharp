using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaContentBlockSourceContentConverter))]
public record class BetaContentBlockSourceContent
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(textBlockParam: (x) => x.Type, imageBlockParam: (x) => x.Type); }
    }

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<BetaCacheControlEphemeral?>(
                textBlockParam: (x) => x.CacheControl,
                imageBlockParam: (x) => x.CacheControl
            );
        }
    }

    public BetaContentBlockSourceContent(BetaTextBlockParam value)
    {
        Value = value;
    }

    public BetaContentBlockSourceContent(BetaImageBlockParam value)
    {
        Value = value;
    }

    BetaContentBlockSourceContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaContentBlockSourceContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickTextBlockParam([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = this.Value as BetaTextBlockParam;
        return value != null;
    }

    public bool TryPickImageBlockParam([NotNullWhen(true)] out BetaImageBlockParam? value)
    {
        value = this.Value as BetaImageBlockParam;
        return value != null;
    }

    public void Switch(
        Action<BetaTextBlockParam> textBlockParam,
        Action<BetaImageBlockParam> imageBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaTextBlockParam value:
                textBlockParam(value);
                break;
            case BetaImageBlockParam value:
                imageBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaContentBlockSourceContent"
                );
        }
    }

    public T Match<T>(
        Func<BetaTextBlockParam, T> textBlockParam,
        Func<BetaImageBlockParam, T> imageBlockParam
    )
    {
        return this.Value switch
        {
            BetaTextBlockParam value => textBlockParam(value),
            BetaImageBlockParam value => imageBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlockSourceContent"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlockSourceContent"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class BetaContentBlockSourceContentConverter : JsonConverter<BetaContentBlockSourceContent>
{
    public override BetaContentBlockSourceContent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaContentBlockSourceContent(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaTextBlockParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "image":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaContentBlockSourceContent(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaImageBlockParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
