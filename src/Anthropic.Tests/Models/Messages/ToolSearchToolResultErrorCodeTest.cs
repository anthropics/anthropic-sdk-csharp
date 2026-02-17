using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolSearchToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(ToolSearchToolResultErrorCode.InvalidToolInput)]
    [InlineData(ToolSearchToolResultErrorCode.Unavailable)]
    [InlineData(ToolSearchToolResultErrorCode.TooManyRequests)]
    [InlineData(ToolSearchToolResultErrorCode.ExecutionTimeExceeded)]
    public void Validation_Works(ToolSearchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolSearchToolResultErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolSearchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolSearchToolResultErrorCode.InvalidToolInput)]
    [InlineData(ToolSearchToolResultErrorCode.Unavailable)]
    [InlineData(ToolSearchToolResultErrorCode.TooManyRequests)]
    [InlineData(ToolSearchToolResultErrorCode.ExecutionTimeExceeded)]
    public void SerializationRoundtrip_Works(ToolSearchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolSearchToolResultErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ToolSearchToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolSearchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ToolSearchToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
