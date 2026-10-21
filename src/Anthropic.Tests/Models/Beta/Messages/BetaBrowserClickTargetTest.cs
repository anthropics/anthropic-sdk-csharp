using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserClickTargetTest : TestBase
{
    [Fact]
    public void CoordinateValidationWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 };
        value.Validate();
    }

    [Fact]
    public void RefValidationWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserRefTarget("ref");
        value.Validate();
    }

    [Fact]
    public void CoordinateSerializationRoundtripWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserClickTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefSerializationRoundtripWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserRefTarget("ref");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserClickTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CoordinateTypeWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 };
        Assert.Equal(BetaBrowserClickTargetType.Coordinate, value.Type.Value());
    }

    [Fact]
    public void RefTypeWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserRefTarget("ref");
        Assert.Equal(BetaBrowserClickTargetType.Ref, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaBrowserClickTarget value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "coordinate"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaBrowserClickTargetType> expectedType =
            BetaBrowserClickTargetType.Coordinate;

        Assert.Equal(expectedType, value.Type);

        BetaBrowserClickTarget emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaBrowserClickTargetTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaBrowserClickTargetType.Coordinate)]
    [InlineData(BetaBrowserClickTargetType.Ref)]
    public void Validation_Works(BetaBrowserClickTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserClickTargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserClickTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaBrowserClickTargetType.Coordinate)]
    [InlineData(BetaBrowserClickTargetType.Ref)]
    public void SerializationRoundtrip_Works(BetaBrowserClickTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserClickTargetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserClickTargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserClickTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserClickTargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
