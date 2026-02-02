using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<WebSearchResultBlock, WebSearchResultBlockFromRaw>))]
public sealed record class WebSearchResultBlock : JsonModel
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

    public required string? PageAge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_age");
        }
        init { this._rawData.Set("page_age", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EncryptedContent;
        _ = this.PageAge;
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
    }

    public WebSearchResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("web_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchResultBlock(WebSearchResultBlock webSearchResultBlock)
        : base(webSearchResultBlock) { }
#pragma warning restore CS8618

    public WebSearchResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchResultBlockFromRaw.FromRawUnchecked"/>
    public static WebSearchResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebSearchResultBlockFromRaw : IFromRawJson<WebSearchResultBlock>
{
    /// <inheritdoc/>
    public WebSearchResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebSearchResultBlock.FromRawUnchecked(rawData);
}
