using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Confirmation that a `session` has been permanently deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeletedSession,
        BetaManagedAgentsDeletedSessionFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeletedSession : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsDeletedSessionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsDeletedSessionType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public BetaManagedAgentsDeletedSession() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedSession(
        BetaManagedAgentsDeletedSession betaManagedAgentsDeletedSession
    )
        : base(betaManagedAgentsDeletedSession) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeletedSession(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeletedSession(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeletedSessionFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeletedSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeletedSessionFromRaw : IFromRawJson<BetaManagedAgentsDeletedSession>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedSession.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsDeletedSessionTypeConverter))]
public enum BetaManagedAgentsDeletedSessionType
{
    SessionDeleted,
}

sealed class BetaManagedAgentsDeletedSessionTypeConverter
    : JsonConverter<BetaManagedAgentsDeletedSessionType>
{
    public override BetaManagedAgentsDeletedSessionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session_deleted" => BetaManagedAgentsDeletedSessionType.SessionDeleted,
            _ => (BetaManagedAgentsDeletedSessionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeletedSessionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeletedSessionType.SessionDeleted => "session_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
