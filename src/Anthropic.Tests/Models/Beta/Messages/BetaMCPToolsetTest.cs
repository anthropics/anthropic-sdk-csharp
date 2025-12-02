using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMCPToolsetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
            Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_toolset\""),
            CacheControl = new() { TTL = TTL.TTL5m },
            Configs = new Dictionary<string, BetaMCPToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };

        string expectedMCPServerName = "x";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"mcp_toolset\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        Dictionary<string, BetaMCPToolConfig> expectedConfigs = new()
        {
            {
                "foo",
                new() { DeferLoading = true, Enabled = true }
            },
        };
        BetaMCPToolDefaultConfig expectedDefaultConfig = new()
        {
            DeferLoading = true,
            Enabled = true,
        };

        Assert.Equal(expectedMCPServerName, model.MCPServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedConfigs.Count, model.Configs.Count);
        foreach (var item in expectedConfigs)
        {
            Assert.True(model.Configs.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Configs[item.Key]);
        }
        Assert.Equal(expectedDefaultConfig, model.DefaultConfig);
    }
}
