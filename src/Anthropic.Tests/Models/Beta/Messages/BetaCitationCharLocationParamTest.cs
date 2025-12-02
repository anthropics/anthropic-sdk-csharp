using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationCharLocationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationCharLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndCharIndex = 0,
            StartCharIndex = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\""),
        };

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "x";
        long expectedEndCharIndex = 0;
        long expectedStartCharIndex = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedDocumentIndex, model.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, model.DocumentTitle);
        Assert.Equal(expectedEndCharIndex, model.EndCharIndex);
        Assert.Equal(expectedStartCharIndex, model.StartCharIndex);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
