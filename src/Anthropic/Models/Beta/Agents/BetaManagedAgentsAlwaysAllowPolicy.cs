using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Tool calls are automatically approved without user confirmation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAlwaysAllowPolicy,
        BetaManagedAgentsAlwaysAllowPolicyFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAlwaysAllowPolicy : JsonModel
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

    public BetaManagedAgentsAlwaysAllowPolicy()
    {
        this.Type = JsonSerializer.SerializeToElement("always_allow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAlwaysAllowPolicy(
        BetaManagedAgentsAlwaysAllowPolicy betaManagedAgentsAlwaysAllowPolicy
    )
        : base(betaManagedAgentsAlwaysAllowPolicy) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAlwaysAllowPolicy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("always_allow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAlwaysAllowPolicy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAlwaysAllowPolicyFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAlwaysAllowPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAlwaysAllowPolicyFromRaw : IFromRawJson<BetaManagedAgentsAlwaysAllowPolicy>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAlwaysAllowPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAlwaysAllowPolicy.FromRawUnchecked(rawData);
}
