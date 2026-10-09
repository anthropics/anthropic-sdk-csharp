using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The session's primary thread can consult `model` mid-turn.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentAdvisorEnabledParams,
        BetaManagedAgentsMultiagentAdvisorEnabledParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentAdvisorEnabledParams : JsonModel
{
    /// <summary>
    /// A Claude model id. The model must be permitted as an advisor for this agent's model.
    /// </summary>
    public required string Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

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
        _ = this.Model;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMultiagentAdvisorEnabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentAdvisorEnabledParams(
        BetaManagedAgentsMultiagentAdvisorEnabledParams betaManagedAgentsMultiagentAdvisorEnabledParams
    )
        : base(betaManagedAgentsMultiagentAdvisorEnabledParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentAdvisorEnabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentAdvisorEnabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentAdvisorEnabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentAdvisorEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentAdvisorEnabledParams(string model)
        : this()
    {
        this.Model = model;
    }
}

class BetaManagedAgentsMultiagentAdvisorEnabledParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentAdvisorEnabledParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentAdvisorEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentAdvisorEnabledParams.FromRawUnchecked(rawData);
}
