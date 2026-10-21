using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionMultiagent20261001Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagent20261001
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorEnabled("claude-opus-5-5"),
            Subagents = new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
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
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ],
            },
        };

        BetaManagedAgentsMultiagentAdvisor expectedAdvisor =
            new BetaManagedAgentsMultiagentAdvisorEnabled("claude-opus-5-5");
        BetaManagedAgentsSessionMultiagentSubagents expectedSubagents =
            new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ],
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("multiagent_20261001");
        BetaManagedAgentsSessionMultiagentWorkflows expectedWorkflows =
            new BetaManagedAgentsSessionMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ],
            };

        Assert.Equal(expectedAdvisor, model.Advisor);
        Assert.Equal(expectedSubagents, model.Subagents);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkflows, model.Workflows);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagent20261001
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorEnabled("claude-opus-5-5"),
            Subagents = new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
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
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagent20261001>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagent20261001
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorEnabled("claude-opus-5-5"),
            Subagents = new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
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
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagent20261001>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsMultiagentAdvisor expectedAdvisor =
            new BetaManagedAgentsMultiagentAdvisorEnabled("claude-opus-5-5");
        BetaManagedAgentsSessionMultiagentSubagents expectedSubagents =
            new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ],
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("multiagent_20261001");
        BetaManagedAgentsSessionMultiagentWorkflows expectedWorkflows =
            new BetaManagedAgentsSessionMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ],
            };

        Assert.Equal(expectedAdvisor, deserialized.Advisor);
        Assert.Equal(expectedSubagents, deserialized.Subagents);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkflows, deserialized.Workflows);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagent20261001
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorEnabled("claude-opus-5-5"),
            Subagents = new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
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
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagent20261001
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorEnabled("claude-opus-5-5"),
            Subagents = new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Description = "A focused research subagent.",
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
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
                        ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                            Effort = new BetaManagedAgentsEffortLow(),
                            InferenceGeo = "inference_geo",
                            Speed = Speed.Standard,
                        },
                        Name = "Researcher",
                        Skills =
                        [
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
                                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                    },
                                ],
                                DefaultConfig = new()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                                },
                            },
                        ],
                        Version = 1,
                    },
                ],
            },
        };

        BetaManagedAgentsSessionMultiagent20261001 copied = new(model);

        Assert.Equal(model, copied);
    }
}
