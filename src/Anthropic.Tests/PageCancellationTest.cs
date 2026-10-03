using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;

namespace Anthropic.Tests;

public class PageCancellationTest
{
    [Theory]
    [InlineData(false, true)]
    [InlineData(true, true)]
    [InlineData(false, false)]
    [InlineData(true, false)]
    public async Task CancellationStopsBufferedItems(bool consumerToken, bool beforeFirst)
    {
        using var cancel = CancellationTokenSource.CreateLinkedTokenSource(
            TestContext.Current.CancellationToken
        );
        var page = new CountingPage([1, 2, 3]);
        var sequence = page.Paginate(consumerToken ? default : cancel.Token);
        await using var iterator = sequence.GetAsyncEnumerator(
            consumerToken ? cancel.Token : TestContext.Current.CancellationToken
        );
        if (!beforeFirst)
        {
            Assert.True(await iterator.MoveNextAsync());
            Assert.Equal(1, iterator.Current);
        }
        cancel.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
            await iterator.MoveNextAsync()
        );
        Assert.Equal(0, page.NextCalls);
    }

    [Fact]
    public async Task CancellationAfterNextPageResponseStopsItsBufferedItems()
    {
        using var cancel = CancellationTokenSource.CreateLinkedTokenSource(
            TestContext.Current.CancellationToken
        );
        var second = new CountingPage([2, 3]);
        var first = new CountingPage([1])
        {
            Fetch = token =>
            {
                Assert.Equal(cancel.Token, token);
                cancel.Cancel();
                return Task.FromResult<IPage<int>>(second);
            },
        };
        await using var iterator = first.Paginate(cancel.Token).GetAsyncEnumerator(cancel.Token);
        Assert.True(await iterator.MoveNextAsync());
        Assert.Equal(1, iterator.Current);
        await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
            await iterator.MoveNextAsync()
        );
        Assert.Equal(1, first.NextCalls);
        Assert.Equal(0, second.NextCalls);
    }

    [Fact]
    public async Task UncancelledPaginationPreservesOrderingAndToken()
    {
        using var cancel = CancellationTokenSource.CreateLinkedTokenSource(
            TestContext.Current.CancellationToken
        );
        var second = new CountingPage([3, 4]);
        var first = new CountingPage([1, 2])
        {
            Fetch = token =>
            {
                Assert.Equal(cancel.Token, token);
                return Task.FromResult<IPage<int>>(second);
            },
        };
        var values = new List<int>();
        await foreach (var value in first.Paginate(cancel.Token))
            values.Add(value);
        Assert.Equal([1, 2, 3, 4], values);
        Assert.Equal(1, first.NextCalls);
        Assert.Equal(0, second.NextCalls);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task CancelledRealClientPageDoesNotYieldMoreOrIssueAnotherRequest(bool beforeFirst)
    {
        using var cancel = CancellationTokenSource.CreateLinkedTokenSource(
            TestContext.Current.CancellationToken
        );
        using var handler = new PageHandler();
        using AnthropicClient client = new() { ApiKey = "test-key", HttpClient = new(handler) };
        var page = await client.Models.List(
            cancellationToken: TestContext.Current.CancellationToken
        );
        await using var iterator = page.Paginate(cancel.Token).GetAsyncEnumerator(cancel.Token);
        if (!beforeFirst)
        {
            Assert.True(await iterator.MoveNextAsync());
            Assert.Equal("one", iterator.Current.ID);
        }
        cancel.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
            await iterator.MoveNextAsync()
        );
        Assert.Equal(1, handler.Requests);
    }

    private sealed class CountingPage(IReadOnlyList<int> items) : IPage<int>
    {
        public IReadOnlyList<int> Items { get; } = items;
        public Func<CancellationToken, Task<IPage<int>>>? Fetch { get; init; }
        public int NextCalls { get; private set; }

        public bool HasNext() => Fetch is not null;

        public Task<IPage<int>> Next(CancellationToken cancellationToken = default)
        {
            NextCalls++;
            return Fetch is { } fetch
                ? fetch(cancellationToken)
                : throw new InvalidOperationException();
        }

        public void Validate() { }
    }

    private sealed class PageHandler : HttpMessageHandler
    {
        public int Requests { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Requests++;
            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.EndsWith("/v1/models", request.RequestUri?.AbsolutePath);
            const string body =
                """{"data":[{"id":"one","type":"model","display_name":"One","created_at":"2026-01-01T00:00:00Z"},{"id":"two","type":"model","display_name":"Two","created_at":"2026-01-01T00:00:00Z"}],"has_more":true,"first_id":"one","last_id":"two"}""";
            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json"),
                }
            );
        }
    }
}
