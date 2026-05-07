using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Threads;

/// <summary>
/// SessionThreadStatus enum
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionThreadStatusConverter))]
public enum BetaManagedAgentsSessionThreadStatus
{
    Running,
    Idle,
    Rescheduling,
    Terminated,
}

sealed class BetaManagedAgentsSessionThreadStatusConverter
    : JsonConverter<BetaManagedAgentsSessionThreadStatus>
{
    public override BetaManagedAgentsSessionThreadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => BetaManagedAgentsSessionThreadStatus.Running,
            "idle" => BetaManagedAgentsSessionThreadStatus.Idle,
            "rescheduling" => BetaManagedAgentsSessionThreadStatus.Rescheduling,
            "terminated" => BetaManagedAgentsSessionThreadStatus.Terminated,
            _ => (BetaManagedAgentsSessionThreadStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionThreadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionThreadStatus.Running => "running",
                BetaManagedAgentsSessionThreadStatus.Idle => "idle",
                BetaManagedAgentsSessionThreadStatus.Rescheduling => "rescheduling",
                BetaManagedAgentsSessionThreadStatus.Terminated => "terminated",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
