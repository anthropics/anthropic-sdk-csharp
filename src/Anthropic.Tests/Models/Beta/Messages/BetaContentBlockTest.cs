using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContentBlockTest : TestBase
{
    [Fact]
    public void textValidation_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void thinkingValidation_Works()
    {
        BetaContentBlock value = new(new() { Signature = "signature", Thinking = "thinking" });
        value.Validate();
    }

    [Fact]
    public void redacted_thinkingValidation_Works()
    {
        BetaContentBlock value = new(new("data"));
        value.Validate();
    }

    [Fact]
    public void tool_useValidation_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void server_tool_useValidation_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void web_search_tool_resultValidation_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void web_fetch_tool_resultValidation_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void code_execution_tool_resultValidation_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void bash_code_execution_tool_resultValidation_Works()
    {
        BetaContentBlock value = new(
            new()
            {
                Content = new BetaBashCodeExecutionToolResultError(ErrorCode.InvalidToolInput),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        value.Validate();
    }

    [Fact]
    public void text_editor_code_execution_tool_resultValidation_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void tool_search_tool_resultValidation_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void mcp_tool_useValidation_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void mcp_tool_resultValidation_Works()
    {
        BetaContentBlock value = new(
            new()
            {
                Content = "string",
                IsError = true,
                ToolUseID = "tool_use_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void container_uploadValidation_Works()
    {
        BetaContentBlock value = new(new("file_id"));
        value.Validate();
    }

    [Fact]
    public void textSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void thinkingSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(new() { Signature = "signature", Thinking = "thinking" });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void redacted_thinkingSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(new("data"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_useSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void server_tool_useSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void web_search_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void web_fetch_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void code_execution_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void bash_code_execution_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void text_editor_code_execution_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void tool_search_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void mcp_tool_useSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void mcp_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(
            new()
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
    public void container_uploadSerializationRoundtrip_Works()
    {
        BetaContentBlock value = new(new("file_id"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlock>(json);

        Assert.Equal(value, deserialized);
    }
}
