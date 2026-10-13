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
        BetaManagedAgentsMultiagentAdvisorEnabled,
        BetaManagedAgentsMultiagentAdvisorEnabledFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentAdvisorEnabled : JsonModel
{
    /// <summary>
    /// The advisor model id.
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

    public BetaManagedAgentsMultiagentAdvisorEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentAdvisorEnabled(
        BetaManagedAgentsMultiagentAdvisorEnabled betaManagedAgentsMultiagentAdvisorEnabled
    )
        : base(betaManagedAgentsMultiagentAdvisorEnabled) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentAdvisorEnabled(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentAdvisorEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentAdvisorEnabledFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentAdvisorEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentAdvisorEnabled(string model)
        : this()
    {
        this.Model = model;
    }
}

class BetaManagedAgentsMultiagentAdvisorEnabledFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentAdvisorEnabled>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentAdvisorEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentAdvisorEnabled.FromRawUnchecked(rawData);
}
