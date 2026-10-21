using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class DreamListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DreamListPageResponse
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
                    Inputs = [new BetaDreamMemoryStoreInput("x")],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Speed.Standard },
                    OutputBehavior = new BetaOutputBehaviorCreateNew(),
                    Outputs = [new("memory_store_id")],
                    SessionID = "session_id",
                    Status = BetaDreamStatus.Pending,
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

        List<BetaDream> expectedData =
        [
            new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Error = new() { Message = "message", Type = "type" },
                Inputs = [new BetaDreamMemoryStoreInput("x")],
                Instructions = "instructions",
                Model = new() { ID = "x", Speed = Speed.Standard },
                OutputBehavior = new BetaOutputBehaviorCreateNew(),
                Outputs = [new("memory_store_id")],
                SessionID = "session_id",
                Status = BetaDreamStatus.Pending,
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
        var model = new DreamListPageResponse
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
                    Inputs = [new BetaDreamMemoryStoreInput("x")],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Speed.Standard },
                    OutputBehavior = new BetaOutputBehaviorCreateNew(),
                    Outputs = [new("memory_store_id")],
                    SessionID = "session_id",
                    Status = BetaDreamStatus.Pending,
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
        var deserialized = JsonSerializer.Deserialize<DreamListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DreamListPageResponse
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
                    Inputs = [new BetaDreamMemoryStoreInput("x")],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Speed.Standard },
                    OutputBehavior = new BetaOutputBehaviorCreateNew(),
                    Outputs = [new("memory_store_id")],
                    SessionID = "session_id",
                    Status = BetaDreamStatus.Pending,
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
        var deserialized = JsonSerializer.Deserialize<DreamListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaDream> expectedData =
        [
            new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Error = new() { Message = "message", Type = "type" },
                Inputs = [new BetaDreamMemoryStoreInput("x")],
                Instructions = "instructions",
                Model = new() { ID = "x", Speed = Speed.Standard },
                OutputBehavior = new BetaOutputBehaviorCreateNew(),
                Outputs = [new("memory_store_id")],
                SessionID = "session_id",
                Status = BetaDreamStatus.Pending,
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
        var model = new DreamListPageResponse
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
                    Inputs = [new BetaDreamMemoryStoreInput("x")],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Speed.Standard },
                    OutputBehavior = new BetaOutputBehaviorCreateNew(),
                    Outputs = [new("memory_store_id")],
                    SessionID = "session_id",
                    Status = BetaDreamStatus.Pending,
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
        var model = new DreamListPageResponse
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
                    Inputs = [new BetaDreamMemoryStoreInput("x")],
                    Instructions = "instructions",
                    Model = new() { ID = "x", Speed = Speed.Standard },
                    OutputBehavior = new BetaOutputBehaviorCreateNew(),
                    Outputs = [new("memory_store_id")],
                    SessionID = "session_id",
                    Status = BetaDreamStatus.Pending,
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

        DreamListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
