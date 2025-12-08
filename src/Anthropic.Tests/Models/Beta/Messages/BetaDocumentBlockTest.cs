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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDocumentBlock
        {
            Citations = new(true),
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaDocumentBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDocumentBlock
        {
            Citations = new(true),
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaDocumentBlock>(json);
        Assert.NotNull(deserialized);

        BetaCitationConfig expectedCitations = new(true);
        Source expectedSource = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz");
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"document\"");

        Assert.Equal(expectedCitations, deserialized.Citations);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDocumentBlock
        {
            Citations = new(true),
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        model.Validate();
    }
}
