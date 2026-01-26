using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaTextDelta, BetaTextDeltaFromRaw>))]
public sealed record class BetaTextDelta : JsonModel
{
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text_delta")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTextDelta()
    {
        this.Type = JsonSerializer.SerializeToElement("text_delta");
    }

    public BetaTextDelta(BetaTextDelta betaTextDelta)
        : base(betaTextDelta) { }

    public BetaTextDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextDeltaFromRaw.FromRawUnchecked"/>
    public static BetaTextDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaTextDelta(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaTextDeltaFromRaw : IFromRawJson<BetaTextDelta>
{
    /// <inheritdoc/>
    public BetaTextDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaTextDelta.FromRawUnchecked(rawData);
}
