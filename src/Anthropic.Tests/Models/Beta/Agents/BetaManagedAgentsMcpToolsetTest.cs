using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            McpServerName = "mcp_server_name",
            Type = BetaManagedAgentsMcpToolsetType.McpToolset,
        };

        List<BetaManagedAgentsMcpToolConfig> expectedConfigs =
        [
            new()
            {
                Enabled = true,
                Name = "name",
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
        ];
        BetaManagedAgentsMcpToolsetDefaultConfig expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        string expectedMcpServerName = "mcp_server_name";
        ApiEnum<string, BetaManagedAgentsMcpToolsetType> expectedType =
            BetaManagedAgentsMcpToolsetType.McpToolset;

        Assert.Equal(expectedConfigs.Count, model.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], model.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, model.DefaultConfig);
        Assert.Equal(expectedMcpServerName, model.McpServerName);
        Assert.Equal(expectedType, model.Type);
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
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            McpServerName = "mcp_server_name",
            Type = BetaManagedAgentsMcpToolsetType.McpToolset,
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
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            McpServerName = "mcp_server_name",
            Type = BetaManagedAgentsMcpToolsetType.McpToolset,
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
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
        ];
        BetaManagedAgentsMcpToolsetDefaultConfig expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
            ),
        };
        string expectedMcpServerName = "mcp_server_name";
        ApiEnum<string, BetaManagedAgentsMcpToolsetType> expectedType =
            BetaManagedAgentsMcpToolsetType.McpToolset;

        Assert.Equal(expectedConfigs.Count, deserialized.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], deserialized.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, deserialized.DefaultConfig);
        Assert.Equal(expectedMcpServerName, deserialized.McpServerName);
        Assert.Equal(expectedType, deserialized.Type);
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
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            McpServerName = "mcp_server_name",
            Type = BetaManagedAgentsMcpToolsetType.McpToolset,
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
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            McpServerName = "mcp_server_name",
            Type = BetaManagedAgentsMcpToolsetType.McpToolset,
        };

        BetaManagedAgentsMcpToolset copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpToolsetTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpToolsetType.McpToolset)]
    public void Validation_Works(BetaManagedAgentsMcpToolsetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpToolsetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMcpToolsetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpToolsetType.McpToolset)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMcpToolsetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpToolsetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolsetType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMcpToolsetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolsetType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
