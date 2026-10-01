using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsConnectorChatMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsConnectorChatMetrics
        {
            DistinctConversationConnectorUsedCount = 0,
        };

        long expectedDistinctConversationConnectorUsedCount = 0;

        Assert.Equal(
            expectedDistinctConversationConnectorUsedCount,
            model.DistinctConversationConnectorUsedCount
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsConnectorChatMetrics
        {
            DistinctConversationConnectorUsedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsConnectorChatMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsConnectorChatMetrics
        {
            DistinctConversationConnectorUsedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsConnectorChatMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDistinctConversationConnectorUsedCount = 0;

        Assert.Equal(
            expectedDistinctConversationConnectorUsedCount,
            deserialized.DistinctConversationConnectorUsedCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsConnectorChatMetrics
        {
            DistinctConversationConnectorUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsConnectorChatMetrics
        {
            DistinctConversationConnectorUsedCount = 0,
        };

        BetaAnalyticsConnectorChatMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
