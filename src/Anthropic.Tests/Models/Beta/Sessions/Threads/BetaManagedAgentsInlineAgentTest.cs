using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Threads;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads;

public class BetaManagedAgentsInlineAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5,
                Effort = new Agents::BetaManagedAgentsEffortLow(
                    Agents::BetaManagedAgentsEffortLowType.Low
                ),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
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
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
        };

        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5,
            Effort = new Agents::BetaManagedAgentsEffortLow(
                Agents::BetaManagedAgentsEffortLowType.Low
            ),
            InferenceGeo = "inference_geo",
            Speed = Agents::Speed.Standard,
        };
        string expectedName = "pdf-reader-3";
        List<Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
        ];
        string expectedSystem = "You extract tables precisely. Output CSV only.";
        List<Tool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new Agents::BetaManagedAgentsBashToolConfig()
                    {
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
                Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("inline");

        Assert.Null(model.Description);
        Assert.Equal(expectedMcpServers.Count, model.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], model.McpServers[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSkills.Count, model.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], model.Skills[i]);
        }
        Assert.Equal(expectedSystem, model.System);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5,
                Effort = new Agents::BetaManagedAgentsEffortLow(
                    Agents::BetaManagedAgentsEffortLowType.Low
                ),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
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
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsInlineAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5,
                Effort = new Agents::BetaManagedAgentsEffortLow(
                    Agents::BetaManagedAgentsEffortLowType.Low
                ),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
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
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsInlineAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5,
            Effort = new Agents::BetaManagedAgentsEffortLow(
                Agents::BetaManagedAgentsEffortLowType.Low
            ),
            InferenceGeo = "inference_geo",
            Speed = Agents::Speed.Standard,
        };
        string expectedName = "pdf-reader-3";
        List<Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
        ];
        string expectedSystem = "You extract tables precisely. Output CSV only.";
        List<Tool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new Agents::BetaManagedAgentsBashToolConfig()
                    {
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
                Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("inline");

        Assert.Null(deserialized.Description);
        Assert.Equal(expectedMcpServers.Count, deserialized.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], deserialized.McpServers[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSkills.Count, deserialized.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], deserialized.Skills[i]);
        }
        Assert.Equal(expectedSystem, deserialized.System);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5,
                Effort = new Agents::BetaManagedAgentsEffortLow(
                    Agents::BetaManagedAgentsEffortLowType.Low
                ),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
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
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5,
                Effort = new Agents::BetaManagedAgentsEffortLow(
                    Agents::BetaManagedAgentsEffortLowType.Low
                ),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
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
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
        };

        BetaManagedAgentsInlineAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SkillTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAnthropicValidationWorks()
    {
        Skill value = new Agents::BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        Skill value = new Agents::BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAnthropicSerializationRoundtripWorks()
    {
        Skill value = new Agents::BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        Skill value = new Agents::BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Skill value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "skill_id": "xlsx",
                  "version": "1"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedSkillID = "xlsx";
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, value.SkillID);
        Assert.Equal(expectedVersion, value.Version);

        Skill emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.SkillID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Version);

        Skill mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "skill_id": [
                    "invalid"
                  ],
                  "version": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.SkillID);
        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Version);
    }
}

public class ToolTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ValidationWorks()
    {
        Tool value = new Agents::BetaManagedAgentsAgentToolset20260401()
        {
            Configs =
            [
                new Agents::BetaManagedAgentsBashToolConfig()
                {
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
            Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetValidationWorks()
    {
        Tool value = new Agents::BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
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
            McpServerName = "mcp_server_name",
            Type = Agents::BetaManagedAgentsMcpToolsetType.McpToolset,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        Tool value = new Agents::BetaManagedAgentsCustomTool()
        {
            Description = "description",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
            },
            Name = "name",
            Type = Agents::BetaManagedAgentsCustomToolType.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401SerializationRoundtripWorks()
    {
        Tool value = new Agents::BetaManagedAgentsAgentToolset20260401()
        {
            Configs =
            [
                new Agents::BetaManagedAgentsBashToolConfig()
                {
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
            Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetSerializationRoundtripWorks()
    {
        Tool value = new Agents::BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
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
            McpServerName = "mcp_server_name",
            Type = Agents::BetaManagedAgentsMcpToolsetType.McpToolset,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        Tool value = new Agents::BetaManagedAgentsCustomTool()
        {
            Description = "description",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
            },
            Name = "name",
            Type = Agents::BetaManagedAgentsCustomToolType.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
