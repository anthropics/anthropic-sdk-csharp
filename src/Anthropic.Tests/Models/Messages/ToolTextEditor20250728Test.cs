using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolTextEditor20250728Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolTextEditor20250728
        {
            Name = JsonSerializer.Deserialize<JsonElement>("\"str_replace_based_edit_tool\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"text_editor_20250728\""),
            CacheControl = new() { TTL = TTL.TTL5m },
            MaxCharacters = 1,
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"str_replace_based_edit_tool\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_20250728\""
        );
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        long expectedMaxCharacters = 1;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedMaxCharacters, model.MaxCharacters);
    }
}
