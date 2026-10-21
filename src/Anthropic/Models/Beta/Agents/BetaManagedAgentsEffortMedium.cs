using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Medium effort. Balances latency and reasoning depth.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortMedium, BetaManagedAgentsEffortMediumFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortMedium : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("medium")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsEffortMedium()
    {
        this.Type = JsonSerializer.SerializeToElement("medium");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortMedium(
        BetaManagedAgentsEffortMedium betaManagedAgentsEffortMedium
    )
        : base(betaManagedAgentsEffortMedium) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortMedium(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("medium");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortMedium(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortMediumFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortMedium FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEffortMediumFromRaw : IFromRawJson<BetaManagedAgentsEffortMedium>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortMedium FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortMedium.FromRawUnchecked(rawData);
}
