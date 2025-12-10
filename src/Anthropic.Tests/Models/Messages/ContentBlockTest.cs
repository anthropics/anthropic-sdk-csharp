using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockTest : TestBase
{
    [Fact]
    public void textValidation_Works()
    {
        ContentBlock value = new(
            new()
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
    public void thinkingValidation_Works()
    {
        ContentBlock value = new(new() { Signature = "signature", Thinking = "thinking" });
        value.Validate();
    }

    [Fact]
    public void redacted_thinkingValidation_Works()
    {
        ContentBlock value = new(new("data"));
        value.Validate();
    }

    [Fact]
    public void tool_useValidation_Works()
    {
        ContentBlock value = new(
            new()
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
    public void server_tool_useValidation_Works()
    {
        ContentBlock value = new(
            new()
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
    public void web_search_tool_resultValidation_Works()
    {
        ContentBlock value = new(
            new()
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
    public void textSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void thinkingSerializationRoundtrip_Works()
    {
        ContentBlock value = new(new() { Signature = "signature", Thinking = "thinking" });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void redacted_thinkingSerializationRoundtrip_Works()
    {
        ContentBlock value = new(new("data"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_useSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "x",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void server_tool_useSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void web_search_tool_resultSerializationRoundtrip_Works()
    {
        ContentBlock value = new(
            new()
            {
                Content = new WebSearchToolResultError(
                    WebSearchToolResultErrorErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlock>(json);

        Assert.Equal(value, deserialized);
    }
}
