using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<SearchResultBlockParam, SearchResultBlockParamFromRaw>))]
public sealed record class SearchResultBlockParam : JsonModel
{
    public required IReadOnlyList<TextBlockParam> Content
    {
        get { return JsonModel.GetNotNullClass<List<TextBlockParam>>(this.RawData, "content"); }
        init { JsonModel.Set(this._rawData, "content", value); }
    }

    public required string Source
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "source"); }
        init { JsonModel.Set(this._rawData, "source", value); }
    }

    public required string Title
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "title"); }
        init { JsonModel.Set(this._rawData, "title", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return JsonModel.GetNullableClass<CacheControlEphemeral>(this.RawData, "cache_control");
        }
        init { JsonModel.Set(this._rawData, "cache_control", value); }
    }

    public CitationsConfigParam? Citations
    {
        get { return JsonModel.GetNullableClass<CitationsConfigParam>(this.RawData, "citations"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "citations", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.Source;
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"search_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Citations?.Validate();
    }

    public SearchResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
    }

    public SearchResultBlockParam(SearchResultBlockParam searchResultBlockParam)
        : base(searchResultBlockParam) { }

    public SearchResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchResultBlockParamFromRaw.FromRawUnchecked"/>
    public static SearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchResultBlockParamFromRaw : IFromRawJson<SearchResultBlockParam>
{
    /// <inheritdoc/>
    public SearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchResultBlockParam.FromRawUnchecked(rawData);
}
