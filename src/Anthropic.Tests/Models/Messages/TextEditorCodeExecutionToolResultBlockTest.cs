using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextEditorCodeExecutionToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlock
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        TextEditorCodeExecutionToolResultBlockContent expectedContent =
            new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
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
        var model = new TextEditorCodeExecutionToolResultBlock
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlock
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TextEditorCodeExecutionToolResultBlockContent expectedContent =
            new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
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
        var model = new TextEditorCodeExecutionToolResultBlock
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlock
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        TextEditorCodeExecutionToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextEditorCodeExecutionToolResultBlockContentTest : TestBase
{
    [Fact]
    public void TextEditorCodeExecutionToolResultErrorValidationWorks()
    {
        TextEditorCodeExecutionToolResultBlockContent value =
            new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionViewResultBlockValidationWorks()
    {
        TextEditorCodeExecutionToolResultBlockContent value =
            new TextEditorCodeExecutionViewResultBlock()
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
    public void TextEditorCodeExecutionCreateResultBlockValidationWorks()
    {
        TextEditorCodeExecutionToolResultBlockContent value =
            new TextEditorCodeExecutionCreateResultBlock(true);
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionStrReplaceResultBlockValidationWorks()
    {
        TextEditorCodeExecutionToolResultBlockContent value =
            new TextEditorCodeExecutionStrReplaceResultBlock()
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
    public void TextEditorCodeExecutionToolResultErrorSerializationRoundtripWorks()
    {
        TextEditorCodeExecutionToolResultBlockContent value =
            new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionViewResultBlockSerializationRoundtripWorks()
    {
        TextEditorCodeExecutionToolResultBlockContent value =
            new TextEditorCodeExecutionViewResultBlock()
            {
                Content = "content",
                FileType = FileType.Text,
                NumLines = 0,
                StartLine = 0,
                TotalLines = 0,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionCreateResultBlockSerializationRoundtripWorks()
    {
        TextEditorCodeExecutionToolResultBlockContent value =
            new TextEditorCodeExecutionCreateResultBlock(true);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionStrReplaceResultBlockSerializationRoundtripWorks()
    {
        TextEditorCodeExecutionToolResultBlockContent value =
            new TextEditorCodeExecutionStrReplaceResultBlock()
            {
                Lines = ["string"],
                NewLines = 0,
                NewStart = 0,
                OldLines = 0,
                OldStart = 0,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
