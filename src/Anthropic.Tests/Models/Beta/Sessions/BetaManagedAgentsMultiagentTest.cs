using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsMultiagentTest : TestBase
{
    [Fact]
    public void CoordinatorValidationWorks()
    {
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagentCoordinator(
            [
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Version = 1,
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void Multiagent20261001ValidationWorks()
    {
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagent20261001()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            },
        };
        value.Validate();
    }

    [Fact]
    public void CoordinatorSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagentCoordinator(
            [
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Version = 1,
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Multiagent20261001SerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagent20261001()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CoordinatorTypeWorks()
    {
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagentCoordinator(
            [
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Version = 1,
                },
            ]
        );
        Assert.Equal(BetaManagedAgentsMultiagentType.Coordinator, value.Type.Value());
    }

    [Fact]
    public void Multiagent20261001TypeWorks()
    {
        BetaManagedAgentsMultiagent value = new BetaManagedAgentsMultiagent20261001()
        {
            Advisor = new BetaManagedAgentsMultiagentAdvisorDisabled(),
            Subagents = new BetaManagedAgentsMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            },
            Workflows = new BetaManagedAgentsMultiagentWorkflowsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsEnabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            },
        };
        Assert.Equal(BetaManagedAgentsMultiagentType.Multiagent20261001, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "coordinator"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsMultiagentType> expectedType =
            BetaManagedAgentsMultiagentType.Coordinator;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMultiagent emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMultiagentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentType.Coordinator)]
    [InlineData(BetaManagedAgentsMultiagentType.Multiagent20261001)]
    public void Validation_Works(BetaManagedAgentsMultiagentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMultiagentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentType.Coordinator)]
    [InlineData(BetaManagedAgentsMultiagentType.Multiagent20261001)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMultiagentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMultiagentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
