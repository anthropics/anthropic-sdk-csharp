using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentSubagentsTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaManagedAgentsMultiagentSubagents value =
            new BetaManagedAgentsMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            };
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaManagedAgentsMultiagentSubagents value =
            new BetaManagedAgentsMultiagentSubagentsDisabled();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentSubagents value =
            new BetaManagedAgentsMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSubagents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsMultiagentSubagents value =
            new BetaManagedAgentsMultiagentSubagentsDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSubagents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaManagedAgentsMultiagentSubagents value =
            new BetaManagedAgentsMultiagentSubagentsEnabled()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabled(),
                PredefinedAgents = [new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 }],
            };
        Assert.Equal(BetaManagedAgentsMultiagentSubagentsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaManagedAgentsMultiagentSubagents value =
            new BetaManagedAgentsMultiagentSubagentsDisabled();
        Assert.Equal(BetaManagedAgentsMultiagentSubagentsType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMultiagentSubagents value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsMultiagentSubagentsType> expectedType =
            BetaManagedAgentsMultiagentSubagentsType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMultiagentSubagents emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMultiagentSubagentsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentSubagentsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentSubagentsType.Disabled)]
    public void Validation_Works(BetaManagedAgentsMultiagentSubagentsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentSubagentsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentSubagentsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentSubagentsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentSubagentsType.Disabled)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMultiagentSubagentsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentSubagentsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentSubagentsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentSubagentsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentSubagentsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
