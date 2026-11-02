using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsConnectorGroupByTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsConnectorGroupBy.Product)]
    [InlineData(BetaAnalyticsConnectorGroupBy.RbacGroupID)]
    [InlineData(BetaAnalyticsConnectorGroupBy.UserID)]
    public void Validation_Works(BetaAnalyticsConnectorGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsConnectorGroupBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsConnectorGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsConnectorGroupBy.Product)]
    [InlineData(BetaAnalyticsConnectorGroupBy.RbacGroupID)]
    [InlineData(BetaAnalyticsConnectorGroupBy.UserID)]
    public void SerializationRoundtrip_Works(BetaAnalyticsConnectorGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsConnectorGroupBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsConnectorGroupBy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsConnectorGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsConnectorGroupBy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
