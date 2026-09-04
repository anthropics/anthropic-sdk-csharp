using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserStateChangeTest : TestBase
{
    [Fact]
    public void TabOpenedValidationWorks()
    {
        BrowserStateChange value = new BrowserStateChangeTabOpened("tab_id");
        value.Validate();
    }

    [Fact]
    public void DownloadStartedValidationWorks()
    {
        BrowserStateChange value = new BrowserStateChangeDownloadStarted()
        {
            DownloadID = "download_id",
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void DownloadCompletedValidationWorks()
    {
        BrowserStateChange value = new BrowserStateChangeDownloadCompleted()
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };
        value.Validate();
    }

    [Fact]
    public void DownloadFailedValidationWorks()
    {
        BrowserStateChange value = new BrowserStateChangeDownloadFailed()
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };
        value.Validate();
    }

    [Fact]
    public void TabOpenedSerializationRoundtripWorks()
    {
        BrowserStateChange value = new BrowserStateChangeTabOpened("tab_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DownloadStartedSerializationRoundtripWorks()
    {
        BrowserStateChange value = new BrowserStateChangeDownloadStarted()
        {
            DownloadID = "download_id",
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DownloadCompletedSerializationRoundtripWorks()
    {
        BrowserStateChange value = new BrowserStateChangeDownloadCompleted()
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DownloadFailedSerializationRoundtripWorks()
    {
        BrowserStateChange value = new BrowserStateChangeDownloadFailed()
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BrowserStateChange value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "tab_opened",
                  "download_id": "download_id",
                  "url": "url"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("tab_opened");
        string expectedDownloadID = "download_id";
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.Equal(expectedDownloadID, value.DownloadID);
        Assert.Equal(expectedUrl, value.Url);

        BrowserStateChange emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.DownloadID);
        Assert.Null(emptyValue.Url);

        BrowserStateChange mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "download_id": [
                    "invalid"
                  ],
                  "url": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.DownloadID);
        Assert.Null(mismatchedValue.Url);
    }
}
