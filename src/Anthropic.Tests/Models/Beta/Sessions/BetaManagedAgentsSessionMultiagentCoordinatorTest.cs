using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Threads;

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
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new()
                                {
                                    Enabled = true,
                                    Name = Name.Bash,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
        };

        List<BetaManagedAgentsSessionThreadAgent> expectedAgents =
        [
            new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                        Version = "1",
                    },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new()
                            {
                                Enabled = true,
                                Name = Name.Bash,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                ),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                            ),
                        },
                        Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                    },
                ],
                Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                Version = 1,
            },
        ];
        ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType> expectedType =
            BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator;

        Assert.Equal(expectedAgents.Count, model.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], model.Agents[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentCoordinator
        {
            Agents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new()
                                {
                                    Enabled = true,
                                    Name = Name.Bash,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
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
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new()
                                {
                                    Enabled = true,
                                    Name = Name.Bash,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentCoordinator>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsSessionThreadAgent> expectedAgents =
        [
            new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Description = "A focused research subagent.",
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                    Speed = Speed.Standard,
                },
                Name = "Researcher",
                Skills =
                [
                    new BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                        Version = "1",
                    },
                ],
                System =
                    "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                Tools =
                [
                    new BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new()
                            {
                                Enabled = true,
                                Name = Name.Bash,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                ),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                            ),
                        },
                        Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                    },
                ],
                Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                Version = 1,
            },
        ];
        ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType> expectedType =
            BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator;

        Assert.Equal(expectedAgents.Count, deserialized.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], deserialized.Agents[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionMultiagentCoordinator
        {
            Agents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new()
                                {
                                    Enabled = true,
                                    Name = Name.Bash,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
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
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Description = "A focused research subagent.",
                    McpServers =
                    [
                        new()
                        {
                            Name = "example-mcp",
                            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                            Url = "https://example-server.modelcontextprotocol.io/sse",
                        },
                    ],
                    Model = new()
                    {
                        ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
                        Speed = Speed.Standard,
                    },
                    Name = "Researcher",
                    Skills =
                    [
                        new BetaManagedAgentsAnthropicSkill()
                        {
                            SkillID = "xlsx",
                            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                            Version = "1",
                        },
                    ],
                    System =
                        "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                    Tools =
                    [
                        new BetaManagedAgentsAgentToolset20260401()
                        {
                            Configs =
                            [
                                new()
                                {
                                    Enabled = true,
                                    Name = Name.Bash,
                                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                                        BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                                    ),
                                },
                            ],
                            DefaultConfig = new()
                            {
                                Enabled = true,
                                PermissionPolicy = new BetaManagedAgentsAlwaysAskPolicy(
                                    BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk
                                ),
                            },
                            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                        },
                    ],
                    Type = BetaManagedAgentsSessionThreadAgentType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
        };

        BetaManagedAgentsSessionMultiagentCoordinator copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionMultiagentCoordinatorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator)]
    public void Validation_Works(BetaManagedAgentsSessionMultiagentCoordinatorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionMultiagentCoordinatorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
