using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class BetaSelfHostedWorkQueueStatsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSelfHostedWorkQueueStats
        {
            Depth = 0,
            OldestQueuedAt = "oldest_queued_at",
            Pending = 0,
            WorkersPolling = 0,
        };

        long expectedDepth = 0;
        string expectedOldestQueuedAt = "oldest_queued_at";
        long expectedPending = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("work_queue_stats");
        long expectedWorkersPolling = 0;

        Assert.Equal(expectedDepth, model.Depth);
        Assert.Equal(expectedOldestQueuedAt, model.OldestQueuedAt);
        Assert.Equal(expectedPending, model.Pending);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkersPolling, model.WorkersPolling);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSelfHostedWorkQueueStats
        {
            Depth = 0,
            OldestQueuedAt = "oldest_queued_at",
            Pending = 0,
            WorkersPolling = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWorkQueueStats>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSelfHostedWorkQueueStats
        {
            Depth = 0,
            OldestQueuedAt = "oldest_queued_at",
            Pending = 0,
            WorkersPolling = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWorkQueueStats>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDepth = 0;
        string expectedOldestQueuedAt = "oldest_queued_at";
        long expectedPending = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("work_queue_stats");
        long expectedWorkersPolling = 0;

        Assert.Equal(expectedDepth, deserialized.Depth);
        Assert.Equal(expectedOldestQueuedAt, deserialized.OldestQueuedAt);
        Assert.Equal(expectedPending, deserialized.Pending);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkersPolling, deserialized.WorkersPolling);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSelfHostedWorkQueueStats
        {
            Depth = 0,
            OldestQueuedAt = "oldest_queued_at",
            Pending = 0,
            WorkersPolling = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSelfHostedWorkQueueStats
        {
            Depth = 0,
            OldestQueuedAt = "oldest_queued_at",
            Pending = 0,
            WorkersPolling = 0,
        };

        BetaSelfHostedWorkQueueStats copied = new(model);

        Assert.Equal(model, copied);
    }
}
