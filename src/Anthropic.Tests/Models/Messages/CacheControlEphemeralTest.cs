using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CacheControlEphemeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CacheControlEphemeral
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\""),
            TTL = TTL.TTL5m,
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
        ApiEnum<string, TTL> expectedTTL = TTL.TTL5m;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedTTL, model.TTL);
    }
}
