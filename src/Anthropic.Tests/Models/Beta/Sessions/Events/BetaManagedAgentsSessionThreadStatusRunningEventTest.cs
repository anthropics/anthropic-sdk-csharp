using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionThreadStatusRunningEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusRunningEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type = BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning,
        };

        string expectedID = "id";
        string expectedAgentName = "agent_name";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusRunningEventType> expectedType =
            BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentName, model.AgentName);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, model.SessionThreadID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusRunningEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type = BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusRunningEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusRunningEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type = BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusRunningEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAgentName = "agent_name";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusRunningEventType> expectedType =
            BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentName, deserialized.AgentName);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, deserialized.SessionThreadID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusRunningEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type = BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusRunningEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type = BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning,
        };

        BetaManagedAgentsSessionThreadStatusRunningEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionThreadStatusRunningEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning)]
    public void Validation_Works(BetaManagedAgentsSessionThreadStatusRunningEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusRunningEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusRunningEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionThreadStatusRunningEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusRunningEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusRunningEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusRunningEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusRunningEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
