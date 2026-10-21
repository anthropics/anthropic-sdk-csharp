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
    public void EnabledTypeWorks()
    {
        BetaManagedAgentsMultiagentInlineAgents value =
            new BetaManagedAgentsMultiagentInlineAgentsEnabled();
        Assert.Equal(BetaManagedAgentsMultiagentInlineAgentsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaManagedAgentsMultiagentInlineAgents value =
            new BetaManagedAgentsMultiagentInlineAgentsDisabled();
        Assert.Equal(BetaManagedAgentsMultiagentInlineAgentsType.Disabled, value.Type.Value());
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

        ApiEnum<string, BetaManagedAgentsMultiagentInlineAgentsType> expectedType =
            BetaManagedAgentsMultiagentInlineAgentsType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMultiagentInlineAgents emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMultiagentInlineAgentsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentInlineAgentsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentInlineAgentsType.Disabled)]
    public void Validation_Works(BetaManagedAgentsMultiagentInlineAgentsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentInlineAgentsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentInlineAgentsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentInlineAgentsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentInlineAgentsType.Disabled)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMultiagentInlineAgentsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentInlineAgentsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentInlineAgentsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentInlineAgentsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentInlineAgentsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
