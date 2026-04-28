using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// Attribution for a write made by a human user through the Anthropic Console.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsUserActor, BetaManagedAgentsUserActorFromRaw>)
)]
public sealed record class BetaManagedAgentsUserActor : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsUserActorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsUserActorType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// ID of the user who performed the write (a `user_...` value).
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.UserID;
    }

    public BetaManagedAgentsUserActor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserActor(BetaManagedAgentsUserActor betaManagedAgentsUserActor)
        : base(betaManagedAgentsUserActor) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserActorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserActorFromRaw : IFromRawJson<BetaManagedAgentsUserActor>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserActor.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUserActorTypeConverter))]
public enum BetaManagedAgentsUserActorType
{
    UserActor,
}

sealed class BetaManagedAgentsUserActorTypeConverter : JsonConverter<BetaManagedAgentsUserActorType>
{
    public override BetaManagedAgentsUserActorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_actor" => BetaManagedAgentsUserActorType.UserActor,
            _ => (BetaManagedAgentsUserActorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserActorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserActorType.UserActor => "user_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
