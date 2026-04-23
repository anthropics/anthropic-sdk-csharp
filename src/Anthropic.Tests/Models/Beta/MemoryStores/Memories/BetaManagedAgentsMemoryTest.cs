using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsMemoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemory
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };

        string expectedID = "id";
        string expectedContentSha256 = "content_sha256";
        int expectedContentSizeBytes = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemoryStoreID = "memory_store_id";
        string expectedMemoryVersionID = "memory_version_id";
        string expectedPath = "path";
        ApiEnum<string, BetaManagedAgentsMemoryType> expectedType =
            BetaManagedAgentsMemoryType.Memory;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedContent = "content";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContentSha256, model.ContentSha256);
        Assert.Equal(expectedContentSizeBytes, model.ContentSizeBytes);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMemoryStoreID, model.MemoryStoreID);
        Assert.Equal(expectedMemoryVersionID, model.MemoryVersionID);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedContent, model.Content);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemory
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemory
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedContentSha256 = "content_sha256";
        int expectedContentSizeBytes = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemoryStoreID = "memory_store_id";
        string expectedMemoryVersionID = "memory_version_id";
        string expectedPath = "path";
        ApiEnum<string, BetaManagedAgentsMemoryType> expectedType =
            BetaManagedAgentsMemoryType.Memory;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedContent = "content";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContentSha256, deserialized.ContentSha256);
        Assert.Equal(expectedContentSizeBytes, deserialized.ContentSizeBytes);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMemoryStoreID, deserialized.MemoryStoreID);
        Assert.Equal(expectedMemoryVersionID, deserialized.MemoryVersionID);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedContent, deserialized.Content);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemory
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemory
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMemory
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMemory
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Content = null,
        };

        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMemory
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemory
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };

        BetaManagedAgentsMemory copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryType.Memory)]
    public void Validation_Works(BetaManagedAgentsMemoryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryType.Memory)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMemoryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
