using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<TextBlockParam, TextBlockParamFromRaw>))]
public sealed record class TextBlockParam : ModelBase
{
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<CacheControlEphemeral>(this.RawData, "cache_control");
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    public IReadOnlyList<TextCitationParam>? Citations
    {
        get
        {
            return ModelBase.GetNullableClass<List<TextCitationParam>>(this.RawData, "citations");
        }
        init { ModelBase.Set(this._rawData, "citations", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"text\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
    }

    public TextBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

    public TextBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextBlockParamFromRaw.FromRawUnchecked"/>
    public static TextBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextBlockParam(string text)
        : this()
    {
        this.Text = text;
    }
}

class TextBlockParamFromRaw : IFromRaw<TextBlockParam>
{
    /// <inheritdoc/>
    public TextBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextBlockParam.FromRawUnchecked(rawData);
}
