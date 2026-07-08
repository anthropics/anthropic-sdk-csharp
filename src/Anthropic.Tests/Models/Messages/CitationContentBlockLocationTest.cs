using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationContentBlockLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationContentBlockLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };

        string expectedCitedText = "The grass is green. The sky is blue.";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "My Document";
        long expectedEndBlockIndex = 0;
        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
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
        var model = new CitationContentBlockLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CitationContentBlockLocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CitationContentBlockLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CitationContentBlockLocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCitedText = "The grass is green. The sky is blue.";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "My Document";
        long expectedEndBlockIndex = 0;
        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
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
        var model = new CitationContentBlockLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CitationContentBlockLocation
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };

        CitationContentBlockLocation copied = new(model);

        Assert.Equal(model, copied);
    }
}
