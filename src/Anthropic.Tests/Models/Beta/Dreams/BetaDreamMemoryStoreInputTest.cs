using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamMemoryStoreInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDreamMemoryStoreInput { MemoryStoreID = "x" };

        string expectedMemoryStoreID = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("memory_store");

        Assert.Equal(expectedMemoryStoreID, model.MemoryStoreID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDreamMemoryStoreInput { MemoryStoreID = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamMemoryStoreInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDreamMemoryStoreInput { MemoryStoreID = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamMemoryStoreInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMemoryStoreID = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("memory_store");

        Assert.Equal(expectedMemoryStoreID, deserialized.MemoryStoreID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDreamMemoryStoreInput { MemoryStoreID = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDreamMemoryStoreInput { MemoryStoreID = "x" };

        BetaDreamMemoryStoreInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
