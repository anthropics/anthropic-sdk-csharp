using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsProductFilterTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsProductFilter.Chat)]
    [InlineData(BetaAnalyticsProductFilter.ChatCoworkUnified)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeTag)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeCode)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeDesign)]
    [InlineData(BetaAnalyticsProductFilter.ClaudeInChrome)]
    [InlineData(BetaAnalyticsProductFilter.Cowork)]
    [InlineData(BetaAnalyticsProductFilter.OfficeAgent)]
    public void Validation_Works(BetaAnalyticsProductFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsProductFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsProductFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsProductFilter.Chat, 0, "chat")]
    [InlineData(BetaAnalyticsProductFilter.ChatCoworkUnified, 1, "chat_cowork_unified")]
    [InlineData(BetaAnalyticsProductFilter.ClaudeTag, 2, "claude-tag")]
    [InlineData(BetaAnalyticsProductFilter.ClaudeCode, 3, "claude_code")]
    [InlineData(BetaAnalyticsProductFilter.ClaudeDesign, 4, "claude_design")]
    [InlineData(BetaAnalyticsProductFilter.ClaudeInChrome, 5, "claude_in_chrome")]
    [InlineData(BetaAnalyticsProductFilter.Cowork, 6, "cowork")]
    [InlineData(BetaAnalyticsProductFilter.OfficeAgent, 7, "office_agent")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsProductFilter rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsProductFilter> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsProductFilter>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsProductFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsProductFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
