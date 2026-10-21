using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsMemoryListItemTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsMemoryValidationWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemory()
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };
        value.Validate();
    }

    [Fact]
    public void PrefixValidationWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemoryPrefix("path");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMemorySerializationRoundtripWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemory()
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryListItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PrefixSerializationRoundtripWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemoryPrefix("path");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryListItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMemoryTypeWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemory()
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };
        Assert.Equal(BetaManagedAgentsMemoryListItemType.Memory, value.Type.Value());
    }

    [Fact]
    public void PrefixTypeWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemoryPrefix("path");
        Assert.Equal(BetaManagedAgentsMemoryListItemType.MemoryPrefix, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMemoryListItem value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "path": "path",
                  "type": "memory"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedPath = "path";
        ApiEnum<string, BetaManagedAgentsMemoryListItemType> expectedType =
            BetaManagedAgentsMemoryListItemType.Memory;

        Assert.Equal(expectedPath, value.Path);
        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMemoryListItem emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Path);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaManagedAgentsMemoryListItem mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "path": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Path);
    }
}

public class BetaManagedAgentsMemoryListItemTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryListItemType.Memory)]
    [InlineData(BetaManagedAgentsMemoryListItemType.MemoryPrefix)]
    public void Validation_Works(BetaManagedAgentsMemoryListItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryListItemType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryListItemType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryListItemType.Memory)]
    [InlineData(BetaManagedAgentsMemoryListItemType.MemoryPrefix)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMemoryListItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryListItemType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryListItemType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryListItemType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryListItemType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
