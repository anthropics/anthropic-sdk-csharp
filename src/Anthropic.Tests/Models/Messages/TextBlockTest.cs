using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextBlock
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

        List<TextCitation> expectedCitations =
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
        ];
        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"text\"");

        Assert.NotNull(model.Citations);
        Assert.Equal(expectedCitations.Count, model.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], model.Citations[i]);
        }
        Assert.Equal(expectedText, model.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TextBlock
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TextBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextBlock
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TextBlock>(element);
        Assert.NotNull(deserialized);

        List<TextCitation> expectedCitations =
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
        ];
        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"text\"");

        Assert.NotNull(deserialized.Citations);
        Assert.Equal(expectedCitations.Count, deserialized.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], deserialized.Citations[i]);
        }
        Assert.Equal(expectedText, deserialized.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TextBlock
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

        model.Validate();
    }
}
