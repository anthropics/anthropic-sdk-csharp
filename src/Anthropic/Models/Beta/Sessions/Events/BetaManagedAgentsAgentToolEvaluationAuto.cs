using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The resolved permission_policy was auto: the server judged this invocation individually.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolEvaluationAuto,
        BetaManagedAgentsAgentToolEvaluationAutoFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolEvaluationAuto : JsonModel
{
    /// <summary>
    /// The server's per-invocation judgement under the auto permission policy. Its
    /// type always equals the event's top-level evaluated_permission. Open union:
    /// clients must tolerate unknown variants.
    /// </summary>
    public required BetaManagedAgentsAgentAutoEvaluatedPermission EvaluatedPermission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsAgentAutoEvaluatedPermission>(
                "evaluated_permission"
            );
        }
        init { this._rawData.Set("evaluated_permission", value); }
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
        this.EvaluatedPermission.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("auto")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentToolEvaluationAuto()
    {
        this.Type = JsonSerializer.SerializeToElement("auto");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolEvaluationAuto(
        BetaManagedAgentsAgentToolEvaluationAuto betaManagedAgentsAgentToolEvaluationAuto
    )
        : base(betaManagedAgentsAgentToolEvaluationAuto) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolEvaluationAuto(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("auto");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolEvaluationAuto(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolEvaluationAutoFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolEvaluationAuto FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolEvaluationAuto(
        BetaManagedAgentsAgentAutoEvaluatedPermission evaluatedPermission
    )
        : this()
    {
        this.EvaluatedPermission = evaluatedPermission;
    }
}

class BetaManagedAgentsAgentToolEvaluationAutoFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolEvaluationAuto>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolEvaluationAuto FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolEvaluationAuto.FromRawUnchecked(rawData);
}
