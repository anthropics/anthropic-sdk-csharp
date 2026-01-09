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

    [Fact]
    public void SerializationRoundtrip_Works()
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
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
            URL = "url",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlock>(element);
        Assert.NotNull(deserialized);

        BetaDocumentBlock expectedContent = new()
        {
            Citations = new(true),
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };
        string expectedRetrievedAt = "retrieved_at";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"");
        string expectedURL = "url";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRetrievedAt, deserialized.RetrievedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
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
            URL = "url",
        };

        model.Validate();
    }
}
