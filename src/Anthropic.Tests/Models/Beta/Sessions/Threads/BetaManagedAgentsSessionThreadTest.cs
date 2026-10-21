using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions.Threads;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads;

public class BetaManagedAgentsSessionThreadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                    ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new Agents::BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Version = "1",
                    },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new Agents::BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new Agents::BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            ParentThreadID = null,
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Stats = new()
            {
                ActiveSeconds = 0,
                DurationSeconds = 0,
                StartupSeconds = 0,
            },
            Status = BetaManagedAgentsSessionThreadStatus.Idle,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            WorkflowRunID = null,
        };

        string expectedID = "sthr_011CZkZVWa6oJjw1rgXZpnBt";
        Agent expectedAgent = new Agents::BetaManagedAgentsSessionThreadAgent()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Description = "A focused research subagent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "Researcher",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System =
                "You are a research subagent that gathers and summarises sources for the coordinating agent.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        BetaManagedAgentsSessionThreadStats expectedStats = new()
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
            StartupSeconds = 0,
        };
        ApiEnum<string, BetaManagedAgentsSessionThreadStatus> expectedStatus =
            BetaManagedAgentsSessionThreadStatus.Idle;
        JsonElement expectedType = JsonSerializer.SerializeToElement("session_thread");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        BetaManagedAgentsSessionThreadUsage expectedUsage = new()
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            OutputTokens = 0,
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgent, model.Agent);
        Assert.Null(model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.ParentThreadID);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedStats, model.Stats);
        Assert.Equal(expectedStatus, model.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsage, model.Usage);
        Assert.Null(model.WorkflowRunID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                    ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new Agents::BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Version = "1",
                    },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new Agents::BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new Agents::BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            ParentThreadID = null,
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Stats = new()
            {
                ActiveSeconds = 0,
                DurationSeconds = 0,
                StartupSeconds = 0,
            },
            Status = BetaManagedAgentsSessionThreadStatus.Idle,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            WorkflowRunID = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThread>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                    ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new Agents::BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Version = "1",
                    },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new Agents::BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new Agents::BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            ParentThreadID = null,
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Stats = new()
            {
                ActiveSeconds = 0,
                DurationSeconds = 0,
                StartupSeconds = 0,
            },
            Status = BetaManagedAgentsSessionThreadStatus.Idle,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            WorkflowRunID = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThread>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sthr_011CZkZVWa6oJjw1rgXZpnBt";
        Agent expectedAgent = new Agents::BetaManagedAgentsSessionThreadAgent()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Description = "A focused research subagent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "Researcher",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System =
                "You are a research subagent that gathers and summarises sources for the coordinating agent.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        BetaManagedAgentsSessionThreadStats expectedStats = new()
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
            StartupSeconds = 0,
        };
        ApiEnum<string, BetaManagedAgentsSessionThreadStatus> expectedStatus =
            BetaManagedAgentsSessionThreadStatus.Idle;
        JsonElement expectedType = JsonSerializer.SerializeToElement("session_thread");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        BetaManagedAgentsSessionThreadUsage expectedUsage = new()
        {
            ActiveSeconds = 0,
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            OutputTokens = 0,
            ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.Null(deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.ParentThreadID);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedStats, deserialized.Stats);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.Null(deserialized.WorkflowRunID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                    ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new Agents::BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Version = "1",
                    },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new Agents::BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new Agents::BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            ParentThreadID = null,
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Stats = new()
            {
                ActiveSeconds = 0,
                DurationSeconds = 0,
                StartupSeconds = 0,
            },
            Status = BetaManagedAgentsSessionThreadStatus.Idle,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            WorkflowRunID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                    ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new Agents::BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Version = "1",
                    },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new Agents::BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new Agents::BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            ParentThreadID = null,
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Stats = new()
            {
                ActiveSeconds = 0,
                DurationSeconds = 0,
                StartupSeconds = 0,
            },
            Status = BetaManagedAgentsSessionThreadStatus.Idle,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            WorkflowRunID = null,
        };

        BetaManagedAgentsSessionThread copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsSessionThreadValidationWorks()
    {
        Agent value = new Agents::BetaManagedAgentsSessionThreadAgent()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Description = "A focused research subagent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "Researcher",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System =
                "You are a research subagent that gathers and summarises sources for the coordinating agent.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAdvisorValidationWorks()
    {
        Agent value = new Agents::BetaManagedAgentsAdvisor("model");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsInlineValidationWorks()
    {
        Agent value = new BetaManagedAgentsInlineAgent()
        {
            Description = null,
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionThreadSerializationRoundtripWorks()
    {
        Agent value = new Agents::BetaManagedAgentsSessionThreadAgent()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Description = "A focused research subagent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "Researcher",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System =
                "You are a research subagent that gathers and summarises sources for the coordinating agent.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAdvisorSerializationRoundtripWorks()
    {
        Agent value = new Agents::BetaManagedAgentsAdvisor("model");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsInlineSerializationRoundtripWorks()
    {
        Agent value = new BetaManagedAgentsInlineAgent()
        {
            Description = null,
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionThreadTypeWorks()
    {
        Agent value = new Agents::BetaManagedAgentsSessionThreadAgent()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Description = "A focused research subagent.",
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "Researcher",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System =
                "You are a research subagent that gathers and summarises sources for the coordinating agent.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                    },
                },
            ],
            Version = 1,
        };
        Assert.Equal(AgentType.Agent, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsAdvisorTypeWorks()
    {
        Agent value = new Agents::BetaManagedAgentsAdvisor("model");
        Assert.Equal(AgentType.Advisor, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsInlineTypeWorks()
    {
        Agent value = new BetaManagedAgentsInlineAgent()
        {
            Description = null,
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
        };
        Assert.Equal(AgentType.Inline, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Agent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "description": "A focused research subagent.",
                  "execution_identity": {
                    "type": "service_account"
                  },
                  "mcp_servers": [
                    {
                      "name": "example-mcp",
                      "type": "url",
                      "url": "https://example-server.modelcontextprotocol.io/sse"
                    }
                  ],
                  "name": "Researcher",
                  "system": "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                  "type": "agent"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedDescription = "A focused research subagent.";
        Agents::BetaManagedAgentsExecutionIdentity expectedExecutionIdentity =
            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity();
        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        string expectedName = "Researcher";
        string expectedSystem =
            "You are a research subagent that gathers and summarises sources for the coordinating agent.";
        ApiEnum<string, AgentType> expectedType = AgentType.Agent;

        Assert.Equal(expectedDescription, value.Description);
        Assert.Equal(expectedExecutionIdentity, value.ExecutionIdentity);
        Assert.NotNull(value.McpServers);
        Assert.Equal(expectedMcpServers.Count, value.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], value.McpServers[i]);
        }
        Assert.Equal(expectedName, value.Name);
        Assert.Equal(expectedSystem, value.System);
        Assert.Equal(expectedType, value.Type);

        Agent emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.Description);
        Assert.Null(emptyValue.ExecutionIdentity);
        Assert.Null(emptyValue.McpServers);
        Assert.Null(emptyValue.Name);
        Assert.Null(emptyValue.System);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        Agent mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "description": [
                    "invalid"
                  ],
                  "name": [
                    "invalid"
                  ],
                  "system": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.Description);
        Assert.Null(mismatchedValue.Name);
        Assert.Null(mismatchedValue.System);
    }
}

public class AgentTypeTest : TestBase
{
    [Theory]
    [InlineData(AgentType.Agent)]
    [InlineData(AgentType.Advisor)]
    [InlineData(AgentType.Inline)]
    public void Validation_Works(AgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgentType.Agent)]
    [InlineData(AgentType.Advisor)]
    [InlineData(AgentType.Inline)]
    public void SerializationRoundtrip_Works(AgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
