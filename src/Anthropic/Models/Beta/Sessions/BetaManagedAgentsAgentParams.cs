using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Specification for an Agent. Provide a specific `version` or use the short-form
/// `agent="agent_id"` for the most recent version
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsAgentParams, BetaManagedAgentsAgentParamsFromRaw>)
)]
public sealed record class BetaManagedAgentsAgentParams : JsonModel
{
    /// <summary>
    /// The `agent` ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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

    /// <summary>
    /// The specific `agent` version to use. Omit to use the latest version. Must
    /// be at least 1 if specified.
    /// </summary>
    public int? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("version");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("version");
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("agent")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Version;
    }

    public BetaManagedAgentsAgentParams()
    {
        this.Type = JsonSerializer.SerializeToElement("agent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentParams(BetaManagedAgentsAgentParams betaManagedAgentsAgentParams)
        : base(betaManagedAgentsAgentParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentParams(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsAgentParamsFromRaw : IFromRawJson<BetaManagedAgentsAgentParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentParams.FromRawUnchecked(rawData);
}
