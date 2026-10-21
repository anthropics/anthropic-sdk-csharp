using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMcpToolsetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        string expectedMcpServerName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_toolset");
        List<BetaManagedAgentsMcpToolConfigParams> expectedConfigs =
        [
            new()
            {
                Name = "x",
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        ];
        BetaManagedAgentsMcpToolsetDefaultConfigParams expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        Assert.Equal(expectedMcpServerName, model.McpServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Configs);
        Assert.Equal(expectedConfigs.Count, model.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], model.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, model.DefaultConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpToolsetParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpToolsetParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMcpServerName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_toolset");
        List<BetaManagedAgentsMcpToolConfigParams> expectedConfigs =
        [
            new()
            {
                Name = "x",
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        ];
        BetaManagedAgentsMcpToolsetDefaultConfigParams expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        Assert.Equal(expectedMcpServerName, deserialized.McpServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Configs);
        Assert.Equal(expectedConfigs.Count, deserialized.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], deserialized.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, deserialized.DefaultConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        Assert.Null(model.Configs);
        Assert.False(model.RawData.ContainsKey("configs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },

            // Null should be interpreted as omitted for these properties
            Configs = null,
        };

        Assert.Null(model.Configs);
        Assert.False(model.RawData.ContainsKey("configs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        } with
        {
            // Null should be interpreted as omitted for these properties
            Configs = null,
        };

        Assert.Null(model.Configs);
        Assert.False(model.RawData.ContainsKey("configs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },

            // Null should be interpreted as omitted for these properties
            Configs = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
        };

        Assert.Null(model.DefaultConfig);
        Assert.False(model.RawData.ContainsKey("default_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],

            DefaultConfig = null,
        };

        Assert.Null(model.DefaultConfig);
        Assert.True(model.RawData.ContainsKey("default_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],

            DefaultConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetParams
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        BetaManagedAgentsMcpToolsetParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
