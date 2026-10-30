using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsPluginClaudeCodeMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        long expectedDistinctSessionPluginUsedCount = 0;

        Assert.Equal(expectedDistinctSessionPluginUsedCount, model.DistinctSessionPluginUsedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsPluginClaudeCodeMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsPluginClaudeCodeMetrics>(
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
        var model = new AnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsPluginClaudeCodeMetrics { DistinctSessionPluginUsedCount = 0 };

        AnalyticsPluginClaudeCodeMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
