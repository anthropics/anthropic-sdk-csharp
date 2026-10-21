using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class BetaSpendLimitPeriodTest : TestBase
{
    [Theory]
    [InlineData(BetaSpendLimitPeriod.Daily)]
    [InlineData(BetaSpendLimitPeriod.Monthly)]
    [InlineData(BetaSpendLimitPeriod.Weekly)]
    public void Validation_Works(BetaSpendLimitPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendLimitPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaSpendLimitPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaSpendLimitPeriod.Daily)]
    [InlineData(BetaSpendLimitPeriod.Monthly)]
    [InlineData(BetaSpendLimitPeriod.Weekly)]
    public void SerializationRoundtrip_Works(BetaSpendLimitPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendLimitPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaSpendLimitPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaSpendLimitPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaSpendLimitPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
