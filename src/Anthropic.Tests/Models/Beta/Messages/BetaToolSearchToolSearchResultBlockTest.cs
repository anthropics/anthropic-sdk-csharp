using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolSearchResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolSearchResultBlock
        {
            ToolReferences = [new("tool_name")],
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_search_result\""),
        };

        List<BetaToolReferenceBlock> expectedToolReferences = [new("tool_name")];
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_search_result\""
        );

        Assert.Equal(expectedToolReferences.Count, model.ToolReferences.Count);
        for (int i = 0; i < expectedToolReferences.Count; i++)
        {
            Assert.Equal(expectedToolReferences[i], model.ToolReferences[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
