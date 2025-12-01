using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolReferenceBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolReferenceBlockParam
        {
            ToolName = "tool_name",
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\""),
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string expectedToolName = "tool_name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedToolName, model.ToolName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }
}
