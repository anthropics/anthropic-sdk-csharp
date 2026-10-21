using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Maximum effort. Favors reasoning depth over latency.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortMax, BetaManagedAgentsEffortMaxFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortMax : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("max")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsEffortMax()
    {
        this.Type = JsonSerializer.SerializeToElement("max");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortMax(BetaManagedAgentsEffortMax betaManagedAgentsEffortMax)
        : base(betaManagedAgentsEffortMax) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortMax(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("max");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortMax(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortMaxFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortMax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEffortMaxFromRaw : IFromRawJson<BetaManagedAgentsEffortMax>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortMax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortMax.FromRawUnchecked(rawData);
}
