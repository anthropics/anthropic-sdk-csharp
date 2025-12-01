using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchBlock
        {
            Content = new()
            {
                Citations = new(true),
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\""),
            URL = "url",
        };

        BetaDocumentBlock expectedContent = new()
        {
            Citations = new(true),
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };
        string expectedRetrievedAt = "retrieved_at";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"");
        string expectedURL = "url";

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRetrievedAt, model.RetrievedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
    }
}
