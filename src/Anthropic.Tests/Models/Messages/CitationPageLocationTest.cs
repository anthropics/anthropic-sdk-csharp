using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationPageLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationPageLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndPageNumber = 0,
            FileID = "file_id",
            StartPageNumber = 1,
            Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\""),
        };

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "document_title";
        long expectedEndPageNumber = 0;
        string expectedFileID = "file_id";
        long expectedStartPageNumber = 1;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedDocumentIndex, model.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, model.DocumentTitle);
        Assert.Equal(expectedEndPageNumber, model.EndPageNumber);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedStartPageNumber, model.StartPageNumber);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
