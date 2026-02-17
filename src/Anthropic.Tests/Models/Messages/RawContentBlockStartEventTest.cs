using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawContentBlockStartEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RawContentBlockStartEvent
        {
            ContentBlock = new TextBlock()
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
            },
            Index = 0,
        };

        RawContentBlockStartEventContentBlock expectedContentBlock = new TextBlock()
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
        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_block_start");

        Assert.Equal(expectedContentBlock, model.ContentBlock);
        Assert.Equal(expectedIndex, model.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RawContentBlockStartEvent
        {
            ContentBlock = new TextBlock()
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
            },
            Index = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RawContentBlockStartEvent
        {
            ContentBlock = new TextBlock()
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
            },
            Index = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RawContentBlockStartEventContentBlock expectedContentBlock = new TextBlock()
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
        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_block_start");

        Assert.Equal(expectedContentBlock, deserialized.ContentBlock);
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RawContentBlockStartEvent
        {
            ContentBlock = new TextBlock()
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
            },
            Index = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RawContentBlockStartEvent
        {
            ContentBlock = new TextBlock()
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
            },
            Index = 0,
        };

        RawContentBlockStartEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RawContentBlockStartEventContentBlockTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        RawContentBlockStartEventContentBlock value = new TextBlock()
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
        RawContentBlockStartEventContentBlock value = new ThinkingBlock()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        value.Validate();
    }

    [Fact]
    public void RedactedThinkingValidationWorks()
    {
        RawContentBlockStartEventContentBlock value = new RedactedThinkingBlock("data");
        value.Validate();
    }

    [Fact]
    public void ToolUseValidationWorks()
    {
        RawContentBlockStartEventContentBlock value = new ToolUseBlock()
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
        RawContentBlockStartEventContentBlock value = new ServerToolUseBlock()
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
        RawContentBlockStartEventContentBlock value = new WebSearchToolResultBlock()
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
        RawContentBlockStartEventContentBlock value = new WebFetchToolResultBlock()
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
        RawContentBlockStartEventContentBlock value = new CodeExecutionToolResultBlock()
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
        RawContentBlockStartEventContentBlock value = new BashCodeExecutionToolResultBlock()
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
        RawContentBlockStartEventContentBlock value = new TextEditorCodeExecutionToolResultBlock()
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
        RawContentBlockStartEventContentBlock value = new ToolSearchToolResultBlock()
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
        RawContentBlockStartEventContentBlock value = new ContainerUploadBlock("file_id");
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new TextBlock()
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
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new ThinkingBlock()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedactedThinkingSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new RedactedThinkingBlock("data");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new ToolUseBlock()
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
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolUseSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new ServerToolUseBlock()
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
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchToolResultSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new WebSearchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchToolResultSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new WebFetchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionToolResultSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new CodeExecutionToolResultBlock()
        {
            Content = new CodeExecutionToolResultError(
                CodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BashCodeExecutionToolResultSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new BashCodeExecutionToolResultBlock()
        {
            Content = new BashCodeExecutionToolResultError(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new TextEditorCodeExecutionToolResultBlock()
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSearchToolResultSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new ToolSearchToolResultBlock()
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContainerUploadSerializationRoundtripWorks()
    {
        RawContentBlockStartEventContentBlock value = new ContainerUploadBlock("file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
