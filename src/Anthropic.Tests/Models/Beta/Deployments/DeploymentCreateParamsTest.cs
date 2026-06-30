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

public class DeploymentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeploymentCreateParams
        {
            Agent = "string",
            EnvironmentID = "x",
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
            Name = "x",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
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

        Agent expectedAgent = "string";
        string expectedEnvironmentID = "x";
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
        string expectedName = "x";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<Resource> expectedResources =
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

        Assert.Equal(expectedAgent, parameters.Agent);
        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
        Assert.Equal(expectedInitialEvents.Count, parameters.InitialEvents.Count);
        for (int i = 0; i < expectedInitialEvents.Count; i++)
        {
            Assert.Equal(expectedInitialEvents[i], parameters.InitialEvents[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
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
        var parameters = new DeploymentCreateParams
        {
            Agent = "string",
            EnvironmentID = "x",
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
            Name = "x",
            Description = "description",
            Schedule = new()
            {
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleParamsType.Cron,
            },
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Resources);
        Assert.False(parameters.RawBodyData.ContainsKey("resources"));
        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DeploymentCreateParams
        {
            Agent = "string",
            EnvironmentID = "x",
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
            Name = "x",
            Description = "description",
            Schedule = new()
            {
                Expression = "0 9 * * 1-5",
                Timezone = "America/Los_Angeles",
                Type = BetaManagedAgentsScheduleParamsType.Cron,
            },

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Resources = null,
            VaultIds = null,
            Betas = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Resources);
        Assert.False(parameters.RawBodyData.ContainsKey("resources"));
        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeploymentCreateParams
        {
            Agent = "string",
            EnvironmentID = "x",
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
            Name = "x",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Schedule);
        Assert.False(parameters.RawBodyData.ContainsKey("schedule"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DeploymentCreateParams
        {
            Agent = "string",
            EnvironmentID = "x",
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
            Name = "x",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Description = null,
            Schedule = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Schedule);
        Assert.True(parameters.RawBodyData.ContainsKey("schedule"));
    }

    [Fact]
    public void Url_Works()
    {
        DeploymentCreateParams parameters = new()
        {
            Agent = "string",
            EnvironmentID = "x",
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
            Name = "x",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/deployments?beta=true"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        DeploymentCreateParams parameters = new()
        {
            Agent = "string",
            EnvironmentID = "x",
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
            Name = "x",
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
        var parameters = new DeploymentCreateParams
        {
            Agent = "string",
            EnvironmentID = "x",
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
            Name = "x",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
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

        DeploymentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AgentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Agent value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentParamsValidationWorks()
    {
        Agent value = new Sessions::BetaManagedAgentsAgentParams()
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
        Agent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentParamsSerializationRoundtripWorks()
    {
        Agent value = new Sessions::BetaManagedAgentsAgentParams()
        {
            ID = "x",
            Type = Sessions::BetaManagedAgentsAgentParamsType.Agent,
            Version = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ResourceTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceParamsValidationWorks()
    {
        Resource value = new Sessions::BetaManagedAgentsGitHubRepositoryResourceParams()
        {
            AuthorizationToken = "ghp_exampletoken",
            Type = Sessions::BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
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
        Resource value = new Sessions::BetaManagedAgentsFileResourceParams()
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
        Resource value = new Sessions::BetaManagedAgentsMemoryStoreResourceParam()
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
        Resource value = new Sessions::BetaManagedAgentsGitHubRepositoryResourceParams()
        {
            AuthorizationToken = "ghp_exampletoken",
            Type = Sessions::BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            Checkout = new Sessions::BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileResourceParamsSerializationRoundtripWorks()
    {
        Resource value = new Sessions::BetaManagedAgentsFileResourceParams()
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = Sessions::BetaManagedAgentsFileResourceParamsType.File,
            MountPath = "/uploads/receipt.pdf",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceParamSerializationRoundtripWorks()
    {
        Resource value = new Sessions::BetaManagedAgentsMemoryStoreResourceParam()
        {
            MemoryStoreID = "memory_store_id",
            Type = Sessions::BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
            Access = Sessions::Access.ReadWrite,
            Instructions = "instructions",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
