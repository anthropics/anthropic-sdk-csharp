using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class DocumentBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocumentBlockParam
        {
            Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            Type = JsonSerializer.Deserialize<JsonElement>("\"document\""),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        Source expectedSource = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"document\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        CitationsConfigParam expectedCitations = new() { Enabled = true };
        string expectedContext = "x";
        string expectedTitle = "x";

        Assert.Equal(expectedSource, model.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedTitle, model.Title);
    }
}
