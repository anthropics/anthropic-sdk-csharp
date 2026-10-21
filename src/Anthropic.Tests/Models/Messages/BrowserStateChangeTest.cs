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
    public void TabOpenedTypeWorks()
    {
        BrowserStateChange value = new BrowserStateChangeTabOpened("tab_id");
        Assert.Equal(BrowserStateChangeType.TabOpened, value.Type.Value());
    }

    [Fact]
    public void DownloadStartedTypeWorks()
    {
        BrowserStateChange value = new BrowserStateChangeDownloadStarted()
        {
            DownloadID = "download_id",
            Url = "url",
        };
        Assert.Equal(BrowserStateChangeType.DownloadStarted, value.Type.Value());
    }

    [Fact]
    public void DownloadCompletedTypeWorks()
    {
        BrowserStateChange value = new BrowserStateChangeDownloadCompleted()
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };
        Assert.Equal(BrowserStateChangeType.DownloadCompleted, value.Type.Value());
    }

    [Fact]
    public void DownloadFailedTypeWorks()
    {
        BrowserStateChange value = new BrowserStateChangeDownloadFailed()
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };
        Assert.Equal(BrowserStateChangeType.DownloadFailed, value.Type.Value());
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

        ApiEnum<string, BrowserStateChangeType> expectedType = BrowserStateChangeType.TabOpened;
        string expectedDownloadID = "download_id";
        string expectedUrl = "url";

        Assert.Equal(expectedType, value.Type);
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

public class BrowserStateChangeTypeTest : TestBase
{
    [Theory]
    [InlineData(BrowserStateChangeType.TabOpened)]
    [InlineData(BrowserStateChangeType.DownloadStarted)]
    [InlineData(BrowserStateChangeType.DownloadCompleted)]
    [InlineData(BrowserStateChangeType.DownloadFailed)]
    public void Validation_Works(BrowserStateChangeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrowserStateChangeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrowserStateChangeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BrowserStateChangeType.TabOpened)]
    [InlineData(BrowserStateChangeType.DownloadStarted)]
    [InlineData(BrowserStateChangeType.DownloadCompleted)]
    [InlineData(BrowserStateChangeType.DownloadFailed)]
    public void SerializationRoundtrip_Works(BrowserStateChangeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrowserStateChangeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrowserStateChangeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrowserStateChangeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrowserStateChangeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
