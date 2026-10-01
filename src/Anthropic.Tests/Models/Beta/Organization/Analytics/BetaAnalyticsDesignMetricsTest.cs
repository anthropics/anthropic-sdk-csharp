using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsDesignMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsDesignMetrics
        {
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
        };

        long expectedDistinctProjectsCreatedCount = 0;
        long expectedDistinctProjectsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedMessageCount = 0;

        Assert.Equal(expectedDistinctProjectsCreatedCount, model.DistinctProjectsCreatedCount);
        Assert.Equal(expectedDistinctProjectsUsedCount, model.DistinctProjectsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, model.DistinctSessionCount);
        Assert.Equal(expectedMessageCount, model.MessageCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsDesignMetrics
        {
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsDesignMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsDesignMetrics
        {
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsDesignMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDistinctProjectsCreatedCount = 0;
        long expectedDistinctProjectsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedMessageCount = 0;

        Assert.Equal(
            expectedDistinctProjectsCreatedCount,
            deserialized.DistinctProjectsCreatedCount
        );
        Assert.Equal(expectedDistinctProjectsUsedCount, deserialized.DistinctProjectsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, deserialized.DistinctSessionCount);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsDesignMetrics
        {
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsDesignMetrics
        {
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
        };

        BetaAnalyticsDesignMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
