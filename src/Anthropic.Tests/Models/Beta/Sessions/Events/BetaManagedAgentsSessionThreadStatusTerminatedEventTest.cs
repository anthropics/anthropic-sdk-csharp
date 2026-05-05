using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionThreadStatusTerminatedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusTerminatedEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type =
                BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated,
        };

        string expectedID = "id";
        string expectedAgentName = "agent_name";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType> expectedType =
            BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentName, model.AgentName);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, model.SessionThreadID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusTerminatedEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type =
                BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusTerminatedEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusTerminatedEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type =
                BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusTerminatedEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAgentName = "agent_name";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType> expectedType =
            BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentName, deserialized.AgentName);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, deserialized.SessionThreadID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusTerminatedEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type =
                BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusTerminatedEvent
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
            Type =
                BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated,
        };

        BetaManagedAgentsSessionThreadStatusTerminatedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionThreadStatusTerminatedEventTypeTest : TestBase
{
    [Theory]
    [InlineData(
        BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated
    )]
    public void Validation_Works(BetaManagedAgentsSessionThreadStatusTerminatedEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated
    )]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionThreadStatusTerminatedEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
