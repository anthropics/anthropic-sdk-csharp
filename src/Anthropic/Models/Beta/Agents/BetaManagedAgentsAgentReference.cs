using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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

    public required ApiEnum<string, BetaManagedAgentsAgentReferenceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentReferenceType>
            >("type");
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
        this.Type.Validate();
        _ = this.Version;
    }

    public BetaManagedAgentsAgentReference() { }

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

[JsonConverter(typeof(BetaManagedAgentsAgentReferenceTypeConverter))]
public enum BetaManagedAgentsAgentReferenceType
{
    Agent,
}

sealed class BetaManagedAgentsAgentReferenceTypeConverter
    : JsonConverter<BetaManagedAgentsAgentReferenceType>
{
    public override BetaManagedAgentsAgentReferenceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent" => BetaManagedAgentsAgentReferenceType.Agent,
            _ => (BetaManagedAgentsAgentReferenceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentReferenceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentReferenceType.Agent => "agent",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
