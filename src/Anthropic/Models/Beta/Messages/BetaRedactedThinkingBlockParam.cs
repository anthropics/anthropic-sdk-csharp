using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaRedactedThinkingBlockParam,
        BetaRedactedThinkingBlockParamFromRaw
    >)
)]
public sealed record class BetaRedactedThinkingBlockParam : JsonModel
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
                this.Type,
                JsonSerializer.SerializeToElement("redacted_thinking")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRedactedThinkingBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("redacted_thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRedactedThinkingBlockParam(
        BetaRedactedThinkingBlockParam betaRedactedThinkingBlockParam
    )
        : base(betaRedactedThinkingBlockParam) { }
#pragma warning restore CS8618

    public BetaRedactedThinkingBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("redacted_thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRedactedThinkingBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRedactedThinkingBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaRedactedThinkingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaRedactedThinkingBlockParam(string data)
        : this()
    {
        this.Data = data;
    }
}

class BetaRedactedThinkingBlockParamFromRaw : IFromRawJson<BetaRedactedThinkingBlockParam>
{
    /// <inheritdoc/>
    public BetaRedactedThinkingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRedactedThinkingBlockParam.FromRawUnchecked(rawData);
}
