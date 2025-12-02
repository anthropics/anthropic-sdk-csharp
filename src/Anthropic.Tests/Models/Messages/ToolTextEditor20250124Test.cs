using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolTextEditor20250124Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolTextEditor20250124
        {
            Name = JsonSerializer.Deserialize<JsonElement>("\"str_replace_editor\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"text_editor_20250124\""),
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"str_replace_editor\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_20250124\""
        );
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }
}
