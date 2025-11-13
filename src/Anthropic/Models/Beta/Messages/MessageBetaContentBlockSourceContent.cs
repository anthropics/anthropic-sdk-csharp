using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(MessageBetaContentBlockSourceContentConverter))]
public record class MessageBetaContentBlockSourceContent
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

    public MessageBetaContentBlockSourceContent(BetaTextBlockParam value)
    {
        Value = value;
    }

    public MessageBetaContentBlockSourceContent(BetaImageBlockParam value)
    {
        Value = value;
    }

    MessageBetaContentBlockSourceContent(UnknownVariant value)
    {
        Value = value;
    }

    public static MessageBetaContentBlockSourceContent CreateUnknownVariant(JsonElement value)
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
        System::Action<BetaTextBlockParam> textBlockParam,
        System::Action<BetaImageBlockParam> imageBlockParam
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
                    "Data did not match any variant of MessageBetaContentBlockSourceContent"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaTextBlockParam, T> textBlockParam,
        System::Func<BetaImageBlockParam, T> imageBlockParam
    )
    {
        return this.Value switch
        {
            BetaTextBlockParam value => textBlockParam(value),
            BetaImageBlockParam value => imageBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageBetaContentBlockSourceContent"
            ),
        };
    }

    public static implicit operator MessageBetaContentBlockSourceContent(
        BetaTextBlockParam value
    ) => new(value);

    public static implicit operator MessageBetaContentBlockSourceContent(
        BetaImageBlockParam value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageBetaContentBlockSourceContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class MessageBetaContentBlockSourceContentConverter
    : JsonConverter<MessageBetaContentBlockSourceContent>
{
    public override MessageBetaContentBlockSourceContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                        return new MessageBetaContentBlockSourceContent(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaTextBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        return new MessageBetaContentBlockSourceContent(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaImageBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
        MessageBetaContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
