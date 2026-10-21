using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionMultiagentCoordinatorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentCoordinator
        {
            Agents =
            [
                new BetaManagedAgentsSessionThreadAgent()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                        Effort = new BetaManagedAgentsEffortLow(),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                            },
                        },
                    ],
                    Version = 1,
                },
            ],
        };

        List<BetaManagedAgentsSessionMultiagentCoordinatorAgent> expectedAgents =
        [
            new BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("coordinator");

        Assert.Equal(expectedAgents.Count, model.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], model.Agents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentCoordinator
        {
            Agents =
            [
                new BetaManagedAgentsSessionThreadAgent()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                        Effort = new BetaManagedAgentsEffortLow(),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                            },
                        },
                    ],
                    Version = 1,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentCoordinator>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentCoordinator
        {
            Agents =
            [
                new BetaManagedAgentsSessionThreadAgent()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                        Effort = new BetaManagedAgentsEffortLow(),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                            },
                        },
                    ],
                    Version = 1,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentCoordinator>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsSessionMultiagentCoordinatorAgent> expectedAgents =
        [
            new BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("coordinator");

        Assert.Equal(expectedAgents.Count, deserialized.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], deserialized.Agents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentCoordinator
        {
            Agents =
            [
                new BetaManagedAgentsSessionThreadAgent()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                        Effort = new BetaManagedAgentsEffortLow(),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                            },
                        },
                    ],
                    Version = 1,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentCoordinator
        {
            Agents =
            [
                new BetaManagedAgentsSessionThreadAgent()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                        Effort = new BetaManagedAgentsEffortLow(),
                        InferenceGeo = "inference_geo",
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new BetaManagedAgentsBashToolConfig()
                                {
                                    Enabled = true,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                            },
                        },
                    ],
                    Version = 1,
                },
            ],
        };

        BetaManagedAgentsSessionMultiagentCoordinator copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionMultiagentCoordinatorAgentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsSessionThreadValidationWorks()
    {
        BetaManagedAgentsSessionMultiagentCoordinatorAgent value =
            new BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAdvisorValidationWorks()
    {
        BetaManagedAgentsSessionMultiagentCoordinatorAgent value = new BetaManagedAgentsAdvisor(
            "model"
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionThreadSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionMultiagentCoordinatorAgent value =
            new BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentCoordinatorAgent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAdvisorSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionMultiagentCoordinatorAgent value = new BetaManagedAgentsAdvisor(
            "model"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentCoordinatorAgent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionThreadTypeWorks()
    {
        BetaManagedAgentsSessionMultiagentCoordinatorAgent value =
            new BetaManagedAgentsSessionThreadAgent()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                ExecutionIdentity = new BetaManagedAgentsServiceAccountExecutionIdentity(),
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            };
        Assert.Equal(
            BetaManagedAgentsSessionMultiagentCoordinatorAgentType.Agent,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAdvisorTypeWorks()
    {
        BetaManagedAgentsSessionMultiagentCoordinatorAgent value = new BetaManagedAgentsAdvisor(
            "model"
        );
        Assert.Equal(
            BetaManagedAgentsSessionMultiagentCoordinatorAgentType.Advisor,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSessionMultiagentCoordinatorAgent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "agent"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorAgentType> expectedType =
            BetaManagedAgentsSessionMultiagentCoordinatorAgentType.Agent;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsSessionMultiagentCoordinatorAgent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsSessionMultiagentCoordinatorAgentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionMultiagentCoordinatorAgentType.Agent)]
    [InlineData(BetaManagedAgentsSessionMultiagentCoordinatorAgentType.Advisor)]
    public void Validation_Works(BetaManagedAgentsSessionMultiagentCoordinatorAgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorAgentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorAgentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionMultiagentCoordinatorAgentType.Agent)]
    [InlineData(BetaManagedAgentsSessionMultiagentCoordinatorAgentType.Advisor)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionMultiagentCoordinatorAgentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorAgentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorAgentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorAgentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorAgentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
