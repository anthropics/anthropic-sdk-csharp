using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsConnectorClaudeCodeMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsConnectorClaudeCodeMetrics
        {
            DistinctSessionConnectorUsedCount = 0,
        };

        long expectedDistinctSessionConnectorUsedCount = 0;

        Assert.Equal(
            expectedDistinctSessionConnectorUsedCount,
            model.DistinctSessionConnectorUsedCount
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsConnectorClaudeCodeMetrics
        {
            DistinctSessionConnectorUsedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsConnectorClaudeCodeMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsConnectorClaudeCodeMetrics
        {
            DistinctSessionConnectorUsedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsConnectorClaudeCodeMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDistinctSessionConnectorUsedCount = 0;

        Assert.Equal(
            expectedDistinctSessionConnectorUsedCount,
            deserialized.DistinctSessionConnectorUsedCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsConnectorClaudeCodeMetrics
        {
            DistinctSessionConnectorUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsConnectorClaudeCodeMetrics
        {
            DistinctSessionConnectorUsedCount = 0,
        };

        BetaAnalyticsConnectorClaudeCodeMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
