using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class AgentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentCreateParams
        {
            Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Name = "My First Agent",
            Description = "A general-purpose starter agent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
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

        Model expectedModel = BetaManagedAgentsModel.ClaudeSonnet4_6;
        string expectedName = "My First Agent";
        string expectedDescription = "A general-purpose starter agent.";
        List<BetaManagedAgentsUrlMcpServerParams> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "bar" } };
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
        List<Tool> expectedTools =
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

        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedName, parameters.Name);
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
        var parameters = new AgentCreateParams
        {
            Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Name = "My First Agent",
            Description = "A general-purpose starter agent.",
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
        };

        Assert.Null(parameters.McpServers);
        Assert.False(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Skills);
        Assert.False(parameters.RawBodyData.ContainsKey("skills"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentCreateParams
        {
            Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Name = "My First Agent",
            Description = "A general-purpose starter agent.",
            System =
                "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",

            // Null should be interpreted as omitted for these properties
            McpServers = null,
            Metadata = null,
            Skills = null,
            Tools = null,
            Betas = null,
        };

        Assert.Null(parameters.McpServers);
        Assert.False(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Skills);
        Assert.False(parameters.RawBodyData.ContainsKey("skills"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentCreateParams
        {
            Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Name = "My First Agent",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Skills =
            [
                new BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
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

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AgentCreateParams
        {
            Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Name = "My First Agent",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
            Skills =
            [
                new BetaManagedAgentsAnthropicSkillParams()
                {
                    SkillID = "xlsx",
                    Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                    Version = "1",
                },
            ],
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

            Description = null,
            System = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.System);
        Assert.True(parameters.RawBodyData.ContainsKey("system"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentCreateParams parameters = new()
        {
            Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Name = "My First Agent",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/agents?beta=true"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AgentCreateParams parameters = new()
        {
            Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Name = "My First Agent",
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
        var parameters = new AgentCreateParams
        {
            Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Name = "My First Agent",
            Description = "A general-purpose starter agent.",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "bar" } },
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

        AgentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ModelTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsValidationWorks()
    {
        Model value = BetaManagedAgentsModel.ClaudeOpus4_6;
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelConfigParamsValidationWorks()
    {
        Model value = new BetaManagedAgentsModelConfigParams()
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSerializationRoundtripWorks()
    {
        Model value = BetaManagedAgentsModel.ClaudeOpus4_6;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsModelConfigParamsSerializationRoundtripWorks()
    {
        Model value = new BetaManagedAgentsModelConfigParams()
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ToolTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsValidationWorks()
    {
        Tool value = new BetaManagedAgentsAgentToolset20260401Params()
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
        Tool value = new BetaManagedAgentsMcpToolsetParams()
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
        Tool value = new BetaManagedAgentsCustomToolParams()
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
        Tool value = new BetaManagedAgentsAgentToolset20260401Params()
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
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsSerializationRoundtripWorks()
    {
        Tool value = new BetaManagedAgentsMcpToolsetParams()
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
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsSerializationRoundtripWorks()
    {
        Tool value = new BetaManagedAgentsCustomToolParams()
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
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
