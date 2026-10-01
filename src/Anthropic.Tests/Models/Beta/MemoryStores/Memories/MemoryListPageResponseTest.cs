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
                    ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    Path = "/preferences/formatting.md",
                    Type = BetaManagedAgentsMemoryType.Memory,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Content = null,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<BetaManagedAgentsMemoryListItem> expectedData =
        [
            new BetaManagedAgentsMemory()
            {
                ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                ContentSha256 = "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                ContentSizeBytes = 28,
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                Path = "/preferences/formatting.md",
                Type = BetaManagedAgentsMemoryType.Memory,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Content = null,
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

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
                    ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    Path = "/preferences/formatting.md",
                    Type = BetaManagedAgentsMemoryType.Memory,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Content = null,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
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
                    ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    Path = "/preferences/formatting.md",
                    Type = BetaManagedAgentsMemoryType.Memory,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Content = null,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
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
                ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                ContentSha256 = "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                ContentSizeBytes = 28,
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                Path = "/preferences/formatting.md",
                Type = BetaManagedAgentsMemoryType.Memory,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Content = null,
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

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
                    ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    Path = "/preferences/formatting.md",
                    Type = BetaManagedAgentsMemoryType.Memory,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Content = null,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MemoryListPageResponse { NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=" };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MemoryListPageResponse { NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MemoryListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",

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
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",

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
                    ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    Path = "/preferences/formatting.md",
                    Type = BetaManagedAgentsMemoryType.Memory,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Content = null,
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
                    ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    Path = "/preferences/formatting.md",
                    Type = BetaManagedAgentsMemoryType.Memory,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Content = null,
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
                    ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    Path = "/preferences/formatting.md",
                    Type = BetaManagedAgentsMemoryType.Memory,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Content = null,
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
                    ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    Path = "/preferences/formatting.md",
                    Type = BetaManagedAgentsMemoryType.Memory,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Content = null,
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
                    ID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    MemoryVersionID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    Path = "/preferences/formatting.md",
                    Type = BetaManagedAgentsMemoryType.Memory,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Content = null,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        MemoryListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
