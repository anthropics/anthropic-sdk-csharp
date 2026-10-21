using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMcpToolsetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpToolset
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };

        List<BetaManagedAgentsMcpToolConfig> expectedConfigs =
        [
            new()
            {
                Enabled = true,
                Name = "name",
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        ];
        BetaManagedAgentsMcpToolsetDefaultConfig expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        string expectedMcpServerName = "mcp_server_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_toolset");

        Assert.Equal(expectedConfigs.Count, model.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], model.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, model.DefaultConfig);
        Assert.Equal(expectedMcpServerName, model.McpServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpToolset
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpToolset>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpToolset
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpToolset>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsMcpToolConfig> expectedConfigs =
        [
            new()
            {
                Enabled = true,
                Name = "name",
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        ];
        BetaManagedAgentsMcpToolsetDefaultConfig expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        string expectedMcpServerName = "mcp_server_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_toolset");

        Assert.Equal(expectedConfigs.Count, deserialized.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], deserialized.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, deserialized.DefaultConfig);
        Assert.Equal(expectedMcpServerName, deserialized.McpServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpToolset
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpToolset
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };

        BetaManagedAgentsMcpToolset copied = new(model);

        Assert.Equal(model, copied);
    }
}
