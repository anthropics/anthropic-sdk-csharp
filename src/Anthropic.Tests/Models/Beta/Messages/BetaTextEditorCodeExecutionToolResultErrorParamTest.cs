using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ApiEnum<
            string,
            BetaTextEditorCodeExecutionToolResultErrorParamErrorCode
        > expectedErrorCode =
            BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultErrorParam>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultErrorParam>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            BetaTextEditorCodeExecutionToolResultErrorParamErrorCode
        > expectedErrorCode =
            BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
        };

        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,

            ErrorMessage = null,
        };

        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,

            ErrorMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        BetaTextEditorCodeExecutionToolResultErrorParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaTextEditorCodeExecutionToolResultErrorParamErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.Unavailable)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.TooManyRequests)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.ExecutionTimeExceeded)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.FileNotFound)]
    public void Validation_Works(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorParamErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorParamErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.Unavailable)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.TooManyRequests)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.ExecutionTimeExceeded)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.FileNotFound)]
    public void SerializationRoundtrip_Works(
        BetaTextEditorCodeExecutionToolResultErrorParamErrorCode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorParamErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorParamErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorParamErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorParamErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
