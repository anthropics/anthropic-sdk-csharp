using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaThinkingBlockParam, BetaThinkingBlockParamFromRaw>))]
public sealed record class BetaThinkingBlockParam : JsonModel
{
    public required string Signature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("signature");
        }
        init { this._rawData.Set("signature", value); }
    }

    public required string Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("thinking");
        }
        init { this._rawData.Set("thinking", value); }
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
        _ = this.Signature;
        _ = this.Thinking;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("thinking")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingBlockParam(BetaThinkingBlockParam betaThinkingBlockParam)
        : base(betaThinkingBlockParam) { }
#pragma warning restore CS8618

    public BetaThinkingBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaThinkingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingBlockParamFromRaw : IFromRawJson<BetaThinkingBlockParam>
{
    /// <inheritdoc/>
    public BetaThinkingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingBlockParam.FromRawUnchecked(rawData);
}
