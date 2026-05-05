using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Credentials;

/// <summary>
/// OIDC workload identity federation credentials. Exchanges platform-issued JWTs for
/// short-lived Anthropic access tokens via the jwt-bearer grant type.
/// </summary>
public sealed class WorkloadIdentityCredentials : IAccessTokenProvider
{
    private readonly HttpClient _tokenHttpClient;
    private readonly IIdentityTokenProvider _identityTokenProvider;
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
        _tokenEndpointUrl = options.BaseUrl.TrimEnd('/') + CredentialsConstants.TokenEndpointPath;

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
    }

    public async ValueTask<AccessToken> GetTokenAsync(
        bool forceRefresh = false,
        CancellationToken cancellationToken = default
    )
    {
        // The exchange always fetches a fresh token, so forceRefresh is implicit.
        return await ExchangeTokenAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task<AccessToken> ExchangeTokenAsync(CancellationToken cancellationToken)
    {
        string jwt;
        try
        {
            jwt = await _identityTokenProvider
                .GetIdentityTokenAsync(cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception ex)
            when (ex is not OperationCanceledException and not WorkloadIdentityException)
        {
            throw new WorkloadIdentityException("Failed to obtain identity token.", ex);
        }

        var requestBody = new Dictionary<string, string>
        {
            ["grant_type"] = CredentialsConstants.JwtBearerGrantType,
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
            CredentialsConstants.TokenExchangeBetaValue
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
        catch (OperationCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            throw new WorkloadIdentityException("Token endpoint request timed out.", ex);
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
        var root = SecurityHelpers.DeserializeTokenResponse(responseBody);

        SecurityHelpers.RequireBearerTokenType(root);

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

        return new AccessToken(accessToken, SecurityHelpers.ParseExpiresIn(root));
    }

    public void Dispose()
    {
        if (_ownsHttpClient)
        {
            _tokenHttpClient.Dispose();
        }
    }
}
