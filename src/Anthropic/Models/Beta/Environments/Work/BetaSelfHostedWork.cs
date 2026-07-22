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
/// Work resource representing a unit of work in a self-hosted environment.
///
/// <para>Work items are queued when sessions are created or when long-dormant sessions
/// receive new messages. The environment worker polls for work to execute in a self-hosted sandbox.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaSelfHostedWork, BetaSelfHostedWorkFromRaw>))]
public sealed record class BetaSelfHostedWork : JsonModel
{
    /// <summary>
    /// Work identifier (e.g., 'work_...')
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
    /// RFC 3339 timestamp when the work item was acknowledged and assigned to a self-hosted sandbox
    /// </summary>
    public required string? AcknowledgedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("acknowledged_at");
        }
        init { this._rawData.Set("acknowledged_at", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp when work was created
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The actual work to be performed
    /// </summary>
    public required BetaSessionWorkData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaSessionWorkData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Environment identifier this work belongs to (e.g., `env_...`)
    /// </summary>
    public required string EnvironmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("environment_id");
        }
        init { this._rawData.Set("environment_id", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp of the most recent heartbeat
    /// </summary>
    public required string? LatestHeartbeatAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("latest_heartbeat_at");
        }
        init { this._rawData.Set("latest_heartbeat_at", value); }
    }

    /// <summary>
    /// User-provided metadata key-value pairs associated with this work item
    /// </summary>
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

    /// <summary>
    /// Credential payload used by the environment worker to execute this work item.
    /// May be populated when polling for work; null on all other retrieval paths.
    /// </summary>
    public required string? Secret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("secret");
        }
        init { this._rawData.Set("secret", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp when work execution started
    /// </summary>
    public required string? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("started_at");
        }
        init { this._rawData.Set("started_at", value); }
    }

    /// <summary>
    /// Current state of the work item
    /// </summary>
    public required ApiEnum<string, State> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, State>>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp when stop was requested
    /// </summary>
    public required string? StopRequestedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stop_requested_at");
        }
        init { this._rawData.Set("stop_requested_at", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp when work execution stopped
    /// </summary>
    public required string? StoppedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stopped_at");
        }
        init { this._rawData.Set("stopped_at", value); }
    }

    /// <summary>
    /// The type of object (always 'work')
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
        _ = this.ID;
        _ = this.AcknowledgedAt;
        _ = this.CreatedAt;
        this.Data.Validate();
        _ = this.EnvironmentID;
        _ = this.LatestHeartbeatAt;
        _ = this.Metadata;
        _ = this.Secret;
        _ = this.StartedAt;
        this.State.Validate();
        _ = this.StopRequestedAt;
        _ = this.StoppedAt;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("work")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSelfHostedWork()
    {
        this.Type = JsonSerializer.SerializeToElement("work");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSelfHostedWork(BetaSelfHostedWork betaSelfHostedWork)
        : base(betaSelfHostedWork) { }
#pragma warning restore CS8618

    public BetaSelfHostedWork(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("work");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSelfHostedWork(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSelfHostedWorkFromRaw.FromRawUnchecked"/>
    public static BetaSelfHostedWork FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSelfHostedWorkFromRaw : IFromRawJson<BetaSelfHostedWork>
{
    /// <inheritdoc/>
    public BetaSelfHostedWork FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaSelfHostedWork.FromRawUnchecked(rawData);
}

/// <summary>
/// Current state of the work item
/// </summary>
[JsonConverter(typeof(StateConverter))]
public enum State
{
    Queued,
    Starting,
    Active,
    Stopping,
    Stopped,
}

sealed class StateConverter : JsonConverter<State>
{
    public override State Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => State.Queued,
            "starting" => State.Starting,
            "active" => State.Active,
            "stopping" => State.Stopping,
            "stopped" => State.Stopped,
            _ => (State)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                State.Queued => "queued",
                State.Starting => "starting",
                State.Active => "active",
                State.Stopping => "stopping",
                State.Stopped => "stopped",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
