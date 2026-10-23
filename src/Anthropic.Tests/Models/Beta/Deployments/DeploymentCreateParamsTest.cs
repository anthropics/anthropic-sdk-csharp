using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Name = "x",
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Schedule = new() { Expression = "0 9 * * 1-5", Timezone = "America/Los_Angeles" },
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        Agent expectedAgent = "string";
        string expectedEnvironmentID = "x";
        List<BetaManagedAgentsDeploymentInitialEventParams> expectedInitialEvents =
        [
            new BetaManagedAgentsUserMessageEventParams(
                [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
            ),
        ];
        string expectedName = "x";
        Sessions::BetaManagedAgentsBudgetLimit expectedBudget = new(
            new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
        );
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<Resource> expectedResources =
        [
            new Sessions::BetaManagedAgentsFileResourceParams()
            {
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                MountPath = "/uploads/receipt.pdf",
            },
        ];
        BetaManagedAgentsScheduleParams expectedSchedule = new()
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
        };
        List<string> expectedVaultIds = ["string"];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedAgent, parameters.Agent);
        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
        Assert.Equal(expectedInitialEvents.Count, parameters.InitialEvents.Count);
        for (int i = 0; i < expectedInitialEvents.Count; i++)
        {
            Assert.Equal(expectedInitialEvents[i], parameters.InitialEvents[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedBudget, parameters.Budget);
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
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
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
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Name = "x",
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Description = "description",
            Schedule = new() { Expression = "0 9 * * 1-5", Timezone = "America/Los_Angeles" },
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Resources);
        Assert.False(parameters.RawBodyData.ContainsKey("resources"));
        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
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
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Name = "x",
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Description = "description",
            Schedule = new() { Expression = "0 9 * * 1-5", Timezone = "America/Los_Angeles" },

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Resources = null,
            VaultIds = null,
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Resources);
        Assert.False(parameters.RawBodyData.ContainsKey("resources"));
        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new DeploymentCreateParams
        {
            Agent = "string",
            EnvironmentID = "x",
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Name = "x",
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Schedule = new() { Expression = "0 9 * * 1-5", Timezone = "America/Los_Angeles" },
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        } with
        {
            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Resources = null,
            VaultIds = null,
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Resources);
        Assert.False(parameters.RawBodyData.ContainsKey("resources"));
        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
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
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Name = "x",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        Assert.Null(parameters.Budget);
        Assert.False(parameters.RawBodyData.ContainsKey("budget"));
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
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Name = "x",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",

            Budget = null,
            Description = null,
            Schedule = null,
        };

        Assert.Null(parameters.Budget);
        Assert.True(parameters.RawBodyData.ContainsKey("budget"));
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
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Name = "x",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/deployments"), url));
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
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,managed-agents-2026-04-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
        Assert.Equal(
            ["wrkspc_011CZkZaBF1tNoB5wlCeusgy"],
            requestMessage.Headers.GetValues("anthropic-workspace-id")
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
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Name = "x",
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new Sessions::BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Schedule = new() { Expression = "0 9 * * 1-5", Timezone = "America/Los_Angeles" },
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
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
        Agent value = new Sessions::BetaManagedAgentsAgentParams() { ID = "x", Version = 0 };
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
        Agent value = new Sessions::BetaManagedAgentsAgentParams() { ID = "x", Version = 0 };
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
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new Sessions::BetaManagedAgentsBranchCheckout("main"),
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
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new Sessions::BetaManagedAgentsBranchCheckout("main"),
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

    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceParamsTypeWorks()
    {
        Resource value = new Sessions::BetaManagedAgentsGitHubRepositoryResourceParams()
        {
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new Sessions::BetaManagedAgentsBranchCheckout("main"),
            MountPath = "x",
        };
        Assert.Equal(ResourceType.GitHubRepository, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsFileResourceParamsTypeWorks()
    {
        Resource value = new Sessions::BetaManagedAgentsFileResourceParams()
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
        };
        Assert.Equal(ResourceType.File, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceParamTypeWorks()
    {
        Resource value = new Sessions::BetaManagedAgentsMemoryStoreResourceParam()
        {
            MemoryStoreID = "memory_store_id",
            Access = Sessions::Access.ReadWrite,
            Instructions = "instructions",
        };
        Assert.Equal(ResourceType.MemoryStore, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Resource value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "file",
                  "mount_path": "x"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ResourceType> expectedType = ResourceType.File;
        string expectedMountPath = "x";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedMountPath, value.MountPath);

        Resource emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.MountPath);

        Resource mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "mount_path": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.MountPath);
    }
}

public class ResourceTypeTest : TestBase
{
    [Theory]
    [InlineData(ResourceType.GitHubRepository)]
    [InlineData(ResourceType.File)]
    [InlineData(ResourceType.MemoryStore)]
    public void Validation_Works(ResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResourceType.GitHubRepository)]
    [InlineData(ResourceType.File)]
    [InlineData(ResourceType.MemoryStore)]
    public void SerializationRoundtrip_Works(ResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
