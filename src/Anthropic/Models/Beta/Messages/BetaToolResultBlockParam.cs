using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaToolResultBlockParam, BetaToolResultBlockParamFromRaw>))]
public sealed record class BetaToolResultBlockParam : ModelBase
{
    public required string ToolUseID
    {
        get
        {
            if (!this._rawData.TryGetValue("tool_use_id", out JsonElement element))
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
            this._rawData["tool_use_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BetaToolResultBlockParamContent? Content
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaToolResultBlockParamContent?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? IsError
    {
        get
        {
            if (!this._rawData.TryGetValue("is_error", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["is_error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Content?.Validate();
        _ = this.IsError;
    }

    public BetaToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
    }

    public BetaToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolResultBlockParam(string toolUseID)
        : this()
    {
        this.ToolUseID = toolUseID;
    }
}

class BetaToolResultBlockParamFromRaw : IFromRaw<BetaToolResultBlockParam>
{
    public BetaToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolResultBlockParamContentConverter))]
public record class BetaToolResultBlockParamContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public BetaToolResultBlockParamContent(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolResultBlockParamContent(IReadOnlyList<Block> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public BetaToolResultBlockParamContent(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of BetaToolResultBlockParamContent"
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
                "Data did not match any variant of BetaToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator BetaToolResultBlockParamContent(string value) => new(value);

    public static implicit operator BetaToolResultBlockParamContent(List<Block> value) =>
        new((IReadOnlyList<Block>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolResultBlockParamContent"
            );
        }
    }
}

sealed class BetaToolResultBlockParamContentConverter
    : JsonConverter<BetaToolResultBlockParamContent>
{
    public override BetaToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Block>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Tool reference block that can be included in tool_result content.
/// </summary>
[JsonConverter(typeof(BlockConverter))]
public record class Block
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaTextBlockParam: (x) => x.Type,
                betaImageBlockParam: (x) => x.Type,
                betaSearchResultBlockParam: (x) => x.Type,
                betaRequestDocument: (x) => x.Type,
                betaToolReferenceBlockParam: (x) => x.Type
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
                betaRequestDocument: (x) => x.CacheControl,
                betaToolReferenceBlockParam: (x) => x.CacheControl
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
                betaRequestDocument: (x) => x.Title,
                betaToolReferenceBlockParam: (_) => null
            );
        }
    }

    public Block(BetaTextBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Block(BetaImageBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Block(BetaSearchResultBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Block(BetaRequestDocumentBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Block(BetaToolReferenceBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Block(JsonElement json)
    {
        this._json = json;
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

    public bool TryPickBetaToolReferenceBlockParam(
        [NotNullWhen(true)] out BetaToolReferenceBlockParam? value
    )
    {
        value = this.Value as BetaToolReferenceBlockParam;
        return value != null;
    }

    public void Switch(
        System::Action<BetaTextBlockParam> betaTextBlockParam,
        System::Action<BetaImageBlockParam> betaImageBlockParam,
        System::Action<BetaSearchResultBlockParam> betaSearchResultBlockParam,
        System::Action<BetaRequestDocumentBlock> betaRequestDocument,
        System::Action<BetaToolReferenceBlockParam> betaToolReferenceBlockParam
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
            case BetaToolReferenceBlockParam value:
                betaToolReferenceBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    public T Match<T>(
        System::Func<BetaTextBlockParam, T> betaTextBlockParam,
        System::Func<BetaImageBlockParam, T> betaImageBlockParam,
        System::Func<BetaSearchResultBlockParam, T> betaSearchResultBlockParam,
        System::Func<BetaRequestDocumentBlock, T> betaRequestDocument,
        System::Func<BetaToolReferenceBlockParam, T> betaToolReferenceBlockParam
    )
    {
        return this.Value switch
        {
            BetaTextBlockParam value => betaTextBlockParam(value),
            BetaImageBlockParam value => betaImageBlockParam(value),
            BetaSearchResultBlockParam value => betaSearchResultBlockParam(value),
            BetaRequestDocumentBlock value => betaRequestDocument(value),
            BetaToolReferenceBlockParam value => betaToolReferenceBlockParam(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Block"),
        };
    }

    public static implicit operator Block(BetaTextBlockParam value) => new(value);

    public static implicit operator Block(BetaImageBlockParam value) => new(value);

    public static implicit operator Block(BetaSearchResultBlockParam value) => new(value);

    public static implicit operator Block(BetaRequestDocumentBlock value) => new(value);

    public static implicit operator Block(BetaToolReferenceBlockParam value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }
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
            case "search_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSearchResultBlockParam>(
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
            case "document":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(
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
            case "tool_reference":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolReferenceBlockParam>(
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
                return new Block(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Block value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
