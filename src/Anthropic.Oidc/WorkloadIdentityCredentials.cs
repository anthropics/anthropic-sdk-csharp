using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Anthropic.Oidc;

/// <summary>
/// OIDC workload identity federation credentials. Exchanges platform-issued JWTs for
/// short-lived Anthropic access tokens via the jwt-bearer grant type.
/// </summary>
public sealed class WorkloadIdentityCredentials : IAnthropicOidcCredentials, IAccessTokenProvider
{
    private readonly HttpClient _tokenHttpClient;
    private readonly IIdentityTokenProvider _identityTokenProvider;
    private readonly TokenCache _tokenCache;
    private readonly string _tokenEndpointUrl;
    private readonly string _federationRuleId;
    private readonly string? _organizationId;
    private readonly string? _serviceAccountId;
    private readonly bool _ownsHttpClient;

    public WorkloadIdentityCredentials(WorkloadIdentityOptions options)
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options));

        SecurityHelpers.EnforceHttps(options.BaseUrl);

        _federationRuleId = options.FederationRuleId;
        _organizationId = options.OrganizationId;
        _serviceAccountId = options.ServiceAccountId;
        _identityTokenProvider = options.IdentityTokenProvider;
        _tokenEndpointUrl = options.BaseUrl.TrimEnd('/') + OidcConstants.TokenEndpointPath;

        if (options.HttpClient != null)
        {
            _tokenHttpClient = options.HttpClient;
            _ownsHttpClient = false;
        }
        else
        {
            _tokenHttpClient = new HttpClient();
            _ownsHttpClient = true;
        }

        _tokenCache = new TokenCache(this);
    }

    public async ValueTask ApplyAsync(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken = default
    )
    {
        var token = await _tokenCache.GetTokenAsync(cancellationToken).ConfigureAwait(false);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
        // Append the OAuth beta header for API requests
        requestMessage.Headers.TryAddWithoutValidation(
            "anthropic-beta",
            OidcConstants.ApiRequestBetaValue
        );
    }

    public void InvalidateToken()
    {
        _tokenCache.Invalidate();
    }

    async Task<AccessToken> IAccessTokenProvider.GetTokenAsync(CancellationToken cancellationToken)
    {
        return await ExchangeTokenAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task<AccessToken> ExchangeTokenAsync(CancellationToken cancellationToken)
    {
        var jwt = await _identityTokenProvider
            .GetIdentityTokenAsync(cancellationToken)
            .ConfigureAwait(false);

        var requestBody = new Dictionary<string, string>
        {
            ["grant_type"] = OidcConstants.JwtBearerGrantType,
            ["assertion"] = jwt,
            ["federation_rule_id"] = _federationRuleId,
        };

        if (_organizationId != null)
        {
            requestBody["organization_id"] = _organizationId;
        }

        if (_serviceAccountId != null)
        {
            requestBody["service_account_id"] = _serviceAccountId;
        }

        var jsonContent = JsonSerializer.Serialize(requestBody);
        using var request = new HttpRequestMessage(HttpMethod.Post, _tokenEndpointUrl)
        {
            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json"),
        };

        // Token exchange uses BOTH beta headers
        request.Headers.TryAddWithoutValidation(
            "anthropic-beta",
            OidcConstants.TokenExchangeBetaValue
        );

        HttpResponseMessage response;
        try
        {
            response = await _tokenHttpClient
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (HttpRequestException ex)
        {
            throw new WorkloadIdentityException("Failed to connect to token endpoint.", ex);
        }

        using (response)
        {
            var responseBody = await response
                .Content
#if NET
                .ReadAsStringAsync(cancellationToken)
#else
            .ReadAsStringAsync()
#endif
                .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var redacted = SecurityHelpers.RedactErrorBody(responseBody);
                throw new WorkloadIdentityException(
                    $"Token exchange failed with status {(int)response.StatusCode}: {redacted}",
                    response.StatusCode,
                    redacted
                );
            }

            return ParseTokenResponse(responseBody);
        }
    }

    private static AccessToken ParseTokenResponse(string responseBody)
    {
        var root = JsonSerializer.Deserialize<JsonElement>(responseBody);

        if (
            !root.TryGetProperty("access_token", out var accessTokenElement)
            || accessTokenElement.ValueKind != JsonValueKind.String
        )
        {
            throw new WorkloadIdentityException(
                "Token exchange response missing 'access_token' field."
            );
        }

        var accessToken =
            accessTokenElement.GetString()
            ?? throw new WorkloadIdentityException(
                "Token exchange response 'access_token' is null."
            );

        long? expiresAt = null;
        if (root.TryGetProperty("expires_in", out var expiresInElement))
        {
            // Defensive: accept both Number and String forms.
            // The server has historically sent expires_in as a string.
            if (expiresInElement.ValueKind == JsonValueKind.Number)
            {
                expiresAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + expiresInElement.GetInt64();
            }
            else if (
                expiresInElement.ValueKind == JsonValueKind.String
                && long.TryParse(expiresInElement.GetString(), out var parsed)
            )
            {
                expiresAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + parsed;
            }
        }

        return new AccessToken(accessToken, expiresAt);
    }

    public void Dispose()
    {
        _tokenCache.Dispose();
        if (_ownsHttpClient)
        {
            _tokenHttpClient.Dispose();
        }
    }
}
