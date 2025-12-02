using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawContentBlockStopEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RawContentBlockStopEvent
        {
            Index = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_stop\""),
        };

        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"content_block_stop\""
        );

        Assert.Equal(expectedIndex, model.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
