using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
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
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            OutputTokens = 0,
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };

        double expectedActiveSeconds = 0;
        BetaManagedAgentsCacheCreationUsage expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        int expectedCacheReadInputTokens = 0;
        int expectedInputTokens = 0;
        BetaMonetaryAmount expectedListCost = new()
        {
            Amount = "2500",
            Currency = BetaCurrency.Usd,
        };
        int expectedOutputTokens = 0;
        BetaManagedAgentsServerToolUsage expectedServerToolUse = new()
        {
            WebFetchRequests = 0,
            WebSearchRequests = 3,
        };

        Assert.Equal(expectedActiveSeconds, model.ActiveSeconds);
        Assert.Equal(expectedCacheCreation, model.CacheCreation);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedListCost, model.ListCost);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedServerToolUse, model.ServerToolUse);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            OutputTokens = 0,
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
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
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            OutputTokens = 0,
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedActiveSeconds = 0;
        BetaManagedAgentsCacheCreationUsage expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        int expectedCacheReadInputTokens = 0;
        int expectedInputTokens = 0;
        BetaMonetaryAmount expectedListCost = new()
        {
            Amount = "2500",
            Currency = BetaCurrency.Usd,
        };
        int expectedOutputTokens = 0;
        BetaManagedAgentsServerToolUsage expectedServerToolUse = new()
        {
            WebFetchRequests = 0,
            WebSearchRequests = 3,
        };

        Assert.Equal(expectedActiveSeconds, deserialized.ActiveSeconds);
        Assert.Equal(expectedCacheCreation, deserialized.CacheCreation);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedListCost, deserialized.ListCost);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedServerToolUse, deserialized.ServerToolUse);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            OutputTokens = 0,
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };

        Assert.Null(model.ActiveSeconds);
        Assert.False(model.RawData.ContainsKey("active_seconds"));
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
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },

            // Null should be interpreted as omitted for these properties
            ActiveSeconds = null,
            CacheCreation = null,
            CacheReadInputTokens = null,
            InputTokens = null,
            OutputTokens = null,
        };

        Assert.Null(model.ActiveSeconds);
        Assert.False(model.RawData.ContainsKey("active_seconds"));
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
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },

            // Null should be interpreted as omitted for these properties
            ActiveSeconds = null,
            CacheCreation = null,
            CacheReadInputTokens = null,
            InputTokens = null,
            OutputTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        Assert.Null(model.ListCost);
        Assert.False(model.RawData.ContainsKey("list_cost"));
        Assert.Null(model.ServerToolUse);
        Assert.False(model.RawData.ContainsKey("server_tool_use"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,

            ListCost = null,
            ServerToolUse = null,
        };

        Assert.Null(model.ListCost);
        Assert.True(model.RawData.ContainsKey("list_cost"));
        Assert.Null(model.ServerToolUse);
        Assert.True(model.RawData.ContainsKey("server_tool_use"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,

            ListCost = null,
            ServerToolUse = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadUsage
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            OutputTokens = 0,
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };

        BetaManagedAgentsSessionThreadUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
