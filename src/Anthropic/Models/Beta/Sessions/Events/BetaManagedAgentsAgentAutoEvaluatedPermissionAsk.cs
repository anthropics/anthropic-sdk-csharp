using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The server reached no judgement; the invocation is held for client approval.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentAutoEvaluatedPermissionAsk,
        BetaManagedAgentsAgentAutoEvaluatedPermissionAskFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentAutoEvaluatedPermissionAsk : JsonModel
{
    /// <summary>
    /// The judgement's grounds in registry-bound terms, for client branching and
    /// audit rather than end-user display. Open registry; currently "indeterminate"
    /// (no judgement was reached). Clients must tolerate values outside this set.
    /// </summary>
    public required string ReasonCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason_code");
        }
        init { this._rawData.Set("reason_code", value); }
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
        _ = this.ReasonCode;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("ask")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentAutoEvaluatedPermissionAsk()
    {
        this.Type = JsonSerializer.SerializeToElement("ask");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentAutoEvaluatedPermissionAsk(
        BetaManagedAgentsAgentAutoEvaluatedPermissionAsk betaManagedAgentsAgentAutoEvaluatedPermissionAsk
    )
        : base(betaManagedAgentsAgentAutoEvaluatedPermissionAsk) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentAutoEvaluatedPermissionAsk(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("ask");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentAutoEvaluatedPermissionAsk(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentAutoEvaluatedPermissionAskFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentAutoEvaluatedPermissionAsk FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentAutoEvaluatedPermissionAsk(string reasonCode)
        : this()
    {
        this.ReasonCode = reasonCode;
    }
}

class BetaManagedAgentsAgentAutoEvaluatedPermissionAskFromRaw
    : IFromRawJson<BetaManagedAgentsAgentAutoEvaluatedPermissionAsk>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentAutoEvaluatedPermissionAsk FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentAutoEvaluatedPermissionAsk.FromRawUnchecked(rawData);
}
