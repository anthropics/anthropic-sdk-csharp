using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawContentBlockDeltaEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RawContentBlockDeltaEvent
        {
            Delta = new TextDelta("text"),
            Index = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\""),
        };

        RawContentBlockDelta expectedDelta = new TextDelta("text");
        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"content_block_delta\""
        );

        Assert.Equal(expectedDelta, model.Delta);
        Assert.Equal(expectedIndex, model.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
