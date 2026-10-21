using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Tool calls require user confirmation before execution.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAlwaysAskPolicy,
        BetaManagedAgentsAlwaysAskPolicyFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAlwaysAskPolicy : JsonModel
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

    public BetaManagedAgentsAlwaysAskPolicy()
    {
        this.Type = JsonSerializer.SerializeToElement("always_ask");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAlwaysAskPolicy(
        BetaManagedAgentsAlwaysAskPolicy betaManagedAgentsAlwaysAskPolicy
    )
        : base(betaManagedAgentsAlwaysAskPolicy) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAlwaysAskPolicy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("always_ask");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAlwaysAskPolicy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAlwaysAskPolicyFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAlwaysAskPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAlwaysAskPolicyFromRaw : IFromRawJson<BetaManagedAgentsAlwaysAskPolicy>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAlwaysAskPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAlwaysAskPolicy.FromRawUnchecked(rawData);
}
