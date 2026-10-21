using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Sessions = Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsMultiagent20261001()
            {
                Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
                Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
                Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        string expectedID = "agent_011CZkYpogX7uDKUyvBTophP";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedDescription = "A general-purpose starter agent.";
        BetaManagedAgentsExecutionIdentity expectedExecutionIdentity =
            new BetaManagedAgentsServiceAccountExecutionIdentity();
        List<BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "bar" } };
        BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };
        Sessions::BetaManagedAgentsMultiagent expectedMultiagent =
            new BetaManagedAgentsMultiagent20261001()
            {
                Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
                Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
                Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
            };
        string expectedName = "My First Agent";
        List<Skill> expectedSkills =
        [
            new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            new BetaManagedAgentsCustomSkill()
            {
                SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                Version = "2",
            },
        ];
        string expectedSystem =
            "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.";
        List<BetaManagedAgentsAgentTool> expectedTools =
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
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        int expectedVersion = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.Null(model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExecutionIdentity, model.ExecutionIdentity);
        Assert.Equal(expectedMcpServers.Count, model.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], model.McpServers[i]);
        }
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
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
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsMultiagent20261001()
            {
                Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
                Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
                Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsMultiagent20261001()
            {
                Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
                Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
                Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "agent_011CZkYpogX7uDKUyvBTophP";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedDescription = "A general-purpose starter agent.";
        BetaManagedAgentsExecutionIdentity expectedExecutionIdentity =
            new BetaManagedAgentsServiceAccountExecutionIdentity();
        List<BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "bar" } };
        BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };
        Sessions::BetaManagedAgentsMultiagent expectedMultiagent =
            new BetaManagedAgentsMultiagent20261001()
            {
                Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
                Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
                Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
            };
        string expectedName = "My First Agent";
        List<Skill> expectedSkills =
        [
            new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            new BetaManagedAgentsCustomSkill()
            {
                SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                Version = "2",
            },
        ];
        string expectedSystem =
            "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.";
        List<BetaManagedAgentsAgentTool> expectedTools =
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
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        int expectedVersion = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Null(deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExecutionIdentity, deserialized.ExecutionIdentity);
        Assert.Equal(expectedMcpServers.Count, deserialized.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], deserialized.McpServers[i]);
        }
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
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
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsMultiagent20261001()
            {
                Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
                Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
                Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsMultiagent20261001()
            {
                Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
                Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
                Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
                {
                    InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                    PredefinedAgents =
                    [
                        new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    ],
                },
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                    Version = "2",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        BetaManagedAgentsAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SkillTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAnthropicValidationWorks()
    {
        Skill value = new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        Skill value = new BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAnthropicSerializationRoundtripWorks()
    {
        Skill value = new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        Skill value = new BetaManagedAgentsCustomSkill()
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
        Skill value = new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" };
        Assert.Equal(SkillType.Anthropic, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomTypeWorks()
    {
        Skill value = new BetaManagedAgentsCustomSkill()
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

public class BetaManagedAgentsAgentToolTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ValidationWorks()
    {
        BetaManagedAgentsAgentTool value = new BetaManagedAgentsAgentToolset20260401()
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
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetValidationWorks()
    {
        BetaManagedAgentsAgentTool value = new BetaManagedAgentsMcpToolset()
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
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        BetaManagedAgentsAgentTool value = new BetaManagedAgentsCustomTool()
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
        BetaManagedAgentsAgentTool value = new BetaManagedAgentsAgentToolset20260401()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentTool value = new BetaManagedAgentsMcpToolset()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentTool value = new BetaManagedAgentsCustomTool()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401TypeWorks()
    {
        BetaManagedAgentsAgentTool value = new BetaManagedAgentsAgentToolset20260401()
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
        Assert.Equal(BetaManagedAgentsAgentToolType.AgentToolset20260401, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetTypeWorks()
    {
        BetaManagedAgentsAgentTool value = new BetaManagedAgentsMcpToolset()
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
        Assert.Equal(BetaManagedAgentsAgentToolType.McpToolset, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomTypeWorks()
    {
        BetaManagedAgentsAgentTool value = new BetaManagedAgentsCustomTool()
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
        Assert.Equal(BetaManagedAgentsAgentToolType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentTool value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "agent_toolset_20260401"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsAgentToolType> expectedType =
            BetaManagedAgentsAgentToolType.AgentToolset20260401;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsAgentTool emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsAgentToolTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentToolType.AgentToolset20260401)]
    [InlineData(BetaManagedAgentsAgentToolType.McpToolset)]
    [InlineData(BetaManagedAgentsAgentToolType.Custom)]
    public void Validation_Works(BetaManagedAgentsAgentToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsAgentToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentToolType.AgentToolset20260401)]
    [InlineData(BetaManagedAgentsAgentToolType.McpToolset)]
    [InlineData(BetaManagedAgentsAgentToolType.Custom)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsAgentToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
