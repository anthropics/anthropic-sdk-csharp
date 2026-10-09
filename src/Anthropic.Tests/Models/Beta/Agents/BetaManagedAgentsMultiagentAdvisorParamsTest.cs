using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentAdvisorParamsTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaManagedAgentsMultiagentAdvisorParams value =
            new BetaManagedAgentsMultiagentAdvisorEnabledParams("claude-fable-5");
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaManagedAgentsMultiagentAdvisorParams value =
            new BetaManagedAgentsMultiagentAdvisorDisabledParams();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentAdvisorParams value =
            new BetaManagedAgentsMultiagentAdvisorEnabledParams("claude-fable-5");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentAdvisorParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentAdvisorParams value =
            new BetaManagedAgentsMultiagentAdvisorDisabledParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentAdvisorParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagentAdvisorParams value = new(
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

        BetaManagedAgentsMultiagentAdvisorParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
