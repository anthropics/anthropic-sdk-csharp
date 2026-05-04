using System.Collections.Concurrent;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Oidc;

/// <summary>
/// Reads cached OAuth tokens from a credentials file on disk and handles refresh_token
/// exchanges when the access token has expired.
/// </summary>
public sealed class CredentialsFileProvider : IAnthropicOidcCredentials, IAccessTokenProvider
{
    // Per-file lock prevents concurrent refresh races when multiple CredentialsFileProvider
    // instances (or callers) target the same credentials file within one process.
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> s_fileLocks = new();

    private readonly string _credentialsFilePath;
    private readonly string _tokenEndpointUrl;
    private readonly HttpClient _tokenHttpClient;
    private readonly TokenCache _tokenCache;
    private readonly bool _ownsHttpClient;

    public CredentialsFileProvider(
        string credentialsFilePath,
        string? baseUrl = null,
        HttpClient? httpClient = null
    )
    {
        _credentialsFilePath =
            credentialsFilePath ?? throw new ArgumentNullException(nameof(credentialsFilePath));

        var effectiveBaseUrl = baseUrl ?? EnvironmentUrl.Production;
        SecurityHelpers.EnforceHttps(effectiveBaseUrl);
        _tokenEndpointUrl = effectiveBaseUrl.TrimEnd('/') + OidcConstants.TokenEndpointPath;

        if (httpClient != null)
        {
            _tokenHttpClient = httpClient;
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
        return await LoadOrRefreshAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task<AccessToken> LoadOrRefreshAsync(CancellationToken cancellationToken)
    {
        SecurityHelpers.CheckFilePermissions(_credentialsFilePath);

        var data = ReadCredentialsFile();

        if (data.AccessToken == null)
        {
            throw new WorkloadIdentityException(
                $"Credentials file {_credentialsFilePath} does not contain an access_token."
            );
        }

        // If the token has not expired, return it
        if (data.ExpiresAt != null)
        {
            var remaining = data.ExpiresAt.Value - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (remaining > OidcConstants.MandatoryRefreshSeconds)
            {
                return new AccessToken(data.AccessToken, data.ExpiresAt);
            }
        }
        else
        {
            // No expiration — treat as valid
            return new AccessToken(data.AccessToken, null);
        }

        // Token expired or about to expire: acquire per-file lock so that concurrent
        // callers sharing the same credentials file don't race on read-refresh-write.
        var fileLock = s_fileLocks.GetOrAdd(_credentialsFilePath, _ => new SemaphoreSlim(1, 1));
        await fileLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            // Re-read: another caller may have already refreshed the token while we waited.
            data = ReadCredentialsFile();
            if (data.AccessToken != null && data.ExpiresAt != null)
            {
                var remaining = data.ExpiresAt.Value - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                if (remaining > OidcConstants.MandatoryRefreshSeconds)
                {
                    return new AccessToken(data.AccessToken, data.ExpiresAt);
                }
            }

            if (data.RefreshToken == null)
            {
                throw new WorkloadIdentityException(
                    $"Access token in {_credentialsFilePath} is expired and no refresh_token is available."
                );
            }

            return await RefreshTokenAsync(data.RefreshToken, cancellationToken)
                .ConfigureAwait(false);
        }
        finally
        {
            fileLock.Release();
        }
    }

    private CredentialsFileData ReadCredentialsFile()
    {
        if (!File.Exists(_credentialsFilePath))
        {
            throw new FileNotFoundException(
                $"Credentials file not found: {_credentialsFilePath}",
                _credentialsFilePath
            );
        }

        var json = File.ReadAllText(_credentialsFilePath);
        var data =
            JsonSerializer.Deserialize<CredentialsFileData>(json, CredentialsFileData.JsonOptions)
            ?? throw new WorkloadIdentityException(
                $"Failed to parse credentials file: {_credentialsFilePath}"
            );

        if (data.Version != 1)
        {
            throw new WorkloadIdentityException(
                $"Unsupported credentials file version {data.Version} in {_credentialsFilePath}. Expected version 1."
            );
        }

        if (data.Type != "oauth_token")
        {
            throw new WorkloadIdentityException(
                $"Unexpected credentials type '{data.Type}' in {_credentialsFilePath}. Expected 'oauth_token'."
            );
        }

        return data;
    }

    private async Task<AccessToken> RefreshTokenAsync(
        string refreshToken,
        CancellationToken cancellationToken
    )
    {
        var requestBody = new Dictionary<string, string>
        {
            ["grant_type"] = OidcConstants.RefreshTokenGrantType,
            ["refresh_token"] = refreshToken,
        };

        var jsonContent = JsonSerializer.Serialize(requestBody);
        using var request = new HttpRequestMessage(HttpMethod.Post, _tokenEndpointUrl)
        {
            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json"),
        };

        // Refresh uses oauth beta only (NOT the federation beta)
        request.Headers.TryAddWithoutValidation("anthropic-beta", OidcConstants.RefreshBetaValue);

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
                    $"Token refresh failed with status {(int)response.StatusCode}: {redacted}",
                    response.StatusCode,
                    redacted
                );
            }

            var tokenResponse = ParseTokenResponse(responseBody);

            // Write the refreshed token back to the credentials file
            WriteRefreshedCredentials(tokenResponse, responseBody);

            return tokenResponse;
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
                "Token refresh response missing 'access_token' field."
            );
        }

        var accessToken =
            accessTokenElement.GetString()
            ?? throw new WorkloadIdentityException(
                "Token refresh response 'access_token' is null."
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

    private void WriteRefreshedCredentials(AccessToken token, string responseBody)
    {
        // Parse the response to extract the new refresh token if present
        var root = JsonSerializer.Deserialize<JsonElement>(responseBody);

        string? newRefreshToken = null;
        if (
            root.TryGetProperty("refresh_token", out var rtElement)
            && rtElement.ValueKind == JsonValueKind.String
        )
        {
            newRefreshToken = rtElement.GetString();
        }

        var credsData = new CredentialsFileData
        {
            Version = 1,
            Type = "oauth_token",
            AccessToken = token.Token,
            ExpiresAt = token.ExpiresAt,
            RefreshToken = newRefreshToken,
        };

        var json = JsonSerializer.Serialize(credsData, CredentialsFileData.JsonOptions);

        // Atomic write: serialize to a temp file then move into place, so a crash
        // mid-write never leaves a truncated/corrupt credentials file.
        var tempPath = _credentialsFilePath + ".tmp." + Guid.NewGuid().ToString("N");
        try
        {
            File.WriteAllText(tempPath, json);
#if NET
            File.Move(tempPath, _credentialsFilePath, overwrite: true);
#else
            if (File.Exists(_credentialsFilePath))
                File.Replace(tempPath, _credentialsFilePath, null);
            else
                File.Move(tempPath, _credentialsFilePath);
#endif
        }
        finally
        {
            // Clean up the temp file if the move/replace failed or was skipped
            File.Delete(tempPath);
        }
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
