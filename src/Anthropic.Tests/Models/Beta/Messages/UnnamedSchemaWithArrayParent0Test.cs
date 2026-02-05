using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class UnnamedSchemaWithArrayParent0Test : TestBase
{
    [Fact]
    public void BetaMessageIterationUsageValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new BetaMessageIterationUsage()
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
    public void BetaCompactionIterationUsageValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new BetaCompactionIterationUsage()
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
    public void BetaMessageIterationUsageSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new BetaMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCompactionIterationUsageSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new BetaCompactionIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
