using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(MessageBetaContentBlockSourceContentConverter))]
public record class MessageBetaContentBlockSourceContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

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

    public MessageBetaContentBlockSourceContent(BetaTextBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageBetaContentBlockSourceContent(BetaImageBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageBetaContentBlockSourceContent(JsonElement json)
    {
        this._json = json;
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
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageBetaContentBlockSourceContent"
            );
        }
    }

    public virtual bool Equals(MessageBetaContentBlockSourceContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "image":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new MessageBetaContentBlockSourceContent(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageBetaContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
