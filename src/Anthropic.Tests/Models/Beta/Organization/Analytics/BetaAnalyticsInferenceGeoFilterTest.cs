using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsInferenceGeoFilterTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsInferenceGeoFilter.Global)]
    [InlineData(BetaAnalyticsInferenceGeoFilter.NotAvailable)]
    [InlineData(BetaAnalyticsInferenceGeoFilter.Us)]
    public void Validation_Works(BetaAnalyticsInferenceGeoFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsInferenceGeoFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsInferenceGeoFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsInferenceGeoFilter.Global)]
    [InlineData(BetaAnalyticsInferenceGeoFilter.NotAvailable)]
    [InlineData(BetaAnalyticsInferenceGeoFilter.Us)]
    public void SerializationRoundtrip_Works(BetaAnalyticsInferenceGeoFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsInferenceGeoFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsInferenceGeoFilter>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsInferenceGeoFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsInferenceGeoFilter>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
