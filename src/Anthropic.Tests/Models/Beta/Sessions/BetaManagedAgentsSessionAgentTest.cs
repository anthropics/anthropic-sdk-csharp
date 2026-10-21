using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                [
                    new Agents::BetaManagedAgentsSessionThreadAgent()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity =
                            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                        McpServers =
                        [
                            new()
                            {
                                Name = "example-mcp",
                                Url = "https://example-server.modelcontextprotocol.io/sse",
                            },
                        ],
                        Model = new()
                        {
                            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new Agents::BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Agents::Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new Agents::BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
                                Version = "1",
                            },
                        ],
                        System =
                            "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                        Tools =
                        [
                            new Agents::BetaManagedAgentsAgentToolset20260401()
                            {
                                Configs =
                                [
                                    new Agents::BetaManagedAgentsBashToolConfig()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ]
            ),
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };

        string expectedID = "agent_011CZkYpogX7uDKUyvBTophP";
        string expectedDescription = "A general-purpose starter agent.";
        Agents::BetaManagedAgentsExecutionIdentity expectedExecutionIdentity =
            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity();
        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new Agents::BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Agents::Speed.Standard,
        };
        BetaManagedAgentsSessionMultiagent expectedMultiagent =
            new BetaManagedAgentsSessionMultiagentCoordinator(
                [
                    new Agents::BetaManagedAgentsSessionThreadAgent()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity =
                            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                        McpServers =
                        [
                            new()
                            {
                                Name = "example-mcp",
                                Url = "https://example-server.modelcontextprotocol.io/sse",
                            },
                        ],
                        Model = new()
                        {
                            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new Agents::BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Agents::Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new Agents::BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
                                Version = "1",
                            },
                        ],
                        System =
                            "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                        Tools =
                        [
                            new Agents::BetaManagedAgentsAgentToolset20260401()
                            {
                                Configs =
                                [
                                    new Agents::BetaManagedAgentsBashToolConfig()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ]
            );
        string expectedName = "My First Agent";
        List<Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            new Agents::BetaManagedAgentsCustomSkill()
            {
                SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                Version = "2",
            },
        ];
        string expectedSystem =
            "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.";
        List<BetaManagedAgentsSessionAgentTool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new Agents::BetaManagedAgentsBashToolConfig()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                },
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");
        int expectedVersion = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExecutionIdentity, model.ExecutionIdentity);
        Assert.Equal(expectedMcpServers.Count, model.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], model.McpServers[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedMultiagent, model.Multiagent);
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
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                [
                    new Agents::BetaManagedAgentsSessionThreadAgent()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity =
                            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                        McpServers =
                        [
                            new()
                            {
                                Name = "example-mcp",
                                Url = "https://example-server.modelcontextprotocol.io/sse",
                            },
                        ],
                        Model = new()
                        {
                            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new Agents::BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Agents::Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new Agents::BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
                                Version = "1",
                            },
                        ],
                        System =
                            "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                        Tools =
                        [
                            new Agents::BetaManagedAgentsAgentToolset20260401()
                            {
                                Configs =
                                [
                                    new Agents::BetaManagedAgentsBashToolConfig()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ]
            ),
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                [
                    new Agents::BetaManagedAgentsSessionThreadAgent()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity =
                            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                        McpServers =
                        [
                            new()
                            {
                                Name = "example-mcp",
                                Url = "https://example-server.modelcontextprotocol.io/sse",
                            },
                        ],
                        Model = new()
                        {
                            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new Agents::BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Agents::Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new Agents::BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
                                Version = "1",
                            },
                        ],
                        System =
                            "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                        Tools =
                        [
                            new Agents::BetaManagedAgentsAgentToolset20260401()
                            {
                                Configs =
                                [
                                    new Agents::BetaManagedAgentsBashToolConfig()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ]
            ),
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "agent_011CZkYpogX7uDKUyvBTophP";
        string expectedDescription = "A general-purpose starter agent.";
        Agents::BetaManagedAgentsExecutionIdentity expectedExecutionIdentity =
            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity();
        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new Agents::BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Agents::Speed.Standard,
        };
        BetaManagedAgentsSessionMultiagent expectedMultiagent =
            new BetaManagedAgentsSessionMultiagentCoordinator(
                [
                    new Agents::BetaManagedAgentsSessionThreadAgent()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity =
                            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                        McpServers =
                        [
                            new()
                            {
                                Name = "example-mcp",
                                Url = "https://example-server.modelcontextprotocol.io/sse",
                            },
                        ],
                        Model = new()
                        {
                            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new Agents::BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Agents::Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new Agents::BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
                                Version = "1",
                            },
                        ],
                        System =
                            "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                        Tools =
                        [
                            new Agents::BetaManagedAgentsAgentToolset20260401()
                            {
                                Configs =
                                [
                                    new Agents::BetaManagedAgentsBashToolConfig()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ]
            );
        string expectedName = "My First Agent";
        List<Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            new Agents::BetaManagedAgentsCustomSkill()
            {
                SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                Version = "2",
            },
        ];
        string expectedSystem =
            "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.";
        List<BetaManagedAgentsSessionAgentTool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new Agents::BetaManagedAgentsBashToolConfig()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                },
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");
        int expectedVersion = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExecutionIdentity, deserialized.ExecutionIdentity);
        Assert.Equal(expectedMcpServers.Count, deserialized.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], deserialized.McpServers[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedMultiagent, deserialized.Multiagent);
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
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                [
                    new Agents::BetaManagedAgentsSessionThreadAgent()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity =
                            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                        McpServers =
                        [
                            new()
                            {
                                Name = "example-mcp",
                                Url = "https://example-server.modelcontextprotocol.io/sse",
                            },
                        ],
                        Model = new()
                        {
                            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new Agents::BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Agents::Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new Agents::BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
                                Version = "1",
                            },
                        ],
                        System =
                            "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                        Tools =
                        [
                            new Agents::BetaManagedAgentsAgentToolset20260401()
                            {
                                Configs =
                                [
                                    new Agents::BetaManagedAgentsBashToolConfig()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ]
            ),
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                [
                    new Agents::BetaManagedAgentsSessionThreadAgent()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity =
                            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                        McpServers =
                        [
                            new()
                            {
                                Name = "example-mcp",
                                Url = "https://example-server.modelcontextprotocol.io/sse",
                            },
                        ],
                        Model = new()
                        {
                            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new Agents::BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Agents::Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new Agents::BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
                                Version = "1",
                            },
                        ],
                        System =
                            "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                        Tools =
                        [
                            new Agents::BetaManagedAgentsAgentToolset20260401()
                            {
                                Configs =
                                [
                                    new Agents::BetaManagedAgentsBashToolConfig()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ]
            ),
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };

        BetaManagedAgentsSessionAgent copied = new(model);

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
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAnthropicTypeWorks()
    {
        Skill value = new Agents::BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Version = "1",
        };
        Assert.Equal(SkillType.Anthropic, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomTypeWorks()
    {
        Skill value = new Agents::BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };
        Assert.Equal(SkillType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Skill value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "skill_id": "xlsx",
                  "type": "anthropic",
                  "version": "1"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedSkillID = "xlsx";
        ApiEnum<string, SkillType> expectedType = SkillType.Anthropic;
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, value.SkillID);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedVersion, value.Version);

        Skill emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.SkillID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
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

public class SkillTypeTest : TestBase
{
    [Theory]
    [InlineData(SkillType.Anthropic)]
    [InlineData(SkillType.Custom)]
    public void Validation_Works(SkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SkillType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SkillType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SkillType.Anthropic)]
    [InlineData(SkillType.Custom)]
    public void SerializationRoundtrip_Works(SkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SkillType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SkillType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SkillType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SkillType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsSessionAgentToolTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ValidationWorks()
    {
        BetaManagedAgentsSessionAgentTool value =
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new Agents::BetaManagedAgentsBashToolConfig()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetValidationWorks()
    {
        BetaManagedAgentsSessionAgentTool value = new Agents::BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        BetaManagedAgentsSessionAgentTool value = new Agents::BetaManagedAgentsCustomTool()
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
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401SerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionAgentTool value =
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new Agents::BetaManagedAgentsBashToolConfig()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionAgentTool value = new Agents::BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionAgentTool value = new Agents::BetaManagedAgentsCustomTool()
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401TypeWorks()
    {
        BetaManagedAgentsSessionAgentTool value =
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new Agents::BetaManagedAgentsBashToolConfig()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            };
        Assert.Equal(
            BetaManagedAgentsSessionAgentToolType.AgentToolset20260401,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetTypeWorks()
    {
        BetaManagedAgentsSessionAgentTool value = new Agents::BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };
        Assert.Equal(BetaManagedAgentsSessionAgentToolType.McpToolset, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomTypeWorks()
    {
        BetaManagedAgentsSessionAgentTool value = new Agents::BetaManagedAgentsCustomTool()
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
        };
        Assert.Equal(BetaManagedAgentsSessionAgentToolType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSessionAgentTool value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "agent_toolset_20260401"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsSessionAgentToolType> expectedType =
            BetaManagedAgentsSessionAgentToolType.AgentToolset20260401;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsSessionAgentTool emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsSessionAgentToolTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionAgentToolType.AgentToolset20260401)]
    [InlineData(BetaManagedAgentsSessionAgentToolType.McpToolset)]
    [InlineData(BetaManagedAgentsSessionAgentToolType.Custom)]
    public void Validation_Works(BetaManagedAgentsSessionAgentToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionAgentToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionAgentToolType.AgentToolset20260401)]
    [InlineData(BetaManagedAgentsSessionAgentToolType.McpToolset)]
    [InlineData(BetaManagedAgentsSessionAgentToolType.Custom)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionAgentToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionAgentToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
