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
