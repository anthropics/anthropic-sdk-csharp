using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContentBlockTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        BetaContentBlock value = new BetaTextBlock()
        {
            Citations =
            [
                new BetaCitationCharLocation()
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
        BetaContentBlock value = new BetaThinkingBlock()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        value.Validate();
    }

    [Fact]
    public void RedactedThinkingValidationWorks()
    {
        BetaContentBlock value = new BetaRedactedThinkingBlock("data");
        value.Validate();
    }

    [Fact]
    public void ToolUseValidationWorks()
    {
        BetaContentBlock value = new BetaToolUseBlock()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        BetaContentBlock value = new BetaServerToolUseBlock()
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.WebSearch,
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchToolResultValidationWorks()
    {
        BetaContentBlock value = new BetaWebSearchToolResultBlock()
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchToolResultValidationWorks()
    {
        BetaContentBlock value = new BetaWebFetchToolResultBlock()
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionToolResultValidationWorks()
    {
        BetaContentBlock value = new BetaCodeExecutionToolResultBlock()
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void BashCodeExecutionToolResultValidationWorks()
    {
        BetaContentBlock value = new BetaBashCodeExecutionToolResultBlock()
        {
            Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultValidationWorks()
    {
        BetaContentBlock value = new BetaTextEditorCodeExecutionToolResultBlock()
        {
            Content = new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void ToolSearchToolResultValidationWorks()
    {
        BetaContentBlock value = new BetaToolSearchToolResultBlock()
        {
            Content = new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void McpToolUseValidationWorks()
    {
        BetaContentBlock value = new BetaMcpToolUseBlock()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
        };
        value.Validate();
    }

    [Fact]
    public void McpToolResultValidationWorks()
    {
        BetaContentBlock value = new BetaMcpToolResultBlock()
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };
        value.Validate();
    }

    [Fact]
    public void ContainerUploadValidationWorks()
    {
        BetaContentBlock value = new BetaContainerUploadBlock("file_id");
        value.Validate();
    }

    [Fact]
    public void CompactionValidationWorks()
    {
        BetaContentBlock value = new BetaCompactionBlock("content");
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaTextBlock()
        {
            Citations =
            [
                new BetaCitationCharLocation()
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
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaThinkingBlock()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedactedThinkingSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaRedactedThinkingBlock("data");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaToolUseBlock()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolUseSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaServerToolUseBlock()
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.WebSearch,
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaWebSearchToolResultBlock()
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaWebFetchToolResultBlock()
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaCodeExecutionToolResultBlock()
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BashCodeExecutionToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaBashCodeExecutionToolResultBlock()
        {
            Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaTextEditorCodeExecutionToolResultBlock()
        {
            Content = new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSearchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaToolSearchToolResultBlock()
        {
            Content = new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpToolUseSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaMcpToolUseBlock()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaMcpToolResultBlock()
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContainerUploadSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaContainerUploadBlock("file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaCompactionBlock("content");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
