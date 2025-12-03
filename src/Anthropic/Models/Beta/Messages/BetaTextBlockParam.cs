using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextBlockParam, BetaTextBlockParamFromRaw>))]
public sealed record class BetaTextBlockParam : ModelBase
{
    public required string Text
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "text"); }
        init { ModelBase.Set(this._rawData, "text", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    public IReadOnlyList<BetaTextCitationParam>? Citations
    {
        get
        {
            return ModelBase.GetNullableClass<List<BetaTextCitationParam>>(
                this.RawData,
                "citations"
            );
        }
        init { ModelBase.Set(this._rawData, "citations", value); }
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

class BetaTextBlockParamFromRaw : IFromRaw<BetaTextBlockParam>
{
    /// <inheritdoc/>
    public BetaTextBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaTextBlockParam.FromRawUnchecked(rawData);
}
