using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Dreams = Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class DreamListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Dreams::DreamListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Error = new() { Message = "message", Type = "type" },
                    Inputs =
                    [
                        new Dreams::BetaDreamMemoryStoreInput()
                        {
                            MemoryStoreID = "x",
                            Type = Dreams::BetaDreamMemoryStoreInputType.MemoryStore,
                        },
                    ],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Dreams::Speed.Standard },
                    Outputs =
                    [
                        new()
                        {
                            MemoryStoreID = "memory_store_id",
                            Type = Dreams::BetaDreamOutputType.MemoryStore,
                        },
                    ],
                    SessionID = "session_id",
                    Status = Dreams::BetaDreamStatus.Pending,
                    Type = Dreams::Type.Dream,
                    Usage = new()
                    {
                        CacheCreationInputTokens = 0,
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "next_page",
        };

        List<Dreams::BetaDream> expectedData =
        [
            new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Error = new() { Message = "message", Type = "type" },
                Inputs =
                [
                    new Dreams::BetaDreamMemoryStoreInput()
                    {
                        MemoryStoreID = "x",
                        Type = Dreams::BetaDreamMemoryStoreInputType.MemoryStore,
                    },
                ],
                Instructions = "instructions",
                Model = new() { ID = "x", Speed = Dreams::Speed.Standard },
                Outputs =
                [
                    new()
                    {
                        MemoryStoreID = "memory_store_id",
                        Type = Dreams::BetaDreamOutputType.MemoryStore,
                    },
                ],
                SessionID = "session_id",
                Status = Dreams::BetaDreamStatus.Pending,
                Type = Dreams::Type.Dream,
                Usage = new()
                {
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                },
            },
        ];
        string expectedNextPage = "next_page";

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
        var model = new Dreams::DreamListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Error = new() { Message = "message", Type = "type" },
                    Inputs =
                    [
                        new Dreams::BetaDreamMemoryStoreInput()
                        {
                            MemoryStoreID = "x",
                            Type = Dreams::BetaDreamMemoryStoreInputType.MemoryStore,
                        },
                    ],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Dreams::Speed.Standard },
                    Outputs =
                    [
                        new()
                        {
                            MemoryStoreID = "memory_store_id",
                            Type = Dreams::BetaDreamOutputType.MemoryStore,
                        },
                    ],
                    SessionID = "session_id",
                    Status = Dreams::BetaDreamStatus.Pending,
                    Type = Dreams::Type.Dream,
                    Usage = new()
                    {
                        CacheCreationInputTokens = 0,
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dreams::DreamListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Dreams::DreamListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Error = new() { Message = "message", Type = "type" },
                    Inputs =
                    [
                        new Dreams::BetaDreamMemoryStoreInput()
                        {
                            MemoryStoreID = "x",
                            Type = Dreams::BetaDreamMemoryStoreInputType.MemoryStore,
                        },
                    ],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Dreams::Speed.Standard },
                    Outputs =
                    [
                        new()
                        {
                            MemoryStoreID = "memory_store_id",
                            Type = Dreams::BetaDreamOutputType.MemoryStore,
                        },
                    ],
                    SessionID = "session_id",
                    Status = Dreams::BetaDreamStatus.Pending,
                    Type = Dreams::Type.Dream,
                    Usage = new()
                    {
                        CacheCreationInputTokens = 0,
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dreams::DreamListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Dreams::BetaDream> expectedData =
        [
            new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Error = new() { Message = "message", Type = "type" },
                Inputs =
                [
                    new Dreams::BetaDreamMemoryStoreInput()
                    {
                        MemoryStoreID = "x",
                        Type = Dreams::BetaDreamMemoryStoreInputType.MemoryStore,
                    },
                ],
                Instructions = "instructions",
                Model = new() { ID = "x", Speed = Dreams::Speed.Standard },
                Outputs =
                [
                    new()
                    {
                        MemoryStoreID = "memory_store_id",
                        Type = Dreams::BetaDreamOutputType.MemoryStore,
                    },
                ],
                SessionID = "session_id",
                Status = Dreams::BetaDreamStatus.Pending,
                Type = Dreams::Type.Dream,
                Usage = new()
                {
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                },
            },
        ];
        string expectedNextPage = "next_page";

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
        var model = new Dreams::DreamListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Error = new() { Message = "message", Type = "type" },
                    Inputs =
                    [
                        new Dreams::BetaDreamMemoryStoreInput()
                        {
                            MemoryStoreID = "x",
                            Type = Dreams::BetaDreamMemoryStoreInputType.MemoryStore,
                        },
                    ],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Dreams::Speed.Standard },
                    Outputs =
                    [
                        new()
                        {
                            MemoryStoreID = "memory_store_id",
                            Type = Dreams::BetaDreamOutputType.MemoryStore,
                        },
                    ],
                    SessionID = "session_id",
                    Status = Dreams::BetaDreamStatus.Pending,
                    Type = Dreams::Type.Dream,
                    Usage = new()
                    {
                        CacheCreationInputTokens = 0,
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Dreams::DreamListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Error = new() { Message = "message", Type = "type" },
                    Inputs =
                    [
                        new Dreams::BetaDreamMemoryStoreInput()
                        {
                            MemoryStoreID = "x",
                            Type = Dreams::BetaDreamMemoryStoreInputType.MemoryStore,
                        },
                    ],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Dreams::Speed.Standard },
                    Outputs =
                    [
                        new()
                        {
                            MemoryStoreID = "memory_store_id",
                            Type = Dreams::BetaDreamOutputType.MemoryStore,
                        },
                    ],
                    SessionID = "session_id",
                    Status = Dreams::BetaDreamStatus.Pending,
                    Type = Dreams::Type.Dream,
                    Usage = new()
                    {
                        CacheCreationInputTokens = 0,
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "next_page",
        };

        Dreams::DreamListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
