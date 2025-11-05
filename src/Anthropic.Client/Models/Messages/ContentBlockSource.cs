using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<ContentBlockSource>))]
public sealed record class ContentBlockSource : ModelBase, IFromRaw<ContentBlockSource>
{
    public required Content Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentNullException("content")
                );
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.Type;
    }

    public ContentBlockSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContentBlockSource(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ContentBlockSource FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ContentBlockSource(Content content)
        : this()
    {
        this.Content = content;
    }
}

[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public Content(string value)
    {
        Value = value;
    }

    public Content(List<ContentBlockSourceContent> value)
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

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBlockSource([NotNullWhen(true)] out List<ContentBlockSourceContent>? value)
    {
        value = this.Value as List<ContentBlockSourceContent>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<List<ContentBlockSourceContent>> contentBlockSourceContent
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<ContentBlockSourceContent> value:
                contentBlockSourceContent(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<List<ContentBlockSourceContent>, T> contentBlockSourceContent
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            List<ContentBlockSourceContent> value => contentBlockSourceContent(value),
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
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Content(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ContentBlockSourceContent>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Content(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<ContentBlockSourceContent>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
