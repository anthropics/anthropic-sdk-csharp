using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationsDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationsDelta
        {
            Citation = new CitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        Citation expectedCitation = new CitationCharLocation()
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndCharIndex = 0,
            FileID = "file_id",
            StartCharIndex = 0,
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");

        Assert.Equal(expectedCitation, model.Citation);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CitationsDelta
        {
            Citation = new CitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CitationsDelta>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CitationsDelta
        {
            Citation = new CitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CitationsDelta>(json);
        Assert.NotNull(deserialized);

        Citation expectedCitation = new CitationCharLocation()
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndCharIndex = 0,
            FileID = "file_id",
            StartCharIndex = 0,
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");

        Assert.Equal(expectedCitation, deserialized.Citation);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CitationsDelta
        {
            Citation = new CitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        model.Validate();
    }
}
