using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserStateChangeTest : TestBase
{
    [Fact]
    public void TabOpenedValidationWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeTabOpened("tab_id");
        value.Validate();
    }

    [Fact]
    public void DownloadStartedValidationWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeDownloadStarted()
        {
            DownloadID = "download_id",
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void DownloadCompletedValidationWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeDownloadCompleted()
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
        BetaBrowserStateChange value = new BetaBrowserStateChangeDownloadFailed()
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
        BetaBrowserStateChange value = new BetaBrowserStateChangeTabOpened("tab_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DownloadStartedSerializationRoundtripWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeDownloadStarted()
        {
            DownloadID = "download_id",
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DownloadCompletedSerializationRoundtripWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeDownloadCompleted()
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DownloadFailedSerializationRoundtripWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeDownloadFailed()
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaBrowserStateChange value = new(
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

        BetaBrowserStateChange emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.DownloadID);
        Assert.Null(emptyValue.Url);

        BetaBrowserStateChange mismatchedValue = new(
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
