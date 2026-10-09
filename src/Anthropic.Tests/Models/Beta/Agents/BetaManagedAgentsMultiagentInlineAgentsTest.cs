using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentInlineAgentsTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaManagedAgentsMultiagentInlineAgents value =
            new BetaManagedAgentsMultiagentInlineAgentsEnabled();
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaManagedAgentsMultiagentInlineAgents value =
            new BetaManagedAgentsMultiagentInlineAgentsDisabled();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentInlineAgents value =
            new BetaManagedAgentsMultiagentInlineAgentsEnabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentInlineAgents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentInlineAgents value =
            new BetaManagedAgentsMultiagentInlineAgentsDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentInlineAgents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagentInlineAgents value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaManagedAgentsMultiagentInlineAgents emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
