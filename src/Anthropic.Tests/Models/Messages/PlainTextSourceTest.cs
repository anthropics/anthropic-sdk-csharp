using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class PlainTextSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlainTextSource { Data = "data" };

        string expectedData = "data";
        JsonElement expectedMediaType = JsonSerializer.SerializeToElement("text/plain");
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");

        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, model.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlainTextSource { Data = "data" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlainTextSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlainTextSource { Data = "data" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlainTextSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedData = "data";
        JsonElement expectedMediaType = JsonSerializer.SerializeToElement("text/plain");
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, deserialized.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlainTextSource { Data = "data" };

        model.Validate();
    }
}
