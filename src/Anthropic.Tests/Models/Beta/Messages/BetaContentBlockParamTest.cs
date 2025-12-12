using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContentBlockParamTest : TestBase
{
    [Fact]
    public void textValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaTextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations =
                [
                    new BetaCitationCharLocationParam()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "x",
                        EndCharIndex = 0,
                        StartCharIndex = 0,
                    },
                ],
            }
        );
        value.Validate();
    }

    [Fact]
    public void imageValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaImageBlockParam()
            {
                Source = new BetaBase64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJPEG,
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void request_document_blockValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaRequestDocumentBlock()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            }
        );
        value.Validate();
    }

    [Fact]
    public void search_resultValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaSearchResultBlockParam()
            {
                Content =
                [
                    new()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
                        Citations =
                        [
                            new BetaCitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ],
                Source = "source",
                Title = "title",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
            }
        );
        value.Validate();
    }

    [Fact]
    public void thinkingValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaThinkingBlockParam() { Signature = "signature", Thinking = "thinking" }
        );
        value.Validate();
    }

    [Fact]
    public void redacted_thinkingValidation_Works()
    {
        BetaContentBlockParam value = new(new BetaRedactedThinkingBlockParam("data"));
        value.Validate();
    }

    [Fact]
    public void tool_useValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaToolUseBlockParam()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Caller = new BetaDirectCaller(),
            }
        );
        value.Validate();
    }

    [Fact]
    public void tool_resultValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaToolResultBlockParam()
            {
                ToolUseID = "tool_use_id",
                CacheControl = new() { TTL = TTL.TTL5m },
                Content = "string",
                IsError = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void server_tool_useValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaServerToolUseBlockParam()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = BetaServerToolUseBlockParamName.WebSearch,
                CacheControl = new() { TTL = TTL.TTL5m },
                Caller = new BetaDirectCaller(),
            }
        );
        value.Validate();
    }

    [Fact]
    public void web_search_tool_resultValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaWebSearchToolResultBlockParam()
            {
                Content = new(
                    [
                        new()
                        {
                            EncryptedContent = "encrypted_content",
                            Title = "title",
                            URL = "url",
                            PageAge = "page_age",
                        },
                    ]
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void web_fetch_tool_resultValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaWebFetchToolResultBlockParam()
            {
                Content = new BetaWebFetchToolResultErrorBlockParam(
                    BetaWebFetchToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void code_execution_tool_resultValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaCodeExecutionToolResultBlockParam()
            {
                Content = new BetaCodeExecutionToolResultErrorParam(
                    BetaCodeExecutionToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void bash_code_execution_tool_resultValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaBashCodeExecutionToolResultBlockParam()
            {
                Content = new BetaBashCodeExecutionToolResultErrorParam(
                    BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void text_editor_code_execution_tool_resultValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaTextEditorCodeExecutionToolResultBlockParam()
            {
                Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
                {
                    ErrorCode =
                        BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                    ErrorMessage = "error_message",
                },
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void tool_search_tool_resultValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaToolSearchToolResultBlockParam()
            {
                Content = new BetaToolSearchToolResultErrorParam(
                    BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void mcp_tool_useValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaMCPToolUseBlockParam()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                ServerName = "server_name",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void request_mcp_tool_resultValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaRequestMCPToolResultBlockParam()
            {
                ToolUseID = "tool_use_id",
                CacheControl = new() { TTL = TTL.TTL5m },
                Content = "string",
                IsError = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void container_uploadValidation_Works()
    {
        BetaContentBlockParam value = new(
            new BetaContainerUploadBlockParam()
            {
                FileID = "file_id",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void textSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaTextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations =
                [
                    new BetaCitationCharLocationParam()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "x",
                        EndCharIndex = 0,
                        StartCharIndex = 0,
                    },
                ],
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void imageSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaImageBlockParam()
            {
                Source = new BetaBase64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJPEG,
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void request_document_blockSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaRequestDocumentBlock()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void search_resultSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaSearchResultBlockParam()
            {
                Content =
                [
                    new()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
                        Citations =
                        [
                            new BetaCitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ],
                Source = "source",
                Title = "title",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void thinkingSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaThinkingBlockParam() { Signature = "signature", Thinking = "thinking" }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void redacted_thinkingSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(new BetaRedactedThinkingBlockParam("data"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_useSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaToolUseBlockParam()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Caller = new BetaDirectCaller(),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaToolResultBlockParam()
            {
                ToolUseID = "tool_use_id",
                CacheControl = new() { TTL = TTL.TTL5m },
                Content = "string",
                IsError = true,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void server_tool_useSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaServerToolUseBlockParam()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = BetaServerToolUseBlockParamName.WebSearch,
                CacheControl = new() { TTL = TTL.TTL5m },
                Caller = new BetaDirectCaller(),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void web_search_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaWebSearchToolResultBlockParam()
            {
                Content = new(
                    [
                        new()
                        {
                            EncryptedContent = "encrypted_content",
                            Title = "title",
                            URL = "url",
                            PageAge = "page_age",
                        },
                    ]
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void web_fetch_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaWebFetchToolResultBlockParam()
            {
                Content = new BetaWebFetchToolResultErrorBlockParam(
                    BetaWebFetchToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void code_execution_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaCodeExecutionToolResultBlockParam()
            {
                Content = new BetaCodeExecutionToolResultErrorParam(
                    BetaCodeExecutionToolResultErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void bash_code_execution_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaBashCodeExecutionToolResultBlockParam()
            {
                Content = new BetaBashCodeExecutionToolResultErrorParam(
                    BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void text_editor_code_execution_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaTextEditorCodeExecutionToolResultBlockParam()
            {
                Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
                {
                    ErrorCode =
                        BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                    ErrorMessage = "error_message",
                },
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_search_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaToolSearchToolResultBlockParam()
            {
                Content = new BetaToolSearchToolResultErrorParam(
                    BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void mcp_tool_useSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaMCPToolUseBlockParam()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                ServerName = "server_name",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void request_mcp_tool_resultSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaRequestMCPToolResultBlockParam()
            {
                ToolUseID = "tool_use_id",
                CacheControl = new() { TTL = TTL.TTL5m },
                Content = "string",
                IsError = true,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void container_uploadSerializationRoundtrip_Works()
    {
        BetaContentBlockParam value = new(
            new BetaContainerUploadBlockParam()
            {
                FileID = "file_id",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }
}
