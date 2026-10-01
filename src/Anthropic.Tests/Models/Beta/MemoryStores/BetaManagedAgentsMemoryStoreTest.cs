using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores;

namespace Anthropic.Tests.Models.Beta.MemoryStores;

public class BetaManagedAgentsMemoryStoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStore
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Type = BetaManagedAgentsMemoryStoreType.MemoryStore,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        ApiEnum<string, BetaManagedAgentsMemoryStoreType> expectedType =
            BetaManagedAgentsMemoryStoreType.MemoryStore;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStore
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Type = BetaManagedAgentsMemoryStoreType.MemoryStore,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryStore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemoryStore
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Type = BetaManagedAgentsMemoryStoreType.MemoryStore,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryStore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        ApiEnum<string, BetaManagedAgentsMemoryStoreType> expectedType =
            BetaManagedAgentsMemoryStoreType.MemoryStore;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemoryStore
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Type = BetaManagedAgentsMemoryStoreType.MemoryStore,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemoryStore
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Type = BetaManagedAgentsMemoryStoreType.MemoryStore,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaManagedAgentsMemoryStore copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryStoreTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryStoreType.MemoryStore)]
    public void Validation_Works(BetaManagedAgentsMemoryStoreType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryStoreType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryStoreType.MemoryStore)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMemoryStoreType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryStoreType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
