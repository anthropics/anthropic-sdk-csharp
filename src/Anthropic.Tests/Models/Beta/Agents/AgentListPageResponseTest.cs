using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class AgentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Agents::AgentListPageResponse
        {
            Data =
            [
                new()
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
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAllowPolicy(
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
                            Type =
                                Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Agents::Type.Agent,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Version = 1,
                },
            ],
            NextPage = "next_page",
        };

        List<Agents::BetaManagedAgentsAgent> expectedData =
        [
            new()
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
                        Type =
                            Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                    },
                ],
                Type = Agents::Type.Agent,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Version = 1,
            },
        ];
        string expectedNextPage = "next_page";

        Assert.NotNull(model.Data);
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
        var model = new Agents::AgentListPageResponse
        {
            Data =
            [
                new()
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
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAllowPolicy(
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
                            Type =
                                Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Agents::Type.Agent,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Version = 1,
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::AgentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Agents::AgentListPageResponse
        {
            Data =
            [
                new()
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
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAllowPolicy(
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
                            Type =
                                Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Agents::Type.Agent,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Version = 1,
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::AgentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Agents::BetaManagedAgentsAgent> expectedData =
        [
            new()
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
                        Type =
                            Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                    },
                ],
                Type = Agents::Type.Agent,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Version = 1,
            },
        ];
        string expectedNextPage = "next_page";

        Assert.NotNull(deserialized.Data);
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
        var model = new Agents::AgentListPageResponse
        {
            Data =
            [
                new()
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
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAllowPolicy(
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
                            Type =
                                Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Agents::Type.Agent,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Version = 1,
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Agents::AgentListPageResponse { NextPage = "next_page" };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Agents::AgentListPageResponse { NextPage = "next_page" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Agents::AgentListPageResponse
        {
            NextPage = "next_page",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Agents::AgentListPageResponse
        {
            NextPage = "next_page",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Agents::AgentListPageResponse
        {
            Data =
            [
                new()
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
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAllowPolicy(
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
                            Type =
                                Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Agents::Type.Agent,
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
        var model = new Agents::AgentListPageResponse
        {
            Data =
            [
                new()
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
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAllowPolicy(
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
                            Type =
                                Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Agents::Type.Agent,
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
        var model = new Agents::AgentListPageResponse
        {
            Data =
            [
                new()
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
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAllowPolicy(
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
                            Type =
                                Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Agents::Type.Agent,
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
        var model = new Agents::AgentListPageResponse
        {
            Data =
            [
                new()
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
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAllowPolicy(
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
                            Type =
                                Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Agents::Type.Agent,
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
        var model = new Agents::AgentListPageResponse
        {
            Data =
            [
                new()
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
                                    PermissionPolicy =
                                        new Agents::BetaManagedAgentsAlwaysAllowPolicy(
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
                            Type =
                                Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Agents::Type.Agent,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Version = 1,
                },
            ],
            NextPage = "next_page",
        };

        Agents::AgentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
