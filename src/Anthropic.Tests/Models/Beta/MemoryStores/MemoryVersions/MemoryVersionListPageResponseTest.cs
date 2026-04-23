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
                },
            ],
            NextPage = "next_page",
        };

        List<BetaManagedAgentsMemoryVersion> expectedData =
        [
            new()
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
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
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
                },
            ],
            NextPage = "next_page",
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
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MemoryVersionListPageResponse { NextPage = "next_page" };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MemoryVersionListPageResponse { NextPage = "next_page" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MemoryVersionListPageResponse
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
        var model = new MemoryVersionListPageResponse
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
        var model = new MemoryVersionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        MemoryVersionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
