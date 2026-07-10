using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamMemoryStoreInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDreamMemoryStoreInput
        {
            MemoryStoreID = "x",
            Type = BetaDreamMemoryStoreInputType.MemoryStore,
        };

        string expectedMemoryStoreID = "x";
        ApiEnum<string, BetaDreamMemoryStoreInputType> expectedType =
            BetaDreamMemoryStoreInputType.MemoryStore;

        Assert.Equal(expectedMemoryStoreID, model.MemoryStoreID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDreamMemoryStoreInput
        {
            MemoryStoreID = "x",
            Type = BetaDreamMemoryStoreInputType.MemoryStore,
        };

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
        var model = new BetaDreamMemoryStoreInput
        {
            MemoryStoreID = "x",
            Type = BetaDreamMemoryStoreInputType.MemoryStore,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamMemoryStoreInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMemoryStoreID = "x";
        ApiEnum<string, BetaDreamMemoryStoreInputType> expectedType =
            BetaDreamMemoryStoreInputType.MemoryStore;

        Assert.Equal(expectedMemoryStoreID, deserialized.MemoryStoreID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDreamMemoryStoreInput
        {
            MemoryStoreID = "x",
            Type = BetaDreamMemoryStoreInputType.MemoryStore,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDreamMemoryStoreInput
        {
            MemoryStoreID = "x",
            Type = BetaDreamMemoryStoreInputType.MemoryStore,
        };

        BetaDreamMemoryStoreInput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaDreamMemoryStoreInputTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaDreamMemoryStoreInputType.MemoryStore)]
    public void Validation_Works(BetaDreamMemoryStoreInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamMemoryStoreInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamMemoryStoreInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDreamMemoryStoreInputType.MemoryStore)]
    public void SerializationRoundtrip_Works(BetaDreamMemoryStoreInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamMemoryStoreInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDreamMemoryStoreInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamMemoryStoreInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDreamMemoryStoreInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
