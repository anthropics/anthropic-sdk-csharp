using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaURLImageSource, BetaURLImageSourceFromRaw>))]
public sealed record class BetaURLImageSource : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"url\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.URL;
    }

    public BetaURLImageSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

    public BetaURLImageSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaURLImageSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaURLImageSourceFromRaw.FromRawUnchecked"/>
    public static BetaURLImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaURLImageSource(string url)
        : this()
    {
        this.URL = url;
    }
}

class BetaURLImageSourceFromRaw : IFromRaw<BetaURLImageSource>
{
    /// <inheritdoc/>
    public BetaURLImageSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaURLImageSource.FromRawUnchecked(rawData);
}
