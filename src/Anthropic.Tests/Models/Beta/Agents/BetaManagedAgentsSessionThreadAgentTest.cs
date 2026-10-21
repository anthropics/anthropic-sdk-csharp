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
            Skills = [new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" }],
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

        string expectedID = "agent_011CZkYqphY8vELVzwCUpqiQ";
        string expectedDescription = "A focused research subagent.";
        BetaManagedAgentsExecutionIdentity expectedExecutionIdentity =
            new BetaManagedAgentsServiceAccountExecutionIdentity();
        List<BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };
        string expectedName = "Researcher";
        List<BetaManagedAgentsSessionThreadAgentSkill> expectedSkills =
        [
            new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
        ];
        string expectedSystem =
            "You are a research subagent that gathers and summarises sources for the coordinating agent.";
        List<BetaManagedAgentsSessionThreadAgentTool> expectedTools =
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
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");
        int expectedVersion = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExecutionIdentity, model.ExecutionIdentity);
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
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadAgent
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
            Skills = [new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" }],
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
            Skills = [new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" }],
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "agent_011CZkYqphY8vELVzwCUpqiQ";
        string expectedDescription = "A focused research subagent.";
        BetaManagedAgentsExecutionIdentity expectedExecutionIdentity =
            new BetaManagedAgentsServiceAccountExecutionIdentity();
        List<BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };
        string expectedName = "Researcher";
        List<BetaManagedAgentsSessionThreadAgentSkill> expectedSkills =
        [
            new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
        ];
        string expectedSystem =
            "You are a research subagent that gathers and summarises sources for the coordinating agent.";
        List<BetaManagedAgentsSessionThreadAgentTool> expectedTools =
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
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");
        int expectedVersion = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExecutionIdentity, deserialized.ExecutionIdentity);
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
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadAgent
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
            Skills = [new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" }],
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadAgent
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
            Skills = [new BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" }],
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
            Version = "1",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        BetaManagedAgentsSessionThreadAgentSkill value = new BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
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
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgentSkill>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAnthropicTypeWorks()
    {
        BetaManagedAgentsSessionThreadAgentSkill value = new BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Version = "1",
        };
        Assert.Equal(BetaManagedAgentsSessionThreadAgentSkillType.Anthropic, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomTypeWorks()
    {
        BetaManagedAgentsSessionThreadAgentSkill value = new BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };
        Assert.Equal(BetaManagedAgentsSessionThreadAgentSkillType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSessionThreadAgentSkill value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "skill_id": "xlsx",
                  "type": "anthropic",
                  "version": "1"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedSkillID = "xlsx";
        ApiEnum<string, BetaManagedAgentsSessionThreadAgentSkillType> expectedType =
            BetaManagedAgentsSessionThreadAgentSkillType.Anthropic;
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, value.SkillID);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedVersion, value.Version);

        BetaManagedAgentsSessionThreadAgentSkill emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.SkillID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Version);

        BetaManagedAgentsSessionThreadAgentSkill mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "skill_id": [
                    "invalid"
                  ],
                  "version": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.SkillID);
        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Version);
    }
}

public class BetaManagedAgentsSessionThreadAgentSkillTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadAgentSkillType.Anthropic)]
    [InlineData(BetaManagedAgentsSessionThreadAgentSkillType.Custom)]
    public void Validation_Works(BetaManagedAgentsSessionThreadAgentSkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadAgentSkillType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentSkillType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadAgentSkillType.Anthropic)]
    [InlineData(BetaManagedAgentsSessionThreadAgentSkillType.Custom)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionThreadAgentSkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadAgentSkillType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentSkillType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentSkillType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentSkillType>
        >(json, ModelBase.SerializerOptions);

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
                new BetaManagedAgentsBashToolConfig()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
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
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
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
            },
            Name = "name",
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
                new BetaManagedAgentsBashToolConfig()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
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
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
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
            },
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadAgentTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401TypeWorks()
    {
        BetaManagedAgentsSessionThreadAgentTool value = new BetaManagedAgentsAgentToolset20260401()
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
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
        };
        Assert.Equal(
            BetaManagedAgentsSessionThreadAgentToolType.AgentToolset20260401,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetTypeWorks()
    {
        BetaManagedAgentsSessionThreadAgentTool value = new BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };
        Assert.Equal(BetaManagedAgentsSessionThreadAgentToolType.McpToolset, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomTypeWorks()
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
            },
            Name = "name",
        };
        Assert.Equal(BetaManagedAgentsSessionThreadAgentToolType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSessionThreadAgentTool value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "agent_toolset_20260401"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsSessionThreadAgentToolType> expectedType =
            BetaManagedAgentsSessionThreadAgentToolType.AgentToolset20260401;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsSessionThreadAgentTool emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsSessionThreadAgentToolTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadAgentToolType.AgentToolset20260401)]
    [InlineData(BetaManagedAgentsSessionThreadAgentToolType.McpToolset)]
    [InlineData(BetaManagedAgentsSessionThreadAgentToolType.Custom)]
    public void Validation_Works(BetaManagedAgentsSessionThreadAgentToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadAgentToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadAgentToolType.AgentToolset20260401)]
    [InlineData(BetaManagedAgentsSessionThreadAgentToolType.McpToolset)]
    [InlineData(BetaManagedAgentsSessionThreadAgentToolType.Custom)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionThreadAgentToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadAgentToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadAgentToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
