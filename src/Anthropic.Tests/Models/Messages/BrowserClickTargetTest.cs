using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserClickTargetTest : TestBase
{
    [Fact]
    public void CoordinateValidationWorks()
    {
        BrowserClickTarget value = new BrowserCoordinateTarget() { X = 0, Y = 0 };
        value.Validate();
    }

    [Fact]
    public void RefValidationWorks()
    {
        BrowserClickTarget value = new BrowserRefTarget("ref");
        value.Validate();
    }

    [Fact]
    public void CoordinateSerializationRoundtripWorks()
    {
        BrowserClickTarget value = new BrowserCoordinateTarget() { X = 0, Y = 0 };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserClickTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefSerializationRoundtripWorks()
    {
        BrowserClickTarget value = new BrowserRefTarget("ref");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserClickTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CoordinateTypeWorks()
    {
        BrowserClickTarget value = new BrowserCoordinateTarget() { X = 0, Y = 0 };
        Assert.Equal(BrowserClickTargetType.Coordinate, value.Type.Value());
    }

    [Fact]
    public void RefTypeWorks()
    {
        BrowserClickTarget value = new BrowserRefTarget("ref");
        Assert.Equal(BrowserClickTargetType.Ref, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BrowserClickTarget value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "coordinate"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BrowserClickTargetType> expectedType = BrowserClickTargetType.Coordinate;

        Assert.Equal(expectedType, value.Type);

        BrowserClickTarget emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BrowserClickTargetTypeTest : TestBase
{
    [Theory]
    [InlineData(BrowserClickTargetType.Coordinate)]
    [InlineData(BrowserClickTargetType.Ref)]
    public void Validation_Works(BrowserClickTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrowserClickTargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrowserClickTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BrowserClickTargetType.Coordinate, 0, "coordinate")]
    [InlineData(BrowserClickTargetType.Ref, 1, "ref")]
    public void EnumMemberSerializationRoundtrip_Works(
        BrowserClickTargetType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrowserClickTargetType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrowserClickTargetType>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrowserClickTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrowserClickTargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
