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
                    new BetaManagedAgentsMultiagentSelfParams(),
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
                    new BetaManagedAgentsMultiagentSelfParams(),
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
    public void EnabledTypeWorks()
    {
        BetaManagedAgentsMultiagentSubagentsParams value =
            new BetaManagedAgentsMultiagentSubagentsEnabledParams()
            {
                InlineAgents = new BetaManagedAgentsMultiagentInlineAgentsDisabledParams(),
                PredefinedAgents =
                [
                    "agent_011CZkYqphY8vELVzwCUpqiQ",
                    new BetaManagedAgentsMultiagentSelfParams(),
                ],
            };
        Assert.Equal(BetaManagedAgentsMultiagentSubagentsParamsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaManagedAgentsMultiagentSubagentsParams value =
            new BetaManagedAgentsMultiagentSubagentsDisabledParams();
        Assert.Equal(BetaManagedAgentsMultiagentSubagentsParamsType.Disabled, value.Type.Value());
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

        ApiEnum<string, BetaManagedAgentsMultiagentSubagentsParamsType> expectedType =
            BetaManagedAgentsMultiagentSubagentsParamsType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMultiagentSubagentsParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMultiagentSubagentsParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentSubagentsParamsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentSubagentsParamsType.Disabled)]
    public void Validation_Works(BetaManagedAgentsMultiagentSubagentsParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentSubagentsParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentSubagentsParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentSubagentsParamsType.Enabled)]
    [InlineData(BetaManagedAgentsMultiagentSubagentsParamsType.Disabled)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMultiagentSubagentsParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentSubagentsParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentSubagentsParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentSubagentsParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentSubagentsParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
