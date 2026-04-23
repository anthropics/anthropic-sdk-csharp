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
    typeof(JsonModelConverter<BetaManagedAgentsApiActor, BetaManagedAgentsApiActorFromRaw>)
)]
public sealed record class BetaManagedAgentsApiActor : JsonModel
{
    public required string ApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("api_key_id");
        }
        init { this._rawData.Set("api_key_id", value); }
    }

    public required ApiEnum<
        string,
        global::Anthropic.Models.Beta.MemoryStores.MemoryVersions.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.MemoryStores.MemoryVersions.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKeyID;
        this.Type.Validate();
    }

    public BetaManagedAgentsApiActor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsApiActor(BetaManagedAgentsApiActor betaManagedAgentsApiActor)
        : base(betaManagedAgentsApiActor) { }
#pragma warning restore CS8618

    public BetaManagedAgentsApiActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsApiActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsApiActorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsApiActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsApiActorFromRaw : IFromRawJson<BetaManagedAgentsApiActor>
{
    /// <inheritdoc/>
    public BetaManagedAgentsApiActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsApiActor.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    ApiActor,
}

sealed class TypeConverter
    : JsonConverter<global::Anthropic.Models.Beta.MemoryStores.MemoryVersions.Type>
{
    public override global::Anthropic.Models.Beta.MemoryStores.MemoryVersions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api_actor" => global::Anthropic.Models.Beta.MemoryStores.MemoryVersions.Type.ApiActor,
            _ => (global::Anthropic.Models.Beta.MemoryStores.MemoryVersions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.MemoryStores.MemoryVersions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.MemoryStores.MemoryVersions.Type.ApiActor =>
                    "api_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
