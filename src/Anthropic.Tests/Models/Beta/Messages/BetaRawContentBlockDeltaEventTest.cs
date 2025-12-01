using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawContentBlockDeltaEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRawContentBlockDeltaEvent
        {
            Delta = new BetaTextDelta("text"),
            Index = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\""),
        };

        BetaRawContentBlockDelta expectedDelta = new BetaTextDelta("text");
        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"content_block_delta\""
        );

        Assert.Equal(expectedDelta, model.Delta);
        Assert.Equal(expectedIndex, model.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
