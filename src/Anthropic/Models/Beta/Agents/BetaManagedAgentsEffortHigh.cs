using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// High effort. Favors reasoning depth.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortHigh, BetaManagedAgentsEffortHighFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortHigh : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("high")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsEffortHigh()
    {
        this.Type = JsonSerializer.SerializeToElement("high");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortHigh(BetaManagedAgentsEffortHigh betaManagedAgentsEffortHigh)
        : base(betaManagedAgentsEffortHigh) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortHigh(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("high");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortHigh(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortHighFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortHigh FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEffortHighFromRaw : IFromRawJson<BetaManagedAgentsEffortHigh>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortHigh FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortHigh.FromRawUnchecked(rawData);
}
