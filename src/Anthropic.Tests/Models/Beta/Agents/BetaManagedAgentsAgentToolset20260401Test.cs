using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolset20260401Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfig()
                {
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

        List<BetaManagedAgentsAgentToolConfig> expectedConfigs =
        [
            new BetaManagedAgentsBashToolConfig()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        ];
        BetaManagedAgentsAgentToolsetDefaultConfig expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent_toolset_20260401");

        Assert.Equal(expectedConfigs.Count, model.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], model.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, model.DefaultConfig);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfig()
                {
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfig()
                {
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsAgentToolConfig> expectedConfigs =
        [
            new BetaManagedAgentsBashToolConfig()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        ];
        BetaManagedAgentsAgentToolsetDefaultConfig expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent_toolset_20260401");

        Assert.Equal(expectedConfigs.Count, deserialized.Configs.Count);
        for (int i = 0; i < expectedConfigs.Count; i++)
        {
            Assert.Equal(expectedConfigs[i], deserialized.Configs[i]);
        }
        Assert.Equal(expectedDefaultConfig, deserialized.DefaultConfig);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfig()
                {
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
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfig()
                {
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

        BetaManagedAgentsAgentToolset20260401 copied = new(model);

        Assert.Equal(model, copied);
    }
}
