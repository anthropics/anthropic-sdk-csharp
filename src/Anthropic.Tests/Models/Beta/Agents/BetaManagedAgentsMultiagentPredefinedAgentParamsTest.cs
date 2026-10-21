using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentPredefinedAgentParamsTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaManagedAgentsMultiagentPredefinedAgentParams value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentParamsValidationWorks()
    {
        BetaManagedAgentsMultiagentPredefinedAgentParams value = new BetaManagedAgentsAgentParams()
        {
            ID = "x",
            Type = BetaManagedAgentsAgentParamsType.Agent,
            Version = 0,
        };
        value.Validate();
    }

    [Fact]
    public void SelfValidationWorks()
    {
        BetaManagedAgentsMultiagentPredefinedAgentParams value =
            new BetaManagedAgentsMultiagentSelfParams(
                BetaManagedAgentsMultiagentSelfParamsType.Self
            );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentPredefinedAgentParams value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentPredefinedAgentParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentParamsSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentPredefinedAgentParams value = new BetaManagedAgentsAgentParams()
        {
            ID = "x",
            Type = BetaManagedAgentsAgentParamsType.Agent,
            Version = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentPredefinedAgentParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SelfSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentPredefinedAgentParams value =
            new BetaManagedAgentsMultiagentSelfParams(
                BetaManagedAgentsMultiagentSelfParamsType.Self
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentPredefinedAgentParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
