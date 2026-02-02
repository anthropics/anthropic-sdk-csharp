using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMcpToolsetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };

        string expectedMcpServerName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_toolset");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        Dictionary<string, BetaMcpToolConfig> expectedConfigs = new()
        {
            {
                "foo",
                new() { DeferLoading = true, Enabled = true }
            },
        };
        BetaMcpToolDefaultConfig expectedDefaultConfig = new()
        {
            DeferLoading = true,
            Enabled = true,
        };

        Assert.Equal(expectedMcpServerName, model.McpServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.NotNull(model.Configs);
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
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolset>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolset>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMcpServerName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_toolset");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        Dictionary<string, BetaMcpToolConfig> expectedConfigs = new()
        {
            {
                "foo",
                new() { DeferLoading = true, Enabled = true }
            },
        };
        BetaMcpToolDefaultConfig expectedDefaultConfig = new()
        {
            DeferLoading = true,
            Enabled = true,
        };

        Assert.Equal(expectedMcpServerName, deserialized.McpServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.NotNull(deserialized.Configs);
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
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
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
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
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
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
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
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
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
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
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
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
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
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
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
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            DefaultConfig = new() { DeferLoading = true, Enabled = true },

            CacheControl = null,
            Configs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMcpToolset
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };

        BetaMcpToolset copied = new(model);

        Assert.Equal(model, copied);
    }
}
