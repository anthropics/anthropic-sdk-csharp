using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchUrlSourceExceptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchUrlSourceExcept { Tools = [new("name")] };

        List<BetaWebFetchUrlSourceToolReference> expectedTools = [new("name")];
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
        var model = new BetaWebFetchUrlSourceExcept { Tools = [new("name")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceExcept>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebFetchUrlSourceExcept { Tools = [new("name")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceExcept>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaWebFetchUrlSourceToolReference> expectedTools = [new("name")];
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
        var model = new BetaWebFetchUrlSourceExcept { Tools = [new("name")] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebFetchUrlSourceExcept { Tools = [new("name")] };

        BetaWebFetchUrlSourceExcept copied = new(model);

        Assert.Equal(model, copied);
    }
}
