using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaIterationsUsageItemsTest : TestBase
{
    [Fact]
    public void MessageIterationUsageValidationWorks()
    {
        BetaIterationsUsageItems value = new BetaMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CompactionIterationUsageValidationWorks()
    {
        BetaIterationsUsageItems value = new BetaCompactionIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        value.Validate();
    }

    [Fact]
    public void MessageIterationUsageSerializationRoundtripWorks()
    {
        BetaIterationsUsageItems value = new BetaMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaIterationsUsageItems>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionIterationUsageSerializationRoundtripWorks()
    {
        BetaIterationsUsageItems value = new BetaCompactionIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaIterationsUsageItems>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
