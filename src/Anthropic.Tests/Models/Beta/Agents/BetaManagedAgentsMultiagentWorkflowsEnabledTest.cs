using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentWorkflowsEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
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

        BetaManagedAgentsMultiagentInlineAgents expectedInlineAgents =
            new BetaManagedAgentsMultiagentInlineAgentsDisabled();
        List<BetaManagedAgentsAgentReference> expectedPredefinedAgents =
        [
            new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedInlineAgents, model.InlineAgents);
        Assert.Equal(expectedPredefinedAgents.Count, model.PredefinedAgents.Count);
        for (int i = 0; i < expectedPredefinedAgents.Count; i++)
        {
            Assert.Equal(expectedPredefinedAgents[i], model.PredefinedAgents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflowsEnabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflowsEnabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsMultiagentInlineAgents expectedInlineAgents =
            new BetaManagedAgentsMultiagentInlineAgentsDisabled();
        List<BetaManagedAgentsAgentReference> expectedPredefinedAgents =
        [
            new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedInlineAgents, deserialized.InlineAgents);
        Assert.Equal(expectedPredefinedAgents.Count, deserialized.PredefinedAgents.Count);
        for (int i = 0; i < expectedPredefinedAgents.Count; i++)
        {
            Assert.Equal(expectedPredefinedAgents[i], deserialized.PredefinedAgents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabled
        {
            InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
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

        BetaManagedAgentsMultiagentWorkflowsEnabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
