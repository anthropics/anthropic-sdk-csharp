using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContentBlockSource
        {
            Content = "string",
            Type = JsonSerializer.Deserialize<JsonElement>("\"content\""),
        };

        Content expectedContent = "string";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"content\"");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
