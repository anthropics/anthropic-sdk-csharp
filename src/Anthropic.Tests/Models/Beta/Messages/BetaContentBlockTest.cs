using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContentBlockTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaTextBlock()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void ThinkingValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaThinkingBlock() { Signature = "signature", Thinking = "thinking" }
        );
        value.Validate();
    }

    [Fact]
    public void RedactedThinkingValidationWorks()
    {
        BetaContentBlock value = new(new BetaRedactedThinkingBlock("data"));
        value.Validate();
    }

    [Fact]
    public void ToolUseValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaToolUseBlock()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "x",
                Caller = new BetaDirectCaller(),
            }
        );
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaServerToolUseBlock()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Caller = new BetaDirectCaller(),
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = Name.WebSearch,
            }
        );
        value.Validate();
    }

    [Fact]
    public void WebSearchToolResultValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaWebSearchToolResultBlock()
            {
                Content = new BetaWebSearchToolResultError(
                    BetaWebSearchToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        value.Validate();
    }

    [Fact]
    public void WebFetchToolResultValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaWebFetchToolResultBlock()
            {
                Content = new BetaWebFetchToolResultErrorBlock(
                    BetaWebFetchToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        value.Validate();
    }

    [Fact]
    public void CodeExecutionToolResultValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaCodeExecutionToolResultBlock()
            {
                Content = new BetaCodeExecutionToolResultError(
                    BetaCodeExecutionToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BashCodeExecutionToolResultValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaBashCodeExecutionToolResultBlock()
            {
                Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaTextEditorCodeExecutionToolResultBlock()
            {
                Content = new BetaTextEditorCodeExecutionToolResultError()
                {
                    ErrorCode =
                        BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                    ErrorMessage = "error_message",
                },
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        value.Validate();
    }

    [Fact]
    public void ToolSearchToolResultValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaToolSearchToolResultBlock()
            {
                Content = new BetaToolSearchToolResultError()
                {
                    ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                    ErrorMessage = "error_message",
                },
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        value.Validate();
    }

    [Fact]
    public void MCPToolUseValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaMCPToolUseBlock()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                ServerName = "server_name",
            }
        );
        value.Validate();
    }

    [Fact]
    public void MCPToolResultValidationWorks()
    {
        BetaContentBlock value = new(
            new BetaMCPToolResultBlock()
            {
                Content = "string",
                IsError = true,
                ToolUseID = "tool_use_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void ContainerUploadValidationWorks()
    {
        BetaContentBlock value = new(new BetaContainerUploadBlock("file_id"));
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaTextBlock()
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaThinkingBlock() { Signature = "signature", Thinking = "thinking" }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedactedThinkingSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(new BetaRedactedThinkingBlock("data"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaToolUseBlock()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "x",
                Caller = new BetaDirectCaller(),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolUseSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaServerToolUseBlock()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Caller = new BetaDirectCaller(),
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = Name.WebSearch,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaWebSearchToolResultBlock()
            {
                Content = new BetaWebSearchToolResultError(
                    BetaWebSearchToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaWebFetchToolResultBlock()
            {
                Content = new BetaWebFetchToolResultErrorBlock(
                    BetaWebFetchToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaCodeExecutionToolResultBlock()
            {
                Content = new BetaCodeExecutionToolResultError(
                    BetaCodeExecutionToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BashCodeExecutionToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaBashCodeExecutionToolResultBlock()
            {
                Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaTextEditorCodeExecutionToolResultBlock()
            {
                Content = new BetaTextEditorCodeExecutionToolResultError()
                {
                    ErrorCode =
                        BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                    ErrorMessage = "error_message",
                },
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSearchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaToolSearchToolResultBlock()
            {
                Content = new BetaToolSearchToolResultError()
                {
                    ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                    ErrorMessage = "error_message",
                },
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MCPToolUseSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaMCPToolUseBlock()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                ServerName = "server_name",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MCPToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(
            new BetaMCPToolResultBlock()
            {
                Content = "string",
                IsError = true,
                ToolUseID = "tool_use_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContainerUploadSerializationRoundtripWorks()
    {
        BetaContentBlock value = new(new BetaContainerUploadBlock("file_id"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }
}
