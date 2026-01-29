using System.Text.Json;
using Anthropic.Core;
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_tool_result");

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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCodeExecutionToolResultBlockContent expectedContent =
            new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_tool_result");

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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCodeExecutionToolResultBlock
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        BetaCodeExecutionToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
