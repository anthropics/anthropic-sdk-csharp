using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Environments.Work;

/// <summary>
/// Response after recording a heartbeat for a work item.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSelfHostedWorkHeartbeatResponse,
        BetaSelfHostedWorkHeartbeatResponseFromRaw
    >)
)]
public sealed record class BetaSelfHostedWorkHeartbeatResponse : JsonModel
{
    /// <summary>
    /// RFC 3339 timestamp of the actual heartbeat from DB
    /// </summary>
    public required string LastHeartbeat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last_heartbeat");
        }
        init { this._rawData.Set("last_heartbeat", value); }
    }

    /// <summary>
    /// Whether the heartbeat succeeded in extending the lease
    /// </summary>
    public required bool LeaseExtended
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("lease_extended");
        }
        init { this._rawData.Set("lease_extended", value); }
    }

    /// <summary>
    /// Current state of the work item (active/stopping/stopped)
    /// </summary>
    public required ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState>
            >("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// Effective TTL applied to the lease
    /// </summary>
    public required long TtlSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("ttl_seconds");
        }
        init { this._rawData.Set("ttl_seconds", value); }
    }

    /// <summary>
    /// The type of response
    /// </summary>
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
        _ = this.LastHeartbeat;
        _ = this.LeaseExtended;
        this.State.Validate();
        _ = this.TtlSeconds;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("work_heartbeat")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSelfHostedWorkHeartbeatResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("work_heartbeat");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSelfHostedWorkHeartbeatResponse(
        BetaSelfHostedWorkHeartbeatResponse betaSelfHostedWorkHeartbeatResponse
    )
        : base(betaSelfHostedWorkHeartbeatResponse) { }
#pragma warning restore CS8618

    public BetaSelfHostedWorkHeartbeatResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("work_heartbeat");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSelfHostedWorkHeartbeatResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSelfHostedWorkHeartbeatResponseFromRaw.FromRawUnchecked"/>
    public static BetaSelfHostedWorkHeartbeatResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSelfHostedWorkHeartbeatResponseFromRaw : IFromRawJson<BetaSelfHostedWorkHeartbeatResponse>
{
    /// <inheritdoc/>
    public BetaSelfHostedWorkHeartbeatResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSelfHostedWorkHeartbeatResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current state of the work item (active/stopping/stopped)
/// </summary>
[JsonConverter(typeof(BetaSelfHostedWorkHeartbeatResponseStateConverter))]
public enum BetaSelfHostedWorkHeartbeatResponseState
{
    Queued,
    Starting,
    Active,
    Stopping,
    Stopped,
}

sealed class BetaSelfHostedWorkHeartbeatResponseStateConverter
    : JsonConverter<BetaSelfHostedWorkHeartbeatResponseState>
{
    public override BetaSelfHostedWorkHeartbeatResponseState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => BetaSelfHostedWorkHeartbeatResponseState.Queued,
            "starting" => BetaSelfHostedWorkHeartbeatResponseState.Starting,
            "active" => BetaSelfHostedWorkHeartbeatResponseState.Active,
            "stopping" => BetaSelfHostedWorkHeartbeatResponseState.Stopping,
            "stopped" => BetaSelfHostedWorkHeartbeatResponseState.Stopped,
            _ => (BetaSelfHostedWorkHeartbeatResponseState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSelfHostedWorkHeartbeatResponseState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaSelfHostedWorkHeartbeatResponseState.Queued => "queued",
                BetaSelfHostedWorkHeartbeatResponseState.Starting => "starting",
                BetaSelfHostedWorkHeartbeatResponseState.Active => "active",
                BetaSelfHostedWorkHeartbeatResponseState.Stopping => "stopping",
                BetaSelfHostedWorkHeartbeatResponseState.Stopped => "stopped",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
