using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBashCodeExecutionToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionToolResultError
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
        };

        ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode> expectedErrorCode =
            BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "bash_code_execution_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionToolResultError
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBashCodeExecutionToolResultError
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode> expectedErrorCode =
            BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "bash_code_execution_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBashCodeExecutionToolResultError
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBashCodeExecutionToolResultError
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
        };

        BetaBashCodeExecutionToolResultError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaBashCodeExecutionToolResultErrorErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput)]
    [InlineData(BetaBashCodeExecutionToolResultErrorErrorCode.Unavailable)]
    [InlineData(BetaBashCodeExecutionToolResultErrorErrorCode.TooManyRequests)]
    [InlineData(BetaBashCodeExecutionToolResultErrorErrorCode.ExecutionTimeExceeded)]
    [InlineData(BetaBashCodeExecutionToolResultErrorErrorCode.OutputFileTooLarge)]
    public void Validation_Works(BetaBashCodeExecutionToolResultErrorErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
        0,
        "invalid_tool_input"
    )]
    [InlineData(BetaBashCodeExecutionToolResultErrorErrorCode.Unavailable, 1, "unavailable")]
    [InlineData(
        BetaBashCodeExecutionToolResultErrorErrorCode.TooManyRequests,
        2,
        "too_many_requests"
    )]
    [InlineData(
        BetaBashCodeExecutionToolResultErrorErrorCode.ExecutionTimeExceeded,
        3,
        "execution_time_exceeded"
    )]
    [InlineData(
        BetaBashCodeExecutionToolResultErrorErrorCode.OutputFileTooLarge,
        4,
        "output_file_too_large"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaBashCodeExecutionToolResultErrorErrorCode rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
