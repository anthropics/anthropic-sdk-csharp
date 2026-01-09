using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCodeExecutionToolResultBlock
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        BetaCodeExecutionToolResultBlockContent expectedContent =
            new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_tool_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCodeExecutionToolResultBlock
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCodeExecutionToolResultBlock
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(element);
        Assert.NotNull(deserialized);

        BetaCodeExecutionToolResultBlockContent expectedContent =
            new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_tool_result\""
        );

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCodeExecutionToolResultBlock
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }
}
