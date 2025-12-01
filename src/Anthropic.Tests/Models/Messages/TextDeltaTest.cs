using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextDelta
        {
            Text = "text",
            Type = JsonSerializer.Deserialize<JsonElement>("\"text_delta\""),
        };

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"text_delta\"");

        Assert.Equal(expectedText, model.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
