using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentToolEvaluationTest : TestBase
{
    [Fact]
    public void AlwaysAllowValidationWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAllow();
        value.Validate();
    }

    [Fact]
    public void AlwaysAskValidationWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAsk();
        value.Validate();
    }

    [Fact]
    public void AutoValidationWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value = new BetaManagedAgentsAgentToolEvaluationAuto(
            new BetaManagedAgentsAgentAutoEvaluatedPermission(
                new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow()
            )
        );
        value.Validate();
    }

    [Fact]
    public void AlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAllow();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAsk();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value = new BetaManagedAgentsAgentToolEvaluationAuto(
            new BetaManagedAgentsAgentAutoEvaluatedPermission(
                new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow()
            )
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentToolEvaluation value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "always_allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("always_allow");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaManagedAgentsAgentToolEvaluation emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
