using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebFetchBlock, BetaWebFetchBlockFromRaw>))]
public sealed record class BetaWebFetchBlock : ModelBase
{
    public required BetaDocumentBlock Content
    {
        get { return ModelBase.GetNotNullClass<BetaDocumentBlock>(this.RawData, "content"); }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the content was retrieved
    /// </summary>
    public required string? RetrievedAt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "retrieved_at"); }
        init { ModelBase.Set(this._rawData, "retrieved_at", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Fetched content URL
    /// </summary>
    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.RetrievedAt;
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
    }

    public BetaWebFetchBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"");
    }

    public BetaWebFetchBlock(BetaWebFetchBlock betaWebFetchBlock)
        : base(betaWebFetchBlock) { }

    public BetaWebFetchBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaWebFetchBlockFromRaw : IFromRaw<BetaWebFetchBlock>
{
    /// <inheritdoc/>
    public BetaWebFetchBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaWebFetchBlock.FromRawUnchecked(rawData);
}
