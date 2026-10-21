using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolset20260401ParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("agent_toolset_20260401");
        List<BetaManagedAgentsAgentToolConfigParams> expectedConfigs =
        [
            new BetaManagedAgentsBashToolConfigParams()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                Type = Type.Bash,
            },
        ];
        BetaManagedAgentsAgentToolsetDefaultConfigParams expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

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
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401Params>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401Params>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("agent_toolset_20260401");
        List<BetaManagedAgentsAgentToolConfigParams> expectedConfigs =
        [
            new BetaManagedAgentsBashToolConfigParams()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                Type = Type.Bash,
            },
        ];
        BetaManagedAgentsAgentToolsetDefaultConfigParams expectedDefaultConfig = new()
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

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
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
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
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
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
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
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
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
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
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
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
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
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
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
                },
            ],
        };

        Assert.Null(model.DefaultConfig);
        Assert.False(model.RawData.ContainsKey("default_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
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
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
                },
            ],

            DefaultConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401Params
        {
            Configs =
            [
                new BetaManagedAgentsBashToolConfigParams()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    Type = Type.Bash,
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };

        BetaManagedAgentsAgentToolset20260401Params copied = new(model);

        Assert.Equal(model, copied);
    }
}
