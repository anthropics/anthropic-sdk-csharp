using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchBlockParam
        {
            Content = new()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\""),
            URL = "url",
            RetrievedAt = "retrieved_at",
        };

        BetaRequestDocumentBlock expectedContent = new()
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"");
        string expectedURL = "url";
        string expectedRetrievedAt = "retrieved_at";

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedRetrievedAt, model.RetrievedAt);
    }
}
