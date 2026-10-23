using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsServiceTierTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsServiceTier.Batch)]
    [InlineData(BetaAnalyticsServiceTier.Flex)]
    [InlineData(BetaAnalyticsServiceTier.FlexDiscount)]
    [InlineData(BetaAnalyticsServiceTier.Priority)]
    [InlineData(BetaAnalyticsServiceTier.PriorityOnDemand)]
    [InlineData(BetaAnalyticsServiceTier.Standard)]
    public void Validation_Works(BetaAnalyticsServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsServiceTier.Batch)]
    [InlineData(BetaAnalyticsServiceTier.Flex)]
    [InlineData(BetaAnalyticsServiceTier.FlexDiscount)]
    [InlineData(BetaAnalyticsServiceTier.Priority)]
    [InlineData(BetaAnalyticsServiceTier.PriorityOnDemand)]
    [InlineData(BetaAnalyticsServiceTier.Standard)]
    public void SerializationRoundtrip_Works(BetaAnalyticsServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
