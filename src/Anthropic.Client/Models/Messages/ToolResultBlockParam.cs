using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<ToolResultBlockParam>))]
public sealed record class ToolResultBlockParam : ModelBase, IFromRaw<ToolResultBlockParam>
{
    public required string ToolUseID
    {
        get
        {
            if (!this.Properties.TryGetValue("tool_use_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'tool_use_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tool_use_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'tool_use_id' cannot be null",
                    new System::ArgumentNullException("tool_use_id")
                );
        }
        set
        {
            this.Properties["tool_use_id"] = JsonSerializer.SerializeToElement(
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Content1? Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Content1?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? IsError
    {
        get
        {
            if (!this.Properties.TryGetValue("is_error", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["is_error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ToolUseID;
        _ = this.Type;
        this.CacheControl?.Validate();
        this.Content?.Validate();
        _ = this.IsError;
    }

    public ToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolResultBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ToolResultBlockParam FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ToolResultBlockParam(string toolUseID)
        : this()
    {
        this.ToolUseID = toolUseID;
    }
}

[JsonConverter(typeof(Content1Converter))]
public record class Content1
{
    public object Value { get; private init; }

    public Content1(string value)
    {
        Value = value;
    }

    public Content1(List<Block> value)
    {
        Value = value;
    }

    Content1(UnknownVariant value)
    {
        Value = value;
    }

    public static Content1 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBlocks([NotNullWhen(true)] out List<Block>? value)
    {
        value = this.Value as List<Block>;
        return value != null;
    }

    public void Switch(System::Action<string> @string, System::Action<List<Block>> blocks)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<Block> value:
                blocks(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content1"
                );
        }
    }

    public T Match<T>(System::Func<string, T> @string, System::Func<List<Block>, T> blocks)
    {
        return this.Value switch
        {
            string value => @string(value),
            List<Block> value => blocks(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content1"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Content1Converter : JsonConverter<Content1>
{
    public override Content1? Read(
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
                return new Content1(deserialized);
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
            var deserialized = JsonSerializer.Deserialize<List<Block>>(ref reader, options);
            if (deserialized != null)
            {
                return new Content1(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<Block>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content1 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(BlockConverter))]
public record class Block
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                textBlockParam: (x) => x.Type,
                imageBlockParam: (x) => x.Type,
                searchResultBlockParam: (x) => x.Type,
                documentBlockParam: (x) => x.Type
            );
        }
    }

    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<CacheControlEphemeral?>(
                textBlockParam: (x) => x.CacheControl,
                imageBlockParam: (x) => x.CacheControl,
                searchResultBlockParam: (x) => x.CacheControl,
                documentBlockParam: (x) => x.CacheControl
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                textBlockParam: (_) => null,
                imageBlockParam: (_) => null,
                searchResultBlockParam: (x) => x.Title,
                documentBlockParam: (x) => x.Title
            );
        }
    }

    public Block(TextBlockParam value)
    {
        Value = value;
    }

    public Block(ImageBlockParam value)
    {
        Value = value;
    }

    public Block(SearchResultBlockParam value)
    {
        Value = value;
    }

    public Block(DocumentBlockParam value)
    {
        Value = value;
    }

    Block(UnknownVariant value)
    {
        Value = value;
    }

    public static Block CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickTextBlockParam([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = this.Value as TextBlockParam;
        return value != null;
    }

    public bool TryPickImageBlockParam([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = this.Value as ImageBlockParam;
        return value != null;
    }

    public bool TryPickSearchResultBlockParam([NotNullWhen(true)] out SearchResultBlockParam? value)
    {
        value = this.Value as SearchResultBlockParam;
        return value != null;
    }

    public bool TryPickDocumentBlockParam([NotNullWhen(true)] out DocumentBlockParam? value)
    {
        value = this.Value as DocumentBlockParam;
        return value != null;
    }

    public void Switch(
        System::Action<TextBlockParam> textBlockParam,
        System::Action<ImageBlockParam> imageBlockParam,
        System::Action<SearchResultBlockParam> searchResultBlockParam,
        System::Action<DocumentBlockParam> documentBlockParam
    )
    {
        switch (this.Value)
        {
            case TextBlockParam value:
                textBlockParam(value);
                break;
            case ImageBlockParam value:
                imageBlockParam(value);
                break;
            case SearchResultBlockParam value:
                searchResultBlockParam(value);
                break;
            case DocumentBlockParam value:
                documentBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    public T Match<T>(
        System::Func<TextBlockParam, T> textBlockParam,
        System::Func<ImageBlockParam, T> imageBlockParam,
        System::Func<SearchResultBlockParam, T> searchResultBlockParam,
        System::Func<DocumentBlockParam, T> documentBlockParam
    )
    {
        return this.Value switch
        {
            TextBlockParam value => textBlockParam(value),
            ImageBlockParam value => imageBlockParam(value),
            SearchResultBlockParam value => searchResultBlockParam(value),
            DocumentBlockParam value => documentBlockParam(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Block"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BlockConverter : JsonConverter<Block>
{
    public override Block? Read(
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
                    var deserialized = JsonSerializer.Deserialize<TextBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'TextBlockParam'",
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
                    var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ImageBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "search_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SearchResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'SearchResultBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "document":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<DocumentBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'DocumentBlockParam'",
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

    public override void Write(Utf8JsonWriter writer, Block value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
