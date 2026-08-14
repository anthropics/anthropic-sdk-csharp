using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Agents.Versions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Agents.Versions;

public class VersionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
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
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                        Type = BetaManagedAgentsMultiagentType.Coordinator,
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
                },
            ],
            NextPage = "next_page",
        };

        List<BetaManagedAgentsAgent> expectedData =
        [
            new()
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
                    ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                    Type = BetaManagedAgentsMultiagentType.Coordinator,
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
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
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                        Type = BetaManagedAgentsMultiagentType.Coordinator,
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
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
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
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                        Type = BetaManagedAgentsMultiagentType.Coordinator,
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
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsAgent> expectedData =
        [
            new()
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
                    ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                    Type = BetaManagedAgentsMultiagentType.Coordinator,
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
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
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                        Type = BetaManagedAgentsMultiagentType.Coordinator,
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
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
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
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                        Type = BetaManagedAgentsMultiagentType.Coordinator,
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
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
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
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                        Type = BetaManagedAgentsMultiagentType.Coordinator,
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
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
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                        Type = BetaManagedAgentsMultiagentType.Coordinator,
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
                },
            ],

            NextPage = null,
        };

        Assert.Null(model.NextPage);
        Assert.True(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
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
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                        Type = BetaManagedAgentsMultiagentType.Coordinator,
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
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
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
                        ID = BetaManagedAgentsModel.ClaudeOpus5,
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
                        Type = BetaManagedAgentsMultiagentType.Coordinator,
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
                },
            ],
            NextPage = "next_page",
        };

        VersionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
