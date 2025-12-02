using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationContentBlockLocationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationContentBlockLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndBlockIndex = 0,
            StartBlockIndex = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_location\""),
        };

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "x";
        long expectedEndBlockIndex = 0;
        long expectedStartBlockIndex = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"content_block_location\""
        );

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedDocumentIndex, model.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, model.DocumentTitle);
        Assert.Equal(expectedEndBlockIndex, model.EndBlockIndex);
        Assert.Equal(expectedStartBlockIndex, model.StartBlockIndex);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
