using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The server judged the invocation safe to execute without client approval.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentAutoEvaluatedPermissionAllow,
        BetaManagedAgentsAgentAutoEvaluatedPermissionAllowFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentAutoEvaluatedPermissionAllow : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("allow")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentAutoEvaluatedPermissionAllow()
    {
        this.Type = JsonSerializer.SerializeToElement("allow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentAutoEvaluatedPermissionAllow(
        BetaManagedAgentsAgentAutoEvaluatedPermissionAllow betaManagedAgentsAgentAutoEvaluatedPermissionAllow
    )
        : base(betaManagedAgentsAgentAutoEvaluatedPermissionAllow) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentAutoEvaluatedPermissionAllow(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("allow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentAutoEvaluatedPermissionAllow(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentAutoEvaluatedPermissionAllowFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentAutoEvaluatedPermissionAllow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentAutoEvaluatedPermissionAllowFromRaw
    : IFromRawJson<BetaManagedAgentsAgentAutoEvaluatedPermissionAllow>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentAutoEvaluatedPermissionAllow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentAutoEvaluatedPermissionAllow.FromRawUnchecked(rawData);
}
