using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<TextBlock>))]
public sealed record class TextBlock : Anthropic::ModelBase, Anthropic::IFromRaw<TextBlock>
{
    /// <summary>
    /// Citations supporting the text block.
    ///
    /// The type of citation returned will depend on the type of document being cited.
    /// Citing a PDF results in `page_location`, plain text results in `char_location`,
    /// and content document results in `content_block_location`.
    /// </summary>
    public required Generic::List<TextCitation>? Citations
    {
        get
        {
            if (!this.Properties.TryGetValue("citations", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "citations",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<TextCitation>?>(element);
        }
        set { this.Properties["citations"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Text
    {
        get
        {
            if (!this.Properties.TryGetValue("text", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("text", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("text");
        }
        set { this.Properties["text"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
        _ = this.Text;
        if (!this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"text\"")))
        {
            throw new System::Exception();
        }
    }

    public TextBlock()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TextBlock(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TextBlock FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
