using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Credentials;

/// <summary>
/// Thread-safe two-tier proactive token cache.
///
/// <para>Advisory refresh (120s before expiry): triggers a background refresh and serves the
/// stale token. If the refresh fails, the stale token is returned.</para>
///
/// <para>Mandatory refresh (30s before expiry): blocks until a fresh token is obtained.
/// If the refresh fails, the exception is raised to the caller.</para>
/// </summary>
internal sealed class TokenCache : IAccessTokenProvider
{
    private readonly IAccessTokenProvider _inner;
    private readonly SemaphoreSlim _refreshLock = new(1, 1);
    private volatile AccessToken? _cached;
    private Task? _backgroundRefresh;
    private long _lastAdvisoryFailureUnix;
    private volatile bool _disposed;

    internal TokenCache(IAccessTokenProvider inner)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
    }

    public async ValueTask<AccessToken> GetTokenAsync(
        bool forceRefresh = false,
        CancellationToken cancellationToken = default
    )
    {
        if (forceRefresh)
        {
            _cached = null;
            return await RefreshAndCacheAsync(forceRefresh: true, cancellationToken)
                .ConfigureAwait(false);
        }

        var token = _cached;

        if (token == null)
        {
            return await RefreshAndCacheAsync(forceRefresh: false, cancellationToken)
                .ConfigureAwait(false);
        }

        if (token.ExpiresAt == null)
        {
            return token;
        }

        var remaining = token.ExpiresAt.Value - DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        if (remaining > CredentialsConstants.AdvisoryRefreshSeconds)
        {
            return token;
        }

        if (remaining > CredentialsConstants.MandatoryRefreshSeconds)
        {
            // Advisory: background refresh, serve stale.
            // Skip when the previous advisory attempt just failed — avoids hammering
            // the token endpoint while still inside the grace window.
            var lastFailure = Interlocked.Read(ref _lastAdvisoryFailureUnix);
            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (
                lastFailure == 0
                || now - lastFailure >= CredentialsConstants.AdvisoryRefreshBackoffSeconds
            )
            {
                TryStartBackgroundRefresh();
            }
            return token;
        }

        // Mandatory: block on refresh
        return await RefreshAndCacheAsync(forceRefresh: false, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// The currently-cached token, or <c>null</c> if none. Read-only peek for the
    /// 401-retry path to compare the failed token against a forced refresh.
    /// </summary>
    internal AccessToken? Cached => _cached;

    internal void Invalidate()
    {
        _cached = null;
    }

    private async Task<AccessToken> RefreshAndCacheAsync(
        bool forceRefresh,
        CancellationToken cancellationToken
    )
    {
        await _refreshLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            // Double-check: another thread may have refreshed while we waited.
            // Skip when forceRefresh — the caller explicitly asked for a fresh fetch.
            if (!forceRefresh)
            {
                var current = _cached;
                if (current != null)
                {
                    if (current.ExpiresAt == null)
                    {
                        return current;
                    }

                    var remaining =
                        current.ExpiresAt.Value - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    if (remaining > CredentialsConstants.MandatoryRefreshSeconds)
                    {
                        return current;
                    }
                }
            }

            var newToken = await _inner
                .GetTokenAsync(forceRefresh, cancellationToken)
                .ConfigureAwait(false);
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
                        .GetTokenAsync(forceRefresh: false, CancellationToken.None)
                        .ConfigureAwait(false);
                    _cached = newToken;
                    Interlocked.Exchange(ref _lastAdvisoryFailureUnix, 0);
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    // Advisory refresh failure: swallow, serve stale, back off briefly.
                    Console.Error.WriteLine(
                        "anthropic: background token refresh failed "
                            + $"({ex.GetType().Name}); serving cached token"
                    );
                    Interlocked.Exchange(
                        ref _lastAdvisoryFailureUnix,
                        DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                    );
                }
                finally
                {
                    if (!_disposed)
                    {
                        try
                        {
                            _refreshLock.Release();
                        }
                        catch (ObjectDisposedException) { }
                    }
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
        if (_disposed)
        {
            return;
        }
        _disposed = true;
        _refreshLock.Dispose();
        _inner.Dispose();
    }
}
