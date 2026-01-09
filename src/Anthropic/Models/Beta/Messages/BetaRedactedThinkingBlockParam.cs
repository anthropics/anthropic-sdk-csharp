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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRedactedThinkingBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");
    }

    public BetaRedactedThinkingBlockParam(
        BetaRedactedThinkingBlockParam betaRedactedThinkingBlockParam
    )
        : base(betaRedactedThinkingBlockParam) { }

    public BetaRedactedThinkingBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRedactedThinkingBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
