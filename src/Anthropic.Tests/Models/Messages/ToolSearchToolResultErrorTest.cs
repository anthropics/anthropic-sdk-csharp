using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolSearchToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolSearchToolResultError
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ApiEnum<string, ToolSearchToolResultErrorCode> expectedErrorCode =
            ToolSearchToolResultErrorCode.InvalidToolInput;
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
        var model = new ToolSearchToolResultError
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolSearchToolResultError
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ToolSearchToolResultErrorCode> expectedErrorCode =
            ToolSearchToolResultErrorCode.InvalidToolInput;
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
        var model = new ToolSearchToolResultError
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolSearchToolResultError
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ToolSearchToolResultError copied = new(model);

        Assert.Equal(model, copied);
    }
}
