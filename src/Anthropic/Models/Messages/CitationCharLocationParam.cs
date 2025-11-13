using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<CitationCharLocationParam>))]
public sealed record class CitationCharLocationParam
    : ModelBase,
        IFromRaw<CitationCharLocationParam>
{
    public required string CitedText
    {
        get
        {
            if (!this._properties.TryGetValue("cited_text", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'cited_text' cannot be null",
                    new ArgumentOutOfRangeException("cited_text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'cited_text' cannot be null",
                    new ArgumentNullException("cited_text")
                );
        }
        init
        {
            this._properties["cited_text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long DocumentIndex
    {
        get
        {
            if (!this._properties.TryGetValue("document_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'document_index' cannot be null",
                    new ArgumentOutOfRangeException("document_index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["document_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? DocumentTitle
    {
        get
        {
            if (!this._properties.TryGetValue("document_title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["document_title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long EndCharIndex
    {
        get
        {
            if (!this._properties.TryGetValue("end_char_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'end_char_index' cannot be null",
                    new ArgumentOutOfRangeException("end_char_index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["end_char_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long StartCharIndex
    {
        get
        {
            if (!this._properties.TryGetValue("start_char_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'start_char_index' cannot be null",
                    new ArgumentOutOfRangeException("start_char_index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["start_char_index"] = JsonSerializer.SerializeToElement(
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
                    new ArgumentOutOfRangeException("type", "Missing required argument")
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

    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.DocumentIndex;
        _ = this.DocumentTitle;
        _ = this.EndCharIndex;
        _ = this.StartCharIndex;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"char_location\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CitationCharLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");
    }

    public CitationCharLocationParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationCharLocationParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CitationCharLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
