using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Agents = Anthropic.Models.Beta.Agents;
using Threads = Anthropic.Models.Beta.Sessions.Threads;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads;

public class BetaManagedAgentsSessionThreadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Threads::BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Effort = new Agents::BetaManagedAgentsEffortLow(
                        Agents::BetaManagedAgentsEffortLowType.Low
                    ),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
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
                Type = Agents::BetaManagedAgentsSessionThreadAgentType.Agent,
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
            Status = Threads::BetaManagedAgentsSessionThreadStatus.Idle,
            Type = Threads::Type.SessionThread,
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
        };

        string expectedID = "sthr_011CZkZVWa6oIjw0rgXZpnBt";
        Threads::Agent expectedAgent = new Agents::BetaManagedAgentsSessionThreadAgent()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Description = "A focused research subagent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                Effort = new Agents::BetaManagedAgentsEffortLow(
                    Agents::BetaManagedAgentsEffortLowType.Low
                ),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "Researcher",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
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
            Type = Agents::BetaManagedAgentsSessionThreadAgentType.Agent,
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        Threads::BetaManagedAgentsSessionThreadStats expectedStats = new()
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
            StartupSeconds = 0,
        };
        ApiEnum<string, Threads::BetaManagedAgentsSessionThreadStatus> expectedStatus =
            Threads::BetaManagedAgentsSessionThreadStatus.Idle;
        ApiEnum<string, Threads::Type> expectedType = Threads::Type.SessionThread;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Threads::BetaManagedAgentsSessionThreadUsage expectedUsage = new()
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
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Threads::BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Effort = new Agents::BetaManagedAgentsEffortLow(
                        Agents::BetaManagedAgentsEffortLowType.Low
                    ),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
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
                Type = Agents::BetaManagedAgentsSessionThreadAgentType.Agent,
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
            Status = Threads::BetaManagedAgentsSessionThreadStatus.Idle,
            Type = Threads::Type.SessionThread,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Threads::BetaManagedAgentsSessionThread>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Threads::BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Effort = new Agents::BetaManagedAgentsEffortLow(
                        Agents::BetaManagedAgentsEffortLowType.Low
                    ),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
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
                Type = Agents::BetaManagedAgentsSessionThreadAgentType.Agent,
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
            Status = Threads::BetaManagedAgentsSessionThreadStatus.Idle,
            Type = Threads::Type.SessionThread,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Threads::BetaManagedAgentsSessionThread>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sthr_011CZkZVWa6oIjw0rgXZpnBt";
        Threads::Agent expectedAgent = new Agents::BetaManagedAgentsSessionThreadAgent()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Description = "A focused research subagent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                Effort = new Agents::BetaManagedAgentsEffortLow(
                    Agents::BetaManagedAgentsEffortLowType.Low
                ),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "Researcher",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
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
            Type = Agents::BetaManagedAgentsSessionThreadAgentType.Agent,
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        Threads::BetaManagedAgentsSessionThreadStats expectedStats = new()
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
            StartupSeconds = 0,
        };
        ApiEnum<string, Threads::BetaManagedAgentsSessionThreadStatus> expectedStatus =
            Threads::BetaManagedAgentsSessionThreadStatus.Idle;
        ApiEnum<string, Threads::Type> expectedType = Threads::Type.SessionThread;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Threads::BetaManagedAgentsSessionThreadUsage expectedUsage = new()
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
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Threads::BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Effort = new Agents::BetaManagedAgentsEffortLow(
                        Agents::BetaManagedAgentsEffortLowType.Low
                    ),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
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
                Type = Agents::BetaManagedAgentsSessionThreadAgentType.Agent,
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
            Status = Threads::BetaManagedAgentsSessionThreadStatus.Idle,
            Type = Threads::Type.SessionThread,
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Threads::BetaManagedAgentsSessionThread
        {
            ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            Agent = new Agents::BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Effort = new Agents::BetaManagedAgentsEffortLow(
                        Agents::BetaManagedAgentsEffortLowType.Low
                    ),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
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
                Type = Agents::BetaManagedAgentsSessionThreadAgentType.Agent,
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
            Status = Threads::BetaManagedAgentsSessionThreadStatus.Idle,
            Type = Threads::Type.SessionThread,
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
        };

        Threads::BetaManagedAgentsSessionThread copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsSessionThreadValidationWorks()
    {
        Threads::Agent value = new Agents::BetaManagedAgentsSessionThreadAgent()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Description = "A focused research subagent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                Effort = new Agents::BetaManagedAgentsEffortLow(
                    Agents::BetaManagedAgentsEffortLowType.Low
                ),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "Researcher",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
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
            Type = Agents::BetaManagedAgentsSessionThreadAgentType.Agent,
            Version = 1,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAdvisorValidationWorks()
    {
        Threads::Agent value = new Agents::BetaManagedAgentsAdvisor()
        {
            Model = "model",
            Type = Agents::Type.Advisor,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionThreadSerializationRoundtripWorks()
    {
        Threads::Agent value = new Agents::BetaManagedAgentsSessionThreadAgent()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Description = "A focused research subagent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeSonnet4_6,
                Effort = new Agents::BetaManagedAgentsEffortLow(
                    Agents::BetaManagedAgentsEffortLowType.Low
                ),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "Researcher",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
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
            Type = Agents::BetaManagedAgentsSessionThreadAgentType.Agent,
            Version = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Threads::Agent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAdvisorSerializationRoundtripWorks()
    {
        Threads::Agent value = new Agents::BetaManagedAgentsAdvisor()
        {
            Model = "model",
            Type = Agents::Type.Advisor,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Threads::Agent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Threads::Type.SessionThread)]
    public void Validation_Works(Threads::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Threads::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Threads::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Threads::Type.SessionThread)]
    public void SerializationRoundtrip_Works(Threads::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Threads::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Threads::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Threads::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Threads::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
