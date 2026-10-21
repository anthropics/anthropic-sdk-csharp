using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsStartEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsStartEvent
        {
            Event = new BetaManagedAgentsAgentMessagePreview("id"),
        };

        BetaManagedAgentsStartEventPreview expectedEvent = new BetaManagedAgentsAgentMessagePreview(
            "id"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("event_start");

        Assert.Equal(expectedEvent, model.Event);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsStartEvent
        {
            Event = new BetaManagedAgentsAgentMessagePreview("id"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStartEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsStartEvent
        {
            Event = new BetaManagedAgentsAgentMessagePreview("id"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStartEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsStartEventPreview expectedEvent = new BetaManagedAgentsAgentMessagePreview(
            "id"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("event_start");

        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsStartEvent
        {
            Event = new BetaManagedAgentsAgentMessagePreview("id"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsStartEvent
        {
            Event = new BetaManagedAgentsAgentMessagePreview("id"),
        };

        BetaManagedAgentsStartEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
