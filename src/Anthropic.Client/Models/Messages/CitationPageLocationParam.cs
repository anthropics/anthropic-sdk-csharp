using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<CitationPageLocationParam>))]
public sealed record class CitationPageLocationParam
    : ModelBase,
        IFromRaw<CitationPageLocationParam>
{
    public required string CitedText
    {
        get
        {
            if (!this.Properties.TryGetValue("cited_text", out JsonElement element))
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
        set
        {
            this.Properties["cited_text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long DocumentIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("document_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'document_index' cannot be null",
                    new ArgumentOutOfRangeException("document_index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["document_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? DocumentTitle
    {
        get
        {
            if (!this.Properties.TryGetValue("document_title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["document_title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long EndPageNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("end_page_number", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'end_page_number' cannot be null",
                    new ArgumentOutOfRangeException("end_page_number", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["end_page_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long StartPageNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("start_page_number", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'start_page_number' cannot be null",
                    new ArgumentOutOfRangeException(
                        "start_page_number",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start_page_number"] = JsonSerializer.SerializeToElement(
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
                    new ArgumentOutOfRangeException("type", "Missing required argument")
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
        _ = this.CitedText;
        _ = this.DocumentIndex;
        _ = this.DocumentTitle;
        _ = this.EndPageNumber;
        _ = this.StartPageNumber;
    }

    public CitationPageLocationParam()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationPageLocationParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CitationPageLocationParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
