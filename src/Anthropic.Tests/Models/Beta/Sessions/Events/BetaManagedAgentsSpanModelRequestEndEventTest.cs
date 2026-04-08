using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            Type = BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd,
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
        ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType> expectedType =
            BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedModelRequestStartID, model.ModelRequestStartID);
        Assert.Equal(expectedModelUsage, model.ModelUsage);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
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
            Type = BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd,
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
            Type = BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd,
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
        ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType> expectedType =
            BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedModelRequestStartID, deserialized.ModelRequestStartID);
        Assert.Equal(expectedModelUsage, deserialized.ModelUsage);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
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
            Type = BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd,
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
            Type = BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd,
        };

        BetaManagedAgentsSpanModelRequestEndEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSpanModelRequestEndEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd)]
    public void Validation_Works(BetaManagedAgentsSpanModelRequestEndEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSpanModelRequestEndEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
