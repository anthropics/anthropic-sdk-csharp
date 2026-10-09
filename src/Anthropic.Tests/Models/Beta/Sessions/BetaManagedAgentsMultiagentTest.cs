using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsMultiagentTest : TestBase
{
    [Fact]
    public void CoordinatorValidationWorks()
    {
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagentCoordinator()
        {
            Agents =
            [
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorType.Coordinator,
        };
        value.Validate();
    }

    [Fact]
    public void Multiagent20261001ValidationWorks()
    {
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagent20261001()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                ],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
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
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagentCoordinator()
        {
            Agents =
            [
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorType.Coordinator,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Multiagent20261001SerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagent20261001()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                ],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents =
                [
                    new()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Type = BetaManagedAgentsAgentReferenceType.Agent,
                        Version = 1,
                    },
                ],
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
