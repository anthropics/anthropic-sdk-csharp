using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;
using Agents = Anthropic.Models.Beta.Agents;

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
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Title = "Order #1234 inquiry",
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        Agent expectedAgent = "agent_011CZkYpogX7uDKUyvBTophP";
        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        BetaManagedAgentsBudgetLimit expectedBudget = new(
            new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
        );
        List<InitialEvent> expectedInitialEvents =
        [
            new BetaManagedAgentsUserMessageEventParams(
                [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
            ),
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<Resource> expectedResources =
        [
            new BetaManagedAgentsFileResourceParams()
            {
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                MountPath = "/uploads/receipt.pdf",
            },
        ];
        string expectedTitle = "Order #1234 inquiry";
        List<string> expectedVaultIds = ["string"];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedAgent, parameters.Agent);
        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
        Assert.Equal(expectedBudget, parameters.Budget);
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
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
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

        Assert.Null(parameters.Budget);
        Assert.False(parameters.RawBodyData.ContainsKey("budget"));
        Assert.Null(parameters.InitialEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("initial_events"));
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
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Title = "Order #1234 inquiry",

            // Null should be interpreted as omitted for these properties
            Budget = null,
            InitialEvents = null,
            Metadata = null,
            Resources = null,
            VaultIds = null,
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Budget);
        Assert.False(parameters.RawBodyData.ContainsKey("budget"));
        Assert.Null(parameters.InitialEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("initial_events"));
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
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Title = "Order #1234 inquiry",
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        } with
        {
            // Null should be interpreted as omitted for these properties
            Budget = null,
            InitialEvents = null,
            Metadata = null,
            Resources = null,
            VaultIds = null,
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Budget);
        Assert.False(parameters.RawBodyData.ContainsKey("budget"));
        Assert.Null(parameters.InitialEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("initial_events"));
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
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
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
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",

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

        Assert.True(TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/sessions"), url));
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
        var parameters = new SessionCreateParams
        {
            Agent = "agent_011CZkYpogX7uDKUyvBTophP",
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            InitialEvents =
            [
                new BetaManagedAgentsUserMessageEventParams(
                    [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                ),
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Resources =
            [
                new BetaManagedAgentsFileResourceParams()
                {
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                },
            ],
            Title = "Order #1234 inquiry",
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
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
        Agent value = new BetaManagedAgentsAgentParams() { ID = "x", Version = 0 };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentWithOverridesParamsValidationWorks()
    {
        Agent value = new BetaManagedAgentsAgentWithOverridesParams()
        {
            ID = "x",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = Agents::BetaManagedAgentsEffortLevel.Low,
                InferenceGeo = "inference_geo",
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfigParams()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            Type = Agents::Type.Bash,
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
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
        Agent value = new BetaManagedAgentsAgentParams() { ID = "x", Version = 0 };
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
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = Agents::BetaManagedAgentsEffortLevel.Low,
                InferenceGeo = "inference_geo",
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401Params()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfigParams()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            Type = Agents::Type.Bash,
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
            Version = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Agent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "x",
                  "type": "agent",
                  "version": 0
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");
        int expectedVersion = 0;

        Assert.Equal(expectedID, value.ID);
        Assert.NotNull(value.Type);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type.Value));
        Assert.Equal(expectedVersion, value.Version);

        Agent emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.ID);
        Assert.Null(emptyValue.Type);
        Assert.Null(emptyValue.Version);

        Agent mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ],
                  "version": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ID);
        Assert.Null(mismatchedValue.Version);
    }
}

public class InitialEventTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsUserMessageEventParamsValidationWorks()
    {
        InitialEvent value = new BetaManagedAgentsUserMessageEventParams(
            [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUserDefineOutcomeEventParamsValidationWorks()
    {
        InitialEvent value = new BetaManagedAgentsUserDefineOutcomeEventParams()
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams(
                "Must cover all five sections; cite sources inline."
            ),
            MaxIterations = 3,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUserMessageEventParamsSerializationRoundtripWorks()
    {
        InitialEvent value = new BetaManagedAgentsUserMessageEventParams(
            [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InitialEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUserDefineOutcomeEventParamsSerializationRoundtripWorks()
    {
        InitialEvent value = new BetaManagedAgentsUserDefineOutcomeEventParams()
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams(
                "Must cover all five sections; cite sources inline."
            ),
            MaxIterations = 3,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InitialEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUserMessageEventParamsTypeWorks()
    {
        InitialEvent value = new BetaManagedAgentsUserMessageEventParams(
            [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
        );
        Assert.Equal(InitialEventType.UserMessage, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsUserDefineOutcomeEventParamsTypeWorks()
    {
        InitialEvent value = new BetaManagedAgentsUserDefineOutcomeEventParams()
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams(
                "Must cover all five sections; cite sources inline."
            ),
            MaxIterations = 3,
        };
        Assert.Equal(InitialEventType.UserDefineOutcome, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        InitialEvent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user.message"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, InitialEventType> expectedType = InitialEventType.UserMessage;

        Assert.Equal(expectedType, value.Type);

        InitialEvent emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class InitialEventTypeTest : TestBase
{
    [Theory]
    [InlineData(InitialEventType.UserMessage)]
    [InlineData(InitialEventType.UserDefineOutcome)]
    public void Validation_Works(InitialEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InitialEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InitialEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InitialEventType.UserMessage)]
    [InlineData(InitialEventType.UserDefineOutcome)]
    public void SerializationRoundtrip_Works(InitialEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InitialEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InitialEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InitialEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InitialEventType>>(
            json,
            ModelBase.SerializerOptions
        );

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
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
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
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
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

    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceParamsTypeWorks()
    {
        Resource value = new BetaManagedAgentsGitHubRepositoryResourceParams()
        {
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
            MountPath = "x",
        };
        Assert.Equal(ResourceType.GitHubRepository, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsFileResourceParamsTypeWorks()
    {
        Resource value = new BetaManagedAgentsFileResourceParams()
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
        };
        Assert.Equal(ResourceType.File, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceParamTypeWorks()
    {
        Resource value = new BetaManagedAgentsMemoryStoreResourceParam()
        {
            MemoryStoreID = "memory_store_id",
            Access = Access.ReadWrite,
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
