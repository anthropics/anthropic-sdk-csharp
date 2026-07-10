using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDreamUsage
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        int expectedCacheCreationInputTokens = 0;
        int expectedCacheReadInputTokens = 0;
        int expectedInputTokens = 0;
        int expectedOutputTokens = 0;

        Assert.Equal(expectedCacheCreationInputTokens, model.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDreamUsage
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDreamUsage
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedCacheCreationInputTokens = 0;
        int expectedCacheReadInputTokens = 0;
        int expectedInputTokens = 0;
        int expectedOutputTokens = 0;

        Assert.Equal(expectedCacheCreationInputTokens, deserialized.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDreamUsage
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDreamUsage
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        BetaDreamUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
