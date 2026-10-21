using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Platform advisor roster entry: a model the session's primary thread may consult mid-turn.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsAdvisor, BetaManagedAgentsAdvisorFromRaw>)
)]
public sealed record class BetaManagedAgentsAdvisor : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("advisor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAdvisor()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAdvisor(BetaManagedAgentsAdvisor betaManagedAgentsAdvisor)
        : base(betaManagedAgentsAdvisor) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAdvisor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAdvisor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAdvisorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAdvisor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAdvisor(string model)
        : this()
    {
        this.Model = model;
    }
}

class BetaManagedAgentsAdvisorFromRaw : IFromRawJson<BetaManagedAgentsAdvisor>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAdvisor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAdvisor.FromRawUnchecked(rawData);
}
