using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagent20261001ParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001Params
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabledParams(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentParamsType.Agent,
                        Version = 1,
                    },
                ],
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("multiagent_20261001");
        BetaManagedAgentsMultiagentAdvisorParams expectedAdvisor =
            new BetaManagedAgentsMultiagentAdvisorDisabledParams();
        BetaManagedAgentsMultiagentSubagentsParams expectedSubagents =
            new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            };
        BetaManagedAgentsMultiagentWorkflowsParams expectedWorkflows =
            new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentParamsType.Agent,
                        Version = 1,
                    },
                ],
            };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAdvisor, model.Advisor);
        Assert.Equal(expectedSubagents, model.Subagents);
        Assert.Equal(expectedWorkflows, model.Workflows);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001Params
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabledParams(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentParamsType.Agent,
                        Version = 1,
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagent20261001Params>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001Params
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabledParams(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentParamsType.Agent,
                        Version = 1,
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagent20261001Params>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("multiagent_20261001");
        BetaManagedAgentsMultiagentAdvisorParams expectedAdvisor =
            new BetaManagedAgentsMultiagentAdvisorDisabledParams();
        BetaManagedAgentsMultiagentSubagentsParams expectedSubagents =
            new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            };
        BetaManagedAgentsMultiagentWorkflowsParams expectedWorkflows =
            new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentParamsType.Agent,
                        Version = 1,
                    },
                ],
            };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedAdvisor, deserialized.Advisor);
        Assert.Equal(expectedSubagents, deserialized.Subagents);
        Assert.Equal(expectedWorkflows, deserialized.Workflows);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001Params
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabledParams(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentParamsType.Agent,
                        Version = 1,
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001Params { };

        Assert.Null(model.Advisor);
        Assert.False(model.RawData.ContainsKey("advisor"));
        Assert.Null(model.Subagents);
        Assert.False(model.RawData.ContainsKey("subagents"));
        Assert.Null(model.Workflows);
        Assert.False(model.RawData.ContainsKey("workflows"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001Params { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001Params
        {
            Advisor = null,
            Subagents = null,
            Workflows = null,
        };

        Assert.Null(model.Advisor);
        Assert.True(model.RawData.ContainsKey("advisor"));
        Assert.Null(model.Subagents);
        Assert.True(model.RawData.ContainsKey("subagents"));
        Assert.Null(model.Workflows);
        Assert.True(model.RawData.ContainsKey("workflows"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001Params
        {
            Advisor = null,
            Subagents = null,
            Workflows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001Params
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabledParams(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentParamsType.Agent,
                        Version = 1,
                    },
                ],
            },
        };

        BetaManagedAgentsMultiagent20261001Params copied = new(model);

        Assert.Equal(model, copied);
    }
}
