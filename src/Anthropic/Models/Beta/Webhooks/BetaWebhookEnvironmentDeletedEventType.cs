using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Webhooks;

[JsonConverter(typeof(BetaWebhookEnvironmentDeletedEventTypeConverter))]
public enum BetaWebhookEnvironmentDeletedEventType
{
    EnvironmentDeleted,
}

sealed class BetaWebhookEnvironmentDeletedEventTypeConverter
    : JsonConverter<BetaWebhookEnvironmentDeletedEventType>
{
    public override BetaWebhookEnvironmentDeletedEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment.deleted" => BetaWebhookEnvironmentDeletedEventType.EnvironmentDeleted,
            _ => (BetaWebhookEnvironmentDeletedEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebhookEnvironmentDeletedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWebhookEnvironmentDeletedEventType.EnvironmentDeleted => "environment.deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
