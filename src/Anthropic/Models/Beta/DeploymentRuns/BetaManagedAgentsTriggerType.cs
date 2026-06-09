using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// What triggered a deployment run.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsTriggerTypeConverter))]
public enum BetaManagedAgentsTriggerType
{
    Schedule,
    Manual,
}

sealed class BetaManagedAgentsTriggerTypeConverter : JsonConverter<BetaManagedAgentsTriggerType>
{
    public override BetaManagedAgentsTriggerType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "schedule" => BetaManagedAgentsTriggerType.Schedule,
            "manual" => BetaManagedAgentsTriggerType.Manual,
            _ => (BetaManagedAgentsTriggerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTriggerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTriggerType.Schedule => "schedule",
                BetaManagedAgentsTriggerType.Manual => "manual",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
