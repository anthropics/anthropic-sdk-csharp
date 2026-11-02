using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsConnectorChatMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsConnectorChatMetrics
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
        var model = new AnalyticsConnectorChatMetrics
        {
            DistinctConversationConnectorUsedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsConnectorChatMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsConnectorChatMetrics
        {
            DistinctConversationConnectorUsedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsConnectorChatMetrics>(
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
        var model = new AnalyticsConnectorChatMetrics
        {
            DistinctConversationConnectorUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsConnectorChatMetrics
        {
            DistinctConversationConnectorUsedCount = 0,
        };

        AnalyticsConnectorChatMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
