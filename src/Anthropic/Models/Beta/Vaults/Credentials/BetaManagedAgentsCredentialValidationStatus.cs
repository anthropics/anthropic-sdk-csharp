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
    /// <summary>
    /// The credential successfully authenticated against its MCP server.
    /// </summary>
    Valid,

    /// <summary>
    /// The probe reached the MCP server and was rejected, and a refresh (if attempted)
    /// did not recover it.
    /// </summary>
    Invalid,

    /// <summary>
    /// The probe could not determine validity — for example, a transport error or
    /// a successful refresh that was not re-probed.
    /// </summary>
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
