using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaToolResultBlockParam>))]
public sealed record class BetaToolResultBlockParam : ModelBase, IFromRaw<BetaToolResultBlockParam>
{
    public required string ToolUseID
    {
        get
        {
            if (!this._properties.TryGetValue("tool_use_id", out JsonElement element))
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
        init
        {
            this._properties["tool_use_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Content7? Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Content7?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? IsError
    {
        get
        {
            if (!this._properties.TryGetValue("is_error", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["is_error"] = JsonSerializer.SerializeToElement(
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

    public BetaToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
    }

    public BetaToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolResultBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaToolResultBlockParam(string toolUseID)
        : this()
    {
        this.ToolUseID = toolUseID;
    }
}

[JsonConverter(typeof(Content7Converter))]
public record class Content7
{
    public object Value { get; private init; }

    public Content7(string value)
    {
        Value = value;
    }

    public Content7(IReadOnlyList<Block> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    Content7(UnknownVariant value)
    {
        Value = value;
    }

    public static Content7 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBlocks([NotNullWhen(true)] out IReadOnlyList<Block>? value)
    {
        value = this.Value as IReadOnlyList<Block>;
        return value != null;
    }

    public void Switch(System::Action<string> @string, System::Action<IReadOnlyList<Block>> blocks)
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
                    "Data did not match any variant of Content7"
                );
        }
    }

    public T Match<T>(System::Func<string, T> @string, System::Func<IReadOnlyList<Block>, T> blocks)
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<Block> value => blocks(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content7"
            ),
        };
    }

    public static implicit operator Content7(string value) => new(value);

    public static implicit operator Content7(List<Block> value) => new((IReadOnlyList<Block>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content7");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Content7Converter : JsonConverter<Content7>
{
    public override Content7? Read(
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
                return new Content7(deserialized);
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
                return new Content7(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Content7 value, JsonSerializerOptions options)
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
                betaTextBlockParam: (x) => x.Type,
                betaImageBlockParam: (x) => x.Type,
                betaSearchResultBlockParam: (x) => x.Type,
                betaRequestDocument: (x) => x.Type
            );
        }
    }

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<BetaCacheControlEphemeral?>(
                betaTextBlockParam: (x) => x.CacheControl,
                betaImageBlockParam: (x) => x.CacheControl,
                betaSearchResultBlockParam: (x) => x.CacheControl,
                betaRequestDocument: (x) => x.CacheControl
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                betaTextBlockParam: (_) => null,
                betaImageBlockParam: (_) => null,
                betaSearchResultBlockParam: (x) => x.Title,
                betaRequestDocument: (x) => x.Title
            );
        }
    }

    public Block(BetaTextBlockParam value)
    {
        Value = value;
    }

    public Block(BetaImageBlockParam value)
    {
        Value = value;
    }

    public Block(BetaSearchResultBlockParam value)
    {
        Value = value;
    }

    public Block(BetaRequestDocumentBlock value)
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

    public bool TryPickBetaTextBlockParam([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = this.Value as BetaTextBlockParam;
        return value != null;
    }

    public bool TryPickBetaImageBlockParam([NotNullWhen(true)] out BetaImageBlockParam? value)
    {
        value = this.Value as BetaImageBlockParam;
        return value != null;
    }

    public bool TryPickBetaSearchResultBlockParam(
        [NotNullWhen(true)] out BetaSearchResultBlockParam? value
    )
    {
        value = this.Value as BetaSearchResultBlockParam;
        return value != null;
    }

    public bool TryPickBetaRequestDocument([NotNullWhen(true)] out BetaRequestDocumentBlock? value)
    {
        value = this.Value as BetaRequestDocumentBlock;
        return value != null;
    }

    public void Switch(
        System::Action<BetaTextBlockParam> betaTextBlockParam,
        System::Action<BetaImageBlockParam> betaImageBlockParam,
        System::Action<BetaSearchResultBlockParam> betaSearchResultBlockParam,
        System::Action<BetaRequestDocumentBlock> betaRequestDocument
    )
    {
        switch (this.Value)
        {
            case BetaTextBlockParam value:
                betaTextBlockParam(value);
                break;
            case BetaImageBlockParam value:
                betaImageBlockParam(value);
                break;
            case BetaSearchResultBlockParam value:
                betaSearchResultBlockParam(value);
                break;
            case BetaRequestDocumentBlock value:
                betaRequestDocument(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    public T Match<T>(
        System::Func<BetaTextBlockParam, T> betaTextBlockParam,
        System::Func<BetaImageBlockParam, T> betaImageBlockParam,
        System::Func<BetaSearchResultBlockParam, T> betaSearchResultBlockParam,
        System::Func<BetaRequestDocumentBlock, T> betaRequestDocument
    )
    {
        return this.Value switch
        {
            BetaTextBlockParam value => betaTextBlockParam(value),
            BetaImageBlockParam value => betaImageBlockParam(value),
            BetaSearchResultBlockParam value => betaSearchResultBlockParam(value),
            BetaRequestDocumentBlock value => betaRequestDocument(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Block"),
        };
    }

    public static implicit operator Block(BetaTextBlockParam value) => new(value);

    public static implicit operator Block(BetaImageBlockParam value) => new(value);

    public static implicit operator Block(BetaSearchResultBlockParam value) => new(value);

    public static implicit operator Block(BetaRequestDocumentBlock value) => new(value);

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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
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
                        return new Block(deserialized);
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
            case "search_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSearchResultBlockParam>(
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
                            "Data does not match union variant 'BetaSearchResultBlockParam'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(
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
                            "Data does not match union variant 'BetaRequestDocumentBlock'",
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
