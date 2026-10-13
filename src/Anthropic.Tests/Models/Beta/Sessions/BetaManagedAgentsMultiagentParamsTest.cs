using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsMultiagentParamsTest : TestBase
{
    [Fact]
    public void CoordinatorValidationWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagentCoordinatorParams()
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator,
        };
        value.Validate();
    }

    [Fact]
    public void Multiagent20261001ValidationWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagent20261001Params()
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
        value.Validate();
    }

    [Fact]
    public void CoordinatorSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagentCoordinatorParams()
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Multiagent20261001SerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagent20261001Params()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
