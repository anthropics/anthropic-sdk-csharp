using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentSubagentsParamsTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaManagedAgentsMultiagentSubagentsParams value =
            new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    "agent_011CZkYqphY8vELVzwCUpqiQ",
                    new BetaManagedAgentsMultiagentSelfParams(
                        BetaManagedAgentsMultiagentSelfParamsType.Self
                    ),
                ],
            };
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaManagedAgentsMultiagentSubagentsParams value =
            new BetaManagedAgentsMultiagentSubagentsDisabledParams();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentSubagentsParams value =
            new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    "agent_011CZkYqphY8vELVzwCUpqiQ",
                    new BetaManagedAgentsMultiagentSelfParams(
                        BetaManagedAgentsMultiagentSelfParamsType.Self
                    ),
                ],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSubagentsParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentSubagentsParams value =
            new BetaManagedAgentsMultiagentSubagentsDisabledParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSubagentsParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagentSubagentsParams value = new(
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

        BetaManagedAgentsMultiagentSubagentsParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
