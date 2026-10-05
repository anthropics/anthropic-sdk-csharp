using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Helpers;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Helpers;

public class AggregationCancellationTest
{
    [Theory]
    [InlineData("stable", true)]
    [InlineData("stable", false)]
    [InlineData("beta", true)]
    [InlineData("beta", false)]
    [InlineData("sessions", true)]
    [InlineData("sessions", false)]
    public Task CollectionForwardsEnumeratorCancellation(string surface, bool beforeFirst)
    {
        return surface switch
        {
            "stable" => CheckCancellation(
                [
                    Parse<RawMessageStreamEvent>("{\"type\":\"message_start\",\"message\":{}}"),
                    Parse<RawMessageStreamEvent>("{\"type\":\"message_stop\"}"),
                ],
                source => source.CollectAsync(new MessageContentAggregator()),
                beforeFirst
            ),
            "beta" => CheckCancellation(
                [
                    Parse<BetaRawMessageStreamEvent>("{\"type\":\"message_start\",\"message\":{}}"),
                    Parse<BetaRawMessageStreamEvent>("{\"type\":\"message_stop\"}"),
                ],
                source => source.CollectAsync(new BetaMessageContentAggregator()),
                beforeFirst
            ),
            _ => CheckCancellation(
                [
                    Parse<Events.BetaManagedAgentsStreamSessionEvents>(
                        "{\"type\":\"event_start\",\"event\":{\"type\":\"agent.message\",\"id\":\"evt_a\"}}"
                    ),
                    Parse<Events.BetaManagedAgentsStreamSessionEvents>(
                        "{\"type\":\"event_start\",\"event\":{\"type\":\"agent.message\",\"id\":\"evt_b\"}}"
                    ),
                ],
                source => source.CollectAsync(new BetaManagedAgentsEventAggregator()),
                beforeFirst
            ),
        };
    }

    private static T Parse<T>(string json)
        where T : class
    {
        var value = JsonSerializer.Deserialize<T>(json, ModelBase.SerializerOptions);
        Assert.NotNull(value);
        return value;
    }

    private static async Task CheckCancellation<T>(
        T[] values,
        Func<IAsyncEnumerable<T>, IAsyncEnumerable<T>> collect,
        bool beforeFirst
    )
        where T : class
    {
        using var cancellation = new CancellationTokenSource();
        var source = new TrackingStream<T>(values);
        var pipeline = collect(source);
        Assert.Equal(0, source.Enumerations);
        await using (
            var iterator = pipeline.WithCancellation(cancellation.Token).GetAsyncEnumerator()
        )
        {
            if (!beforeFirst)
            {
                Assert.True(await iterator.MoveNextAsync());
                Assert.Same(values[0], iterator.Current);
            }
            cancellation.Cancel();
            var error = await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
                await iterator.MoveNextAsync()
            );
            Assert.Equal(cancellation.Token, error.CancellationToken);
        }
        Assert.Equal(cancellation.Token, source.Token);
        Assert.Equal(beforeFirst ? 0 : 1, source.Delivered);
        Assert.Equal(1, source.Disposals);
    }

    [Fact]
    public async Task CancelledSessionCollectionDoesNotAggregateLaterEvents()
    {
        var aggregator = new BetaManagedAgentsEventAggregator();
        var source = new TrackingStream<Events.BetaManagedAgentsStreamSessionEvents>(
            [
                Parse<Events.BetaManagedAgentsStreamSessionEvents>(
                    "{\"type\":\"event_start\",\"event\":{\"type\":\"agent.message\",\"id\":\"evt_a\"}}"
                ),
                Parse<Events.BetaManagedAgentsStreamSessionEvents>(
                    "{\"type\":\"event_start\",\"event\":{\"type\":\"agent.message\",\"id\":\"evt_b\"}}"
                ),
            ]
        );
        using var cancellation = new CancellationTokenSource();
        await using (
            var iterator = source
                .CollectAsync(aggregator)
                .WithCancellation(cancellation.Token)
                .GetAsyncEnumerator()
        )
        {
            Assert.True(await iterator.MoveNextAsync());
            cancellation.Cancel();
            await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
                await iterator.MoveNextAsync()
            );
        }
        Assert.Contains("evt_a", aggregator.AgentMessages.Keys);
        Assert.DoesNotContain("evt_b", aggregator.AgentMessages.Keys);
        Assert.Equal(1, source.Disposals);
    }

    [Fact]
    public async Task EarlyExitStillDisposesTheSource()
    {
        var source = new TrackingStream<int>([0, 1, 2]);
        await foreach (var value in source.CollectAsync(new IntegerAggregator()))
        {
            Assert.Equal(0, value);
            break;
        }
        Assert.Equal(1, source.Disposals);
        Assert.Equal(1, source.Delivered);
    }

    private sealed class IntegerAggregator : SseAggregator<int, string>
    {
        protected override FilterResult Filter(int message) =>
            message == 0 ? FilterResult.StartMessage : FilterResult.EndMessage;

        protected override string GetResult(
            IReadOnlyDictionary<FilterResult, IList<int>> messages
        ) => "done";
    }

    private sealed class TrackingStream<T>(T[] values) : IAsyncEnumerable<T>, IAsyncEnumerator<T>
    {
        private int index = -1;
        public int Enumerations { get; private set; }
        public int Delivered { get; private set; }
        public int Disposals { get; private set; }
        public CancellationToken Token { get; private set; }
        public T Current => values[index];

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            Enumerations++;
            Token = cancellationToken;
            return this;
        }

        public ValueTask<bool> MoveNextAsync()
        {
            Token.ThrowIfCancellationRequested();
            var available = ++index < values.Length;
            if (available)
                Delivered++;
            return new ValueTask<bool>(available);
        }

        public ValueTask DisposeAsync()
        {
            Disposals++;
            return default;
        }
    }
}
