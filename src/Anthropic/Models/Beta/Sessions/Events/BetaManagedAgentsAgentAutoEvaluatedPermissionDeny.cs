using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The server judged the invocation high-risk; it does not execute and a synthetic
/// error tool result is appended.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentAutoEvaluatedPermissionDeny,
        BetaManagedAgentsAgentAutoEvaluatedPermissionDenyFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentAutoEvaluatedPermissionDeny : JsonModel
{
    /// <summary>
    /// The judgement's grounds in registry-bound terms. Open registry; currently
    /// "high_risk" (judged high-risk; the call does not run). Clients must tolerate
    /// values outside this set.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("deny")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentAutoEvaluatedPermissionDeny()
    {
        this.Type = JsonSerializer.SerializeToElement("deny");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentAutoEvaluatedPermissionDeny(
        BetaManagedAgentsAgentAutoEvaluatedPermissionDeny betaManagedAgentsAgentAutoEvaluatedPermissionDeny
    )
        : base(betaManagedAgentsAgentAutoEvaluatedPermissionDeny) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentAutoEvaluatedPermissionDeny(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("deny");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentAutoEvaluatedPermissionDeny(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentAutoEvaluatedPermissionDenyFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentAutoEvaluatedPermissionDeny FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentAutoEvaluatedPermissionDeny(string reasonCode)
        : this()
    {
        this.ReasonCode = reasonCode;
    }
}

class BetaManagedAgentsAgentAutoEvaluatedPermissionDenyFromRaw
    : IFromRawJson<BetaManagedAgentsAgentAutoEvaluatedPermissionDeny>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentAutoEvaluatedPermissionDeny FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentAutoEvaluatedPermissionDeny.FromRawUnchecked(rawData);
}
