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
        BetaManagedAgentsMultiagentInlineAgentsEnabledParams,
        BetaManagedAgentsMultiagentInlineAgentsEnabledParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentInlineAgentsEnabledParams : JsonModel
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

    public BetaManagedAgentsMultiagentInlineAgentsEnabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentInlineAgentsEnabledParams(
        BetaManagedAgentsMultiagentInlineAgentsEnabledParams betaManagedAgentsMultiagentInlineAgentsEnabledParams
    )
        : base(betaManagedAgentsMultiagentInlineAgentsEnabledParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentInlineAgentsEnabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentInlineAgentsEnabledParams(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentInlineAgentsEnabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentInlineAgentsEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentInlineAgentsEnabledParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentInlineAgentsEnabledParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentInlineAgentsEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentInlineAgentsEnabledParams.FromRawUnchecked(rawData);
}
