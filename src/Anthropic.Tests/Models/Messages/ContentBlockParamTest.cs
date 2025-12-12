using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockParamTest : TestBase
{
    [Fact]
    public void textValidation_Works()
    {
        ContentBlockParam value = new(
            new TextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
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
    public void imageValidation_Works()
    {
        ContentBlockParam value = new(
            new ImageBlockParam()
            {
                Source = new Base64ImageSource()
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
    public void documentValidation_Works()
    {
        ContentBlockParam value = new(
            new DocumentBlockParam()
            {
                Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
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
        ContentBlockParam value = new(
            new SearchResultBlockParam()
            {
                Content =
                [
                    new()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
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
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
            }
        );
        value.Validate();
    }

    [Fact]
    public void thinkingValidation_Works()
    {
        ContentBlockParam value = new(
            new ThinkingBlockParam() { Signature = "signature", Thinking = "thinking" }
        );
        value.Validate();
    }

    [Fact]
    public void redacted_thinkingValidation_Works()
    {
        ContentBlockParam value = new(new RedactedThinkingBlockParam("data"));
        value.Validate();
    }

    [Fact]
    public void tool_useValidation_Works()
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
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void tool_resultValidation_Works()
    {
        ContentBlockParam value = new(
            new ToolResultBlockParam()
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
        ContentBlockParam value = new(
            new ServerToolUseBlockParam()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void web_search_tool_resultValidation_Works()
    {
        ContentBlockParam value = new(
            new WebSearchToolResultBlockParam()
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
    public void textSerializationRoundtrip_Works()
    {
        ContentBlockParam value = new(
            new TextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void imageSerializationRoundtrip_Works()
    {
        ContentBlockParam value = new(
            new ImageBlockParam()
            {
                Source = new Base64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJPEG,
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void documentSerializationRoundtrip_Works()
    {
        ContentBlockParam value = new(
            new DocumentBlockParam()
            {
                Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void search_resultSerializationRoundtrip_Works()
    {
        ContentBlockParam value = new(
            new SearchResultBlockParam()
            {
                Content =
                [
                    new()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
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
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void thinkingSerializationRoundtrip_Works()
    {
        ContentBlockParam value = new(
            new ThinkingBlockParam() { Signature = "signature", Thinking = "thinking" }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void redacted_thinkingSerializationRoundtrip_Works()
    {
        ContentBlockParam value = new(new RedactedThinkingBlockParam("data"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_useSerializationRoundtrip_Works()
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
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_resultSerializationRoundtrip_Works()
    {
        ContentBlockParam value = new(
            new ToolResultBlockParam()
            {
                ToolUseID = "tool_use_id",
                CacheControl = new() { TTL = TTL.TTL5m },
                Content = "string",
                IsError = true,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void server_tool_useSerializationRoundtrip_Works()
    {
        ContentBlockParam value = new(
            new ServerToolUseBlockParam()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void web_search_tool_resultSerializationRoundtrip_Works()
    {
        ContentBlockParam value = new(
            new WebSearchToolResultBlockParam()
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
        var deserialized = JsonSerializer.Deserialize<ContentBlockParam>(json);

        Assert.Equal(value, deserialized);
    }
}
