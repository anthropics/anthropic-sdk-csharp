using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationContentBlockLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationContentBlockLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndBlockIndex = 0,
            FileID = "file_id",
            StartBlockIndex = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_location\""),
        };

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "document_title";
        long expectedEndBlockIndex = 0;
        string expectedFileID = "file_id";
        long expectedStartBlockIndex = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"content_block_location\""
        );

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedDocumentIndex, model.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, model.DocumentTitle);
        Assert.Equal(expectedEndBlockIndex, model.EndBlockIndex);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedStartBlockIndex, model.StartBlockIndex);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
