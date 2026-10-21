using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The agent has no advisor.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentAdvisorDisabled,
        BetaManagedAgentsMultiagentAdvisorDisabledFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentAdvisorDisabled : JsonModel
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

    public BetaManagedAgentsMultiagentAdvisorDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentAdvisorDisabled(
        BetaManagedAgentsMultiagentAdvisorDisabled betaManagedAgentsMultiagentAdvisorDisabled
    )
        : base(betaManagedAgentsMultiagentAdvisorDisabled) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentAdvisorDisabled(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentAdvisorDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentAdvisorDisabledFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentAdvisorDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentAdvisorDisabledFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentAdvisorDisabled>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentAdvisorDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentAdvisorDisabled.FromRawUnchecked(rawData);
}
