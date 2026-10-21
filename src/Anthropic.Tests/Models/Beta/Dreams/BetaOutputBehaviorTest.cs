using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaOutputBehaviorTest : TestBase
{
    [Fact]
    public void CreateNewValidationWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorCreateNew();
        value.Validate();
    }

    [Fact]
    public void UpdateExistingValidationWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorUpdateExisting("x");
        value.Validate();
    }

    [Fact]
    public void CreateNewSerializationRoundtripWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorCreateNew();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputBehavior>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UpdateExistingSerializationRoundtripWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorUpdateExisting("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputBehavior>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreateNewTypeWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorCreateNew();
        Assert.Equal(BetaOutputBehaviorType.CreateNew, value.Type.Value());
    }

    [Fact]
    public void UpdateExistingTypeWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorUpdateExisting("x");
        Assert.Equal(BetaOutputBehaviorType.UpdateExisting, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaOutputBehavior value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "create_new"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaOutputBehaviorType> expectedType = BetaOutputBehaviorType.CreateNew;

        Assert.Equal(expectedType, value.Type);

        BetaOutputBehavior emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaOutputBehaviorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaOutputBehaviorType.CreateNew)]
    [InlineData(BetaOutputBehaviorType.UpdateExisting)]
    public void Validation_Works(BetaOutputBehaviorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOutputBehaviorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOutputBehaviorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaOutputBehaviorType.CreateNew)]
    [InlineData(BetaOutputBehaviorType.UpdateExisting)]
    public void SerializationRoundtrip_Works(BetaOutputBehaviorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOutputBehaviorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaOutputBehaviorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOutputBehaviorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaOutputBehaviorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
