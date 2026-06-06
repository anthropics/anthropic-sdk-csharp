using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
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
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
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
        };

        List<BetaManagedAgentsUrlMcpServerParams> expectedMcpServers =
        [
            new()
            {
                Name = "example-mcp",
                Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        List<BetaManagedAgentsSessionAgentUpdateTool> expectedTools =
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
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
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
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
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
                Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                Url = "https://example-server.modelcontextprotocol.io/sse",
            },
        ];
        List<BetaManagedAgentsSessionAgentUpdateTool> expectedTools =
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
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
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
                    Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                    Url = "https://example-server.modelcontextprotocol.io/sse",
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
        BetaManagedAgentsSessionAgentUpdateTool value = new BetaManagedAgentsMcpToolsetParams()
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
            Type = BetaManagedAgentsCustomToolParamsType.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentToolset20260401ParamsSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionAgentUpdateTool value =
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
            Type = BetaManagedAgentsCustomToolParamsType.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionAgentUpdateTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
