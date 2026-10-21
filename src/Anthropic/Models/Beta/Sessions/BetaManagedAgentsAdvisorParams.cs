using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Platform advisor roster entry: a model the session's primary thread may consult
/// mid-turn. At most one per roster; the entry occupies the roster name `anthropic.advisor`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAdvisorParams,
        BetaManagedAgentsAdvisorParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAdvisorParams : JsonModel
{
    /// <summary>
    /// A Claude model id. The model must be permitted as an advisor for this agent's model.
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

    public BetaManagedAgentsAdvisorParams()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAdvisorParams(
        BetaManagedAgentsAdvisorParams betaManagedAgentsAdvisorParams
    )
        : base(betaManagedAgentsAdvisorParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAdvisorParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAdvisorParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAdvisorParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAdvisorParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAdvisorParams(string model)
        : this()
    {
        this.Model = model;
    }
}

class BetaManagedAgentsAdvisorParamsFromRaw : IFromRawJson<BetaManagedAgentsAdvisorParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAdvisorParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAdvisorParams.FromRawUnchecked(rawData);
}
