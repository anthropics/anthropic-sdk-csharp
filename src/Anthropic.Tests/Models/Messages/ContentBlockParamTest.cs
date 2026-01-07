using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockParamTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        ContentBlockParam value = new(
            new TextBlockParam()
            {
                Text = "x",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations =
                [
                    new CitationCharLocationParam()
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
        ContentBlockParam value = new(
            new ImageBlockParam()
            {
                Source = new Base64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJpeg,
                },
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void DocumentValidationWorks()
    {
        ContentBlockParam value = new(
            new DocumentBlockParam()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
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
        ContentBlockParam value = new(
            new SearchResultBlockParam()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void ThinkingValidationWorks()
    {
        ContentBlockParam value = new(
            new ThinkingBlockParam() { Signature = "signature", Thinking = "thinking" }
        );
        value.Validate();
    }

    [Fact]
    public void RedactedThinkingValidationWorks()
    {
        ContentBlockParam value = new(new RedactedThinkingBlockParam("data"));
        value.Validate();
    }

    [Fact]
    public void ToolUseValidationWorks()
    {
        ContentBlockParam value = new(
            new ToolUseBlockParam()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "x",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void ToolResultValidationWorks()
    {
        ContentBlockParam value = new(
            new ToolResultBlockParam()
            {
                ToolUseID = "tool_use_id",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Content = "string",
                IsError = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        ContentBlockParam value = new(
            new ServerToolUseBlockParam()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void WebSearchToolResultValidationWorks()
    {
        ContentBlockParam value = new(
            new WebSearchToolResultBlockParam()
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
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(
            new TextBlockParam()
            {
                Text = "x",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations =
                [
                    new CitationCharLocationParam()
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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(
            new ImageBlockParam()
            {
                Source = new Base64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJpeg,
                },
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DocumentSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(
            new DocumentBlockParam()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SearchResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(
            new SearchResultBlockParam()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(
            new ThinkingBlockParam() { Signature = "signature", Thinking = "thinking" }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedactedThinkingSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(new RedactedThinkingBlockParam("data"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(
            new ToolUseBlockParam()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "x",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(
            new ToolResultBlockParam()
            {
                ToolUseID = "tool_use_id",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Content = "string",
                IsError = true,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolUseSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(
            new ServerToolUseBlockParam()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchToolResultSerializationRoundtripWorks()
    {
        ContentBlockParam value = new(
            new WebSearchToolResultBlockParam()
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
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(element);

        Assert.Equal(value, deserialized);
    }
}
