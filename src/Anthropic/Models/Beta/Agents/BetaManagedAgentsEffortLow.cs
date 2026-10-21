using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Low effort. Favors latency over reasoning depth.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortLow, BetaManagedAgentsEffortLowFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortLow : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("low")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsEffortLow()
    {
        this.Type = JsonSerializer.SerializeToElement("low");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLow betaManagedAgentsEffortLow)
        : base(betaManagedAgentsEffortLow) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortLow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("low");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortLow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortLowFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortLow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEffortLowFromRaw : IFromRawJson<BetaManagedAgentsEffortLow>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortLow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortLow.FromRawUnchecked(rawData);
}
