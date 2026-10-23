using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
                        CitedText = "The grass is green. The sky is blue.",
                        DocumentIndex = 0,
                        DocumentTitle = "My Document",
                        EndCharIndex = 0,
                        FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "My Document",
                    EndCharIndex = 0,
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                        CitedText = "The grass is green. The sky is blue.",
                        DocumentIndex = 0,
                        DocumentTitle = "My Document",
                        EndCharIndex = 0,
                        FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                        CitedText = "The grass is green. The sky is blue.",
                        DocumentIndex = 0,
                        DocumentTitle = "My Document",
                        EndCharIndex = 0,
                        FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "My Document",
                    EndCharIndex = 0,
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                        CitedText = "The grass is green. The sky is blue.",
                        DocumentIndex = 0,
                        DocumentTitle = "My Document",
                        EndCharIndex = 0,
                        FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                        CitedText = "The grass is green. The sky is blue.",
                        DocumentIndex = 0,
                        DocumentTitle = "My Document",
                        EndCharIndex = 0,
                        FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "My Document",
                    EndCharIndex = 0,
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
            ToolsetName = "toolset_name",
        };
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        RawContentBlockStartEventContentBlock value = new ServerToolUseBlock()
        {
            ID = "srvtoolu_c",
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
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "My Document",
                    EndCharIndex = 0,
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
            ToolsetName = "toolset_name",
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
            ID = "srvtoolu_c",
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
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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

    [Fact]
    public void TextTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new TextBlock()
        {
            Citations =
            [
                new CitationCharLocation()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "My Document",
                    EndCharIndex = 0,
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    StartCharIndex = 0,
                },
            ],
            Text = "text",
        };
        Assert.Equal(RawContentBlockStartEventContentBlockType.Text, value.Type.Value());
    }

    [Fact]
    public void ThinkingTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new ThinkingBlock()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        Assert.Equal(RawContentBlockStartEventContentBlockType.Thinking, value.Type.Value());
    }

    [Fact]
    public void RedactedThinkingTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new RedactedThinkingBlock("data");
        Assert.Equal(
            RawContentBlockStartEventContentBlockType.RedactedThinking,
            value.Type.Value()
        );
    }

    [Fact]
    public void ToolUseTypeWorks()
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
            ToolsetName = "toolset_name",
        };
        Assert.Equal(RawContentBlockStartEventContentBlockType.ToolUse, value.Type.Value());
    }

    [Fact]
    public void ServerToolUseTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new ServerToolUseBlock()
        {
            ID = "srvtoolu_c",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.WebSearch,
        };
        Assert.Equal(RawContentBlockStartEventContentBlockType.ServerToolUse, value.Type.Value());
    }

    [Fact]
    public void WebSearchToolResultTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new WebSearchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(
            RawContentBlockStartEventContentBlockType.WebSearchToolResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void WebFetchToolResultTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new WebFetchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(
            RawContentBlockStartEventContentBlockType.WebFetchToolResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void CodeExecutionToolResultTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new CodeExecutionToolResultBlock()
        {
            Content = new CodeExecutionToolResultError(
                CodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(
            RawContentBlockStartEventContentBlockType.CodeExecutionToolResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void BashCodeExecutionToolResultTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new BashCodeExecutionToolResultBlock()
        {
            Content = new BashCodeExecutionToolResultError(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(
            RawContentBlockStartEventContentBlockType.BashCodeExecutionToolResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new TextEditorCodeExecutionToolResultBlock()
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(
            RawContentBlockStartEventContentBlockType.TextEditorCodeExecutionToolResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void ToolSearchToolResultTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new ToolSearchToolResultBlock()
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(
            RawContentBlockStartEventContentBlockType.ToolSearchToolResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void ContainerUploadTypeWorks()
    {
        RawContentBlockStartEventContentBlock value = new ContainerUploadBlock("file_id");
        Assert.Equal(RawContentBlockStartEventContentBlockType.ContainerUpload, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text",
                  "id": "id",
                  "tool_use_id": "srvtoolu_c"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, RawContentBlockStartEventContentBlockType> expectedType =
            RawContentBlockStartEventContentBlockType.Text;
        string expectedID = "id";
        string expectedToolUseID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedToolUseID, value.ToolUseID);

        RawContentBlockStartEventContentBlock emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ID);
        Assert.Null(emptyValue.ToolUseID);

        RawContentBlockStartEventContentBlock mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ],
                  "tool_use_id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ID);
        Assert.Null(mismatchedValue.ToolUseID);
    }
}

public class RawContentBlockStartEventContentBlockTypeTest : TestBase
{
    [Theory]
    [InlineData(RawContentBlockStartEventContentBlockType.Text)]
    [InlineData(RawContentBlockStartEventContentBlockType.Thinking)]
    [InlineData(RawContentBlockStartEventContentBlockType.RedactedThinking)]
    [InlineData(RawContentBlockStartEventContentBlockType.ToolUse)]
    [InlineData(RawContentBlockStartEventContentBlockType.ServerToolUse)]
    [InlineData(RawContentBlockStartEventContentBlockType.WebSearchToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.WebFetchToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.CodeExecutionToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.BashCodeExecutionToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.TextEditorCodeExecutionToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.ToolSearchToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.ContainerUpload)]
    public void Validation_Works(RawContentBlockStartEventContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RawContentBlockStartEventContentBlockType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RawContentBlockStartEventContentBlockType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RawContentBlockStartEventContentBlockType.Text)]
    [InlineData(RawContentBlockStartEventContentBlockType.Thinking)]
    [InlineData(RawContentBlockStartEventContentBlockType.RedactedThinking)]
    [InlineData(RawContentBlockStartEventContentBlockType.ToolUse)]
    [InlineData(RawContentBlockStartEventContentBlockType.ServerToolUse)]
    [InlineData(RawContentBlockStartEventContentBlockType.WebSearchToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.WebFetchToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.CodeExecutionToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.BashCodeExecutionToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.TextEditorCodeExecutionToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.ToolSearchToolResult)]
    [InlineData(RawContentBlockStartEventContentBlockType.ContainerUpload)]
    public void SerializationRoundtrip_Works(RawContentBlockStartEventContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RawContentBlockStartEventContentBlockType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RawContentBlockStartEventContentBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RawContentBlockStartEventContentBlockType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RawContentBlockStartEventContentBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
