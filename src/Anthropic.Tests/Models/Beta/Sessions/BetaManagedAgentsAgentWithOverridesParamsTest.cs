using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsAgentWithOverridesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type =
                        Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
            Version = 0,
        };

        string expectedID = "x";
        ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType> expectedType =
            BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides;
        List<Agents::BetaManagedAgentsUrlMcpServerParams> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Model expectedModel = new Agents::BetaManagedAgentsModelConfigParams()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
            Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        List<Agents::BetaManagedAgentsSkillParams> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkillParams()
            {
                SkillID = "xlsx",
                Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                Version = "1",
            },
        ];
        string expectedSystem = "system";
        List<Tool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401Params()
            {
                Type = Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                Configs =
                [
                    new()
                    {
                        Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            },
        ];
        int expectedVersion = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.McpServers);
        Assert.Equal(expectedMcpServers.Count, model.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], model.McpServers[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.NotNull(model.Skills);
        Assert.Equal(expectedSkills.Count, model.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], model.Skills[i]);
        }
        Assert.Equal(expectedSystem, model.System);
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type =
                        Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
            Version = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentWithOverridesParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type =
                        Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
            Version = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentWithOverridesParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "x";
        ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType> expectedType =
            BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides;
        List<Agents::BetaManagedAgentsUrlMcpServerParams> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Model expectedModel = new Agents::BetaManagedAgentsModelConfigParams()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
            Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        List<Agents::BetaManagedAgentsSkillParams> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkillParams()
            {
                SkillID = "xlsx",
                Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                Version = "1",
            },
        ];
        string expectedSystem = "system";
        List<Tool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401Params()
            {
                Type = Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                Configs =
                [
                    new()
                    {
                        Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            },
        ];
        int expectedVersion = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.McpServers);
        Assert.Equal(expectedMcpServers.Count, deserialized.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], deserialized.McpServers[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.NotNull(deserialized.Skills);
        Assert.Equal(expectedSkills.Count, deserialized.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], deserialized.Skills[i]);
        }
        Assert.Equal(expectedSystem, deserialized.System);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type =
                        Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            System = "system",
        };

        Assert.Null(model.McpServers);
        Assert.False(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Skills);
        Assert.False(model.RawData.ContainsKey("skills"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            System = "system",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            System = "system",

            // Null should be interpreted as omitted for these properties
            McpServers = null,
            Model = null,
            Skills = null,
            Tools = null,
            Version = null,
        };

        Assert.Null(model.McpServers);
        Assert.False(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Skills);
        Assert.False(model.RawData.ContainsKey("skills"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            System = "system",

            // Null should be interpreted as omitted for these properties
            McpServers = null,
            Model = null,
            Skills = null,
            Tools = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type =
                        Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
            Version = 0,
        };

        Assert.Null(model.System);
        Assert.False(model.RawData.ContainsKey("system"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type =
                        Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type =
                        Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
            Version = 0,

            System = null,
        };

        Assert.Null(model.System);
        Assert.True(model.RawData.ContainsKey("system"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type =
                        Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
            Version = 0,

            System = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentWithOverridesParams
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type =
                        Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
            Version = 0,
        };

        BetaManagedAgentsAgentWithOverridesParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentWithOverridesParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides)]
    public void Validation_Works(BetaManagedAgentsAgentWithOverridesParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentWithOverridesParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentWithOverridesParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ModelTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsValidationWorks()
    {
        Model value = Agents::BetaManagedAgentsModel.ClaudeSonnet5;
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelConfigParamsValidationWorks()
    {
        Model value = new Agents::BetaManagedAgentsModelConfigParams()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
            Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSerializationRoundtripWorks()
    {
        Model value = Agents::BetaManagedAgentsModel.ClaudeSonnet5;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsModelConfigParamsSerializationRoundtripWorks()
    {
        Model value = new Agents::BetaManagedAgentsModelConfigParams()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_8,
            Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ToolTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsValidationWorks()
    {
        Tool value = new Agents::BetaManagedAgentsAgentToolset20260401Params()
        {
            Type = Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
            Configs =
            [
                new()
                {
                    Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                    Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsValidationWorks()
    {
        Tool value = new Agents::BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Type = Agents::BetaManagedAgentsMcpToolsetParamsType.McpToolset,
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                    Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsValidationWorks()
    {
        Tool value = new Agents::BetaManagedAgentsCustomToolParams()
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
            },
            Name = "x",
            Type = Agents::BetaManagedAgentsCustomToolParamsType.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsSerializationRoundtripWorks()
    {
        Tool value = new Agents::BetaManagedAgentsAgentToolset20260401Params()
        {
            Type = Agents::BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
            Configs =
            [
                new()
                {
                    Name = Agents::BetaManagedAgentsAgentToolConfigParamsName.Bash,
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                    Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsSerializationRoundtripWorks()
    {
        Tool value = new Agents::BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Type = Agents::BetaManagedAgentsMcpToolsetParamsType.McpToolset,
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                    Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsSerializationRoundtripWorks()
    {
        Tool value = new Agents::BetaManagedAgentsCustomToolParams()
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
            },
            Name = "x",
            Type = Agents::BetaManagedAgentsCustomToolParamsType.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
