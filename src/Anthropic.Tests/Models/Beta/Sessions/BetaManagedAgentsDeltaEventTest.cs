using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsDeltaEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeltaEvent
        {
            Delta = new()
            {
                Content = new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
                Type = BetaManagedAgentsDeltaContentType.ContentDelta,
                Index = 0,
            },
            EventID = "event_id",
            Type = BetaManagedAgentsDeltaEventType.EventDelta,
        };

        BetaManagedAgentsDeltaContent expectedDelta = new()
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,
            Index = 0,
        };
        string expectedEventID = "event_id";
        ApiEnum<string, BetaManagedAgentsDeltaEventType> expectedType =
            BetaManagedAgentsDeltaEventType.EventDelta;

        Assert.Equal(expectedDelta, model.Delta);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeltaEvent
        {
            Delta = new()
            {
                Content = new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
                Type = BetaManagedAgentsDeltaContentType.ContentDelta,
                Index = 0,
            },
            EventID = "event_id",
            Type = BetaManagedAgentsDeltaEventType.EventDelta,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeltaEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeltaEvent
        {
            Delta = new()
            {
                Content = new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
                Type = BetaManagedAgentsDeltaContentType.ContentDelta,
                Index = 0,
            },
            EventID = "event_id",
            Type = BetaManagedAgentsDeltaEventType.EventDelta,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeltaEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsDeltaContent expectedDelta = new()
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,
            Index = 0,
        };
        string expectedEventID = "event_id";
        ApiEnum<string, BetaManagedAgentsDeltaEventType> expectedType =
            BetaManagedAgentsDeltaEventType.EventDelta;

        Assert.Equal(expectedDelta, deserialized.Delta);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeltaEvent
        {
            Delta = new()
            {
                Content = new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
                Type = BetaManagedAgentsDeltaContentType.ContentDelta,
                Index = 0,
            },
            EventID = "event_id",
            Type = BetaManagedAgentsDeltaEventType.EventDelta,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeltaEvent
        {
            Delta = new()
            {
                Content = new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
                Type = BetaManagedAgentsDeltaContentType.ContentDelta,
                Index = 0,
            },
            EventID = "event_id",
            Type = BetaManagedAgentsDeltaEventType.EventDelta,
        };

        BetaManagedAgentsDeltaEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsDeltaEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeltaEventType.EventDelta)]
    public void Validation_Works(BetaManagedAgentsDeltaEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeltaEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDeltaEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeltaEventType.EventDelta)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsDeltaEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeltaEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeltaEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDeltaEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeltaEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
