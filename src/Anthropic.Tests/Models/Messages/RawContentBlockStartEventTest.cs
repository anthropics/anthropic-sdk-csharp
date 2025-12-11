using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawContentBlockStartEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RawContentBlockStartEvent
        {
            ContentBlock = new TextBlock()
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
            },
            Index = 0,
        };

        RawContentBlockStartEventContentBlock expectedContentBlock = new TextBlock()
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
        var model = new RawContentBlockStartEvent
        {
            ContentBlock = new TextBlock()
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
            },
            Index = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEvent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RawContentBlockStartEvent
        {
            ContentBlock = new TextBlock()
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
            },
            Index = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEvent>(json);
        Assert.NotNull(deserialized);

        RawContentBlockStartEventContentBlock expectedContentBlock = new TextBlock()
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
        var model = new RawContentBlockStartEvent
        {
            ContentBlock = new TextBlock()
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
            },
            Index = 0,
        };

        model.Validate();
    }
}

public class RawContentBlockStartEventContentBlockTest : TestBase
{
    [Fact]
    public void textValidation_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
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
    public void thinkingValidation_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
            new ThinkingBlock() { Signature = "signature", Thinking = "thinking" }
        );
        value.Validate();
    }

    [Fact]
    public void redacted_thinkingValidation_Works()
    {
        RawContentBlockStartEventContentBlock value = new(new RedactedThinkingBlock("data"));
        value.Validate();
    }

    [Fact]
    public void tool_useValidation_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
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
    public void server_tool_useValidation_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
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
    public void web_search_tool_resultValidation_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
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
    public void textSerializationRoundtrip_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void thinkingSerializationRoundtrip_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
            new ThinkingBlock() { Signature = "signature", Thinking = "thinking" }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void redacted_thinkingSerializationRoundtrip_Works()
    {
        RawContentBlockStartEventContentBlock value = new(new RedactedThinkingBlock("data"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_useSerializationRoundtrip_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void server_tool_useSerializationRoundtrip_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
            new ServerToolUseBlock()
            {
                ID = "srvtoolu_SQfNkl1n_JR_",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void web_search_tool_resultSerializationRoundtrip_Works()
    {
        RawContentBlockStartEventContentBlock value = new(
            new WebSearchToolResultBlock()
            {
                Content = new WebSearchToolResultError(
                    WebSearchToolResultErrorErrorCode.InvalidToolInput
                ),
                ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEventContentBlock>(json);

        Assert.Equal(value, deserialized);
    }
}
