using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The agent cannot spawn session threads.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentSubagentsDisabled,
        BetaManagedAgentsMultiagentSubagentsDisabledFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentSubagentsDisabled : JsonModel
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

    public BetaManagedAgentsMultiagentSubagentsDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentSubagentsDisabled(
        BetaManagedAgentsMultiagentSubagentsDisabled betaManagedAgentsMultiagentSubagentsDisabled
    )
        : base(betaManagedAgentsMultiagentSubagentsDisabled) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentSubagentsDisabled(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentSubagentsDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentSubagentsDisabledFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentSubagentsDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentSubagentsDisabledFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentSubagentsDisabled>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentSubagentsDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentSubagentsDisabled.FromRawUnchecked(rawData);
}
