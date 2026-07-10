using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Dreams = Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Dreams::BetaDream
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
        };

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dreams::BetaDreamError expectedError = new() { Message = "message", Type = "type" };
        List<Dreams::BetaDreamInput> expectedInputs =
        [
            new Dreams::BetaDreamMemoryStoreInput()
            {
                MemoryStoreID = "x",
                Type = Dreams::BetaDreamMemoryStoreInputType.MemoryStore,
            },
        ];
        string expectedInstructions = "instructions";
        Dreams::BetaDreamModelConfig expectedModel = new()
        {
            ID = "x",
            Speed = Dreams::Speed.Standard,
        };
        List<Dreams::BetaDreamOutput> expectedOutputs =
        [
            new()
            {
                MemoryStoreID = "memory_store_id",
                Type = Dreams::BetaDreamOutputType.MemoryStore,
            },
        ];
        string expectedSessionID = "session_id";
        ApiEnum<string, Dreams::BetaDreamStatus> expectedStatus = Dreams::BetaDreamStatus.Pending;
        ApiEnum<string, Dreams::Type> expectedType = Dreams::Type.Dream;
        Dreams::BetaDreamUsage expectedUsage = new()
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEndedAt, model.EndedAt);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedInputs.Count, model.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], model.Inputs[i]);
        }
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedOutputs.Count, model.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], model.Outputs[i]);
        }
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Dreams::BetaDream
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dreams::BetaDream>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Dreams::BetaDream
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dreams::BetaDream>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dreams::BetaDreamError expectedError = new() { Message = "message", Type = "type" };
        List<Dreams::BetaDreamInput> expectedInputs =
        [
            new Dreams::BetaDreamMemoryStoreInput()
            {
                MemoryStoreID = "x",
                Type = Dreams::BetaDreamMemoryStoreInputType.MemoryStore,
            },
        ];
        string expectedInstructions = "instructions";
        Dreams::BetaDreamModelConfig expectedModel = new()
        {
            ID = "x",
            Speed = Dreams::Speed.Standard,
        };
        List<Dreams::BetaDreamOutput> expectedOutputs =
        [
            new()
            {
                MemoryStoreID = "memory_store_id",
                Type = Dreams::BetaDreamOutputType.MemoryStore,
            },
        ];
        string expectedSessionID = "session_id";
        ApiEnum<string, Dreams::BetaDreamStatus> expectedStatus = Dreams::BetaDreamStatus.Pending;
        ApiEnum<string, Dreams::Type> expectedType = Dreams::Type.Dream;
        Dreams::BetaDreamUsage expectedUsage = new()
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEndedAt, deserialized.EndedAt);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedInputs.Count, deserialized.Inputs.Count);
        for (int i = 0; i < expectedInputs.Count; i++)
        {
            Assert.Equal(expectedInputs[i], deserialized.Inputs[i]);
        }
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedOutputs.Count, deserialized.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], deserialized.Outputs[i]);
        }
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Dreams::BetaDream
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Dreams::BetaDream
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
        };

        Dreams::BetaDream copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Dreams::Type.Dream)]
    public void Validation_Works(Dreams::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Dreams::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Dreams::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Dreams::Type.Dream)]
    public void SerializationRoundtrip_Works(Dreams::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Dreams::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Dreams::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Dreams::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Dreams::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
