using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The agent cannot start workflow runs.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentWorkflowsDisabledParams,
        BetaManagedAgentsMultiagentWorkflowsDisabledParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentWorkflowsDisabledParams : JsonModel
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

    public BetaManagedAgentsMultiagentWorkflowsDisabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentWorkflowsDisabledParams(
        BetaManagedAgentsMultiagentWorkflowsDisabledParams betaManagedAgentsMultiagentWorkflowsDisabledParams
    )
        : base(betaManagedAgentsMultiagentWorkflowsDisabledParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentWorkflowsDisabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentWorkflowsDisabledParams(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentWorkflowsDisabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentWorkflowsDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentWorkflowsDisabledParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentWorkflowsDisabledParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentWorkflowsDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentWorkflowsDisabledParams.FromRawUnchecked(rawData);
}
