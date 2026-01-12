using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        CitationsWebSearchResultLocation,
        CitationsWebSearchResultLocationFromRaw
    >)
)]
public sealed record class CitationsWebSearchResultLocation : JsonModel
{
    public required string CitedText
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "cited_text"); }
        init { JsonModel.Set(this._rawData, "cited_text", value); }
    }

    public required string EncryptedIndex
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "encrypted_index"); }
        init { JsonModel.Set(this._rawData, "encrypted_index", value); }
    }

    public required string? Title
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "title"); }
        init { JsonModel.Set(this._rawData, "title", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    public required string Url
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.EncryptedIndex;
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_search_result_location\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public CitationsWebSearchResultLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result_location\"");
    }

    public CitationsWebSearchResultLocation(
        CitationsWebSearchResultLocation citationsWebSearchResultLocation
    )
        : base(citationsWebSearchResultLocation) { }

    public CitationsWebSearchResultLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsWebSearchResultLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationsWebSearchResultLocationFromRaw.FromRawUnchecked"/>
    public static CitationsWebSearchResultLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationsWebSearchResultLocationFromRaw : IFromRawJson<CitationsWebSearchResultLocation>
{
    /// <inheritdoc/>
    public CitationsWebSearchResultLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CitationsWebSearchResultLocation.FromRawUnchecked(rawData);
}
