using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationPageLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationPageLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };

        string expectedCitedText = "The grass is green. The sky is blue.";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "My Document";
        long expectedEndPageNumber = 0;
        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        long expectedStartPageNumber = 1;
        JsonElement expectedType = JsonSerializer.SerializeToElement("page_location");

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedDocumentIndex, model.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, model.DocumentTitle);
        Assert.Equal(expectedEndPageNumber, model.EndPageNumber);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedStartPageNumber, model.StartPageNumber);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CitationPageLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CitationPageLocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CitationPageLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CitationPageLocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCitedText = "The grass is green. The sky is blue.";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "My Document";
        long expectedEndPageNumber = 0;
        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        long expectedStartPageNumber = 1;
        JsonElement expectedType = JsonSerializer.SerializeToElement("page_location");

        Assert.Equal(expectedCitedText, deserialized.CitedText);
        Assert.Equal(expectedDocumentIndex, deserialized.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, deserialized.DocumentTitle);
        Assert.Equal(expectedEndPageNumber, deserialized.EndPageNumber);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedStartPageNumber, deserialized.StartPageNumber);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CitationPageLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CitationPageLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };

        CitationPageLocation copied = new(model);

        Assert.Equal(model, copied);
    }
}
