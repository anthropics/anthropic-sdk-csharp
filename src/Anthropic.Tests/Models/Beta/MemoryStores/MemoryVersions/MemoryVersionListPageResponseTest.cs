using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Tests.Models.Beta.MemoryStores.MemoryVersions;

public class MemoryVersionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                    Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                    Content = null,
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                    Path = "/preferences/formatting.md",
                    RedactedAt = null,
                    RedactedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "x",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<BetaManagedAgentsMemoryVersion> expectedData =
        [
            new()
            {
                ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                Content = null,
                ContentSha256 = "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                ContentSizeBytes = 28,
                CreatedBy = new BetaManagedAgentsSessionActor()
                {
                    SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                    Type = BetaManagedAgentsSessionActorType.SessionActor,
                },
                Path = "/preferences/formatting.md",
                RedactedAt = null,
                RedactedBy = new BetaManagedAgentsSessionActor()
                {
                    SessionID = "x",
                    Type = BetaManagedAgentsSessionActorType.SessionActor,
                },
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
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                    Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                    Content = null,
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                    Path = "/preferences/formatting.md",
                    RedactedAt = null,
                    RedactedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "x",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MemoryVersionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                    Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                    Content = null,
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                    Path = "/preferences/formatting.md",
                    RedactedAt = null,
                    RedactedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "x",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MemoryVersionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsMemoryVersion> expectedData =
        [
            new()
            {
                ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                Content = null,
                ContentSha256 = "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                ContentSizeBytes = 28,
                CreatedBy = new BetaManagedAgentsSessionActor()
                {
                    SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                    Type = BetaManagedAgentsSessionActorType.SessionActor,
                },
                Path = "/preferences/formatting.md",
                RedactedAt = null,
                RedactedBy = new BetaManagedAgentsSessionActor()
                {
                    SessionID = "x",
                    Type = BetaManagedAgentsSessionActorType.SessionActor,
                },
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
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                    Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                    Content = null,
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                    Path = "/preferences/formatting.md",
                    RedactedAt = null,
                    RedactedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "x",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MemoryVersionListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MemoryVersionListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MemoryVersionListPageResponse
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
        var model = new MemoryVersionListPageResponse
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
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                    Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                    Content = null,
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                    Path = "/preferences/formatting.md",
                    RedactedAt = null,
                    RedactedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "x",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                    Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                    Content = null,
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                    Path = "/preferences/formatting.md",
                    RedactedAt = null,
                    RedactedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "x",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                    Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                    Content = null,
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                    Path = "/preferences/formatting.md",
                    RedactedAt = null,
                    RedactedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "x",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
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
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                    Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                    Content = null,
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                    Path = "/preferences/formatting.md",
                    RedactedAt = null,
                    RedactedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "x",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "memver_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MemoryID = "mem_011CZkZ9X2dpNyB6YbtxvB6e",
                    MemoryStoreID = "memstore_01Wf3kQ8tZxB2mVr7HcJ4aNd",
                    Operation = BetaManagedAgentsMemoryVersionOperation.Created,
                    Type = BetaManagedAgentsMemoryVersionType.MemoryVersion,
                    Content = null,
                    ContentSha256 =
                        "ba7936d94c84d948a2232088f78228f175df6a8353b2d5bc9228eee5794a0024",
                    ContentSizeBytes = 28,
                    CreatedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                    Path = "/preferences/formatting.md",
                    RedactedAt = null,
                    RedactedBy = new BetaManagedAgentsSessionActor()
                    {
                        SessionID = "x",
                        Type = BetaManagedAgentsSessionActorType.SessionActor,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        MemoryVersionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
