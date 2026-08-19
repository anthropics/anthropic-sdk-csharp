using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserStateChangeDownloadStartedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserStateChangeDownloadStarted
        {
            DownloadID = "download_id",
            Url = "url",
        };

        string expectedDownloadID = "download_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("download_started");
        string expectedUrl = "url";

        Assert.Equal(expectedDownloadID, model.DownloadID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserStateChangeDownloadStarted
        {
            DownloadID = "download_id",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateChangeDownloadStarted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserStateChangeDownloadStarted
        {
            DownloadID = "download_id",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateChangeDownloadStarted>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDownloadID = "download_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("download_started");
        string expectedUrl = "url";

        Assert.Equal(expectedDownloadID, deserialized.DownloadID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserStateChangeDownloadStarted
        {
            DownloadID = "download_id",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserStateChangeDownloadStarted
        {
            DownloadID = "download_id",
            Url = "url",
        };

        BrowserStateChangeDownloadStarted copied = new(model);

        Assert.Equal(model, copied);
    }
}
