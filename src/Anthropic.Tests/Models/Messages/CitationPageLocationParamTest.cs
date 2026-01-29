using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationPageLocationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationPageLocationParam
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("page_location");

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
        var model = new CitationPageLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CitationPageLocationParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CitationPageLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CitationPageLocationParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "x";
        long expectedEndPageNumber = 0;
        long expectedStartPageNumber = 1;
        JsonElement expectedType = JsonSerializer.SerializeToElement("page_location");

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
        var model = new CitationPageLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CitationPageLocationParam
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };

        CitationPageLocationParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
