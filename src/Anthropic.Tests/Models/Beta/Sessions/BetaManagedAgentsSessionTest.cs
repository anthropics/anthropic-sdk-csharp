using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSession
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
            },
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        string expectedID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
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
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        Dictionary<string, string> expectedMetadata = new();
        List<BetaManagedAgentsSessionResource> expectedResources =
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
        ];
        BetaManagedAgentsSessionStats expectedStats = new()
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
        };
        ApiEnum<string, Status> expectedStatus = Status.Idle;
        string expectedTitle = "Order #1234 inquiry";
        ApiEnum<string, BetaManagedAgentsSessionType> expectedType =
            BetaManagedAgentsSessionType.Session;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        BetaManagedAgentsSessionUsage expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        List<string> expectedVaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgent, model.Agent);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEnvironmentID, model.EnvironmentID);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedResources.Count, model.Resources.Count);
        for (int i = 0; i < expectedResources.Count; i++)
        {
            Assert.Equal(expectedResources[i], model.Resources[i]);
        }
        Assert.Equal(expectedStats, model.Stats);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsage, model.Usage);
        Assert.Equal(expectedVaultIds.Count, model.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], model.VaultIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSession
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
            },
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSession>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSession
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
            },
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSession>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
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
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        Dictionary<string, string> expectedMetadata = new();
        List<BetaManagedAgentsSessionResource> expectedResources =
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
        ];
        BetaManagedAgentsSessionStats expectedStats = new()
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
        };
        ApiEnum<string, Status> expectedStatus = Status.Idle;
        string expectedTitle = "Order #1234 inquiry";
        ApiEnum<string, BetaManagedAgentsSessionType> expectedType =
            BetaManagedAgentsSessionType.Session;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        BetaManagedAgentsSessionUsage expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        List<string> expectedVaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEnvironmentID, deserialized.EnvironmentID);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedResources.Count, deserialized.Resources.Count);
        for (int i = 0; i < expectedResources.Count; i++)
        {
            Assert.Equal(expectedResources[i], deserialized.Resources[i]);
        }
        Assert.Equal(expectedStats, deserialized.Stats);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.Equal(expectedVaultIds.Count, deserialized.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], deserialized.VaultIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSession
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
            },
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSession
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
            },
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        BetaManagedAgentsSession copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Rescheduling)]
    [InlineData(Status.Running)]
    [InlineData(Status.Idle)]
    [InlineData(Status.Terminated)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Rescheduling)]
    [InlineData(Status.Running)]
    [InlineData(Status.Idle)]
    [InlineData(Status.Terminated)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsSessionTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionType.Session)]
    public void Validation_Works(BetaManagedAgentsSessionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSessionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionType.Session)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSessionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
