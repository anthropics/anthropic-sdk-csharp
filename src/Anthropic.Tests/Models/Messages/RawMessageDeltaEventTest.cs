using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawMessageDeltaEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RawMessageDeltaEvent
        {
            Delta = new() { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
            },
        };

        Delta expectedDelta = new()
        {
            StopReason = StopReason.EndTurn,
            StopSequence = "stop_sequence",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("message_delta");
        MessageDeltaUsage expectedUsage = new()
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new(0),
        };

        Assert.Equal(expectedDelta, model.Delta);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RawMessageDeltaEvent
        {
            Delta = new() { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawMessageDeltaEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RawMessageDeltaEvent
        {
            Delta = new() { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawMessageDeltaEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Delta expectedDelta = new()
        {
            StopReason = StopReason.EndTurn,
            StopSequence = "stop_sequence",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("message_delta");
        MessageDeltaUsage expectedUsage = new()
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new(0),
        };

        Assert.Equal(expectedDelta, deserialized.Delta);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RawMessageDeltaEvent
        {
            Delta = new() { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RawMessageDeltaEvent
        {
            Delta = new() { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
            },
        };

        RawMessageDeltaEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Delta { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" };

        ApiEnum<string, StopReason> expectedStopReason = StopReason.EndTurn;
        string expectedStopSequence = "stop_sequence";

        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.Equal(expectedStopSequence, model.StopSequence);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Delta { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Delta { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, StopReason> expectedStopReason = StopReason.EndTurn;
        string expectedStopSequence = "stop_sequence";

        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.Equal(expectedStopSequence, deserialized.StopSequence);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Delta { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Delta { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" };

        Delta copied = new(model);

        Assert.Equal(model, copied);
    }
}
