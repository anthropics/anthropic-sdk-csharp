using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentCoordinatorParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(),
            ],
        };

        List<BetaManagedAgentsMultiagentRosterEntryParams> expectedAgents =
        [
            "agent_011CZkYqphY8vELVzwCUpqiQ",
            new BetaManagedAgentsMultiagentSelfParams(),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("coordinator");

        Assert.Equal(expectedAgents.Count, model.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], model.Agents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentCoordinatorParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentCoordinatorParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsMultiagentRosterEntryParams> expectedAgents =
        [
            "agent_011CZkYqphY8vELVzwCUpqiQ",
            new BetaManagedAgentsMultiagentSelfParams(),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("coordinator");

        Assert.Equal(expectedAgents.Count, deserialized.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], deserialized.Agents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(),
            ],
        };

        BetaManagedAgentsMultiagentCoordinatorParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
