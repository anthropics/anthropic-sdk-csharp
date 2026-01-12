using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        ApiEnum<string, BetaCodeExecutionToolResultErrorCode> expectedErrorCode =
            BetaCodeExecutionToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultErrorParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultErrorParam>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaCodeExecutionToolResultErrorCode> expectedErrorCode =
            BetaCodeExecutionToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        model.Validate();
    }
}
