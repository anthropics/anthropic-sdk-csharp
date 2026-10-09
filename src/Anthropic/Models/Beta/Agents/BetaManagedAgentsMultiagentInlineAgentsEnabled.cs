using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The agent can define inline agents.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentInlineAgentsEnabled,
        BetaManagedAgentsMultiagentInlineAgentsEnabledFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentInlineAgentsEnabled : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMultiagentInlineAgentsEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentInlineAgentsEnabled(
        BetaManagedAgentsMultiagentInlineAgentsEnabled betaManagedAgentsMultiagentInlineAgentsEnabled
    )
        : base(betaManagedAgentsMultiagentInlineAgentsEnabled) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentInlineAgentsEnabled(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentInlineAgentsEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentInlineAgentsEnabledFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentInlineAgentsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentInlineAgentsEnabledFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentInlineAgentsEnabled>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentInlineAgentsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentInlineAgentsEnabled.FromRawUnchecked(rawData);
}
