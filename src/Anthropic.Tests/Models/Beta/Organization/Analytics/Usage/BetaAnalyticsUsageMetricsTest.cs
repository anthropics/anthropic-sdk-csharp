using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Usage;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Usage;

public class BetaAnalyticsUsageMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUsageMetrics
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            OutputTokens = 891000,
            Requests = 128,
            ServerToolUse = new(10),
            TotalTokens = 5375500,
            UncachedInputTokens = 1284500,
        };

        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheReadInputTokens = 3200000;
        long expectedOutputTokens = 891000;
        long expectedRequests = 128;
        BetaAnalyticsServerToolUse expectedServerToolUse = new(10);
        long expectedTotalTokens = 5375500;
        long expectedUncachedInputTokens = 1284500;

        Assert.Equal(expectedCacheCreation, model.CacheCreation);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedRequests, model.Requests);
        Assert.Equal(expectedServerToolUse, model.ServerToolUse);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
        Assert.Equal(expectedUncachedInputTokens, model.UncachedInputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUsageMetrics
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            OutputTokens = 891000,
            Requests = 128,
            ServerToolUse = new(10),
            TotalTokens = 5375500,
            UncachedInputTokens = 1284500,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUsageMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUsageMetrics
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            OutputTokens = 891000,
            Requests = 128,
            ServerToolUse = new(10),
            TotalTokens = 5375500,
            UncachedInputTokens = 1284500,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUsageMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheReadInputTokens = 3200000;
        long expectedOutputTokens = 891000;
        long expectedRequests = 128;
        BetaAnalyticsServerToolUse expectedServerToolUse = new(10);
        long expectedTotalTokens = 5375500;
        long expectedUncachedInputTokens = 1284500;

        Assert.Equal(expectedCacheCreation, deserialized.CacheCreation);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedRequests, deserialized.Requests);
        Assert.Equal(expectedServerToolUse, deserialized.ServerToolUse);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
        Assert.Equal(expectedUncachedInputTokens, deserialized.UncachedInputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUsageMetrics
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            OutputTokens = 891000,
            Requests = 128,
            ServerToolUse = new(10),
            TotalTokens = 5375500,
            UncachedInputTokens = 1284500,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUsageMetrics
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            OutputTokens = 891000,
            Requests = 128,
            ServerToolUse = new(10),
            TotalTokens = 5375500,
            UncachedInputTokens = 1284500,
        };

        BetaAnalyticsUsageMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
