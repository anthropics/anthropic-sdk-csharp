using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaServerToolCallerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServerToolCaller
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
            Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_20250825\""),
        };

        string expectedToolID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_20250825\""
        );

        Assert.Equal(expectedToolID, model.ToolID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
