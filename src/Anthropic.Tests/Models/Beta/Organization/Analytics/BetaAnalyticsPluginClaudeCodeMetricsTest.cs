using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsPluginClaudeCodeMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        long expectedDistinctSessionPluginUsedCount = 0;

        Assert.Equal(expectedDistinctSessionPluginUsedCount, model.DistinctSessionPluginUsedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsPluginClaudeCodeMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsPluginClaudeCodeMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDistinctSessionPluginUsedCount = 0;

        Assert.Equal(
            expectedDistinctSessionPluginUsedCount,
            deserialized.DistinctSessionPluginUsedCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        BetaAnalyticsPluginClaudeCodeMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
