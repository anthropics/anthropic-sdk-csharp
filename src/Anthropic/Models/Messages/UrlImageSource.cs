using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<UrlImageSource, UrlImageSourceFromRaw>))]
public sealed record class UrlImageSource : JsonModel
{
    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    public required string Url
    {
        get { return this._rawData.GetNotNullClass<string>("url"); }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"url\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public UrlImageSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

    public UrlImageSource(UrlImageSource urlImageSource)
        : base(urlImageSource) { }

    public UrlImageSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlImageSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlImageSourceFromRaw.FromRawUnchecked"/>
    public static UrlImageSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UrlImageSource(string url)
        : this()
    {
        this.Url = url;
    }
}

class UrlImageSourceFromRaw : IFromRawJson<UrlImageSource>
{
    /// <inheritdoc/>
    public UrlImageSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UrlImageSource.FromRawUnchecked(rawData);
}
