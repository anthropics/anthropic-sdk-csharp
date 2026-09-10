using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The resolved permission_policy was always_allow; accompanies evaluated_permission "allow".
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolEvaluationAlwaysAllow,
        BetaManagedAgentsAgentToolEvaluationAlwaysAllowFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolEvaluationAlwaysAllow : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("always_allow")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentToolEvaluationAlwaysAllow()
    {
        this.Type = JsonSerializer.SerializeToElement("always_allow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolEvaluationAlwaysAllow(
        BetaManagedAgentsAgentToolEvaluationAlwaysAllow betaManagedAgentsAgentToolEvaluationAlwaysAllow
    )
        : base(betaManagedAgentsAgentToolEvaluationAlwaysAllow) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolEvaluationAlwaysAllow(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("always_allow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolEvaluationAlwaysAllow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolEvaluationAlwaysAllowFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolEvaluationAlwaysAllow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentToolEvaluationAlwaysAllowFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolEvaluationAlwaysAllow>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolEvaluationAlwaysAllow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolEvaluationAlwaysAllow.FromRawUnchecked(rawData);
}
