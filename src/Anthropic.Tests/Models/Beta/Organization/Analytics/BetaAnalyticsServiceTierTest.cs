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
    [InlineData(BetaAnalyticsServiceTier.Batch, 0, "batch")]
    [InlineData(BetaAnalyticsServiceTier.Flex, 1, "flex")]
    [InlineData(BetaAnalyticsServiceTier.FlexDiscount, 2, "flex_discount")]
    [InlineData(BetaAnalyticsServiceTier.Priority, 3, "priority")]
    [InlineData(BetaAnalyticsServiceTier.PriorityOnDemand, 4, "priority_on_demand")]
    [InlineData(BetaAnalyticsServiceTier.Standard, 5, "standard")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsServiceTier rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsServiceTier> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsServiceTier>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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
