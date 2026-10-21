using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsBase64DocumentSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource { Data = "x", MediaType = "x" };

        string expectedData = "x";
        string expectedMediaType = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("base64");

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource { Data = "x", MediaType = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBase64DocumentSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource { Data = "x", MediaType = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBase64DocumentSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedData = "x";
        string expectedMediaType = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("base64");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource { Data = "x", MediaType = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource { Data = "x", MediaType = "x" };

        BetaManagedAgentsBase64DocumentSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
