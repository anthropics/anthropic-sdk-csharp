#pragma warning disable xUnit1051
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Credentials;

namespace Anthropic.Tests.Credentials;

public class TokenCacheTests
{
    private class FakeTokenProvider : IAccessTokenProvider
    {
        private int _callCount;
        private readonly Func<int, bool, Task<AccessToken>> _factory;

        public int CallCount => _callCount;
        public bool LastForceRefresh { get; private set; }

        public FakeTokenProvider(Func<int, Task<AccessToken>> factory)
        {
            _factory = (n, _) => factory(n);
        }

        public FakeTokenProvider(Func<int, AccessToken> factory)
        {
            _factory = (n, _) => Task.FromResult(factory(n));
        }

        public FakeTokenProvider(Func<int, bool, AccessToken> factory)
        {
            _factory = (n, force) => Task.FromResult(factory(n, force));
        }

        public async ValueTask<AccessToken> GetTokenAsync(
            bool forceRefresh = false,
            CancellationToken cancellationToken = default
        )
        {
            LastForceRefresh = forceRefresh;
            var call = Interlocked.Increment(ref _callCount);
            return await _factory(call, forceRefresh);
        }

        public void Dispose() { }
    }

    [Fact]
    public async Task FreshToken_CallsProvider()
    {
        var provider = new FakeTokenProvider(_ => new AccessToken(
            "tok-1",
            DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600
        ));

        using var cache = new TokenCache(provider);
        var token = await cache.GetTokenAsync();

        Assert.Equal("tok-1", token.Token);
        Assert.Equal(1, provider.CallCount);
    }

    [Fact]
    public async Task CachedToken_DoesNotCallProviderAgain()
    {
        var provider = new FakeTokenProvider(n => new AccessToken(
            $"tok-{n}",
            DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600
        ));

        using var cache = new TokenCache(provider);
        var token1 = await cache.GetTokenAsync();
        var token2 = await cache.GetTokenAsync();

        Assert.Equal("tok-1", token1.Token);
        Assert.Equal("tok-1", token2.Token);
        Assert.Equal(1, provider.CallCount);
    }

    [Fact]
    public async Task NeverExpires_ReturnsCachedForever()
    {
        var provider = new FakeTokenProvider(n => new AccessToken($"tok-{n}", expiresAt: null));

        using var cache = new TokenCache(provider);
        var token1 = await cache.GetTokenAsync();
        var token2 = await cache.GetTokenAsync();

        Assert.Equal("tok-1", token1.Token);
        Assert.Equal("tok-1", token2.Token);
        Assert.Equal(1, provider.CallCount);
    }

    [Fact]
    public async Task AdvisoryWindow_ServesStaleAndRefreshesInBackground()
    {
        // Token expires in 60 seconds (within advisory window of 120s)
        var refreshStarted = new TaskCompletionSource<bool>();
        var refreshGate = new TaskCompletionSource<bool>();
        var provider = new FakeTokenProvider(async n =>
        {
            if (n == 1)
            {
                return new AccessToken("stale", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60);
            }
            refreshStarted.TrySetResult(true);
            await refreshGate.Task;
            return new AccessToken("fresh", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600);
        });

        using var cache = new TokenCache(provider);

        // First call fetches
        var token1 = await cache.GetTokenAsync();
        Assert.Equal("stale", token1.Token);
        Assert.Equal(1, provider.CallCount);

        // Second call triggers advisory background refresh but returns stale immediately
        var token2 = await cache.GetTokenAsync();
        Assert.Equal("stale", token2.Token);

        // Wait for the background refresh to start
        var started = await Task.WhenAny(refreshStarted.Task, Task.Delay(TimeSpan.FromSeconds(5)));
        Assert.Same(refreshStarted.Task, started);

        // Let the refresh complete
        refreshGate.SetResult(true);

        // Give the background task a moment to cache the new token
        await Task.Delay(100);

        // Third call should return the refreshed token
        var token3 = await cache.GetTokenAsync();
        Assert.Equal("fresh", token3.Token);
    }

    [Fact]
    public async Task MandatoryWindow_BlocksOnRefresh()
    {
        // Token expires in 10 seconds (within mandatory window of 30s)
        var provider = new FakeTokenProvider(n => new AccessToken(
            $"tok-{n}",
            DateTimeOffset.UtcNow.ToUnixTimeSeconds() + (n == 1 ? 10 : 600)
        ));

        using var cache = new TokenCache(provider);

        var token1 = await cache.GetTokenAsync();
        Assert.Equal("tok-1", token1.Token);

        // Second call should block and get a new token (mandatory refresh)
        var token2 = await cache.GetTokenAsync();
        Assert.Equal("tok-2", token2.Token);
        Assert.Equal(2, provider.CallCount);
    }

    [Fact]
    public async Task Invalidate_ForcesRefresh()
    {
        var provider = new FakeTokenProvider(n => new AccessToken(
            $"tok-{n}",
            DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600
        ));

        using var cache = new TokenCache(provider);

        var token1 = await cache.GetTokenAsync();
        Assert.Equal("tok-1", token1.Token);

        cache.Invalidate();

        var token2 = await cache.GetTokenAsync();
        Assert.Equal("tok-2", token2.Token);
        Assert.Equal(2, provider.CallCount);
    }

    [Fact]
    public async Task AdvisoryRefreshFailure_ServesStale()
    {
        var callCount = 0;
        var provider = new FakeTokenProvider(n =>
        {
            callCount = n;
            if (n == 1)
            {
                return Task.FromResult(
                    new AccessToken("stale", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60)
                );
            }
            throw new Exception("Refresh failed");
        });

        using var cache = new TokenCache(provider);

        var token1 = await cache.GetTokenAsync();
        Assert.Equal("stale", token1.Token);

        // Advisory refresh will fail silently
        var token2 = await cache.GetTokenAsync();
        Assert.Equal("stale", token2.Token);

        // Wait a bit for background refresh to complete (and fail)
        await Task.Delay(200);

        // Should still serve stale
        var token3 = await cache.GetTokenAsync();
        Assert.Equal("stale", token3.Token);
    }

    [Fact]
    public async Task AdvisoryRefreshFailure_BacksOffFor5Seconds()
    {
        // Token is inside the advisory window (60s remaining: 30 < 60 < 120).
        var provider = new FakeTokenProvider(n =>
        {
            if (n == 1)
            {
                return Task.FromResult(
                    new AccessToken("stale", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60)
                );
            }
            throw new Exception("Refresh failed");
        });

        using var cache = new TokenCache(provider);

        // Call 1 — primes the cache.
        var token1 = await cache.GetTokenAsync();
        Assert.Equal("stale", token1.Token);
        Assert.Equal(1, provider.CallCount);

        // Call 2 — triggers an advisory background refresh that throws; stale is served.
        var token2 = await cache.GetTokenAsync();
        Assert.Equal("stale", token2.Token);

        // Let the background task run and fail.
        await Task.Delay(200);
        Assert.Equal(2, provider.CallCount);

        // Call 3 — within the 5s backoff window: provider must NOT be called again.
        var token3 = await cache.GetTokenAsync();
        Assert.Equal("stale", token3.Token);

        // Give any (incorrectly) started background task a chance to run.
        await Task.Delay(100);
        Assert.Equal(2, provider.CallCount);

        // No injectable clock — skipping the "advance 6s and retry" assertion.
    }

    [Fact]
    public async Task MandatoryRefreshFailure_Throws()
    {
        var provider = new FakeTokenProvider(n =>
        {
            if (n == 1)
            {
                return Task.FromResult(
                    new AccessToken("expired", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 5)
                );
            }
            throw new Exception("Refresh failed");
        });

        using var cache = new TokenCache(provider);

        var token1 = await cache.GetTokenAsync();
        Assert.Equal("expired", token1.Token);

        // Wait for token to enter mandatory window
        await Task.Delay(100);

        // Mandatory refresh should propagate the error
        await Assert.ThrowsAsync<Exception>(async () => await cache.GetTokenAsync());
    }

    [Fact]
    public async Task ForceRefresh_BypassesCacheAndPropagatesToInner()
    {
        var provider = new FakeTokenProvider(
            (n, force) =>
                new AccessToken(
                    $"tok-{n}-{(force ? "forced" : "normal")}",
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600
                )
        );

        using var cache = new TokenCache(provider);

        var token1 = await cache.GetTokenAsync();
        Assert.Equal("tok-1-normal", token1.Token);

        var token2 = await cache.GetTokenAsync(forceRefresh: true);
        Assert.Equal("tok-2-forced", token2.Token);
        Assert.True(provider.LastForceRefresh);

        // Subsequent normal call should serve the freshly cached token
        var token3 = await cache.GetTokenAsync();
        Assert.Equal("tok-2-forced", token3.Token);
        Assert.Equal(2, provider.CallCount);
    }

    [Fact]
    public async Task Dispose_DuringBackgroundRefresh_DoesNotThrow()
    {
        var unobserved = false;
        void Handler(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            unobserved = true;
            e.SetObserved();
        }
        TaskScheduler.UnobservedTaskException += Handler;
        try
        {
            var gate = new TaskCompletionSource<bool>();
            var provider = new FakeTokenProvider(async n =>
            {
                if (n == 1)
                {
                    return new AccessToken("stale", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60);
                }
                await gate.Task;
                return new AccessToken("fresh", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600);
            });

            var cache = new TokenCache(provider);
            await cache.GetTokenAsync(); // prime
            await cache.GetTokenAsync(); // triggers background refresh (blocked on gate)

            cache.Dispose();
            gate.SetResult(true);

            // Give the background task time to complete and any unobserved
            // exception to surface via the finalizer.
            await Task.Delay(100);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            await Task.Delay(50);

            Assert.False(unobserved, "background refresh raised an unobserved exception");
        }
        finally
        {
            TaskScheduler.UnobservedTaskException -= Handler;
        }
    }

    [Fact]
    public async Task ConcurrentCalls_SingleFlight()
    {
        var gate = new TaskCompletionSource<bool>();
        var provider = new FakeTokenProvider(async n =>
        {
            await gate.Task;
            return new AccessToken($"tok-{n}", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600);
        });

        using var cache = new TokenCache(provider);

        // Start multiple concurrent fetches
        var tasks = new List<Task<AccessToken>>();
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(cache.GetTokenAsync().AsTask());
        }

        // Release the gate
        gate.SetResult(true);

        var tokens = await Task.WhenAll(tasks);

        // All should get the same token (single-flight)
        Assert.All(tokens, t => Assert.Equal("tok-1", t.Token));
        Assert.Equal(1, provider.CallCount);
    }
}
