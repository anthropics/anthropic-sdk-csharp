using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RedactedThinkingBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RedactedThinkingBlockParam
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
