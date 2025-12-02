using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingBlockParam
        {
            Signature = "signature",
            Thinking = "thinking",
            Type = JsonSerializer.Deserialize<JsonElement>("\"thinking\""),
        };

        string expectedSignature = "signature";
        string expectedThinking = "thinking";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"thinking\"");

        Assert.Equal(expectedSignature, model.Signature);
        Assert.Equal(expectedThinking, model.Thinking);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
