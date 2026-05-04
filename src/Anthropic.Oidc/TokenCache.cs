namespace Anthropic.Oidc;

/// <summary>
/// Thread-safe two-tier proactive token cache.
///
/// <para>Advisory refresh (120s before expiry): triggers a background refresh and serves the
/// stale token. If the refresh fails, the stale token is returned.</para>
///
/// <para>Mandatory refresh (30s before expiry): blocks until a fresh token is obtained.
/// If the refresh fails, the exception is raised to the caller.</para>
/// </summary>
internal sealed class TokenCache : IDisposable
{
    private readonly IAccessTokenProvider _inner;
    private readonly SemaphoreSlim _refreshLock = new(1, 1);
    private volatile AccessToken? _cached;
    private Task? _backgroundRefresh;

    internal TokenCache(IAccessTokenProvider inner)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
    }

    internal async Task<AccessToken> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        var token = _cached;

        if (token == null)
        {
            return await RefreshAndCacheAsync(cancellationToken).ConfigureAwait(false);
        }

        if (token.ExpiresAt == null)
        {
            return token;
        }

        var remaining = token.ExpiresAt.Value - DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        if (remaining > OidcConstants.AdvisoryRefreshSeconds)
        {
            return token;
        }

        if (remaining > OidcConstants.MandatoryRefreshSeconds)
        {
            // Advisory: background refresh, serve stale
            TryStartBackgroundRefresh();
            return token;
        }

        // Mandatory: block on refresh
        return await RefreshAndCacheAsync(cancellationToken).ConfigureAwait(false);
    }

    internal void Invalidate()
    {
        _cached = null;
    }

    private async Task<AccessToken> RefreshAndCacheAsync(CancellationToken cancellationToken)
    {
        await _refreshLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            // Double-check: another thread may have refreshed while we waited
            var current = _cached;
            if (current != null)
            {
                if (current.ExpiresAt == null)
                {
                    return current;
                }

                var remaining = current.ExpiresAt.Value - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                if (remaining > OidcConstants.MandatoryRefreshSeconds)
                {
                    return current;
                }
            }

            var newToken = await _inner.GetTokenAsync(cancellationToken).ConfigureAwait(false);
            _cached = newToken;
            return newToken;
        }
        finally
        {
            _refreshLock.Release();
        }
    }

    private void TryStartBackgroundRefresh()
    {
        if (!_refreshLock.Wait(0))
        {
            // Another refresh is already in progress
            return;
        }

        try
        {
            if (_backgroundRefresh != null && !_backgroundRefresh.IsCompleted)
            {
                // Already have a background refresh running
                _refreshLock.Release();
                return;
            }

            _backgroundRefresh = Task.Run(async () =>
            {
                try
                {
                    var newToken = await _inner
                        .GetTokenAsync(CancellationToken.None)
                        .ConfigureAwait(false);
                    _cached = newToken;
                }
                catch
                {
                    // Advisory refresh failure: swallow, serve stale
                }
                finally
                {
                    _refreshLock.Release();
                }
            });
        }
        catch
        {
            _refreshLock.Release();
            throw;
        }
    }

    public void Dispose()
    {
        _refreshLock.Dispose();
    }
}
