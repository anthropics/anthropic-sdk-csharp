using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

[JsonConverter(typeof(BetaManagedAgentsAgentEvaluatedPermissionConverter))]
public enum BetaManagedAgentsAgentEvaluatedPermission
{
    Allow,
    Ask,
    Deny,
}

sealed class BetaManagedAgentsAgentEvaluatedPermissionConverter
    : JsonConverter<BetaManagedAgentsAgentEvaluatedPermission>
{
    public override BetaManagedAgentsAgentEvaluatedPermission Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow" => BetaManagedAgentsAgentEvaluatedPermission.Allow,
            "ask" => BetaManagedAgentsAgentEvaluatedPermission.Ask,
            "deny" => BetaManagedAgentsAgentEvaluatedPermission.Deny,
            _ => (BetaManagedAgentsAgentEvaluatedPermission)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentEvaluatedPermission value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentEvaluatedPermission.Allow => "allow",
                BetaManagedAgentsAgentEvaluatedPermission.Ask => "ask",
                BetaManagedAgentsAgentEvaluatedPermission.Deny => "deny",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
