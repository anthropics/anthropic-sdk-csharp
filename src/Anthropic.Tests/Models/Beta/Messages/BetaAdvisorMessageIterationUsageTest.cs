using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorMessageIterationUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorMessageIterationUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeOpus4_7,
            OutputTokens = 0,
        };

        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheCreationInputTokens = 0;
        long expectedCacheReadInputTokens = 0;
        long expectedInputTokens = 0;
        ApiEnum<string, Model> expectedModel = Model.ClaudeOpus4_7;
        long expectedOutputTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_message");

        Assert.Equal(expectedCacheCreation, model.CacheCreation);
        Assert.Equal(expectedCacheCreationInputTokens, model.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorMessageIterationUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeOpus4_7,
            OutputTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorMessageIterationUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAdvisorMessageIterationUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeOpus4_7,
            OutputTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorMessageIterationUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheCreationInputTokens = 0;
        long expectedCacheReadInputTokens = 0;
        long expectedInputTokens = 0;
        ApiEnum<string, Model> expectedModel = Model.ClaudeOpus4_7;
        long expectedOutputTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_message");

        Assert.Equal(expectedCacheCreation, deserialized.CacheCreation);
        Assert.Equal(expectedCacheCreationInputTokens, deserialized.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorMessageIterationUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeOpus4_7,
            OutputTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorMessageIterationUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeOpus4_7,
            OutputTokens = 0,
        };

        BetaAdvisorMessageIterationUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
