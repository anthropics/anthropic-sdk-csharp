using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

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
            Version = 0,
        };
        value.Validate();
    }

    [Fact]
    public void SelfValidationWorks()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value =
            new BetaManagedAgentsMultiagentSelfParams();
        value.Validate();
    }

    [Fact]
    public void AdvisorValidationWorks()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value = new BetaManagedAgentsAdvisorParams(
            "claude-opus-5-5"
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
            new BetaManagedAgentsMultiagentSelfParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentRosterEntryParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdvisorSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value = new BetaManagedAgentsAdvisorParams(
            "claude-opus-5-5"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentRosterEntryParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagentRosterEntryParams value = new(
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

        BetaManagedAgentsMultiagentRosterEntryParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.Type);
    }
}
