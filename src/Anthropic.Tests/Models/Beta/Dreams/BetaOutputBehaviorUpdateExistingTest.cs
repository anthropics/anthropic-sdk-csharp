using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaOutputBehaviorUpdateExistingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOutputBehaviorUpdateExisting
        {
            MemoryStoreID = "x",
            Type = BetaOutputBehaviorUpdateExistingType.UpdateExisting,
        };

        string expectedMemoryStoreID = "x";
        ApiEnum<string, BetaOutputBehaviorUpdateExistingType> expectedType =
            BetaOutputBehaviorUpdateExistingType.UpdateExisting;

        Assert.Equal(expectedMemoryStoreID, model.MemoryStoreID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOutputBehaviorUpdateExisting
        {
            MemoryStoreID = "x",
            Type = BetaOutputBehaviorUpdateExistingType.UpdateExisting,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputBehaviorUpdateExisting>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOutputBehaviorUpdateExisting
        {
            MemoryStoreID = "x",
            Type = BetaOutputBehaviorUpdateExistingType.UpdateExisting,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputBehaviorUpdateExisting>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMemoryStoreID = "x";
        ApiEnum<string, BetaOutputBehaviorUpdateExistingType> expectedType =
            BetaOutputBehaviorUpdateExistingType.UpdateExisting;

        Assert.Equal(expectedMemoryStoreID, deserialized.MemoryStoreID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOutputBehaviorUpdateExisting
        {
            MemoryStoreID = "x",
            Type = BetaOutputBehaviorUpdateExistingType.UpdateExisting,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOutputBehaviorUpdateExisting
        {
            MemoryStoreID = "x",
            Type = BetaOutputBehaviorUpdateExistingType.UpdateExisting,
        };

        BetaOutputBehaviorUpdateExisting copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaOutputBehaviorUpdateExistingTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaOutputBehaviorUpdateExistingType.UpdateExisting)]
    public void Validation_Works(BetaOutputBehaviorUpdateExistingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOutputBehaviorUpdateExistingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOutputBehaviorUpdateExistingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaOutputBehaviorUpdateExistingType.UpdateExisting)]
    public void SerializationRoundtrip_Works(BetaOutputBehaviorUpdateExistingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOutputBehaviorUpdateExistingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOutputBehaviorUpdateExistingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOutputBehaviorUpdateExistingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOutputBehaviorUpdateExistingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
