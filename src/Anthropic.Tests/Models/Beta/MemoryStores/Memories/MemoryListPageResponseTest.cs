using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class MemoryListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MemoryListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsMemory()
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
                },
            ],
            NextPage = "next_page",
        };

        List<BetaManagedAgentsMemoryListItem> expectedData =
        [
            new BetaManagedAgentsMemory()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MemoryListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsMemory()
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
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MemoryListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MemoryListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsMemory()
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
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MemoryListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsMemoryListItem> expectedData =
        [
            new BetaManagedAgentsMemory()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MemoryListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsMemory()
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
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MemoryListPageResponse { NextPage = "next_page" };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MemoryListPageResponse { NextPage = "next_page" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MemoryListPageResponse
        {
            NextPage = "next_page",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MemoryListPageResponse
        {
            NextPage = "next_page",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MemoryListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsMemory()
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
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MemoryListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsMemory()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MemoryListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsMemory()
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
                },
            ],

            NextPage = null,
        };

        Assert.Null(model.NextPage);
        Assert.True(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MemoryListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsMemory()
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
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MemoryListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsMemory()
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
                },
            ],
            NextPage = "next_page",
        };

        MemoryListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
