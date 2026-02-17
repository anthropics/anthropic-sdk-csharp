using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContentBlockParamTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        BetaContentBlockParam value = new BetaTextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
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
        };
        value.Validate();
    }

    [Fact]
    public void ImageValidationWorks()
    {
        BetaContentBlockParam value = new BetaImageBlockParam()
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void RequestDocumentBlockValidationWorks()
    {
        BetaContentBlockParam value = new BetaRequestDocumentBlock()
        {
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        value.Validate();
    }

    [Fact]
    public void SearchResultValidationWorks()
    {
        BetaContentBlockParam value = new BetaSearchResultBlockParam()
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
        };
        value.Validate();
    }

    [Fact]
    public void ThinkingValidationWorks()
    {
        BetaContentBlockParam value = new BetaThinkingBlockParam()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        value.Validate();
    }

    [Fact]
    public void RedactedThinkingValidationWorks()
    {
        BetaContentBlockParam value = new BetaRedactedThinkingBlockParam("data");
        value.Validate();
    }

    [Fact]
    public void ToolUseValidationWorks()
    {
        BetaContentBlockParam value = new BetaToolUseBlockParam()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ToolResultValidationWorks()
    {
        BetaContentBlockParam value = new BetaToolResultBlockParam()
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
        };
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        BetaContentBlockParam value = new BetaServerToolUseBlockParam()
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchToolResultValidationWorks()
    {
        BetaContentBlockParam value = new BetaWebSearchToolResultBlockParam()
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchToolResultValidationWorks()
    {
        BetaContentBlockParam value = new BetaWebFetchToolResultBlockParam()
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionToolResultValidationWorks()
    {
        BetaContentBlockParam value = new BetaCodeExecutionToolResultBlockParam()
        {
            Content = new BetaCodeExecutionToolResultErrorParam(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void BashCodeExecutionToolResultValidationWorks()
    {
        BetaContentBlockParam value = new BetaBashCodeExecutionToolResultBlockParam()
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultValidationWorks()
    {
        BetaContentBlockParam value = new BetaTextEditorCodeExecutionToolResultBlockParam()
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void ToolSearchToolResultValidationWorks()
    {
        BetaContentBlockParam value = new BetaToolSearchToolResultBlockParam()
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void McpToolUseValidationWorks()
    {
        BetaContentBlockParam value = new BetaMcpToolUseBlockParam()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void RequestMcpToolResultValidationWorks()
    {
        BetaContentBlockParam value = new BetaRequestMcpToolResultBlockParam()
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
        };
        value.Validate();
    }

    [Fact]
    public void ContainerUploadValidationWorks()
    {
        BetaContentBlockParam value = new BetaContainerUploadBlockParam()
        {
            FileID = "file_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void CompactionValidationWorks()
    {
        BetaContentBlockParam value = new BetaCompactionBlockParam()
        {
            Content = "content",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaTextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaImageBlockParam()
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RequestDocumentBlockSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaRequestDocumentBlock()
        {
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SearchResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaSearchResultBlockParam()
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaThinkingBlockParam()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedactedThinkingSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaRedactedThinkingBlockParam("data");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaToolUseBlockParam()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaToolResultBlockParam()
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolUseSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaServerToolUseBlockParam()
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaWebSearchToolResultBlockParam()
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaWebFetchToolResultBlockParam()
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionToolResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaCodeExecutionToolResultBlockParam()
        {
            Content = new BetaCodeExecutionToolResultErrorParam(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BashCodeExecutionToolResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaBashCodeExecutionToolResultBlockParam()
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaTextEditorCodeExecutionToolResultBlockParam()
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSearchToolResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaToolSearchToolResultBlockParam()
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpToolUseSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaMcpToolUseBlockParam()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RequestMcpToolResultSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaRequestMcpToolResultBlockParam()
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContainerUploadSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaContainerUploadBlockParam()
        {
            FileID = "file_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionSerializationRoundtripWorks()
    {
        BetaContentBlockParam value = new BetaCompactionBlockParam()
        {
            Content = "content",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
