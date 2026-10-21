using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentWorkflowsTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaManagedAgentsMultiagentWorkflows value =
            new BetaManagedAgentsMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            };
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaManagedAgentsMultiagentWorkflows value =
            new BetaManagedAgentsMultiagentWorkflowsDisabled();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentWorkflows value =
            new BetaManagedAgentsMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflows>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentWorkflows value =
            new BetaManagedAgentsMultiagentWorkflowsDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflows>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaManagedAgentsMultiagentWorkflows value =
            new BetaManagedAgentsMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            };
        Assert.Equal(BetaManagedAgentsMultiagentWorkflowsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaManagedAgentsMultiagentWorkflows value =
            new BetaManagedAgentsMultiagentWorkflowsDisabled();
        Assert.Equal(BetaManagedAgentsMultiagentWorkflowsType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagentWorkflows value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsType> expectedType =
            BetaManagedAgentsMultiagentWorkflowsType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMultiagentWorkflows emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMultiagentWorkflowsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentWorkflowsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentWorkflowsType.Disabled)]
    public void Validation_Works(BetaManagedAgentsMultiagentWorkflowsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentWorkflowsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentWorkflowsType.Disabled)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMultiagentWorkflowsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentWorkflowsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
