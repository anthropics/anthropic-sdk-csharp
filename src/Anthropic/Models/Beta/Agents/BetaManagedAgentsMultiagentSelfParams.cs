using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Sentinel roster entry meaning "the agent that owns this configuration". Resolved
/// server-side to a concrete agent reference.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentSelfParams,
        BetaManagedAgentsMultiagentSelfParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentSelfParams : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("self")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMultiagentSelfParams()
    {
        this.Type = JsonSerializer.SerializeToElement("self");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentSelfParams(
        BetaManagedAgentsMultiagentSelfParams betaManagedAgentsMultiagentSelfParams
    )
        : base(betaManagedAgentsMultiagentSelfParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentSelfParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("self");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentSelfParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentSelfParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentSelfParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentSelfParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentSelfParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentSelfParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentSelfParams.FromRawUnchecked(rawData);
}
