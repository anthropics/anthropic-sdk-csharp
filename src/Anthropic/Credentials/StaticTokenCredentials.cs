using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Credentials;

/// <summary>
/// Wraps a static bearer token. The token is never refreshed or exchanged.
/// </summary>
public sealed class StaticTokenCredentials : IAccessTokenProvider
{
    private readonly AccessToken _token;

    public StaticTokenCredentials(string token)
    {
        if (token == null)
            throw new ArgumentNullException(nameof(token));
        _token = new AccessToken(token, expiresAt: null);
    }

    public ValueTask<AccessToken> GetTokenAsync(
        bool forceRefresh = false,
        CancellationToken cancellationToken = default
    )
    {
        // Static tokens cannot be refreshed.
        return new ValueTask<AccessToken>(_token);
    }

    public void Dispose()
    {
        // Nothing to dispose.
    }
}
