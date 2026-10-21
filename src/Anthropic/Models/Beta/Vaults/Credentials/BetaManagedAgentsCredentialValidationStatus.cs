using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

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
    /// The probe reached the MCP server and the server rejected the credential,
    /// or no access token is stored. A refresh, if one was tried, didn't recover
    /// it. Usually the end user needs to authorize again.
    /// </summary>
    Invalid,

    /// <summary>
    /// The probe couldn't tell whether the credential works, for example because
    /// of a network error or because a refresh succeeded but the new access token
    /// wasn't tested. Validate the credential again to find out.
    /// </summary>
    Unknown,
}

sealed class BetaManagedAgentsCredentialValidationStatusConverter
    : JsonConverter<BetaManagedAgentsCredentialValidationStatus>
{
    public override BetaManagedAgentsCredentialValidationStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
