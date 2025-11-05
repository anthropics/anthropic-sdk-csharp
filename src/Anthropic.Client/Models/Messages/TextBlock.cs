using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

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
            if (!this._properties.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<TextCitation>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["citations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Text
    {
        get
        {
            if (!this._properties.TryGetValue("text", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'text' cannot be null",
                    new System::ArgumentOutOfRangeException("text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'text' cannot be null",
                    new System::ArgumentNullException("text")
                );
        }
        init
        {
            this._properties["text"] = JsonSerializer.SerializeToElement(
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

    public override void Validate()
    {
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
        _ = this.Text;
        _ = this.Type;
    }

    public TextBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

    public TextBlock(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextBlock(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TextBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
