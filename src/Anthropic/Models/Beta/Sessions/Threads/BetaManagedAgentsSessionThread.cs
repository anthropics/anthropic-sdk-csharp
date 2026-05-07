using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Threads;

/// <summary>
/// An execution thread within a `session`. Each session has one primary thread plus
/// zero or more child threads spawned by the coordinator.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionThread,
        BetaManagedAgentsSessionThreadFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionThread : JsonModel
{
    /// <summary>
    /// Unique identifier for this thread.
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

    /// <summary>
    /// Resolved `agent` definition for a single `session_thread`. Snapshot of the
    /// agent at thread creation time. The multiagent roster is not repeated here;
    /// read it from `Session.agent`.
    /// </summary>
    public required BetaManagedAgentsSessionThreadAgent Agent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSessionThreadAgent>("agent");
        }
        init { this._rawData.Set("agent", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Parent thread that spawned this thread. Null for the primary thread.
    /// </summary>
    public required string? ParentThreadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parent_thread_id");
        }
        init { this._rawData.Set("parent_thread_id", value); }
    }

    /// <summary>
    /// The session this thread belongs to.
    /// </summary>
    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// Timing statistics for a session thread.
    /// </summary>
    public required BetaManagedAgentsSessionThreadStats? Stats
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsSessionThreadStats>("stats");
        }
        init { this._rawData.Set("stats", value); }
    }

    /// <summary>
    /// SessionThreadStatus enum
    /// </summary>
    public required ApiEnum<string, BetaManagedAgentsSessionThreadStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionThreadStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Threads.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Threads.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Cumulative token usage for a session thread across all turns.
    /// </summary>
    public required BetaManagedAgentsSessionThreadUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsSessionThreadUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Agent.Validate();
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.ParentThreadID;
        _ = this.SessionID;
        this.Stats?.Validate();
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
        this.Usage?.Validate();
    }

    public BetaManagedAgentsSessionThread() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionThread(
        BetaManagedAgentsSessionThread betaManagedAgentsSessionThread
    )
        : base(betaManagedAgentsSessionThread) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionThread(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionThread(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionThreadFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionThread FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionThreadFromRaw : IFromRawJson<BetaManagedAgentsSessionThread>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionThread FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionThread.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    SessionThread,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Sessions.Threads.Type>
{
    public override global::Anthropic.Models.Beta.Sessions.Threads.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session_thread" => global::Anthropic.Models.Beta.Sessions.Threads.Type.SessionThread,
            _ => (global::Anthropic.Models.Beta.Sessions.Threads.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Sessions.Threads.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Sessions.Threads.Type.SessionThread =>
                    "session_thread",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
