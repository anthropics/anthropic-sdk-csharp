using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Tests.Models.Beta.MemoryStores.MemoryVersions;

public class BetaManagedAgentsMemoryVersionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            Content = "content",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
            Path = "path",
            RedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RedactedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemoryID = "memory_id";
        string expectedMemoryStoreID = "memory_store_id";
        ApiEnum<string, BetaManagedAgentsMemoryVersionOperation> expectedOperation =
            BetaManagedAgentsMemoryVersionOperation.Created;
        ApiEnum<string, BetaManagedAgentsMemoryVersionType> expectedType =
            BetaManagedAgentsMemoryVersionType.MemoryVersion;
        string expectedContent = "content";
        string expectedContentSha256 = "content_sha256";
        int expectedContentSizeBytes = 0;
        BetaManagedAgentsActor expectedCreatedBy = new BetaManagedAgentsSessionActor()
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };
        string expectedPath = "path";
        DateTimeOffset expectedRedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsActor expectedRedactedBy = new BetaManagedAgentsSessionActor()
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMemoryID, model.MemoryID);
        Assert.Equal(expectedMemoryStoreID, model.MemoryStoreID);
        Assert.Equal(expectedOperation, model.Operation);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedContentSha256, model.ContentSha256);
        Assert.Equal(expectedContentSizeBytes, model.ContentSizeBytes);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedRedactedAt, model.RedactedAt);
        Assert.Equal(expectedRedactedBy, model.RedactedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            Content = "content",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
            Path = "path",
            RedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RedactedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryVersion>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            Content = "content",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
            Path = "path",
            RedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RedactedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryVersion>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemoryID = "memory_id";
        string expectedMemoryStoreID = "memory_store_id";
        ApiEnum<string, BetaManagedAgentsMemoryVersionOperation> expectedOperation =
            BetaManagedAgentsMemoryVersionOperation.Created;
        ApiEnum<string, BetaManagedAgentsMemoryVersionType> expectedType =
            BetaManagedAgentsMemoryVersionType.MemoryVersion;
        string expectedContent = "content";
        string expectedContentSha256 = "content_sha256";
        int expectedContentSizeBytes = 0;
        BetaManagedAgentsActor expectedCreatedBy = new BetaManagedAgentsSessionActor()
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };
        string expectedPath = "path";
        DateTimeOffset expectedRedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsActor expectedRedactedBy = new BetaManagedAgentsSessionActor()
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMemoryID, deserialized.MemoryID);
        Assert.Equal(expectedMemoryStoreID, deserialized.MemoryStoreID);
        Assert.Equal(expectedOperation, deserialized.Operation);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedContentSha256, deserialized.ContentSha256);
        Assert.Equal(expectedContentSizeBytes, deserialized.ContentSizeBytes);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedRedactedAt, deserialized.RedactedAt);
        Assert.Equal(expectedRedactedBy, deserialized.RedactedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            Content = "content",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
            Path = "path",
            RedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RedactedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            Content = "content",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            Path = "path",
            RedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.RedactedBy);
        Assert.False(model.RawData.ContainsKey("redacted_by"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            Content = "content",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            Path = "path",
            RedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            Content = "content",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            Path = "path",
            RedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            CreatedBy = null,
            RedactedBy = null,
        };

        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.RedactedBy);
        Assert.False(model.RawData.ContainsKey("redacted_by"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            Content = "content",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            Path = "path",
            RedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            CreatedBy = null,
            RedactedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            CreatedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
            RedactedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.ContentSha256);
        Assert.False(model.RawData.ContainsKey("content_sha256"));
        Assert.Null(model.ContentSizeBytes);
        Assert.False(model.RawData.ContainsKey("content_size_bytes"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.RedactedAt);
        Assert.False(model.RawData.ContainsKey("redacted_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            CreatedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
            RedactedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            CreatedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
            RedactedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },

            Content = null,
            ContentSha256 = null,
            ContentSizeBytes = null,
            Path = null,
            RedactedAt = null,
        };

        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.ContentSha256);
        Assert.True(model.RawData.ContainsKey("content_sha256"));
        Assert.Null(model.ContentSizeBytes);
        Assert.True(model.RawData.ContainsKey("content_size_bytes"));
        Assert.Null(model.Path);
        Assert.True(model.RawData.ContainsKey("path"));
        Assert.Null(model.RedactedAt);
        Assert.True(model.RawData.ContainsKey("redacted_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            CreatedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
            RedactedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },

            Content = null,
            ContentSha256 = null,
            ContentSizeBytes = null,
            Path = null,
            RedactedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemoryVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryID = "memory_id",
            MemoryStoreID = "memory_store_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
            Content = "content",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
            Path = "path",
            RedactedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RedactedBy = new BetaManagedAgentsSessionActor()
            {
                SessionID = "x",
                Type = BetaManagedAgentsSessionActorType.SessionActor,
            },
        };

        BetaManagedAgentsMemoryVersion copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryVersionTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryVersionType.MemoryVersion)]
    public void Validation_Works(BetaManagedAgentsMemoryVersionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryVersionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryVersionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryVersionType.MemoryVersion)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMemoryVersionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryVersionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryVersionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryVersionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryVersionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
