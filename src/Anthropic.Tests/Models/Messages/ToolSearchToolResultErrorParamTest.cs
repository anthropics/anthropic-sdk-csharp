using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolSearchToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolSearchToolResultErrorParam
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ApiEnum<string, ToolSearchToolResultErrorCode> expectedErrorCode =
            ToolSearchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "tool_search_tool_result_error"
        );
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolSearchToolResultErrorParam
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultErrorParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolSearchToolResultErrorParam
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultErrorParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ToolSearchToolResultErrorCode> expectedErrorCode =
            ToolSearchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "tool_search_tool_result_error"
        );
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolSearchToolResultErrorParam
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolSearchToolResultErrorParam
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
        };

        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolSearchToolResultErrorParam
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolSearchToolResultErrorParam
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,

            ErrorMessage = null,
        };

        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolSearchToolResultErrorParam
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,

            ErrorMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolSearchToolResultErrorParam
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ToolSearchToolResultErrorParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
