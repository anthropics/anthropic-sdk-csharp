using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsDeltaEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeltaEvent
        {
            Delta = new() { Content = new("Where is my order #1234?"), Index = 0 },
            EventID = "event_id",
        };

        BetaManagedAgentsDeltaContent expectedDelta = new()
        {
            Content = new("Where is my order #1234?"),
            Index = 0,
        };
        string expectedEventID = "event_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("event_delta");

        Assert.Equal(expectedDelta, model.Delta);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeltaEvent
        {
            Delta = new() { Content = new("Where is my order #1234?"), Index = 0 },
            EventID = "event_id",
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
            Delta = new() { Content = new("Where is my order #1234?"), Index = 0 },
            EventID = "event_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeltaEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsDeltaContent expectedDelta = new()
        {
            Content = new("Where is my order #1234?"),
            Index = 0,
        };
        string expectedEventID = "event_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("event_delta");

        Assert.Equal(expectedDelta, deserialized.Delta);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeltaEvent
        {
            Delta = new() { Content = new("Where is my order #1234?"), Index = 0 },
            EventID = "event_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeltaEvent
        {
            Delta = new() { Content = new("Where is my order #1234?"), Index = 0 },
            EventID = "event_id",
        };

        BetaManagedAgentsDeltaEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
