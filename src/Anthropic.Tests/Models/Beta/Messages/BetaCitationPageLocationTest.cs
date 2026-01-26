using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationPageLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationPageLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndPageNumber = 0,
            FileID = "file_id",
            StartPageNumber = 1,
        };

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "document_title";
        long expectedEndPageNumber = 0;
        string expectedFileID = "file_id";
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
        var model = new BetaCitationPageLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndPageNumber = 0,
            FileID = "file_id",
            StartPageNumber = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCitationPageLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndPageNumber = 0,
            FileID = "file_id",
            StartPageNumber = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "document_title";
        long expectedEndPageNumber = 0;
        string expectedFileID = "file_id";
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
        var model = new BetaCitationPageLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndPageNumber = 0,
            FileID = "file_id",
            StartPageNumber = 1,
        };

        model.Validate();
    }
}
