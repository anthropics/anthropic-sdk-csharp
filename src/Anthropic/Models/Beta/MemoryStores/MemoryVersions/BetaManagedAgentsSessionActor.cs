using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsSessionActor, BetaManagedAgentsSessionActorFromRaw>)
)]
public sealed record class BetaManagedAgentsSessionActor : JsonModel
{
    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionActorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionActorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SessionID;
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionActor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionActor(
        BetaManagedAgentsSessionActor betaManagedAgentsSessionActor
    )
        : base(betaManagedAgentsSessionActor) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionActorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionActorFromRaw : IFromRawJson<BetaManagedAgentsSessionActor>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionActor.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionActorTypeConverter))]
public enum BetaManagedAgentsSessionActorType
{
    SessionActor,
}

sealed class BetaManagedAgentsSessionActorTypeConverter
    : JsonConverter<BetaManagedAgentsSessionActorType>
{
    public override BetaManagedAgentsSessionActorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session_actor" => BetaManagedAgentsSessionActorType.SessionActor,
            _ => (BetaManagedAgentsSessionActorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionActorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionActorType.SessionActor => "session_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
