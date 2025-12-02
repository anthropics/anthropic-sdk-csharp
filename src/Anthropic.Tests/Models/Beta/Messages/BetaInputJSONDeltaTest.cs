using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaInputJSONDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaInputJSONDelta
        {
            PartialJSON = "partial_json",
            Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\""),
        };

        string expectedPartialJSON = "partial_json";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");

        Assert.Equal(expectedPartialJSON, model.PartialJSON);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
