using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Resources;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// A Managed Agents `session`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsSession, BetaManagedAgentsSessionFromRaw>)
)]
public sealed record class BetaManagedAgentsSession : JsonModel
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

    /// <summary>
    /// Resolved `agent` definition for a `session`. Snapshot of the `agent` at `session`
    /// creation time.
    /// </summary>
    public required BetaManagedAgentsSessionAgent Agent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSessionAgent>("agent");
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

    public required string EnvironmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("environment_id");
        }
        init { this._rawData.Set("environment_id", value); }
    }

    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required IReadOnlyList<BetaManagedAgentsSessionResource> Resources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsSessionResource>>(
                "resources"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSessionResource>>(
                "resources",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timing statistics for a session.
    /// </summary>
    public required BetaManagedAgentsSessionStats Stats
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSessionStats>("stats");
        }
        init { this._rawData.Set("stats", value); }
    }

    /// <summary>
    /// SessionStatus enum
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsSessionType>>(
                "type"
            );
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
    /// Cumulative token usage for a session across all turns.
    /// </summary>
    public required BetaManagedAgentsSessionUsage Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSessionUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <summary>
    /// Vault IDs attached to the session at creation. Empty when no vaults were supplied.
    /// </summary>
    public required IReadOnlyList<string> VaultIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("vault_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "vault_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Agent.Validate();
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.EnvironmentID;
        _ = this.Metadata;
        foreach (var item in this.Resources)
        {
            item.Validate();
        }
        this.Stats.Validate();
        this.Status.Validate();
        _ = this.Title;
        this.Type.Validate();
        _ = this.UpdatedAt;
        this.Usage.Validate();
        _ = this.VaultIds;
    }

    public BetaManagedAgentsSession() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSession(BetaManagedAgentsSession betaManagedAgentsSession)
        : base(betaManagedAgentsSession) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSession(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSession(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionFromRaw : IFromRawJson<BetaManagedAgentsSession>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSession.FromRawUnchecked(rawData);
}

/// <summary>
/// SessionStatus enum
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Rescheduling,
    Running,
    Idle,
    Terminated,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rescheduling" => Status.Rescheduling,
            "running" => Status.Running,
            "idle" => Status.Idle,
            "terminated" => Status.Terminated,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Rescheduling => "rescheduling",
                Status.Running => "running",
                Status.Idle => "idle",
                Status.Terminated => "terminated",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BetaManagedAgentsSessionTypeConverter))]
public enum BetaManagedAgentsSessionType
{
    Session,
}

sealed class BetaManagedAgentsSessionTypeConverter : JsonConverter<BetaManagedAgentsSessionType>
{
    public override BetaManagedAgentsSessionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session" => BetaManagedAgentsSessionType.Session,
            _ => (BetaManagedAgentsSessionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionType.Session => "session",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
