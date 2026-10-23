using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

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
            ToolsetName = "toolset_name",
        };
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        BetaContentBlock value = new BetaServerToolUseBlock()
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.Advisor,
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void AdvisorToolResultValidationWorks()
    {
        BetaContentBlock value = new BetaAdvisorToolResultBlock()
        {
            Content = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded),
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
        };
        value.Validate();
    }

    [Fact]
    public void BashCodeExecutionToolResultValidationWorks()
    {
        BetaContentBlock value = new BetaBashCodeExecutionToolResultBlock()
        {
            Content = new BetaBashCodeExecutionToolResultError(
                BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
        BetaContentBlock value = new BetaCompactionBlock()
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaResponseToolAdditionBlock(new BetaResponseToolChangeToolReference("name")),
            ],
        };
        value.Validate();
    }

    [Fact]
    public void FallbackValidationWorks()
    {
        BetaContentBlock value = new BetaFallbackBlock()
        {
            From = new(Messages::Model.ClaudeHaiku5_5),
            To = new(Messages::Model.ClaudeHaiku5_5),
            Trigger = new(BetaFallbackRefusalTriggerCategory.Cyber),
        };
        value.Validate();
    }

    [Fact]
    public void McpToolListingValidationWorks()
    {
        BetaContentBlock value = new BetaMcpToolListingBlock()
        {
            McpServerName = "mcp_server_name",
            Tools =
            [
                new()
                {
                    InputSchema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Description = "description",
                },
            ],
        };
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
            ToolsetName = "toolset_name",
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
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.Advisor,
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
    public void AdvisorToolResultSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaAdvisorToolResultBlock()
        {
            Content = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded),
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            Content = new BetaBashCodeExecutionToolResultError(
                BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
        BetaContentBlock value = new BetaCompactionBlock()
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaResponseToolAdditionBlock(new BetaResponseToolChangeToolReference("name")),
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FallbackSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaFallbackBlock()
        {
            From = new(Messages::Model.ClaudeHaiku5_5),
            To = new(Messages::Model.ClaudeHaiku5_5),
            Trigger = new(BetaFallbackRefusalTriggerCategory.Cyber),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpToolListingSerializationRoundtripWorks()
    {
        BetaContentBlock value = new BetaMcpToolListingBlock()
        {
            McpServerName = "mcp_server_name",
            Tools =
            [
                new()
                {
                    InputSchema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Description = "description",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextTypeWorks()
    {
        BetaContentBlock value = new BetaTextBlock()
        {
            Citations =
            [
                new BetaCitationCharLocation()
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
        Assert.Equal(BetaContentBlockType.Text, value.Type.Value());
    }

    [Fact]
    public void ThinkingTypeWorks()
    {
        BetaContentBlock value = new BetaThinkingBlock()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        Assert.Equal(BetaContentBlockType.Thinking, value.Type.Value());
    }

    [Fact]
    public void RedactedThinkingTypeWorks()
    {
        BetaContentBlock value = new BetaRedactedThinkingBlock("data");
        Assert.Equal(BetaContentBlockType.RedactedThinking, value.Type.Value());
    }

    [Fact]
    public void ToolUseTypeWorks()
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
            ToolsetName = "toolset_name",
        };
        Assert.Equal(BetaContentBlockType.ToolUse, value.Type.Value());
    }

    [Fact]
    public void ServerToolUseTypeWorks()
    {
        BetaContentBlock value = new BetaServerToolUseBlock()
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.Advisor,
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaContentBlockType.ServerToolUse, value.Type.Value());
    }

    [Fact]
    public void WebSearchToolResultTypeWorks()
    {
        BetaContentBlock value = new BetaWebSearchToolResultBlock()
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaContentBlockType.WebSearchToolResult, value.Type.Value());
    }

    [Fact]
    public void WebFetchToolResultTypeWorks()
    {
        BetaContentBlock value = new BetaWebFetchToolResultBlock()
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaContentBlockType.WebFetchToolResult, value.Type.Value());
    }

    [Fact]
    public void AdvisorToolResultTypeWorks()
    {
        BetaContentBlock value = new BetaAdvisorToolResultBlock()
        {
            Content = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(BetaContentBlockType.AdvisorToolResult, value.Type.Value());
    }

    [Fact]
    public void CodeExecutionToolResultTypeWorks()
    {
        BetaContentBlock value = new BetaCodeExecutionToolResultBlock()
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(BetaContentBlockType.CodeExecutionToolResult, value.Type.Value());
    }

    [Fact]
    public void BashCodeExecutionToolResultTypeWorks()
    {
        BetaContentBlock value = new BetaBashCodeExecutionToolResultBlock()
        {
            Content = new BetaBashCodeExecutionToolResultError(
                BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(BetaContentBlockType.BashCodeExecutionToolResult, value.Type.Value());
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultTypeWorks()
    {
        BetaContentBlock value = new BetaTextEditorCodeExecutionToolResultBlock()
        {
            Content = new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(BetaContentBlockType.TextEditorCodeExecutionToolResult, value.Type.Value());
    }

    [Fact]
    public void ToolSearchToolResultTypeWorks()
    {
        BetaContentBlock value = new BetaToolSearchToolResultBlock()
        {
            Content = new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
        };
        Assert.Equal(BetaContentBlockType.ToolSearchToolResult, value.Type.Value());
    }

    [Fact]
    public void McpToolUseTypeWorks()
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
        Assert.Equal(BetaContentBlockType.McpToolUse, value.Type.Value());
    }

    [Fact]
    public void McpToolResultTypeWorks()
    {
        BetaContentBlock value = new BetaMcpToolResultBlock()
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };
        Assert.Equal(BetaContentBlockType.McpToolResult, value.Type.Value());
    }

    [Fact]
    public void ContainerUploadTypeWorks()
    {
        BetaContentBlock value = new BetaContainerUploadBlock("file_id");
        Assert.Equal(BetaContentBlockType.ContainerUpload, value.Type.Value());
    }

    [Fact]
    public void CompactionTypeWorks()
    {
        BetaContentBlock value = new BetaCompactionBlock()
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaResponseToolAdditionBlock(new BetaResponseToolChangeToolReference("name")),
            ],
        };
        Assert.Equal(BetaContentBlockType.Compaction, value.Type.Value());
    }

    [Fact]
    public void FallbackTypeWorks()
    {
        BetaContentBlock value = new BetaFallbackBlock()
        {
            From = new(Messages::Model.ClaudeHaiku5_5),
            To = new(Messages::Model.ClaudeHaiku5_5),
            Trigger = new(BetaFallbackRefusalTriggerCategory.Cyber),
        };
        Assert.Equal(BetaContentBlockType.Fallback, value.Type.Value());
    }

    [Fact]
    public void McpToolListingTypeWorks()
    {
        BetaContentBlock value = new BetaMcpToolListingBlock()
        {
            McpServerName = "mcp_server_name",
            Tools =
            [
                new()
                {
                    InputSchema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Description = "description",
                },
            ],
        };
        Assert.Equal(BetaContentBlockType.McpToolListing, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaContentBlock value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text",
                  "signature": "signature",
                  "id": "id",
                  "tool_use_id": "srvtoolu_c"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaContentBlockType> expectedType = BetaContentBlockType.Text;
        string expectedSignature = "signature";
        string expectedID = "id";
        string expectedToolUseID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedSignature, value.Signature);
        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedToolUseID, value.ToolUseID);

        BetaContentBlock emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Signature);
        Assert.Null(emptyValue.ID);
        Assert.Null(emptyValue.ToolUseID);

        BetaContentBlock mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "signature": [
                    "invalid"
                  ],
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

        Assert.Null(mismatchedValue.Signature);
        Assert.Null(mismatchedValue.ID);
        Assert.Null(mismatchedValue.ToolUseID);
    }
}

public class BetaContentBlockTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaContentBlockType.Text)]
    [InlineData(BetaContentBlockType.Thinking)]
    [InlineData(BetaContentBlockType.RedactedThinking)]
    [InlineData(BetaContentBlockType.ToolUse)]
    [InlineData(BetaContentBlockType.ServerToolUse)]
    [InlineData(BetaContentBlockType.WebSearchToolResult)]
    [InlineData(BetaContentBlockType.WebFetchToolResult)]
    [InlineData(BetaContentBlockType.AdvisorToolResult)]
    [InlineData(BetaContentBlockType.CodeExecutionToolResult)]
    [InlineData(BetaContentBlockType.BashCodeExecutionToolResult)]
    [InlineData(BetaContentBlockType.TextEditorCodeExecutionToolResult)]
    [InlineData(BetaContentBlockType.ToolSearchToolResult)]
    [InlineData(BetaContentBlockType.McpToolUse)]
    [InlineData(BetaContentBlockType.McpToolResult)]
    [InlineData(BetaContentBlockType.ContainerUpload)]
    [InlineData(BetaContentBlockType.Compaction)]
    [InlineData(BetaContentBlockType.Fallback)]
    [InlineData(BetaContentBlockType.McpToolListing)]
    public void Validation_Works(BetaContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaContentBlockType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaContentBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaContentBlockType.Text)]
    [InlineData(BetaContentBlockType.Thinking)]
    [InlineData(BetaContentBlockType.RedactedThinking)]
    [InlineData(BetaContentBlockType.ToolUse)]
    [InlineData(BetaContentBlockType.ServerToolUse)]
    [InlineData(BetaContentBlockType.WebSearchToolResult)]
    [InlineData(BetaContentBlockType.WebFetchToolResult)]
    [InlineData(BetaContentBlockType.AdvisorToolResult)]
    [InlineData(BetaContentBlockType.CodeExecutionToolResult)]
    [InlineData(BetaContentBlockType.BashCodeExecutionToolResult)]
    [InlineData(BetaContentBlockType.TextEditorCodeExecutionToolResult)]
    [InlineData(BetaContentBlockType.ToolSearchToolResult)]
    [InlineData(BetaContentBlockType.McpToolUse)]
    [InlineData(BetaContentBlockType.McpToolResult)]
    [InlineData(BetaContentBlockType.ContainerUpload)]
    [InlineData(BetaContentBlockType.Compaction)]
    [InlineData(BetaContentBlockType.Fallback)]
    [InlineData(BetaContentBlockType.McpToolListing)]
    public void SerializationRoundtrip_Works(BetaContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaContentBlockType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaContentBlockType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaContentBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaContentBlockType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
