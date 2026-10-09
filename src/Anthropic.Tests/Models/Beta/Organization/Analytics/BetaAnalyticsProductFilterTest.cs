using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsProductFilterTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsProductFilter.Chat)]
    [InlineData(BetaAnalyticsProductFilter.ChatCoworkUnified)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeTag)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeCode)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeDesign)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeInChrome)]
    [InlineData(BetaAnalyticsProductFilter.Cowork)]
    [InlineData(BetaAnalyticsProductFilter.OfficeAgent)]
    public void Validation_Works(BetaAnalyticsProductFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsProductFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsProductFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsProductFilter.Chat)]
    [InlineData(BetaAnalyticsProductFilter.ChatCoworkUnified)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeTag)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeCode)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeDesign)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeInChrome)]
    [InlineData(BetaAnalyticsProductFilter.Cowork)]
    [InlineData(BetaAnalyticsProductFilter.OfficeAgent)]
    public void SerializationRoundtrip_Works(BetaAnalyticsProductFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsProductFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsProductFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsProductFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsProductFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
