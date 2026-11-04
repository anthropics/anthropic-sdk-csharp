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
/// A work item's lease as the server holds it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaWorkLeaseState, BetaWorkLeaseStateFromRaw>))]
public sealed record class BetaWorkLeaseState : JsonModel
{
    /// <summary>
    /// RFC 3339 timestamp of the stored heartbeat, or null if there has been none
    /// </summary>
    public required string? LastHeartbeat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_heartbeat");
        }
        init { this._rawData.Set("last_heartbeat", value); }
    }

    /// <summary>
    /// Always false: a refused heartbeat does not extend the lease
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
    /// Current state of the work item
    /// </summary>
    public required ApiEnum<string, BetaWorkLeaseStateState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaWorkLeaseStateState>>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// TTL of the lease
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LastHeartbeat;
        _ = this.LeaseExtended;
        this.State.Validate();
        _ = this.TtlSeconds;
    }

    public BetaWorkLeaseState() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkLeaseState(BetaWorkLeaseState betaWorkLeaseState)
        : base(betaWorkLeaseState) { }
#pragma warning restore CS8618

    public BetaWorkLeaseState(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkLeaseState(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkLeaseStateFromRaw.FromRawUnchecked"/>
    public static BetaWorkLeaseState FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkLeaseStateFromRaw : IFromRawJson<BetaWorkLeaseState>
{
    /// <inheritdoc/>
    public BetaWorkLeaseState FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaWorkLeaseState.FromRawUnchecked(rawData);
}

/// <summary>
/// Current state of the work item
/// </summary>
[JsonConverter(typeof(BetaWorkLeaseStateStateConverter))]
public enum BetaWorkLeaseStateState
{
    Queued,
    Starting,
    Active,
    Stopping,
    Stopped,
}

sealed class BetaWorkLeaseStateStateConverter : JsonConverter<BetaWorkLeaseStateState>
{
    public override BetaWorkLeaseStateState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => BetaWorkLeaseStateState.Queued,
            "starting" => BetaWorkLeaseStateState.Starting,
            "active" => BetaWorkLeaseStateState.Active,
            "stopping" => BetaWorkLeaseStateState.Stopping,
            "stopped" => BetaWorkLeaseStateState.Stopped,
            _ => (BetaWorkLeaseStateState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWorkLeaseStateState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWorkLeaseStateState.Queued => "queued",
                BetaWorkLeaseStateState.Starting => "starting",
                BetaWorkLeaseStateState.Active => "active",
                BetaWorkLeaseStateState.Stopping => "stopping",
                BetaWorkLeaseStateState.Stopped => "stopped",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
