using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlock
        {
            Content = new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        BetaTextEditorCodeExecutionToolResultBlockContent expectedContent =
            new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlock
        {
            Content = new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlock>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlock
        {
            Content = new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlock>(
            json
        );
        Assert.NotNull(deserialized);

        BetaTextEditorCodeExecutionToolResultBlockContent expectedContent =
            new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlock
        {
            Content = new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }
}

public class BetaTextEditorCodeExecutionToolResultBlockContentTest : TestBase
{
    [Fact]
    public void beta_text_editor_code_execution_tool_result_errorValidation_Works()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value = new(
            new()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            }
        );
        value.Validate();
    }

    [Fact]
    public void beta_text_editor_code_execution_view_result_blockValidation_Works()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value = new(
            new()
            {
                Content = "content",
                FileType = FileType.Text,
                NumLines = 0,
                StartLine = 0,
                TotalLines = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void beta_text_editor_code_execution_create_result_blockValidation_Works()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value = new(new(true));
        value.Validate();
    }

    [Fact]
    public void beta_text_editor_code_execution_str_replace_result_blockValidation_Works()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value = new(
            new()
            {
                Lines = ["string"],
                NewLines = 0,
                NewStart = 0,
                OldLines = 0,
                OldStart = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void beta_text_editor_code_execution_tool_result_errorSerializationRoundtrip_Works()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value = new(
            new()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_text_editor_code_execution_view_result_blockSerializationRoundtrip_Works()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value = new(
            new()
            {
                Content = "content",
                FileType = FileType.Text,
                NumLines = 0,
                StartLine = 0,
                TotalLines = 0,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_text_editor_code_execution_create_result_blockSerializationRoundtrip_Works()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value = new(new(true));
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_text_editor_code_execution_str_replace_result_blockSerializationRoundtrip_Works()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value = new(
            new()
            {
                Lines = ["string"],
                NewLines = 0,
                NewStart = 0,
                OldLines = 0,
                OldStart = 0,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }
}
