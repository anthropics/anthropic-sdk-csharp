using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockParamTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        ContentBlockParam value = new TextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new CitationCharLocationParam()
                {
                    CitedText = "The grass is green. The sky is blue.",
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
        ContentBlockParam value = new ImageBlockParam()
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        value.Validate();
    }

    [Fact]
    public void DocumentValidationWorks()
    {
        ContentBlockParam value = new DocumentBlockParam()
        {
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
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
        ContentBlockParam value = new SearchResultBlockParam()
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new CitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
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
        ContentBlockParam value = new ThinkingBlockParam()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        value.Validate();
    }

    [Fact]
    public void RedactedThinkingValidationWorks()
    {
        ContentBlockParam value = new RedactedThinkingBlockParam("data");
        value.Validate();
    }

    [Fact]
    public void ToolUseValidationWorks()
    {
        ContentBlockParam value = new ToolUseBlockParam()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };
        value.Validate();
    }

    [Fact]
    public void ToolResultValidationWorks()
    {
        ContentBlockParam value = new ToolResultBlockParam()
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
            ToolsetName = "toolset_name",
        };
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        ContentBlockParam value = new ServerToolUseBlockParam()
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchToolResultValidationWorks()
    {
        ContentBlockParam value = new WebSearchToolResultBlockParam()
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchToolResultValidationWorks()
    {
        ContentBlockParam value = new WebFetchToolResultBlockParam()
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionToolResultValidationWorks()
    {
        ContentBlockParam value = new CodeExecutionToolResultBlockParam()
        {
            Content = new CodeExecutionToolResultErrorParam(
                CodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void BashCodeExecutionToolResultValidationWorks()
    {
        ContentBlockParam value = new BashCodeExecutionToolResultBlockParam()
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultValidationWorks()
    {
        ContentBlockParam value = new TextEditorCodeExecutionToolResultBlockParam()
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void ToolSearchToolResultValidationWorks()
    {
        ContentBlockParam value = new ToolSearchToolResultBlockParam()
        {
            Content = new ToolSearchToolResultErrorParam()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void ContainerUploadValidationWorks()
    {
        ContentBlockParam value = new ContainerUploadBlockParam()
        {
            FileID = "file_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        ContentBlockParam value = new TextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new CitationCharLocationParam()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "x",
                    EndCharIndex = 0,
                    StartCharIndex = 0,
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageSerializationRoundtripWorks()
    {
        ContentBlockParam value = new ImageBlockParam()
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DocumentSerializationRoundtripWorks()
    {
        ContentBlockParam value = new DocumentBlockParam()
        {
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SearchResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new SearchResultBlockParam()
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new CitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
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
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        ContentBlockParam value = new ThinkingBlockParam()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedactedThinkingSerializationRoundtripWorks()
    {
        ContentBlockParam value = new RedactedThinkingBlockParam("data");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseSerializationRoundtripWorks()
    {
        ContentBlockParam value = new ToolUseBlockParam()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new ToolResultBlockParam()
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
            ToolsetName = "toolset_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolUseSerializationRoundtripWorks()
    {
        ContentBlockParam value = new ServerToolUseBlockParam()
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchToolResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new WebSearchToolResultBlockParam()
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchToolResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new WebFetchToolResultBlockParam()
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionToolResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new CodeExecutionToolResultBlockParam()
        {
            Content = new CodeExecutionToolResultErrorParam(
                CodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BashCodeExecutionToolResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new BashCodeExecutionToolResultBlockParam()
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new TextEditorCodeExecutionToolResultBlockParam()
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSearchToolResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new ToolSearchToolResultBlockParam()
        {
            Content = new ToolSearchToolResultErrorParam()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContainerUploadSerializationRoundtripWorks()
    {
        ContentBlockParam value = new ContainerUploadBlockParam()
        {
            FileID = "file_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextTypeWorks()
    {
        ContentBlockParam value = new TextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new CitationCharLocationParam()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "x",
                    EndCharIndex = 0,
                    StartCharIndex = 0,
                },
            ],
        };
        Assert.Equal(ContentBlockParamType.Text, value.Type.Value());
    }

    [Fact]
    public void ImageTypeWorks()
    {
        ContentBlockParam value = new ImageBlockParam()
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        Assert.Equal(ContentBlockParamType.Image, value.Type.Value());
    }

    [Fact]
    public void DocumentTypeWorks()
    {
        ContentBlockParam value = new DocumentBlockParam()
        {
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        Assert.Equal(ContentBlockParamType.Document, value.Type.Value());
    }

    [Fact]
    public void SearchResultTypeWorks()
    {
        ContentBlockParam value = new SearchResultBlockParam()
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new CitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
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
        Assert.Equal(ContentBlockParamType.SearchResult, value.Type.Value());
    }

    [Fact]
    public void ThinkingTypeWorks()
    {
        ContentBlockParam value = new ThinkingBlockParam()
        {
            Signature = "signature",
            Thinking = "thinking",
        };
        Assert.Equal(ContentBlockParamType.Thinking, value.Type.Value());
    }

    [Fact]
    public void RedactedThinkingTypeWorks()
    {
        ContentBlockParam value = new RedactedThinkingBlockParam("data");
        Assert.Equal(ContentBlockParamType.RedactedThinking, value.Type.Value());
    }

    [Fact]
    public void ToolUseTypeWorks()
    {
        ContentBlockParam value = new ToolUseBlockParam()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };
        Assert.Equal(ContentBlockParamType.ToolUse, value.Type.Value());
    }

    [Fact]
    public void ToolResultTypeWorks()
    {
        ContentBlockParam value = new ToolResultBlockParam()
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
            ToolsetName = "toolset_name",
        };
        Assert.Equal(ContentBlockParamType.ToolResult, value.Type.Value());
    }

    [Fact]
    public void ServerToolUseTypeWorks()
    {
        ContentBlockParam value = new ServerToolUseBlockParam()
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };
        Assert.Equal(ContentBlockParamType.ServerToolUse, value.Type.Value());
    }

    [Fact]
    public void WebSearchToolResultTypeWorks()
    {
        ContentBlockParam value = new WebSearchToolResultBlockParam()
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };
        Assert.Equal(ContentBlockParamType.WebSearchToolResult, value.Type.Value());
    }

    [Fact]
    public void WebFetchToolResultTypeWorks()
    {
        ContentBlockParam value = new WebFetchToolResultBlockParam()
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };
        Assert.Equal(ContentBlockParamType.WebFetchToolResult, value.Type.Value());
    }

    [Fact]
    public void CodeExecutionToolResultTypeWorks()
    {
        ContentBlockParam value = new CodeExecutionToolResultBlockParam()
        {
            Content = new CodeExecutionToolResultErrorParam(
                CodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        Assert.Equal(ContentBlockParamType.CodeExecutionToolResult, value.Type.Value());
    }

    [Fact]
    public void BashCodeExecutionToolResultTypeWorks()
    {
        ContentBlockParam value = new BashCodeExecutionToolResultBlockParam()
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        Assert.Equal(ContentBlockParamType.BashCodeExecutionToolResult, value.Type.Value());
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultTypeWorks()
    {
        ContentBlockParam value = new TextEditorCodeExecutionToolResultBlockParam()
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        Assert.Equal(ContentBlockParamType.TextEditorCodeExecutionToolResult, value.Type.Value());
    }

    [Fact]
    public void ToolSearchToolResultTypeWorks()
    {
        ContentBlockParam value = new ToolSearchToolResultBlockParam()
        {
            Content = new ToolSearchToolResultErrorParam()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        Assert.Equal(ContentBlockParamType.ToolSearchToolResult, value.Type.Value());
    }

    [Fact]
    public void ContainerUploadTypeWorks()
    {
        ContentBlockParam value = new ContainerUploadBlockParam()
        {
            FileID = "file_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        Assert.Equal(ContentBlockParamType.ContainerUpload, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ContentBlockParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text",
                  "cache_control": {
                    "type": "ephemeral",
                    "ttl": "5m"
                  },
                  "title": "x",
                  "id": "id",
                  "toolset_name": "toolset_name",
                  "tool_use_id": "tool_use_id"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ContentBlockParamType> expectedType = ContentBlockParamType.Text;
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        string expectedTitle = "x";
        string expectedID = "id";
        string expectedToolsetName = "toolset_name";
        string expectedToolUseID = "tool_use_id";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedCacheControl, value.CacheControl);
        Assert.Equal(expectedTitle, value.Title);
        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedToolsetName, value.ToolsetName);
        Assert.Equal(expectedToolUseID, value.ToolUseID);

        ContentBlockParam emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.CacheControl);
        Assert.Null(emptyValue.Title);
        Assert.Null(emptyValue.ID);
        Assert.Null(emptyValue.ToolsetName);
        Assert.Null(emptyValue.ToolUseID);

        ContentBlockParam mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_control": [
                    "invalid"
                  ],
                  "title": [
                    "invalid"
                  ],
                  "id": [
                    "invalid"
                  ],
                  "toolset_name": [
                    "invalid"
                  ],
                  "tool_use_id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.CacheControl);
        Assert.Null(mismatchedValue.Title);
        Assert.Null(mismatchedValue.ID);
        Assert.Null(mismatchedValue.ToolsetName);
        Assert.Null(mismatchedValue.ToolUseID);
    }
}

public class ContentBlockParamTypeTest : TestBase
{
    [Theory]
    [InlineData(ContentBlockParamType.Text)]
    [InlineData(ContentBlockParamType.Image)]
    [InlineData(ContentBlockParamType.Document)]
    [InlineData(ContentBlockParamType.SearchResult)]
    [InlineData(ContentBlockParamType.Thinking)]
    [InlineData(ContentBlockParamType.RedactedThinking)]
    [InlineData(ContentBlockParamType.ToolUse)]
    [InlineData(ContentBlockParamType.ToolResult)]
    [InlineData(ContentBlockParamType.ServerToolUse)]
    [InlineData(ContentBlockParamType.WebSearchToolResult)]
    [InlineData(ContentBlockParamType.WebFetchToolResult)]
    [InlineData(ContentBlockParamType.CodeExecutionToolResult)]
    [InlineData(ContentBlockParamType.BashCodeExecutionToolResult)]
    [InlineData(ContentBlockParamType.TextEditorCodeExecutionToolResult)]
    [InlineData(ContentBlockParamType.ToolSearchToolResult)]
    [InlineData(ContentBlockParamType.ContainerUpload)]
    public void Validation_Works(ContentBlockParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentBlockParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentBlockParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContentBlockParamType.Text)]
    [InlineData(ContentBlockParamType.Image)]
    [InlineData(ContentBlockParamType.Document)]
    [InlineData(ContentBlockParamType.SearchResult)]
    [InlineData(ContentBlockParamType.Thinking)]
    [InlineData(ContentBlockParamType.RedactedThinking)]
    [InlineData(ContentBlockParamType.ToolUse)]
    [InlineData(ContentBlockParamType.ToolResult)]
    [InlineData(ContentBlockParamType.ServerToolUse)]
    [InlineData(ContentBlockParamType.WebSearchToolResult)]
    [InlineData(ContentBlockParamType.WebFetchToolResult)]
    [InlineData(ContentBlockParamType.CodeExecutionToolResult)]
    [InlineData(ContentBlockParamType.BashCodeExecutionToolResult)]
    [InlineData(ContentBlockParamType.TextEditorCodeExecutionToolResult)]
    [InlineData(ContentBlockParamType.ToolSearchToolResult)]
    [InlineData(ContentBlockParamType.ContainerUpload)]
    public void SerializationRoundtrip_Works(ContentBlockParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentBlockParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentBlockParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentBlockParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentBlockParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
