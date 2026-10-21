using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
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
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };

        string expectedID = "id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.updated");
        BetaManagedAgentsSessionAgent expectedAgent = new()
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                [
                    new BetaManagedAgentsSessionThreadAgent()
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
                ]
            ),
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
            Version = 1,
        };
        BetaManagedAgentsBudgetLimit expectedBudget = new(
            new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
        );
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedTitle = "title";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAgent, model.Agent);
        Assert.Equal(expectedBudget, model.Budget);
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
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
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
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.updated");
        BetaManagedAgentsSessionAgent expectedAgent = new()
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
            Model = new()
            {
                ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Speed.Standard,
            },
            Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                [
                    new BetaManagedAgentsSessionThreadAgent()
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
                ]
            ),
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
            Version = 1,
        };
        BetaManagedAgentsBudgetLimit expectedBudget = new(
            new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
        );
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedTitle = "title";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.Equal(expectedBudget, deserialized.Budget);
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
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
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
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
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
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
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
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsSessionUpdatedEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        } with
        {
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
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(model.Agent);
        Assert.False(model.RawData.ContainsKey("agent"));
        Assert.Null(model.Budget);
        Assert.False(model.RawData.ContainsKey("budget"));
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            Agent = null,
            Budget = null,
            Title = null,
        };

        Assert.Null(model.Agent);
        Assert.True(model.RawData.ContainsKey("agent"));
        Assert.Null(model.Budget);
        Assert.True(model.RawData.ContainsKey("budget"));
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            Agent = null,
            Budget = null,
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
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
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
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                                            PermissionPolicy =
                                                new BetaManagedAgentsAlwaysAllowPolicy(),
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
                    ]
                ),
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
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };

        BetaManagedAgentsSessionUpdatedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
