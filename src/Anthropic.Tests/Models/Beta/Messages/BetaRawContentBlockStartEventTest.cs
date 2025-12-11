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
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"content_block_start\""
        );

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStartEvent>(json);
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
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"content_block_start\""
        );

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
    public void beta_textValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_thinkingValidation_Works()
    {
        ContentBlock value = new(
            new BetaThinkingBlock() { Signature = "signature", Thinking = "thinking" }
        );
        value.Validate();
    }

    [Fact]
    public void beta_redacted_thinkingValidation_Works()
    {
        ContentBlock value = new(new BetaRedactedThinkingBlock("data"));
        value.Validate();
    }

    [Fact]
    public void beta_tool_useValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_server_tool_useValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_web_search_tool_resultValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_web_fetch_tool_resultValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_code_execution_tool_resultValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_bash_code_execution_tool_resultValidation_Works()
    {
        ContentBlock value = new(
            new BetaBashCodeExecutionToolResultBlock()
            {
                Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        value.Validate();
    }

    [Fact]
    public void beta_text_editor_code_execution_tool_resultValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_tool_search_tool_resultValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_mcp_tool_useValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_mcp_tool_resultValidation_Works()
    {
        ContentBlock value = new(
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
    public void beta_container_uploadValidation_Works()
    {
        ContentBlock value = new(new BetaContainerUploadBlock("file_id"));
        value.Validate();
    }

    [Fact]
    public void beta_textSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
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
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_thinkingSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new BetaThinkingBlock() { Signature = "signature", Thinking = "thinking" }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_redacted_thinkingSerializationRoundtrip_Works()
    {
        ContentBlock value = new(new BetaRedactedThinkingBlock("data"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_tool_useSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
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
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_server_tool_useSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
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
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_web_search_tool_resultSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new BetaWebSearchToolResultBlock()
            {
                Content = new BetaWebSearchToolResultError(
                    BetaWebSearchToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_web_fetch_tool_resultSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new BetaWebFetchToolResultBlock()
            {
                Content = new BetaWebFetchToolResultErrorBlock(
                    BetaWebFetchToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_code_execution_tool_resultSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new BetaCodeExecutionToolResultBlock()
            {
                Content = new BetaCodeExecutionToolResultError(
                    BetaCodeExecutionToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_bash_code_execution_tool_resultSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new BetaBashCodeExecutionToolResultBlock()
            {
                Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_text_editor_code_execution_tool_resultSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
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
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_tool_search_tool_resultSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
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
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_mcp_tool_useSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
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
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_mcp_tool_resultSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new BetaMCPToolResultBlock()
            {
                Content = "string",
                IsError = true,
                ToolUseID = "tool_use_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_container_uploadSerializationRoundtrip_Works()
    {
        ContentBlock value = new(new BetaContainerUploadBlock("file_id"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }
}
