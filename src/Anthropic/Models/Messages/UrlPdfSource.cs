using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<UrlPdfSource, UrlPdfSourceFromRaw>))]
public sealed record class UrlPdfSource : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("url")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public UrlPdfSource()
    {
        this.Type = JsonSerializer.SerializeToElement("url");
    }

    public UrlPdfSource(UrlPdfSource urlPdfSource)
        : base(urlPdfSource) { }

    public UrlPdfSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlPdfSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlPdfSourceFromRaw.FromRawUnchecked"/>
    public static UrlPdfSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UrlPdfSource(string url)
        : this()
    {
        this.Url = url;
    }
}

class UrlPdfSourceFromRaw : IFromRawJson<UrlPdfSource>
{
    /// <inheritdoc/>
    public UrlPdfSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UrlPdfSource.FromRawUnchecked(rawData);
}
