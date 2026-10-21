using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDreamOutput { MemoryStoreID = "memory_store_id" };

        string expectedMemoryStoreID = "memory_store_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("memory_store");

        Assert.Equal(expectedMemoryStoreID, model.MemoryStoreID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDreamOutput { MemoryStoreID = "memory_store_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDreamOutput { MemoryStoreID = "memory_store_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMemoryStoreID = "memory_store_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("memory_store");

        Assert.Equal(expectedMemoryStoreID, deserialized.MemoryStoreID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDreamOutput { MemoryStoreID = "memory_store_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDreamOutput { MemoryStoreID = "memory_store_id" };

        BetaDreamOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}
