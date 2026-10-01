using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// Lifecycle status of a deployment.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsDeploymentStatusConverter))]
public enum BetaManagedAgentsDeploymentStatus
{
    /// <summary>
    /// The deployment is active and can run sessions. Archived deployments also report
    /// this status; check `archived_at` to distinguish them.
    /// </summary>
    Active,

    /// <summary>
    /// The deployment is paused. Autonomous triggers are suppressed; manual runs
    /// are still permitted.
    /// </summary>
    Paused,
}

sealed class BetaManagedAgentsDeploymentStatusConverter
    : JsonConverter<BetaManagedAgentsDeploymentStatus>
{
    public override BetaManagedAgentsDeploymentStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => BetaManagedAgentsDeploymentStatus.Active,
            "paused" => BetaManagedAgentsDeploymentStatus.Paused,
            _ => (BetaManagedAgentsDeploymentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeploymentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeploymentStatus.Active => "active",
                BetaManagedAgentsDeploymentStatus.Paused => "paused",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
