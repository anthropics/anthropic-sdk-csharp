using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class AgentUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Version = 1,
            Description = "description",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Model = BetaManagedAgentsModel.ClaudeOpus4_6,
            Name = "name",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedAgentID = "agent_011CZkYpogX7uDKUyvBTophP";
        int expectedVersion = 1;
        string expectedDescription = "description";
        List<BetaManagedAgentsUrlMcpServerParams> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        AgentUpdateParamsModel expectedModel = BetaManagedAgentsModel.ClaudeOpus4_6;
        string expectedName = "name";
        List<BetaManagedAgentsSkillParams> expectedSkills =
        [
            new BetaManagedAgentsAnthropicSkillParams()
            {
                SkillID = "xlsx",
                Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                Version = "1",
            },
        ];
        string expectedSystem =
            "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.";
        List<AgentUpdateParamsTool> expectedTools =
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
        ];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedAgentID, parameters.AgentID);
        Assert.Equal(expectedVersion, parameters.Version);
        Assert.Equal(expectedDescription, parameters.Description);
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
        var parameters = new AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Version = 1,
            Description = "description",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Skills =
            [
                new BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Version = 1,
            Description = "description",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Skills =
            [
                new BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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

            // Null should be interpreted as omitted for these properties
            Model = null,
            Name = null,
            Betas = null,
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Version = 1,
            Model = BetaManagedAgentsModel.ClaudeOpus4_6,
            Name = "name",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.McpServers);
        Assert.False(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
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
        var parameters = new AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Version = 1,
            Model = BetaManagedAgentsModel.ClaudeOpus4_6,
            Name = "name",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Description = null,
            McpServers = null,
            Metadata = null,
            Skills = null,
            System = null,
            Tools = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.McpServers);
        Assert.True(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
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
        AgentUpdateParams parameters = new()
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Version = 1,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri("https://api.anthropic.com/v1/agents/agent_011CZkYpogX7uDKUyvBTophP?beta=true"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AgentUpdateParams parameters = new()
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Version = 1,
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
        var parameters = new AgentUpdateParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Version = 1,
            Description = "description",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Model = BetaManagedAgentsModel.ClaudeOpus4_6,
            Name = "name",
            Skills =
            [
                new BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        AgentUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AgentUpdateParamsModelTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsValidationWorks()
    {
        AgentUpdateParamsModel value = BetaManagedAgentsModel.ClaudeOpus4_6;
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelConfigParamsValidationWorks()
    {
        AgentUpdateParamsModel value = new BetaManagedAgentsModelConfigParams()
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSerializationRoundtripWorks()
    {
        AgentUpdateParamsModel value = BetaManagedAgentsModel.ClaudeOpus4_6;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentUpdateParamsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsModelConfigParamsSerializationRoundtripWorks()
    {
        AgentUpdateParamsModel value = new BetaManagedAgentsModelConfigParams()
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentUpdateParamsModel>(
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
        AgentUpdateParamsTool value = new BetaManagedAgentsAgentToolset20260401Params()
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
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsValidationWorks()
    {
        AgentUpdateParamsTool value = new BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Type = BetaManagedAgentsMcpToolsetParamsType.McpToolset,
            Configs =
            [
                new()
                {
                    Name = "x",
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
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsValidationWorks()
    {
        AgentUpdateParamsTool value = new BetaManagedAgentsCustomToolParams()
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "x",
            Type = BetaManagedAgentsCustomToolParamsType.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsSerializationRoundtripWorks()
    {
        AgentUpdateParamsTool value = new BetaManagedAgentsAgentToolset20260401Params()
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentUpdateParamsTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsSerializationRoundtripWorks()
    {
        AgentUpdateParamsTool value = new BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Type = BetaManagedAgentsMcpToolsetParamsType.McpToolset,
            Configs =
            [
                new()
                {
                    Name = "x",
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentUpdateParamsTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsSerializationRoundtripWorks()
    {
        AgentUpdateParamsTool value = new BetaManagedAgentsCustomToolParams()
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "x",
            Type = BetaManagedAgentsCustomToolParamsType.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentUpdateParamsTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
