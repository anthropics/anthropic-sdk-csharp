using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaThinkingConfigAdaptive, BetaThinkingConfigAdaptiveFromRaw>)
)]
public sealed record class BetaThinkingConfigAdaptive : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("adaptive")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingConfigAdaptive()
    {
        this.Type = JsonSerializer.SerializeToElement("adaptive");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingConfigAdaptive(BetaThinkingConfigAdaptive betaThinkingConfigAdaptive)
        : base(betaThinkingConfigAdaptive) { }
#pragma warning restore CS8618

    public BetaThinkingConfigAdaptive(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("adaptive");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingConfigAdaptive(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingConfigAdaptiveFromRaw.FromRawUnchecked"/>
    public static BetaThinkingConfigAdaptive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingConfigAdaptiveFromRaw : IFromRawJson<BetaThinkingConfigAdaptive>
{
    /// <inheritdoc/>
    public BetaThinkingConfigAdaptive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingConfigAdaptive.FromRawUnchecked(rawData);
}
