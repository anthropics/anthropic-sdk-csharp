using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
#if !NET
using System.Runtime.InteropServices;
#endif

namespace Anthropic.Credentials;

/// <summary>
/// Reads cached OAuth tokens from a credentials file on disk and handles refresh_token
/// exchanges when the access token has expired.
///
/// <para>On netstandard2.0 there is no API to set Unix file permissions, so the
/// refreshed file is written with umask defaults (typically 0644 on Linux/macOS).
/// Target .NET 8+ or chmod the file out-of-band to enforce 0600.</para>
/// </summary>
public sealed class CredentialsFileProvider : IAccessTokenProvider
{
    // Per-file lock prevents concurrent refresh races when multiple CredentialsFileProvider
    // instances (or callers) target the same credentials file within one process.
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> s_fileLocks = new();

#if !NET
    private static int s_netstandardPermWarningEmitted;
#endif

    private readonly string _credentialsFilePath;
    private readonly string _tokenEndpointUrl;
    private readonly string? _clientId;
    private readonly HttpClient _tokenHttpClient;
    private readonly bool _ownsHttpClient;

    public CredentialsFileProvider(
        string credentialsFilePath,
        string? baseUrl = null,
        HttpClient? httpClient = null,
        string? clientId = null
    )
    {
        _credentialsFilePath =
            credentialsFilePath ?? throw new ArgumentNullException(nameof(credentialsFilePath));
        _clientId = clientId;

        var effectiveBaseUrl = baseUrl ?? EnvironmentUrl.Production;
        SecurityHelpers.EnforceHttps(effectiveBaseUrl);
        _tokenEndpointUrl = effectiveBaseUrl.TrimEnd('/') + CredentialsConstants.TokenEndpointPath;

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
    }

    public async ValueTask<AccessToken> GetTokenAsync(
        bool forceRefresh = false,
        CancellationToken cancellationToken = default
    )
    {
        return await LoadOrRefreshAsync(forceRefresh, cancellationToken).ConfigureAwait(false);
    }

    private async Task<AccessToken> LoadOrRefreshAsync(
        bool forceRefresh,
        CancellationToken cancellationToken
    )
    {
        var data = ReadCredentialsFile();

        if (data.AccessToken == null)
        {
            throw new WorkloadIdentityException(
                $"Credentials file {_credentialsFilePath} does not contain an access_token."
            );
        }

        // If the token has not expired, return it. Skip this short-circuit on forceRefresh
        // (the server just rejected the on-disk token with a 401).
        if (!forceRefresh)
        {
            if (data.ExpiresAt != null)
            {
                var remaining = data.ExpiresAt.Value - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                if (remaining > CredentialsConstants.MandatoryRefreshSeconds)
                {
                    return new AccessToken(data.AccessToken, data.ExpiresAt);
                }
            }
            else
            {
                // No expiration — treat as valid
                return new AccessToken(data.AccessToken, null);
            }
        }

        // Token expired or about to expire: acquire per-file lock so that concurrent
        // callers sharing the same credentials file don't race on read-refresh-write.
        var fileLock = s_fileLocks.GetOrAdd(_credentialsFilePath, _ => new SemaphoreSlim(1, 1));
        await fileLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            // Re-read: another caller may have already refreshed the token while we waited.
            data = ReadCredentialsFile();
            if (!forceRefresh && data.AccessToken != null && data.ExpiresAt != null)
            {
                var remaining = data.ExpiresAt.Value - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                if (remaining > CredentialsConstants.MandatoryRefreshSeconds)
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

            return await RefreshTokenAsync(data, cancellationToken).ConfigureAwait(false);
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

        SecurityHelpers.CheckFilePermissions(_credentialsFilePath);

        var json = File.ReadAllText(_credentialsFilePath);
        CredentialsFileData? data;
        try
        {
            data = JsonSerializer.Deserialize<CredentialsFileData>(
                json,
                CredentialsFileData.JsonOptions
            );
        }
        catch (JsonException ex)
        {
            throw new WorkloadIdentityException(
                $"Failed to parse credentials file {_credentialsFilePath}.",
                ex
            );
        }
        if (data == null)
        {
            throw new WorkloadIdentityException(
                $"Failed to parse credentials file: {_credentialsFilePath}"
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
        CredentialsFileData data,
        CancellationToken cancellationToken
    )
    {
        var refreshToken = data.RefreshToken!;

        var requestBody = new Dictionary<string, string>
        {
            ["grant_type"] = CredentialsConstants.RefreshTokenGrantType,
            ["refresh_token"] = refreshToken,
        };

        if (_clientId != null)
        {
            requestBody["client_id"] = _clientId;
        }

        var jsonContent = JsonSerializer.Serialize(requestBody);
        using var request = new HttpRequestMessage(HttpMethod.Post, _tokenEndpointUrl)
        {
            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json"),
        };

        // Refresh uses oauth beta only (NOT the federation beta)
        request.Headers.TryAddWithoutValidation(
            "anthropic-beta",
            CredentialsConstants.RefreshBetaValue
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
                    $"Token refresh failed with status {(int)response.StatusCode}: {redacted}",
                    response.StatusCode,
                    redacted
                );
            }

            var tokenResponse = ParseTokenResponse(responseBody, out string? newRefreshToken);

            // Write the refreshed token back to the credentials file. Mutate the
            // deserialized instance so unknown fields captured via [JsonExtensionData]
            // round-trip rather than being dropped. A write failure must not discard
            // the just-obtained token — warn and serve it from memory.
            try
            {
                WriteRefreshedCredentials(data, tokenResponse, newRefreshToken ?? refreshToken);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                Console.Error.WriteLine(
                    $"anthropic: failed to persist refreshed credentials to "
                        + $"{_credentialsFilePath}: {ex.GetType().Name}. "
                        + "Token will be used in-memory only."
                );
            }

            return tokenResponse;
        }
    }

    private static AccessToken ParseTokenResponse(string responseBody, out string? newRefreshToken)
    {
        var root = SecurityHelpers.DeserializeTokenResponse(responseBody);

        SecurityHelpers.RequireBearerTokenType(root);

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

        var expiresAt = SecurityHelpers.ParseExpiresIn(root);

        if (
            root.TryGetProperty("refresh_token", out var rtElement)
            && rtElement.ValueKind == JsonValueKind.String
        )
        {
            newRefreshToken = rtElement.GetString();
        }
        else
        {
            newRefreshToken = null;
        }

        return new AccessToken(accessToken, expiresAt);
    }

    private void WriteRefreshedCredentials(
        CredentialsFileData existing,
        AccessToken token,
        string refreshToken
    )
    {
        existing.Version = "1.0";
        existing.Type = "oauth_token";
        existing.AccessToken = token.Token;
        existing.ExpiresAt = token.ExpiresAt;
        existing.RefreshToken = refreshToken;

        var json = JsonSerializer.Serialize(existing, CredentialsFileData.JsonOptions);

        // Atomic write: serialize to a temp file then move into place, so a crash
        // mid-write never leaves a truncated/corrupt credentials file.
        var tempPath = _credentialsFilePath + ".tmp." + Guid.NewGuid().ToString("N");
        try
        {
#if NET
            // Create the file with 0600 permissions atomically — the open() syscall
            // applies the mode at creation time, so credentials are never world-readable.
            if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
            {
                var fs = new FileStream(
                    tempPath,
                    new FileStreamOptions
                    {
                        Mode = FileMode.CreateNew,
                        Access = FileAccess.Write,
                        UnixCreateMode = UnixFileMode.UserRead | UnixFileMode.UserWrite,
                    }
                );
                // StreamWriter owns and disposes the FileStream.
                using var writer = new StreamWriter(fs);
                writer.Write(json);
            }
            else
            {
                File.WriteAllText(tempPath, json);
            }

            File.Move(tempPath, _credentialsFilePath, overwrite: true);
#else
            // netstandard2.0 has no UnixCreateMode/SetUnixFileMode API. The temp file is
            // created with umask defaults (typically 0644 on POSIX), and rename preserves
            // that mode. On Linux/macOS this means the credentials file may be group/world-
            // readable after the first refresh. Consumers on netstandard2.0 + POSIX should
            // either chmod 0600 the file out-of-band or target .NET 8+. See the one-time
            // warning below.
            if (
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
            )
            {
                if (Interlocked.CompareExchange(ref s_netstandardPermWarningEmitted, 1, 0) == 0)
                {
                    Console.Error.WriteLine(
                        "anthropic: warning: writing credentials file on netstandard2.0; "
                            + "cannot set 0600 permissions. Run `chmod 600 "
                            + _credentialsFilePath
                            + "` or target .NET 8+ to enforce restrictive permissions."
                    );
                }
            }

            File.WriteAllText(tempPath, json);

            if (File.Exists(_credentialsFilePath))
                File.Replace(tempPath, _credentialsFilePath, null);
            else
                File.Move(tempPath, _credentialsFilePath);
#endif
        }
        finally
        {
            // Clean up the temp file if the move/replace failed or was skipped.
            // Guarded so a cleanup failure can't mask the real error.
            try
            {
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
            }
            catch (IOException) { }
        }
    }

    public void Dispose()
    {
        if (_ownsHttpClient)
        {
            _tokenHttpClient.Dispose();
        }
    }
}
