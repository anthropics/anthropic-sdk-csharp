using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionMultiagentSubagentsTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaManagedAgentsSessionMultiagentSubagents value =
            new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
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
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
        value.Validate();
    }

    [Fact]
    public void MultiagentSubagentsDisabledValidationWorks()
    {
        BetaManagedAgentsSessionMultiagentSubagents value =
            new BetaManagedAgentsMultiagentSubagentsDisabled();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionMultiagentSubagents value =
            new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
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
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentSubagents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MultiagentSubagentsDisabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionMultiagentSubagents value =
            new BetaManagedAgentsMultiagentSubagentsDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentSubagents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaManagedAgentsSessionMultiagentSubagents value =
            new BetaManagedAgentsSessionMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
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
                            new BetaManagedAgentsAnthropicSkill()
                            {
                                SkillID = "xlsx",
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
        Assert.Equal(BetaManagedAgentsSessionMultiagentSubagentsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void MultiagentSubagentsDisabledTypeWorks()
    {
        BetaManagedAgentsSessionMultiagentSubagents value =
            new BetaManagedAgentsMultiagentSubagentsDisabled();
        Assert.Equal(BetaManagedAgentsSessionMultiagentSubagentsType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSessionMultiagentSubagents value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsSessionMultiagentSubagentsType> expectedType =
            BetaManagedAgentsSessionMultiagentSubagentsType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsSessionMultiagentSubagents emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsSessionMultiagentSubagentsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionMultiagentSubagentsType.Enabled)]
    [InlineData(BetaManagedAgentsSessionMultiagentSubagentsType.Disabled)]
    public void Validation_Works(BetaManagedAgentsSessionMultiagentSubagentsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionMultiagentSubagentsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentSubagentsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionMultiagentSubagentsType.Enabled)]
    [InlineData(BetaManagedAgentsSessionMultiagentSubagentsType.Disabled)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionMultiagentSubagentsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionMultiagentSubagentsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentSubagentsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentSubagentsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionMultiagentSubagentsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
