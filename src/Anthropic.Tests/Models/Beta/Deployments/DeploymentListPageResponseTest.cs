using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Deployments;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class DeploymentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnvironmentID = "environment_id",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent()
                        {
                            Content =
                            [
                                new BetaManagedAgentsTextBlock()
                                {
                                    Text = "Where is my order #1234?",
                                    Type = BetaManagedAgentsTextBlockType.Text,
                                },
                            ],
                            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                        BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                    ),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Type =
                                BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "x",
                        Timezone = "x",
                        Type = BetaManagedAgentsScheduleType.Cron,
                        LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    Type = BetaManagedAgentsDeploymentType.Deployment,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        List<BetaManagedAgentsDeployment> expectedData =
        [
            new()
            {
                ID = "id",
                Agent = new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                EnvironmentID = "environment_id",
                InitialEvents =
                [
                    new BetaManagedAgentsDeploymentUserMessageEvent()
                    {
                        Content =
                        [
                            new BetaManagedAgentsTextBlock()
                            {
                                Text = "Where is my order #1234?",
                                Type = BetaManagedAgentsTextBlockType.Text,
                            },
                        ],
                        Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                    BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                ),
                Resources =
                [
                    new BetaManagedAgentsGitHubRepositoryResourceConfig()
                    {
                        Type = BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                        Url = "url",
                        Checkout = new BetaManagedAgentsBranchCheckout()
                        {
                            Name = "main",
                            Type = BetaManagedAgentsBranchCheckoutType.Branch,
                        },
                        MountPath = "mount_path",
                    },
                ],
                Schedule = new()
                {
                    Expression = "x",
                    Timezone = "x",
                    Type = BetaManagedAgentsScheduleType.Cron,
                    LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                },
                Status = BetaManagedAgentsDeploymentStatus.Active,
                Type = BetaManagedAgentsDeploymentType.Deployment,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VaultIds = ["string"],
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
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnvironmentID = "environment_id",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent()
                        {
                            Content =
                            [
                                new BetaManagedAgentsTextBlock()
                                {
                                    Text = "Where is my order #1234?",
                                    Type = BetaManagedAgentsTextBlockType.Text,
                                },
                            ],
                            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                        BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                    ),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Type =
                                BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "x",
                        Timezone = "x",
                        Type = BetaManagedAgentsScheduleType.Cron,
                        LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    Type = BetaManagedAgentsDeploymentType.Deployment,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnvironmentID = "environment_id",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent()
                        {
                            Content =
                            [
                                new BetaManagedAgentsTextBlock()
                                {
                                    Text = "Where is my order #1234?",
                                    Type = BetaManagedAgentsTextBlockType.Text,
                                },
                            ],
                            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                        BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                    ),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Type =
                                BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "x",
                        Timezone = "x",
                        Type = BetaManagedAgentsScheduleType.Cron,
                        LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    Type = BetaManagedAgentsDeploymentType.Deployment,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsDeployment> expectedData =
        [
            new()
            {
                ID = "id",
                Agent = new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                EnvironmentID = "environment_id",
                InitialEvents =
                [
                    new BetaManagedAgentsDeploymentUserMessageEvent()
                    {
                        Content =
                        [
                            new BetaManagedAgentsTextBlock()
                            {
                                Text = "Where is my order #1234?",
                                Type = BetaManagedAgentsTextBlockType.Text,
                            },
                        ],
                        Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                    BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                ),
                Resources =
                [
                    new BetaManagedAgentsGitHubRepositoryResourceConfig()
                    {
                        Type = BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                        Url = "url",
                        Checkout = new BetaManagedAgentsBranchCheckout()
                        {
                            Name = "main",
                            Type = BetaManagedAgentsBranchCheckoutType.Branch,
                        },
                        MountPath = "mount_path",
                    },
                ],
                Schedule = new()
                {
                    Expression = "x",
                    Timezone = "x",
                    Type = BetaManagedAgentsScheduleType.Cron,
                    LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                },
                Status = BetaManagedAgentsDeploymentStatus.Active,
                Type = BetaManagedAgentsDeploymentType.Deployment,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VaultIds = ["string"],
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
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnvironmentID = "environment_id",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent()
                        {
                            Content =
                            [
                                new BetaManagedAgentsTextBlock()
                                {
                                    Text = "Where is my order #1234?",
                                    Type = BetaManagedAgentsTextBlockType.Text,
                                },
                            ],
                            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                        BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                    ),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Type =
                                BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "x",
                        Timezone = "x",
                        Type = BetaManagedAgentsScheduleType.Cron,
                        LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    Type = BetaManagedAgentsDeploymentType.Deployment,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnvironmentID = "environment_id",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent()
                        {
                            Content =
                            [
                                new BetaManagedAgentsTextBlock()
                                {
                                    Text = "Where is my order #1234?",
                                    Type = BetaManagedAgentsTextBlockType.Text,
                                },
                            ],
                            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                        BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                    ),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Type =
                                BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "x",
                        Timezone = "x",
                        Type = BetaManagedAgentsScheduleType.Cron,
                        LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    Type = BetaManagedAgentsDeploymentType.Deployment,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnvironmentID = "environment_id",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent()
                        {
                            Content =
                            [
                                new BetaManagedAgentsTextBlock()
                                {
                                    Text = "Where is my order #1234?",
                                    Type = BetaManagedAgentsTextBlockType.Text,
                                },
                            ],
                            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                        BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                    ),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Type =
                                BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "x",
                        Timezone = "x",
                        Type = BetaManagedAgentsScheduleType.Cron,
                        LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    Type = BetaManagedAgentsDeploymentType.Deployment,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnvironmentID = "environment_id",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent()
                        {
                            Content =
                            [
                                new BetaManagedAgentsTextBlock()
                                {
                                    Text = "Where is my order #1234?",
                                    Type = BetaManagedAgentsTextBlockType.Text,
                                },
                            ],
                            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                        BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                    ),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Type =
                                BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "x",
                        Timezone = "x",
                        Type = BetaManagedAgentsScheduleType.Cron,
                        LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    Type = BetaManagedAgentsDeploymentType.Deployment,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
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
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnvironmentID = "environment_id",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent()
                        {
                            Content =
                            [
                                new BetaManagedAgentsTextBlock()
                                {
                                    Text = "Where is my order #1234?",
                                    Type = BetaManagedAgentsTextBlockType.Text,
                                },
                            ],
                            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                        BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                    ),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Type =
                                BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "x",
                        Timezone = "x",
                        Type = BetaManagedAgentsScheduleType.Cron,
                        LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    Type = BetaManagedAgentsDeploymentType.Deployment,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnvironmentID = "environment_id",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent()
                        {
                            Content =
                            [
                                new BetaManagedAgentsTextBlock()
                                {
                                    Text = "Where is my order #1234?",
                                    Type = BetaManagedAgentsTextBlockType.Text,
                                },
                            ],
                            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(
                        BetaManagedAgentsManualDeploymentPausedReasonType.Manual
                    ),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Type =
                                BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout()
                            {
                                Name = "main",
                                Type = BetaManagedAgentsBranchCheckoutType.Branch,
                            },
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "x",
                        Timezone = "x",
                        Type = BetaManagedAgentsScheduleType.Cron,
                        LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    Type = BetaManagedAgentsDeploymentType.Deployment,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VaultIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        DeploymentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
