using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationCharLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationCharLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndCharIndex = 0,
            FileID = "file_id",
            StartCharIndex = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\""),
        };

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "document_title";
        long expectedEndCharIndex = 0;
        string expectedFileID = "file_id";
        long expectedStartCharIndex = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedDocumentIndex, model.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, model.DocumentTitle);
        Assert.Equal(expectedEndCharIndex, model.EndCharIndex);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedStartCharIndex, model.StartCharIndex);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
