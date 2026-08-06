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
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new()
            {
                Agents =
                [
                    new BetaManagedAgentsAgentReference()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                ],
                Type = Sessions::BetaManagedAgentsMultiagentType.Coordinator,
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Name.Bash,
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
            Type = BetaManagedAgentsAgentType.Agent,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        string expectedID = "agent_011CZkYpogX7uDKUyvBTophP";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedDescription = "A general-purpose starter agent.";
        List<BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "bar" } };
        BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };
        Sessions::BetaManagedAgentsMultiagent expectedMultiagent = new()
        {
            Agents =
            [
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
            ],
            Type = Sessions::BetaManagedAgentsMultiagentType.Coordinator,
        };
        string expectedName = "My First Agent";
        List<Skill> expectedSkills =
        [
            new BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
            new BetaManagedAgentsCustomSkill()
            {
                SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                Type = BetaManagedAgentsCustomSkillType.Custom,
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
                    new()
                    {
                        Enabled = true,
                        Name = Name.Bash,
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
        ];
        ApiEnum<string, BetaManagedAgentsAgentType> expectedType = BetaManagedAgentsAgentType.Agent;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        int expectedVersion = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.Null(model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
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
        Assert.Equal(expectedType, model.Type);
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
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new()
            {
                Agents =
                [
                    new BetaManagedAgentsAgentReference()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                ],
                Type = Sessions::BetaManagedAgentsMultiagentType.Coordinator,
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Name.Bash,
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
            Type = BetaManagedAgentsAgentType.Agent,
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
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new()
            {
                Agents =
                [
                    new BetaManagedAgentsAgentReference()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                ],
                Type = Sessions::BetaManagedAgentsMultiagentType.Coordinator,
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Name.Bash,
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
            Type = BetaManagedAgentsAgentType.Agent,
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
        List<BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "bar" } };
        BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };
        Sessions::BetaManagedAgentsMultiagent expectedMultiagent = new()
        {
            Agents =
            [
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
            ],
            Type = Sessions::BetaManagedAgentsMultiagentType.Coordinator,
        };
        string expectedName = "My First Agent";
        List<Skill> expectedSkills =
        [
            new BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
            new BetaManagedAgentsCustomSkill()
            {
                SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                Type = BetaManagedAgentsCustomSkillType.Custom,
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
                    new()
                    {
                        Enabled = true,
                        Name = Name.Bash,
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
        ];
        ApiEnum<string, BetaManagedAgentsAgentType> expectedType = BetaManagedAgentsAgentType.Agent;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        int expectedVersion = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Null(deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
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
        Assert.Equal(expectedType, deserialized.Type);
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
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new()
            {
                Agents =
                [
                    new BetaManagedAgentsAgentReference()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                ],
                Type = Sessions::BetaManagedAgentsMultiagentType.Coordinator,
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Name.Bash,
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
            Type = BetaManagedAgentsAgentType.Agent,
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
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                Effort = new BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLowType.Low),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new()
            {
                Agents =
                [
                    new BetaManagedAgentsAgentReference()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                ],
                Type = Sessions::BetaManagedAgentsMultiagentType.Coordinator,
            },
            Name = "My First Agent",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Name.Bash,
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
            Type = BetaManagedAgentsAgentType.Agent,
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
        Skill value = new BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        Skill value = new BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAnthropicSerializationRoundtripWorks()
    {
        Skill value = new BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        Skill value = new BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);

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
                new()
                {
                    Enabled = true,
                    Name = Name.Bash,
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
            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
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
            Type = BetaManagedAgentsCustomToolType.Custom,
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
                new()
                {
                    Enabled = true,
                    Name = Name.Bash,
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
            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
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
            Type = BetaManagedAgentsCustomToolType.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsAgentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentType.Agent)]
    public void Validation_Works(BetaManagedAgentsAgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsAgentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentType.Agent)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsAgentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsAgentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsAgentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
