using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// EventDeltaType enum
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsDeltaTypeConverter))]
public enum BetaManagedAgentsDeltaType
{
    AgentMessage,
    AgentThinking,
}

sealed class BetaManagedAgentsDeltaTypeConverter : JsonConverter<BetaManagedAgentsDeltaType>
{
    public override BetaManagedAgentsDeltaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.message" => BetaManagedAgentsDeltaType.AgentMessage,
            "agent.thinking" => BetaManagedAgentsDeltaType.AgentThinking,
            _ => (BetaManagedAgentsDeltaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeltaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeltaType.AgentMessage => "agent.message",
                BetaManagedAgentsDeltaType.AgentThinking => "agent.thinking",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
