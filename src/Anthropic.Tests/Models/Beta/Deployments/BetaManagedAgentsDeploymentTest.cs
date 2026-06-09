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
        };

        string expectedID = "id";
        BetaManagedAgentsAgentReference expectedAgent = new()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedEnvironmentID = "environment_id";
        List<BetaManagedAgentsDeploymentInitialEvent> expectedInitialEvents =
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
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
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
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
        };
        ApiEnum<string, BetaManagedAgentsDeploymentStatus> expectedStatus =
            BetaManagedAgentsDeploymentStatus.Active;
        ApiEnum<string, BetaManagedAgentsDeploymentType> expectedType =
            BetaManagedAgentsDeploymentType.Deployment;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVaultIds = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgent, model.Agent);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeployment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BetaManagedAgentsAgentReference expectedAgent = new()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedEnvironmentID = "environment_id";
        List<BetaManagedAgentsDeploymentInitialEvent> expectedInitialEvents =
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
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
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
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
        };
        ApiEnum<string, BetaManagedAgentsDeploymentStatus> expectedStatus =
            BetaManagedAgentsDeploymentStatus.Active;
        ApiEnum<string, BetaManagedAgentsDeploymentType> expectedType =
            BetaManagedAgentsDeploymentType.Deployment;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVaultIds = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeployment
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
