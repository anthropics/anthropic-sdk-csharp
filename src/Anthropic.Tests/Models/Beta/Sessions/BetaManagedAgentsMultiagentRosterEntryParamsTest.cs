using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsMultiagentRosterEntryParamsTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value = "string";
        value.Validate();
    }

    [Fact]
    public void AgentValidationWorks()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value = new BetaManagedAgentsAgentParams()
        {
            ID = "x",
            Type = Type.Agent,
            Version = 0,
        };
        value.Validate();
    }

    [Fact]
    public void SelfValidationWorks()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value =
            new Agents::BetaManagedAgentsMultiagentSelfParams(
                Agents::BetaManagedAgentsMultiagentSelfParamsType.Self
            );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentRosterEntryParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value = new BetaManagedAgentsAgentParams()
        {
            ID = "x",
            Type = Type.Agent,
            Version = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentRosterEntryParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SelfSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value =
            new Agents::BetaManagedAgentsMultiagentSelfParams(
                Agents::BetaManagedAgentsMultiagentSelfParamsType.Self
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentRosterEntryParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
