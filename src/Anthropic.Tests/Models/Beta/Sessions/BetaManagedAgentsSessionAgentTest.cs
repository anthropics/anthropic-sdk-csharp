using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "id",
            Description = "description",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "name",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = BetaManagedAgentsSessionAgentType.Agent,
            Version = 0,
        };

        string expectedID = "id";
        string expectedDescription = "description";
        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = Agents::Speed.Standard,
        };
        string expectedName = "name";
        List<Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
        ];
        string expectedSystem = "system";
        List<Tool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new()
                    {
                        Enabled = true,
                        Name = Agents::Name.Bash,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
                Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
            },
        ];
        ApiEnum<string, BetaManagedAgentsSessionAgentType> expectedType =
            BetaManagedAgentsSessionAgentType.Agent;
        int expectedVersion = 0;

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
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "id",
            Description = "description",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "name",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = BetaManagedAgentsSessionAgentType.Agent,
            Version = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "id",
            Description = "description",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "name",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = BetaManagedAgentsSessionAgentType.Agent,
            Version = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "description";
        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = Agents::Speed.Standard,
        };
        string expectedName = "name";
        List<Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill()
            {
                SkillID = "xlsx",
                Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                Version = "1",
            },
        ];
        string expectedSystem = "system";
        List<Tool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new()
                    {
                        Enabled = true,
                        Name = Agents::Name.Bash,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
                Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
            },
        ];
        ApiEnum<string, BetaManagedAgentsSessionAgentType> expectedType =
            BetaManagedAgentsSessionAgentType.Agent;
        int expectedVersion = 0;

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
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "id",
            Description = "description",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "name",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = BetaManagedAgentsSessionAgentType.Agent,
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionAgent
        {
            ID = "id",
            Description = "description",
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Type = Agents::BetaManagedAgentsMcpServerUrlDefinitionType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Model = new()
            {
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus4_6,
                Speed = Agents::Speed.Standard,
            },
            Name = "name",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill()
                {
                    SkillID = "xlsx",
                    Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
                    Version = "1",
                },
            ],
            System = "system",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new()
                        {
                            Enabled = true,
                            Name = Agents::Name.Bash,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                                Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                            ),
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                            Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                        ),
                    },
                    Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                },
            ],
            Type = BetaManagedAgentsSessionAgentType.Agent,
            Version = 0,
        };

        BetaManagedAgentsSessionAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SkillTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAnthropicValidationWorks()
    {
        Skill value = new Agents::BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        Skill value = new Agents::BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAnthropicSerializationRoundtripWorks()
    {
        Skill value = new Agents::BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Type = Agents::BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        Skill value = new Agents::BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = Agents::BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ToolTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ValidationWorks()
    {
        Tool value = new Agents::BetaManagedAgentsAgentToolset20260401()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = Agents::Name.Bash,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                    Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetValidationWorks()
    {
        Tool value = new Agents::BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                    Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            McpServerName = "mcp_server_name",
            Type = Agents::BetaManagedAgentsMcpToolsetType.McpToolset,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        Tool value = new Agents::BetaManagedAgentsCustomTool()
        {
            Description = "description",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = Agents::BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "name",
            Type = Agents::BetaManagedAgentsCustomToolType.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401SerializationRoundtripWorks()
    {
        Tool value = new Agents::BetaManagedAgentsAgentToolset20260401()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = Agents::Name.Bash,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                    Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            Type = Agents::BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetSerializationRoundtripWorks()
    {
        Tool value = new Agents::BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                        Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                    ),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(
                    Agents::BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow
                ),
            },
            McpServerName = "mcp_server_name",
            Type = Agents::BetaManagedAgentsMcpToolsetType.McpToolset,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomSerializationRoundtripWorks()
    {
        Tool value = new Agents::BetaManagedAgentsCustomTool()
        {
            Description = "description",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = Agents::BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "name",
            Type = Agents::BetaManagedAgentsCustomToolType.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsSessionAgentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionAgentType.Agent)]
    public void Validation_Works(BetaManagedAgentsSessionAgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionAgentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSessionAgentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionAgentType.Agent)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionAgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionAgentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSessionAgentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
