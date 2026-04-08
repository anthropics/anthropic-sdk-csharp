using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Agents::BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(
                            Agents::BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = Agents::Type.Agent,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        string expectedID = "agent_011CZkYpogX7uDKUyvBTophP";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedDescription = "A general-purpose starter agent.";
        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "bar" } };
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
            Speed = Agents::Speed.Standard,
        };
        string expectedName = "My First Agent";
        List<Agents::Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
            new Agents::BetaManagedAgentsCustomSkill()
            {
                SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
                Version = "2",
            },
        ];
        string expectedSystem =
            "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.";
        List<Agents::BetaManagedAgentsAgentTool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new()
                    {
                        Enabled = true,
                        Name = Agents::Name.Bash,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(
                        Agents::BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                    ),
                },
                Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
            },
        ];
        ApiEnum<string, Agents::Type> expectedType = Agents::Type.Agent;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        int expectedVersion = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
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
        var model = new Agents::BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(
                            Agents::BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = Agents::Type.Agent,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::BetaManagedAgentsAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Agents::BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(
                            Agents::BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = Agents::Type.Agent,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::BetaManagedAgentsAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "agent_011CZkYpogX7uDKUyvBTophP";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedDescription = "A general-purpose starter agent.";
        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "bar" } };
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
            Speed = Agents::Speed.Standard,
        };
        string expectedName = "My First Agent";
        List<Agents::Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
            new Agents::BetaManagedAgentsCustomSkill()
            {
                SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
                Version = "2",
            },
        ];
        string expectedSystem =
            "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.";
        List<Agents::BetaManagedAgentsAgentTool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new()
                    {
                        Enabled = true,
                        Name = Agents::Name.Bash,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(
                        Agents::BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                    ),
                },
                Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
            },
        ];
        ApiEnum<string, Agents::Type> expectedType = Agents::Type.Agent;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        int expectedVersion = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
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
        var model = new Agents::BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(
                            Agents::BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = Agents::Type.Agent,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Agents::BetaManagedAgentsAgent
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "A general-purpose starter agent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "My First Agent",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
                new Agents::BetaManagedAgentsCustomSkill()
                {
                    SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
                    Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
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
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(
                            Agents::BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = Agents::Type.Agent,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Version = 1,
        };

        Agents::BetaManagedAgentsAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SkillTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAnthropicValidationWorks()
    {
        Agents::Skill value = new Agents::BetaManagedAgentsAnthropicSkill()
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
        Agents::Skill value = new Agents::BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAnthropicSerializationRoundtripWorks()
    {
        Agents::Skill value = new Agents::BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::Skill>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        Agents::Skill value = new Agents::BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::Skill>(
            element,
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
        Agents::BetaManagedAgentsAgentTool value =
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new()
                    {
                        Enabled = true,
                        Name = Agents::Name.Bash,
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
        Agents::BetaManagedAgentsAgentTool value = new Agents::BetaManagedAgentsMcpToolset()
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
        Agents::BetaManagedAgentsAgentTool value = new Agents::BetaManagedAgentsCustomTool()
        {
            Description = "description",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = Agents::BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "name",
            Type = Agents::BetaManagedAgentsCustomToolType.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401SerializationRoundtripWorks()
    {
        Agents::BetaManagedAgentsAgentTool value =
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new()
                    {
                        Enabled = true,
                        Name = Agents::Name.Bash,
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
        var deserialized = JsonSerializer.Deserialize<Agents::BetaManagedAgentsAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetSerializationRoundtripWorks()
    {
        Agents::BetaManagedAgentsAgentTool value = new Agents::BetaManagedAgentsMcpToolset()
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
        var deserialized = JsonSerializer.Deserialize<Agents::BetaManagedAgentsAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        Agents::BetaManagedAgentsAgentTool value = new Agents::BetaManagedAgentsCustomTool()
        {
            Description = "description",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = Agents::BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "name",
            Type = Agents::BetaManagedAgentsCustomToolType.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::BetaManagedAgentsAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Agents::Type.Agent)]
    public void Validation_Works(Agents::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Agents::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Agents::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Agents::Type.Agent)]
    public void SerializationRoundtrip_Works(Agents::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Agents::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Agents::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Agents::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Agents::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
