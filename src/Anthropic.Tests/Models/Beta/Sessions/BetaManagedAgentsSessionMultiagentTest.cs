using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionMultiagentTest : TestBase
{
    [Fact]
    public void CoordinatorValidationWorks()
    {
        BetaManagedAgentsSessionMultiagent value =
            new BetaManagedAgentsSessionMultiagentCoordinator()
            {
                Agents =
                [
                    new BetaManagedAgentsSessionThreadAgent()
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
                            Effort = new BetaManagedAgentsEffortLow(
                                BetaManagedAgentsEffortLowType.Low
                            ),
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                        Version = 1,
                    },
                ],
                Type = BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
            };
        value.Validate();
    }

    [Fact]
    public void Multiagent20261001ValidationWorks()
    {
        BetaManagedAgentsSessionMultiagent value = new BetaManagedAgentsSessionMultiagent20261001()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorEnabled("claude-fable-5"),
            Subagents = new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
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
                            Effort = new BetaManagedAgentsEffortLow(
                                BetaManagedAgentsEffortLowType.Low
                            ),
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                        Version = 1,
                    },
                ],
            },
            Workflows = new BetaManagedAgentsSessionMultiagentWorkflowsEnabled()
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
                            Effort = new BetaManagedAgentsEffortLow(
                                BetaManagedAgentsEffortLowType.Low
                            ),
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                        Version = 1,
                    },
                ],
            },
        };
        value.Validate();
    }

    [Fact]
    public void CoordinatorSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionMultiagent value =
            new BetaManagedAgentsSessionMultiagentCoordinator()
            {
                Agents =
                [
                    new BetaManagedAgentsSessionThreadAgent()
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
                            Effort = new BetaManagedAgentsEffortLow(
                                BetaManagedAgentsEffortLowType.Low
                            ),
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                        Version = 1,
                    },
                ],
                Type = BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Multiagent20261001SerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionMultiagent value = new BetaManagedAgentsSessionMultiagent20261001()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorEnabled("claude-fable-5"),
            Subagents = new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
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
                            Effort = new BetaManagedAgentsEffortLow(
                                BetaManagedAgentsEffortLowType.Low
                            ),
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                        Version = 1,
                    },
                ],
            },
            Workflows = new BetaManagedAgentsSessionMultiagentWorkflowsEnabled()
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
                            Effort = new BetaManagedAgentsEffortLow(
                                BetaManagedAgentsEffortLowType.Low
                            ),
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                        Version = 1,
                    },
                ],
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
