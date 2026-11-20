using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsClaudeTagCategoryTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsClaudeTagCategory.Dm)]
    [InlineData(BetaAnalyticsClaudeTagCategory.Engaged)]
    [InlineData(BetaAnalyticsClaudeTagCategory.Monitoring)]
    [InlineData(BetaAnalyticsClaudeTagCategory.Proactive)]
    [InlineData(BetaAnalyticsClaudeTagCategory.Scheduled)]
    public void Validation_Works(BetaAnalyticsClaudeTagCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsClaudeTagCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsClaudeTagCategory.Dm, 0, "dm")]
    [InlineData(BetaAnalyticsClaudeTagCategory.Engaged, 1, "engaged")]
    [InlineData(BetaAnalyticsClaudeTagCategory.Monitoring, 2, "monitoring")]
    [InlineData(BetaAnalyticsClaudeTagCategory.Proactive, 3, "proactive")]
    [InlineData(BetaAnalyticsClaudeTagCategory.Scheduled, 4, "scheduled")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsClaudeTagCategory rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsClaudeTagCategory>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsClaudeTagCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsClaudeTagCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
