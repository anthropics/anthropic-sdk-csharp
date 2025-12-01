using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawMessageStopEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RawMessageStopEvent
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"message_stop\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"message_stop\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
