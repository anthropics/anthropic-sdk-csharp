using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Webhooks;

/// <summary>
/// Whether deliveries are sent to an organization webhook endpoint.
/// </summary>
[JsonConverter(typeof(BetaOrganizationWebhookEndpointStateConverter))]
public enum BetaOrganizationWebhookEndpointState
{
    Disabled,
    Enabled,
}

sealed class BetaOrganizationWebhookEndpointStateConverter
    : JsonConverter<BetaOrganizationWebhookEndpointState>
{
    public override BetaOrganizationWebhookEndpointState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaOrganizationWebhookEndpointState.Disabled,
            "enabled" => BetaOrganizationWebhookEndpointState.Enabled,
            _ => (BetaOrganizationWebhookEndpointState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaOrganizationWebhookEndpointState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaOrganizationWebhookEndpointState.Disabled => "disabled",
                BetaOrganizationWebhookEndpointState.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
