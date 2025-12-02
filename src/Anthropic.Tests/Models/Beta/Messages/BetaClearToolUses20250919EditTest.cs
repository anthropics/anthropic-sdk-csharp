using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaClearToolUses20250919EditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\""),
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_tool_uses_20250919\""
        );
        BetaInputTokensClearAtLeast expectedClearAtLeast = new(0);
        ClearToolInputs expectedClearToolInputs = true;
        List<string> expectedExcludeTools = ["string"];
        BetaToolUsesKeep expectedKeep = new(0);
        Trigger expectedTrigger = new BetaInputTokensTrigger(1);

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedClearAtLeast, model.ClearAtLeast);
        Assert.Equal(expectedClearToolInputs, model.ClearToolInputs);
        Assert.Equal(expectedExcludeTools.Count, model.ExcludeTools.Count);
        for (int i = 0; i < expectedExcludeTools.Count; i++)
        {
            Assert.Equal(expectedExcludeTools[i], model.ExcludeTools[i]);
        }
        Assert.Equal(expectedKeep, model.Keep);
        Assert.Equal(expectedTrigger, model.Trigger);
    }
}
