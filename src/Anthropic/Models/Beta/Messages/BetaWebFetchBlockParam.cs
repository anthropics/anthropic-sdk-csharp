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
        get { return JsonModel.GetNotNullClass<BetaRequestDocumentBlock>(this.RawData, "content"); }
        init { JsonModel.Set(this._rawData, "content", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Fetched content URL
    /// </summary>
    public required string URL
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the content was retrieved
    /// </summary>
    public string? RetrievedAt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "retrieved_at"); }
        init { JsonModel.Set(this._rawData, "retrieved_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.URL;
        _ = this.RetrievedAt;
    }

    public BetaWebFetchBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"");
    }

    public BetaWebFetchBlockParam(BetaWebFetchBlockParam betaWebFetchBlockParam)
        : base(betaWebFetchBlockParam) { }

    public BetaWebFetchBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
