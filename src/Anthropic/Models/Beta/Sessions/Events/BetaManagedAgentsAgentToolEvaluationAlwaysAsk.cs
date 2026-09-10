using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The resolved permission_policy was always_ask; accompanies evaluated_permission "ask".
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolEvaluationAlwaysAsk,
        BetaManagedAgentsAgentToolEvaluationAlwaysAskFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolEvaluationAlwaysAsk : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("always_ask")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentToolEvaluationAlwaysAsk()
    {
        this.Type = JsonSerializer.SerializeToElement("always_ask");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolEvaluationAlwaysAsk(
        BetaManagedAgentsAgentToolEvaluationAlwaysAsk betaManagedAgentsAgentToolEvaluationAlwaysAsk
    )
        : base(betaManagedAgentsAgentToolEvaluationAlwaysAsk) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolEvaluationAlwaysAsk(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("always_ask");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolEvaluationAlwaysAsk(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolEvaluationAlwaysAskFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolEvaluationAlwaysAsk FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentToolEvaluationAlwaysAskFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolEvaluationAlwaysAsk>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolEvaluationAlwaysAsk FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolEvaluationAlwaysAsk.FromRawUnchecked(rawData);
}
