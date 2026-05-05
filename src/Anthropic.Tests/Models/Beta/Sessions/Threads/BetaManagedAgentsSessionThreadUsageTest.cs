using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Threads;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads;

public class BetaManagedAgentsSessionThreadUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        BetaManagedAgentsCacheCreationUsage expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        int expectedCacheReadInputTokens = 0;
        int expectedInputTokens = 0;
        int expectedOutputTokens = 0;

        Assert.Equal(expectedCacheCreation, model.CacheCreation);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsCacheCreationUsage expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        int expectedCacheReadInputTokens = 0;
        int expectedInputTokens = 0;
        int expectedOutputTokens = 0;

        Assert.Equal(expectedCacheCreation, deserialized.CacheCreation);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage { };

        Assert.Null(model.CacheCreation);
        Assert.False(model.RawData.ContainsKey("cache_creation"));
        Assert.Null(model.CacheReadInputTokens);
        Assert.False(model.RawData.ContainsKey("cache_read_input_tokens"));
        Assert.Null(model.InputTokens);
        Assert.False(model.RawData.ContainsKey("input_tokens"));
        Assert.Null(model.OutputTokens);
        Assert.False(model.RawData.ContainsKey("output_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            // Null should be interpreted as omitted for these properties
            CacheCreation = null,
            CacheReadInputTokens = null,
            InputTokens = null,
            OutputTokens = null,
        };

        Assert.Null(model.CacheCreation);
        Assert.False(model.RawData.ContainsKey("cache_creation"));
        Assert.Null(model.CacheReadInputTokens);
        Assert.False(model.RawData.ContainsKey("cache_read_input_tokens"));
        Assert.Null(model.InputTokens);
        Assert.False(model.RawData.ContainsKey("input_tokens"));
        Assert.Null(model.OutputTokens);
        Assert.False(model.RawData.ContainsKey("output_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            // Null should be interpreted as omitted for these properties
            CacheCreation = null,
            CacheReadInputTokens = null,
            InputTokens = null,
            OutputTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        BetaManagedAgentsSessionThreadUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
