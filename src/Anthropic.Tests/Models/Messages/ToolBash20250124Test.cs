using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolBash20250124Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolBash20250124
        {
            Name = JsonSerializer.Deserialize<JsonElement>("\"bash\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\""),
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"bash\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }
}
