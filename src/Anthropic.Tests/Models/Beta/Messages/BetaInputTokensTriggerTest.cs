using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaInputTokensTriggerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaInputTokensTrigger
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"input_tokens\""),
            Value = 1,
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"input_tokens\"");
        long expectedValue = 1;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValue, model.Value);
    }
}
