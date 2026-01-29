using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaWebFetchBlock, BetaWebFetchBlockFromRaw>))]
public sealed record class BetaWebFetchBlock : JsonModel
{
    public required BetaDocumentBlock Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaDocumentBlock>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the content was retrieved
    /// </summary>
    public required string? RetrievedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("retrieved_at");
        }
        init { this._rawData.Set("retrieved_at", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.RetrievedAt;
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
    }

    public BetaWebFetchBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("web_fetch_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchBlock(BetaWebFetchBlock betaWebFetchBlock)
        : base(betaWebFetchBlock) { }
#pragma warning restore CS8618

    public BetaWebFetchBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_fetch_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchBlockFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchBlockFromRaw : IFromRawJson<BetaWebFetchBlock>
{
    /// <inheritdoc/>
    public BetaWebFetchBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaWebFetchBlock.FromRawUnchecked(rawData);
}
