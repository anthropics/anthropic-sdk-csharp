using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsCronScheduleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsCronScheduleParamsType.Cron,
        };

        string expectedExpression = "0 9 * * 1-5";
        string expectedTimezone = "America/Los_Angeles";
        ApiEnum<string, BetaManagedAgentsCronScheduleParamsType> expectedType =
            BetaManagedAgentsCronScheduleParamsType.Cron;

        Assert.Equal(expectedExpression, model.Expression);
        Assert.Equal(expectedTimezone, model.Timezone);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsCronScheduleParamsType.Cron,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCronScheduleParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsCronScheduleParamsType.Cron,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCronScheduleParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExpression = "0 9 * * 1-5";
        string expectedTimezone = "America/Los_Angeles";
        ApiEnum<string, BetaManagedAgentsCronScheduleParamsType> expectedType =
            BetaManagedAgentsCronScheduleParamsType.Cron;

        Assert.Equal(expectedExpression, deserialized.Expression);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsCronScheduleParamsType.Cron,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsCronScheduleParamsType.Cron,
        };

        BetaManagedAgentsCronScheduleParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsCronScheduleParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsCronScheduleParamsType.Cron)]
    public void Validation_Works(BetaManagedAgentsCronScheduleParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCronScheduleParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCronScheduleParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsCronScheduleParamsType.Cron)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsCronScheduleParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCronScheduleParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCronScheduleParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCronScheduleParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCronScheduleParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
