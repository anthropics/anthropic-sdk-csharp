using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        ContentBlock value = new(
            new TextBlock()
            {
                Citations =
                [
                    new CitationCharLocation()
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
    public void ThinkingValidationWorks()
    {
        ContentBlock value = new(
            new ThinkingBlock() { Signature = "signature", Thinking = "thinking" }
        );
        value.Validate();
    }

    [Fact]
    public void RedactedThinkingValidationWorks()
    {
        ContentBlock value = new(new RedactedThinkingBlock("data"));
        value.Validate();
    }

    [Fact]
    public void ToolUseValidationWorks()
    {
        ContentBlock value = new(
            new ToolUseBlock()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "x",
            }
        );
        value.Validate();
    }

    [Fact]
    public void ServerToolUseValidationWorks()
    {
        ContentBlock value = new(
            new ServerToolUseBlock()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void WebSearchToolResultValidationWorks()
    {
        ContentBlock value = new(
            new WebSearchToolResultBlock()
            {
                Content = new WebSearchToolResultError(
                    WebSearchToolResultErrorErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        ContentBlock value = new(
            new TextBlock()
            {
                Citations =
                [
                    new CitationCharLocation()
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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        ContentBlock value = new(
            new ThinkingBlock() { Signature = "signature", Thinking = "thinking" }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedactedThinkingSerializationRoundtripWorks()
    {
        ContentBlock value = new(new RedactedThinkingBlock("data"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseSerializationRoundtripWorks()
    {
        ContentBlock value = new(
            new ToolUseBlock()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "x",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolUseSerializationRoundtripWorks()
    {
        ContentBlock value = new(
            new ServerToolUseBlock()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchToolResultSerializationRoundtripWorks()
    {
        ContentBlock value = new(
            new WebSearchToolResultBlock()
            {
                Content = new WebSearchToolResultError(
                    WebSearchToolResultErrorErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(element);

        Assert.Equal(value, deserialized);
    }
}
