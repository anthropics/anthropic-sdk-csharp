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
        BetaManagedAgentsMultiagentSubagentsDisabledParams,
        BetaManagedAgentsMultiagentSubagentsDisabledParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentSubagentsDisabledParams : JsonModel
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

    public BetaManagedAgentsMultiagentSubagentsDisabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentSubagentsDisabledParams(
        BetaManagedAgentsMultiagentSubagentsDisabledParams betaManagedAgentsMultiagentSubagentsDisabledParams
    )
        : base(betaManagedAgentsMultiagentSubagentsDisabledParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentSubagentsDisabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentSubagentsDisabledParams(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentSubagentsDisabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentSubagentsDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentSubagentsDisabledParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentSubagentsDisabledParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentSubagentsDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentSubagentsDisabledParams.FromRawUnchecked(rawData);
}
