using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = BetaUsageServiceTier.Standard,
        };

        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        long expectedInputTokens = 2095;
        long expectedOutputTokens = 503;
        BetaServerToolUsage expectedServerToolUse = new()
        {
            WebFetchRequests = 2,
            WebSearchRequests = 0,
        };
        ApiEnum<string, BetaUsageServiceTier> expectedServiceTier = BetaUsageServiceTier.Standard;

        Assert.Equal(expectedCacheCreation, model.CacheCreation);
        Assert.Equal(expectedCacheCreationInputTokens, model.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedServerToolUse, model.ServerToolUse);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = BetaUsageServiceTier.Standard,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaUsage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = BetaUsageServiceTier.Standard,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaUsage>(json);
        Assert.NotNull(deserialized);

        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        long expectedInputTokens = 2095;
        long expectedOutputTokens = 503;
        BetaServerToolUsage expectedServerToolUse = new()
        {
            WebFetchRequests = 2,
            WebSearchRequests = 0,
        };
        ApiEnum<string, BetaUsageServiceTier> expectedServiceTier = BetaUsageServiceTier.Standard;

        Assert.Equal(expectedCacheCreation, deserialized.CacheCreation);
        Assert.Equal(expectedCacheCreationInputTokens, deserialized.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedServerToolUse, deserialized.ServerToolUse);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = BetaUsageServiceTier.Standard,
        };

        model.Validate();
    }
}
