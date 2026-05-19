using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsSessionThreadAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadAgent
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
            Model = new() { ID = BetaManagedAgentsModel.ClaudeSonnet4_6, Speed = Speed.Standard },
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
        };

        string expectedID = "agent_011CZkYqphY8vELVzwCUpqiQ";
        string expectedDescription = "A focused research subagent.";
        List<BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Speed = Speed.Standard,
        };
        string expectedName = "Researcher";
        List<BetaManagedAgentsSessionThreadAgentSkill> expectedSkills =
        [
            new BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
        ];
        string expectedSystem =
            "You are a research subagent that gathers and summarises sources for the coordinating agent.";
        List<BetaManagedAgentsSessionThreadAgentTool> expectedTools =
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
        ];
        ApiEnum<string, BetaManagedAgentsSessionThreadAgentType> expectedType =
            BetaManagedAgentsSessionThreadAgentType.Agent;
        int expectedVersion = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMcpServers.Count, model.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], model.McpServers[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSkills.Count, model.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], model.Skills[i]);
        }
        Assert.Equal(expectedSystem, model.System);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadAgent
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
            Model = new() { ID = BetaManagedAgentsModel.ClaudeSonnet4_6, Speed = Speed.Standard },
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionThreadAgent
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
            Model = new() { ID = BetaManagedAgentsModel.ClaudeSonnet4_6, Speed = Speed.Standard },
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "agent_011CZkYqphY8vELVzwCUpqiQ";
        string expectedDescription = "A focused research subagent.";
        List<BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = BetaManagedAgentsModel.ClaudeSonnet4_6,
            Speed = Speed.Standard,
        };
        string expectedName = "Researcher";
        List<BetaManagedAgentsSessionThreadAgentSkill> expectedSkills =
        [
            new BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
        ];
        string expectedSystem =
            "You are a research subagent that gathers and summarises sources for the coordinating agent.";
        List<BetaManagedAgentsSessionThreadAgentTool> expectedTools =
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
        ];
        ApiEnum<string, BetaManagedAgentsSessionThreadAgentType> expectedType =
            BetaManagedAgentsSessionThreadAgentType.Agent;
        int expectedVersion = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMcpServers.Count, deserialized.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], deserialized.McpServers[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSkills.Count, deserialized.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], deserialized.Skills[i]);
        }
        Assert.Equal(expectedSystem, deserialized.System);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadAgent
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
            Model = new() { ID = BetaManagedAgentsModel.ClaudeSonnet4_6, Speed = Speed.Standard },
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadAgent
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
            Model = new() { ID = BetaManagedAgentsModel.ClaudeSonnet4_6, Speed = Speed.Standard },
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
        };

        BetaManagedAgentsSessionThreadAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionThreadAgentSkillTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAnthropicValidationWorks()
    {
        BetaManagedAgentsSessionThreadAgentSkill value = new BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        BetaManagedAgentsSessionThreadAgentSkill value = new BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAnthropicSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadAgentSkill value = new BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgentSkill>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadAgentSkill value = new BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgentSkill>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsSessionThreadAgentToolTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ValidationWorks()
    {
        BetaManagedAgentsSessionThreadAgentTool value = new BetaManagedAgentsAgentToolset20260401()
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
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetValidationWorks()
    {
        BetaManagedAgentsSessionThreadAgentTool value = new BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
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
            McpServerName = "mcp_server_name",
            Type = BetaManagedAgentsMcpToolsetType.McpToolset,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        BetaManagedAgentsSessionThreadAgentTool value = new BetaManagedAgentsCustomTool()
        {
            Description = "description",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "name",
            Type = BetaManagedAgentsCustomToolType.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401SerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadAgentTool value = new BetaManagedAgentsAgentToolset20260401()
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
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(
                    BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            Type = BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadAgentTool value = new BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
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
            McpServerName = "mcp_server_name",
            Type = BetaManagedAgentsMcpToolsetType.McpToolset,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadAgentTool value = new BetaManagedAgentsCustomTool()
        {
            Description = "description",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "name",
            Type = BetaManagedAgentsCustomToolType.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsSessionThreadAgentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadAgentType.Agent)]
    public void Validation_Works(BetaManagedAgentsSessionThreadAgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadAgentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadAgentType.Agent)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionThreadAgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadAgentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
