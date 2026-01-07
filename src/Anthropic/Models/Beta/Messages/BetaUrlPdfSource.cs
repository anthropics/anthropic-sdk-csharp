using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaUrlPdfSource, BetaUrlPdfSourceFromRaw>))]
public sealed record class BetaUrlPdfSource : JsonModel
{
    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    public required string Url
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
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

    public BetaUrlPdfSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

    public BetaUrlPdfSource(BetaUrlPdfSource betaUrlPdfSource)
        : base(betaUrlPdfSource) { }

    public BetaUrlPdfSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUrlPdfSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUrlPdfSourceFromRaw.FromRawUnchecked"/>
    public static BetaUrlPdfSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaUrlPdfSource(string url)
        : this()
    {
        this.Url = url;
    }
}

class BetaUrlPdfSourceFromRaw : IFromRawJson<BetaUrlPdfSource>
{
    /// <inheritdoc/>
    public BetaUrlPdfSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaUrlPdfSource.FromRawUnchecked(rawData);
}
