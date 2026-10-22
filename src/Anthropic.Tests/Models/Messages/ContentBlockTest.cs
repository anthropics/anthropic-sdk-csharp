using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            ToolsetName = "toolset_name",
        };
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        ContentBlock value = new ServerToolUseBlock()
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
        ContentBlock value = new WebSearchToolResultBlock()
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
        ContentBlock value = new WebFetchToolResultBlock()
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
        ContentBlock value = new CodeExecutionToolResultBlock()
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
        ContentBlock value = new BashCodeExecutionToolResultBlock()
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
        ContentBlock value = new TextEditorCodeExecutionToolResultBlock()
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
        ContentBlock value = new ToolSearchToolResultBlock()
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
            ToolsetName = "toolset_name",
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
            ID = "srvtoolu_c",
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
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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

    [Fact]
    public void TextTypeWorks()
    {
        ContentBlock value = new TextBlock()
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
        Assert.Equal(ContentBlockType.Text, value.Type.Value());
    }

    [Fact]
    public void ThinkingTypeWorks()
    {
        ContentBlock value = new ThinkingBlock() { Signature = "signature", Thinking = "thinking" };
        Assert.Equal(ContentBlockType.Thinking, value.Type.Value());
    }

    [Fact]
    public void RedactedThinkingTypeWorks()
    {
        ContentBlock value = new RedactedThinkingBlock("data");
        Assert.Equal(ContentBlockType.RedactedThinking, value.Type.Value());
    }

    [Fact]
    public void ToolUseTypeWorks()
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
            ToolsetName = "toolset_name",
        };
        Assert.Equal(ContentBlockType.ToolUse, value.Type.Value());
    }

    [Fact]
    public void ServerToolUseTypeWorks()
    {
        ContentBlock value = new ServerToolUseBlock()
        {
            ID = "srvtoolu_c",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.WebSearch,
        };
        Assert.Equal(ContentBlockType.ServerToolUse, value.Type.Value());
    }

    [Fact]
    public void WebSearchToolResultTypeWorks()
    {
        ContentBlock value = new WebSearchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(ContentBlockType.WebSearchToolResult, value.Type.Value());
    }

    [Fact]
    public void WebFetchToolResultTypeWorks()
    {
        ContentBlock value = new WebFetchToolResultBlock()
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(ContentBlockType.WebFetchToolResult, value.Type.Value());
    }

    [Fact]
    public void CodeExecutionToolResultTypeWorks()
    {
        ContentBlock value = new CodeExecutionToolResultBlock()
        {
            Content = new CodeExecutionToolResultError(
                CodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(ContentBlockType.CodeExecutionToolResult, value.Type.Value());
    }

    [Fact]
    public void BashCodeExecutionToolResultTypeWorks()
    {
        ContentBlock value = new BashCodeExecutionToolResultBlock()
        {
            Content = new BashCodeExecutionToolResultError(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(ContentBlockType.BashCodeExecutionToolResult, value.Type.Value());
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultTypeWorks()
    {
        ContentBlock value = new TextEditorCodeExecutionToolResultBlock()
        {
            Content = new TextEditorCodeExecutionToolResultError()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(ContentBlockType.TextEditorCodeExecutionToolResult, value.Type.Value());
    }

    [Fact]
    public void ToolSearchToolResultTypeWorks()
    {
        ContentBlock value = new ToolSearchToolResultBlock()
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(ContentBlockType.ToolSearchToolResult, value.Type.Value());
    }

    [Fact]
    public void ContainerUploadTypeWorks()
    {
        ContentBlock value = new ContainerUploadBlock("file_id");
        Assert.Equal(ContentBlockType.ContainerUpload, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ContentBlock value = new(
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

        ApiEnum<string, ContentBlockType> expectedType = ContentBlockType.Text;
        string expectedID = "id";
        string expectedToolUseID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedToolUseID, value.ToolUseID);

        ContentBlock emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ID);
        Assert.Null(emptyValue.ToolUseID);

        ContentBlock mismatchedValue = new(
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

public class ContentBlockTypeTest : TestBase
{
    [Theory]
    [InlineData(ContentBlockType.Text)]
    [InlineData(ContentBlockType.Thinking)]
    [InlineData(ContentBlockType.RedactedThinking)]
    [InlineData(ContentBlockType.ToolUse)]
    [InlineData(ContentBlockType.ServerToolUse)]
    [InlineData(ContentBlockType.WebSearchToolResult)]
    [InlineData(ContentBlockType.WebFetchToolResult)]
    [InlineData(ContentBlockType.CodeExecutionToolResult)]
    [InlineData(ContentBlockType.BashCodeExecutionToolResult)]
    [InlineData(ContentBlockType.TextEditorCodeExecutionToolResult)]
    [InlineData(ContentBlockType.ToolSearchToolResult)]
    [InlineData(ContentBlockType.ContainerUpload)]
    public void Validation_Works(ContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentBlockType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContentBlockType.Text)]
    [InlineData(ContentBlockType.Thinking)]
    [InlineData(ContentBlockType.RedactedThinking)]
    [InlineData(ContentBlockType.ToolUse)]
    [InlineData(ContentBlockType.ServerToolUse)]
    [InlineData(ContentBlockType.WebSearchToolResult)]
    [InlineData(ContentBlockType.WebFetchToolResult)]
    [InlineData(ContentBlockType.CodeExecutionToolResult)]
    [InlineData(ContentBlockType.BashCodeExecutionToolResult)]
    [InlineData(ContentBlockType.TextEditorCodeExecutionToolResult)]
    [InlineData(ContentBlockType.ToolSearchToolResult)]
    [InlineData(ContentBlockType.ContainerUpload)]
    public void SerializationRoundtrip_Works(ContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentBlockType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentBlockType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentBlockType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
