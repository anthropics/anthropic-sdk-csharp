using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Credentials;

namespace Anthropic.Tests.Credentials;

public class TokenCacheInvalidationTests
{
    private sealed class ScriptedProvider(Func<int, bool, Task<AccessToken>> getToken)
        : IAccessTokenProvider
    {
        private int _calls;
        public int Calls => Volatile.Read(ref _calls);

        public ValueTask<AccessToken> GetTokenAsync(
            bool forceRefresh = false,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            return new(getToken(Interlocked.Increment(ref _calls), forceRefresh));
        }

        public void Dispose() { }
    }

    private static TaskCompletionSource<bool> Gate() =>
        new(TaskCreationOptions.RunContinuationsAsynchronously);

    private static async Task WaitFor(Task task)
    {
        Assert.Same(
            task,
            await Task.WhenAny(
                task,
                Task.Delay(TimeSpan.FromSeconds(5), TestContext.Current.CancellationToken)
            )
        );
        await task;
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task InvalidateDuringForegroundRefreshDoesNotRepublishTheOldResult(bool expires)
    {
        var started = Gate();
        var release = Gate();
        var provider = new ScriptedProvider(
            async (call, _) =>
            {
                if (call == 1)
                {
                    started.SetResult(true);
                    await release.Task;
                }
                return new AccessToken(
                    $"token-{call}",
                    expires ? DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600 : null
                );
            }
        );
        using var cache = new TokenCache(provider);
        var first = cache
            .GetTokenAsync(cancellationToken: TestContext.Current.CancellationToken)
            .AsTask();
        try
        {
            await WaitFor(started.Task);
            cache.Invalidate();
        }
        finally
        {
            release.TrySetResult(true);
        }
        await WaitFor(first);
        Assert.Equal("token-1", (await first).Token);
        Assert.Null(cache.Cached);
        var next = await cache.GetTokenAsync(
            cancellationToken: TestContext.Current.CancellationToken
        );
        Assert.Equal("token-2", next.Token);
        Assert.Same(next, cache.Cached);
        Assert.Equal(2, provider.Calls);
    }

    [Fact]
    public async Task InvalidateDuringAdvisoryRefreshMakesTheWaitingCallerRefetch()
    {
        var started = Gate();
        var release = Gate();
        var provider = new ScriptedProvider(
            async (call, _) =>
            {
                if (call == 2)
                {
                    started.SetResult(true);
                    await release.Task;
                }
                return new AccessToken(
                    $"token-{call}",
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds() + (call == 1 ? 60 : 600)
                );
            }
        );
        using var cache = new TokenCache(provider);
        await cache.GetTokenAsync(cancellationToken: TestContext.Current.CancellationToken);
        await cache.GetTokenAsync(cancellationToken: TestContext.Current.CancellationToken);
        Task<AccessToken>? waiting = null;
        try
        {
            await WaitFor(started.Task);
            cache.Invalidate();
            waiting = cache
                .GetTokenAsync(cancellationToken: TestContext.Current.CancellationToken)
                .AsTask();
        }
        finally
        {
            release.TrySetResult(true);
        }
        Assert.NotNull(waiting);
        await WaitFor(waiting);
        Assert.Equal("token-3", (await waiting).Token);
        Assert.Equal(3, provider.Calls);
        Assert.Same(await waiting, cache.Cached);
    }

    [Fact]
    public async Task FailedForceRefreshDoesNotRestoreAnEarlierAdvisoryResult()
    {
        var started = Gate();
        var release = Gate();
        var failure = new InvalidOperationException("forced refresh failed");
        var provider = new ScriptedProvider(
            async (call, force) =>
            {
                if (call == 2)
                {
                    started.SetResult(true);
                    await release.Task;
                }
                if (force)
                {
                    throw failure;
                }
                return new AccessToken(
                    $"token-{call}",
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds() + (call == 1 ? 60 : 600)
                );
            }
        );
        using var cache = new TokenCache(provider);
        await cache.GetTokenAsync(cancellationToken: TestContext.Current.CancellationToken);
        await cache.GetTokenAsync(cancellationToken: TestContext.Current.CancellationToken);
        Task<AccessToken>? forced = null;
        try
        {
            await WaitFor(started.Task);
            forced = cache
                .GetTokenAsync(
                    forceRefresh: true,
                    cancellationToken: TestContext.Current.CancellationToken
                )
                .AsTask();
        }
        finally
        {
            release.TrySetResult(true);
        }
        Assert.NotNull(forced);
        var caught = await Assert.ThrowsAsync<InvalidOperationException>(async () => await forced);
        Assert.Same(failure, caught);
        Assert.Null(cache.Cached);
        Assert.Equal(
            "token-4",
            (
                await cache.GetTokenAsync(cancellationToken: TestContext.Current.CancellationToken)
            ).Token
        );
        Assert.Equal(4, provider.Calls);
    }
}
