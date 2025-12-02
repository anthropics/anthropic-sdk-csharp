using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationsDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationsDelta
        {
            Citation = new BetaCitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
            Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\""),
        };

        Citation expectedCitation = new BetaCitationCharLocation()
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
}
