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
        BetaManagedAgentsMultiagentAdvisorDisabledParams,
        BetaManagedAgentsMultiagentAdvisorDisabledParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentAdvisorDisabledParams : JsonModel
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

    public BetaManagedAgentsMultiagentAdvisorDisabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentAdvisorDisabledParams(
        BetaManagedAgentsMultiagentAdvisorDisabledParams betaManagedAgentsMultiagentAdvisorDisabledParams
    )
        : base(betaManagedAgentsMultiagentAdvisorDisabledParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentAdvisorDisabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentAdvisorDisabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentAdvisorDisabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentAdvisorDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentAdvisorDisabledParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentAdvisorDisabledParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentAdvisorDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentAdvisorDisabledParams.FromRawUnchecked(rawData);
}
