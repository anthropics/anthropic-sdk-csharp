using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawMessageStopEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRawMessageStopEvent
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"message_stop\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"message_stop\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
