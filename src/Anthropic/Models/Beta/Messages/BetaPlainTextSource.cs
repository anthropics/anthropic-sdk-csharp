using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaPlainTextSource, BetaPlainTextSourceFromRaw>))]
public sealed record class BetaPlainTextSource : JsonModel
{
    public required string Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    public JsonElement MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("media_type");
        }
        init { this._rawData.Set("media_type", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        if (
            !JsonElement.DeepEquals(this.MediaType, JsonSerializer.SerializeToElement("text/plain"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPlainTextSource()
    {
        this.MediaType = JsonSerializer.SerializeToElement("text/plain");
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPlainTextSource(BetaPlainTextSource betaPlainTextSource)
        : base(betaPlainTextSource) { }
#pragma warning restore CS8618

    public BetaPlainTextSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.MediaType = JsonSerializer.SerializeToElement("text/plain");
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPlainTextSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPlainTextSourceFromRaw.FromRawUnchecked"/>
    public static BetaPlainTextSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaPlainTextSource(string data)
        : this()
    {
        this.Data = data;
    }
}

class BetaPlainTextSourceFromRaw : IFromRawJson<BetaPlainTextSource>
{
    /// <inheritdoc/>
    public BetaPlainTextSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPlainTextSource.FromRawUnchecked(rawData);
}
