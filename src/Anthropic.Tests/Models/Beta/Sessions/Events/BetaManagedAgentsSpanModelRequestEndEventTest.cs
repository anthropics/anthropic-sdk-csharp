using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSpanModelRequestEndEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanModelRequestEndEvent
        {
            ID = "id",
            IsError = true,
            ModelRequestStartID = "model_request_start_id",
            ModelUsage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                Speed = Speed.Standard,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        bool expectedIsError = true;
        string expectedModelRequestStartID = "model_request_start_id";
        BetaManagedAgentsSpanModelUsage expectedModelUsage = new()
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
            Speed = Speed.Standard,
        };
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("span.model_request_end");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedModelRequestStartID, model.ModelRequestStartID);
        Assert.Equal(expectedModelUsage, model.ModelUsage);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanModelRequestEndEvent
        {
            ID = "id",
            IsError = true,
            ModelRequestStartID = "model_request_start_id",
            ModelUsage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                Speed = Speed.Standard,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSpanModelRequestEndEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSpanModelRequestEndEvent
        {
            ID = "id",
            IsError = true,
            ModelRequestStartID = "model_request_start_id",
            ModelUsage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                Speed = Speed.Standard,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSpanModelRequestEndEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedIsError = true;
        string expectedModelRequestStartID = "model_request_start_id";
        BetaManagedAgentsSpanModelUsage expectedModelUsage = new()
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
            Speed = Speed.Standard,
        };
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("span.model_request_end");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedModelRequestStartID, deserialized.ModelRequestStartID);
        Assert.Equal(expectedModelUsage, deserialized.ModelUsage);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSpanModelRequestEndEvent
        {
            ID = "id",
            IsError = true,
            ModelRequestStartID = "model_request_start_id",
            ModelUsage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                Speed = Speed.Standard,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSpanModelRequestEndEvent
        {
            ID = "id",
            IsError = true,
            ModelRequestStartID = "model_request_start_id",
            ModelUsage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
                Speed = Speed.Standard,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaManagedAgentsSpanModelRequestEndEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
