using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingConfigEnabled
        {
            BudgetTokens = 1024,
            Type = JsonSerializer.Deserialize<JsonElement>("\"enabled\""),
        };

        long expectedBudgetTokens = 1024;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"enabled\"");

        Assert.Equal(expectedBudgetTokens, model.BudgetTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
