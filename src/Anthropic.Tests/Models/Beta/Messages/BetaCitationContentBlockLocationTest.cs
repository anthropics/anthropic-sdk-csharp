using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationContentBlockLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationContentBlockLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndBlockIndex = 0,
            FileID = "file_id",
            StartBlockIndex = 0,
        };

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "document_title";
        long expectedEndBlockIndex = 0;
        string expectedFileID = "file_id";
        long expectedStartBlockIndex = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_block_location");

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedDocumentIndex, model.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, model.DocumentTitle);
        Assert.Equal(expectedEndBlockIndex, model.EndBlockIndex);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedStartBlockIndex, model.StartBlockIndex);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCitationContentBlockLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndBlockIndex = 0,
            FileID = "file_id",
            StartBlockIndex = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCitationContentBlockLocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCitationContentBlockLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndBlockIndex = 0,
            FileID = "file_id",
            StartBlockIndex = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCitationContentBlockLocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCitedText = "cited_text";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "document_title";
        long expectedEndBlockIndex = 0;
        string expectedFileID = "file_id";
        long expectedStartBlockIndex = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_block_location");

        Assert.Equal(expectedCitedText, deserialized.CitedText);
        Assert.Equal(expectedDocumentIndex, deserialized.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, deserialized.DocumentTitle);
        Assert.Equal(expectedEndBlockIndex, deserialized.EndBlockIndex);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedStartBlockIndex, deserialized.StartBlockIndex);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCitationContentBlockLocation
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndBlockIndex = 0,
            FileID = "file_id",
            StartBlockIndex = 0,
        };

        model.Validate();
    }
}
