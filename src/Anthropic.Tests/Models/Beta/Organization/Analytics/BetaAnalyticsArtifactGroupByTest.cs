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
    [InlineData(BetaAnalyticsArtifactGroupBy.Product, 0, "product")]
    [InlineData(BetaAnalyticsArtifactGroupBy.RbacGroupID, 1, "rbac_group_id")]
    [InlineData(BetaAnalyticsArtifactGroupBy.UserID, 2, "user_id")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsArtifactGroupBy rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsArtifactGroupBy> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsArtifactGroupBy>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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
