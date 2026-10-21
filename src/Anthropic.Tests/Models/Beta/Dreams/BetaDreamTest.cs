using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDream
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
        };

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaDreamError expectedError = new() { Message = "message", Type = "type" };
        List<BetaDreamInput> expectedInputs = [new BetaDreamMemoryStoreInput("x")];
        string expectedInstructions = "instructions";
        BetaDreamModelConfig expectedModel = new() { ID = "x", Speed = Speed.Standard };
        BetaOutputBehavior expectedOutputBehavior = new BetaOutputBehaviorCreateNew();
        List<BetaDreamOutput> expectedOutputs = [new("memory_store_id")];
        string expectedSessionID = "session_id";
        ApiEnum<string, BetaDreamStatus> expectedStatus = BetaDreamStatus.Pending;
        JsonElement expectedType = JsonSerializer.SerializeToElement("dream");
        BetaDreamUsage expectedUsage = new()
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
        Assert.Equal(expectedOutputBehavior, model.OutputBehavior);
        Assert.Equal(expectedOutputs.Count, model.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], model.Outputs[i]);
        }
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDream
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDream>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDream
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDream>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaDreamError expectedError = new() { Message = "message", Type = "type" };
        List<BetaDreamInput> expectedInputs = [new BetaDreamMemoryStoreInput("x")];
        string expectedInstructions = "instructions";
        BetaDreamModelConfig expectedModel = new() { ID = "x", Speed = Speed.Standard };
        BetaOutputBehavior expectedOutputBehavior = new BetaOutputBehaviorCreateNew();
        List<BetaDreamOutput> expectedOutputs = [new("memory_store_id")];
        string expectedSessionID = "session_id";
        ApiEnum<string, BetaDreamStatus> expectedStatus = BetaDreamStatus.Pending;
        JsonElement expectedType = JsonSerializer.SerializeToElement("dream");
        BetaDreamUsage expectedUsage = new()
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
        Assert.Equal(expectedOutputBehavior, deserialized.OutputBehavior);
        Assert.Equal(expectedOutputs.Count, deserialized.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], deserialized.Outputs[i]);
        }
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDream
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDream
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
        };

        BetaDream copied = new(model);

        Assert.Equal(model, copied);
    }
}
