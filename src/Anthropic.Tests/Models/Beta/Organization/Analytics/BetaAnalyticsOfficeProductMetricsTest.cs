using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsOfficeProductMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsOfficeProductMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        long expectedConnectorsUsedCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSkillsUsedCount = 0;

        Assert.Equal(expectedConnectorsUsedCount, model.ConnectorsUsedCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, model.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, model.DistinctSessionCount);
        Assert.Equal(expectedDistinctSkillsUsedCount, model.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedSkillsUsedCount, model.SkillsUsedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsOfficeProductMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsOfficeProductMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsOfficeProductMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsOfficeProductMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedConnectorsUsedCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSkillsUsedCount = 0;

        Assert.Equal(expectedConnectorsUsedCount, deserialized.ConnectorsUsedCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, deserialized.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, deserialized.DistinctSessionCount);
        Assert.Equal(expectedDistinctSkillsUsedCount, deserialized.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(expectedSkillsUsedCount, deserialized.SkillsUsedCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsOfficeProductMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsOfficeProductMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        BetaAnalyticsOfficeProductMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
