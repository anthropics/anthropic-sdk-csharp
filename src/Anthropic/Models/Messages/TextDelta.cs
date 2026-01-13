using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<TextDelta, TextDeltaFromRaw>))]
public sealed record class TextDelta : JsonModel
{
    public required string Text
    {
        get { return this._rawData.GetNotNullClass<string>("text"); }
        init { this._rawData.Set("text", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"text_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public TextDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_delta\"");
    }

    public TextDelta(TextDelta textDelta)
        : base(textDelta) { }

    public TextDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextDeltaFromRaw.FromRawUnchecked"/>
    public static TextDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextDelta(string text)
        : this()
    {
        this.Text = text;
    }
}

class TextDeltaFromRaw : IFromRawJson<TextDelta>
{
    /// <inheritdoc/>
    public TextDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextDelta.FromRawUnchecked(rawData);
}
