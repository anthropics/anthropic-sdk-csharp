using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionRequiresActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction { EventIds = ["string"] };

        List<string> expectedEventIds = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("requires_action");

        Assert.Equal(expectedEventIds.Count, model.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], model.EventIds[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction { EventIds = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionRequiresAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction { EventIds = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionRequiresAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedEventIds = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("requires_action");

        Assert.Equal(expectedEventIds.Count, deserialized.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], deserialized.EventIds[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction { EventIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction { EventIds = ["string"] };

        BetaManagedAgentsSessionRequiresAction copied = new(model);

        Assert.Equal(model, copied);
    }
}
