using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBashCodeExecutionToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlock
        {
            Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        Content expectedContent = new BetaBashCodeExecutionToolResultError(
            ErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlock
        {
            Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlock
        {
            Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlock>(json);
        Assert.NotNull(deserialized);

        Content expectedContent = new BetaBashCodeExecutionToolResultError(
            ErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result\""
        );

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlock
        {
            Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void BetaBashCodeExecutionToolResultErrorValidationWorks()
    {
        Content value = new(new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput));
        value.Validate();
    }

    [Fact]
    public void BetaBashCodeExecutionResultBlockValidationWorks()
    {
        Content value = new(
            new BetaBashCodeExecutionResultBlock()
            {
                Content = [new("file_id")],
                ReturnCode = 0,
                Stderr = "stderr",
                Stdout = "stdout",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaBashCodeExecutionToolResultErrorSerializationRoundtripWorks()
    {
        Content value = new(new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Content>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaBashCodeExecutionResultBlockSerializationRoundtripWorks()
    {
        Content value = new(
            new BetaBashCodeExecutionResultBlock()
            {
                Content = [new("file_id")],
                ReturnCode = 0,
                Stderr = "stderr",
                Stdout = "stdout",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Content>(json);

        Assert.Equal(value, deserialized);
    }
}
