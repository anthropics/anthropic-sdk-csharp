namespace Anthropic.Credentials;

internal static class CredentialsConstants
{
    // Beta headers
    internal const string OAuthBeta = "oauth-2025-04-20";
    internal const string FederationBeta = "oidc-federation-2026-04-01";

    // Combined beta header values
    internal const string ApiRequestBetaValue = OAuthBeta;
    internal const string TokenExchangeBetaValue = OAuthBeta + "," + FederationBeta;
    internal const string RefreshBetaValue = OAuthBeta;

    // Token cache thresholds
    internal const int AdvisoryRefreshSeconds = 120;
    internal const int MandatoryRefreshSeconds = 30;
    internal const int AdvisoryRefreshBackoffSeconds = 5;

    // OAuth grant types
    internal const string JwtBearerGrantType = "urn:ietf:params:oauth:grant-type:jwt-bearer";
    internal const string RefreshTokenGrantType = "refresh_token";

    // Token endpoint path
    internal const string TokenEndpointPath = "/v1/oauth/token";

    // Environment variable names
    internal const string EnvApiKey = "ANTHROPIC_API_KEY";
    internal const string EnvAuthToken = "ANTHROPIC_AUTH_TOKEN";
    internal const string EnvProfile = "ANTHROPIC_PROFILE";
    internal const string EnvConfigDir = "ANTHROPIC_CONFIG_DIR";
    internal const string EnvIdentityTokenFile = "ANTHROPIC_IDENTITY_TOKEN_FILE";
    internal const string EnvIdentityToken = "ANTHROPIC_IDENTITY_TOKEN";
    internal const string EnvFederationRuleId = "ANTHROPIC_FEDERATION_RULE_ID";
    internal const string EnvOrganizationId = "ANTHROPIC_ORGANIZATION_ID";
    internal const string EnvServiceAccountId = "ANTHROPIC_SERVICE_ACCOUNT_ID";

    // Error body redaction
    internal const int MaxErrorBodyLength = 2000;
}
