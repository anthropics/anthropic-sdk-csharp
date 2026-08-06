using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionUsageEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionUsageEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUsageEventType.SessionUsage,
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            Budget = new()
            {
                MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                Type = BetaManagedAgentsBudgetLimitType.Limit,
            },
        };

        string expectedID = "id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsSessionUsageEventType> expectedType =
            BetaManagedAgentsSessionUsageEventType.SessionUsage;
        BetaManagedAgentsSessionUsageSnapshot expectedUsage = new()
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            OutputTokens = 0,
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };
        BetaManagedAgentsBudgetLimit expectedBudget = new()
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            Type = BetaManagedAgentsBudgetLimitType.Limit,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUsage, model.Usage);
        Assert.Equal(expectedBudget, model.Budget);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionUsageEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUsageEventType.SessionUsage,
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            Budget = new()
            {
                MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                Type = BetaManagedAgentsBudgetLimitType.Limit,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionUsageEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionUsageEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUsageEventType.SessionUsage,
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            Budget = new()
            {
                MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                Type = BetaManagedAgentsBudgetLimitType.Limit,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionUsageEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsSessionUsageEventType> expectedType =
            BetaManagedAgentsSessionUsageEventType.SessionUsage;
        BetaManagedAgentsSessionUsageSnapshot expectedUsage = new()
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            OutputTokens = 0,
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };
        BetaManagedAgentsBudgetLimit expectedBudget = new()
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            Type = BetaManagedAgentsBudgetLimitType.Limit,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.Equal(expectedBudget, deserialized.Budget);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionUsageEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUsageEventType.SessionUsage,
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            Budget = new()
            {
                MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                Type = BetaManagedAgentsBudgetLimitType.Limit,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionUsageEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUsageEventType.SessionUsage,
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
        };

        Assert.Null(model.Budget);
        Assert.False(model.RawData.ContainsKey("budget"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSessionUsageEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUsageEventType.SessionUsage,
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsSessionUsageEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUsageEventType.SessionUsage,
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },

            Budget = null,
        };

        Assert.Null(model.Budget);
        Assert.True(model.RawData.ContainsKey("budget"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSessionUsageEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUsageEventType.SessionUsage,
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },

            Budget = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionUsageEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUsageEventType.SessionUsage,
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            Budget = new()
            {
                MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                Type = BetaManagedAgentsBudgetLimitType.Limit,
            },
        };

        BetaManagedAgentsSessionUsageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionUsageEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionUsageEventType.SessionUsage)]
    public void Validation_Works(BetaManagedAgentsSessionUsageEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionUsageEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionUsageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionUsageEventType.SessionUsage)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionUsageEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionUsageEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionUsageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionUsageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionUsageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
