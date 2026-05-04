namespace Anthropic.Oidc;

/// <summary>
/// Provides access tokens for authenticating with the Anthropic API.
/// Implementations must be thread-safe.
/// </summary>
public interface IAccessTokenProvider
{
    /// <summary>
    /// Retrieves a fresh access token. Called by the token cache when a new token is needed.
    /// </summary>
    Task<AccessToken> GetTokenAsync(CancellationToken cancellationToken = default);
}
