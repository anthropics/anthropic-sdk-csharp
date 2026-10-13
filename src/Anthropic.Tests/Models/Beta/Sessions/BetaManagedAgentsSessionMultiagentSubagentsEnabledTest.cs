using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionMultiagentSubagentsEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentSubagentsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
            PredefinedAgents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
                        Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
        };

        BetaManagedAgentsMultiagentInlineAgents expectedInlineAgents =
            new BetaManagedAgentsMultiagentInlineAgentsEnabled();
        List<BetaManagedAgentsSessionThreadAgent> expectedPredefinedAgents =
        [
            new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5,
                    Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                        Version = "1",
                    },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                ),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                            ),
                        },
                        Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                    },
                ],
                Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                Version = 1,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedInlineAgents, model.InlineAgents);
        Assert.Equal(expectedPredefinedAgents.Count, model.PredefinedAgents.Count);
        for (int i = 0; i < expectedPredefinedAgents.Count; i++)
        {
            Assert.Equal(expectedPredefinedAgents[i], model.PredefinedAgents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentSubagentsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
            PredefinedAgents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
                        Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentSubagentsEnabled>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentSubagentsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
            PredefinedAgents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
                        Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentSubagentsEnabled>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        BetaManagedAgentsMultiagentInlineAgents expectedInlineAgents =
            new BetaManagedAgentsMultiagentInlineAgentsEnabled();
        List<BetaManagedAgentsSessionThreadAgent> expectedPredefinedAgents =
        [
            new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5,
                    Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                        Version = "1",
                    },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                ),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                            ),
                        },
                        Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                    },
                ],
                Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                Version = 1,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedInlineAgents, deserialized.InlineAgents);
        Assert.Equal(expectedPredefinedAgents.Count, deserialized.PredefinedAgents.Count);
        for (int i = 0; i < expectedPredefinedAgents.Count; i++)
        {
            Assert.Equal(expectedPredefinedAgents[i], deserialized.PredefinedAgents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentSubagentsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
            PredefinedAgents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
                        Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentSubagentsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
            PredefinedAgents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
                        Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
        };

        BetaManagedAgentsSessionMultiagentSubagentsEnabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
