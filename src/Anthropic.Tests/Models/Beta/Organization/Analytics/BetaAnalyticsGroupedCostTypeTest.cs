using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsGroupedCostTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsGroupedCostType.CodeExecution)]
    [InlineData(BetaAnalyticsGroupedCostType.SessionUsage)]
    [InlineData(BetaAnalyticsGroupedCostType.Tokens)]
    [InlineData(BetaAnalyticsGroupedCostType.WebSearch)]
    public void Validation_Works(BetaAnalyticsGroupedCostType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsGroupedCostType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsGroupedCostType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsGroupedCostType.CodeExecution)]
    [InlineData(BetaAnalyticsGroupedCostType.SessionUsage)]
    [InlineData(BetaAnalyticsGroupedCostType.Tokens)]
    [InlineData(BetaAnalyticsGroupedCostType.WebSearch)]
    public void SerializationRoundtrip_Works(BetaAnalyticsGroupedCostType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsGroupedCostType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsGroupedCostType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsGroupedCostType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsGroupedCostType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
