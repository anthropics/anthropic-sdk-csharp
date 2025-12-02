using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRedactedThinkingBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRedactedThinkingBlock
        {
            Data = "data",
            Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\""),
        };

        string expectedData = "data";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");

        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
