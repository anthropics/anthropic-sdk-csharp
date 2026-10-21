using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSystemMessageEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content = [new("Where is my order #1234?")],
        };

        List<BetaManagedAgentsSystemContentBlock> expectedContent =
        [
            new("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("system.message");

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content = [new("Where is my order #1234?")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEventParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content = [new("Where is my order #1234?")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEventParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsSystemContentBlock> expectedContent =
        [
            new("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("system.message");

        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content = [new("Where is my order #1234?")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content = [new("Where is my order #1234?")],
        };

        BetaManagedAgentsSystemMessageEventParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
