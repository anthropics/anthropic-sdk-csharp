using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsScheduleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleParamsType.Cron,
        };

        string expectedExpression = "0 9 * * 1-5";
        string expectedTimezone = "America/Los_Angeles";
        ApiEnum<string, BetaManagedAgentsScheduleParamsType> expectedType =
            BetaManagedAgentsScheduleParamsType.Cron;

        Assert.Equal(expectedExpression, model.Expression);
        Assert.Equal(expectedTimezone, model.Timezone);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleParamsType.Cron,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsScheduleParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleParamsType.Cron,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsScheduleParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExpression = "0 9 * * 1-5";
        string expectedTimezone = "America/Los_Angeles";
        ApiEnum<string, BetaManagedAgentsScheduleParamsType> expectedType =
            BetaManagedAgentsScheduleParamsType.Cron;

        Assert.Equal(expectedExpression, deserialized.Expression);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleParamsType.Cron,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleParamsType.Cron,
        };

        BetaManagedAgentsScheduleParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsScheduleParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsScheduleParamsType.Cron)]
    public void Validation_Works(BetaManagedAgentsScheduleParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsScheduleParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsScheduleParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsScheduleParamsType.Cron)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsScheduleParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsScheduleParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsScheduleParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsScheduleParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsScheduleParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
