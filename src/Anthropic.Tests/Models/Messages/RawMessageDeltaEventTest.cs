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
            Type = JsonSerializer.Deserialize<JsonElement>("\"message_delta\""),
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
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"message_delta\"");
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
}
