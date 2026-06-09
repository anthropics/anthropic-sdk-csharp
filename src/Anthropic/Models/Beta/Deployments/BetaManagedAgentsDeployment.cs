using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A deployment is a configured instance of an agent — it binds the agent to everything
/// needed to run it autonomously: an environment, credentials, initial events, and
/// an optional schedule.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsDeployment, BetaManagedAgentsDeploymentFromRaw>)
)]
public sealed record class BetaManagedAgentsDeployment : JsonModel
{
    /// <summary>
    /// Unique identifier for this deployment.
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
    /// A resolved agent reference with a concrete version.
    /// </summary>
    public required BetaManagedAgentsAgentReference Agent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsAgentReference>("agent");
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
    /// Description of what the deployment does.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// ID of the `environment` where sessions run.
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
    /// Events sent to each session immediately after creation.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsDeploymentInitialEvent> InitialEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsDeploymentInitialEvent>
            >("initial_events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsDeploymentInitialEvent>>(
                "initial_events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Arbitrary key-value metadata. Maximum 16 pairs.
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
    /// Human-readable name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Why a deployment is paused. Non-null exactly when `status` is `paused`.
    /// </summary>
    public required BetaManagedAgentsDeploymentPausedReason? PausedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsDeploymentPausedReason>(
                "paused_reason"
            );
        }
        init { this._rawData.Set("paused_reason", value); }
    }

    /// <summary>
    /// Resources attached to sessions created from this deployment. Echoes the input
    /// minus write-only credentials.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsSessionResourceConfig> Resources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsSessionResourceConfig>
            >("resources");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSessionResourceConfig>>(
                "resources",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// 5-field POSIX cron schedule with computed runtime timestamps.
    /// </summary>
    public required BetaManagedAgentsSchedule? Schedule
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsSchedule>("schedule");
        }
        init { this._rawData.Set("schedule", value); }
    }

    /// <summary>
    /// Lifecycle status of a deployment.
    /// </summary>
    public required ApiEnum<string, BetaManagedAgentsDeploymentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsDeploymentStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsDeploymentType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsDeploymentType>>(
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
    /// Vault IDs supplying stored credentials for sessions created from this deployment.
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
        _ = this.Description;
        _ = this.EnvironmentID;
        foreach (var item in this.InitialEvents)
        {
            item.Validate();
        }
        _ = this.Metadata;
        _ = this.Name;
        this.PausedReason?.Validate();
        foreach (var item in this.Resources)
        {
            item.Validate();
        }
        this.Schedule?.Validate();
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
        _ = this.VaultIds;
    }

    public BetaManagedAgentsDeployment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeployment(BetaManagedAgentsDeployment betaManagedAgentsDeployment)
        : base(betaManagedAgentsDeployment) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeployment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeployment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeploymentFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeploymentFromRaw : IFromRawJson<BetaManagedAgentsDeployment>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeployment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsDeploymentTypeConverter))]
public enum BetaManagedAgentsDeploymentType
{
    Deployment,
}

sealed class BetaManagedAgentsDeploymentTypeConverter
    : JsonConverter<BetaManagedAgentsDeploymentType>
{
    public override BetaManagedAgentsDeploymentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deployment" => BetaManagedAgentsDeploymentType.Deployment,
            _ => (BetaManagedAgentsDeploymentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeploymentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeploymentType.Deployment => "deployment",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
