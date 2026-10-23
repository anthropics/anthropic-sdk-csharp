using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsUsageCostProductFilterTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsUsageCostProductFilter.Chat)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ChatCoworkUnified)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeCode)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeConsole)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeDesign)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeInChrome)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeTag)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.Cowork)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ManagedAgentsApi)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.MessageBatchesApi)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.MessagesApi)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.OfficeAgent)]
    public void Validation_Works(BetaAnalyticsUsageCostProductFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageCostProductFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageCostProductFilter>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsUsageCostProductFilter.Chat)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ChatCoworkUnified)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeCode)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeConsole)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeDesign)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeInChrome)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeTag)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.Cowork)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ManagedAgentsApi)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.MessageBatchesApi)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.MessagesApi)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.OfficeAgent)]
    public void SerializationRoundtrip_Works(BetaAnalyticsUsageCostProductFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageCostProductFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageCostProductFilter>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageCostProductFilter>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageCostProductFilter>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
