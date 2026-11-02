using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsPluginGroupByTest : TestBase
{
    [Theory]
    [InlineData(AnalyticsPluginGroupBy.Product)]
    [InlineData(AnalyticsPluginGroupBy.RbacGroupID)]
    [InlineData(AnalyticsPluginGroupBy.UserID)]
    public void Validation_Works(AnalyticsPluginGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnalyticsPluginGroupBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsPluginGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AnalyticsPluginGroupBy.Product)]
    [InlineData(AnalyticsPluginGroupBy.RbacGroupID)]
    [InlineData(AnalyticsPluginGroupBy.UserID)]
    public void SerializationRoundtrip_Works(AnalyticsPluginGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnalyticsPluginGroupBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsPluginGroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsPluginGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsPluginGroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
