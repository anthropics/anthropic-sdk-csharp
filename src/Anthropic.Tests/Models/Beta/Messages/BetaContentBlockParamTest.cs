using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContentBlockParamTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
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
    public void ImageValidationWorks()
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
    public void RequestDocumentBlockValidationWorks()
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
    public void SearchResultValidationWorks()
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
    public void ThinkingValidationWorks()
    {
        BetaContentBlockParam value = new(
            new BetaThinkingBlockParam() { Signature = "signature", Thinking = "thinking" }
        );
        value.Validate();
    }

    [Fact]
    public void RedactedThinkingValidationWorks()
    {
        BetaContentBlockParam value = new(new BetaRedactedThinkingBlockParam("data"));
        value.Validate();
    }

    [Fact]
    public void ToolUseValidationWorks()
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
    public void ToolResultValidationWorks()
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
    public void ServerToolUseValidationWorks()
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
    public void WebSearchToolResultValidationWorks()
    {
        BetaContentBlockParam value = new(
            new BetaWebSearchToolResultBlockParam()
            {
                Content = new(
                    [
                        new BetaWebSearchResultBlockParam()
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
    public void WebFetchToolResultValidationWorks()
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
    public void CodeExecutionToolResultValidationWorks()
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
    public void BashCodeExecutionToolResultValidationWorks()
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
    public void TextEditorCodeExecutionToolResultValidationWorks()
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
    public void ToolSearchToolResultValidationWorks()
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
    public void MCPToolUseValidationWorks()
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
    public void RequestMCPToolResultValidationWorks()
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
    public void ContainerUploadValidationWorks()
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
    public void TextSerializationRoundtripWorks()
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
    public void ImageSerializationRoundtripWorks()
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
    public void RequestDocumentBlockSerializationRoundtripWorks()
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
    public void SearchResultSerializationRoundtripWorks()
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
    public void ThinkingSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new(
            new BetaThinkingBlockParam() { Signature = "signature", Thinking = "thinking" }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedactedThinkingSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new(new BetaRedactedThinkingBlockParam("data"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseSerializationRoundtripWorks()
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
    public void ToolResultSerializationRoundtripWorks()
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
    public void ServerToolUseSerializationRoundtripWorks()
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
    public void WebSearchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new(
            new BetaWebSearchToolResultBlockParam()
            {
                Content = new(
                    [
                        new BetaWebSearchResultBlockParam()
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
    public void WebFetchToolResultSerializationRoundtripWorks()
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
    public void CodeExecutionToolResultSerializationRoundtripWorks()
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
    public void BashCodeExecutionToolResultSerializationRoundtripWorks()
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
    public void TextEditorCodeExecutionToolResultSerializationRoundtripWorks()
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
    public void ToolSearchToolResultSerializationRoundtripWorks()
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
    public void MCPToolUseSerializationRoundtripWorks()
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
    public void RequestMCPToolResultSerializationRoundtripWorks()
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
    public void ContainerUploadSerializationRoundtripWorks()
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
