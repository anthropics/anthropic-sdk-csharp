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
    [InlineData(BetaAnalyticsTimeBucketWidth.Day, 0, "1d")]
    [InlineData(BetaAnalyticsTimeBucketWidth.Hour, 1, "1h")]
    [InlineData(BetaAnalyticsTimeBucketWidth.Minute, 2, "1m")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsTimeBucketWidth rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsTimeBucketWidth> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsTimeBucketWidth>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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
