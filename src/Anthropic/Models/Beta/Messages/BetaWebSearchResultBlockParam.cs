using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaWebSearchResultBlockParam, BetaWebSearchResultBlockParamFromRaw>)
)]
public sealed record class BetaWebSearchResultBlockParam : JsonModel
{
    public required string EncryptedContent
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "encrypted_content"); }
        init { JsonModel.Set(this._rawData, "encrypted_content", value); }
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

    public required string Url
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    public string? PageAge
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "page_age"); }
        init { JsonModel.Set(this._rawData, "page_age", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EncryptedContent;
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
        _ = this.PageAge;
    }

    public BetaWebSearchResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
    }

    public BetaWebSearchResultBlockParam(
        BetaWebSearchResultBlockParam betaWebSearchResultBlockParam
    )
        : base(betaWebSearchResultBlockParam) { }

    public BetaWebSearchResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebSearchResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaWebSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebSearchResultBlockParamFromRaw : IFromRawJson<BetaWebSearchResultBlockParam>
{
    /// <inheritdoc/>
    public BetaWebSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebSearchResultBlockParam.FromRawUnchecked(rawData);
}
