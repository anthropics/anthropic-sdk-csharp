using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaTextBlockParam, BetaTextBlockParamFromRaw>))]
public sealed record class BetaTextBlockParam : JsonModel
{
    public required string Text
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "text"); }
        init { JsonModel.Set(this._rawData, "text", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return JsonModel.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { JsonModel.Set(this._rawData, "cache_control", value); }
    }

    public IReadOnlyList<BetaTextCitationParam>? Citations
    {
        get
        {
            return JsonModel.GetNullableClass<List<BetaTextCitationParam>>(
                this.RawData,
                "citations"
            );
        }
        init { JsonModel.Set(this._rawData, "citations", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"text\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
    }

    public BetaTextBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

    public BetaTextBlockParam(BetaTextBlockParam betaTextBlockParam)
        : base(betaTextBlockParam) { }

    public BetaTextBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaTextBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaTextBlockParam(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaTextBlockParamFromRaw : IFromRawJson<BetaTextBlockParam>
{
    /// <inheritdoc/>
    public BetaTextBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaTextBlockParam.FromRawUnchecked(rawData);
}
