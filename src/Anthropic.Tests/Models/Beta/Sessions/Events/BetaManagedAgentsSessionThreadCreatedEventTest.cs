using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionThreadCreatedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Type = BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated,
        };

        string expectedID = "sevt_011CZkZWXb7pJkx1shYaqoCu";
        string expectedAgentName = "Researcher";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt";
        ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType> expectedType =
            BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentName, model.AgentName);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, model.SessionThreadID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Type = BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadCreatedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Type = BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadCreatedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZWXb7pJkx1shYaqoCu";
        string expectedAgentName = "Researcher";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt";
        ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType> expectedType =
            BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentName, deserialized.AgentName);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, deserialized.SessionThreadID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Type = BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Type = BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated,
        };

        BetaManagedAgentsSessionThreadCreatedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionThreadCreatedEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated)]
    public void Validation_Works(BetaManagedAgentsSessionThreadCreatedEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionThreadCreatedEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
