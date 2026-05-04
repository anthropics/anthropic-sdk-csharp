using System.Net.Http;

namespace Anthropic.Oidc;

/// <summary>
/// Credentials for authenticating with the Anthropic API using OIDC workload identity
/// federation or OAuth tokens.
/// </summary>
public interface IAnthropicOidcCredentials : IDisposable
{
    /// <summary>
    /// Applies authentication headers to the given HTTP request.
    /// Sets <c>Authorization: Bearer</c> and appends <c>anthropic-beta: oauth-2025-04-20</c>.
    /// </summary>
    ValueTask ApplyAsync(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Invalidates any cached tokens. Called on 401 responses to force a fresh token on the
    /// next request.
    /// </summary>
    void InvalidateToken();
}
