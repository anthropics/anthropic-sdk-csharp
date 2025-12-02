using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaInputTokensClearAtLeastTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaInputTokensClearAtLeast
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"input_tokens\""),
            Value = 0,
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"input_tokens\"");
        long expectedValue = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValue, model.Value);
    }
}
