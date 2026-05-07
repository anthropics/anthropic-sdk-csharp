using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Credentials;

internal sealed class ConfigFile
{
    [JsonPropertyName("authentication")]
    public AuthenticationConfig? Authentication { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("workspace_id")]
    public string? WorkspaceId { get; set; }

    [JsonPropertyName("base_url")]
    public string? BaseUrl { get; set; }

    internal static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };
}

internal sealed class AuthenticationConfig
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("federation_rule_id")]
    public string? FederationRuleId { get; set; }

    [JsonPropertyName("service_account_id")]
    public string? ServiceAccountId { get; set; }

    [JsonPropertyName("identity_token")]
    public IdentityTokenConfig? IdentityToken { get; set; }

    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [JsonPropertyName("credentials_path")]
    public string? CredentialsPath { get; set; }
}

internal sealed class IdentityTokenConfig
{
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }
}

internal sealed class CredentialsFileData
{
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("expires_at")]
    public long? ExpiresAt { get; set; }

    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Captures any fields the SDK doesn't model explicitly (scope, organization_uuid,
    /// account_email, workspace_id, …) so they round-trip through a refresh write-back.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }

    internal static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
#if NET
        // Redundant with the explicit [JsonPropertyName] attributes above, but kept as a
        // safety net so new properties without an explicit name still serialize as snake_case.
        // This is .NET only, but on non-.NET targets the [JsonPropertyName] attributes will still
        // allow things to work.
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
#endif
    };
}
