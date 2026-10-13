using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentWorkflowsEnabledParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabledParams
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

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        BetaManagedAgentsMultiagentInlineAgentsParams expectedInlineAgents =
            new BetaManagedAgentsMultiagentInlineAgentsDisabledParams();
        List<BetaManagedAgentsMultiagentPredefinedAgentParams> expectedPredefinedAgents =
        [
            new BetaManagedAgentsAgentParams()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentParamsType.Agent,
                Version = 1,
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedInlineAgents, model.InlineAgents);
        Assert.NotNull(model.PredefinedAgents);
        Assert.Equal(expectedPredefinedAgents.Count, model.PredefinedAgents.Count);
        for (int i = 0; i < expectedPredefinedAgents.Count; i++)
        {
            Assert.Equal(expectedPredefinedAgents[i], model.PredefinedAgents[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabledParams
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflowsEnabledParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabledParams
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflowsEnabledParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        BetaManagedAgentsMultiagentInlineAgentsParams expectedInlineAgents =
            new BetaManagedAgentsMultiagentInlineAgentsDisabledParams();
        List<BetaManagedAgentsMultiagentPredefinedAgentParams> expectedPredefinedAgents =
        [
            new BetaManagedAgentsAgentParams()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentParamsType.Agent,
                Version = 1,
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedInlineAgents, deserialized.InlineAgents);
        Assert.NotNull(deserialized.PredefinedAgents);
        Assert.Equal(expectedPredefinedAgents.Count, deserialized.PredefinedAgents.Count);
        for (int i = 0; i < expectedPredefinedAgents.Count; i++)
        {
            Assert.Equal(expectedPredefinedAgents[i], deserialized.PredefinedAgents[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabledParams
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabledParams { };

        Assert.Null(model.InlineAgents);
        Assert.False(model.RawData.ContainsKey("inline_agents"));
        Assert.Null(model.PredefinedAgents);
        Assert.False(model.RawData.ContainsKey("predefined_agents"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabledParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabledParams
        {
            InlineAgents = null,
            PredefinedAgents = null,
        };

        Assert.Null(model.InlineAgents);
        Assert.True(model.RawData.ContainsKey("inline_agents"));
        Assert.Null(model.PredefinedAgents);
        Assert.True(model.RawData.ContainsKey("predefined_agents"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabledParams
        {
            InlineAgents = null,
            PredefinedAgents = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsEnabledParams
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

        BetaManagedAgentsMultiagentWorkflowsEnabledParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
