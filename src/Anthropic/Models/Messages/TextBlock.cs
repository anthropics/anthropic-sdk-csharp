using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<TextBlock, TextBlockFromRaw>))]
public sealed record class TextBlock : ModelBase
{
    /// <summary>
    /// Citations supporting the text block.
    ///
    /// <para>The type of citation returned will depend on the type of document being
    /// cited. Citing a PDF results in `page_location`, plain text results in `char_location`,
    /// and content document results in `content_block_location`.</para>
    /// </summary>
    public required IReadOnlyList<TextCitation>? Citations
    {
        get { return ModelBase.GetNullableClass<List<TextCitation>>(this.RawData, "citations"); }
        init { ModelBase.Set(this._rawData, "citations", value); }
    }

    public required string Text
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "text"); }
        init { ModelBase.Set(this._rawData, "text", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"text\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public TextBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

    public TextBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextBlockFromRaw.FromRawUnchecked"/>
    public static TextBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextBlockFromRaw : IFromRaw<TextBlock>
{
    /// <inheritdoc/>
    public TextBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextBlock.FromRawUnchecked(rawData);
}
