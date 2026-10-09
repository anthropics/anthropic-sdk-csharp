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
        BetaManagedAgentsMultiagentInlineAgentsDisabledParams,
        BetaManagedAgentsMultiagentInlineAgentsDisabledParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentInlineAgentsDisabledParams : JsonModel
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

    public BetaManagedAgentsMultiagentInlineAgentsDisabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentInlineAgentsDisabledParams(
        BetaManagedAgentsMultiagentInlineAgentsDisabledParams betaManagedAgentsMultiagentInlineAgentsDisabledParams
    )
        : base(betaManagedAgentsMultiagentInlineAgentsDisabledParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentInlineAgentsDisabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentInlineAgentsDisabledParams(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentInlineAgentsDisabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentInlineAgentsDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentInlineAgentsDisabledParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentInlineAgentsDisabledParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentInlineAgentsDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentInlineAgentsDisabledParams.FromRawUnchecked(rawData);
}
