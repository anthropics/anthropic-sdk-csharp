using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class SessionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SessionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionAgentType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    Metadata = new Dictionary<string, string>(),
                    Resources =
                    [
                        new BetaManagedAgentsFileResource()
                        {
                            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                            MountPath = "/uploads/receipt.pdf",
                            Type = BetaManagedAgentsFileResourceType.File,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        },
                        new BetaManagedAgentsGitHubRepositoryResource()
                        {
                            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            MountPath = "/workspace/example-repo",
                            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            Url = "https://github.com/example-org/example-repo",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                        },
                    ],
                    Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                    Status = Status.Idle,
                    Title = "Order #1234 inquiry",
                    Type = BetaManagedAgentsSessionType.Session,
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
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<BetaManagedAgentsSession> expectedData =
        [
            new()
            {
                ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                Metadata = new Dictionary<string, string>(),
                Resources =
                [
                    new BetaManagedAgentsFileResource()
                    {
                        ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                        CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                        MountPath = "/uploads/receipt.pdf",
                        Type = BetaManagedAgentsFileResourceType.File,
                        UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    },
                    new BetaManagedAgentsGitHubRepositoryResource()
                    {
                        ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                        CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        MountPath = "/workspace/example-repo",
                        Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                        UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        Url = "https://github.com/example-org/example-repo",
                        Checkout = new BetaManagedAgentsBranchCheckout()
                        {
                            Name = "main",
                            Type = BetaManagedAgentsBranchCheckoutType.Branch,
                        },
                    },
                ],
                Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                Status = Status.Idle,
                Title = "Order #1234 inquiry",
                Type = BetaManagedAgentsSessionType.Session,
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
                VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
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
        var model = new SessionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionAgentType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    Metadata = new Dictionary<string, string>(),
                    Resources =
                    [
                        new BetaManagedAgentsFileResource()
                        {
                            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                            MountPath = "/uploads/receipt.pdf",
                            Type = BetaManagedAgentsFileResourceType.File,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        },
                        new BetaManagedAgentsGitHubRepositoryResource()
                        {
                            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            MountPath = "/workspace/example-repo",
                            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            Url = "https://github.com/example-org/example-repo",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                        },
                    ],
                    Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                    Status = Status.Idle,
                    Title = "Order #1234 inquiry",
                    Type = BetaManagedAgentsSessionType.Session,
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
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SessionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionAgentType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    Metadata = new Dictionary<string, string>(),
                    Resources =
                    [
                        new BetaManagedAgentsFileResource()
                        {
                            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                            MountPath = "/uploads/receipt.pdf",
                            Type = BetaManagedAgentsFileResourceType.File,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        },
                        new BetaManagedAgentsGitHubRepositoryResource()
                        {
                            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            MountPath = "/workspace/example-repo",
                            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            Url = "https://github.com/example-org/example-repo",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                        },
                    ],
                    Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                    Status = Status.Idle,
                    Title = "Order #1234 inquiry",
                    Type = BetaManagedAgentsSessionType.Session,
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
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SessionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsSession> expectedData =
        [
            new()
            {
                ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                Metadata = new Dictionary<string, string>(),
                Resources =
                [
                    new BetaManagedAgentsFileResource()
                    {
                        ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                        CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                        MountPath = "/uploads/receipt.pdf",
                        Type = BetaManagedAgentsFileResourceType.File,
                        UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    },
                    new BetaManagedAgentsGitHubRepositoryResource()
                    {
                        ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                        CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        MountPath = "/workspace/example-repo",
                        Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                        UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        Url = "https://github.com/example-org/example-repo",
                        Checkout = new BetaManagedAgentsBranchCheckout()
                        {
                            Name = "main",
                            Type = BetaManagedAgentsBranchCheckoutType.Branch,
                        },
                    },
                ],
                Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                Status = Status.Idle,
                Title = "Order #1234 inquiry",
                Type = BetaManagedAgentsSessionType.Session,
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
                VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
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
        var model = new SessionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionAgentType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    Metadata = new Dictionary<string, string>(),
                    Resources =
                    [
                        new BetaManagedAgentsFileResource()
                        {
                            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                            MountPath = "/uploads/receipt.pdf",
                            Type = BetaManagedAgentsFileResourceType.File,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        },
                        new BetaManagedAgentsGitHubRepositoryResource()
                        {
                            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            MountPath = "/workspace/example-repo",
                            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            Url = "https://github.com/example-org/example-repo",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                        },
                    ],
                    Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                    Status = Status.Idle,
                    Title = "Order #1234 inquiry",
                    Type = BetaManagedAgentsSessionType.Session,
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
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SessionListPageResponse { NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=" };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionListPageResponse { NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SessionListPageResponse
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
        var model = new SessionListPageResponse
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
        var model = new SessionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionAgentType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    Metadata = new Dictionary<string, string>(),
                    Resources =
                    [
                        new BetaManagedAgentsFileResource()
                        {
                            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                            MountPath = "/uploads/receipt.pdf",
                            Type = BetaManagedAgentsFileResourceType.File,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        },
                        new BetaManagedAgentsGitHubRepositoryResource()
                        {
                            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            MountPath = "/workspace/example-repo",
                            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            Url = "https://github.com/example-org/example-repo",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                        },
                    ],
                    Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                    Status = Status.Idle,
                    Title = "Order #1234 inquiry",
                    Type = BetaManagedAgentsSessionType.Session,
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
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SessionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionAgentType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    Metadata = new Dictionary<string, string>(),
                    Resources =
                    [
                        new BetaManagedAgentsFileResource()
                        {
                            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                            MountPath = "/uploads/receipt.pdf",
                            Type = BetaManagedAgentsFileResourceType.File,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        },
                        new BetaManagedAgentsGitHubRepositoryResource()
                        {
                            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            MountPath = "/workspace/example-repo",
                            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            Url = "https://github.com/example-org/example-repo",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                        },
                    ],
                    Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                    Status = Status.Idle,
                    Title = "Order #1234 inquiry",
                    Type = BetaManagedAgentsSessionType.Session,
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
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SessionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionAgentType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    Metadata = new Dictionary<string, string>(),
                    Resources =
                    [
                        new BetaManagedAgentsFileResource()
                        {
                            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                            MountPath = "/uploads/receipt.pdf",
                            Type = BetaManagedAgentsFileResourceType.File,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        },
                        new BetaManagedAgentsGitHubRepositoryResource()
                        {
                            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            MountPath = "/workspace/example-repo",
                            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            Url = "https://github.com/example-org/example-repo",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                        },
                    ],
                    Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                    Status = Status.Idle,
                    Title = "Order #1234 inquiry",
                    Type = BetaManagedAgentsSessionType.Session,
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
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
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
        var model = new SessionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionAgentType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    Metadata = new Dictionary<string, string>(),
                    Resources =
                    [
                        new BetaManagedAgentsFileResource()
                        {
                            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                            MountPath = "/uploads/receipt.pdf",
                            Type = BetaManagedAgentsFileResourceType.File,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        },
                        new BetaManagedAgentsGitHubRepositoryResource()
                        {
                            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            MountPath = "/workspace/example-repo",
                            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            Url = "https://github.com/example-org/example-repo",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                        },
                    ],
                    Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                    Status = Status.Idle,
                    Title = "Order #1234 inquiry",
                    Type = BetaManagedAgentsSessionType.Session,
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
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SessionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionAgentType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    Metadata = new Dictionary<string, string>(),
                    Resources =
                    [
                        new BetaManagedAgentsFileResource()
                        {
                            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                            MountPath = "/uploads/receipt.pdf",
                            Type = BetaManagedAgentsFileResourceType.File,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                        },
                        new BetaManagedAgentsGitHubRepositoryResource()
                        {
                            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            MountPath = "/workspace/example-repo",
                            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                            Url = "https://github.com/example-org/example-repo",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                        },
                    ],
                    Stats = new() { ActiveSeconds = 0, DurationSeconds = 0 },
                    Status = Status.Idle,
                    Title = "Order #1234 inquiry",
                    Type = BetaManagedAgentsSessionType.Session,
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
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        SessionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
