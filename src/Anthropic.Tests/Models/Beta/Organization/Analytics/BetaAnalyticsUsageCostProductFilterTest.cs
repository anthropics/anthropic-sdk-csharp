using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsUsageCostProductFilterTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsUsageCostProductFilter.Chat)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ChatCoworkUnified)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeCode)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeConsole)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeDesign)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeInChrome)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeTag)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.Cowork)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ManagedAgentsApi)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.MessageBatchesApi)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.MessagesApi)]
    [InlineData(BetaAnalyticsUsageCostProductFilter.OfficeAgent)]
    public void Validation_Works(BetaAnalyticsUsageCostProductFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageCostProductFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageCostProductFilter>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsUsageCostProductFilter.Chat, 0, "chat")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ChatCoworkUnified, 1, "chat_cowork_unified")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeCode, 2, "claude_code")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeConsole, 3, "claude_console")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeDesign, 4, "claude_design")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeInChrome, 5, "claude_in_chrome")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ClaudeTag, 6, "claude_tag")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.Cowork, 7, "cowork")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.ManagedAgentsApi, 8, "managed_agents_api")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.MessageBatchesApi, 9, "message_batches_api")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.MessagesApi, 10, "messages_api")]
    [InlineData(BetaAnalyticsUsageCostProductFilter.OfficeAgent, 11, "office_agent")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsUsageCostProductFilter rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageCostProductFilter> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageCostProductFilter>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageCostProductFilter>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageCostProductFilter>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
