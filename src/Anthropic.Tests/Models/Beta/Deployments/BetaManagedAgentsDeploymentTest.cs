using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Deployments;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeployment
        {
            ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "Compiles yesterday's orders into a report every weekday morning.",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            InitialEvents =
            [
                new BetaManagedAgentsDeploymentUserMessageEvent()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Compile yesterday's orders into report.md.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                },
            ],
            Metadata = new Dictionary<string, string>(),
            Name = "Daily order report",
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
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleType.Cron,
                LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                UpcomingRunsAt =
                [
                    DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                    DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                ],
            },
            Status = BetaManagedAgentsDeploymentStatus.Active,
            Type = BetaManagedAgentsDeploymentType.Deployment,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        string expectedID = "depl_011CZkZcDH3vPqd7xnEfwTai";
        BetaManagedAgentsAgentReference expectedAgent = new()
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedDescription =
            "Compiles yesterday's orders into a report every weekday morning.";
        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        List<BetaManagedAgentsDeploymentInitialEvent> expectedInitialEvents =
        [
            new BetaManagedAgentsDeploymentUserMessageEvent()
            {
                Content =
                [
                    new BetaManagedAgentsTextBlock()
                    {
                        Text = "Compile yesterday's orders into report.md.",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
            },
        ];
        Dictionary<string, string> expectedMetadata = new();
        string expectedName = "Daily order report";
        BetaManagedAgentsDeploymentPausedReason expectedPausedReason =
            new BetaManagedAgentsManualDeploymentPausedReason(
                BetaManagedAgentsManualDeploymentPausedReasonType.Manual
            );
        List<BetaManagedAgentsSessionResourceConfig> expectedResources =
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
        ];
        BetaManagedAgentsSchedule expectedSchedule = new()
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],
        };
        ApiEnum<string, BetaManagedAgentsDeploymentStatus> expectedStatus =
            BetaManagedAgentsDeploymentStatus.Active;
        ApiEnum<string, BetaManagedAgentsDeploymentType> expectedType =
            BetaManagedAgentsDeploymentType.Deployment;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        List<string> expectedVaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgent, model.Agent);
        Assert.Null(model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEnvironmentID, model.EnvironmentID);
        Assert.Equal(expectedInitialEvents.Count, model.InitialEvents.Count);
        for (int i = 0; i < expectedInitialEvents.Count; i++)
        {
            Assert.Equal(expectedInitialEvents[i], model.InitialEvents[i]);
        }
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPausedReason, model.PausedReason);
        Assert.Equal(expectedResources.Count, model.Resources.Count);
        for (int i = 0; i < expectedResources.Count; i++)
        {
            Assert.Equal(expectedResources[i], model.Resources[i]);
        }
        Assert.Equal(expectedSchedule, model.Schedule);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVaultIds.Count, model.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], model.VaultIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeployment
        {
            ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "Compiles yesterday's orders into a report every weekday morning.",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            InitialEvents =
            [
                new BetaManagedAgentsDeploymentUserMessageEvent()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Compile yesterday's orders into report.md.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                },
            ],
            Metadata = new Dictionary<string, string>(),
            Name = "Daily order report",
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
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleType.Cron,
                LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                UpcomingRunsAt =
                [
                    DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                    DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                ],
            },
            Status = BetaManagedAgentsDeploymentStatus.Active,
            Type = BetaManagedAgentsDeploymentType.Deployment,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeployment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeployment
        {
            ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "Compiles yesterday's orders into a report every weekday morning.",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            InitialEvents =
            [
                new BetaManagedAgentsDeploymentUserMessageEvent()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Compile yesterday's orders into report.md.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                },
            ],
            Metadata = new Dictionary<string, string>(),
            Name = "Daily order report",
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
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleType.Cron,
                LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                UpcomingRunsAt =
                [
                    DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                    DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                ],
            },
            Status = BetaManagedAgentsDeploymentStatus.Active,
            Type = BetaManagedAgentsDeploymentType.Deployment,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeployment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "depl_011CZkZcDH3vPqd7xnEfwTai";
        BetaManagedAgentsAgentReference expectedAgent = new()
        {
            ID = "agent_011CZkYpogX7uDKUyvBTophP",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedDescription =
            "Compiles yesterday's orders into a report every weekday morning.";
        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        List<BetaManagedAgentsDeploymentInitialEvent> expectedInitialEvents =
        [
            new BetaManagedAgentsDeploymentUserMessageEvent()
            {
                Content =
                [
                    new BetaManagedAgentsTextBlock()
                    {
                        Text = "Compile yesterday's orders into report.md.",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
            },
        ];
        Dictionary<string, string> expectedMetadata = new();
        string expectedName = "Daily order report";
        BetaManagedAgentsDeploymentPausedReason expectedPausedReason =
            new BetaManagedAgentsManualDeploymentPausedReason(
                BetaManagedAgentsManualDeploymentPausedReasonType.Manual
            );
        List<BetaManagedAgentsSessionResourceConfig> expectedResources =
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
        ];
        BetaManagedAgentsSchedule expectedSchedule = new()
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],
        };
        ApiEnum<string, BetaManagedAgentsDeploymentStatus> expectedStatus =
            BetaManagedAgentsDeploymentStatus.Active;
        ApiEnum<string, BetaManagedAgentsDeploymentType> expectedType =
            BetaManagedAgentsDeploymentType.Deployment;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        List<string> expectedVaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.Null(deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEnvironmentID, deserialized.EnvironmentID);
        Assert.Equal(expectedInitialEvents.Count, deserialized.InitialEvents.Count);
        for (int i = 0; i < expectedInitialEvents.Count; i++)
        {
            Assert.Equal(expectedInitialEvents[i], deserialized.InitialEvents[i]);
        }
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPausedReason, deserialized.PausedReason);
        Assert.Equal(expectedResources.Count, deserialized.Resources.Count);
        for (int i = 0; i < expectedResources.Count; i++)
        {
            Assert.Equal(expectedResources[i], deserialized.Resources[i]);
        }
        Assert.Equal(expectedSchedule, deserialized.Schedule);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVaultIds.Count, deserialized.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], deserialized.VaultIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeployment
        {
            ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "Compiles yesterday's orders into a report every weekday morning.",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            InitialEvents =
            [
                new BetaManagedAgentsDeploymentUserMessageEvent()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Compile yesterday's orders into report.md.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                },
            ],
            Metadata = new Dictionary<string, string>(),
            Name = "Daily order report",
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
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleType.Cron,
                LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                UpcomingRunsAt =
                [
                    DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                    DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                ],
            },
            Status = BetaManagedAgentsDeploymentStatus.Active,
            Type = BetaManagedAgentsDeploymentType.Deployment,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeployment
        {
            ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Description = "Compiles yesterday's orders into a report every weekday morning.",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            InitialEvents =
            [
                new BetaManagedAgentsDeploymentUserMessageEvent()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Compile yesterday's orders into report.md.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
                },
            ],
            Metadata = new Dictionary<string, string>(),
            Name = "Daily order report",
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
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleType.Cron,
                LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                UpcomingRunsAt =
                [
                    DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                    DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                ],
            },
            Status = BetaManagedAgentsDeploymentStatus.Active,
            Type = BetaManagedAgentsDeploymentType.Deployment,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
        };

        BetaManagedAgentsDeployment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsDeploymentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeploymentType.Deployment)]
    public void Validation_Works(BetaManagedAgentsDeploymentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDeploymentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeploymentType.Deployment)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsDeploymentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDeploymentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
