using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultError
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ApiEnum<string, BetaToolSearchToolResultErrorErrorCode> expectedErrorCode =
            BetaToolSearchToolResultErrorErrorCode.InvalidToolInput;
        string expectedErrorMessage = "error_message";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "tool_search_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultError
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolSearchToolResultError
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaToolSearchToolResultErrorErrorCode> expectedErrorCode =
            BetaToolSearchToolResultErrorErrorCode.InvalidToolInput;
        string expectedErrorMessage = "error_message";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "tool_search_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolSearchToolResultError
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        model.Validate();
    }
}

public class BetaToolSearchToolResultErrorErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaToolSearchToolResultErrorErrorCode.InvalidToolInput)]
    [InlineData(BetaToolSearchToolResultErrorErrorCode.Unavailable)]
    [InlineData(BetaToolSearchToolResultErrorErrorCode.TooManyRequests)]
    [InlineData(BetaToolSearchToolResultErrorErrorCode.ExecutionTimeExceeded)]
    public void Validation_Works(BetaToolSearchToolResultErrorErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaToolSearchToolResultErrorErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolSearchToolResultErrorErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaToolSearchToolResultErrorErrorCode.InvalidToolInput)]
    [InlineData(BetaToolSearchToolResultErrorErrorCode.Unavailable)]
    [InlineData(BetaToolSearchToolResultErrorErrorCode.TooManyRequests)]
    [InlineData(BetaToolSearchToolResultErrorErrorCode.ExecutionTimeExceeded)]
    public void SerializationRoundtrip_Works(BetaToolSearchToolResultErrorErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaToolSearchToolResultErrorErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolSearchToolResultErrorErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolSearchToolResultErrorErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolSearchToolResultErrorErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
