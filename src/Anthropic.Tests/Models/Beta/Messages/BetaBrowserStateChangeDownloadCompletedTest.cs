using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserStateChangeDownloadCompletedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserStateChangeDownloadCompleted
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };

        string expectedDownloadID = "download_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("download_completed");
        string expectedUrl = "url";
        string expectedPath = "path";
        long expectedSizeBytes = 0;

        Assert.Equal(expectedDownloadID, model.DownloadID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserStateChangeDownloadCompleted
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateChangeDownloadCompleted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserStateChangeDownloadCompleted
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateChangeDownloadCompleted>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDownloadID = "download_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("download_completed");
        string expectedUrl = "url";
        string expectedPath = "path";
        long expectedSizeBytes = 0;

        Assert.Equal(expectedDownloadID, deserialized.DownloadID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserStateChangeDownloadCompleted
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserStateChangeDownloadCompleted
        {
            DownloadID = "download_id",
            Url = "url",
        };

        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("size_bytes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserStateChangeDownloadCompleted
        {
            DownloadID = "download_id",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserStateChangeDownloadCompleted
        {
            DownloadID = "download_id",
            Url = "url",

            Path = null,
            SizeBytes = null,
        };

        Assert.Null(model.Path);
        Assert.True(model.RawData.ContainsKey("path"));
        Assert.Null(model.SizeBytes);
        Assert.True(model.RawData.ContainsKey("size_bytes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserStateChangeDownloadCompleted
        {
            DownloadID = "download_id",
            Url = "url",

            Path = null,
            SizeBytes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserStateChangeDownloadCompleted
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };

        BetaBrowserStateChangeDownloadCompleted copied = new(model);

        Assert.Equal(model, copied);
    }
}
