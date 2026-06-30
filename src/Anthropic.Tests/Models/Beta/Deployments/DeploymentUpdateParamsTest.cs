using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Deployments;
using Anthropic.Models.Beta.Sessions.Events;
using Sessions = Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class DeploymentUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeploymentUpdateParams
        {
            DeploymentID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Agent = "string",
            Description = "description",
            EnvironmentID = "environment_id",
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "name",
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Schedule = new()
            {
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleParamsType.Cron,
            },
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedDeploymentID = "depl_011CZkZcDH3vPqd7xnEfwTai";
        DeploymentUpdateParamsAgent expectedAgent = "string";
        string expectedDescription = "description";
        string expectedEnvironmentID = "environment_id";
        List<BetaManagedAgentsDeploymentInitialEventParams> expectedInitialEvents =
        [
            new BetaManagedAgentsUserMessageEventParams()
            {
                Content =
                [
                    new BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
            },
        ];
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        List<DeploymentUpdateParamsResource> expectedResources =
        [
            new Sessions::BetaManagedAgentsFileResourceParams()
            {
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
                MountPath = "/uploads/receipt.pdf",
            },
        ];
        BetaManagedAgentsScheduleParams expectedSchedule = new()
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleParamsType.Cron,
        };
        List<string> expectedVaultIds = ["string"];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedDeploymentID, parameters.DeploymentID);
        Assert.Equal(expectedAgent, parameters.Agent);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
        Assert.NotNull(parameters.InitialEvents);
        Assert.Equal(expectedInitialEvents.Count, parameters.InitialEvents.Count);
        for (int i = 0; i < expectedInitialEvents.Count; i++)
        {
            Assert.Equal(expectedInitialEvents[i], parameters.InitialEvents[i]);
        }
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Resources);
        Assert.Equal(expectedResources.Count, parameters.Resources.Count);
        for (int i = 0; i < expectedResources.Count; i++)
        {
            Assert.Equal(expectedResources[i], parameters.Resources[i]);
        }
        Assert.Equal(expectedSchedule, parameters.Schedule);
        Assert.NotNull(parameters.VaultIds);
        Assert.Equal(expectedVaultIds.Count, parameters.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], parameters.VaultIds[i]);
        }
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeploymentUpdateParams
        {
            DeploymentID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Schedule = new()
            {
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleParamsType.Cron,
            },
            VaultIds = ["string"],
        };

        Assert.Null(parameters.Agent);
        Assert.False(parameters.RawBodyData.ContainsKey("agent"));
        Assert.Null(parameters.EnvironmentID);
        Assert.False(parameters.RawBodyData.ContainsKey("environment_id"));
        Assert.Null(parameters.InitialEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("initial_events"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DeploymentUpdateParams
        {
            DeploymentID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Schedule = new()
            {
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleParamsType.Cron,
            },
            VaultIds = ["string"],

            // Null should be interpreted as omitted for these properties
            Agent = null,
            EnvironmentID = null,
            InitialEvents = null,
            Name = null,
            Betas = null,
        };

        Assert.Null(parameters.Agent);
        Assert.False(parameters.RawBodyData.ContainsKey("agent"));
        Assert.Null(parameters.EnvironmentID);
        Assert.False(parameters.RawBodyData.ContainsKey("environment_id"));
        Assert.Null(parameters.InitialEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("initial_events"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeploymentUpdateParams
        {
            DeploymentID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Agent = "string",
            EnvironmentID = "environment_id",
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],
            Name = "name",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Resources);
        Assert.False(parameters.RawBodyData.ContainsKey("resources"));
        Assert.Null(parameters.Schedule);
        Assert.False(parameters.RawBodyData.ContainsKey("schedule"));
        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DeploymentUpdateParams
        {
            DeploymentID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Agent = "string",
            EnvironmentID = "environment_id",
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],
            Name = "name",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Description = null,
            Metadata = null,
            Resources = null,
            Schedule = null,
            VaultIds = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Resources);
        Assert.True(parameters.RawBodyData.ContainsKey("resources"));
        Assert.Null(parameters.Schedule);
        Assert.True(parameters.RawBodyData.ContainsKey("schedule"));
        Assert.Null(parameters.VaultIds);
        Assert.True(parameters.RawBodyData.ContainsKey("vault_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        DeploymentUpdateParams parameters = new()
        {
            DeploymentID = "depl_011CZkZcDH3vPqd7xnEfwTai",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/deployments/depl_011CZkZcDH3vPqd7xnEfwTai?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        DeploymentUpdateParams parameters = new()
        {
            DeploymentID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeploymentUpdateParams
        {
            DeploymentID = "depl_011CZkZcDH3vPqd7xnEfwTai",
            Agent = "string",
            Description = "description",
            EnvironmentID = "environment_id",
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams()
                {
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "name",
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Schedule = new()
            {
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleParamsType.Cron,
            },
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        DeploymentUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DeploymentUpdateParamsAgentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        DeploymentUpdateParamsAgent value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentParamsValidationWorks()
    {
        DeploymentUpdateParamsAgent value = new Sessions::BetaManagedAgentsAgentParams()
        {
            ID = "x",
            Type = Sessions::BetaManagedAgentsAgentParamsType.Agent,
            Version = 0,
        };
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DeploymentUpdateParamsAgent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentUpdateParamsAgent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentParamsSerializationRoundtripWorks()
    {
        DeploymentUpdateParamsAgent value = new Sessions::BetaManagedAgentsAgentParams()
        {
            ID = "x",
            Type = Sessions::BetaManagedAgentsAgentParamsType.Agent,
            Version = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentUpdateParamsAgent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DeploymentUpdateParamsResourceTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceParamsValidationWorks()
    {
        DeploymentUpdateParamsResource value =
            new Sessions::BetaManagedAgentsGitHubRepositoryResourceParams()
            {
                AuthorizationToken = "ghp_exampletoken",
                Type =
                    Sessions::BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
                Url = "https://github.com/example-org/example-repo",
                Checkout = new Sessions::BetaManagedAgentsBranchCheckout()
                {
                    Name = "main",
                    Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
                },
                MountPath = "x",
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileResourceParamsValidationWorks()
    {
        DeploymentUpdateParamsResource value = new Sessions::BetaManagedAgentsFileResourceParams()
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
            MountPath = "/uploads/receipt.pdf",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceParamValidationWorks()
    {
        DeploymentUpdateParamsResource value =
            new Sessions::BetaManagedAgentsMemoryStoreResourceParam()
            {
                MemoryStoreID = "memory_store_id",
                Type = Sessions::BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
                Access = Sessions::Access.ReadWrite,
                Instructions = "instructions",
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceParamsSerializationRoundtripWorks()
    {
        DeploymentUpdateParamsResource value =
            new Sessions::BetaManagedAgentsGitHubRepositoryResourceParams()
            {
                AuthorizationToken = "ghp_exampletoken",
                Type =
                    Sessions::BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
                Url = "https://github.com/example-org/example-repo",
                Checkout = new Sessions::BetaManagedAgentsBranchCheckout()
                {
                    Name = "main",
                    Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
                },
                MountPath = "x",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentUpdateParamsResource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileResourceParamsSerializationRoundtripWorks()
    {
        DeploymentUpdateParamsResource value = new Sessions::BetaManagedAgentsFileResourceParams()
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
            MountPath = "/uploads/receipt.pdf",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentUpdateParamsResource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceParamSerializationRoundtripWorks()
    {
        DeploymentUpdateParamsResource value =
            new Sessions::BetaManagedAgentsMemoryStoreResourceParam()
            {
                MemoryStoreID = "memory_store_id",
                Type = Sessions::BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
                Access = Sessions::Access.ReadWrite,
                Instructions = "instructions",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentUpdateParamsResource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
