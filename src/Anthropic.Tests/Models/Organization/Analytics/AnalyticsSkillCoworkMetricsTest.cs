using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsSkillCoworkMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsSkillCoworkMetrics { DistinctSessionSkillUsedCount = 0 };

        long expectedDistinctSessionSkillUsedCount = 0;

        Assert.Equal(expectedDistinctSessionSkillUsedCount, model.DistinctSessionSkillUsedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AnalyticsSkillCoworkMetrics { DistinctSessionSkillUsedCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsSkillCoworkMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsSkillCoworkMetrics { DistinctSessionSkillUsedCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsSkillCoworkMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDistinctSessionSkillUsedCount = 0;

        Assert.Equal(
            expectedDistinctSessionSkillUsedCount,
            deserialized.DistinctSessionSkillUsedCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AnalyticsSkillCoworkMetrics { DistinctSessionSkillUsedCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsSkillCoworkMetrics { DistinctSessionSkillUsedCount = 0 };

        AnalyticsSkillCoworkMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
