using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionUpdatedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Multiagent = new()
                {
                    Agents =
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
                                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                        new()
                                        {
                                            Enabled = true,
                                            Name = Name.Bash,
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(
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
                Type = BetaManagedAgentsSessionAgentType.Agent,
                Version = 1,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };

        string expectedID = "id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType> expectedType =
            BetaManagedAgentsSessionUpdatedEventType.SessionUpdated;
        BetaManagedAgentsSessionAgent expectedAgent = new()
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
            Model = new() { ID = BetaManagedAgentsModel.ClaudeSonnet4_6, Speed = Speed.Standard },
            Multiagent = new()
            {
                Agents =
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
                            ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                        Version = 1,
                    },
                ],
                Type = BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
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
            Type = BetaManagedAgentsSessionAgentType.Agent,
            Version = 1,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedTitle = "title";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAgent, model.Agent);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Multiagent = new()
                {
                    Agents =
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
                                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                        new()
                                        {
                                            Enabled = true,
                                            Name = Name.Bash,
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(
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
                Type = BetaManagedAgentsSessionAgentType.Agent,
                Version = 1,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionUpdatedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Multiagent = new()
                {
                    Agents =
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
                                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                        new()
                                        {
                                            Enabled = true,
                                            Name = Name.Bash,
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(
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
                Type = BetaManagedAgentsSessionAgentType.Agent,
                Version = 1,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionUpdatedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType> expectedType =
            BetaManagedAgentsSessionUpdatedEventType.SessionUpdated;
        BetaManagedAgentsSessionAgent expectedAgent = new()
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
            Model = new() { ID = BetaManagedAgentsModel.ClaudeSonnet4_6, Speed = Speed.Standard },
            Multiagent = new()
            {
                Agents =
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
                            ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                        Version = 1,
                    },
                ],
                Type = BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
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
            Type = BetaManagedAgentsSessionAgentType.Agent,
            Version = 1,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedTitle = "title";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Multiagent = new()
                {
                    Agents =
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
                                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                        new()
                                        {
                                            Enabled = true,
                                            Name = Name.Bash,
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(
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
                Type = BetaManagedAgentsSessionAgentType.Agent,
                Version = 1,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Multiagent = new()
                {
                    Agents =
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
                                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                        new()
                                        {
                                            Enabled = true,
                                            Name = Name.Bash,
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(
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
                Type = BetaManagedAgentsSessionAgentType.Agent,
                Version = 1,
            },
            Title = "title",
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Multiagent = new()
                {
                    Agents =
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
                                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                        new()
                                        {
                                            Enabled = true,
                                            Name = Name.Bash,
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(
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
                Type = BetaManagedAgentsSessionAgentType.Agent,
                Version = 1,
            },
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Multiagent = new()
                {
                    Agents =
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
                                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                        new()
                                        {
                                            Enabled = true,
                                            Name = Name.Bash,
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(
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
                Type = BetaManagedAgentsSessionAgentType.Agent,
                Version = 1,
            },
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Multiagent = new()
                {
                    Agents =
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
                                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                        new()
                                        {
                                            Enabled = true,
                                            Name = Name.Bash,
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(
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
                Type = BetaManagedAgentsSessionAgentType.Agent,
                Version = 1,
            },
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(model.Agent);
        Assert.False(model.RawData.ContainsKey("agent"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            Agent = null,
            Title = null,
        };

        Assert.Null(model.Agent);
        Assert.True(model.RawData.ContainsKey("agent"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            Agent = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Multiagent = new()
                {
                    Agents =
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
                                ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
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
                                        new()
                                        {
                                            Enabled = true,
                                            Name = Name.Bash,
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(
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
                Type = BetaManagedAgentsSessionAgentType.Agent,
                Version = 1,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };

        BetaManagedAgentsSessionUpdatedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionUpdatedEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionUpdatedEventType.SessionUpdated)]
    public void Validation_Works(BetaManagedAgentsSessionUpdatedEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionUpdatedEventType.SessionUpdated)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionUpdatedEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
