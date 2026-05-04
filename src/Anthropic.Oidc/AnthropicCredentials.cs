using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Oidc;

/// <summary>
/// Resolves OIDC credentials from environment variables and configuration files.
/// </summary>
public static class AnthropicCredentials
{
    /// <summary>
    /// Resolves credentials from environment variables and config files.
    /// Returns <c>null</c> if <c>ANTHROPIC_API_KEY</c> is set (existing API key auth handles it).
    /// </summary>
    /// <param name="profile">Override profile name. Defaults to <c>ANTHROPIC_PROFILE</c> env var
    /// or the active_config file.</param>
    /// <param name="baseUrl">Override base URL. Defaults to config file value or
    /// <see cref="EnvironmentUrl.Production"/>.</param>
    /// <param name="httpClient">Optional <see cref="HttpClient"/> for token exchange requests.</param>
    /// <returns>Resolved credentials, or <c>null</c> if API key auth should be used instead.</returns>
    public static CredentialResult? Resolve(
        string? profile = null,
        string? baseUrl = null,
        HttpClient? httpClient = null
    )
    {
        // ANTHROPIC_API_KEY
        var apiKey = Environment.GetEnvironmentVariable(OidcConstants.EnvApiKey);
        if (!string.IsNullOrEmpty(apiKey))
        {
            return null;
        }

        // ANTHROPIC_AUTH_TOKEN (static bearer token)
        var authToken = Environment.GetEnvironmentVariable(OidcConstants.EnvAuthToken);
        if (!string.IsNullOrEmpty(authToken))
        {
            return new CredentialResult(new StaticTokenCredentials(authToken));
        }

        // Resolution order per the credential spec:
        //   1. explicit API key / auth token (handled above)
        //   2. explicit profile selection: the `profile` argument, or the
        //      ANTHROPIC_PROFILE env var. Errors propagate.
        //   3. env-var workload identity federation
        //   4. fallback active profile from disk (active_config pointer
        //      or `default` profile) — errors swallowed
        //
        // Step 3 must sit above step 4 so that a machine with WIF env vars
        // wired up preempts a leftover `active_config` pointer or stale
        // `default` profile from a past `ant auth login`. ANTHROPIC_PROFILE
        // still wins (step 2) because the user explicitly named a profile.
        //
        // ANTHROPIC_CONFIG_DIR alone does NOT count as explicit profile
        // selection — it just redirects where profiles are searched.
        // Combined with ANTHROPIC_PROFILE it still flows through step 2;
        // without PROFILE it flows through step 4, like the default case.
        var profileExplicit =
            profile ?? Environment.GetEnvironmentVariable(OidcConstants.EnvProfile);
        var configDirExplicit = Environment.GetEnvironmentVariable(OidcConstants.EnvConfigDir);

        // Step 2: explicit profile selection — errors propagate.
        // Only PROFILE qualifies; CONFIG_DIR alone does not.
        if (profileExplicit != null)
        {
            var explicitResult = TryResolveFromConfig(profileExplicit, baseUrl, httpClient);
            if (explicitResult != null)
            {
                return explicitResult;
            }
        }

        // Step 3: env-var workload identity federation.
        var envResult = TryResolveFromEnvVars(baseUrl, httpClient);
        if (envResult != null)
        {
            return envResult;
        }

        // Step 4: fallback active profile from disk. Skipped when PROFILE is
        // set — step 2 already exhausted that profile, and ConfigPaths.
        // GetActiveProfile() would resolve to the same value. Errors
        // propagate when the user set CONFIG_DIR explicitly, otherwise
        // they're swallowed so a corrupt unselected profile doesn't break
        // construction.
        if (profileExplicit == null)
        {
            try
            {
                var fallbackResult = TryResolveFromConfig(
                    ConfigPaths.GetActiveProfile(),
                    baseUrl,
                    httpClient
                );
                if (fallbackResult != null)
                {
                    return fallbackResult;
                }
            }
            catch (Exception) when (configDirExplicit == null)
            {
                // Auto-discovered config: swallow errors and fall through.
            }
        }

        return null;
    }

    private static CredentialResult? TryResolveFromConfig(
        string profile,
        string? baseUrlOverride,
        HttpClient? httpClient
    )
    {
        var configPath = ConfigPaths.GetConfigFilePath(profile);
        if (!File.Exists(configPath))
        {
            return null;
        }

        var configJson = File.ReadAllText(configPath);
        var config = JsonSerializer.Deserialize<ConfigFile>(configJson, ConfigFile.JsonOptions);
        if (config?.Authentication == null)
        {
            return null;
        }

        var effectiveBaseUrl = baseUrlOverride ?? config.BaseUrl ?? EnvironmentUrl.Production;
        var extraHeaders = new Dictionary<string, string>();

        if (!string.IsNullOrEmpty(config.WorkspaceId))
        {
            extraHeaders["anthropic-workspace-id"] = config.WorkspaceId!;
        }

        var auth = config.Authentication;

        if (auth.Type == "oidc_federation")
        {
            if (string.IsNullOrEmpty(auth.FederationRuleId))
            {
                throw new WorkloadIdentityException(
                    $"Config profile '{profile}' has type 'oidc_federation' but no federation_rule_id."
                );
            }

            IIdentityTokenProvider identityProvider;
            if (
                auth.IdentityToken?.Source == "file"
                && !string.IsNullOrEmpty(auth.IdentityToken.Path)
            )
            {
                identityProvider = new FileIdentityTokenProvider(auth.IdentityToken.Path!);
            }
            else
            {
                throw new WorkloadIdentityException(
                    $"Config profile '{profile}' has type 'oidc_federation' but no valid identity_token configuration."
                );
            }

            var creds = new WorkloadIdentityCredentials(
                new WorkloadIdentityOptions
                {
                    FederationRuleId = auth.FederationRuleId!,
                    OrganizationId = config.OrganizationId,
                    ServiceAccountId = auth.ServiceAccountId,
                    IdentityTokenProvider = identityProvider,
                    BaseUrl = effectiveBaseUrl,
                    HttpClient = httpClient,
                }
            );

            return new CredentialResult(creds, extraHeaders);
        }

        if (auth.Type == "user_oauth")
        {
            var credentialsPath =
                auth.CredentialsPath ?? ConfigPaths.GetCredentialsFilePath(profile);
            var creds = new CredentialsFileProvider(credentialsPath, effectiveBaseUrl, httpClient);

            return new CredentialResult(creds, extraHeaders);
        }

        return null;
    }

    private static CredentialResult? TryResolveFromEnvVars(
        string? baseUrlOverride,
        HttpClient? httpClient
    )
    {
        var identityTokenFile = Environment.GetEnvironmentVariable(
            OidcConstants.EnvIdentityTokenFile
        );
        var identityToken = Environment.GetEnvironmentVariable(OidcConstants.EnvIdentityToken);
        var federationRule = Environment.GetEnvironmentVariable(OidcConstants.EnvFederationRuleId);

        if (string.IsNullOrEmpty(federationRule))
        {
            return null;
        }

        IIdentityTokenProvider? identityProvider = null;
        if (!string.IsNullOrEmpty(identityTokenFile))
        {
            identityProvider = new FileIdentityTokenProvider(identityTokenFile!);
        }
        else if (!string.IsNullOrEmpty(identityToken))
        {
            identityProvider = new StaticIdentityTokenProvider(identityToken!);
        }

        if (identityProvider == null)
        {
            return null;
        }

        var effectiveBaseUrl = baseUrlOverride ?? EnvironmentUrl.Production;

        var creds = new WorkloadIdentityCredentials(
            new WorkloadIdentityOptions
            {
                FederationRuleId = federationRule!,
                OrganizationId = Environment.GetEnvironmentVariable(
                    OidcConstants.EnvOrganizationId
                ),
                ServiceAccountId = Environment.GetEnvironmentVariable(
                    OidcConstants.EnvServiceAccountId
                ),
                IdentityTokenProvider = identityProvider,
                BaseUrl = effectiveBaseUrl,
                HttpClient = httpClient,
            }
        );

        return new CredentialResult(creds);
    }
}

/// <summary>
/// The result of credential resolution, bundling credentials with any extra headers
/// from the profile configuration.
/// </summary>
public sealed class CredentialResult
{
    /// <summary>
    /// The resolved credentials.
    /// </summary>
    public IAnthropicOidcCredentials Credentials { get; }

    /// <summary>
    /// Extra headers to include in API requests (e.g., <c>anthropic-workspace-id</c>).
    /// </summary>
    public IReadOnlyDictionary<string, string> ExtraHeaders { get; }

    public CredentialResult(IAnthropicOidcCredentials credentials)
        : this(credentials, new Dictionary<string, string>()) { }

    public CredentialResult(
        IAnthropicOidcCredentials credentials,
        IReadOnlyDictionary<string, string> extraHeaders
    )
    {
        Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        ExtraHeaders = extraHeaders ?? throw new ArgumentNullException(nameof(extraHeaders));
    }
}
