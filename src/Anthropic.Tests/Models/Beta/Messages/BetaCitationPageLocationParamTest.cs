using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationPageLocationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationPageLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "x";
        long expectedEndPageNumber = 0;
        long expectedStartPageNumber = 1;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedDocumentIndex, model.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, model.DocumentTitle);
        Assert.Equal(expectedEndPageNumber, model.EndPageNumber);
        Assert.Equal(expectedStartPageNumber, model.StartPageNumber);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCitationPageLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocationParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCitationPageLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocationParam>(json);
        Assert.NotNull(deserialized);

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "x";
        long expectedEndPageNumber = 0;
        long expectedStartPageNumber = 1;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");

        Assert.Equal(expectedCitedText, deserialized.CitedText);
        Assert.Equal(expectedDocumentIndex, deserialized.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, deserialized.DocumentTitle);
        Assert.Equal(expectedEndPageNumber, deserialized.EndPageNumber);
        Assert.Equal(expectedStartPageNumber, deserialized.StartPageNumber);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCitationPageLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };

        model.Validate();
    }
}
