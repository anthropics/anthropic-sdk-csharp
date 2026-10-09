using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagent20261001Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001
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

        BetaManagedAgentsMultiagentAdvisor expectedAdvisor =
            new BetaManagedAgentsMultiagentAdvisorDisabled();
        BetaManagedAgentsMultiagentSubagents expectedSubagents =
            new BetaManagedAgentsMultiagentSubagentsEnabled()
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
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("multiagent_20261001");
        BetaManagedAgentsMultiagentWorkflows expectedWorkflows =
            new BetaManagedAgentsMultiagentWorkflowsEnabled()
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
            };

        Assert.Equal(expectedAdvisor, model.Advisor);
        Assert.Equal(expectedSubagents, model.Subagents);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkflows, model.Workflows);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagent20261001>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagent20261001>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsMultiagentAdvisor expectedAdvisor =
            new BetaManagedAgentsMultiagentAdvisorDisabled();
        BetaManagedAgentsMultiagentSubagents expectedSubagents =
            new BetaManagedAgentsMultiagentSubagentsEnabled()
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
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("multiagent_20261001");
        BetaManagedAgentsMultiagentWorkflows expectedWorkflows =
            new BetaManagedAgentsMultiagentWorkflowsEnabled()
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
            };

        Assert.Equal(expectedAdvisor, deserialized.Advisor);
        Assert.Equal(expectedSubagents, deserialized.Subagents);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkflows, deserialized.Workflows);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagent20261001
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

        BetaManagedAgentsMultiagent20261001 copied = new(model);

        Assert.Equal(model, copied);
    }
}
