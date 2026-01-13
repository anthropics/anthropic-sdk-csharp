using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawContentBlockStartEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRawContentBlockStartEvent
        {
            ContentBlock = new BetaTextBlock()
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
            },
            Index = 0,
        };

        ContentBlock expectedContentBlock = new BetaTextBlock()
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
        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_block_start");

        Assert.Equal(expectedContentBlock, model.ContentBlock);
        Assert.Equal(expectedIndex, model.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRawContentBlockStartEvent
        {
            ContentBlock = new BetaTextBlock()
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
            },
            Index = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStartEvent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRawContentBlockStartEvent
        {
            ContentBlock = new BetaTextBlock()
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
            },
            Index = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStartEvent>(element);
        Assert.NotNull(deserialized);

        ContentBlock expectedContentBlock = new BetaTextBlock()
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
        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_block_start");

        Assert.Equal(expectedContentBlock, deserialized.ContentBlock);
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRawContentBlockStartEvent
        {
            ContentBlock = new BetaTextBlock()
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
            },
            Index = 0,
        };

        model.Validate();
    }
}

public class ContentBlockTest : TestBase
{
    [Fact]
    public void BetaTextValidationWorks()
    {
        ContentBlock value = new BetaTextBlock()
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
    public void BetaThinkingValidationWorks()
    {
        ContentBlock value = new BetaThinkingBlock()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        value.Validate();
    }

    [Fact]
    public void BetaRedactedThinkingValidationWorks()
    {
        ContentBlock value = new BetaRedactedThinkingBlock("data");
        value.Validate();
    }

    [Fact]
    public void BetaToolUseValidationWorks()
    {
        ContentBlock value = new BetaToolUseBlock()
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
    public void BetaServerToolUseValidationWorks()
    {
        ContentBlock value = new BetaServerToolUseBlock()
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.WebSearch,
        };
        value.Validate();
    }

    [Fact]
    public void BetaWebSearchToolResultValidationWorks()
    {
        ContentBlock value = new BetaWebSearchToolResultBlock()
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchToolResultValidationWorks()
    {
        ContentBlock value = new BetaWebFetchToolResultBlock()
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void BetaCodeExecutionToolResultValidationWorks()
    {
        ContentBlock value = new BetaCodeExecutionToolResultBlock()
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void BetaBashCodeExecutionToolResultValidationWorks()
    {
        ContentBlock value = new BetaBashCodeExecutionToolResultBlock()
        {
            Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        value.Validate();
    }

    [Fact]
    public void BetaTextEditorCodeExecutionToolResultValidationWorks()
    {
        ContentBlock value = new BetaTextEditorCodeExecutionToolResultBlock()
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
    public void BetaToolSearchToolResultValidationWorks()
    {
        ContentBlock value = new BetaToolSearchToolResultBlock()
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
    public void BetaMcpToolUseValidationWorks()
    {
        ContentBlock value = new BetaMcpToolUseBlock()
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
    public void BetaMcpToolResultValidationWorks()
    {
        ContentBlock value = new BetaMcpToolResultBlock()
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };
        value.Validate();
    }

    [Fact]
    public void BetaContainerUploadValidationWorks()
    {
        ContentBlock value = new BetaContainerUploadBlock("file_id");
        value.Validate();
    }

    [Fact]
    public void BetaTextSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaTextBlock()
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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaThinkingSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaThinkingBlock()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRedactedThinkingSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaRedactedThinkingBlock("data");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolUseSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaToolUseBlock()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolUseSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaServerToolUseBlock()
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.WebSearch,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebSearchToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaWebSearchToolResultBlock()
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaWebFetchToolResultBlock()
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCodeExecutionToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaCodeExecutionToolResultBlock()
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaBashCodeExecutionToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaBashCodeExecutionToolResultBlock()
        {
            Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextEditorCodeExecutionToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaTextEditorCodeExecutionToolResultBlock()
        {
            Content = new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolSearchToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaToolSearchToolResultBlock()
        {
            Content = new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaMcpToolUseSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaMcpToolUseBlock()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaMcpToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaMcpToolResultBlock()
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaContainerUploadSerializationRoundtripWorks()
    {
        ContentBlock value = new BetaContainerUploadBlock("file_id");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }
}
