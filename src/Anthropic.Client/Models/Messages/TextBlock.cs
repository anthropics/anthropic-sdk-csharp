using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<TextBlock>))]
public sealed record class TextBlock : ModelBase, IFromRaw<TextBlock>
{
    /// <summary>
    /// Citations supporting the text block.
    ///
    /// The type of citation returned will depend on the type of document being cited.
    /// Citing a PDF results in `page_location`, plain text results in `char_location`,
    /// and content document results in `content_block_location`.
    /// </summary>
    public required List<TextCitation>? Citations
    {
        get
        {
            if (!this.Properties.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<TextCitation>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["citations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Text
    {
        get
        {
            if (!this.Properties.TryGetValue("text", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'text' cannot be null",
                    new ArgumentOutOfRangeException("text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'text' cannot be null",
                    new ArgumentNullException("text")
                );
        }
        set
        {
            this.Properties["text"] = JsonSerializer.SerializeToElement(
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
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
        _ = this.Text;
    }

    public TextBlock()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TextBlock FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
