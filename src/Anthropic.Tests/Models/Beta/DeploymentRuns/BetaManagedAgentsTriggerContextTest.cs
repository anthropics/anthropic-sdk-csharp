using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsTriggerContextTest : TestBase
{
    [Fact]
    public void ScheduleValidationWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsScheduleTriggerContext(
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
        );
        value.Validate();
    }

    [Fact]
    public void ManualValidationWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsManualTriggerContext();
        value.Validate();
    }

    [Fact]
    public void ScheduleSerializationRoundtripWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsScheduleTriggerContext(
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTriggerContext>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ManualSerializationRoundtripWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsManualTriggerContext();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTriggerContext>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScheduleTypeWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsScheduleTriggerContext(
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
        );
        Assert.Equal(BetaManagedAgentsTriggerContextType.Schedule, value.Type.Value());
    }

    [Fact]
    public void ManualTypeWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsManualTriggerContext();
        Assert.Equal(BetaManagedAgentsTriggerContextType.Manual, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsTriggerContext value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "schedule"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsTriggerContextType> expectedType =
            BetaManagedAgentsTriggerContextType.Schedule;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsTriggerContext emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsTriggerContextTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsTriggerContextType.Schedule)]
    [InlineData(BetaManagedAgentsTriggerContextType.Manual)]
    public void Validation_Works(BetaManagedAgentsTriggerContextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTriggerContextType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTriggerContextType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsTriggerContextType.Schedule)]
    [InlineData(BetaManagedAgentsTriggerContextType.Manual)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsTriggerContextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTriggerContextType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTriggerContextType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTriggerContextType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTriggerContextType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
