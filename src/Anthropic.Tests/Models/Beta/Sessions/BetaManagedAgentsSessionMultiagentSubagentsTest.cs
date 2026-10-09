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
                            ID = BetaManagedAgentsModel.ClaudeOpus5,
                            Effort = new BetaManagedAgentsEffortLow(
                                BetaManagedAgentsEffortLowType.Low
                            ),
                            InferenceGeo = "inference_geo",
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
                                    new BetaManagedAgentsBashToolConfig()
                                    {
                                        Enabled = true,
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
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
                            ID = BetaManagedAgentsModel.ClaudeOpus5,
                            Effort = new BetaManagedAgentsEffortLow(
                                BetaManagedAgentsEffortLowType.Low
                            ),
                            InferenceGeo = "inference_geo",
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
                                    new BetaManagedAgentsBashToolConfig()
                                    {
                                        Enabled = true,
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
                                Type =
                                    BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
                            },
                        ],
                        Type = BetaManagedAgentsSessionThreadAgentType.Agent,
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

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaManagedAgentsSessionMultiagentSubagents emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
