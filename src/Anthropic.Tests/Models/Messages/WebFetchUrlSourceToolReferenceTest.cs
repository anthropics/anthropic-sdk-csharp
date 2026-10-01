using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebFetchUrlSourceToolReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchUrlSourceToolReference { Name = "name" };

        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_reference");

        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebFetchUrlSourceToolReference { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceToolReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchUrlSourceToolReference { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceToolReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_reference");

        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebFetchUrlSourceToolReference { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebFetchUrlSourceToolReference { Name = "name" };

        WebFetchUrlSourceToolReference copied = new(model);

        Assert.Equal(model, copied);
    }
}
