using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics.Usage;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Usage;

public class BetaAnalyticsUsageOrderByTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsUsageOrderBy.OutputTokens)]
    [InlineData(BetaAnalyticsUsageOrderBy.Requests)]
    [InlineData(BetaAnalyticsUsageOrderBy.Time)]
    [InlineData(BetaAnalyticsUsageOrderBy.TotalTokens)]
    [InlineData(BetaAnalyticsUsageOrderBy.UncachedInputTokens)]
    public void Validation_Works(BetaAnalyticsUsageOrderBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageOrderBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageOrderBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsUsageOrderBy.OutputTokens)]
    [InlineData(BetaAnalyticsUsageOrderBy.Requests)]
    [InlineData(BetaAnalyticsUsageOrderBy.Time)]
    [InlineData(BetaAnalyticsUsageOrderBy.TotalTokens)]
    [InlineData(BetaAnalyticsUsageOrderBy.UncachedInputTokens)]
    public void SerializationRoundtrip_Works(BetaAnalyticsUsageOrderBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageOrderBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageOrderBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageOrderBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageOrderBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
