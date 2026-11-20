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
    [InlineData(BetaAnalyticsInferenceGeoFilter.Global, 0, "global")]
    [InlineData(BetaAnalyticsInferenceGeoFilter.NotAvailable, 1, "not_available")]
    [InlineData(BetaAnalyticsInferenceGeoFilter.Us, 2, "us")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsInferenceGeoFilter rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsInferenceGeoFilter> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsInferenceGeoFilter>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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
