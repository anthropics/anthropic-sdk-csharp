using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The server decides each tool call individually: it judges, from the tool, its
/// input, and the session content so far, whether the call is safe to execute or
/// high-risk, and evaluates it to allow when judged safe and to deny when judged
/// high-risk. A call the server cannot reach a judgement on evaluates to ask.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsAutoPolicy, BetaManagedAgentsAutoPolicyFromRaw>)
)]
public sealed record class BetaManagedAgentsAutoPolicy : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("auto")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAutoPolicy()
    {
        this.Type = JsonSerializer.SerializeToElement("auto");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAutoPolicy(BetaManagedAgentsAutoPolicy betaManagedAgentsAutoPolicy)
        : base(betaManagedAgentsAutoPolicy) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAutoPolicy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("auto");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAutoPolicy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAutoPolicyFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAutoPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAutoPolicyFromRaw : IFromRawJson<BetaManagedAgentsAutoPolicy>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAutoPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAutoPolicy.FromRawUnchecked(rawData);
}
