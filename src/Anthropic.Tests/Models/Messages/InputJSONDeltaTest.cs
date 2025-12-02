using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class InputJSONDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputJSONDelta
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
