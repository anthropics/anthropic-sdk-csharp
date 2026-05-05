using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Overall verdict of a credential validation probe.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsCredentialValidationStatusConverter))]
public enum BetaManagedAgentsCredentialValidationStatus
{
    Valid,
    Invalid,
    Unknown,
}

sealed class BetaManagedAgentsCredentialValidationStatusConverter
    : JsonConverter<BetaManagedAgentsCredentialValidationStatus>
{
    public override BetaManagedAgentsCredentialValidationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "valid" => BetaManagedAgentsCredentialValidationStatus.Valid,
            "invalid" => BetaManagedAgentsCredentialValidationStatus.Invalid,
            "unknown" => BetaManagedAgentsCredentialValidationStatus.Unknown,
            _ => (BetaManagedAgentsCredentialValidationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsCredentialValidationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsCredentialValidationStatus.Valid => "valid",
                BetaManagedAgentsCredentialValidationStatus.Invalid => "invalid",
                BetaManagedAgentsCredentialValidationStatus.Unknown => "unknown",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
