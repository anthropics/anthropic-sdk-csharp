using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Threads;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads;

public class BetaManagedAgentsInlineAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
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

        Agents::BetaManagedAgentsExecutionIdentity expectedExecutionIdentity =
            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity();
        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new Agents::BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Agents::Speed.Standard,
        };
        string expectedName = "pdf-reader-3";
        List<Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
        ];
        string expectedSystem = "You extract tables precisely. Output CSV only.";
        List<Tool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new Agents::BetaManagedAgentsBashToolConfig()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("inline");

        Assert.Null(model.Description);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsInlineAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsInlineAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Agents::BetaManagedAgentsExecutionIdentity expectedExecutionIdentity =
            new Agents::BetaManagedAgentsServiceAccountExecutionIdentity();
        List<Agents::BetaManagedAgentsMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        Agents::BetaManagedAgentsModelConfig expectedModel = new()
        {
            ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new Agents::BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Agents::Speed.Standard,
        };
        string expectedName = "pdf-reader-3";
        List<Skill> expectedSkills =
        [
            new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
        ];
        string expectedSystem = "You extract tables precisely. Output CSV only.";
        List<Tool> expectedTools =
        [
            new Agents::BetaManagedAgentsAgentToolset20260401()
            {
                Configs =
                [
                    new Agents::BetaManagedAgentsBashToolConfig()
                    {
                        Enabled = true,
                        PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("inline");

        Assert.Null(deserialized.Description);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsInlineAgent
        {
            Description = null,
            ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
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
                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                Effort = new Agents::BetaManagedAgentsEffortLow(),
                InferenceGeo = "inference_geo",
                Speed = Agents::Speed.Standard,
            },
            Name = "pdf-reader-3",
            Skills =
            [
                new Agents::BetaManagedAgentsAnthropicSkill() { SkillID = "xlsx", Version = "1" },
            ],
            System = "You extract tables precisely. Output CSV only.",
            Tools =
            [
                new Agents::BetaManagedAgentsAgentToolset20260401()
                {
                    Configs =
                    [
                        new Agents::BetaManagedAgentsBashToolConfig()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
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

        BetaManagedAgentsInlineAgent copied = new(model);

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
            Version = "1",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCustomValidationWorks()
    {
        Skill value = new Agents::BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
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
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skill>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAnthropicTypeWorks()
    {
        Skill value = new Agents::BetaManagedAgentsAnthropicSkill()
        {
            SkillID = "xlsx",
            Version = "1",
        };
        Assert.Equal(SkillType.Anthropic, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomTypeWorks()
    {
        Skill value = new Agents::BetaManagedAgentsCustomSkill()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };
        Assert.Equal(SkillType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Skill value = new(
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
        ApiEnum<string, SkillType> expectedType = SkillType.Anthropic;
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, value.SkillID);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedVersion, value.Version);

        Skill emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.SkillID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Version);

        Skill mismatchedValue = new(
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

public class SkillTypeTest : TestBase
{
    [Theory]
    [InlineData(SkillType.Anthropic)]
    [InlineData(SkillType.Custom)]
    public void Validation_Works(SkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SkillType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SkillType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SkillType.Anthropic)]
    [InlineData(SkillType.Custom)]
    public void SerializationRoundtrip_Works(SkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SkillType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SkillType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SkillType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SkillType>>(
            json,
            ModelBase.SerializerOptions
        );

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
                new Agents::BetaManagedAgentsBashToolConfig()
                {
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
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
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
            },
            Name = "name",
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
                new Agents::BetaManagedAgentsBashToolConfig()
                {
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
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
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
            },
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401TypeWorks()
    {
        Tool value = new Agents::BetaManagedAgentsAgentToolset20260401()
        {
            Configs =
            [
                new Agents::BetaManagedAgentsBashToolConfig()
                {
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
        Assert.Equal(ToolType.AgentToolset20260401, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetTypeWorks()
    {
        Tool value = new Agents::BetaManagedAgentsMcpToolset()
        {
            Configs =
            [
                new()
                {
                    Enabled = true,
                    Name = "name",
                    PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                },
            ],
            DefaultConfig = new()
            {
                Enabled = true,
                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
            },
            McpServerName = "mcp_server_name",
        };
        Assert.Equal(ToolType.McpToolset, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomTypeWorks()
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
            },
            Name = "name",
        };
        Assert.Equal(ToolType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Tool value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "agent_toolset_20260401"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ToolType> expectedType = ToolType.AgentToolset20260401;

        Assert.Equal(expectedType, value.Type);

        Tool emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ToolTypeTest : TestBase
{
    [Theory]
    [InlineData(ToolType.AgentToolset20260401)]
    [InlineData(ToolType.McpToolset)]
    [InlineData(ToolType.Custom)]
    public void Validation_Works(ToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolType.AgentToolset20260401)]
    [InlineData(ToolType.McpToolset)]
    [InlineData(ToolType.Custom)]
    public void SerializationRoundtrip_Works(ToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
