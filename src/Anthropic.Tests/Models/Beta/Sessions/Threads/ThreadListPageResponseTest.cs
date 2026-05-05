using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Threads = Anthropic.Models.Beta.Sessions.Threads;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads;

public class ThreadListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                    Agent = new()
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
                        Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<Threads::BetaManagedAgentsSessionThread> expectedData =
        [
            new()
            {
                ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                Agent = new()
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
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                },
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

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
        var model = new Threads::ThreadListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                    Agent = new()
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
                        Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Threads::ThreadListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                    Agent = new()
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
                        Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Threads::ThreadListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Threads::BetaManagedAgentsSessionThread> expectedData =
        [
            new()
            {
                ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                Agent = new()
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
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                },
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

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
        var model = new Threads::ThreadListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                    Agent = new()
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
                        Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                    Agent = new()
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
                        Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                    Agent = new()
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
                        Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                    Agent = new()
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
                        Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
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
        var model = new Threads::ThreadListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                    Agent = new()
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
                        Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Threads::ThreadListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                    Agent = new()
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
                        Type = Threads::BetaManagedAgentsSessionThreadAgentType.Agent,
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
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        OutputTokens = 0,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        Threads::ThreadListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
