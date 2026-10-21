using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Extra-high effort. Not all models accept this level.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortXhigh, BetaManagedAgentsEffortXhighFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortXhigh : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("xhigh")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsEffortXhigh()
    {
        this.Type = JsonSerializer.SerializeToElement("xhigh");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortXhigh(BetaManagedAgentsEffortXhigh betaManagedAgentsEffortXhigh)
        : base(betaManagedAgentsEffortXhigh) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortXhigh(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("xhigh");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortXhigh(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortXhighFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortXhigh FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEffortXhighFromRaw : IFromRawJson<BetaManagedAgentsEffortXhigh>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortXhigh FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortXhigh.FromRawUnchecked(rawData);
}
