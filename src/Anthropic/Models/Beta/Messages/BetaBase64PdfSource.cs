using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaBase64PdfSource, BetaBase64PdfSourceFromRaw>))]
public sealed record class BetaBase64PdfSource : JsonModel
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
            !JsonElement.DeepEquals(
                this.MediaType,
                JsonSerializer.SerializeToElement("application/pdf")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("base64")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBase64PdfSource()
    {
        this.MediaType = JsonSerializer.SerializeToElement("application/pdf");
        this.Type = JsonSerializer.SerializeToElement("base64");
    }

    public BetaBase64PdfSource(BetaBase64PdfSource betaBase64PdfSource)
        : base(betaBase64PdfSource) { }

    public BetaBase64PdfSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.MediaType = JsonSerializer.SerializeToElement("application/pdf");
        this.Type = JsonSerializer.SerializeToElement("base64");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBase64PdfSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBase64PdfSourceFromRaw.FromRawUnchecked"/>
    public static BetaBase64PdfSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBase64PdfSource(string data)
        : this()
    {
        this.Data = data;
    }
}

class BetaBase64PdfSourceFromRaw : IFromRawJson<BetaBase64PdfSource>
{
    /// <inheritdoc/>
    public BetaBase64PdfSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaBase64PdfSource.FromRawUnchecked(rawData);
}
