using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsTimeBucketWidthTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsTimeBucketWidth.Day)]
    [InlineData(BetaAnalyticsTimeBucketWidth.Hour)]
    [InlineData(BetaAnalyticsTimeBucketWidth.Minute)]
    public void Validation_Works(BetaAnalyticsTimeBucketWidth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsTimeBucketWidth> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsTimeBucketWidth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsTimeBucketWidth.Day)]
    [InlineData(BetaAnalyticsTimeBucketWidth.Hour)]
    [InlineData(BetaAnalyticsTimeBucketWidth.Minute)]
    public void SerializationRoundtrip_Works(BetaAnalyticsTimeBucketWidth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsTimeBucketWidth> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsTimeBucketWidth>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsTimeBucketWidth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsTimeBucketWidth>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
