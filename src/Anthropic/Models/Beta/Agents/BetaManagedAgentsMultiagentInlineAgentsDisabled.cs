using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The agent cannot define inline agents.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentInlineAgentsDisabled,
        BetaManagedAgentsMultiagentInlineAgentsDisabledFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentInlineAgentsDisabled : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("disabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMultiagentInlineAgentsDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentInlineAgentsDisabled(
        BetaManagedAgentsMultiagentInlineAgentsDisabled betaManagedAgentsMultiagentInlineAgentsDisabled
    )
        : base(betaManagedAgentsMultiagentInlineAgentsDisabled) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentInlineAgentsDisabled(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentInlineAgentsDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentInlineAgentsDisabledFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentInlineAgentsDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentInlineAgentsDisabledFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentInlineAgentsDisabled>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentInlineAgentsDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentInlineAgentsDisabled.FromRawUnchecked(rawData);
}
