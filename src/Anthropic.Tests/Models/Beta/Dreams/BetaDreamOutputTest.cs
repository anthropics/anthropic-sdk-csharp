using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDreamOutput
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaDreamOutputType.MemoryStore,
        };

        string expectedMemoryStoreID = "memory_store_id";
        ApiEnum<string, BetaDreamOutputType> expectedType = BetaDreamOutputType.MemoryStore;

        Assert.Equal(expectedMemoryStoreID, model.MemoryStoreID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDreamOutput
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaDreamOutputType.MemoryStore,
        };

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
        var model = new BetaDreamOutput
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaDreamOutputType.MemoryStore,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMemoryStoreID = "memory_store_id";
        ApiEnum<string, BetaDreamOutputType> expectedType = BetaDreamOutputType.MemoryStore;

        Assert.Equal(expectedMemoryStoreID, deserialized.MemoryStoreID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDreamOutput
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaDreamOutputType.MemoryStore,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDreamOutput
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaDreamOutputType.MemoryStore,
        };

        BetaDreamOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaDreamOutputTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaDreamOutputType.MemoryStore)]
    public void Validation_Works(BetaDreamOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamOutputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamOutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDreamOutputType.MemoryStore)]
    public void SerializationRoundtrip_Works(BetaDreamOutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamOutputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamOutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamOutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamOutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
