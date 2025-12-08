using System.Text.Json;
using Anthropic.Core;
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultErrorParam>(
            json
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
