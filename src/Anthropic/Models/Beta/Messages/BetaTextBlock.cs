using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaTextBlock>))]
public sealed record class BetaTextBlock : Anthropic::ModelBase, Anthropic::IFromRaw<BetaTextBlock>
{
    /// <summary>
    /// Citations supporting the text block.
    ///
    /// The type of citation returned will depend on the type of document being cited.
    /// Citing a PDF results in `page_location`, plain text results in `char_location`,
    /// and content document results in `content_block_location`.
    /// </summary>
    public required List<BetaTextCitation>? Citations
    {
        get
        {
            if (!this.Properties.TryGetValue("citations", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "citations",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<BetaTextCitation>?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["citations"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Text
    {
        get
        {
            if (!this.Properties.TryGetValue("text", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "text",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("text");
        }
        set { this.Properties["text"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
        _ = this.Text;
    }

    public BetaTextBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaTextBlock FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
