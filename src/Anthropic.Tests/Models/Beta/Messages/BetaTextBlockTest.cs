using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextBlock
        {
            Citations =
            [
                new BetaCitationCharLocation()
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

        List<BetaTextCitation> expectedCitations =
        [
            new BetaCitationCharLocation()
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
        var model = new BetaTextBlock
        {
            Citations =
            [
                new BetaCitationCharLocation()
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
        var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextBlock
        {
            Citations =
            [
                new BetaCitationCharLocation()
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
        var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(json);
        Assert.NotNull(deserialized);

        List<BetaTextCitation> expectedCitations =
        [
            new BetaCitationCharLocation()
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
        var model = new BetaTextBlock
        {
            Citations =
            [
                new BetaCitationCharLocation()
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
