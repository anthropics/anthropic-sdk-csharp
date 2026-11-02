using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsArtifactGroupByTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsArtifactGroupBy.Product)]
    [InlineData(BetaAnalyticsArtifactGroupBy.RbacGroupID)]
    [InlineData(BetaAnalyticsArtifactGroupBy.UserID)]
    public void Validation_Works(BetaAnalyticsArtifactGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsArtifactGroupBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsArtifactGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsArtifactGroupBy.Product)]
    [InlineData(BetaAnalyticsArtifactGroupBy.RbacGroupID)]
    [InlineData(BetaAnalyticsArtifactGroupBy.UserID)]
    public void SerializationRoundtrip_Works(BetaAnalyticsArtifactGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsArtifactGroupBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsArtifactGroupBy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsArtifactGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsArtifactGroupBy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
