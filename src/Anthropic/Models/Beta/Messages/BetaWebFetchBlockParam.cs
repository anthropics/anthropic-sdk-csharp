using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaWebFetchBlockParam, BetaWebFetchBlockParamFromRaw>))]
public sealed record class BetaWebFetchBlockParam : JsonModel
{
    public required BetaRequestDocumentBlock Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaRequestDocumentBlock>("content");
        }
        init { this._rawData.Set("content", value); }
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

    /// <summary>
    /// Fetched content URL
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the content was retrieved
    /// </summary>
    public string? RetrievedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("retrieved_at");
        }
        init { this._rawData.Set("retrieved_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_fetch_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
        _ = this.RetrievedAt;
    }

    public BetaWebFetchBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("web_fetch_result");
    }

    public BetaWebFetchBlockParam(BetaWebFetchBlockParam betaWebFetchBlockParam)
        : base(betaWebFetchBlockParam) { }

    public BetaWebFetchBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_fetch_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchBlockParamFromRaw : IFromRawJson<BetaWebFetchBlockParam>
{
    /// <inheritdoc/>
    public BetaWebFetchBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchBlockParam.FromRawUnchecked(rawData);
}
