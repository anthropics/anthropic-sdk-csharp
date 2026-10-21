using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentWorkflowsParamsTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaManagedAgentsMultiagentWorkflowsParams value =
            new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
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
            };
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaManagedAgentsMultiagentWorkflowsParams value =
            new BetaManagedAgentsMultiagentWorkflowsDisabledParams();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentWorkflowsParams value =
            new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflowsParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentWorkflowsParams value =
            new BetaManagedAgentsMultiagentWorkflowsDisabledParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflowsParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaManagedAgentsMultiagentWorkflowsParams value =
            new BetaManagedAgentsMultiagentWorkflowsEnabledParams()
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
            };
        Assert.Equal(BetaManagedAgentsMultiagentWorkflowsParamsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaManagedAgentsMultiagentWorkflowsParams value =
            new BetaManagedAgentsMultiagentWorkflowsDisabledParams();
        Assert.Equal(BetaManagedAgentsMultiagentWorkflowsParamsType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagentWorkflowsParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsParamsType> expectedType =
            BetaManagedAgentsMultiagentWorkflowsParamsType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMultiagentWorkflowsParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMultiagentWorkflowsParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentWorkflowsParamsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentWorkflowsParamsType.Disabled)]
    public void Validation_Works(BetaManagedAgentsMultiagentWorkflowsParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentWorkflowsParamsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentWorkflowsParamsType.Disabled)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMultiagentWorkflowsParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
