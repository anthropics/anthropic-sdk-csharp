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
        BetaThinkingConfigBetweenTools,
        BetaThinkingConfigBetweenToolsFromRaw
    >)
)]
public sealed record class BetaThinkingConfigBetweenTools : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("between_tools")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingConfigBetweenTools()
    {
        this.Type = JsonSerializer.SerializeToElement("between_tools");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingConfigBetweenTools(
        BetaThinkingConfigBetweenTools betaThinkingConfigBetweenTools
    )
        : base(betaThinkingConfigBetweenTools) { }
#pragma warning restore CS8618

    public BetaThinkingConfigBetweenTools(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("between_tools");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingConfigBetweenTools(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingConfigBetweenToolsFromRaw.FromRawUnchecked"/>
    public static BetaThinkingConfigBetweenTools FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingConfigBetweenToolsFromRaw : IFromRawJson<BetaThinkingConfigBetweenTools>
{
    /// <inheritdoc/>
    public BetaThinkingConfigBetweenTools FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingConfigBetweenTools.FromRawUnchecked(rawData);
}
