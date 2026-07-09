using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class SessionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Title = "Order #1234 inquiry",
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Agent expectedAgent = "agent_011CZkYpogX7uDKUyvBTophP";
        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<Resource> expectedResources =
        [
            new BetaManagedAgentsFileResourceParams()
            {
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                Type = BetaManagedAgentsFileResourceParamsType.File,
                MountPath = "/uploads/receipt.pdf",
            },
        ];
        string expectedTitle = "Order #1234 inquiry";
        List<string> expectedVaultIds = ["string"];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedAgent, parameters.Agent);
        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
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
        Assert.Equal(expectedTitle, parameters.Title);
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
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Title = "Order #1234 inquiry",
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
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Title = "Order #1234 inquiry",

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
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Title = null,
        };

        Assert.Null(parameters.Title);
        Assert.True(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void Url_Works()
    {
        SessionCreateParams parameters = new()
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/sessions?beta=true"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SessionCreateParams parameters = new()
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
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
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    Type = BetaManagedAgentsFileResourceParamsType.File,
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Title = "Order #1234 inquiry",
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        SessionCreateParams copied = new(parameters);

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
        Agent value = new BetaManagedAgentsAgentParams()
        {
            ID = "x",
            Type = BetaManagedAgentsAgentParamsType.Agent,
            Version = 0,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentWithOverridesParamsValidationWorks()
    {
        Agent value = new BetaManagedAgentsAgentWithOverridesParams()
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new BetaManagedAgentsModelConfigParams()
            {
                ID = BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type = BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                            BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
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
        Agent value = new BetaManagedAgentsAgentParams()
        {
            ID = "x",
            Type = BetaManagedAgentsAgentParamsType.Agent,
            Version = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentWithOverridesParamsSerializationRoundtripWorks()
    {
        Agent value = new BetaManagedAgentsAgentWithOverridesParams()
        {
            ID = "x",
            Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new BetaManagedAgentsModelConfigParams()
            {
                ID = BetaManagedAgentsModel.ClaudeOpus4_8,
                Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new BetaManagedAgentsAgentToolset20260401Params()
                {
                    Type = BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                    Configs =
                    [
                        new()
                        {
                            Name = BetaManagedAgentsAgentToolConfigParamsName.Bash,
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                            BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                },
            ],
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
        Resource value = new BetaManagedAgentsGitHubRepositoryResourceParams()
        {
            AuthorizationToken = "ghp_exampletoken",
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileResourceParamsValidationWorks()
    {
        Resource value = new BetaManagedAgentsFileResourceParams()
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,
            MountPath = "/uploads/receipt.pdf",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceParamValidationWorks()
    {
        Resource value = new BetaManagedAgentsMemoryStoreResourceParam()
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceParamsSerializationRoundtripWorks()
    {
        Resource value = new BetaManagedAgentsGitHubRepositoryResourceParams()
        {
            AuthorizationToken = "ghp_exampletoken",
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
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
        Resource value = new BetaManagedAgentsFileResourceParams()
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,
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
        Resource value = new BetaManagedAgentsMemoryStoreResourceParam()
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
            Access = Access.ReadWrite,
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
