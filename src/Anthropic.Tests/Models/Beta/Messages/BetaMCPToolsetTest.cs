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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMCPToolset>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMCPToolset>(element);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedMCPServerName, deserialized.MCPServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedConfigs.Count, deserialized.Configs.Count);
        foreach (var item in expectedConfigs)
        {
            Assert.True(deserialized.Configs.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Configs[item.Key]);
        }
        Assert.Equal(expectedDefaultConfig, deserialized.DefaultConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
            CacheControl = new() { TTL = TTL.TTL5m },
            Configs = new Dictionary<string, BetaMCPToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
        };

        Assert.Null(model.DefaultConfig);
        Assert.False(model.RawData.ContainsKey("default_config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
            CacheControl = new() { TTL = TTL.TTL5m },
            Configs = new Dictionary<string, BetaMCPToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
            CacheControl = new() { TTL = TTL.TTL5m },
            Configs = new Dictionary<string, BetaMCPToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },

            // Null should be interpreted as omitted for these properties
            DefaultConfig = null,
        };

        Assert.Null(model.DefaultConfig);
        Assert.False(model.RawData.ContainsKey("default_config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
            CacheControl = new() { TTL = TTL.TTL5m },
            Configs = new Dictionary<string, BetaMCPToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },

            // Null should be interpreted as omitted for these properties
            DefaultConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Configs);
        Assert.False(model.RawData.ContainsKey("configs"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
            DefaultConfig = new() { DeferLoading = true, Enabled = true },

            CacheControl = null,
            Configs = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Configs);
        Assert.True(model.RawData.ContainsKey("configs"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaMCPToolset
        {
            MCPServerName = "x",
            DefaultConfig = new() { DeferLoading = true, Enabled = true },

            CacheControl = null,
            Configs = null,
        };

        model.Validate();
    }
}
