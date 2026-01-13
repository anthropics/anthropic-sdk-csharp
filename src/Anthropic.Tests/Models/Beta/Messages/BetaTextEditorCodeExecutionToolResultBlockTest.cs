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
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result"
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlock>(
            element
        );
        Assert.NotNull(deserialized);

        BetaTextEditorCodeExecutionToolResultBlockContent expectedContent =
            new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result"
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
    public void BetaTextEditorCodeExecutionToolResultErrorValidationWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value =
            new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        value.Validate();
    }

    [Fact]
    public void BetaTextEditorCodeExecutionViewResultBlockValidationWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value =
            new BetaTextEditorCodeExecutionViewResultBlock()
            {
                Content = "content",
                FileType = FileType.Text,
                NumLines = 0,
                StartLine = 0,
                TotalLines = 0,
            };
        value.Validate();
    }

    [Fact]
    public void BetaTextEditorCodeExecutionCreateResultBlockValidationWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value =
            new BetaTextEditorCodeExecutionCreateResultBlock(true);
        value.Validate();
    }

    [Fact]
    public void BetaTextEditorCodeExecutionStrReplaceResultBlockValidationWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value =
            new BetaTextEditorCodeExecutionStrReplaceResultBlock()
            {
                Lines = ["string"],
                NewLines = 0,
                NewStart = 0,
                OldLines = 0,
                OldStart = 0,
            };
        value.Validate();
    }

    [Fact]
    public void BetaTextEditorCodeExecutionToolResultErrorSerializationRoundtripWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value =
            new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextEditorCodeExecutionViewResultBlockSerializationRoundtripWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value =
            new BetaTextEditorCodeExecutionViewResultBlock()
            {
                Content = "content",
                FileType = FileType.Text,
                NumLines = 0,
                StartLine = 0,
                TotalLines = 0,
            };
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextEditorCodeExecutionCreateResultBlockSerializationRoundtripWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value =
            new BetaTextEditorCodeExecutionCreateResultBlock(true);
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextEditorCodeExecutionStrReplaceResultBlockSerializationRoundtripWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockContent value =
            new BetaTextEditorCodeExecutionStrReplaceResultBlock()
            {
                Lines = ["string"],
                NewLines = 0,
                NewStart = 0,
                OldLines = 0,
                OldStart = 0,
            };
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }
}
