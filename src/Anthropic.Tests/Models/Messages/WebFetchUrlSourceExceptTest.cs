using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebFetchUrlSourceExceptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchUrlSourceExcept { Tools = [new("name")] };

        List<WebFetchUrlSourceToolReference> expectedTools = [new("name")];
        JsonElement expectedType = JsonSerializer.SerializeToElement("except");

        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebFetchUrlSourceExcept { Tools = [new("name")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceExcept>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchUrlSourceExcept { Tools = [new("name")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceExcept>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WebFetchUrlSourceToolReference> expectedTools = [new("name")];
        JsonElement expectedType = JsonSerializer.SerializeToElement("except");

        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebFetchUrlSourceExcept { Tools = [new("name")] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebFetchUrlSourceExcept { Tools = [new("name")] };

        WebFetchUrlSourceExcept copied = new(model);

        Assert.Equal(model, copied);
    }
}
