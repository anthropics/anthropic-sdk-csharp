using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaOutputBehaviorCreateNewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOutputBehaviorCreateNew
        {
            Type = BetaOutputBehaviorCreateNewType.CreateNew,
        };

        ApiEnum<string, BetaOutputBehaviorCreateNewType> expectedType =
            BetaOutputBehaviorCreateNewType.CreateNew;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOutputBehaviorCreateNew
        {
            Type = BetaOutputBehaviorCreateNewType.CreateNew,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputBehaviorCreateNew>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOutputBehaviorCreateNew
        {
            Type = BetaOutputBehaviorCreateNewType.CreateNew,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputBehaviorCreateNew>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaOutputBehaviorCreateNewType> expectedType =
            BetaOutputBehaviorCreateNewType.CreateNew;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOutputBehaviorCreateNew
        {
            Type = BetaOutputBehaviorCreateNewType.CreateNew,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOutputBehaviorCreateNew
        {
            Type = BetaOutputBehaviorCreateNewType.CreateNew,
        };

        BetaOutputBehaviorCreateNew copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaOutputBehaviorCreateNewTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaOutputBehaviorCreateNewType.CreateNew)]
    public void Validation_Works(BetaOutputBehaviorCreateNewType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOutputBehaviorCreateNewType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOutputBehaviorCreateNewType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaOutputBehaviorCreateNewType.CreateNew)]
    public void SerializationRoundtrip_Works(BetaOutputBehaviorCreateNewType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOutputBehaviorCreateNewType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOutputBehaviorCreateNewType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOutputBehaviorCreateNewType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOutputBehaviorCreateNewType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
