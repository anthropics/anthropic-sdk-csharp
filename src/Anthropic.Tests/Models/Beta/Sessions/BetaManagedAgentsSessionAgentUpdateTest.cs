using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionAgentUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate
        {
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Tools =
            [
                new BetaManagedAgentsAgentToolset20260401Params()
                {
                    Configs =
                    [
                        new BetaManagedAgentsBashToolConfigParams()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            Type = Type.Bash,
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
        };

        List<BetaManagedAgentsUrlMcpServerParams> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        List<BetaManagedAgentsSessionAgentUpdateTool> expectedTools =
        [
            new BetaManagedAgentsAgentToolset20260401Params()
            {
                Configs =
                [
                    new BetaManagedAgentsBashToolConfigParams()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                        Type = Type.Bash,
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            },
        ];

        Assert.NotNull(model.McpServers);
        Assert.Equal(expectedMcpServers.Count, model.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], model.McpServers[i]);
        }
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate
        {
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Tools =
            [
                new BetaManagedAgentsAgentToolset20260401Params()
                {
                    Configs =
                    [
                        new BetaManagedAgentsBashToolConfigParams()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            Type = Type.Bash,
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgentUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate
        {
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Tools =
            [
                new BetaManagedAgentsAgentToolset20260401Params()
                {
                    Configs =
                    [
                        new BetaManagedAgentsBashToolConfigParams()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            Type = Type.Bash,
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgentUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsUrlMcpServerParams> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        List<BetaManagedAgentsSessionAgentUpdateTool> expectedTools =
        [
            new BetaManagedAgentsAgentToolset20260401Params()
            {
                Configs =
                [
                    new BetaManagedAgentsBashToolConfigParams()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                        Type = Type.Bash,
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            },
        ];

        Assert.NotNull(deserialized.McpServers);
        Assert.Equal(expectedMcpServers.Count, deserialized.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], deserialized.McpServers[i]);
        }
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate
        {
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Tools =
            [
                new BetaManagedAgentsAgentToolset20260401Params()
                {
                    Configs =
                    [
                        new BetaManagedAgentsBashToolConfigParams()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            Type = Type.Bash,
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate { };

        Assert.Null(model.McpServers);
        Assert.False(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate
        {
            // Null should be interpreted as omitted for these properties
            McpServers = null,
            Tools = null,
        };

        Assert.Null(model.McpServers);
        Assert.False(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate
        {
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Tools =
            [
                new BetaManagedAgentsAgentToolset20260401Params()
                {
                    Configs =
                    [
                        new BetaManagedAgentsBashToolConfigParams()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            Type = Type.Bash,
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
        } with
        {
            // Null should be interpreted as omitted for these properties
            McpServers = null,
            Tools = null,
        };

        Assert.Null(model.McpServers);
        Assert.False(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate
        {
            // Null should be interpreted as omitted for these properties
            McpServers = null,
            Tools = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionAgentUpdate
        {
            McpServers =
            [
                new()
                {
                    Name = "example-mcp",
                    Url = "https://example-server.modelcontextprotocol.io/sse",
                },
            ],
            Tools =
            [
                new BetaManagedAgentsAgentToolset20260401Params()
                {
                    Configs =
                    [
                        new BetaManagedAgentsBashToolConfigParams()
                        {
                            Enabled = true,
                            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                            Type = Type.Bash,
                        },
                    ],
                    DefaultConfig = new()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                    },
                },
            ],
        };

        BetaManagedAgentsSessionAgentUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionAgentUpdateToolTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsValidationWorks()
    {
        BetaManagedAgentsSessionAgentUpdateTool value =
            new BetaManagedAgentsAgentToolset20260401Params()
            {
                Configs =
                [
                    new BetaManagedAgentsBashToolConfigParams()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                        Type = Type.Bash,
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
    public void BetaManagedAgentsMcpToolsetParamsValidationWorks()
    {
        BetaManagedAgentsSessionAgentUpdateTool value = new BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
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
    public void BetaManagedAgentsCustomToolParamsValidationWorks()
    {
        BetaManagedAgentsSessionAgentUpdateTool value = new BetaManagedAgentsCustomToolParams()
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
        BetaManagedAgentsSessionAgentUpdateTool value =
            new BetaManagedAgentsAgentToolset20260401Params()
            {
                Configs =
                [
                    new BetaManagedAgentsBashToolConfigParams()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                        Type = Type.Bash,
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgentUpdateTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionAgentUpdateTool value = new BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgentUpdateTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionAgentUpdateTool value = new BetaManagedAgentsCustomToolParams()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgentUpdateTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsTypeWorks()
    {
        BetaManagedAgentsSessionAgentUpdateTool value =
            new BetaManagedAgentsAgentToolset20260401Params()
            {
                Configs =
                [
                    new BetaManagedAgentsBashToolConfigParams()
                    {
                        Enabled = true,
                        PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                        Type = Type.Bash,
                    },
                ],
                DefaultConfig = new()
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
                },
            };
        Assert.Equal(
            BetaManagedAgentsSessionAgentUpdateToolType.AgentToolset20260401,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsMcpToolsetParamsTypeWorks()
    {
        BetaManagedAgentsSessionAgentUpdateTool value = new BetaManagedAgentsMcpToolsetParams()
        {
            McpServerName = "x",
            Configs =
            [
                new()
                {
                    Name = "x",
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
        Assert.Equal(BetaManagedAgentsSessionAgentUpdateToolType.McpToolset, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCustomToolParamsTypeWorks()
    {
        BetaManagedAgentsSessionAgentUpdateTool value = new BetaManagedAgentsCustomToolParams()
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
        Assert.Equal(BetaManagedAgentsSessionAgentUpdateToolType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSessionAgentUpdateTool value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "agent_toolset_20260401"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsSessionAgentUpdateToolType> expectedType =
            BetaManagedAgentsSessionAgentUpdateToolType.AgentToolset20260401;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsSessionAgentUpdateTool emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsSessionAgentUpdateToolTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionAgentUpdateToolType.AgentToolset20260401)]
    [InlineData(BetaManagedAgentsSessionAgentUpdateToolType.McpToolset)]
    [InlineData(BetaManagedAgentsSessionAgentUpdateToolType.Custom)]
    public void Validation_Works(BetaManagedAgentsSessionAgentUpdateToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionAgentUpdateToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentUpdateToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionAgentUpdateToolType.AgentToolset20260401)]
    [InlineData(BetaManagedAgentsSessionAgentUpdateToolType.McpToolset)]
    [InlineData(BetaManagedAgentsSessionAgentUpdateToolType.Custom)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionAgentUpdateToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionAgentUpdateToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentUpdateToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentUpdateToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionAgentUpdateToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
