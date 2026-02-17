using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        ContentBlock value = new TextBlock()
        {
            Citations =
            [
                new CitationCharLocation()
                {
                    CitedText = "cited_text",
                    DocumentIndex = 0,
                    DocumentTitle = "document_title",
                    EndCharIndex = 0,
                    FileID = "file_id",
                    StartCharIndex = 0,
                },
            ],
            Text = "text",
        };
        value.Validate();
    }

    [Fact]
    public void ThinkingValidationWorks()
    {
        ContentBlock value = new ThinkingBlock() { Signature = "signature", Thinking = "thinking" };
        value.Validate();
    }

    [Fact]
    public void RedactedThinkingValidationWorks()
    {
        ContentBlock value = new RedactedThinkingBlock("data");
        value.Validate();
    }

    [Fact]
    public void ToolUseValidationWorks()
    {
        ContentBlock value = new ToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        ContentBlock value = new ServerToolUseBlock()
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.WebSearch,
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchToolResultValidationWorks()
    {
        ContentBlock value = new WebSearchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchToolResultValidationWorks()
    {
        ContentBlock value = new WebFetchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionToolResultValidationWorks()
    {
        ContentBlock value = new CodeExecutionToolResultBlock()
        {
            Content = new CodeExecutionToolResultError(
                CodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void BashCodeExecutionToolResultValidationWorks()
    {
        ContentBlock value = new BashCodeExecutionToolResultBlock()
        {
            Content = new BashCodeExecutionToolResultError(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultValidationWorks()
    {
        ContentBlock value = new TextEditorCodeExecutionToolResultBlock()
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void ToolSearchToolResultValidationWorks()
    {
        ContentBlock value = new ToolSearchToolResultBlock()
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void ContainerUploadValidationWorks()
    {
        ContentBlock value = new ContainerUploadBlock("file_id");
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        ContentBlock value = new TextBlock()
        {
            Citations =
            [
                new CitationCharLocation()
                {
                    CitedText = "cited_text",
                    DocumentIndex = 0,
                    DocumentTitle = "document_title",
                    EndCharIndex = 0,
                    FileID = "file_id",
                    StartCharIndex = 0,
                },
            ],
            Text = "text",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        ContentBlock value = new ThinkingBlock() { Signature = "signature", Thinking = "thinking" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedactedThinkingSerializationRoundtripWorks()
    {
        ContentBlock value = new RedactedThinkingBlock("data");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseSerializationRoundtripWorks()
    {
        ContentBlock value = new ToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolUseSerializationRoundtripWorks()
    {
        ContentBlock value = new ServerToolUseBlock()
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.WebSearch,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new WebSearchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new WebFetchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new CodeExecutionToolResultBlock()
        {
            Content = new CodeExecutionToolResultError(
                CodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BashCodeExecutionToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new BashCodeExecutionToolResultBlock()
        {
            Content = new BashCodeExecutionToolResultError(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new TextEditorCodeExecutionToolResultBlock()
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSearchToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new ToolSearchToolResultBlock()
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContainerUploadSerializationRoundtripWorks()
    {
        ContentBlock value = new ContainerUploadBlock("file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
