using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsArtifactGroupByTest : TestBase
{
    [Theory]
    [InlineData(AnalyticsArtifactGroupBy.Product)]
    [InlineData(AnalyticsArtifactGroupBy.RbacGroupID)]
    [InlineData(AnalyticsArtifactGroupBy.UserID)]
    public void Validation_Works(AnalyticsArtifactGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnalyticsArtifactGroupBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsArtifactGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AnalyticsArtifactGroupBy.Product)]
    [InlineData(AnalyticsArtifactGroupBy.RbacGroupID)]
    [InlineData(AnalyticsArtifactGroupBy.UserID)]
    public void SerializationRoundtrip_Works(AnalyticsArtifactGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnalyticsArtifactGroupBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsArtifactGroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsArtifactGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsArtifactGroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
