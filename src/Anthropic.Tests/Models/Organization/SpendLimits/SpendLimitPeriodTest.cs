using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Organization.SpendLimits;

public class SpendLimitPeriodTest : TestBase
{
    [Theory]
    [InlineData(SpendLimitPeriod.Daily)]
    [InlineData(SpendLimitPeriod.Monthly)]
    [InlineData(SpendLimitPeriod.Weekly)]
    public void Validation_Works(SpendLimitPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendLimitPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpendLimitPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SpendLimitPeriod.Daily)]
    [InlineData(SpendLimitPeriod.Monthly)]
    [InlineData(SpendLimitPeriod.Weekly)]
    public void SerializationRoundtrip_Works(SpendLimitPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendLimitPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SpendLimitPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpendLimitPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SpendLimitPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
