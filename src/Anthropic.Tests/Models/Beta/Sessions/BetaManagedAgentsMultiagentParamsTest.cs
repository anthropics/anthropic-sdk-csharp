using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsMultiagentParamsTest : TestBase
{
    [Fact]
    public void CoordinatorValidationWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagentCoordinatorParams(
            ["agent_011CZkYqphY8vELVzwCUpqiQ", new BetaManagedAgentsMultiagentSelfParams()]
        );
        value.Validate();
    }

    [Fact]
    public void Multiagent20261001ValidationWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagent20261001Params()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabledParams(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Version = 1,
                    },
                ],
            },
        };
        value.Validate();
    }

    [Fact]
    public void CoordinatorSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagentCoordinatorParams(
            ["agent_011CZkYqphY8vELVzwCUpqiQ", new BetaManagedAgentsMultiagentSelfParams()]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Multiagent20261001SerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagent20261001Params()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabledParams(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Version = 1,
                    },
                ],
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CoordinatorTypeWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagentCoordinatorParams(
            ["agent_011CZkYqphY8vELVzwCUpqiQ", new BetaManagedAgentsMultiagentSelfParams()]
        );
        Assert.Equal(BetaManagedAgentsMultiagentParamsType.Coordinator, value.Type.Value());
    }

    [Fact]
    public void Multiagent20261001TypeWorks()
    {
        BetaManagedAgentsMultiagentParams value = new BetaManagedAgentsMultiagent20261001Params()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabledParams(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents = ["agent_011CZkYqphY8vELVzwCUpqiQ"],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    new BetaManagedAgentsAgentParams()
                    {
                        ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                        Version = 1,
                    },
                ],
            },
        };
        Assert.Equal(BetaManagedAgentsMultiagentParamsType.Multiagent20261001, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagentParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "coordinator"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsMultiagentParamsType> expectedType =
            BetaManagedAgentsMultiagentParamsType.Coordinator;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMultiagentParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMultiagentParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentParamsType.Coordinator)]
    [InlineData(BetaManagedAgentsMultiagentParamsType.Multiagent20261001)]
    public void Validation_Works(BetaManagedAgentsMultiagentParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentParamsType.Coordinator)]
    [InlineData(BetaManagedAgentsMultiagentParamsType.Multiagent20261001)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMultiagentParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
