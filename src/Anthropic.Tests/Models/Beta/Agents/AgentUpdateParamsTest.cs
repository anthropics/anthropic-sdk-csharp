using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class AgentUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Agents::AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "updated",
            ExecutionIdentity = new Agents::BetaManagedAgentsAwsRoleExecutionIdentityParams(
                "role_arn"
            ),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = Agents::BetaManagedAgentsEffortLevel.Low,
                InferenceGeo = "inference_geo",
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Multiagent = new Agents::BetaManagedAgentsMultiagentCoordinatorParams(
                [
                    "agent_011CZkYqphY8vELVzwCUpqiQ",
                    new Agents::BetaManagedAgentsMultiagentSelfParams(),
                ]
            ),
            Name = "name",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Version = "1",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            Version = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string expectedAgentID = "agent_011CZkYpogX7uDKUyvBTophP";
        string expectedDescription = "updated";
        Agents::BetaManagedAgentsExecutionIdentityParams expectedExecutionIdentity =
            new Agents::BetaManagedAgentsAwsRoleExecutionIdentityParams("role_arn");
        List<Agents::BetaManagedAgentsUrlMcpServerParams> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        Agents::AgentUpdateParamsModel expectedModel =
            new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = Agents::BetaManagedAgentsEffortLevel.Low,
                InferenceGeo = "inference_geo",
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            };
        BetaManagedAgentsMultiagentParams expectedMultiagent =
            new Agents::BetaManagedAgentsMultiagentCoordinatorParams(
                [
                    "agent_011CZkYqphY8vELVzwCUpqiQ",
                    new Agents::BetaManagedAgentsMultiagentSelfParams(),
                ]
            );
        string expectedName = "name";
        List<Agents::BetaManagedAgentsSkillParams> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkillParams() { SkillID = "xlsx", Version = "1" },
        ];
        string expectedSystem =
            "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.";
        List<Agents::AgentUpdateParamsTool> expectedTools =
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
        ];
        int expectedVersion = 1;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedAgentID, parameters.AgentID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedExecutionIdentity, parameters.ExecutionIdentity);
        Assert.NotNull(parameters.McpServers);
        Assert.Equal(expectedMcpServers.Count, parameters.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], parameters.McpServers[i]);
        }
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedMultiagent, parameters.Multiagent);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Skills);
        Assert.Equal(expectedSkills.Count, parameters.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], parameters.Skills[i]);
        }
        Assert.Equal(expectedSystem, parameters.System);
        Assert.NotNull(parameters.Tools);
        Assert.Equal(expectedTools.Count, parameters.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], parameters.Tools[i]);
        }
        Assert.Equal(expectedVersion, parameters.Version);
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
        var parameters = new Agents::AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "updated",
            ExecutionIdentity = new Agents::BetaManagedAgentsAwsRoleExecutionIdentityParams(
                "role_arn"
            ),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Multiagent = new Agents::BetaManagedAgentsMultiagentCoordinatorParams(
                [
                    "agent_011CZkYqphY8vELVzwCUpqiQ",
                    new Agents::BetaManagedAgentsMultiagentSelfParams(),
                ]
            ),
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Version = "1",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Agents::AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "updated",
            ExecutionIdentity = new Agents::BetaManagedAgentsAwsRoleExecutionIdentityParams(
                "role_arn"
            ),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Multiagent = new Agents::BetaManagedAgentsMultiagentCoordinatorParams(
                [
                    "agent_011CZkYqphY8vELVzwCUpqiQ",
                    new Agents::BetaManagedAgentsMultiagentSelfParams(),
                ]
            ),
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Version = "1",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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

            // Null should be interpreted as omitted for these properties
            Model = null,
            Name = null,
            Version = null,
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new Agents::AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "updated",
            ExecutionIdentity = new Agents::BetaManagedAgentsAwsRoleExecutionIdentityParams(
                "role_arn"
            ),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = Agents::BetaManagedAgentsEffortLevel.Low,
                InferenceGeo = "inference_geo",
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Multiagent = new Agents::BetaManagedAgentsMultiagentCoordinatorParams(
                [
                    "agent_011CZkYqphY8vELVzwCUpqiQ",
                    new Agents::BetaManagedAgentsMultiagentSelfParams(),
                ]
            ),
            Name = "name",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Version = "1",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            Version = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        } with
        {
            // Null should be interpreted as omitted for these properties
            Model = null,
            Name = null,
            Version = null,
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Agents::AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = Agents::BetaManagedAgentsEffortLevel.Low,
                InferenceGeo = "inference_geo",
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Name = "name",
            Version = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExecutionIdentity);
        Assert.False(parameters.RawBodyData.ContainsKey("execution_identity"));
        Assert.Null(parameters.McpServers);
        Assert.False(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Multiagent);
        Assert.False(parameters.RawBodyData.ContainsKey("multiagent"));
        Assert.Null(parameters.Skills);
        Assert.False(parameters.RawBodyData.ContainsKey("skills"));
        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Agents::AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = Agents::BetaManagedAgentsEffortLevel.Low,
                InferenceGeo = "inference_geo",
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Name = "name",
            Version = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",

            Description = null,
            ExecutionIdentity = null,
            McpServers = null,
            Metadata = null,
            Multiagent = null,
            Skills = null,
            System = null,
            Tools = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExecutionIdentity);
        Assert.True(parameters.RawBodyData.ContainsKey("execution_identity"));
        Assert.Null(parameters.McpServers);
        Assert.True(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Multiagent);
        Assert.True(parameters.RawBodyData.ContainsKey("multiagent"));
        Assert.Null(parameters.Skills);
        Assert.True(parameters.RawBodyData.ContainsKey("skills"));
        Assert.Null(parameters.System);
        Assert.True(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Tools);
        Assert.True(parameters.RawBodyData.ContainsKey("tools"));
    }

    [Fact]
    public void Url_Works()
    {
        Agents::AgentUpdateParams parameters = new() { AgentID = "agent_011CZkYpogX7uDKUyvBTophP" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/agents/agent_011CZkYpogX7uDKUyvBTophP"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        Agents::AgentUpdateParams parameters = new()
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
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
        var parameters = new Agents::AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Description = "updated",
            ExecutionIdentity = new Agents::BetaManagedAgentsAwsRoleExecutionIdentityParams(
                "role_arn"
            ),
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Model = new Agents::BetaManagedAgentsModelConfigParams()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = Agents::BetaManagedAgentsEffortLevel.Low,
                InferenceGeo = "inference_geo",
                Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
            },
            Multiagent = new Agents::BetaManagedAgentsMultiagentCoordinatorParams(
                [
                    "agent_011CZkYqphY8vELVzwCUpqiQ",
                    new Agents::BetaManagedAgentsMultiagentSelfParams(),
                ]
            ),
            Name = "name",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Version = "1",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            Version = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        Agents::AgentUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AgentUpdateParamsModelTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsValidationWorks()
    {
        Agents::AgentUpdateParamsModel value = Agents::BetaManagedAgentsModel.ClaudeHaiku5_5;
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelConfigParamsValidationWorks()
    {
        Agents::AgentUpdateParamsModel value = new Agents::BetaManagedAgentsModelConfigParams()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = Agents::BetaManagedAgentsEffortLevel.Low,
            InferenceGeo = "inference_geo",
            Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSerializationRoundtripWorks()
    {
        Agents::AgentUpdateParamsModel value = Agents::BetaManagedAgentsModel.ClaudeHaiku5_5;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::AgentUpdateParamsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsModelConfigParamsSerializationRoundtripWorks()
    {
        Agents::AgentUpdateParamsModel value = new Agents::BetaManagedAgentsModelConfigParams()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = Agents::BetaManagedAgentsEffortLevel.Low,
            InferenceGeo = "inference_geo",
            Speed = Agents::BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::AgentUpdateParamsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentUpdateParamsToolTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsValidationWorks()
    {
        Agents::AgentUpdateParamsTool value =
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
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsValidationWorks()
    {
        Agents::AgentUpdateParamsTool value = new Agents::BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsValidationWorks()
    {
        Agents::AgentUpdateParamsTool value = new Agents::BetaManagedAgentsCustomToolParams()
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
            },
            Name = "x",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsSerializationRoundtripWorks()
    {
        Agents::AgentUpdateParamsTool value =
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::AgentUpdateParamsTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsSerializationRoundtripWorks()
    {
        Agents::AgentUpdateParamsTool value = new Agents::BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::AgentUpdateParamsTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsSerializationRoundtripWorks()
    {
        Agents::AgentUpdateParamsTool value = new Agents::BetaManagedAgentsCustomToolParams()
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
            },
            Name = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agents::AgentUpdateParamsTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsTypeWorks()
    {
        Agents::AgentUpdateParamsTool value =
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
            };
        Assert.Equal(Agents::AgentUpdateParamsToolType.AgentToolset20260401, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsTypeWorks()
    {
        Agents::AgentUpdateParamsTool value = new Agents::BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };
        Assert.Equal(Agents::AgentUpdateParamsToolType.McpToolset, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsTypeWorks()
    {
        Agents::AgentUpdateParamsTool value = new Agents::BetaManagedAgentsCustomToolParams()
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
            },
            Name = "x",
        };
        Assert.Equal(Agents::AgentUpdateParamsToolType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Agents::AgentUpdateParamsTool value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "agent_toolset_20260401"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, Agents::AgentUpdateParamsToolType> expectedType =
            Agents::AgentUpdateParamsToolType.AgentToolset20260401;

        Assert.Equal(expectedType, value.Type);

        Agents::AgentUpdateParamsTool emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class AgentUpdateParamsToolTypeTest : TestBase
{
    [Theory]
    [InlineData(Agents::AgentUpdateParamsToolType.AgentToolset20260401)]
    [InlineData(Agents::AgentUpdateParamsToolType.McpToolset)]
    [InlineData(Agents::AgentUpdateParamsToolType.Custom)]
    public void Validation_Works(Agents::AgentUpdateParamsToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Agents::AgentUpdateParamsToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Agents::AgentUpdateParamsToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Agents::AgentUpdateParamsToolType.AgentToolset20260401)]
    [InlineData(Agents::AgentUpdateParamsToolType.McpToolset)]
    [InlineData(Agents::AgentUpdateParamsToolType.Custom)]
    public void SerializationRoundtrip_Works(Agents::AgentUpdateParamsToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Agents::AgentUpdateParamsToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Agents::AgentUpdateParamsToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Agents::AgentUpdateParamsToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Agents::AgentUpdateParamsToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
