using System;

namespace Anthropic.Credentials;

/// <summary>
/// Represents an access token with optional expiration.
/// </summary>
public sealed class AccessToken
{
    /// <summary>
    /// The access token string.
    /// </summary>
    public string Token { get; }

    /// <summary>
    /// Unix timestamp (seconds) when this token expires, or <c>null</c> if it never expires.
    /// </summary>
    public long? ExpiresAt { get; }

    public AccessToken(string token, long? expiresAt = null)
    {
        Token = token ?? throw new ArgumentNullException(nameof(token));
        ExpiresAt = expiresAt;
    }
}
