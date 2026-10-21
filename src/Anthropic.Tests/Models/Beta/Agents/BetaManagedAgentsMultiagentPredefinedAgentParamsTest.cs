using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            Version = 0,
        };
        value.Validate();
    }

    [Fact]
    public void SelfValidationWorks()
    {
        BetaManagedAgentsMultiagentPredefinedAgentParams value =
            new BetaManagedAgentsMultiagentSelfParams();
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
            new BetaManagedAgentsMultiagentSelfParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentPredefinedAgentParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagentPredefinedAgentParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "agent"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");

        Assert.NotNull(value.Type);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type.Value));

        BetaManagedAgentsMultiagentPredefinedAgentParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.Type);
    }
}
