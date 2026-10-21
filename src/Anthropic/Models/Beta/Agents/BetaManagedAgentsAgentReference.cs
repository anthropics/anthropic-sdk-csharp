using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// A resolved agent reference with a concrete version.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentReference,
        BetaManagedAgentsAgentReferenceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentReference : JsonModel
{
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

    public required int Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("version");
        }
        init { this._rawData.Set("version", value); }
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

    public BetaManagedAgentsAgentReference()
    {
        this.Type = JsonSerializer.SerializeToElement("agent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentReference(
        BetaManagedAgentsAgentReference betaManagedAgentsAgentReference
    )
        : base(betaManagedAgentsAgentReference) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentReferenceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentReferenceFromRaw : IFromRawJson<BetaManagedAgentsAgentReference>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentReference.FromRawUnchecked(rawData);
}
