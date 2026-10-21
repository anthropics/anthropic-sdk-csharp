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
    public void TabOpenedTypeWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeTabOpened("tab_id");
        Assert.Equal(BetaBrowserStateChangeType.TabOpened, value.Type.Value());
    }

    [Fact]
    public void DownloadStartedTypeWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeDownloadStarted()
        {
            DownloadID = "download_id",
            Url = "url",
        };
        Assert.Equal(BetaBrowserStateChangeType.DownloadStarted, value.Type.Value());
    }

    [Fact]
    public void DownloadCompletedTypeWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeDownloadCompleted()
        {
            DownloadID = "download_id",
            Url = "url",
            Path = "path",
            SizeBytes = 0,
        };
        Assert.Equal(BetaBrowserStateChangeType.DownloadCompleted, value.Type.Value());
    }

    [Fact]
    public void DownloadFailedTypeWorks()
    {
        BetaBrowserStateChange value = new BetaBrowserStateChangeDownloadFailed()
        {
            DownloadID = "download_id",
            Url = "url",
            Error = "error",
        };
        Assert.Equal(BetaBrowserStateChangeType.DownloadFailed, value.Type.Value());
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

        ApiEnum<string, BetaBrowserStateChangeType> expectedType =
            BetaBrowserStateChangeType.TabOpened;
        string expectedDownloadID = "download_id";
        string expectedUrl = "url";

        Assert.Equal(expectedType, value.Type);
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

public class BetaBrowserStateChangeTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaBrowserStateChangeType.TabOpened)]
    [InlineData(BetaBrowserStateChangeType.DownloadStarted)]
    [InlineData(BetaBrowserStateChangeType.DownloadCompleted)]
    [InlineData(BetaBrowserStateChangeType.DownloadFailed)]
    public void Validation_Works(BetaBrowserStateChangeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserStateChangeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserStateChangeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaBrowserStateChangeType.TabOpened)]
    [InlineData(BetaBrowserStateChangeType.DownloadStarted)]
    [InlineData(BetaBrowserStateChangeType.DownloadCompleted)]
    [InlineData(BetaBrowserStateChangeType.DownloadFailed)]
    public void SerializationRoundtrip_Works(BetaBrowserStateChangeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserStateChangeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserStateChangeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserStateChangeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserStateChangeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
