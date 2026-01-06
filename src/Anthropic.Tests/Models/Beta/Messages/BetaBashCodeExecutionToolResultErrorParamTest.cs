using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBashCodeExecutionToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
        };

        ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode> expectedErrorCode =
            BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultErrorParam>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBashCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultErrorParam>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode> expectedErrorCode =
            BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBashCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
        };

        model.Validate();
    }
}

public class BetaBashCodeExecutionToolResultErrorParamErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput)]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.Unavailable)]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.TooManyRequests)]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.ExecutionTimeExceeded)]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.OutputFileTooLarge)]
    public void Validation_Works(BetaBashCodeExecutionToolResultErrorParamErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput)]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.Unavailable)]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.TooManyRequests)]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.ExecutionTimeExceeded)]
    [InlineData(BetaBashCodeExecutionToolResultErrorParamErrorCode.OutputFileTooLarge)]
    public void SerializationRoundtrip_Works(
        BetaBashCodeExecutionToolResultErrorParamErrorCode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
