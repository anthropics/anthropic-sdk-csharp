using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new(0),
            ServiceTier = UsageServiceTier.Standard,
        };

        CacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        long expectedInputTokens = 2095;
        long expectedOutputTokens = 503;
        ServerToolUsage expectedServerToolUse = new(0);
        ApiEnum<string, UsageServiceTier> expectedServiceTier = UsageServiceTier.Standard;

        Assert.Equal(expectedCacheCreation, model.CacheCreation);
        Assert.Equal(expectedCacheCreationInputTokens, model.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedServerToolUse, model.ServerToolUse);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
    }
}
