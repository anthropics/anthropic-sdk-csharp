using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<WebSearchResultBlockParam, WebSearchResultBlockParamFromRaw>)
)]
public sealed record class WebSearchResultBlockParam : JsonModel
{
    public required string EncryptedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("encrypted_content");
        }
        init { this._rawData.Set("encrypted_content", value); }
    }

    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public string? PageAge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_age");
        }
        init { this._rawData.Set("page_age", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EncryptedContent;
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_search_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
        _ = this.PageAge;
    }

    public WebSearchResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("web_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchResultBlockParam(WebSearchResultBlockParam webSearchResultBlockParam)
        : base(webSearchResultBlockParam) { }
#pragma warning restore CS8618

    public WebSearchResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchResultBlockParamFromRaw.FromRawUnchecked"/>
    public static WebSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebSearchResultBlockParamFromRaw : IFromRawJson<WebSearchResultBlockParam>
{
    /// <inheritdoc/>
    public WebSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebSearchResultBlockParam.FromRawUnchecked(rawData);
}
