using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaDocumentBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDocumentBlock
        {
            Citations = new(true),
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
            Type = JsonSerializer.Deserialize<JsonElement>("\"document\""),
        };

        BetaCitationConfig expectedCitations = new(true);
        Source expectedSource = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz");
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"document\"");

        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
