using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserStateChangeDownloadFailedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserStateChangeDownloadFailed
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };

        string expectedDownloadID = "download_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("download_failed");
        string expectedUrl = "url";
        string expectedError = "error";

        Assert.Equal(expectedDownloadID, model.DownloadID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserStateChangeDownloadFailed
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateChangeDownloadFailed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserStateChangeDownloadFailed
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateChangeDownloadFailed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDownloadID = "download_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("download_failed");
        string expectedUrl = "url";
        string expectedError = "error";

        Assert.Equal(expectedDownloadID, deserialized.DownloadID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserStateChangeDownloadFailed
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowserStateChangeDownloadFailed
        {
            DownloadID = "download_id",
            Url = "url",
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowserStateChangeDownloadFailed
        {
            DownloadID = "download_id",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrowserStateChangeDownloadFailed
        {
            DownloadID = "download_id",
            Url = "url",

            Error = null,
        };

        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowserStateChangeDownloadFailed
        {
            DownloadID = "download_id",
            Url = "url",

            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserStateChangeDownloadFailed
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };

        BrowserStateChangeDownloadFailed copied = new(model);

        Assert.Equal(model, copied);
    }
}
